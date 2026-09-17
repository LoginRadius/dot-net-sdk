using System.Linq;
using LoginRadius.Sdk;
using LoginRadius.Sdk.Demo;

// A runnable demo of the LoginRadius .NET SDK.
//
// Uses ASP.NET Core's minimal API — built into the SDK, so the demo adds no
// dependency beyond the LoginRadius facade itself.
//
//   export LR_API_KEY=... LR_API_SECRET=...
//   dotnet run --project demo
//
// Reads the same environment variables as every other language's demo:
// LR_API_KEY, LR_API_SECRET, and the optional server-selection trio
// LR_DOMAIN / LR_CUSTOM_DOMAIN / LR_BASE_URL.

// Load .env from the repo root (dev convenience — never do this in production).
// dotnet run sets CWD to the project folder; .env lives one level up.
var dotEnv = Path.Combine(Directory.GetCurrentDirectory(), ".env");
if (!File.Exists(dotEnv))
    dotEnv = Path.Combine(Directory.GetCurrentDirectory(), "..", ".env");
if (File.Exists(dotEnv))
{
    foreach (var line in File.ReadAllLines(dotEnv))
    {
        if (line.StartsWith('#') || !line.Contains('=')) continue;
        var parts = line.Split('=', 2);
        var key = parts[0].Trim().TrimStart('\uFEFF');
        // A real shell-exported var wins over .env — matches Node's dotenv and
        // the PHP demo's loader. Silently overwriting an operator's real
        // environment with a stale .env value is exactly the "invalid API key"
        // trap hit during this SDK's own testing.
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(key)))
        {
            Environment.SetEnvironmentVariable(key, parts[1].Trim());
        }
    }
}

var apiKey = Environment.GetEnvironmentVariable("LR_API_KEY");
if (string.IsNullOrEmpty(apiKey))
{
    Console.Error.WriteLine("LR_API_KEY is required");
    return 1;
}

var config = new LoginRadiusConfig
{
    ApiKey = apiKey,
    ApiSecret = Environment.GetEnvironmentVariable("LR_API_SECRET"),
    // Server selection, same precedence as every other SDK.
    Domain = Environment.GetEnvironmentVariable("LR_DOMAIN"),
    CustomDomain = Environment.GetEnvironmentVariable("LR_CUSTOM_DOMAIN"),
    BaseURL = Environment.GetEnvironmentVariable("LR_BASE_URL"),
    UserAgent = "loginradius-dotnet-demo/0.1",
};

using var client = new LoginRadiusClient(config);
var sessions = new DemoSessions();
var handlers = new DemoHandlers(client, config, sessions);

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
var app = builder.Build();

// The UI. Not part of the shared contract — each language's demo ships its own
// look, which is deliberate.
app.UseDefaultFiles();
app.UseStaticFiles();

// The API surface comes from DemoRoutes, generated from manifest/sdk.yaml,
// plus ExtendedDemoRoutes (hand-written, not part of the shared contract — see
// its header comment). Registering from the table (rather than by hand) is
// what keeps every language's demo on the same endpoints: method checking and
// session enforcement are applied uniformly here instead of being
// re-implemented, slightly differently, in each handler.
foreach (var route in DemoRoutes.All().Concat(ExtendedDemoRoutes.All()))
{
    var captured = route;
    app.MapMethods(captured.Path, [captured.Method], async (HttpContext ctx) =>
    {
        if (captured.RequiresSession && sessions.Lookup(Demo.SessionId(ctx)) is null)
        {
            await Demo.WriteJsonAsync(ctx, 401, new { error = "not signed in" });
            return;
        }
        await captured.Handler(ctx, handlers);
    });
}

var port = Environment.GetEnvironmentVariable("LR_DEMO_PORT") ?? "8080";
Console.WriteLine($"demo listening on http://localhost:{port}/");
// Bind all interfaces, not just localhost — matches the Go/Java/PHP demos, and
// is required for the demo to be reachable from outside a container.
app.Run($"http://0.0.0.0:{port}");
return 0;
