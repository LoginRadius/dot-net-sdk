using System.Net;
using LoginRadius.Sdk;

namespace LoginRadius.Sdk.Examples;

/// <summary>
/// Shared plumbing for the runnable examples.
/// </summary>
/// <remarks>
/// <para>
/// Every example here RUNS OFFLINE. Each calls a real SDK operation, but the
/// request is captured at the transport instead of being sent, so the output is
/// exactly what would have gone on the wire — no tenant, no credentials, no
/// network. The two examples that do reach the API say so.
/// </para>
/// <para>
/// The recorder has to be the <em>primary</em> handler. The facade installs its
/// credential handler above the caller's, so anything higher in the chain sees
/// the request before the credentials are applied and would show nothing.
/// </para>
/// </remarks>
internal static class Examples
{
    /// <summary>Terminal handler that records the finished request.</summary>
    internal sealed class Recorder : HttpMessageHandler
    {
        internal HttpRequestMessage? Request { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Request = request;
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json"),
                RequestMessage = request,
            });
        }

        internal string? Header(string name)
        {
            if (Request is null)
            {
                return null;
            }

            return Request.Headers.TryGetValues(name, out var values)
                ? string.Join(",", values)
                : null;
        }

        internal string? Query(string name) =>
            System.Web.HttpUtility.ParseQueryString(Request?.RequestUri?.Query ?? string.Empty)[name];
    }

    /// <summary>
    /// Runs one operation through a client built from <paramref name="config"/>
    /// and returns the request it produced.
    /// </summary>
    /// <remarks>
    /// Any operation would do: the options these examples demonstrate apply to
    /// every request, which is the whole point of them living in the transport.
    /// </remarks>
    internal static Recorder Capture(
        Func<Func<HttpMessageHandler>, LoginRadiusConfig> config,
        Func<LoginRadiusClient, Task>? call = null)
    {
        var recorder = new Recorder();
        using var client = new LoginRadiusClient(config(() => recorder));

        try
        {
            (call ?? AnyAuthOperation)(client).GetAwaiter().GetResult();
        }
        catch
        {
            // The canned response does not deserialise into the operation's
            // model; the request is what matters.
        }

        if (recorder.Request is null)
        {
            throw new InvalidOperationException("no request reached the transport");
        }

        return recorder;
    }

    /// <summary>GET /identity/v2/auth/... — an ordinary, unsigned endpoint.</summary>
    internal static Task AnyAuthOperation(LoginRadiusClient client) =>
        client.Login.CheckUserNameAvailabilityAsync(username: new("alice"));

    /// <summary>GET /identity/v2/manage/account/{uid} — a management endpoint.</summary>
    internal static Task AnyManagementOperation(LoginRadiusClient client) =>
        client.Accounts.GetAccountIdentityByUIDAsync("demo-uid");

    /// <summary>
    /// GET /identity/v2/manage/account/access_token — a management endpoint that
    /// signing deliberately excludes, because it is how you obtain the
    /// credential you would sign with.
    /// </summary>
    internal static Task AccessTokenExchange(LoginRadiusClient client) =>
        client.Accounts.GetImpersonationTokenAsync("demo-uid");

    internal static void ShowHeaders(Recorder r, params string[] names)
    {
        foreach (var name in names)
        {
            Console.WriteLine($"  {name + ":",-28} {r.Header(name) ?? "(not sent)"}");
        }
    }

    internal static void ShowQuery(Recorder r, params string[] names)
    {
        foreach (var name in names)
        {
            Console.WriteLine($"  {"?" + name + "=",-28} {r.Query(name) ?? "(not sent)"}");
        }
    }

    internal static void ShowUrl(string label, Recorder r) =>
        Console.WriteLine($"  {label,-28} {r.Request!.Method} {r.Request.RequestUri}");

    internal static void Heading(string title)
    {
        Console.WriteLine();
        Console.WriteLine(title);
        Console.WriteLine(new string('-', title.Length));
    }
}
