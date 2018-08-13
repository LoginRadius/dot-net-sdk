using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;
using System.Collections.Generic;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;


namespace LoginRadiusSDK.V2.Api
{
    public class UserNameEntity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("username");

        public ApiResponse<LoginRadiusPostResponse> UpSertUserName(string accessToken, string userName)
        {
            Validate(new [] {accessToken, userName});
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            var bodyParams = new BodyParameters {["username"] = userName}.ConvertToJson();
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT,
                _resoucePath.ToString(),null, bodyParams,additionalHeaders);
        }

        public ApiResponse<LogiinRadiusExistsResponse> CheckUserNameAvailablity(string userName)
        {
            Validate(new [] {userName});
            var additionalQueryParams = new QueryParameters {["username"] = userName};
            return ConfigureAndExecute<LogiinRadiusExistsResponse>(RequestType.Authentication, HttpMethod.GET,
                _resoucePath.ToString(),
                additionalQueryParams);
        }
    }
}