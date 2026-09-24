using LoginRadius.Sdk;

namespace LoginRadius.Sdk.Examples;

/// <summary>
/// A passwordless login flow: the user receives a one-time email link which, on
/// click, delivers an access token.
/// </summary>
/// <remarks>
/// This example covers the first half — initiating the email. Completing the
/// flow happens in the browser via the verification endpoint; the demo project
/// shows that half. Really calls the API: needs LR_API_KEY and an email
/// argument.
/// </remarks>
internal static class Login
{
    internal static void Run(string[] args)
    {
        if (args.Length < 1)
        {
            Console.Error.WriteLine("usage: login <email>");
            Environment.Exit(2);
            return;
        }

        var apiKey = Environment.GetEnvironmentVariable("LR_API_KEY");
        if (string.IsNullOrEmpty(apiKey))
        {
            Console.Error.WriteLine("LR_API_KEY is required");
            Environment.Exit(2);
            return;
        }

        using var client = new LoginRadiusClient(new LoginRadiusConfig { ApiKey = apiKey });

        try
        {
            var response = client.Login
                .PasswordlessLoginByEmailAsync(email: new(args[0]))
                .GetAwaiter()
                .GetResult();

            Console.WriteLine($"login email sent: {response.Ok()}");
        }
        catch (Exception e)
        {
            // The typed exception carries the HTTP status, the LoginRadius error
            // code, and the raw body — branch on intent, not on status codes.
            var lr = LoginRadiusException.From(0, null, e);
            Console.Error.WriteLine(
                lr.IsAuth()
                    ? $"authentication rejected: {lr.Description}"
                    : $"failed: {lr.Description} (code {lr.Code})");
            Environment.Exit(1);
        }
    }
}
