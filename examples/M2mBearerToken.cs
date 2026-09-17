using LoginRadius.Sdk;

namespace LoginRadius.Sdk.Examples;

/// <summary>Auth scheme: M2MBearerToken (Authorization: Bearer &lt;JWT&gt;).</summary>
/// <remarks>Machine-to-machine endpoints require an M2M JWT, obtained from the OAuth M2M token endpoint rather than from a user login. RUNS OFFLINE.</remarks>
internal static class M2mBearerToken
{
    internal static void Run()
    {
        Examples.Heading("What goes on the wire");

        var request = Examples.Capture(handler => new LoginRadiusConfig
        {
            ApiKey = "demo-api-key",
            M2mBearerToken = "demo-m2m-jwt",
            HttpClient = handler,
        });

        Examples.ShowHeaders(request, "Authorization", "X-LoginRadius-ApiKey");
        Examples.ShowQuery(request, "apikey");

        Console.WriteLine();
        Console.WriteLine("An M2M token represents a service, not a user, so there is no access_token");
        Console.WriteLine("and no signed-in identity behind the call.");
    }
}
