using LoginRadius.Sdk.Examples;

// One entry point dispatching to one class per example. .NET allows a single
// Main per project, so a project per example would mean 15 projects and 15
// restores; this keeps them in one place while each example stays its own
// self-contained class.

var name = args.Length > 0 ? args[0] : null;
var rest = args.Length > 1 ? args[1..] : Array.Empty<string>();

var examples = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase)
{
    ["quickstart"] = Quickstart.Run,
    ["login"] = () => Login.Run(rest),
    ["api-key-secret"] = ApiKeySecret.Run,
    ["access-token"] = AccessTokenExample.Run,
    ["bearer-token"] = BearerTokenExample.Run,
    ["m2m-bearer-token"] = M2mBearerToken.Run,
    ["client-id-secret"] = ClientIdSecret.Run,
    ["x-loginradius-headers"] = XLoginRadiusHeaders.Run,
    ["request-options"] = RequestOptions.Run,
    ["default-headers"] = DefaultHeaders.Run,
    ["request-signing"] = RequestSigning.Run,
    ["debug-logging"] = DebugLogging.Run,
    ["operation-servers"] = OperationServers.Run,
    ["timeout-http-client"] = TimeoutHttpClient.Run,
    ["custom-http"] = CustomHttp.Run,
};

if (name is null || !examples.TryGetValue(name, out var run))
{
    Console.Error.WriteLine("usage: dotnet run --project examples -- <example> [args]");
    Console.Error.WriteLine();
    Console.Error.WriteLine("Available:");
    foreach (var key in examples.Keys.OrderBy(k => k, StringComparer.Ordinal))
    {
        Console.Error.WriteLine($"  {key}");
    }

    return name is null ? 0 : 1;
}

run();
return 0;
