using LoginRadiusSDK.V2.Api;
using LoginRadiusSDK.V2.Api.Social;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.Password;
using LoginRadiusSDK.V2.Models.UserProfile;
using System.Web.Mvc;
using LoginRadiusSDK.V2;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly SocialEntity _social = new SocialEntity();
        // GET: Home
        public ActionResult Index()
        {
            LoginRadiusSdkGlobalConfig.ApiKey = "";
            LoginRadiusSdkGlobalConfig.ApiSecret = "";
            LoginRadiusSdkGlobalConfig.AppName = "";
            LoginRadiusSdkGlobalConfig.RequestRetries = 3;
            return View();
        }


        public string GetProfile()
        {
            return "HI";
        }

        public void GetAccessToken(string token)
        {
            var apiResponse = _social.GetAccessToken(token);
            if (apiResponse != null && apiResponse.Response != null)
            {
                Session["access_token"] = apiResponse.Response.access_token;
            }

            //Secure accesstoken in session
            //Session["access_token"] = Token;
        }

        public JsonResult GetAlbumData()
        {
            string accessToken = Session["access_token"].ToString();
            var apiResponse = _social.GetAlbumData(accessToken);
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
            string To = "******";
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
            catch
            {
                // ignored
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SetAccountPassword(string password)
        {
            var response = new AccountManagementEntity().SetAccountPassword(Session["UID"].ToString(), password);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ChangePassword(string oldPassword, string newPassword)
        {
            ChangePasswordModel model = new ChangePasswordModel();
            model.OldPassword = oldPassword;
            model.NewPassword = newPassword;
            var response = new PasswordEntity().ChangePassword(Session["access_token"].ToString(), model);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public void logout()
        {
            Session.Clear();
        }

        public JsonResult Register(UserIdentityCreateModel identityCreateModel)
        {
            identityCreateModel.PhoneId = "+91*******";
            identityCreateModel.IsTwoFactorAuthenticationEnabled = true;
            identityCreateModel.Password = "P@$$w0rd";
            identityCreateModel.UserName = "UserName";

            SottDetails sottDetails = new SottDetails
            {
                Sott = new Sott
                {
                    StartTime = null,
                    EndTime = null,
                    TimeDifference = "10"
                }
            };
            //_SottDetails.Sott.StartTime = DateTime.UtcNow.ToString();
            //_SottDetails.Sott.EndTime = DateTime.UtcNow.AddMinutes(10).ToString();

            var apiResponse = new RegisterEntity().RegisterCustomer(identityCreateModel, _apiOptionalParams, sottDetails);
            _apiOptionalParams.VerificationUrl = "VerificationUrl";
            return Json(apiResponse, JsonRequestBehavior.AllowGet);
        }

        readonly LoginRadiusApiOptionalParams _apiOptionalParams = new LoginRadiusApiOptionalParams();

        [HttpPost]
        public JsonResult Login(string email, string password, string gRecaptchaResponse)
        {
            LoginRadiusApiOptionalParams loginRadiusApiOptionalParams = new LoginRadiusApiOptionalParams
            {
                LoginUrl = "https://www.google.co.in",
                VerificationUrl = "http://localhost:58955/Home/EmailVerificationToken",
                EmailTemplate = "https://www.google.co.in"
            };

            var response = new LoginEntity().LoginByEmail(email, password, loginRadiusApiOptionalParams);
            if (response.Response != null)
            {
                Session["UID"] = response.Response.Profile.Uid;
                Session["access_token"] = response.Response.access_token;
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }


        public JsonResult accountlink(string candidateToken)
        {
            SocialIdentityEntity socialIdentityEntity = new SocialIdentityEntity();
            var response = socialIdentityEntity.LinkAccount(Session["access_token"].ToString(), candidateToken);
            return Json(response, JsonRequestBehavior.AllowGet);
        }


        public ActionResult welcome()
        {
            return RedirectToAction("Index");
        }


        public JsonResult EmailVerificationToken(string vtype, string vtoken)
        {
            var apiResponse = new EmailEntity().VerifyEmail(vtoken, "http://localhost:58955");
            return Json(apiResponse, JsonRequestBehavior.AllowGet);
        }


        public JsonResult forgotpassword(string email, string resetPasswordUrl)
        {
            LoginRadiusApiOptionalParams apiOptionalParams = new LoginRadiusApiOptionalParams
            {
                ResetPasswordUrl = resetPasswordUrl,
                EmailTemplate = "emailTemplate"
            };
            var apiResponse = new PasswordEntity().ForgotPassword(email, apiOptionalParams);

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