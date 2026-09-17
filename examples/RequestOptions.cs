using LoginRadius.Sdk;

namespace LoginRadius.Sdk.Examples;

/// <summary>
/// The four client-wide request options the legacy v11 SDK had and v12 was
/// missing: OriginIp, ServerRegion, Fields, and PreventWebhook.
/// </summary>
/// <remarks>
/// Each is applied to EVERY outgoing request by the same handler that injects
/// credentials, so there is one place to audit rather than 210 hand-written
/// call sites. RUNS OFFLINE.
/// </remarks>
internal static class RequestOptions
{
    internal static void Run()
    {
        Examples.Heading("With every option set");
        var configured = Examples.Capture(handler => new LoginRadiusConfig
        {
            ApiKey = "demo-api-key",
            OriginIp = "203.0.113.7",
            ServerRegion = "eu",
            Fields = "Email,Uid",
            PreventWebhook = true,
            HttpClient = handler,
        });
        Examples.ShowHeaders(configured, "X-Origin-IP", "X-PreventWebhook");
        Examples.ShowQuery(configured, "region", "fields");

        Examples.Heading("With none set — nothing is added");
        var bare = Examples.Capture(handler => new LoginRadiusConfig
        {
            ApiKey = "demo-api-key",
            HttpClient = handler,
        });
        Examples.ShowHeaders(bare, "X-Origin-IP", "X-PreventWebhook");
        Examples.ShowQuery(bare, "region", "fields");

        Console.WriteLine();
        Console.WriteLine("An unset option sends nothing at all — it never sends an empty value,");
        Console.WriteLine("which the API would treat as a real (and wrong) filter.");
    }
}
