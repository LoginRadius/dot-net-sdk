using Xunit;

namespace LoginRadius.Sdk.Tests;

/// <summary>
/// CROSS-LANGUAGE PARITY. Mirrors Go's <c>TestResolveBaseURLPrecedence</c>,
/// <c>TestNewClientWiresEveryService</c>, and
/// <c>TestOperationServersHonourClientConfiguration</c>.
/// </summary>
public class ClientTests
{
    // ---- base URL precedence ----------------------------------------------

    [Fact]
    public void ResolveBaseUrlPrecedence()
    {
        // Declared in manifest/sdk.yaml as an ordered list; the order is the
        // contract, so assert each level beats the ones below it.
        Assert.Equal(
            "https://staging.internal",
            new LoginRadiusConfig
            {
                BaseURL = "https://staging.internal",
                CustomDomain = "auth.acme.com",
                Domain = "acme",
            }.ResolveBaseUrl());

        Assert.Equal(
            "https://auth.acme.com",
            new LoginRadiusConfig { CustomDomain = "auth.acme.com", Domain = "acme" }
                .ResolveBaseUrl());

        Assert.Equal(
            "https://acme.hub.loginradius.com",
            new LoginRadiusConfig { Domain = "acme" }.ResolveBaseUrl());

        Assert.Equal(
            "https://api.loginradius.com", new LoginRadiusConfig().ResolveBaseUrl());
    }

    [Fact]
    public void ValidateRequiresACredential()
    {
        // A client with no credential at all would send unauthenticated
        // requests and fail per-call with a confusing 401.
        Assert.Throws<ArgumentException>(() => new LoginRadiusConfig().Validate());

        var ex = Record.Exception(() => new LoginRadiusConfig { ApiKey = "k" }.Validate());
        Assert.Null(ex);
    }

    [Fact]
    public void ConstructorRequiresCredentials()
    {
        Assert.Throws<ArgumentException>(() => new LoginRadiusClient(new LoginRadiusConfig()));
    }

    [Fact]
    public void WiresEveryService()
    {
        using var client = new LoginRadiusClient(new LoginRadiusConfig { ApiKey = "k" });

        // Every service property is derived from the generated client, so a
        // null here means a service the facade failed to wire.
        foreach (var property in typeof(LoginRadiusClient).GetProperties())
        {
            if (property.Name == nameof(LoginRadiusClient.Config))
            {
                continue;
            }

            Assert.NotNull(property.GetValue(client));
        }
    }

    // ---- operation servers -------------------------------------------------

    /// <summary>
    /// Issues a request against an operation the spec pins to
    /// <c>https://{domain}.hub.loginradius.com</c> and reports the host it
    /// actually addressed.
    /// </summary>
    private static string PinnedOperationHost(string? domain = null, string? baseUrl = null)
    {
        var recorder = new RecordingHandler();
        using var client = new LoginRadiusClient(new LoginRadiusConfig
        {
            ApiKey = "k",
            Domain = domain,
            BaseURL = baseUrl,
            HttpClient = () => recorder,
        });
        try
        {
            client.BigCommerceSSO
                .GetBigCommerceLoginUrlAsync("tok", "mystore")
                .GetAwaiter()
                .GetResult();
        }
        catch
        {
            // The canned response does not deserialise into the operation's
            // model, which is fine — the request has already been recorded.
        }

        Assert.NotNull(recorder.Request);
        return recorder.Request!.RequestUri!.Host;
    }

    [Fact]
    public void OperationServersHonourClientConfiguration()
    {
        // No server options: the spec's own placeholder stands, exactly as it
        // does in Go. Before the OperationServers hook existed this threw
        // UriFormatException, because `{domain}` is not a legal host.
        Assert.Equal("example.hub.loginradius.com", PinnedOperationHost());

        // Domain fills the {domain} template variable.
        Assert.Equal("acme.hub.loginradius.com", PinnedOperationHost(domain: "acme"));

        // An explicit base URL means "send everything here" and wins over the
        // pin — otherwise a caller pointing at a proxy or a staging host would
        // still have this operation go to production.
        Assert.Equal(
            "staging.internal",
            PinnedOperationHost(baseUrl: "https://staging.internal"));
    }

    [Fact]
    public void PinnedOperationKeepsItsOwnPath()
    {
        var recorder = new RecordingHandler();
        using var client = new LoginRadiusClient(new LoginRadiusConfig
        {
            ApiKey = "k",
            Domain = "acme",
            HttpClient = () => recorder,
        });

        try
        {
            client.BigCommerceSSO
                .GetBigCommerceLoginUrlAsync("tok", "mystore")
                .GetAwaiter()
                .GetResult();
        }
        catch
        {
            // See PinnedOperationHost.
        }

        // The generator set the path to the pinned SERVER's path and never
        // appended the operation's own, so every pinned operation addressed the
        // host root. Assert the operation path survives.
        Assert.NotEqual("/", recorder.Request!.RequestUri!.AbsolutePath);
        Assert.Contains(
            "bigcommerce",
            recorder.Request.RequestUri.AbsolutePath,
            StringComparison.OrdinalIgnoreCase);
    }
}
