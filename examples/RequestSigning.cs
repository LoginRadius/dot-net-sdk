using LoginRadius.Sdk;

namespace LoginRadius.Sdk.Examples;

/// <summary>
/// ApiRequestSigning — the digest and x-Request-Expires headers the LoginRadius
/// API accepts on management endpoints.
/// </summary>
/// <remarks>
/// Signing is opt-in and off by default. When enabled it applies only to
/// /manage/ paths, and never to /manage/account/access_token — that call is how
/// you obtain the credential you would sign with. The API secret is stripped
/// from the URL before the signature is computed, so it never appears in a
/// signed URL nor on the wire. RUNS OFFLINE.
/// </remarks>
internal static class RequestSigning
{
    internal static void Run()
    {
        Show("A management endpoint — signed", Examples.AnyManagementOperation);
        Show("An auth endpoint — not signed", Examples.AnyAuthOperation);
        Show("The access-token exchange — excluded", Examples.AccessTokenExchange);

        Console.WriteLine();
        Console.WriteLine("Signing cannot be validated offline: these prove the headers are applied");
        Console.WriteLine("where they should be, not that the API accepts the signature. Make one");
        Console.WriteLine("real /manage/ call against your tenant before relying on it.");
    }

    private static void Show(string label, Func<LoginRadiusClient, Task> call)
    {
        Examples.Heading(label);

        var request = Examples.Capture(
            handler => new LoginRadiusConfig
            {
                ApiKey = "demo-api-key",
                ApiSecret = "demo-api-secret",
                ApiRequestSigning = true,
                HttpClient = handler,
            },
            call);

        Examples.ShowUrl("URL sent:", request);
        Examples.ShowHeaders(request, Signing.DigestHeader, Signing.ExpiresHeader);
        Examples.ShowQuery(request, "apisecret");
    }
}
