using LoginRadius.Sdk;

namespace LoginRadius.Sdk.Examples;

/// <summary>
/// DefaultHeaders — headers merged into every outgoing request.
/// </summary>
/// <remarks>
/// Useful for correlation IDs, tenant traces, or anything your gateway needs.
/// The property worth understanding is PRECEDENCE: default headers are applied
/// first, so the SDK's own credential and User-Agent headers always win. A
/// default header cannot silently replace a credential. RUNS OFFLINE.
/// </remarks>
internal static class DefaultHeaders
{
    internal static void Run()
    {
        var request = Examples.Capture(handler => new LoginRadiusConfig
        {
            ApiKey = "REAL-API-KEY",
            DefaultHeaders = new Dictionary<string, string>
            {
                ["X-Tenant-Trace"] = "trace-abc123",
                ["X-Correlation-Id"] = "req-42",
                // Deliberately attempts to hijack two headers the SDK owns.
                ["X-LoginRadius-ApiKey"] = "HIJACKED",
                ["User-Agent"] = "HIJACKED",
            },
            HttpClient = handler,
        });

        Examples.Heading("Merged in");
        Examples.ShowHeaders(request, "X-Tenant-Trace", "X-Correlation-Id");

        Examples.Heading("Attempted overrides — the SDK's values stand");
        Examples.ShowHeaders(request, "X-LoginRadius-ApiKey", "User-Agent");

        Console.WriteLine();
        Console.WriteLine("Both show the SDK's own value, not HIJACKED. Letting a default header");
        Console.WriteLine("override a credential would mean silently sending the wrong one.");
    }
}
