
#if NETSTANDARD2_0 || NET45
using System;
using System.IdentityModel.Tokens.Jwt;

using System.Text;
using Microsoft.IdentityModel.Tokens;
# endif
namespace LoginRadiusSDK.V2.Common
{
#if NETSTANDARD2_0 || NET45

    public class JwtTokenValidation
	{

		public JwtResponse validateJwtToken(JwtValidationParameters jwt)

		{
			if (!string.IsNullOrEmpty(jwt.JwtToken) && !string.IsNullOrWhiteSpace(jwt.Secret))
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				try
				{
					var principal = tokenHandler.ValidateToken(jwt.JwtToken,
					new TokenValidationParameters
					{
						ValidateIssuerSigningKey = jwt.ValidateIssuerSigningKey,
						ValidateIssuer = jwt.ValidateIssuer,
						ValidateAudience = jwt.ValidateAudience,
						ValidIssuer = jwt.Issuer,
						ValidAudience = jwt.Audience,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Secret))
					}, out var rawValidatedToken);


					return (JwtResponse)rawValidatedToken;

				}
				catch (System.Exception e)
				{

                    return new JwtResponse { Error = e };
				}
			}

			return null;
		}

	}

	public class JwtResponse : JwtSecurityToken
	{

		public System.Exception Error { get; set; }

	}

#endif
}

