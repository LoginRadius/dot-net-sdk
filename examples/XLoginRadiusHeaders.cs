using LoginRadius.Sdk;

namespace LoginRadius.Sdk.Examples;

/// <summary>Auth scheme: XLoginRadiusApiKey + XLoginRadiusApiSecret (header-only).</summary>
/// <remarks>Use these when the header credentials must differ from the query-parameter ones — for example when a gateway in front of the API rewrites or consumes the query form. RUNS OFFLINE.</remarks>
internal static class XLoginRadiusHeaders
{
    internal static void Run()
    {
        Examples.Heading("What goes on the wire");

        var request = Examples.Capture(handler => new LoginRadiusConfig
        {
            ApiKey = "query-api-key",
            XLoginRadiusApiKey = "header-api-key",
            XLoginRadiusApiSecret = "header-api-secret",
            HttpClient = handler,
        });

        Examples.ShowHeaders(request, "X-LoginRadius-ApiKey", "X-LoginRadius-ApiSecret");
        Examples.ShowQuery(request, "apikey");

        Console.WriteLine();
        Console.WriteLine("The header credentials override the header form only; the query form still");
        Console.WriteLine("carries whatever ApiKey was set. That separation is the point of these.");
    }
}
