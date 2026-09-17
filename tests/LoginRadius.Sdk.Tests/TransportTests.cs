using System.Net;
using System.Text;
using Xunit;

namespace LoginRadius.Sdk.Tests;

/// <summary>
/// CROSS-LANGUAGE PARITY.
///
/// <para>Every case here mirrors one in the Go suite
/// (<c>loginradius_test.go</c>) and the Node suite
/// (<c>__tests__/request-options.test.ts</c>), asserting the same concrete
/// values from <c>manifest/sdk.yaml</c>. The manifest is the contract; these
/// are what stop one language drifting away from it quietly.</para>
///
/// <para>A manifest change is <em>supposed</em> to break these. Update every
/// language's suite in the same change.</para>
/// </summary>
public class TransportTests
{
    private const string LoginPath = "https://api.loginradius.com/identity/v2/auth/login";
    private const string ManagePath = "https://api.loginradius.com/identity/v2/manage/account/uid";

    /// <summary>
    /// Drives the credential handler directly, the way Go's <c>roundTrip</c>
    /// helper drives its transport, and hands back what reached the wire.
    /// </summary>
    private static RecordingHandler Send(LoginRadiusConfig config, string url = LoginPath)
    {
        var recorder = new RecordingHandler();
        using var handler = new AuthHandler(config) { InnerHandler = recorder };
        using var invoker = new HttpMessageInvoker(handler);
        using var request = new HttpRequestMessage(HttpMethod.Get, url);

        invoker.SendAsync(request, CancellationToken.None).GetAwaiter().GetResult().Dispose();

        Assert.NotNull(recorder.Request);
        return recorder;
    }

    // ---- credentials -------------------------------------------------------

    [Fact]
    public void InjectsCredentialsAsHeadersAndQueryParameters()
    {
        var got = Send(new LoginRadiusConfig { ApiKey = "KEY", ApiSecret = "SECRET" });

        Assert.Equal("KEY", got.Header("X-LoginRadius-ApiKey"));
        Assert.Equal("SECRET", got.Header("X-LoginRadius-ApiSecret"));
        // The query form exists because some LoginRadius operations accept
        // nothing else; it must be sent alongside the header, not instead.
        Assert.Equal("KEY", got.Query("apikey"));
    }

    [Fact]
    public void OmitsUnsetCredentials()
    {
        var got = Send(new LoginRadiusConfig { ApiKey = "KEY" });

        Assert.Null(got.Header("X-LoginRadius-ApiSecret"));
        Assert.Null(got.Query("apisecret"));
    }

    [Fact]
    public void PerCallParametersWinOverClientWideOnes()
    {
        var recorder = new RecordingHandler();
        using var handler = new AuthHandler(new LoginRadiusConfig { ApiKey = "CLIENT_KEY" })
        {
            InnerHandler = recorder,
        };
        using var invoker = new HttpMessageInvoker(handler);
        using var request = new HttpRequestMessage(
            HttpMethod.Get, LoginPath + "?apikey=PER_CALL_KEY");

        invoker.SendAsync(request, CancellationToken.None).GetAwaiter().GetResult().Dispose();

        // An operation that already carries the credential must not have it
        // appended a second time — two values would be sent and the API would
        // read whichever came first.
        Assert.Equal("PER_CALL_KEY", recorder.Query("apikey"));
        Assert.Single(
            System.Web.HttpUtility.ParseQueryString(recorder.Request!.RequestUri!.Query)
                .GetValues("apikey")!);
    }

    // ---- cross-cutting request options -------------------------------------

    [Fact]
    public void RequestOptionsAppliedToEveryRequest()
    {
        var got = Send(new LoginRadiusConfig
        {
            ApiKey = "KEY",
            OriginIp = "203.0.113.7",
            ServerRegion = "eu",
            Fields = "Email,Uid",
            PreventWebhook = true,
        });

        Assert.Equal("203.0.113.7", got.Header("X-Origin-IP"));
        Assert.Equal("true", got.Header("X-PreventWebhook"));
        Assert.Equal("eu", got.Query("region"));
        Assert.Equal("Email,Uid", got.Query("fields"));
    }

