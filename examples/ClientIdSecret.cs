using LoginRadius.Sdk;

namespace LoginRadius.Sdk.Examples;

/// <summary>Auth scheme: ClientId + ClientSecret (query parameters).</summary>
/// <remarks>OAuth-style endpoints — typically multipurpose token operations and account linking. These identify an OAuth client rather than your LoginRadius app. RUNS OFFLINE.</remarks>
internal static class ClientIdSecret
{
    internal static void Run()
    {
        Examples.Heading("What goes on the wire");

        var request = Examples.Capture(handler => new LoginRadiusConfig
        {
            ClientId = "demo-client-id",
            ClientSecret = "demo-client-secret",
            HttpClient = handler,
        });

        Examples.ShowHeaders(request, "X-LoginRadius-ApiKey");
        Examples.ShowQuery(request, "client_id", "client_secret");

        Console.WriteLine();
        Console.WriteLine("The client secret is server-side-only, exactly like the API secret.");
    }
}
