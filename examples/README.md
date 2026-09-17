# Examples

One class per topic, dispatched from a single entry point:

```bash
dotnet run --project examples -- request-options
dotnet run --project examples            # lists them all
```

Most **run offline**: they call a real SDK operation but capture the request at
the transport instead of sending it, so you see exactly what would go on the
wire without a tenant, credentials, or a network. The two that do reach the API
say so and read `LR_API_KEY` from the environment.

| Example | Shows |
|---|---|
| `quickstart` | The minimum: construct a client, call an operation. **Needs `LR_API_KEY`.** |
| `login` | Passwordless email login. **Needs `LR_API_KEY` and an email argument.** |
| `api-key-secret` | API key + secret — server-side operations |
| `access-token` | Access token — user-context operations |
| `bearer-token` | `Authorization: Bearer <token>` |
| `m2m-bearer-token` | Machine-to-machine JWT |
| `client-id-secret` | OAuth client id + secret |
| `x-loginradius-headers` | Header-only credentials, separate from the query form |
| `request-options` | `OriginIp`, `ServerRegion`, `Fields`, `PreventWebhook` |
| `default-headers` | Headers merged into every request, and why they cannot mask a credential |
| `request-signing` | `digest` / `x-Request-Expires`, and exactly which paths get signed |
| `debug-logging` | Request logging, and the redaction that makes it safe to paste |
| `operation-servers` | The 42 operations the spec pins elsewhere, and how to redirect them |
| `timeout-http-client` | How `Timeout` interacts with a handler you supply |
| `custom-http` | Proxies, TLS, metrics — plugging in your own handler |

This project is not packable: it builds with the solution so the examples cannot
rot, but it never ships inside the NuGet package.
