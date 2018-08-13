using System.Collections;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.Album;
using LoginRadiusSDK.V2.Models.Audio;
using LoginRadiusSDK.V2.Models.CheckIn;
using LoginRadiusSDK.V2.Models.Company;
using LoginRadiusSDK.V2.Models.Contact;
using LoginRadiusSDK.V2.Models.Event;
using LoginRadiusSDK.V2.Models.Following;
using LoginRadiusSDK.V2.Models.Group;
using LoginRadiusSDK.V2.Models.Like;
using LoginRadiusSDK.V2.Models.Mention;
using LoginRadiusSDK.V2.Models.Page;
using LoginRadiusSDK.V2.Models.Photo;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Api.Social
{
    public class SocialEntity : LoginRadiusResource
    {
        public ApiResponse<ListLoginRadiusAlbum> GetAlbumData(string accessToken, int nextCursor = 0)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["nextcursor"] = nextCursor.ToString()
            };
            return ConfigureAndExecute<ListLoginRadiusAlbum>(RequestType.Social, HttpMethod.GET, "album",
                additionalQueryParams);
        }

        public ApiResponse<List<LoginRadiusAudio>> GetAudioData(string accessToken)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            return ConfigureAndExecute<List<LoginRadiusAudio>>(RequestType.Social, HttpMethod.GET, "audio",
                additionalQueryParams);
        }

        public ApiResponse<List<LoginRadiusCheckIn>> GetCheckInData(string accessToken)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            return ConfigureAndExecute<List<LoginRadiusCheckIn>>(RequestType.Social, HttpMethod.GET, "checkin",
                additionalQueryParams);
        }

        public ApiResponse<List<LoginRadiusCompany>> GetCompanyData(string accessToken)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            return ConfigureAndExecute<List<LoginRadiusCompany>>(RequestType.Social, HttpMethod.GET, "company",
                additionalQueryParams);
        }

        public ApiResponse<LoginRadiusContact> GetContactData(string accessToken, int nextCursor = 0)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["nextcursor"] = nextCursor.ToString()
            };
            return ConfigureAndExecute<LoginRadiusContact>(RequestType.Social, HttpMethod.GET, "contact",
                additionalQueryParams);
        }

        public ApiResponse<ListLoginRadiusEvent> GetEventData(string accessToken, int nextCursor = 0)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["nextcursor"] = nextCursor.ToString()
            };
            return ConfigureAndExecute<ListLoginRadiusEvent>(RequestType.Social, HttpMethod.GET, "event",
                additionalQueryParams);
        }

        public ApiResponse<List<LoginRadiusFollowing>> GetFollowingData(string accessToken)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            return ConfigureAndExecute<List<LoginRadiusFollowing>>(RequestType.Social, HttpMethod.GET, "following",
                additionalQueryParams);
        }

        public ApiResponse<ListLoginRadiusGroup> GetGroupData(string accessToken, int nextCursor = 0)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["nextcursor"] = nextCursor.ToString()
            };

            return ConfigureAndExecute<ListLoginRadiusGroup>(RequestType.Social, HttpMethod.GET, "group",
                additionalQueryParams);
        }

        public ApiResponse<ListLoginRadiusLike> GetLikeData(string accessToken, int nextCursor = 0)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["nextcursor"] = nextCursor.ToString()
            };

            return ConfigureAndExecute<ListLoginRadiusLike>(RequestType.Social, HttpMethod.GET, "like",
                additionalQueryParams);
        }

        public ApiResponse<List<LoginRadiusMention>> GetMentionData(string accessToken)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            return ConfigureAndExecute<List<LoginRadiusMention>>(RequestType.Social, HttpMethod.GET, "mention",
                additionalQueryParams);
        }

        public ApiResponse<LoginRadiusPostResponse> PostMessage(string accessToken, string to, string subject,
            string message)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["to"] = to,
                ["subject"] = subject,
                ["message"] = message
            };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Social, HttpMethod.POST,
                "message", additionalQueryParams );
        }


        public ApiResponse<LoginRadiusPostResponse> GetMessage( string access_token, string to, string subject, string message)
        {
            Validate(new [] { access_token , to , subject, message });
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = access_token,
                ["to"] = to,
                ["subject"] = subject,
                ["message"] = message
            };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Social, HttpMethod.GET,
               "message/js", additionalQueryParams   );

        }
        public ApiResponse<LoginRadiusPage> GetPageData(string accessToken, string pageName)
        {
            Validate(new [] {accessToken, pageName});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken, ["pageName"] = pageName};
            return ConfigureAndExecute<LoginRadiusPage>(RequestType.Social, HttpMethod.GET, "page",
                additionalQueryParams);
        }

        public ApiResponse<List<LoginRadiusPhoto>> GetPhotoData(string accessToken, string albumId)
        {
            Validate(new [] {accessToken, albumId});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken, ["albumId"] = albumId};
            return ConfigureAndExecute<List<LoginRadiusPhoto>>(RequestType.Social, HttpMethod.GET, "photo",
                additionalQueryParams);
        }

        public ApiResponse<List<LoginRadiusStatus>> GetStatusData(string accessToken)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            return ConfigureAndExecute<List<LoginRadiusStatus>>(RequestType.Social, HttpMethod.GET, "status",
                additionalQueryParams);
        }

        public ApiResponse<LoginRadiusPostResponse> PostStatus(string accessToken, PostStatus model)
        {
            Validate(new [] { accessToken });
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["Imageurl"] = model.Imageurl,
                ["Url"] = model.Url,
                ["Title"] = model.Title,
                ["Status"] = model.Status,
                ["Caption"] = model.Caption,
                ["Description"] = model.Description
            };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Social, HttpMethod.POST,
                "status", additionalQueryParams);
        }



        public ApiResponse<List<LoginRadiusCurrentStatus>> GetPostStatus(string accessToken, PostStatus model)
        {
            Validate(new [] { accessToken });
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["Imageurl"] = model.Imageurl,
                ["Url"] = model.Url,
                ["Title"] = model.Title,
                ["Status"] = model.Status,
                ["Caption"] = model.Caption,
                ["Description"] = model.Description
            };
            return ConfigureAndExecute<List<LoginRadiusCurrentStatus>>(RequestType.Social, HttpMethod.GET,
                "status", additionalQueryParams);
        }


        public ApiResponse<List<LoginRadiusStatus>> FetchStatus(string accessToken)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken
            };
            return ConfigureAndExecute<List<LoginRadiusStatus>>(RequestType.Social, HttpMethod.GET,
                "status", additionalQueryParams);
        }

        public ApiResponse<LoginRadiusSocialUserProfile> GetUserProfile(string accessToken)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            return ConfigureAndExecute<LoginRadiusSocialUserProfile>(RequestType.Social, HttpMethod.GET,
                "userprofile", additionalQueryParams);
        }

        public ApiResponse<List<Models.Video.Data>> GetVideoData(string accessToken)
        {
            Validate(new [] {accessToken});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            return ConfigureAndExecute<List<Models.Video.Data>>(RequestType.Social, HttpMethod.GET, "video",
                additionalQueryParams);
        }

        public ApiResponse<LoginRadiusAccessToken> GetAccessToken(string token)
        {
            Validate(new [] {token});
            var additionalQueryParams = new QueryParameters {["token"] = token};
            return ConfigureAndExecute<LoginRadiusAccessToken>(RequestType.AccessToken, HttpMethod.GET, "access_token",
                additionalQueryParams);
        }
    }
}