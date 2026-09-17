// Hand-written — unlike Routes.generated.cs, this is NOT part of the shared
// manifest contract in manifest/sdk.yaml `demo.routes`. It extends the .NET
// demo with endpoints the other SDKs' demos also expose ad hoc, on top of the
// 9 routes every language's demo shares.

namespace LoginRadius.Sdk.Demo;

/// <summary>Endpoints added on top of the shared <see cref="DemoRoutes"/> contract.</summary>
public static class ExtendedDemoRoutes
{
    /// <summary>Returns the extended endpoint list. Registered by Program alongside DemoRoutes.</summary>
    public static IReadOnlyList<DemoRoute> All() => new[]
    {
        // Removes an email address from the signed-in user's account.
        new DemoRoute("POST", "/api/email/delete", true, (ctx, h) => h.DeleteEmail(ctx)),
        // Deletes the signed-in user's account and clears the local session.
        new DemoRoute("POST", "/api/account/delete", true, (ctx, h) => h.DeleteAccount(ctx)),
        // Updates the phone number on the signed-in user's account.
        new DemoRoute("POST", "/api/phone/update", true, (ctx, h) => h.UpdatePhone(ctx)),
        // Resets a password using a reset token, or an OTP paired with an email or username.
        new DemoRoute("POST", "/api/password/reset-otp", false, (ctx, h) => h.ResetPasswordWithToken(ctx)),
        // Creates a new custom object entry for the signed-in user.
        new DemoRoute("POST", "/api/customobject/create", true, (ctx, h) => h.CreateCustomObject(ctx)),
        // Lists all custom object records of a given type for the signed-in user.
        new DemoRoute("POST", "/api/customobject/list", true, (ctx, h) => h.ListCustomObjects(ctx)),
        // Partially updates a custom object record identified by its record ID.
        new DemoRoute("POST", "/api/customobject/update", true, (ctx, h) => h.UpdateCustomObject(ctx)),
        // Deletes a custom object record identified by its record ID.
        new DemoRoute("POST", "/api/customobject/delete", true, (ctx, h) => h.DeleteCustomObject(ctx)),
        // Validates an access token from the request body, or the current session's.
        new DemoRoute("POST", "/api/token/validate", false, (ctx, h) => h.ValidateToken(ctx)),
        // Returns active session details for the currently signed-in user.
        new DemoRoute("GET", "/api/session/active", true, (ctx, h) => h.ActiveSession(ctx)),
        // Invalidates the access token upstream, then clears the local session.
        new DemoRoute("POST", "/api/token/invalidate", true, (ctx, h) => h.InvalidateToken(ctx)),
        // Begins the Passkey login flow.
        new DemoRoute("POST", "/api/passkey/login/begin", false, (ctx, h) => h.BeginPasskeyLogin(ctx)),
        // Begins the Passkey registration flow.
        new DemoRoute("POST", "/api/passkey/register/begin", false, (ctx, h) => h.BeginPasskeyRegistration(ctx)),
    };
}
