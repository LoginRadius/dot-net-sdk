using Xunit;

namespace LoginRadius.Sdk.Tests;

/// <summary>
/// CROSS-LANGUAGE PARITY. Mirrors Go's <c>TestExtractEnvelopeAcrossWireShapes</c>,
/// <c>TestErrorPredicates</c>, and <c>TestDefaultDescriptionForStatus</c>, and
/// Node's <c>errors.test.ts</c>.
/// </summary>
public class ErrorTests
{
    /// <summary>
    /// The LoginRadius API returns three different error envelopes depending on
    /// which family of endpoints answered. All three must classify identically,
    /// or a caller's error handling works on some endpoints and not others.
    /// </summary>
    [Theory]
    [InlineData(
        """{"ErrorCode":1043,"Message":"Invalid credentials","Description":"The email and password do not match."}""",
        "1043", "The email and password do not match.")]
    [InlineData(
        """{"errorCode":1066,"message":"Token expired","description":"The access token has expired."}""",
        "1066", "The access token has expired.")]
    [InlineData(
        """{"error":"invalid_grant","error_description":"Refresh token is invalid."}""",
        "invalid_grant", "Refresh token is invalid.")]
    public void ExtractsEnvelopeAcrossWireShapes(string body, string code, string description)
    {
        var ex = LoginRadiusException.From(400, body);

        Assert.Equal(code, ex.Code);
        Assert.Equal(description, ex.Description);
    }

    [Theory]
    [InlineData(401, true, false, false, false)]
    [InlineData(403, false, true, false, false)]
    [InlineData(429, false, false, true, false)]
    [InlineData(500, false, false, false, true)]
    [InlineData(503, false, false, false, true)]
    [InlineData(599, false, false, false, true)]
    [InlineData(400, false, false, false, false)]
    [InlineData(200, false, false, false, false)]
    public void Predicates(int status, bool auth, bool forbidden, bool rateLimit, bool server)
    {
        var ex = LoginRadiusException.From(status, "{}");

        Assert.Equal(auth, ex.IsAuth());
        Assert.Equal(forbidden, ex.IsForbidden());
        Assert.Equal(rateLimit, ex.IsRateLimit());
        Assert.Equal(server, ex.IsServer());
    }

    [Fact]
    public void UnusableBodiesStillProduceATypedError()
    {
        // An HTML error page from a proxy, or an empty body, must not throw
        // while building the error — the status code is still actionable.
        foreach (var body in new[] { "", "not json", "<html>502</html>", "[]" })
        {
            var ex = LoginRadiusException.From(502, body);
            Assert.Equal(502, ex.StatusCode);
            Assert.True(ex.IsServer());
        }
    }

    [Fact]
    public void CarriesAHintForStatusesWithoutAnEnvelope()
    {
        // The hints come from manifest/sdk.yaml so all four SDKs say the same
        // thing for a bare 401 or 403.
        Assert.NotEmpty(LoginRadiusException.From(401, "").Description);
        Assert.NotEmpty(LoginRadiusException.From(403, "").Description);
    }

    [Fact]
    public void KeepsTheRawBodyForDiagnosis()
    {
        const string body = """{"ErrorCode":1043,"Message":"Invalid credentials"}""";
        Assert.Contains("1043", LoginRadiusException.From(400, body).RawBody, StringComparison.Ordinal);
    }
}
