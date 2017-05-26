using LoginradiusSdk.Entity.AppSettings;
using LoginRadiusSDK.V2.Api;
using LoginRadiusSDK.V2.Api.AdvancedSocial;
using LoginRadiusSDK.V2.Api.CustomerRegistrationAuth;
using LoginRadiusSDK.V2.Api.Social;
using LoginRadiusSDK.V2.Api.Webhook;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.CustomerAuthentication._2FA;
using LoginRadiusSDK.V2.Models.Email;
using LoginRadiusSDK.V2.Models.Following;
using LoginRadiusSDK.V2.Models.Password;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Models.webhook;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly SocialEntity _social = new SocialEntity();
        // GET: Home
        public ActionResult Index()
        {
            LoginRadiusAppSettings.AppKey = "";
            LoginRadiusAppSettings.AppSecret = "";
            LoginRadiusAppSettings.AppName = "";
            return View();
        }


        public string GetProfile()
        {
            return "HI";
        }

        public void GetAccessToken(string Token)
        {
            var apiResponse = _social.GetAccessToken(Token);
            if (apiResponse.Response != null && apiResponse != null)
            {
                Session["access_token"] = apiResponse.Response.access_token;
            }

            //Secure accesstoken in session
            //Session["access_token"] = Token;
        }

        public JsonResult GetAlbumData()
        {
            string AccessToken = Session["access_token"].ToString();
            var apiResponse = _social.GetAlbumData(AccessToken);
            return Json(apiResponse, JsonRequestBehavior.AllowGet);
        }

        public void GetAudioData()
        {
            var apiResponse = _social.GetAudioData(Session["access_token"].ToString());

        }

        public void GetCheckInData()
        {
            var apiResponse = _social.GetCheckInData(Session["access_token"].ToString());

        }

        public JsonResult GetCompanyData()
        {
            var apiResponse = _social.GetCompanyData(Session["access_token"].ToString());
            return Json(apiResponse, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetContactData()
        {
            var apiResponse = _social.GetContactData(Session["access_token"].ToString());
            return Json(apiResponse, JsonRequestBehavior.AllowGet);
        }


        public void GetEventData()
        {
            var apiResponse = _social.GetEventData(Session["access_token"].ToString());

        }


        public JsonResult GetFollowingData()
        {
            var apiResponse = _social.GetFollowingData(Session["access_token"].ToString());
            return Json(apiResponse, JsonRequestBehavior.AllowGet);
        }


        public void GetGroupData()
        {
            var apiResponse = _social.GetGroupData(Session["access_token"].ToString());

        }


        public JsonResult GetLikeData()
        {
            var apiResponse = _social.GetLikeData(Session["access_token"].ToString());
            return Json(apiResponse, JsonRequestBehavior.AllowGet);

        }


        public void GetMentionData()
        {
            var apiResponse = _social.GetMentionData(Session["access_token"].ToString());
        }


        public void GetVideoData()
        {
            var apiResponse = _social.GetVideoData(Session["access_token"].ToString());

        }


        public JsonResult GetUserProfile()
        {
            var response = _social.GetUserProfile(Session["access_token"].ToString());
            Session["UID"] = response.Response.Uid;
            return Json(response, JsonRequestBehavior.AllowGet);
        }


        public void GetPageData()
        {
            var apiResponse = _social.GetPageData(Session["access_token"].ToString(), "loginradius");
        }


        public void GetPhotoData(string albumid)
        {

            var apiResponse = _social.GetPhotoData(Session["access_token"].ToString(), albumid);
        }


        public void GetStatusData()
        {
            var apiResponse = _social.GetStatusData(Session["access_token"].ToString());
        }

        [HttpPost]
        public JsonResult PostStatus(PostStatus model)
        {
            var apiResponse = _social.PostStatus(Session["access_token"].ToString(), model);
            return Json(apiResponse, JsonRequestBehavior.AllowGet);
        }

        public void PostMessage()
        {
            string To = "707922929368946";
            string Subject = "Subject";
            string Message = "Message";
            var apiResponse = _social.PostMessage(Session["access_token"].ToString(), To, Subject, Message);
        }

        public JsonResult FetchStatus()
        {
            var apiResponse = _social.FetchStatus(Session["access_token"].ToString());
            return Json(apiResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAccountPassword()
        {
            var response = new AccountManagementEntity().GetAccountPassword(Session["UID"].ToString());
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DeleteAccount()
        {
            var response = new AccountManagementEntity().DeleteAccount(Session["UID"].ToString());

            try
            {
                if (response.Response.IsDeleted)
                    Session.Clear();
            }
            catch { }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SetAccountPassword(string Password)
        {
            var response = new AccountManagementEntity().SetAccountPassword(Session["UID"].ToString(), Password);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ChangePassword(string OldPassword, string NewPassword)
        {
            ChangePasswordModel model = new ChangePasswordModel();
            model.OldPassword = OldPassword;
            model.NewPassword = NewPassword;
            var response = new PasswordEntity().ChangePassword(Session["access_token"].ToString(), model);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public void logout()
        {
            Session.Clear();
        }

        public JsonResult Register(UserIdentityCreateModel identityCreateModel)
        {
            identityCreateModel.PhoneId = "+919667286111";
            identityCreateModel.IsTwoFactorAuthenticationEnabled = true;
            identityCreateModel.Password = "123123";
            identityCreateModel.UserName = "ankurv";

            foreach (var item in identityCreateModel.Email)
            {
                var Type = item.Type;

                var Value = item.Value;
            }
            SottDetails _SottDetails = new SottDetails();
            _SottDetails.Sott = new Sott();
            //_SottDetails.Sott.StartTime = DateTime.UtcNow.ToString();
            //_SottDetails.Sott.EndTime = DateTime.UtcNow.AddMinutes(10).ToString();
            _SottDetails.Sott.StartTime = null;
            _SottDetails.Sott.EndTime = null;
            _SottDetails.Sott.TimeDifference = "10";

            var apiResponse = new RegisterEntity().RegisterCustomer(identityCreateModel, _apiOptionalParams, _SottDetails);
            _apiOptionalParams.VerificationUrl = "VerificationUrl";
            return Json(apiResponse, JsonRequestBehavior.AllowGet);
        }

        LoginRadiusApiOptionalParams _apiOptionalParams = new LoginRadiusApiOptionalParams();

        [HttpPost]
        public JsonResult Login(string email, string password, string g_recaptcha_response)
        {

            LoginRadiusApiOptionalParams _LoginRadiusApiOptionalParams = new LoginRadiusApiOptionalParams();
            _LoginRadiusApiOptionalParams.LoginUrl = "https://www.google.co.in";
            _LoginRadiusApiOptionalParams.VerificationUrl = "http://localhost:58955/Home/EmailVerificationToken";
            _LoginRadiusApiOptionalParams.EmailTemplate = "https://www.google.co.in";

            var response = new LoginEntity().LoginByEmail(email, password, _LoginRadiusApiOptionalParams);
            if (response.Response != null)
            {
                Session["UID"] = response.Response.Profile.Uid;
                Session["access_token"] = response.Response.access_token;
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }


        public JsonResult accountlink(string candidateToken)
        {
            SocialIdentityEntity _SocialIdentityEntity = new SocialIdentityEntity();
            var response = _SocialIdentityEntity.LinkAccount(Session["access_token"].ToString(), candidateToken);
            return Json(response, JsonRequestBehavior.AllowGet);
        }


        public ActionResult welcome()
        {
            return RedirectToAction("Index");
        }


        public JsonResult EmailVerificationToken(string vtype, string vtoken)
        {
            var apiResponse = new EmailEntity().VerifyEmail(vtoken, "http://localhost:58955", "");
            return Json(apiResponse, JsonRequestBehavior.AllowGet);
        }


        public JsonResult forgotpassword(string Email, string resetPasswordUrl)
        {
            LoginRadiusApiOptionalParams _apiOptionalParams = new LoginRadiusApiOptionalParams();
            _apiOptionalParams.ResetPasswordUrl = resetPasswordUrl;
            _apiOptionalParams.EmailTemplate = "emailTemplate";
            var apiResponse = new PasswordEntity().ForgotPassword(Email, _apiOptionalParams);

            return Json(apiResponse, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult resetpasword(string vtype, ReSetPasswordModel model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult resetpasword(ReSetPasswordModel model)
        {
            model.resettoken = model.VToken;
            var apiResponse = new PasswordEntity().ReSetPassword(model);
            if (apiResponse.Response != null)
            {
                if (apiResponse.Response.IsPosted)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult AccountProvider()
        {
            return View();
        }
         

    }

}