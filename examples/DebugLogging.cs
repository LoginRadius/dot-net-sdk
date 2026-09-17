using LoginRadius.Sdk;

namespace LoginRadius.Sdk.Examples;

/// <summary>Debug — a one-line summary of every request.</summary>
/// <remarks>
/// The property worth verifying here is REDACTION: credential header values are
/// replaced before anything is written, so a debug log can be pasted into a
/// ticket without leaking an API secret or an access token. The header NAME is
/// kept, because knowing which credential was sent is the point of the log.
/// RUNS OFFLINE.
/// </remarks>
internal static class DebugLogging
{
    internal static void Run()
    {
        Examples.Heading("Debug output");

        Examples.Capture(handler => new LoginRadiusConfig
        {
            ApiKey = "SUPER-SECRET-KEY",
            ApiSecret = "SUPER-SECRET-VALUE",
            BearerToken = "SUPER-SECRET-TOKEN",
            Debug = line => Console.WriteLine("  " + line),
            HttpClient = handler,
        });

        Console.WriteLine();
        Console.WriteLine("Every credential above appears by header name with its value replaced.");
        Console.WriteLine("Debug takes an Action<string>, so route it to any logger you like.");
    }
}
