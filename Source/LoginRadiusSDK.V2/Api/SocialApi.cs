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

namespace LoginRadiusSDK.V2.Api
{
    public class SocialApi : LoginRadiusResource
    {
        /// <summary>
        /// This API is used to post messages to the user’s contacts.
        /// </summary>
        /// <param name="accessToken">Session which is linked to a social profile.</param>
        /// <param name="to">Id of target of message.</param>
        /// <param name="subject">Subject of message.</param>
        /// <param name="message">The message.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show message was sent.</returns>
        public ApiResponse<LoginRadiusPostResponse> PostMessage(string accessToken, string to, string subject,
            string message)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["to"] = to,
                ["subject"] = subject,
                ["message"] = message
            };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Social, HttpMethod.POST,
                "message", additionalQueryParams);
        }

        /// <summary>
        /// This API is used to post statuses.
        /// </summary>
        /// <param name="accessToken">Session which is linked to a social profile.</param>
        /// <param name="model">Contains data for posting a status.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show status was posted.</returns>
        public ApiResponse<LoginRadiusPostResponse> PostStatus(string accessToken, PostStatus model)
        {
            Validate(new[] { accessToken });
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

        /// <summary>
        /// This API is used to get a social access token.
        /// </summary>
        /// <param name="token">Session which is linked to a social profile.</param>
        /// <returns>LoginRadiusAccessToken: Access token data.</returns>
        public ApiResponse<LoginRadiusAccessToken> GetAccessToken(string token)
        {
            Validate(new[] { token });
            var additionalQueryParams = new QueryParameters { ["token"] = token };
            return ConfigureAndExecute<LoginRadiusAccessToken>(RequestType.AccessToken, HttpMethod.GET, "access_token",
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to validate an access token.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <returns>LoginRadiusAccessToken: Access token data.</returns>
        public ApiResponse<LoginRadiusAccessToken> TokenValidate(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken };
            return ConfigureAndExecute<LoginRadiusAccessToken>(RequestType.Sso, HttpMethod.GET, "access_token/validate",
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to invalidate an access token.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show token is invalidated.</returns>
        public ApiResponse<LoginRadiusPostResponse> TokenInvalidate(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Sso, HttpMethod.GET, "access_token/invalidate",
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to get album data.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <param name="nextCursor">Targets the next point in the album list.</param>
        /// <returns>ListLoginRadiusAlbum: Object containing album data.</returns>
        public ApiResponse<ListLoginRadiusAlbum> GetAlbumData(string accessToken, int nextCursor = 0)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["nextcursor"] = nextCursor.ToString()
            };
            return ConfigureAndExecute<ListLoginRadiusAlbum>(RequestType.Social, HttpMethod.GET, "album",
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to get audio data.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <returns>ListLoginRadiusAlbum: Object containing audio data.</returns>
        public ApiResponse<List<LoginRadiusAudio>> GetAudioData(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken };
            return ConfigureAndExecute<List<LoginRadiusAudio>>(RequestType.Social, HttpMethod.GET, "audio",
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to get check in data.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <returns>ListLoginRadiusAlbum: Object containing check in data.</returns>
        public ApiResponse<List<LoginRadiusCheckIn>> GetCheckInData(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken };
            return ConfigureAndExecute<List<LoginRadiusCheckIn>>(RequestType.Social, HttpMethod.GET, "checkin",
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to get company data.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <returns>ListLoginRadiusAlbum: Object containing company data.</returns>
        public ApiResponse<List<LoginRadiusCompany>> GetCompanyData(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken };
            return ConfigureAndExecute<List<LoginRadiusCompany>>(RequestType.Social, HttpMethod.GET, "company",
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to get contact data.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <param name="nextCursor">Pointer to next array element.</param>
        /// <returns>ListLoginRadiusAlbum: Object containing contact data.</returns>
        public ApiResponse<LoginRadiusContact> GetContactData(string accessToken, int nextCursor = 0)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["nextcursor"] = nextCursor.ToString()
            };
            return ConfigureAndExecute<LoginRadiusContact>(RequestType.Social, HttpMethod.GET, "contact",
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to get event data.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <param name="nextCursor">Pointer to next array element.</param>
        /// <returns>ListLoginRadiusAlbum: Object containing event data.</returns>
        public ApiResponse<ListLoginRadiusEvent> GetEventData(string accessToken, int nextCursor = 0)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["nextcursor"] = nextCursor.ToString()
            };
            return ConfigureAndExecute<ListLoginRadiusEvent>(RequestType.Social, HttpMethod.GET, "event",
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to get following data.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <returns>ListLoginRadiusAlbum: Object containing following data.</returns>
        public ApiResponse<List<LoginRadiusFollowing>> GetFollowingData(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken };
            return ConfigureAndExecute<List<LoginRadiusFollowing>>(RequestType.Social, HttpMethod.GET, "following",
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to get group data.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <param name="nextCursor">Pointer to next array element.</param>
        /// <returns>ListLoginRadiusAlbum: Object containing group data.</returns>
        public ApiResponse<ListLoginRadiusGroup> GetGroupData(string accessToken, int nextCursor = 0)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["nextcursor"] = nextCursor.ToString()
            };

            return ConfigureAndExecute<ListLoginRadiusGroup>(RequestType.Social, HttpMethod.GET, "group",
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to get like data.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <param name="nextCursor">Pointer to next array element.</param>
        /// <returns>ListLoginRadiusAlbum: Object containing like data.</returns>
        public ApiResponse<ListLoginRadiusLike> GetLikeData(string accessToken, int nextCursor = 0)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["nextcursor"] = nextCursor.ToString()
            };

            return ConfigureAndExecute<ListLoginRadiusLike>(RequestType.Social, HttpMethod.GET, "like",
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to get mention data.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <returns>ListLoginRadiusAlbum: Object containing mention data.</returns>
        public ApiResponse<List<LoginRadiusMention>> GetMentionData(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken };
            return ConfigureAndExecute<List<LoginRadiusMention>>(RequestType.Social, HttpMethod.GET, "mention",
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to post messages to the user’s contacts.
        /// </summary>
        /// <param name="accessToken">Session which is linked to a social profile.</param>
        /// <param name="to">Id of target of message.</param>
        /// <param name="subject">Subject of message.</param>
        /// <param name="message">The message.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show message was sent.</returns>
        public ApiResponse<LoginRadiusPostResponse> GetMessage(string accessToken, string to, string subject, string message)
        {
            Validate(new[] { accessToken, to, subject, message });
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["to"] = to,
                ["subject"] = subject,
                ["message"] = message
            };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Social, HttpMethod.GET,
               "message/js", additionalQueryParams);
        }

        /// <summary>
        /// This API is used to get page data.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <param name="pageName">Name of page.</param>
        /// <returns>ListLoginRadiusAlbum: Object containing page data.</returns>
        public ApiResponse<LoginRadiusPage> GetPageData(string accessToken, string pageName)
        {
            Validate(new[] { accessToken, pageName });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken, ["pageName"] = pageName };
            return ConfigureAndExecute<LoginRadiusPage>(RequestType.Social, HttpMethod.GET, "page",
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to get photo data.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <param name="albumId">Name of photo album.</param>
        /// <returns>ListLoginRadiusAlbum: Object containing photo data.</returns>
        public ApiResponse<List<LoginRadiusPhoto>> GetPhotoData(string accessToken, string albumId)
        {
            Validate(new[] { accessToken, albumId });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken, ["albumId"] = albumId };
            return ConfigureAndExecute<List<LoginRadiusPhoto>>(RequestType.Social, HttpMethod.GET, "photo",
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to get post data.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <returns>ListLoginRadiusAlbum: Object containing post data.</returns>
        public ApiResponse<List<LoginRadiusStatus>> GetPostData(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken };
            return ConfigureAndExecute<List<LoginRadiusStatus>>(RequestType.Social, HttpMethod.GET, "post",
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to get status data.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <returns>ListLoginRadiusAlbum: Object containing status data.</returns>
        public ApiResponse<List<LoginRadiusStatus>> GetStatusData(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken };
            return ConfigureAndExecute<List<LoginRadiusStatus>>(RequestType.Social, HttpMethod.GET, "status",
                additionalQueryParams);
        }


        /// <summary>
        /// This API is used to post statuses.
        /// </summary>
        /// <param name="accessToken">Session which is linked to a social profile.</param>
        /// <param name="model">Contains data for posting a status.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show status was posted.</returns>
        public ApiResponse<List<LoginRadiusCurrentStatus>> GetPostStatus(string accessToken, PostStatus model)
        {
            Validate(new[] { accessToken });
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

        /// <summary>
        /// This API is used to get user profile data.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <returns>ListLoginRadiusAlbum: Object containing user profile data.</returns>
        public ApiResponse<LoginRadiusSocialUserProfile> GetUserProfile(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken };
            return ConfigureAndExecute<LoginRadiusSocialUserProfile>(RequestType.Social, HttpMethod.GET,
                "userprofile", additionalQueryParams);
        }

        /// <summary>
        /// This API is used to get video data.
        /// </summary>
        /// <param name="accessToken">Session token.</param>
        /// <returns>ListLoginRadiusAlbum: Object containing video data.</returns>
        public ApiResponse<List<Models.Video.Data>> GetVideoData(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken };
            return ConfigureAndExecute<List<Models.Video.Data>>(RequestType.Social, HttpMethod.GET, "video",
                additionalQueryParams);
        }
    }
}