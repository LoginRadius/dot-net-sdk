using LoginRadius.Sdk;

namespace LoginRadius.Sdk.Examples;

/// <summary>
/// The fix for a defect that made 42 operations unusable.
/// </summary>
/// <remarks>
/// <para>
/// The OpenAPI specification pins 42 operations to their own host — the
/// migration and cloud-api services, plus the tenant-hub and custom-domain
/// templates. The generator inlines each pin into the operation itself, so
/// neither BaseURL nor any generated option reached them.
/// </para>
/// <para>
/// On .NET that was fatal rather than merely wrong: 31 of the 42 carried a
/// template variable, and <c>new Uri("https://{domain}.hub.loginradius.com")</c>
/// throws UriFormatException — braces are not a legal host. Those operations
/// could not be called at all.
/// </para>
/// <para>RUNS OFFLINE.</para>
/// </remarks>
internal static class OperationServers
{
    internal static void Run()
    {
        Examples.Heading("Nothing configured — the spec's placeholder stands");
        Show(null, null);
        Console.WriteLine("  (that is the specification's own default, not a real tenant)");

        Examples.Heading("Domain = \"acme\" — fills the {domain} template variable");
        Show("acme", null);

        Examples.Heading("BaseURL — means \"send everything here\", pins included");
        Show(null, "https://staging.internal");

        Examples.Heading("An ordinary, unpinned operation for comparison");
        var unpinned = Examples.Capture(handler => new LoginRadiusConfig
        {
            ApiKey = "demo-api-key",
            BaseURL = "https://staging.internal",
            HttpClient = handler,
        });
        Examples.ShowUrl("URL sent:", unpinned);
    }

    private static void Show(string? domain, string? baseUrl)
    {
        // GetBigCommerceLoginUrl is pinned to https://{domain}.hub.loginradius.com.
        var request = Examples.Capture(
            handler => new LoginRadiusConfig
            {
                ApiKey = "demo-api-key",
                Domain = domain,
                BaseURL = baseUrl,
                HttpClient = handler,
            },
            client => client.BigCommerceSSO.GetBigCommerceLoginUrlAsync("demo-token", "mystore"));

        Examples.ShowUrl("URL sent:", request);
    }
}
