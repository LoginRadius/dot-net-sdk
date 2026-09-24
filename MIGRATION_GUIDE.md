# Adopting the v12 .NET SDK

## Scope of this guide

This covers what v12 looks like and how to move an existing integration onto it:
construction, credentials, request and response shapes, error handling, server
selection, and custom HTTP.

It covers the v11 → v12 differences that change *every* call site: the package,
construction, the call style, and error handling.

**It does not include a full endpoint-by-endpoint mapping** from v11's method
surface. Every operation in the API is present in v12, so the mapping exists —
it just is not written out here. The representative flows below show how to
derive it, and `docs/API.md` lists all 392 operations with the
endpoint each one calls, which is the reliable way to find a v11 method's
counterpart. Tell us which methods you depend on and we will prioritise those.

## Why migrate

- Every operation in the API, not a hand-maintained subset that drifts behind it.
- Typed models everywhere, instead of maps and hand-built JSON.
- One place where credentials, signing, and logging are applied — so one place
  to audit.
- Behaviour defined once and applied everywhere in the client, rather than
  re-implemented per method, so credentials and error handling are consistent
  across every operation.

## Decide whether to migrate

You should migrate if you need operations the old integration never covered, if
you want typed errors rather than status-code checks scattered through your
code, or if you need the cross-cutting options (`originIp`, `serverRegion`,
`fields`, `preventWebhook`, default headers, signing).

You can wait if your integration touches only a handful of stable endpoints and
works. v12 is a new artifact; nothing forces the move on a schedule.

## What's different at a glance

| | Before | v12 |
|---|---|---|
| Construction | per-service objects, often static | one `LoginRadiusClient` per tenant |
| Credentials | passed per call, or global mutable state | set once on `LoginRadiusConfig` |
| Requests | dictionaries / hand-built JSON | typed model classes |
| Responses | dictionaries / raw JSON | typed model classes |
| Errors | status codes, raw bodies | `LoginRadiusException` + predicates |
| Base URL | often hardcoded | four-level precedence, see below |
| Calls | synchronous | `async`/`await` throughout |

## Package and target framework

The NuGet id is unchanged, so this is a version bump rather than a new package:

```
# v11
dotnet add package LoginRadiusSDK.NET --version 11.7.1

# v12
dotnet add package LoginRadiusSDK.NET --version 12.0.0-rc.1
```

**The target framework moves.** v11 supported .NET Framework 4.0+ and
.NET Standard 1.3+; v12 targets `net8.0`. If you are on
.NET Framework, that is the blocking constraint to resolve before anything else
in this guide matters.

One thing you can delete: v11's README required setting

```csharp
ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
```

in `Global.asax`, because the frameworks it supported defaulted to older TLS.
v12's target negotiates TLS 1.2+ on its own; that line is dead code.

## Construction

v11 configured the SDK through **process-global static state**, then instantiated
one class per API. v12 gives you a client object that owns its configuration:

```csharp
// v11 — global state, set once at startup
LoginRadiusSdkGlobalConfig.ApiKey = "__API_KEY__";
LoginRadiusSdkGlobalConfig.ApiSecret = "__API_SECRET__";
LoginRadiusSdkGlobalConfig.AppName = "__APP_NAME__";

var authenticationApi = new AuthenticationApi();
var accountApi = new AccountApi();

// v12 — configuration belongs to the client
using var client = new LoginRadiusClient(new LoginRadiusConfig
{
    ApiKey = Environment.GetEnvironmentVariable("LR_API_KEY"),
    ApiSecret = Environment.GetEnvironmentVariable("LR_API_SECRET"),  // server-side only
});

// every service hangs off that client
client.Login; client.Accounts; client.User;
```

That difference matters if you serve more than one tenant: v11's static config
made a second credential set impossible without mutating global state between
calls — a race in any concurrent host. In v12 you construct one client per tenant
and hold both, and it registers cleanly as a DI singleton.

## Call style

v11 returned `Task<ApiResponse>` and its documented usage blocked on `.Result`.
v12 is async to the call site:

```csharp
// v11 — sync-over-async, a deadlock risk on any host with a synchronisation
// context, and the reason many v11 integrations hang under load
var apiResponse = new AuthenticationApi()
    .LoginByEmail(model, emailTemplate, fields, loginUrl, verificationUrl)
    .Result;

// v12
var response = await client.Login.EmailByLoginUserNamePhoneAsync(model);
```

Every generated method is `…Async` and returns `Task<T>`. If a call site cannot
be made async, that is the one place to keep a blocking wrapper — but do it
deliberately, rather than inheriting `.Result` everywhere as v11 encouraged.

