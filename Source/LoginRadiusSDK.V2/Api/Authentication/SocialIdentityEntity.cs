using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
using LoginRadiusSDK.V2.Models.UserProfile;
using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Api
{
    public class SocialIdentityEntity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("socialidentity");

        public ApiResponse<LoginRadiusPostResponse> LinkAccount(string accessToken, string candidateToken)
        {
            Validate(new [] {accessToken, candidateToken});
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            var bodyparams = new BodyParameters {["candidateToken"] = candidateToken};
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT,
                _resoucePath.ToString(),null, bodyparams.ConvertToJson(),additionalHeaders);
        }

        public ApiResponse<LoginRadiusDeleteResponse> UnLinkAccount(string accessToken, UnlinkProfileModel unlinkModel)
        {
            Validate(new [] {accessToken});
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.DELETE,
                _resoucePath.ToString(), null, unlinkModel.ConvertToJson(),additionalHeaders);
        }

        public ApiResponse<LoginRadiusSocialUserProfile> GetProfile(string accessToken)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            return ConfigureAndExecute<LoginRadiusSocialUserProfile>(RequestType.Authentication, HttpMethod.GET, _resoucePath.ToString(), additionalQueryParams);
        }

        public ApiResponse<LoginRadiusUserIdentity> AuthReadallProfilesbyToken(string accessToken)
        {
            Validate(new [] { accessToken });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Authentication, HttpMethod.GET,"account", null,null,additionalHeaders);

        }
        public ApiResponse<LoginRadiusSocialUserProfile> AuthSocialIdentity(string accessToken)
        {
            Validate(new [] { accessToken });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<LoginRadiusSocialUserProfile>(RequestType.Authentication, HttpMethod.GET,
                "socialidentity", null,null,additionalHeaders);

        }

    }
}