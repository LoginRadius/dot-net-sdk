using LoginRadius.Sdk;

namespace LoginRadius.Sdk.Examples;

/// <summary>Auth scheme: APIKey + APISecret.</summary>
/// <remarks>Server-side-only operations — token exchange, account lookup, and management endpoints. The secret must never reach a browser or a mobile app: it authorises acting on any user's behalf. RUNS OFFLINE.</remarks>
internal static class ApiKeySecret
{
    internal static void Run()
    {
        Examples.Heading("What goes on the wire");

        var request = Examples.Capture(handler => new LoginRadiusConfig
        {
            ApiKey = "demo-api-key",
            ApiSecret = "demo-api-secret",
            HttpClient = handler,
        });

        Examples.ShowHeaders(request, "X-LoginRadius-ApiKey", "X-LoginRadius-ApiSecret");
        Examples.ShowQuery(request, "apikey", "apisecret");

        Console.WriteLine();
        Console.WriteLine("Both credentials are sent as headers AND query parameters: some LoginRadius");
        Console.WriteLine("operations accept nothing else. Keep the secret server-side.");
    }
}
