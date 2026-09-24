using LoginRadius.Sdk;

namespace LoginRadius.Sdk.Examples;

/// <summary>
/// Plugging your own <see cref="HttpMessageHandler"/> into the SDK — for a
/// proxy, custom TLS, request logging, metrics, or connection-pool tuning.
/// </summary>
/// <remarks>
/// Your handler is installed as the PRIMARY handler, underneath the SDK's
/// credential handler. That ordering is deliberate: it means your handler sees
/// the fully decorated request, and your proxy and TLS settings apply to what
/// actually goes out. RUNS OFFLINE.
/// </remarks>
internal static class CustomHttp
{
    /// <summary>A primary handler that logs and then answers locally.</summary>
    private sealed class LoggingHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"  -> {request.Method} {request.RequestUri?.AbsolutePath}");
            Console.WriteLine(
                $"     credentials present: {request.Headers.Contains("X-LoginRadius-ApiKey")}");

            return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json"),
            });
        }
    }

    internal static void Run()
    {
        Examples.Heading("A client with your own handler");

        using var client = new LoginRadiusClient(new LoginRadiusConfig
        {
            ApiKey = "demo-api-key",
            HttpClient = () => new LoggingHandler(),
        });

        try
        {
            Examples.AnyAuthOperation(client).GetAwaiter().GetResult();
        }
        catch
        {
            // The canned response does not deserialise; the log above is the point.
        }

        Console.WriteLine();
        Console.WriteLine("For a proxy, return a SocketsHttpHandler with Proxy set.");
        Console.WriteLine("For custom TLS, set SslOptions on it. The SDK touches neither.");
    }
}
