using LoginRadius.Sdk;

namespace LoginRadius.Sdk.Examples;

/// <summary>
/// How Timeout interacts with an injected handler.
/// </summary>
/// <remarks>
/// The rule: the SDK never imposes its default on transport you own. Set
/// Timeout explicitly and it applies, because you asked for it; leave it unset
/// and the SDK's 30-second default is used for the client it builds. Any other
/// rule would silently retune a pipeline you had already configured for your
/// own workload.
/// </remarks>
internal static class TimeoutHttpClient
{
    internal static void Run()
    {
        Examples.Heading("No Timeout set — the SDK's default applies");
        var a = new LoginRadiusConfig { ApiKey = "demo-api-key" };
        Console.WriteLine($"  {"configured timeout",-28} {a.Timeout?.ToString() ?? "(unset — default " + LoginRadiusConfig.DefaultTimeout + ")"}");

        Examples.Heading("Timeout set explicitly — yours wins");
        var b = new LoginRadiusConfig
        {
            ApiKey = "demo-api-key",
            Timeout = TimeSpan.FromSeconds(5),
        };
        Console.WriteLine($"  {"configured timeout",-28} {b.Timeout}");

        Examples.Heading("With your own primary handler");
        var c = Examples.Capture(handler => new LoginRadiusConfig
        {
            ApiKey = "demo-api-key",
            Timeout = TimeSpan.FromSeconds(5),
            HttpClient = handler,
        });
        Examples.ShowUrl("URL sent:", c);

        Console.WriteLine();
        Console.WriteLine("A handler you supply sits UNDERNEATH the SDK's credential handler, so");
        Console.WriteLine("your proxy, TLS, and pooling apply to the fully decorated request rather");
        Console.WriteLine("than replacing the credential injection.");
    }
}
