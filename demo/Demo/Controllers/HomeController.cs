using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Mvc;
using LoginRadiusSDK.API;
using LoginRadiusSDK.Entity;
using LoginRadiusSDK.Exception;
using LoginRadiusSDK.Models;
using LoginRadiusSDK.Models.Album;
using LoginRadiusSDK.Models.Audio;
using LoginRadiusSDK.Models.CheckIn;
using LoginRadiusSDK.Models.Company;
using LoginRadiusSDK.Models.Contact;
using LoginRadiusSDK.Models.Event;
using LoginRadiusSDK.Models.Following;
using LoginRadiusSDK.Models.Group;
using LoginRadiusSDK.Models.Like;
using LoginRadiusSDK.Models.Mention;
using LoginRadiusSDK.Models.Object;
using LoginRadiusSDK.Models.Photo;
using LoginRadiusSDK.Models.Post;
using LoginRadiusSDK.Models.Status;
using LoginRadiusSDK.Models.UserProfile;
using LoginRadiusSDK.Models.Video;
using LoginRadiusSDK.Utility.Serialization;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // To Set LoginRadius App Credentials or this could be set in config file.
            AppCredentials.AppSettingInitialization("LoginRadius App Key", "LoginRadius Site Secret", "LoginRadius App Name");
            // To set Http Server Proxy Configuration
            // AppCredentials.AppSettingInitialization("LoginRadius App Key", "LoginRadius Site Secret", "LoginRadius App Name", "Absolute HTTP Proxy URI", "Http Proxy Credential(Username:Password)");
            return View();
        }

        [HttpGet]
        public ActionResult Welcome(FormCollection form)
        {
            if (Session["userprofile"] != null)
            {
                var userProfileData = (RaasUserprofile)Session["userprofile"];
                return View(userProfileData);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Welcome()
        {
            //Social Login Process.
            if (HttpContext.Request.Params["token"] != null)
            {
                var lrCallback = new LoginRadiusCallback();
                if (lrCallback.IsCallback)
                {
                    var accesstoken = lrCallback.GetAccessToken();
                    Session["access_token"] = accesstoken.access_token;
                    //create client with the help of access token as parameter
                    var client = new LoginRadiusClient(accesstoken);
                    //create object to execute user profile api to get user profile data.
                    var userprofile = new UserProfileApi();
                    //To get ultimate user profile data with the help of user profile api object as parameter.
                    // and pass "LoginRadiusUltimateUserProfile" model as interface to map user profile data.
                    var userProfileData = client.GetResponse<RaasUserprofile>(userprofile);
                    if (userProfileData != null)
                    {
                        Session["userprofile"] = userProfileData;
                        Session["Uid"] = userProfileData.Uid;
                        return View(userProfileData);
                    }
                    return Redirect("/Home/Index");
                }
            }

            //Traditional Login Process.
            else if (HttpContext.Request.Params["Access_token"] != null)
            {
                var userProfile = UserProfiledata(HttpContext.Request.Params["Access_token"]);
                return View(userProfile);
            }

            //Set Password and Traditional profile registration process for social user accounts.
            else if (HttpContext.Request.Params["password"] != null && HttpContext.Request.Params["confirmpassword"] != null && HttpContext.Request.Params["emailid"] != null)
            {
                var _object = new LoginRadiusAccountEntity();
                var userid = (string)System.Web.HttpContext.Current.Session["Uid"];
                _object.UserCreateRegistrationProfile(userid, HttpContext.Request.Params["emailid"], HttpContext.Request.Params["password"]);
                return Content("<script language='javascript' type='text/javascript'>alert('Password has been set !'); window.location.href =window.location.href;</script>");
            }

            //Process or Function to update password of user account.
            else if (HttpContext.Request.Params["oldpassword"] != null && HttpContext.Request.Params["newpassword"] != null && HttpContext.Request.Params["confirmnewpassword"] != null)
            {
                try
                {
                    var _object = new LoginRadiusUserProfileEntity();
                    _object.ChangePassword(HttpContext.Request.Params["raasid"], HttpContext.Request.Params["oldpassword"], HttpContext.Request.Params["newpassword"]);
                    return Content("<script language='javascript' type='text/javascript'>alert('Password has been Changed successfully !'); window.location.href =window.location.href;</script>");
                }
                //To catch loginRadius API exception.
                catch (LoginRadiusException)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Password can not be updated, please check your old password!' ); window.location.href = window.location.href; </script>");
                }
            }

            //Process or Function to link  a social account.
            else if (HttpContext.Request.Params["accounttoken"] != null)
            {
                var accessToken = HttpContext.Request.Params["accounttoken"];
                var client = new LoginRadiusClient(accessToken);
                var userprofile = new UserProfileApi();
                var userProfileData = client.GetResponse<RaasUserprofile>(userprofile);
                var _object = new LoginRadiusAccountEntity();
                var userid = (string)System.Web.HttpContext.Current.Session["Uid"];
                try
                {
                    var status = _object.LinkAccount(userid, userProfileData.Provider, userProfileData.ID);
                    return Content(status.isPosted ? "<script language='javascript' type='text/javascript'>alert( 'Social Account has been linked !' ); window.location =window.location.href; </script>" : "<script language='javascript' type='text/javascript'>alert( 'Social Account can not be linked !' ); window.location =window.location.href; </script>");
                }
                catch (LoginRadiusException)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert( 'Social Account cannot be linked! it has been linked with another account' ); window.location =window.location.href; </script>");
                }
            }

            //Process or Function to unlink a social account.
            else if (HttpContext.Request.Params["accountunlinkname"] != null && HttpContext.Request.Params["accountunlinkid"] != null)
            {
                try
                {
                    var _object = new LoginRadiusAccountEntity();
                    var userid = (string)System.Web.HttpContext.Current.Session["Uid"];
                    var status = _object.UnlinkAccount(userid, HttpContext.Request.Params["accountunlinkname"], HttpContext.Request.Params["accountunlinkid"]);
                    return Content(status.isPosted ? "<script language='javascript' type='text/javascript'>alert( 'Social Account has been unlinked !' ); window.location.href =window.location.href; </script>" : "<script language='javascript' type='text/javascript'>alert( 'Social Account can not be unlinked !' ); window.location.href = window.location.href; </script>");
                }
                catch (LoginRadiusException exception)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert( '" + exception.Message + "' ); window.location.href ='/Home/Welcome'; </script>");
                }

            }
            return Redirect("/Home/Index");
        }

        //Logout process to destroy the session.
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        //Function to get Customer's Contact data of social account.
        [HttpPost]
        public ActionResult ContactData()
        {
            try
            {
                var token = HttpContext.Request.Params["access_token"];
                var client = new LoginRadiusClient(token);
                var userContacts = new ContactApi();
                var userContactsData = client.GetResponse<LoginRadiusContact>(userContacts);
                return Json(userContactsData);
            }
            catch (LoginRadiusException exception)
            {
                var error = exception.Response.Deserialize<ApiExceptionResponse>();
                return Json(error);
            }
        }

        //Function to get Customer's like data of social account.
        [HttpPost]
        public ActionResult LikeData()
        {
            try
            {
                var token = HttpContext.Request.Params["access_token"];
                var client = new LoginRadiusClient(token);
                var userLikes = new LikeApi();
                var userLikeData = client.GetResponse<List<LoginRadiusLike>>(userLikes);
                return Json(userLikeData);
            }
            catch (LoginRadiusException exception)
            {
                var error = exception.Response.Deserialize<ApiExceptionResponse>();
                return Json(error);
            }
        }

        //Function to get Customer's extended profile data of social account.
        [HttpPost]
        public ActionResult ExtendedProfile()
        {
            var userProfileData = (RaasUserprofile)Session["userprofile"];
            return Json(userProfileData);
        }

        //Function to update the user profile.
        [HttpPost]
        public ActionResult UpdateProfile(User user)
        {
            try
            {
                var userProfileData = (RaasUserprofile)Session["userprofile"];
                var _object = new LoginRadiusUserProfileEntity();
                var response = _object.UpdateUser(userProfileData.ID, user);
                UserProfiledata(System.Web.HttpContext.Current.Session["access_token"].ToString());
                return Content(response.isPosted ? "<script language='javascript' type='text/javascript'>alert( 'Profile has been updated !!' ); window.location.href ='/Home/Welcome'; </script>" : "<script language='javascript' type='text/javascript'>alert( 'Profile cannot be updated ,Please check parameters again !' ); window.location.href = '/Home/Welcome'; </script>");
            }
            catch (LoginRadiusException exception)
            {
                return Content("<script language='javascript' type='text/javascript'>alert( '" + exception.Response + "' ); window.location.href ='/Home/Welcome'; </script>");
            }
        }

        //Function to get Customer's album data of social account.
        [HttpPost]
        public ActionResult AlbumData()
        {
            try
            {
                var token = HttpContext.Request.Params["access_token"];
                var client = new LoginRadiusClient(token);
                var userAlbums = new AlbumApi();
                var userAlbumData = client.GetResponse<List<LoginRadiusAlbum>>(userAlbums);
                return Json(userAlbumData);
            }
            catch (LoginRadiusException exception)
            {
                var error = exception.Response.Deserialize<ApiExceptionResponse>();
                return Json(error);
            }
        }

        //Function to get Users's checkin data of social account.
        [HttpPost]
        public ActionResult CheckInData()
        {
            try
            {
                var token = HttpContext.Request.Params["access_token"];
                var client = new LoginRadiusClient(token);
                var userCheckin = new CheckInApi();
                var usercheckinData = client.GetResponse<List<LoginRadiusCheckIn>>(userCheckin);
                return Json(usercheckinData);
            }
            catch (LoginRadiusException exception)
            {
                var error = exception.Response.Deserialize<ApiExceptionResponse>();
                return Json(error);
            }

        }

        //Function to get Customer's audio data of social account.
        [HttpPost]
        public ActionResult AudioData()
        {
            try
            {
                var token = HttpContext.Request.Params["access_token"];
                var client = new LoginRadiusClient(token);
                var userAudio = new AudioApi();
                var userAudioData = client.GetResponse<List<LoginRadiusAudio>>(userAudio);
                return Json(userAudioData);
            }
            catch (LoginRadiusException exception)
            {
                var error = exception.Response.Deserialize<ApiExceptionResponse>();
                return Json(error);
            }

        }

        //Function to get Customer's Mentions data of social account.
        [HttpPost]
        public ActionResult MentionsData()
        {
            try
            {
                var token = HttpContext.Request.Params["access_token"];
                var client = new LoginRadiusClient(token);
                var userMention = new MentionApi();
                var userMentionData = client.GetResponse<List<LoginRadiusMention>>(userMention);
                return Json(userMentionData);
            }
            catch (LoginRadiusException exception)
            {
                var error = exception.Response.Deserialize<ApiExceptionResponse>();
                return Json(error);
            }
        }

        //Function to get Customer's following data of social account.
        [HttpPost]
        public ActionResult FollowingData()
        {
            try
            {
                var token = HttpContext.Request.Params["access_token"];
                var client = new LoginRadiusClient(token);
                var userFollowing = new FollowingApi();
                var userFollowingData = client.GetResponse<List<LoginRadiusFollowing>>(userFollowing);
                return Json(userFollowingData);
            }
            catch (LoginRadiusException exception)
            {
                var error = exception.Response.Deserialize<ApiExceptionResponse>();
                return Json(error);
            }
        }
        //Function to get Customer's event data of social account.
        [HttpPost]
        public ActionResult EventData()
        {
            try
            {
                var token = HttpContext.Request.Params["access_token"];
                var client = new LoginRadiusClient(token);
                var userEvent = new EventApi();
                var userEventData = client.GetResponse<List<LoginRadiusEvent>>(userEvent);
                return Json(userEventData);
            }
            catch (LoginRadiusException exception)
            {
                var error = exception.Response.Deserialize<ApiExceptionResponse>();
                return Json(error);
            }
        }
        //Function to get Customer's timeline posts data of social account.
        [HttpPost]
        public ActionResult PostsData()
        {
            try
            {
                var token = HttpContext.Request.Params["access_token"];
                var client = new LoginRadiusClient(token);
                var userPosts = new PostApi();
                var userPostsData = client.GetResponse<List<LoginRadiusPost>>(userPosts);
                return Json(userPostsData);
            }
            catch (LoginRadiusException exception)
            {
                var error = exception.Response.Deserialize<ApiExceptionResponse>();
                return Json(error);
            }
        }
        //Function to get Customer's associated companies data of social account.
        [HttpPost]
        public ActionResult CompaniesData()
        {
            try
            {
                var token = HttpContext.Request.Params["access_token"];
                var client = new LoginRadiusClient(token);
                var userCompanies = new CompanyApi();
                var userCompaniesData = client.GetResponse<List<LoginRadiusCompany>>(userCompanies);
                return Json(userCompaniesData);
            }
            catch (LoginRadiusException exception)
            {
                var error = exception.Response.Deserialize<ApiExceptionResponse>();
                return Json(error);
            }

        }

        //Function to get Customer's group data of social account.
        [HttpPost]
        public ActionResult GroupsData()
        {
            try
            {
                var token = HttpContext.Request.Params["access_token"];
                var client = new LoginRadiusClient(token);
                var userGroups = new GroupApi();
                var userGroupsData = client.GetResponse<List<LoginRadiusGroup>>(userGroups);
                return Json(userGroupsData);
            }
            catch (LoginRadiusException exception)
            {
                var error = exception.Response.Deserialize<ApiExceptionResponse>();
                return Json(error);
            }

        }

        //Function to get Customer's status data of social account.
        [HttpPost]
        public ActionResult StatusData()
        {
            try
            {
                var token = HttpContext.Request.Params["access_token"];
                var client = new LoginRadiusClient(token);
                var userStatus = new StatusApi();
                var userStatusData = client.GetResponse<List<LoginRadiusStatus>>(userStatus);
                return Json(userStatusData);
            }
            catch (LoginRadiusException exception)
            {
                var error = exception.Response.Deserialize<ApiExceptionResponse>();
                return Json(error);
            }

        }
        //Function to get Customer's videos data of social account.
        [HttpPost]
        public ActionResult VideosData()
        {
            try
            {
                var token = HttpContext.Request.Params["access_token"];
                var client = new LoginRadiusClient(token);
                var userVideos = new VideoApi(nextcursor: "0");
                var userVideosData = client.GetResponse<LoginRadiusVideo>(userVideos);
                return Json(userVideosData);
            }
            catch (LoginRadiusException exception)
            {
                var error = exception.Response.Deserialize<ApiExceptionResponse>();
                return Json(error);
            }
        }

        //Function to get Customer's profile data by Loginradius Access Token.
        public RaasUserprofile UserProfiledata(string accessToken)
        {
            Session["access_token"] = accessToken;
            //create client with the help of access token as parameter
            var client = new LoginRadiusClient(accessToken);
            //create object to execute user profile api to get user profile data.
            var userprofile = new UserProfileApi();
            //To get ultimate user profile data with the help of user profile api object as parameter.
            // and pass "LoginRadiusUltimateUserProfile" model as interface to map user profile data.
            var userProfileData = client.GetResponse<RaasUserprofile>(userprofile);
            if (userProfileData == null) { return null; }
            Session["userprofile"] = userProfileData;
            Session["Uid"] = userProfileData.Uid;
            return userProfileData;
        }

        //Function to Post Customer's status on their social account.
        public string PostStatus(StatusUpdateApi values)
        {
            try
            {
                var token = System.Web.HttpContext.Current.Session["access_token"].ToString();
                var client = new LoginRadiusClient(token);
                var userStatusData = client.GetResponse<LoginRadiusPostResponse>(values);
                return userStatusData.isPosted.ToString();
            }
            catch (LoginRadiusException exception)
            {
                var error = exception.Response.Deserialize<ApiExceptionResponse>();
                return error.message;
            }

        }

        //Function to get Customer's Photo data of social account.
        [HttpPost]
        public ActionResult PhotoData()
        {
            try
            {
                var albumId = HttpContext.Request.Params["AlbumID"];
                var token = System.Web.HttpContext.Current.Session["access_token"].ToString();
                var client = new LoginRadiusClient(token);
                var userPhotos = new PhotoApi(albumId);
                var userPhotosData = client.GetResponse<List<LoginRadiusPhoto>>(userPhotos);
                return Json(userPhotosData);
            }
            catch (LoginRadiusException exception)
            {
                var error = exception.Response.Deserialize<ApiExceptionResponse>();
                return Json(error);
            }
        }

        //Function to get Customer's videos data of social account.
        [HttpPost]
        public string DirectMessage(MessageApi messageApi)
        {
            try
            {
                var token = System.Web.HttpContext.Current.Session["access_token"].ToString();
                var client = new LoginRadiusClient(token);
                var userStatusData = client.GetResponse<LoginRadiusPostResponse>(messageApi);
                return userStatusData.isPosted.ToString();
            }
            catch (LoginRadiusException exception)
            {
                var error = exception.Response.Deserialize<ApiExceptionResponse>();
                return error.message;
            }
        }
    }
}