    [Fact]
    public void RequestOptionsOmittedWhenUnset()
    {
        var got = Send(new LoginRadiusConfig { ApiKey = "KEY" });

        Assert.Null(got.Header("X-Origin-IP"));
        Assert.Null(got.Header("X-PreventWebhook"));
        Assert.Null(got.Query("region"));
        Assert.Null(got.Query("fields"));
    }

    [Fact]
    public void DefaultHeadersNeverMaskACredential()
    {
        // Default headers are applied first so the SDK's own headers overwrite
        // them. Letting a caller override X-LoginRadius-ApiKey here would
        // silently send the wrong credential.
        var got = Send(new LoginRadiusConfig
        {
            ApiKey = "REAL_KEY",
            DefaultHeaders = new Dictionary<string, string>
            {
                ["X-Tenant-Trace"] = "abc123",
                ["X-LoginRadius-ApiKey"] = "HIJACKED",
                ["User-Agent"] = "HIJACKED",
            },
        });

        Assert.Equal("abc123", got.Header("X-Tenant-Trace"));
        Assert.Equal("REAL_KEY", got.Header("X-LoginRadius-ApiKey"));
        Assert.NotEqual("HIJACKED", got.Header("User-Agent"));
    }

    // ---- request signing ---------------------------------------------------

    [Fact]
    public void SigningAppliedOnlyToManagementPaths()
    {
        static LoginRadiusConfig Signing() => new()
        {
            ApiKey = "KEY",
            ApiSecret = "SECRET",
            ApiRequestSigning = true,
        };

        var signed = Send(Signing(), ManagePath);
        Assert.NotNull(signed.Header(Sdk.Signing.DigestHeader));
        Assert.NotNull(signed.Header(Sdk.Signing.ExpiresHeader));

        var unsigned = Send(Signing(), LoginPath);
        Assert.Null(unsigned.Header(Sdk.Signing.DigestHeader));

        // The access-token exchange lives under /manage/ but is explicitly
        // excluded: it is the call that obtains the credential to sign with.
        var excluded = Send(
            Signing(), "https://api.loginradius.com/identity/v2/manage/account/access_token");
        Assert.Null(excluded.Header(Sdk.Signing.DigestHeader));
    }

    [Fact]
    public void SigningStripsTheSecretFromTheSignedUrl()
    {
        var got = Send(
            new LoginRadiusConfig
            {
                ApiKey = "KEY",
                ApiSecret = "SECRET",
                ApiRequestSigning = true,
            },
            ManagePath);

        // apisecret is removed before the URL is signed AND before it is sent —
        // a signature computed over a URL carrying the secret would also mean
        // the secret went out on the wire.
        Assert.Null(got.Query("apisecret"));
        Assert.NotNull(got.Header(Sdk.Signing.DigestHeader));
    }

    [Fact]
    public void SigningRequiresBothOptInAndSecret()
    {
        var noOptIn = Send(
            new LoginRadiusConfig { ApiKey = "KEY", ApiSecret = "SECRET" }, ManagePath);
        Assert.Null(noOptIn.Header(Sdk.Signing.DigestHeader));

        var noSecret = Send(
            new LoginRadiusConfig { ApiKey = "KEY", ApiRequestSigning = true }, ManagePath);
        Assert.Null(noSecret.Header(Sdk.Signing.DigestHeader));
    }

    // ---- debug logging -----------------------------------------------------

    [Fact]
    public void DebugRedactsCredentialValues()
    {
        var log = new StringBuilder();
        Send(new LoginRadiusConfig
        {
            ApiKey = "SUPER_SECRET_KEY",
            ApiSecret = "SUPER_SECRET_VALUE",
            BearerToken = "SUPER_SECRET_TOKEN",
            Debug = line => log.AppendLine(line),
        });

        var output = log.ToString();
        Assert.NotEmpty(output);
        Assert.DoesNotContain("SUPER_SECRET_KEY", output, StringComparison.Ordinal);
        Assert.DoesNotContain("SUPER_SECRET_VALUE", output, StringComparison.Ordinal);
        Assert.DoesNotContain("SUPER_SECRET_TOKEN", output, StringComparison.Ordinal);
        Assert.Contains("x-loginradius-apikey", output.ToLowerInvariant(), StringComparison.Ordinal);
        Assert.Contains("[REDACTED]", output, StringComparison.Ordinal);
    }
}
