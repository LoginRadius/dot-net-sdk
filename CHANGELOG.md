# v12 changelog

## v12.0.0-rc.1

The first .NET SDK generated from the LoginRadius OpenAPI specification. There
is no earlier v12, and no 11.x .NET SDK it replaces in place — see
`MIGRATION_GUIDE.md` if you are coming from a hand-written integration.

### What's new

- **Generated from the OpenAPI spec.** Every operation in
  `LoginRadius-Public-APIs.yaml` is reachable through a typed service on
  `LoginRadiusClient` — 57 services.
- **Typed request and response models** for every schema in the spec, rather
  than dictionaries and hand-built JSON.
- **Centralised authentication.** All nine credentials are injected by a single
  `DelegatingHandler`, configured once on `LoginRadiusConfig`. Each is sent as a
  header by preference — keeping secrets out of access logs and URL caches —
  and additionally as a query parameter for the operations that accept nothing
  else.
- **Typed errors.** `LoginRadiusException` exposes the HTTP status, LoginRadius
  error code, description, and raw body, plus `IsAuth()`, `IsForbidden()`,
  `IsRateLimit()`, and `IsServer()`. The API's three different error envelopes
  are normalised to one shape.
- **Cross-cutting request options** applied to every request: `OriginIp`,
  `ServerRegion`, `Fields`, `PreventWebhook`, and arbitrary `DefaultHeaders`.
  Default headers are merged at the lowest precedence and cannot mask a
  credential.
- **Request signing.** Opt-in `digest` / `x-Request-Expires` headers on
  `/manage/` endpoints, excluding the access-token exchange. The API secret is
  stripped from the URL before signing.
- **Debug logging** with credential values redacted, so a log is safe to share.
- **SOTT generation** matching every other LoginRadius SDK byte for byte,
  guarded by golden-value tests.
- **Custom handler support**: your `HttpMessageHandler` is installed as the
  primary handler, beneath the SDK's credential handler, so your proxy and TLS
  settings apply to the finished request.

### Fixed before first release

- **The client could not be constructed.** The generated APIs take a
  `TokenProvider<T>` as a constructor dependency; without one registered, DI
  activation of every service failed. Credentials come from the credential
  handler, so the SDK now registers providers that apply nothing.
- **The 42 operations the spec pins to their own host.** The generator inlines
  each pin directly into the operation with no override hook, so an explicit
  `BaseURL` was ignored for migration, cloud-api, OIDC, OAuth, and SSO traffic.
  31 of them carried a template variable, and a URI with braces in the host
  throws `UriFormatException` — those operations could not be called at all.
  The operation's own path was also dropped, leaving every pinned request
  addressed at the host root.
- **The solution file referenced two projects with doubled path separators**, so
  the test and demo projects were silently skipped: `dotnet build` and
  `dotnet test` both reported success having compiled and run neither.

### Known limitations

- Request signing has not been validated against a live tenant. The
  implementation matches the reference algorithm and is covered by
  cross-language golden-value tests, but no signed request has been accepted by
  the API yet. It ships opt-in and off by default.
