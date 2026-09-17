using LoginRadius.Sdk;

namespace LoginRadius.Sdk.Examples;

/// <summary>
/// The minimum needed to call a LoginRadius endpoint with the v12 SDK:
/// construct a client with an API key, then call an operation through a service
/// property.
/// </summary>
/// <remarks>
/// Unlike the rest of this project this example really calls the API, so it
/// needs LR_API_KEY in the environment.
/// </remarks>
internal static class Quickstart
{
    internal static void Run()
    {
        var apiKey = Environment.GetEnvironmentVariable("LR_API_KEY");
        if (string.IsNullOrEmpty(apiKey))
        {
            Console.Error.WriteLine("set LR_API_KEY to run this example");
            Environment.Exit(2);
            return;
        }

        // One client per tenant, reused for the life of the process: every
        // service property shares its HTTP client, handlers, and configuration.
        using var client = new LoginRadiusClient(new LoginRadiusConfig { ApiKey = apiKey });

        try
        {
            var result = client.Login
                .CheckUserNameAvailabilityAsync(username: new("alice"))
                .GetAwaiter()
                .GetResult();

            Console.WriteLine($"username available: {result.Ok()}");
        }
        catch (Exception e)
        {
            // Convert to the facade's typed exception so you branch on intent
            // rather than on status codes.
            var lr = LoginRadiusException.From(0, null, e);
            Console.Error.WriteLine($"failed: {lr.Description} (code {lr.Code})");
            if (lr.IsAuth())
            {
                Console.Error.WriteLine("the API key was rejected");
            }

            Environment.Exit(1);
        }
    }
}