Build it once per tenant and hold it — register it as a singleton if you are
using DI. Every service property shares the underlying HTTP client, handlers,
and configuration, so constructing per request throws away connection pooling
for no benefit. The client is `IDisposable`: it owns a service provider.

The constructor throws `ArgumentException` if no credential is set at all, which
is otherwise a confusing 401 on the first call.

## Auth posture

Nine credentials, each sent as a header by preference and additionally as a
query parameter where the API accepts nothing else. Set only what your endpoints
need.

`ApiSecret` and `ClientSecret` are **server-side only**. They authorise acting
on any user's behalf; a build that ships either to a browser or a mobile app has
leaked the tenant.

## Request and response shapes

Operations take typed models:

```csharp
var body = new EmailByLoginUserNamePhoneRequest(
    new LoginByEmailRequest(email: new(email), password: new(password)));

var response = await client.Login.EmailByLoginUserNamePhoneAsync(body);
var result = response.Ok();
```

Optional parameters are wrapped in `Option<T>`, so an unset parameter is
distinguishable from one explicitly set to null — pass `new("value")` to set
one. Responses are `IApiResponse` wrappers: call `.Ok()` for the success model,
or the status-specific accessor you care about. Where a response is a `oneOf`,
each branch is a nullable property — check the one you expect rather than
assuming.

## Error handling

v11 returned an `ApiResponse` you had to inspect — a success path and a failure
path that looked identical at the call site, so an unchecked response silently
carried an error forward. v12 throws:

```csharp
// v11 — nothing forces you to look
var apiResponse = new AccountApi().GetAccountProfileByUid(uid, fields).Result;
// ... was that an error? you have to check the response object to know

// v12
try
{
    await client.Accounts.GetAccountIdentityByUIDAsync(uid);
}
catch (Exception e)
{
    var lr = LoginRadiusException.From(0, null, e);

    if (lr.IsAuth())      { /* credential rejected — do not retry as-is */ }
    if (lr.IsRateLimit()) { /* back off */ }
    if (lr.IsServer())    { /* retry with backoff */ }

    logger.LogWarning("{Description} ({Code}) status={Status}",
        lr.Description, lr.Code, lr.StatusCode);
}
```

The API returns three different error envelopes depending on the endpoint
family — PascalCase, camelCase, and the OAuth `{error, error_description}`
shape. All three normalise to the same exception, so your handling works
everywhere rather than on some endpoints only.

An empty or non-JSON body — common when a gateway or WAF blocks the request
before the API sees it — still produces a typed exception carrying a
status-based hint.

## Server selection

```
BaseURL = "https://…"           →  exactly that
CustomDomain = "auth.acme.com"  →  https://auth.acme.com
Domain = "acme"                 →  https://acme.hub.loginradius.com
(nothing)                       →  https://api.loginradius.com
```

The specification pins 42 operations to their own host. An explicit `BaseURL`
redirects those too — that is what makes pointing the SDK at a proxy or a
staging environment actually move all of your traffic.

## Custom HTTP handler

```csharp
new LoginRadiusConfig
{
    ApiKey = key,
    HttpClient = () => new SocketsHttpHandler
    {
        Proxy = proxy,
        ConnectTimeout = TimeSpan.FromSeconds(90),
    },
};
```

Your handler is installed as the primary handler, beneath the SDK's credential
handler, so your proxy and TLS settings apply to the fully decorated request.

## Representative endpoint mapping

v11 method names came from a hand-written surface; v12's come from the
specification's `operationId`. Most differ, and the reliable way to find a
counterpart is to match the **HTTP endpoint** rather than the name —
`docs/API.md` lists the endpoint for all 392 operations.

| v11 | v12 | Endpoint |
| --- | --- | --- |
| `AuthenticationApi.LoginByEmail` | `client.Login.EmailByLoginUserNamePhoneAsync` | `POST /identity/v2/auth/login` |
| `AccountApi.GetAccountProfileByUid` | `client.Accounts.GetAccountIdentityByUIDAsync` | `GET /identity/v2/manage/account/{uid}` |

Note the second one is admin-scoped (`/manage/`, authorised by the API secret).
For the signed-in user's own profile, `client.User.GetAccountDetailsAsync` calls
`GET /identity/v2/auth/account` with their access token — usually what a
customer-facing integration wants.

## What we don't migrate for you

- Stored access tokens and sessions. Tokens issued before the migration remain
  valid; the SDK does not manage their lifecycle.
- Your error-handling policy. The predicates tell you what kind of failure it
  was; retry and backoff are yours.
- Secret storage. The SDK reads what you give it and never persists anything.

## Need help?

<support@loginradius.com>
