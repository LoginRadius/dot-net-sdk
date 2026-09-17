using LoginRadius.Sdk;

namespace LoginRadius.Sdk.Examples;

/// <summary>Auth scheme: BearerToken (Authorization: Bearer &lt;token&gt;).</summary>
/// <remarks>Endpoints protected with the HTTP bearer scheme accept a bearer token in the standard Authorization header. RUNS OFFLINE.</remarks>
internal static class BearerTokenExample
{
    internal static void Run()
    {
        Examples.Heading("What goes on the wire");

        var request = Examples.Capture(handler => new LoginRadiusConfig
        {
            ApiKey = "demo-api-key",
            BearerToken = "demo-bearer-token",
            HttpClient = handler,
        });

        Examples.ShowHeaders(request, "Authorization", "X-LoginRadius-ApiKey");
        Examples.ShowQuery(request, "apikey");

        Console.WriteLine();
        Console.WriteLine("The bearer token goes in the standard Authorization header, not the query.");
    }
}
