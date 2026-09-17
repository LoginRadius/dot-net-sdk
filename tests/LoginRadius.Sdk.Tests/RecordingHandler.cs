using System.Net;

namespace LoginRadius.Sdk.Tests;

/// <summary>
/// Terminal handler that captures the fully decorated request and answers with
/// a canned response, so a test can assert on what the SDK would put on the
/// wire without one going anywhere.
/// </summary>
/// <remarks>
/// This is the .NET counterpart of the custom <c>RoundTripper</c> the Go suite
/// uses. It has to be the <em>primary</em> handler: the facade installs its
/// <c>AuthHandler</c> above the caller's, so anything higher in the chain would
/// see the request before the credentials were applied and assert nothing.
/// </remarks>
internal sealed class RecordingHandler : HttpMessageHandler
{
    private readonly HttpStatusCode _status;
    private readonly string _body;

    internal RecordingHandler(HttpStatusCode status = HttpStatusCode.OK, string body = "{}")
    {
        _status = status;
        _body = body;
    }

    /// <summary>The last request that reached the transport.</summary>
    internal HttpRequestMessage? Request { get; private set; }

    /// <summary>The last request's body, read before the handler returns.</summary>
    internal string? RequestBody { get; private set; }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        Request = request;
        RequestBody = request.Content is null
            ? null
            : await request.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        return new HttpResponseMessage(_status)
        {
            Content = new StringContent(_body, System.Text.Encoding.UTF8, "application/json"),
            RequestMessage = request,
        };
    }

    /// <summary>Header value, or null when the header is absent.</summary>
    internal string? Header(string name)
    {
        if (Request is null)
        {
            return null;
        }

        if (Request.Headers.TryGetValues(name, out var values))
        {
            return string.Join(",", values);
        }

        return Request.Content is not null && Request.Content.Headers.TryGetValues(name, out var cv)
            ? string.Join(",", cv)
            : null;
    }

    /// <summary>Query-string value, or null when the parameter is absent.</summary>
    internal string? Query(string name)
    {
        var q = System.Web.HttpUtility.ParseQueryString(Request?.RequestUri?.Query ?? string.Empty);
        return q[name];
    }
}
