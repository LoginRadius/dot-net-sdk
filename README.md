# LoginRadius .NET SDK — v12

Official .NET SDK for the [LoginRadius](https://www.loginradius.com) Customer
Identity and Access Management (CIAM) platform, generated from the LoginRadius
OpenAPI specification: every operation is present, the models match the wire
format, and credentials, base-URL precedence, error classification, request
signing and SOTT are applied in one place rather than per call.

## What changed in v12

v12 is generated rather than hand-written. Practically, that means:

- **Full API coverage.** 57 services covering every operation in the spec, not a
  hand-maintained subset that drifts behind the API.
- **Typed models** for every request and response.
- **One credential path.** Credentials, cross-cutting request options, signing,
  and debug logging are applied by a single handler, so there is one place
  to audit rather than one per method.
- **Typed errors** with intent-based predicates (`IsAuth()`, `IsRateLimit()`)
  instead of status-code comparisons at every call site.

v12 has never been released, so it is not a drop-in replacement for 11.x. See
`MIGRATION_GUIDE.md`.

## Install

```bash
dotnet add package LoginRadiusSDK.NET --version 12.0.0-rc.1
```

Targets .NET 8.0.

## Quickstart

```csharp
using var client = new LoginRadiusClient(new LoginRadiusConfig
{
    ApiKey = Environment.GetEnvironmentVariable("LR_API_KEY"),
});

var result = await client.Login.CheckUserNameAvailabilityAsync(username: new("alice"));
```

Construct one client per tenant and reuse it: every service property shares the
underlying HTTP client, handlers, and configuration. The client is
`IDisposable` — it owns a service provider and its HTTP clients.

## Authentication

Set whichever credentials your endpoints require; the SDK sends only what you
set. Each is sent as a header and, where the API accepts nothing else, also as a
query parameter.

| Option | Sent as | Notes |
|---|---|---|
| `ApiKey` | `X-LoginRadius-ApiKey`, `?apikey` | Almost every endpoint |
| `ApiSecret` | `X-LoginRadius-ApiSecret`, `?apisecret` | **Server-side only** |
| `AccessToken` | `?access_token` | User-context endpoints |
| `BearerToken` | `Authorization: Bearer` | |
| `M2mBearerToken` | `Authorization: Bearer` | Machine-to-machine JWT |
| `ClientId` / `ClientSecret` | `?client_id`, `?client_secret` | **Secret is server-side only** |
| `XLoginRadiusApiKey` / `XLoginRadiusApiSecret` | headers only | When header and query values must differ |

Never ship `ApiSecret` or `ClientSecret` to a browser or mobile app: they
authorise acting on any user's behalf.

## Server selection

Resolved in this order — the first one set wins:

```
BaseURL = "https://…"            →  exactly that
CustomDomain = "auth.acme.com"   →  https://auth.acme.com
Domain = "acme"                  →  https://acme.hub.loginradius.com
(nothing)                        →  https://api.loginradius.com
```

The specification pins 42 operations to their own host — the migration and
cloud-api services, plus tenant-hub and custom-domain templates. Setting
`BaseURL` redirects those too, so pointing the SDK at a proxy or a staging host
really does move all of your traffic. Leave it unset and the pins stand, with
their template variables filled from `Domain` / `CustomDomain`.

On .NET this was not merely wrong but fatal: 31 of those 42 pins carry a
template variable, and a URI with braces in the host throws before a request is
made. Those operations could not be called at all until this was fixed.

## Cross-cutting request options

Applied to every request by the same handler that injects credentials:

```csharp
new LoginRadiusConfig
{
    ApiKey = key,
    OriginIp = "203.0.113.7",   // X-Origin-IP — risk-based auth, audit trails
    ServerRegion = "eu",        // ?region
    Fields = "Email,Uid",       // ?fields — response field selector
    PreventWebhook = true,      // X-PreventWebhook
    DefaultHeaders = new Dictionary<string, string> { ["X-Correlation-Id"] = id },
};
```

Default headers are merged at the lowest precedence: they cannot mask the SDK's
own credential or `User-Agent` headers.

## Request signing

Opt-in and off by default:

```csharp
new LoginRadiusConfig { ApiKey = k, ApiSecret = s, ApiRequestSigning = true };
```

Adds `digest` and `x-Request-Expires` to `/manage/` requests only, never to
`/manage/account/access_token`. The API secret is stripped from the URL before
the signature is computed, so it never appears in a signed URL.

## Debug logging

```csharp
new LoginRadiusConfig { ApiKey = k, Debug = line => logger.LogDebug(line) };
```

Credential values are redacted before anything is written; the header name is
kept, so a debug log is safe to paste into a ticket.

## Custom HTTP handler

```csharp
new LoginRadiusConfig
{
    ApiKey = k,
    HttpClient = () => new SocketsHttpHandler { Proxy = proxy },
};
```

Your handler is installed as the **primary** handler, underneath the SDK's
credential handler. That ordering is deliberate: your proxy, TLS, and pooling
apply to the fully decorated request rather than replacing the credential
injection, and a logging handler of yours sees exactly what goes on the wire.

## Error handling

```csharp
try
{
    await client.Accounts.GetAccountIdentityByUIDAsync(uid);
}
catch (Exception e)
{
    var lr = LoginRadiusException.From(0, null, e);
    if (lr.IsAuth())      { /* credential rejected */ }
    if (lr.IsRateLimit()) { /* back off */ }
    Console.Error.WriteLine($"{lr.Description} ({lr.Code})");
}
```

The API returns three different error envelopes depending on the endpoint
family; all three are normalised to the same typed exception.

## Examples

15 runnable examples in `examples/` — most run offline:

```bash
dotnet run --project examples            # list them
dotnet run --project examples -- request-options
```

## Demo

A complete browser flow — register, log in, profile, password reset — in
`demo/`. Copy `.env.example` to `.env`, fill it in, and run
`dotnet run --project demo`.

## Migrating from v11

See `MIGRATION_GUIDE.md`.

## Support

- Bugs and feature requests: <https://github.com/LoginRadius/dot-net-sdk/issues>
- Account or integration questions: <support@loginradius.com>
- API documentation: <https://www.loginradius.com/docs/api/openapi/customer-identity-api>

## API reference

The API itself is documented at
[https://www.loginradius.com/docs/api/openapi/customer-identity-api](https://www.loginradius.com/docs/api/openapi/customer-identity-api) — endpoint behaviour, request and response fields, and what
each operation does. This SDK is generated from the same specification, so the
two stay in step.

[`docs/API.md`](./docs/API.md) lists every one of the 392
operations with its method name, HTTP verb and path, grouped across the
57 services.

Per-member descriptions ship as XML documentation inside the NuGet package, so
your IDE shows them on hover without any extra download.

## Validating a LoginRadius JWT

`JwtValidation.Validate` verifies a token issued by one of your JWT apps. It is
entirely local — no network call, no credentials, no client.

```csharp
var claims = JwtValidation.Validate(token, new JwtValidationParams
{
    Algorithm = JwtAlgorithm.HS256,   // the algorithm YOUR app is configured for
    Key = Encoding.UTF8.GetBytes(secret),
    Issuer = "LoginRadius",           // optional
});
```

Signature, `exp` and `nbf` are always checked; issuer and audience are checked
when supplied. HS256/384/512 take the shared secret; RS*/ES* take the
PEM-encoded **public** key. Throws `JwtValidationException`, whose `Code` is a
short stable reason.

> **The algorithm is yours to state, and is never read from the token.** A
> validator that trusts the token's own `alg` header can be attacked: against an
> RS256 app, an attacker signs with HS256 using the public key as the HMAC
> secret. Passing the algorithm your app is configured for is what prevents it.

## License

MIT
