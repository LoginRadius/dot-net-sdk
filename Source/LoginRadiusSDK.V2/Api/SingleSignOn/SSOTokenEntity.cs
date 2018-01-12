using System.Collections;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class SsoTokenEntity:LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("access_token/Validate");

        public ApiResponse<LoginRadiusAccessToken> TokenValidate(string accessToken)
        {
            Validate(new [] { accessToken });
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken };   
            return ConfigureAndExecute<LoginRadiusAccessToken>(RequestType.Sso, HttpMethod.Get, _resoucePath.ToString(),
                additionalQueryParams);
        }
        public ApiResponse<LoginRadiusPostResponse> TokenInvalidate(string accessToken)
        {
            Validate(new [] { accessToken });
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Sso, HttpMethod.Get, _resoucePath.ToString(),
                additionalQueryParams);
        }
    }
}
