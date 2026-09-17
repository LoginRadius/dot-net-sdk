using System.Collections.Concurrent;
using System.Security.Cryptography;

namespace LoginRadius.Sdk.Demo;

/// <summary>
/// In-memory session store mapping an opaque cookie value to an access token.
///
/// <para>DEMO ONLY. A real application would use a signed cookie or a session
/// store; keeping access tokens in a process dictionary loses them on restart
/// and does not survive more than one instance.</para>
/// </summary>
public sealed class DemoSessions
{
    private readonly ConcurrentDictionary<string, string> _tokens = new();

    /// <summary>Mints a session id for an access token.</summary>
    public string Create(string accessToken)
    {
        var id = Convert.ToHexString(RandomNumberGenerator.GetBytes(16)).ToLowerInvariant();
        _tokens[id] = accessToken;
        return id;
    }

    /// <summary>Returns the access token for a session id, or null.</summary>
    public string? Lookup(string? id) =>
        id is not null && _tokens.TryGetValue(id, out var token) ? token : null;

    public void Delete(string? id)
    {
        if (id is not null)
        {
            _tokens.TryRemove(id, out _);
        }
    }
}
