using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using LoginRadius.Sdk;
using LoginRadius.Sdk.Internal.OpenApi.Client;
using LoginRadius.Sdk.Internal.OpenApi.Model;

namespace LoginRadius.Sdk.Demo;

/// <summary>
/// The demo's nine contract handlers, one per route in <see cref="DemoRoutes"/>,
/// plus extended handlers for email, phone, custom objects, token management,
/// and passkeys (registered by <see cref="ExtendedDemoRoutes"/>).
///
/// <para><c>DemoRoutes.All()</c> references every method below by name, so this
/// class stops compiling the moment the manifest gains a route nobody has
/// implemented. HTTP-method checking and session enforcement live in Program —
/// each handler here is only the interesting part: the SDK call.</para>
/// </summary>
public sealed class DemoHandlers(LoginRadiusClient client, LoginRadiusConfig config, DemoSessions sessions)
{
    private static Option<string> Opt(string? v) => new(v ?? "");

    /// <summary>
    /// True if <paramref name="root"/> is an in-progress MFA challenge
    /// (<c>AuthResponseRequiredMfa</c>) rather than a completed login, with
    /// <paramref name="token"/> set to its challenge token.
    ///
    /// <para>Per the spec, <c>AuthResponseRequiredMfa</c> is
    /// <c>TwoFactorAuthenticationTokenObject</c> + <c>AuthResponseRequiredMfaCore</c>,
    /// which puts <c>SecondFactorAuthenticationToken</c> flat on the response
    /// root — NOT nested under a <c>SecondFactorAuthentication</c> object. That
    /// nested field is a different, unrelated one that appears only on the
    /// non-challenge <c>AuthResponseOptionalMfa</c> success branch.</para>
    /// </summary>
    private static bool TryGetMfaToken(JsonElement root, out string token)
    {
        if (root.TryGetProperty("SecondFactorAuthenticationToken", out var tokenEl) &&
            tokenEl.ValueKind == JsonValueKind.String &&
            !string.IsNullOrEmpty(tokenEl.GetString()))
        {
            token = tokenEl.GetString()!;
            return true;
        }
        token = "";
        return false;
    }

    /// <summary>
    /// Builds the JSON body for an in-progress MFA challenge, shared by
    /// <see cref="Login"/> and both passwordless OTP handlers. Field set
    /// mirrors Node's, PHP's and Java's demos exactly.
    /// </summary>
    private static object MfaChallengeBody(JsonElement root)
    {
        bool totpEnrolled =
            (root.TryGetProperty("IsGoogleAuthenticatorVerified", out var g) && g.ValueKind == JsonValueKind.True) ||
            (root.TryGetProperty("IsAuthenticatorVerified", out var a) && a.ValueKind == JsonValueKind.True);
        string? manualEntryCode =
            root.TryGetProperty("ManualEntryCode", out var m) && m.ValueKind == JsonValueKind.String ? m.GetString() : null;
        string? qrCode =
            root.TryGetProperty("QRCode", out var q) && q.ValueKind == JsonValueKind.String ? q.GetString() : null;
        return new
        {
            mfa_required = true,
            totp_enrolled = totpEnrolled,
            manual_entry_code = manualEntryCode,
            qr_code = qrCode,
            response = root.Clone(),
        };
    }

    /// <summary>
    /// Like <see cref="Opt"/>, but omits the parameter entirely when the value
    /// is null or empty rather than sending an empty string. Needed wherever
    /// "unset" and "empty" are different requests to the API — e.g. picking
    /// which branch of a oneOf request applies.
    /// </summary>
    private static Option<string> OptIfSet(string? v) => string.IsNullOrEmpty(v) ? default : new(v);

    /// <summary>
    /// The fully-populated <see cref="JsonSerializerOptions"/> the generated
    /// client uses internally — every model type there registers its own
    /// converter to (de)serialize its <c>Option&lt;T&gt;</c> fields, and there is
    /// no built-in support for that on a plain <see cref="JsonSerializerOptions"/>.
    /// Built once, from a throwaway <see cref="HostConfiguration"/> — the same
    /// class <see cref="LoginRadiusClient"/> uses — so a raw request body can be
    /// deserialized straight into a generated model like
    /// <see cref="PasskeyRegisterFinish"/> without duplicating its converter
    /// wiring here.
    /// </summary>
    private static readonly JsonSerializerOptions ModelJsonOptions = BuildModelJsonOptions();

    private static JsonSerializerOptions BuildModelJsonOptions()
    {
        var services = new ServiceCollection();
        _ = new HostConfiguration(services);
        using var provider = services.BuildServiceProvider();
        return provider.GetRequiredService<JsonSerializerOptionsProvider>().Options;
    }

    // ------------------------------------------------------------------ auth --

    /// <summary>Registers a new user. Mints a SOTT server-side; never accepts one from the client.</summary>
    public async Task Register(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var email = Demo.Get(input, "email");
        var password = Demo.Get(input, "password");
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {email, password}" });
            return;
        }
        if (string.IsNullOrEmpty(config.ApiSecret))
        {
            await Demo.WriteJsonAsync(ctx, 500, new { error = "LR_API_SECRET is required for registration" });
            return;
        }

        // Minted per request: a SOTT is valid for ten minutes, so it must never
        // come from configuration — and never from the client.
        var sott = Sott.Generate(config.ApiKey!, config.ApiSecret!);

