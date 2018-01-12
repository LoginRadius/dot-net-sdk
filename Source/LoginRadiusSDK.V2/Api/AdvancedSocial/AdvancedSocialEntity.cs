using System.Collections;
using System.Collections.Generic;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
using LoginRadiusSDK.V2.Models.CustomerManagement.Identity;

namespace LoginRadiusSDK.V2.Api.AdvancedSocial
{
    public class AdvancedSocialEntity : LoginRadiusResource
    {
        public ApiResponse<LoginRadiusAccessToken> GetFacebookAccessToken(string facebookToken)
        {
            Validate(new [] {facebookToken});
            var additionalQueryParams = new QueryParameters {["fb_access_token"] = facebookToken};
            return ConfigureAndExecute<LoginRadiusAccessToken>(RequestType.AdvancedSocial,
                HttpMethod.Get, "access_token/facebook", additionalQueryParams);
        }

        public ApiResponse<LoginRadiusAccessToken> GetTwitterAccessToken(string twitterToken, string twitterTokenSecret)
        {
            Validate(new [] {twitterToken, twitterTokenSecret});
            var additionalQueryParams =
                new QueryParameters {["tw_access_token"] = twitterToken, ["tw_token_secret"] = twitterTokenSecret};
            return ConfigureAndExecute<LoginRadiusAccessToken>(RequestType.AdvancedSocial,
                HttpMethod.Get, "access_token/twitter", additionalQueryParams);
        }

        public ApiResponse<LoginRadiusSocialUserProfile> GetRefreshUserProfile(string accessToken)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            return ConfigureAndExecute<LoginRadiusSocialUserProfile>(RequestType.AdvancedSocial, HttpMethod.Get,
                "userprofile/refresh", additionalQueryParams);
        }

        public ApiResponse<AccessTokenResponse> GetRefreshToken(string accessToken)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            return ConfigureAndExecute<AccessTokenResponse>(RequestType.AdvancedSocial, HttpMethod.Get,
                "access_token/refresh", additionalQueryParams);
        }

        public ApiResponse<ShortUrlResponse> GetShortenUri(string uri)
        {
            Validate(new [] {uri});
            var additionalQueryParams = new QueryParameters {["url"] = uri};
            return ConfigureAndExecute<ShortUrlResponse>(RequestType.AdvancedSharing, HttpMethod.Get, null,
                additionalQueryParams);
        }

        public ApiResponse<LoginRadiusStatusStats> GetTrackableStatus(string postId)
        {
            Validate(new [] {postId});
            var additionalQueryParams = new QueryParameters {["postid"] = postId};
            return ConfigureAndExecute<LoginRadiusStatusStats>(RequestType.AdvancedSocial, HttpMethod.Get,
                "status/trackable", additionalQueryParams);
        }

        //public ApiResponse<TrackableStatusPostResponse> GetUpdateTrackableStatus(string accessToken,
        //    TrackableStatusUpdateModel trackableStatusUpdate)
        //{
        //    Validate(new [] {accessToken, trackableStatusUpdate});
        //    var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
        //    //.AddRange(additionalQueryParams, trackableStatusUpdate.ConvertToJson());
        //    return ConfigureAndExecute<TrackableStatusPostResponse>(RequestType.AdvancedSocial, HttpMethod.Post,
        //        "status/trackable", additionalQueryParams, trackableStatusUpdate.ConvertToJson());
        //}

        public ApiResponse<TrackableStatusPostResponse> PostUpdateTrackableStatus(string accessToken,
            TrackableStatusUpdateModel trackableStatusUpdate)
        {
            Validate(new List<object> {accessToken, trackableStatusUpdate});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            return ConfigureAndExecute<TrackableStatusPostResponse>(RequestType.AdvancedSocial, HttpMethod.Post,
                "status/trackable", additionalQueryParams, trackableStatusUpdate.ConvertToJson());
        }
    }
}