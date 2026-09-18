using LoginRadius.Sdk;
using Xunit;

namespace LoginRadius.Sdk.Tests;

/// <summary>
/// CROSS-LANGUAGE PARITY.
///
/// <para>The golden values below are asserted identically by the Go, Node, and
/// Java SDKs. Every LoginRadius SDK must emit a byte-identical SOTT and request
/// signature, because the API validates the payload exactly — a drifted IV,
/// iteration count, salt, or timestamp format yields a token that is silently
/// rejected.</para>
///
/// <para>The signing values came from the reference implementation in
/// admin-console-backend, not from this SDK's own output, so these prove the
/// port matches the known-working algorithm rather than merely matching itself.</para>
///
/// <para>If this fails, fix the implementation, not the expectation. The shared
/// parameters live in the SDK generator's shared configuration.</para>
/// </summary>
public class CryptoParityTests
{
    private const string ApiKey = "test-api-key";
    private const string ApiSecret = "test-api-secret";
    private const string Uri = "https://api.loginradius.com/identity/v2/manage/account/uid?apikey=test-api-key";

    private static readonly DateTime Start = new(2026, 1, 2, 3, 4, 5, DateTimeKind.Utc);
    private static readonly DateTime End = new(2026, 1, 2, 3, 14, 5, DateTimeKind.Utc);

    [Fact]
    public void SottMatchesTheOtherSdks() =>
        Assert.Equal(
            "yvLBFPR3aRNl1YlisgPpEdphb73sUfne2Jem7hTKWU6RLlkcfjYOhe5B7kSHorQS"
                + "*1059092e1510bfbc5388d7438b943106",
            Sott.GenerateWithWindow(ApiKey, ApiSecret, Start, End));

    [Fact]
    public void SottRejectsMissingCredentials()
    {
        Assert.Throws<ArgumentException>(() => Sott.GenerateWithWindow("", ApiSecret, Start, End));
        Assert.Throws<ArgumentException>(() => Sott.GenerateWithWindow(ApiKey, "", Start, End));
    }

    [Fact]
    public void SigningMatchesTheReferenceImplementation()
    {
        var noBody = Signing.Sign(ApiSecret, Uri, null, Start);
        Assert.Equal("SHA-256=WhdnDwiFzLUkrhBOUQYzrec+ZllDrY6X0hdovov8bKY=", noBody.Digest);
        Assert.Equal("2026-01-02 03:24:05", noBody.Expires);

        var withBody = Signing.Sign(ApiSecret, Uri, "{\"Uid\":\"abc123\"}", Start);
        Assert.Equal("SHA-256=cVEPKKM+Dd1fzQePAPDKMKCn+2QollSbzWfVx8YxSzM=", withBody.Digest);
    }

    /// <summary>
    /// Guards the escaper. <c>Uri.EscapeDataString</c> is NOT
    /// encodeURIComponent: it escapes <c>!'()*</c>. Signing a URL containing an
    /// email address with the wrong escaper yields a digest the API rejects.
    /// </summary>
    [Fact]
    public void EncodeUriComponentMatchesJavaScript() =>
        Assert.Equal("a%20b!'()*~-_.%C3%A9%2F%3F%26%3D", Signing.EncodeUriComponent("a b!'()*~-_.é/?&="));

    [Theory]
    [InlineData("/identity/v2/manage/account/uid", true)]
    [InlineData("/v2/manage/roles", true)]
    [InlineData("/identity/v2/auth/login", false)]
    // The access-token exchange is explicitly excluded by the reference.
    [InlineData("/identity/v2/manage/account/access_token", false)]
    public void SigningScopeIsManagementPathsOnly(string path, bool expected) =>
        Assert.Equal(expected, Signing.ShouldSign(path));

    [Fact]
    public void ConfigRequiresACredential()
    {
        Assert.Throws<ArgumentException>(() => new LoginRadiusConfig().Validate());
        new LoginRadiusConfig { ApiKey = "k" }.Validate(); // does not throw
    }

    [Fact]
    public void BaseUrlPrecedence()
    {
        Assert.Equal("https://api.loginradius.com", new LoginRadiusConfig { ApiKey = "k" }.ResolveBaseUrl());
        Assert.Equal(
            "https://acme.hub.loginradius.com",
            new LoginRadiusConfig { ApiKey = "k", Domain = "acme" }.ResolveBaseUrl());
        Assert.Equal(
            "https://id.acme.com",
            new LoginRadiusConfig { ApiKey = "k", Domain = "acme", CustomDomain = "id.acme.com" }.ResolveBaseUrl());
        Assert.Equal(
            "https://staging.internal",
            new LoginRadiusConfig { ApiKey = "k", Domain = "acme", BaseURL = "https://staging.internal" }.ResolveBaseUrl());
    }
}
