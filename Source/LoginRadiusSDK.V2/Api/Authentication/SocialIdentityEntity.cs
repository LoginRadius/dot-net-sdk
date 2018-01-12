using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
using LoginRadiusSDK.V2.Models.UserProfile;

namespace LoginRadiusSDK.V2.Api
{
    public class SocialIdentityEntity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("socialidentity");

        public ApiResponse<LoginRadiusPostResponse> LinkAccount(string accessToken, string candidateToken)
        {
            Validate(new [] {accessToken, candidateToken});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            var bodyparams = new BodyParameters {["candidateToken"] = candidateToken};
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Put,
                _resoucePath.ToString(),
                additionalQueryParams, bodyparams.ConvertToJson());
        }

        public ApiResponse<LoginRadiusDeleteResponse> UnLinkAccount(string accessToken, UnlinkProfileModel unlinkModel)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.Delete,
                _resoucePath.ToString(),
                additionalQueryParams, unlinkModel.ConvertToJson());
        }

        public ApiResponse<LoginRadiusSocialUserProfile> GetProfile(string accessToken)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            return ConfigureAndExecute<LoginRadiusSocialUserProfile>(RequestType.Authentication, HttpMethod.Get, _resoucePath.ToString(), additionalQueryParams);
        }

        public ApiResponse<LoginRadiusSocialUserProfile> AuthReadallProfilesbyToken(string access_token)
        {
            Validate(new [] { access_token });
            var additionalQueryParams = new QueryParameters { ["access_token"] = access_token };
            return ConfigureAndExecute<LoginRadiusSocialUserProfile>(RequestType.Authentication, HttpMethod.Get,
                "account", additionalQueryParams);

        }
        public ApiResponse<LoginRadiusSocialUserProfile> AuthSocialIdentity(string access_token)
        {
            Validate(new [] { access_token });
            var additionalQueryParams = new QueryParameters { ["access_token"] = access_token };
            return ConfigureAndExecute<LoginRadiusSocialUserProfile>(RequestType.Authentication, HttpMethod.Get,
                "socialidentity", additionalQueryParams);

        }

    }
}