using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Xunit;

namespace LoginRadius.Sdk.Tests;

/// <summary>
/// CROSS-LANGUAGE PARITY. Mirrors Go's <c>TestValidateJWT*</c> and Node's
/// <c>jwt.test.ts</c> case for case, so a weakness fixed in one language cannot
/// quietly persist in another.
/// </summary>
public class JwtValidationTests
{
    private const string Secret = "a-shared-secret-at-least-32-bytes-long!!";

    private static byte[] SecretBytes => Encoding.UTF8.GetBytes(Secret);

    private static Dictionary<string, object> LiveClaims() =>
        new()
        {
            ["sub"] = "uid-123",
            ["iss"] = "LoginRadius",
            ["aud"] = "my-app",
            ["exp"] = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds(),
            ["nbf"] = DateTimeOffset.UtcNow.AddMinutes(-1).ToUnixTimeSeconds(),
        };

    private static string B64Url(byte[] b) =>
        Convert.ToBase64String(b).Replace('+', '-').Replace('/', '_').TrimEnd('=');

    /// <summary>Assembles a token by hand — the way an attacker would.</summary>
    private static string Assemble(string alg, IDictionary<string, object> claims, Func<string, byte[]> sign)
    {
        var head = B64Url(Encoding.UTF8.GetBytes($"{{\"alg\":\"{alg}\",\"typ\":\"JWT\"}}"));
        var body = B64Url(Encoding.UTF8.GetBytes(
            System.Text.Json.JsonSerializer.Serialize(claims)));
        return $"{head}.{body}.{B64Url(sign($"{head}.{body}"))}";
    }

    private static string Hs(string alg, IDictionary<string, object> claims, byte[] key)
    {
        var hash = alg[2..];
        return Assemble(alg, claims, input =>
        {
            using HMAC mac = hash switch
            {
                "384" => new HMACSHA384(key),
                "512" => new HMACSHA512(key),
                _ => new HMACSHA256(key),
            };
            return mac.ComputeHash(Encoding.UTF8.GetBytes(input));
        });
    }

    private static string PublicPem(AsymmetricAlgorithm key) =>
        new string(PemEncoding.Write("PUBLIC KEY", key.ExportSubjectPublicKeyInfo()));

    [Fact]
    public void AcceptsAWellFormedToken()
    {
        var claims = JwtValidation.Validate(
            Hs("HS256", LiveClaims(), SecretBytes),
            new JwtValidationParams
            {
                Algorithm = JwtAlgorithm.HS256,
                Key = SecretBytes,
                Issuer = "LoginRadius",
                Audience = "my-app",
            });
        Assert.Equal("uid-123", claims["sub"].ToString());
    }

    /// <summary>
    /// THE attack this utility exists to stop. Against an RS256-configured app an attacker signs
    /// with HS256 using the PUBLIC key as the HMAC secret; a validator that reads the algorithm
    /// from the token header accepts it.
    /// </summary>
    [Fact]
    public void RejectsAlgorithmConfusion()
    {
        using var rsa = RSA.Create(2048);
        var pem = PublicPem(rsa);
        var forged = Hs("HS256", LiveClaims(), Encoding.UTF8.GetBytes(pem));

        var ex = Assert.Throws<JwtValidationException>(() =>
            JwtValidation.Validate(forged, new JwtValidationParams
            {
                Algorithm = JwtAlgorithm.RS256,
                Key = Encoding.UTF8.GetBytes(pem),
            }));
        Assert.Equal("algorithm_mismatch", ex.Code);
    }

    [Fact]
    public void RejectsAlgNone()
    {
        var unsigned = "eyJhbGciOiJub25lIiwidHlwIjoiSldUIn0."
                     + "eyJzdWIiOiJhdHRhY2tlciIsImV4cCI6NDEwMjQ0NDgwMH0.";
        foreach (var alg in new[] { JwtAlgorithm.HS256, JwtAlgorithm.RS256 })
        {
            Assert.Throws<JwtValidationException>(() =>
                JwtValidation.Validate(unsigned, new JwtValidationParams
                {
                    Algorithm = alg,
                    Key = SecretBytes,
                }));
        }
    }

    [Fact]
    public void RejectsAWrongSecret()
    {
        var token = Hs("HS256", LiveClaims(), Encoding.UTF8.GetBytes("a-different-secret-entirely-32-bytes"));
        var ex = Assert.Throws<JwtValidationException>(() =>
            JwtValidation.Validate(token, new JwtValidationParams
            {
                Algorithm = JwtAlgorithm.HS256,
                Key = SecretBytes,
            }));
        Assert.Equal("signature", ex.Code);
    }