        var body = new ProfileRequestModel
        {
            Email = [new ProfileRequestModelEmailInner { Type = Opt("Primary"), Value = Opt(email) }],
            Password = Opt(password),
            FirstName = OptIfSet(Demo.Get(input, "firstName")),
            LastName = OptIfSet(Demo.Get(input, "lastName")),
        };

        await Demo.CallAsync(ctx, async () =>
            await client.Registration.UserRegistrationBySottEmailPhoneUserNameAsync(
                body, sott: Opt(sott), verificationurl: Opt(Demo.VerificationUrl)));
    }

    /// <summary>Email + password login. Stores the returned access token in the demo session.</summary>
    public async Task Login(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var email = Demo.Get(input, "email");
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(Demo.Get(input, "password")))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {email, password}" });
            return;
        }
        try
        {
            var body = new EmailByLoginUserNamePhoneRequest(
                new LoginByEmailRequest(
                    email: Opt(email),
                    password: Opt(Demo.Get(input, "password"))));

            var response = await client.Login.EmailByLoginUserNamePhoneAsync(body);

            if (!response.IsSuccessStatusCode)
            {
                await Demo.WriteErrorAsync(ctx,
                    LoginRadiusException.From((int)response.StatusCode, response.RawContent));
                return;
            }

            // Parse the raw JSON directly — the generated oneOf converter is
            // fragile and can lose the access_token on some response shapes.
            using var doc = JsonDocument.Parse(response.RawContent);
            var root = doc.RootElement;

            // MFA challenge: surface it instead of treating it as a failure.
            // Park the challenge token in its own cookie so the follow-up
            // /api/mfa/login/* call can complete it — never in the session
            // cookie, which nothing that reads it should accept from a
            // half-authenticated caller.
            if (TryGetMfaToken(root, out var mfaToken))
            {
                Demo.SetMfaCookie(ctx, mfaToken);
                await Demo.WriteJsonAsync(ctx, 200, MfaChallengeBody(root));
                return;
            }

            string? accessToken = null;
            if (root.TryGetProperty("access_token", out var tokenEl))
                accessToken = tokenEl.GetString();

            if (string.IsNullOrEmpty(accessToken))
            {
                await Demo.WriteJsonAsync(
                    ctx, 502, new { error = "login succeeded but no access_token was returned" });
                return;
            }

            Demo.SetSessionCookie(ctx, sessions.Create(accessToken));
            await Demo.WriteJsonAsync(ctx, 200, new { ok = true, result = root.Clone() });
        }
        catch (Exception e)
        {
            await Demo.WriteErrorAsync(ctx, e);
        }
    }

    // ------------------------------------------------------- passwordless --

    /// <summary>Emails a one-time code to an existing user; no password involved.</summary>
    public async Task PasswordlessLoginByEmail(HttpContext ctx)
    {
        var email = ctx.Request.Query["email"].ToString();
        if (string.IsNullOrEmpty(email))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected query param ?email=" });
            return;
        }
        try
        {
            var response = await client.Login.PasswordlessLoginByEmailAsync(email: Opt(email));
            if (!response.IsSuccessStatusCode)
            {
                await Demo.WriteErrorAsync(ctx,
                    LoginRadiusException.From((int)response.StatusCode, response.RawContent));
                return;
            }
            await Demo.WriteJsonAsync(ctx, 200, new { ok = true, result = response.RawContent });
        }
        catch (Exception e)
        {
            await Demo.WriteErrorAsync(ctx, e);
        }
    }

    /// <summary>
    /// Completes an email passwordless login. Same response shape as
    /// <see cref="Login"/>, including the MFA-challenge branch — a tenant with
    /// MFA enabled still enforces its second factor after the emailed code.
    /// </summary>
    public async Task PasswordlessLoginByEmailOtp(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var email = Demo.Get(input, "email");
        var otp = Demo.Get(input, "otp");
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(otp))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {email, otp}" });
            return;
        }
        try
        {
            var body = new PasswordLessEmailOTPModel(otp: otp, email: email);
            var response = await client.Login.PasswordlessLoginByEmailAndOTPAsync(body);

            if (!response.IsSuccessStatusCode)
            {
                await Demo.WriteErrorAsync(ctx,
                    LoginRadiusException.From((int)response.StatusCode, response.RawContent));
                return;
            }

            using var doc = JsonDocument.Parse(response.RawContent);
            var root = doc.RootElement;

            if (TryGetMfaToken(root, out var mfaToken))
            {
                Demo.SetMfaCookie(ctx, mfaToken);
                await Demo.WriteJsonAsync(ctx, 200, MfaChallengeBody(root));
                return;
            }

            string? accessToken = null;
            if (root.TryGetProperty("access_token", out var tokenEl))
                accessToken = tokenEl.GetString();

            if (string.IsNullOrEmpty(accessToken))
            {
                await Demo.WriteJsonAsync(
                    ctx, 502, new { error = "login succeeded but no access_token was returned" });
                return;
            }

            Demo.SetSessionCookie(ctx, sessions.Create(accessToken));
            await Demo.WriteJsonAsync(ctx, 200, new { ok = true, result = root.Clone() });
        }
        catch (Exception e)
        {
            await Demo.WriteErrorAsync(ctx, e);
        }
    }

    /// <summary>Texts a one-time code to an existing user; no password involved.</summary>
    public async Task PasswordlessLoginByPhone(HttpContext ctx)
    {
        var phone = ctx.Request.Query["phone"].ToString();
        if (string.IsNullOrEmpty(phone))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected query param ?phone=" });
            return;
        }
        try
        {
            var response = await client.Login.PasswordlessLoginByPhoneAsync(phone: Opt(phone));
            if (!response.IsSuccessStatusCode)
            {
                await Demo.WriteErrorAsync(ctx,
                    LoginRadiusException.From((int)response.StatusCode, response.RawContent));
                return;
            }
            await Demo.WriteJsonAsync(ctx, 200, new { ok = true, result = response.RawContent });
        }
        catch (Exception e)
        {
            await Demo.WriteErrorAsync(ctx, e);
        }
    }

    /// <summary>
    /// Completes a phone passwordless login. Same response shape as
    /// <see cref="Login"/>, including the MFA-challenge branch.
    /// </summary>
    public async Task PasswordlessLoginByPhoneOtp(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var phone = Demo.Get(input, "phone");
        var otp = Demo.Get(input, "otp");
        if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(otp))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {phone, otp}" });
            return;
        }
        try
        {
            var body = new PhoneOTPModel(oTP: otp, phone: phone);
            var response = await client.Login.PasswordlessLoginPhoneVerificationAsync(body);

            if (!response.IsSuccessStatusCode)
            {
                await Demo.WriteErrorAsync(ctx,
                    LoginRadiusException.From((int)response.StatusCode, response.RawContent));
                return;
            }

            using var doc = JsonDocument.Parse(response.RawContent);
            var root = doc.RootElement;

            if (TryGetMfaToken(root, out var mfaToken))
            {
                Demo.SetMfaCookie(ctx, mfaToken);
                await Demo.WriteJsonAsync(ctx, 200, MfaChallengeBody(root));
                return;
            }

            string? accessToken = null;
            if (root.TryGetProperty("access_token", out var tokenEl))
                accessToken = tokenEl.GetString();

            if (string.IsNullOrEmpty(accessToken))
            {
                await Demo.WriteJsonAsync(
                    ctx, 502, new { error = "login succeeded but no access_token was returned" });
                return;
            }

            Demo.SetSessionCookie(ctx, sessions.Create(accessToken));
            await Demo.WriteJsonAsync(ctx, 200, new { ok = true, result = root.Clone() });
        }
        catch (Exception e)
        {
            await Demo.WriteErrorAsync(ctx, e);
        }
    }

    /// <summary>Invalidates the access token upstream, then clears the demo session.</summary>
    public Task Logout(HttpContext ctx)
    {
        // The local session is cleared even if the upstream call fails —
        // otherwise a transient API error would leave the user unable to sign out.
        sessions.Delete(Demo.SessionId(ctx));
        Demo.ClearSessionCookie(ctx);
        return Demo.WriteJsonAsync(ctx, 200, new { ok = true });
    }

    /// <summary>
    /// Landing point for the link in the verification email. Redirects back to
    /// the UI with a status banner rather than returning JSON, because a browser
    /// lands here directly.
    /// </summary>
    public async Task VerifyEmail(HttpContext ctx)
    {
        var token = ctx.Request.Query["vtoken"].ToString();
        if (string.IsNullOrEmpty(token))
        {
            ctx.Response.Redirect("/?verify=missing");
            return;
        }
        try
        {
            // The verification endpoint shares its path with the availability
            // check, so the SDK exposes one operation; passing verificationtoken
            // performs the verification.
            await client.User.CheckEmailAvailabilityAsync(verificationtoken: Opt(token));
            ctx.Response.Redirect("/?verify=success");
        }
        catch (Exception e)
        {
            ctx.Response.Redirect("/?verify=error&message=" + Uri.EscapeDataString(e.Message));
        }
    }

    // -------------------------------------------------------------- password --

    /// <summary>Sends a password-reset email containing a reset token.</summary>
    public async Task ForgotPassword(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var email = Demo.Get(input, "email");
        if (string.IsNullOrEmpty(email))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {email}" });
            return;
        }
        var body = new ForgotPasswordRequest { Email = Opt(email) };
        await Demo.CallAsync(ctx, async () =>
            await client.Password.ForgotPasswordAsync(
                resetpasswordurl: Opt(Demo.ResetUrl),
                forgotPasswordRequest: new Option<ForgotPasswordRequest>(body)));
    }

    /// <summary>Completes a reset using the token from the email.</summary>
    public async Task ResetPassword(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var token = Demo.Get(input, "resetToken");
        var password = Demo.Get(input, "password");
        if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(password))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {resetToken, password}" });
            return;
        }
        var branch = new ResetPasswordOneOf(token, password);
        await Demo.CallAsync(ctx, async () =>
            await client.Password.ResetPasswordByResetTokenAsync(new ResetPassword(branch)));
    }

    /// <summary>Changes the signed-in user's password.</summary>
    public async Task ChangePassword(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var oldPassword = Demo.Get(input, "oldPassword");
        var newPassword = Demo.Get(input, "newPassword");
        if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {oldPassword, newPassword}" });
            return;
        }
        var body = new ChangePassword(oldPassword, newPassword);
        await Demo.CallAsync(ctx, async () =>
            await client.Password.ChangePasswordAsync(
                body, accessToken: Opt(Demo.AccessToken(ctx, sessions))));
    }

    // --------------------------------------------------------------- profile --

    /// <summary>Returns the signed-in user's profile.</summary>
    public Task GetProfile(HttpContext ctx) =>
        Demo.CallAsync(ctx, async () =>
            await client.User.GetAccountDetailsAsync(
                accessToken: Opt(Demo.AccessToken(ctx, sessions))));

    /// <summary>Updates editable fields on the signed-in user's profile.</summary>
    public async Task UpdateProfile(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var body = new UpdateAccountByAccessTokenRequest
        {
            FirstName = Opt(Demo.Get(input, "firstName")),
            LastName = Opt(Demo.Get(input, "lastName")),
            About = Opt(Demo.Get(input, "about")),
        };
        await Demo.CallAsync(ctx, async () =>
            await client.User.UpdateAccountByAccessTokenAsync(
                body, accessToken: Opt(Demo.AccessToken(ctx, sessions))));
    }

    // --------------------------------------------------------------- email   --

    /// <summary>Adds a secondary email to the signed-in user's account.</summary>
    public async Task AddEmail(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var email = Demo.Get(input, "email");
        if (string.IsNullOrEmpty(email))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {email, type}" });
            return;
        }
        var type = Demo.Get(input, "type");
        var body = new AddEmailModel(email, Opt(string.IsNullOrEmpty(type) ? "Secondary" : type));

        await Demo.CallAsync(ctx, async () =>
            await client.User.AddEmailAsync(
                body,
                accessToken: Opt(Demo.AccessToken(ctx, sessions)),
                verificationurl: Opt(Demo.VerificationUrl)));
    }

    /// <summary>Removes an email address from the signed-in user's account.</summary>
    public async Task DeleteEmail(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var email = Demo.Get(input, "email");
        if (string.IsNullOrEmpty(email))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {email}" });
            return;
        }
        var body = new DeleteemailbyaccesstokenRequest(email, Opt(Demo.AccessToken(ctx, sessions)));
        await Demo.CallAsync(ctx, async () =>
            await client.User.DeleteemailbyaccesstokenAsync(body));
    }

    /// <summary>
    /// Deletes the signed-in user's own account.
    ///
    /// The underlying operation is ADMIN-scoped: it authenticates with the API
    /// secret and will delete any account in the tenant by email address.
    /// Exposing that straight through would let anyone with a demo session
    /// delete anyone else, so this handler reads the signed-in profile first
    /// and refuses unless the address matches one the session actually owns.
    /// That guard is demo policy, not an SDK limitation — mirrors Node's
    /// handler exactly.
    /// </summary>
    public async Task DeleteAccount(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var email = Demo.Get(input, "email");
        if (string.IsNullOrEmpty(email))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {email}" });
            return;
        }
        try
        {
            var accessToken = Demo.AccessToken(ctx, sessions);
            var profileResult = await client.User.GetAccountDetailsAsync(accessToken: Opt(accessToken));
            if (!profileResult.IsSuccessStatusCode)
            {
                await Demo.WriteErrorAsync(ctx,
                    LoginRadiusException.From((int)profileResult.StatusCode, profileResult.RawContent));
                return;
            }
            using var profileDoc = JsonDocument.Parse(profileResult.RawContent);
            var owned = new List<string>();
            if (profileDoc.RootElement.TryGetProperty("Email", out var emailsEl) &&
                emailsEl.ValueKind == JsonValueKind.Array)
            {
                foreach (var e in emailsEl.EnumerateArray())
                {
                    if (e.TryGetProperty("Value", out var valEl) && valEl.ValueKind == JsonValueKind.String)
                    {
                        var val = valEl.GetString();
                        if (!string.IsNullOrEmpty(val)) owned.Add(val.Trim().ToLowerInvariant());
                    }
                }
            }
            if (!owned.Contains(email.Trim().ToLowerInvariant()))
            {
                await Demo.WriteJsonAsync(ctx, 403, new
                {
                    error = "refusing to delete an account you are not signed in as",
                    hint = "the demo only deletes the signed-in account; the underlying API would delete any address",
                });
                return;
            }

            var result = await client.Accounts.DeleteAccountByEmailAsync(email: Opt(email));
            if (!result.IsSuccessStatusCode)
            {
                await Demo.WriteErrorAsync(ctx, LoginRadiusException.From((int)result.StatusCode, result.RawContent));
                return;
            }
            sessions.Delete(Demo.SessionId(ctx));
            Demo.ClearSessionCookie(ctx);
            Demo.ClearMfaCookie(ctx);
            await Demo.WriteJsonAsync(ctx, 200, new { deleted = true });
        }
        catch (Exception e)
        {
            await Demo.WriteErrorAsync(ctx, e);
        }
    }

    // --------------------------------------------------------------- phone   --

    /// <summary>Updates the phone number on the signed-in user's account.</summary>
    public async Task UpdatePhone(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var phone = Demo.Get(input, "phone");
        if (string.IsNullOrEmpty(phone))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {phone}" });
            return;
        }
        await Demo.CallAsync(ctx, async () =>
            await client.User.ChangePhoneNumberAsync(
                accessToken: Opt(Demo.AccessToken(ctx, sessions)),
                phoneIdModel: new Option<PhoneIdModel>(new PhoneIdModel(phone))));
    }

    // ------------------------------------------------------------- password  --

    /// <summary>
    /// Resets a password using a reset token, or an OTP paired with either an
    /// email or a username — the three branches of the "Reset Password with
    /// token and OTP" operation.
    /// </summary>
    public async Task ResetPasswordWithToken(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var password = Demo.Get(input, "password");
        var resetToken = Demo.Get(input, "resetToken");
        var otp = Demo.Get(input, "otp");
        var email = Demo.Get(input, "email");
        var username = Demo.Get(input, "username");

        if (string.IsNullOrEmpty(password))
        {
            await Demo.WriteJsonAsync(ctx, 400, new
            {
                error = "expected JSON {password, resetToken} or {password, otp, email} or {password, otp, username}",
            });
            return;
        }

        ResetPassword body;
        if (!string.IsNullOrEmpty(resetToken))
        {
            body = new ResetPassword(new ResetPasswordOneOf(resetToken, password));
        }
        else if (!string.IsNullOrEmpty(otp) && !string.IsNullOrEmpty(email))
        {
            body = new ResetPassword(new ResetPasswordOneOf1(otp, email, password));
        }
        else if (!string.IsNullOrEmpty(otp) && !string.IsNullOrEmpty(username))
        {
            body = new ResetPassword(new ResetPasswordOneOf2(otp, username, password));
        }
        else
        {
            await Demo.WriteJsonAsync(ctx, 400, new
            {
                error = "expected JSON {password, resetToken} or {password, otp, email} or {password, otp, username}",
            });
            return;
        }

        await Demo.CallAsync(ctx, async () => await client.Password.ResetPasswordAsync(body));
    }

    /// <summary>
    /// Sends a password-reset OTP by SMS to the phone number on the account —
    /// the phone-based counterpart to <see cref="ForgotPassword"/>'s email link.
    /// </summary>
    public async Task RequestResetOtp(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var phone = Demo.Get(input, "phone");
        if (string.IsNullOrEmpty(phone))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {phone}" });
            return;
        }
        await Demo.CallAsync(ctx, async () =>
            await client.Password.RequestOTPForPasswordResetAsync(new ForgotPasswordPhoneModel(phone)));
    }

    /// <summary>Completes a password reset using the OTP delivered by SMS.</summary>
    public async Task ResetPasswordWithOtp(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var phone = Demo.Get(input, "phone");
        var otp = Demo.Get(input, "otp");
        var password = Demo.Get(input, "password");
        if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(otp) || string.IsNullOrEmpty(password))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {phone, otp, password}" });
            return;
        }
        await Demo.CallAsync(ctx, async () =>
            await client.Password.ResetPasswordWithOTPAsync(new ResetPasswordWithOTP(password, otp, phone)));
    }

    // --------------------------------------------------------- custom objects --

    /// <summary>Creates a new custom object entry for the signed-in user.</summary>
    /// <summary>
    /// Resolves the custom-object schema name. An explicit value from the
    /// caller (this demo's UI always sends one) wins; the manifest's
    /// generated routes declare this via configQuery instead — no client
    /// value at all — so LR_CUSTOM_OBJECT_NAME is the fallback for that
    /// caller shape.
    /// </summary>
    private static string? ResolveObjectName(HttpContext ctx, Dictionary<string, JsonElement> body)
    {
        var fromBody = Demo.Get(body, "objectname");
        if (!string.IsNullOrEmpty(fromBody)) return fromBody;
        var fromQuery = ctx.Request.Query["objectname"].ToString();
        if (!string.IsNullOrEmpty(fromQuery)) return fromQuery;
        return Environment.GetEnvironmentVariable("LR_CUSTOM_OBJECT_NAME");
    }

    /// <summary>
    /// Resolves the record id an update/delete targets. The manifest's
    /// generated routes carry it as a URL path segment (PUT/DELETE
    /// /api/customobject/{objectRecordId}, matched by ASP.NET's own routing
    /// into RouteValues); this demo's UI and the old hand-written routes send
    /// it as a body field instead.
    /// </summary>
    private static string? ResolveRecordId(HttpContext ctx, Dictionary<string, JsonElement> body)
    {
        if (ctx.Request.RouteValues.TryGetValue("objectRecordId", out var fromRoute)
            && fromRoute is string s && !string.IsNullOrEmpty(s))
        {
            return s;
        }
        return Demo.Get(body, "objectrecordid");
    }

    public async Task CreateCustomObject(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var objectname = ResolveObjectName(ctx, input);
        if (string.IsNullOrEmpty(objectname))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {objectname, ...fields}, or configure LR_CUSTOM_OBJECT_NAME" });
            return;
        }
        var data = ToRequestBody(input, "objectname");
        await Demo.CallAsync(ctx, async () =>
            await client.CustomObject.CreateCustomObjectByTokenAsync(
                data, objectname: Opt(objectname), accessToken: Opt(Demo.AccessToken(ctx, sessions))));
    }

    /// <summary>Lists all custom object records of the given type for the signed-in user.</summary>
    public async Task ListCustomObjects(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var objectname = ResolveObjectName(ctx, input);
        if (string.IsNullOrEmpty(objectname))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {objectname}, or configure LR_CUSTOM_OBJECT_NAME" });
            return;
        }
        await Demo.CallAsync(ctx, async () =>
            await client.CustomObject.GetCustomObjectByTokenAsync(
                objectname: Opt(objectname), accessToken: Opt(Demo.AccessToken(ctx, sessions))));
    }

    /// <summary>Partially updates a custom object record identified by its record ID.</summary>
    public async Task UpdateCustomObject(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var objectname = ResolveObjectName(ctx, input);
        var recordId = ResolveRecordId(ctx, input);
        if (string.IsNullOrEmpty(objectname) || string.IsNullOrEmpty(recordId))
        {
            await Demo.WriteJsonAsync(
                ctx, 400, new { error = "expected JSON {objectname, objectrecordid, ...fields} "
                    + "(or a record id in the URL, and LR_CUSTOM_OBJECT_NAME configured)" });
            return;
        }
        if (!Guid.TryParse(recordId, out var guid))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "objectrecordid must be a valid UUID" });
            return;
        }
        var data = ToRequestBody(input, "objectname", "objectrecordid");
        await Demo.CallAsync(ctx, async () =>
            await client.CustomObject.UpdateCustomObjectByTokenAndRecordIdAsync(
                guid, "PartialReplace", data,
                objectname: Opt(objectname), accessToken: Opt(Demo.AccessToken(ctx, sessions))));
    }

    /// <summary>Deletes a custom object record identified by its record ID.</summary>
    public async Task DeleteCustomObject(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var objectname = ResolveObjectName(ctx, input);
        var recordId = ResolveRecordId(ctx, input);
        if (string.IsNullOrEmpty(objectname) || string.IsNullOrEmpty(recordId))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {objectname, objectrecordid} "
                + "(or a record id in the URL, and LR_CUSTOM_OBJECT_NAME configured)" });
            return;
        }
        if (!Guid.TryParse(recordId, out var guid))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "objectrecordid must be a valid UUID" });
            return;
        }
        await Demo.CallAsync(ctx, async () =>
            await client.CustomObject.DeleteCustomObjectByTokenAndRecordIdAsync(
                guid, objectname: Opt(objectname), accessToken: Opt(Demo.AccessToken(ctx, sessions))));
    }

    /// <summary>
    /// Builds a custom-object request body from the raw JSON input, dropping the
    /// routing keys. <see cref="JsonElement"/> values are passed through
    /// unchanged — <see cref="JsonSerializer"/> round-trips them faithfully, so
    /// no manual conversion to CLR primitives is needed.
    /// </summary>
    private static Dictionary<string, object> ToRequestBody(
        Dictionary<string, JsonElement> input, params string[] omit)
    {
        var data = new Dictionary<string, object>();
        foreach (var (key, value) in input)
        {
            if (Array.IndexOf(omit, key) < 0)
            {
                data[key] = value;
            }
        }
        return data;
    }

    // --------------------------------------------------------------- token   --

    /// <summary>Exchanges a refresh token for a new access token.</summary>
    public async Task RefreshToken(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var refreshToken = Demo.Get(input, "refreshToken");
        if (string.IsNullOrEmpty(refreshToken))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {refreshToken}" });
            return;
        }
        await Demo.CallAsync(ctx, async () => await client.AccountSession.RefreshAccessTokenAsync(refreshToken));
    }

    /// <summary>
    /// Validates an access token. Uses the token from the request body if
    /// provided; falls back to the current session's token.
    /// </summary>
    public async Task ValidateToken(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var token = Demo.Get(input, "accessToken");
        if (string.IsNullOrEmpty(token))
        {
            token = Demo.AccessToken(ctx, sessions);
        }
        if (string.IsNullOrEmpty(token))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {accessToken} or an active session" });
            return;
        }
        await Demo.CallAsync(ctx, async () => await client.AccountSession.ValidateAccessTokenAsync(token));
    }

    /// <summary>Returns active session details for the currently signed-in user.</summary>
    public Task ActiveSession(HttpContext ctx) =>
        Demo.CallAsync(ctx, async () =>
            await client.AccountSession.GetActiveSessionAsync(token: Opt(Demo.AccessToken(ctx, sessions))));

    /// <summary>
    /// Invalidates the access token on the LoginRadius API, then clears the
    /// local session. Unlike logout (which only clears the local session), this
    /// revokes the token server-side so it cannot be reused.
    /// </summary>
    public async Task InvalidateToken(HttpContext ctx)
    {
        var accessToken = Demo.AccessToken(ctx, sessions);
        try
        {
            var result = await client.AccountSession.NativeInvalidateAccessTokenAsync(accessToken: Opt(accessToken));
            if (!result.IsSuccessStatusCode)
            {
                await Demo.WriteErrorAsync(ctx, LoginRadiusException.From((int)result.StatusCode, result.RawContent));
                return;
            }
            sessions.Delete(Demo.SessionId(ctx));
            Demo.ClearSessionCookie(ctx);
            await Demo.WriteJsonAsync(ctx, 200, new { ok = true });
        }
        catch (Exception e)
        {
            await Demo.WriteErrorAsync(ctx, e);
        }
    }

    // --------------------------------------------------------------- passkey --

    /// <summary>Begins the Passkey login flow — returns the WebAuthn assertion challenge.</summary>
    public async Task BeginPasskeyLogin(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var identifier = Demo.Get(input, "identifier");
        if (string.IsNullOrEmpty(identifier))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {identifier}" });
            return;
        }
        await Demo.CallAsync(ctx, async () => await client.Login.BeginPasskeyLoginAsync(identifier));
    }

    /// <summary>Begins the Passkey registration flow — returns the WebAuthn creation challenge.</summary>
    public async Task BeginPasskeyRegistration(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var identifier = Demo.Get(input, "identifier");
        if (string.IsNullOrEmpty(identifier))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {identifier}" });
            return;
        }
        await Demo.CallAsync(ctx, async () => await client.Registration.BeginPasskeyRegistrationAsync(identifier));
    }

    /// <summary>
    /// Completes the Passkey registration flow with the attestation response
    /// from the browser's <c>navigator.credentials.create()</c> call. The raw
    /// JSON body must match the <see cref="PasskeyRegisterFinish"/> schema.
    /// </summary>
    public async Task FinishPasskeyRegistration(HttpContext ctx)
    {
        PasskeyRegisterFinish? body;
        try
        {
            body = await JsonSerializer.DeserializeAsync<PasskeyRegisterFinish>(ctx.Request.Body, ModelJsonOptions);
        }
        catch (JsonException)
        {
            body = null;
        }
        if (body is null)
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "request body must match the PasskeyRegisterFinish schema" });
            return;
        }
        await Demo.CallAsync(ctx, async () =>
            await client.Registration.FinishPasskeyRegistrationAsync(body, verificationurl: Opt(Demo.VerificationUrl)));
    }

    /// <summary>
    /// Completes the Passkey login flow with the browser's assertion response
    /// from <c>navigator.credentials.get()</c>. The raw JSON body must match the
    /// <see cref="PasskeyLoginFinish"/> schema. Mints a session on success, so it
    /// cannot go through <see cref="Demo.CallAsync{T}"/> like the other passkey
    /// steps.
    /// </summary>
    public async Task FinishPasskeyLogin(HttpContext ctx)
    {
        PasskeyLoginFinish? body;
        try
        {
            body = await JsonSerializer.DeserializeAsync<PasskeyLoginFinish>(ctx.Request.Body, ModelJsonOptions);
        }
        catch (Exception e) when (e is JsonException or NotSupportedException or ArgumentException)
        {
            // The generated model's converter can throw NotSupportedException/
            // ArgumentException for a structurally-valid-JSON-but-schema-invalid
            // body (e.g. a credential missing required nested fields), not just
            // JsonException — catch broadly so a malformed WebAuthn payload
            // reports 400 instead of an unhandled 500.
            body = null;
        }
        if (body is null)
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "request body must match the PasskeyLoginFinish schema" });
            return;
        }
        try
        {
            var response = await client.Login.FinishPasskeyLoginAsync(body);
            if (!response.IsSuccessStatusCode)
            {
                await Demo.WriteErrorAsync(ctx,
                    LoginRadiusException.From((int)response.StatusCode, response.RawContent));
                return;
            }
            using var doc = JsonDocument.Parse(response.RawContent);
            var root = doc.RootElement;
            string? accessToken = root.TryGetProperty("access_token", out var tokenEl) ? tokenEl.GetString() : null;
            if (string.IsNullOrEmpty(accessToken))
            {
                await Demo.WriteJsonAsync(ctx, 502, new { error = "authentication succeeded but no access_token returned" });
                return;
            }
            Demo.SetSessionCookie(ctx, sessions.Create(accessToken));
            JsonElement? profile = root.TryGetProperty("Profile", out var profileEl) ? profileEl.Clone() : null;
            await Demo.WriteJsonAsync(ctx, 200, new { ok = true, profile });
        }
        catch (Exception e)
        {
            await Demo.WriteErrorAsync(ctx, e);
        }
    }

    // ------------------------------------------------------------------- mfa --

    /// <summary>Returns which second factors are configured on the signed-in account.</summary>
    public async Task MfaSettings(HttpContext ctx)
    {
        var duoRedirectUri = ctx.Request.Query.TryGetValue("duoRedirectUri", out var v) ? v.ToString() : null;
        await Demo.CallAsync(ctx, async () =>
            await client.Security.GetMFASettingsAsync(
                // Only sent when supplied. Duo returns the user here after its
                // own challenge; an empty string would put duoredirecturi= on
                // the wire for every tenant, including those with no Duo
                // configured.
                duoredirecturi: OptIfSet(duoRedirectUri),
                accessToken: Opt(Demo.AccessToken(ctx, sessions))));
    }

    /// <summary>Confirms a TOTP code and enrols the authenticator on the signed-in account.</summary>
    public async Task MfaEnrolTotp(HttpContext ctx)
    {
        var input = await Demo.ReadJsonAsync(ctx);
        var totp = Demo.Get(input, "totp");
        if (string.IsNullOrEmpty(totp))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {totp}" });
            return;
        }
        await Demo.CallAsync(ctx, async () =>
            await client.Security.Verify2faTOTPAuthAsync(
                new AuthenticatorCodeRequest(googleauthenticatorcode: OptIfSet(totp)),
                accessToken: Opt(Demo.AccessToken(ctx, sessions))));
    }

    /// <summary>Issues a fresh set of single-use MFA backup codes for the signed-in account.</summary>
    public async Task MfaBackupCodes(HttpContext ctx) =>
        await Demo.CallAsync(ctx, async () =>
            await client.Security.MfaGenerateBackupCodesAsync(accessToken: Opt(Demo.AccessToken(ctx, sessions))));

    /// <summary>
    /// Sends an email OTP for an in-progress MFA login challenge. Authenticated
    /// by the MFA cookie from the challenge login, never by a session.
    /// </summary>
    public async Task MfaSendEmailOtp(HttpContext ctx)
    {
        var mfaToken = Demo.MfaToken(ctx);
        if (string.IsNullOrEmpty(mfaToken))
        {
            await Demo.WriteJsonAsync(ctx, 401, new { error = "mfa challenge required" });
            return;
        }
        var input = await Demo.ReadJsonAsync(ctx);
        var email = Demo.Get(input, "email");
        if (string.IsNullOrEmpty(email))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {email}" });
            return;
        }
        await Demo.CallAsync(ctx, async () =>
            await client.Security.ResendEmailOTPMFATokenAsync(mfaToken, new EmailModel(email)));
    }

    /// <summary>
    /// Completes an in-progress MFA login challenge with an email OTP. Mints a
    /// session on success, so it cannot go through
    /// <see cref="Demo.CallAsync{T}"/> like the other MFA steps.
    /// </summary>
    public async Task MfaVerifyEmailOtp(HttpContext ctx)
    {
        var mfaToken = Demo.MfaToken(ctx);
        if (string.IsNullOrEmpty(mfaToken))
        {
            await Demo.WriteJsonAsync(ctx, 401, new { error = "mfa challenge required" });
            return;
        }
        var input = await Demo.ReadJsonAsync(ctx);
        var email = Demo.Get(input, "email");
        var otp = Demo.Get(input, "otp");
        if (string.IsNullOrEmpty(email))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {email, otp}" });
            return;
        }
        if (string.IsNullOrEmpty(otp))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {email, otp}" });
            return;
        }
        try
        {
            var response = await client.Security.ValidateMfaOTPByEmailAsync(
                mfaToken, new ReAuthModelByEmailOtp(email, otp));
            Demo.ClearMfaCookie(ctx);
            if (!response.IsSuccessStatusCode)
            {
                await Demo.WriteErrorAsync(ctx,
                    LoginRadiusException.From((int)response.StatusCode, response.RawContent));
                return;
            }
            using var doc = JsonDocument.Parse(response.RawContent);
            var root = doc.RootElement;
            string? accessToken = root.TryGetProperty("access_token", out var tokenEl) ? tokenEl.GetString() : null;
            if (string.IsNullOrEmpty(accessToken))
            {
                await Demo.WriteJsonAsync(ctx, 502, new { error = "authentication succeeded but no access_token returned" });
                return;
            }
            Demo.SetSessionCookie(ctx, sessions.Create(accessToken));
            JsonElement? profile = root.TryGetProperty("Profile", out var profileEl) ? profileEl.Clone() : null;
            await Demo.WriteJsonAsync(ctx, 200, new { ok = true, profile });
        }
        catch (Exception e)
        {
            Demo.ClearMfaCookie(ctx);
            await Demo.WriteErrorAsync(ctx, e);
        }
    }

    /// <summary>
    /// Completes an in-progress MFA login challenge with a TOTP code. Mints a
    /// session on success, so it cannot go through
    /// <see cref="Demo.CallAsync{T}"/> like the other MFA steps.
    /// </summary>
    public async Task MfaVerifyTotp(HttpContext ctx)
    {
        var mfaToken = Demo.MfaToken(ctx);
        if (string.IsNullOrEmpty(mfaToken))
        {
            await Demo.WriteJsonAsync(ctx, 401, new { error = "mfa challenge required" });
            return;
        }
        var input = await Demo.ReadJsonAsync(ctx);
        var totp = Demo.Get(input, "totp");
        if (string.IsNullOrEmpty(totp))
        {
            await Demo.WriteJsonAsync(ctx, 400, new { error = "expected JSON {totp}" });
            return;
        }
        try
        {
            var response = await client.Security.VerifyTotpByMfaTokenAsync(
                mfaToken, new AuthenticatorCodeRequest(googleauthenticatorcode: OptIfSet(totp)));
            Demo.ClearMfaCookie(ctx);
            if (!response.IsSuccessStatusCode)
            {
                await Demo.WriteErrorAsync(ctx,
                    LoginRadiusException.From((int)response.StatusCode, response.RawContent));
                return;
            }
            using var doc = JsonDocument.Parse(response.RawContent);
            var root = doc.RootElement;
            string? accessToken = root.TryGetProperty("access_token", out var tokenEl) ? tokenEl.GetString() : null;
            if (string.IsNullOrEmpty(accessToken))
            {
                await Demo.WriteJsonAsync(ctx, 502, new { error = "authentication succeeded but no access_token returned" });
                return;
            }
            Demo.SetSessionCookie(ctx, sessions.Create(accessToken));
            JsonElement? profile = root.TryGetProperty("Profile", out var profileEl) ? profileEl.Clone() : null;
            await Demo.WriteJsonAsync(ctx, 200, new { ok = true, profile });
        }
        catch (Exception e)
        {
            Demo.ClearMfaCookie(ctx);
            await Demo.WriteErrorAsync(ctx, e);
        }
    }
}
