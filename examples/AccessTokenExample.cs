using LoginRadius.Sdk;

namespace LoginRadius.Sdk.Examples;

/// <summary>Auth scheme: AccessToken (query access_token).</summary>
/// <remarks>User-context endpoints operate on the signed-in user's own profile and sessions. The token comes from a login response and identifies that user. RUNS OFFLINE.</remarks>
internal static class AccessTokenExample
{
    internal static void Run()
    {
        Examples.Heading("What goes on the wire");

        var request = Examples.Capture(handler => new LoginRadiusConfig
        {
            ApiKey = "demo-api-key",
            AccessToken = "demo-access-token",
            HttpClient = handler,
        });

        Examples.ShowHeaders(request, "X-LoginRadius-ApiKey");
        Examples.ShowQuery(request, "apikey", "access_token");

        Console.WriteLine();
        Console.WriteLine("The access token identifies the user; the API key identifies your app.");
        Console.WriteLine("Both are sent — the endpoint needs to know who is calling and on whose behalf.");
    }
}