    [Fact]
    public void RejectsExpiredAndNotYetValid()
    {
        var expiredClaims = LiveClaims();
        expiredClaims["exp"] = DateTimeOffset.UtcNow.AddMinutes(-10).ToUnixTimeSeconds();
        // nbf must stay BEFORE exp or the token is nonsensical rather than merely
        // expired, and the handler reports an invalid lifetime instead.
        expiredClaims["nbf"] = DateTimeOffset.UtcNow.AddMinutes(-20).ToUnixTimeSeconds();
        Assert.Equal("expired", Assert.Throws<JwtValidationException>(() =>
            JwtValidation.Validate(Hs("HS256", expiredClaims, SecretBytes), new JwtValidationParams
            {
                Algorithm = JwtAlgorithm.HS256,
                Key = SecretBytes,
            })).Code);

        var earlyClaims = LiveClaims();
        earlyClaims["nbf"] = DateTimeOffset.UtcNow.AddMinutes(10).ToUnixTimeSeconds();
        Assert.Equal("not_yet_valid", Assert.Throws<JwtValidationException>(() =>
            JwtValidation.Validate(Hs("HS256", earlyClaims, SecretBytes), new JwtValidationParams
            {
                Algorithm = JwtAlgorithm.HS256,
                Key = SecretBytes,
            })).Code);
    }

    /// <summary>A token with no exp never stops being valid.</summary>
    [Fact]
    public void RequiresAnExpiryClaim()
    {
        var token = Hs("HS256", new Dictionary<string, object> { ["sub"] = "uid-123" }, SecretBytes);
        Assert.Throws<JwtValidationException>(() =>
            JwtValidation.Validate(token, new JwtValidationParams
            {
                Algorithm = JwtAlgorithm.HS256,
                Key = SecretBytes,
            }));
    }

    [Fact]
    public void ChecksIssuerAndAudienceWhenSupplied()
    {
        var token = Hs("HS256", LiveClaims(), SecretBytes);
        Assert.Equal("issuer", Assert.Throws<JwtValidationException>(() =>
            JwtValidation.Validate(token, new JwtValidationParams
            {
                Algorithm = JwtAlgorithm.HS256, Key = SecretBytes, Issuer = "SomeoneElse",
            })).Code);
        Assert.Equal("audience", Assert.Throws<JwtValidationException>(() =>
            JwtValidation.Validate(token, new JwtValidationParams
            {
                Algorithm = JwtAlgorithm.HS256, Key = SecretBytes, Audience = "another-app",
            })).Code);
    }

    /// <summary>Omitting them must not silently disable the checks that are NOT optional.</summary>
    [Fact]
    public void IssuerAndAudienceAreOptional()
    {
        var claims = JwtValidation.Validate(Hs("HS256", LiveClaims(), SecretBytes),
            new JwtValidationParams { Algorithm = JwtAlgorithm.HS256, Key = SecretBytes });
        Assert.Equal("uid-123", claims["sub"].ToString());
    }

    [Fact]
    public void VerifiesRsaAndEcdsa()
    {
        using var rsa = RSA.Create(2048);
        var rsaToken = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
            issuer: "LoginRadius", audience: "my-app",
            claims: new[] { new System.Security.Claims.Claim("sub", "uid-123") },
            notBefore: DateTime.UtcNow.AddMinutes(-1), expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)));
        Assert.Equal("uid-123", JwtValidation.Validate(rsaToken, new JwtValidationParams
        {
            Algorithm = JwtAlgorithm.RS256,
            Key = Encoding.UTF8.GetBytes(PublicPem(rsa)),
        })["sub"].ToString());

        using var ec = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var ecToken = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
            issuer: "LoginRadius", audience: "my-app",
            claims: new[] { new System.Security.Claims.Claim("sub", "uid-123") },
            notBefore: DateTime.UtcNow.AddMinutes(-1), expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new SigningCredentials(new ECDsaSecurityKey(ec), SecurityAlgorithms.EcdsaSha256)));
        Assert.Equal("uid-123", JwtValidation.Validate(ecToken, new JwtValidationParams
        {
            Algorithm = JwtAlgorithm.ES256,
            Key = Encoding.UTF8.GetBytes(PublicPem(ec)),
        })["sub"].ToString());
    }

    /// <summary>Handing over a PRIVATE key is a serious mistake; it is named, not swallowed.</summary>
    [Fact]
    public void RefusesAPrivateKeyAsTheVerificationKey()
    {
        using var rsa = RSA.Create(2048);
        var priv = new string(PemEncoding.Write("PRIVATE KEY", rsa.ExportPkcs8PrivateKey()));
        var token = Hs("RS256", LiveClaims(), SecretBytes);
        var ex = Assert.Throws<JwtValidationException>(() =>
            JwtValidation.Validate(token, new JwtValidationParams
            {
                Algorithm = JwtAlgorithm.RS256,
                Key = Encoding.UTF8.GetBytes(priv),
            }));
        Assert.Equal("invalid_key", ex.Code);
    }

    [Fact]
    public void RejectsAnEmptyKeyAndAMalformedToken()
    {
        Assert.Equal("invalid_key", Assert.Throws<JwtValidationException>(() =>
            JwtValidation.Validate("a.b.c", new JwtValidationParams
            {
                Algorithm = JwtAlgorithm.HS256, Key = Array.Empty<byte>(),
            })).Code);
        Assert.Equal("malformed", Assert.Throws<JwtValidationException>(() =>
            JwtValidation.Validate("not-a-jwt", new JwtValidationParams
            {
                Algorithm = JwtAlgorithm.HS256, Key = SecretBytes,
            })).Code);
    }
}
