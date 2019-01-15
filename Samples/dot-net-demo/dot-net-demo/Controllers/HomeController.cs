using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dot_net_demo.Models;
using LoginRadiusSDK.V2.Api;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.CustomerAuthentication.Login;
using LoginRadiusSDK.V2.Models.Password;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Models.CustomerAuthentication._2FA;
using LoginRadiusSDK.V2;

namespace dot_net_demo.Controllers
{
    public class HomeController : Controller
    {
        LoginRadiusApiOptionalParams _apiOptionalParams = new LoginRadiusApiOptionalParams();

         


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginScreen()
        {
            return View();
        }

        public IActionResult EmailVerification()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LRLogin([FromBody] EmailLoginModel emailLoginModel)
        {
            Debug.WriteLine(BaseConstants.RestAuthApiEndpoint);
            Debug.WriteLine(LoginRadiusSdkGlobalConfig.DomainName);
            _apiOptionalParams.VerificationUrl = "";
            _apiOptionalParams.G_Recaptcha_Response = "";

            var apiresponse = new AuthenticationApi().LoginByEmail(emailLoginModel.ConvertToJson(), _apiOptionalParams);
            if(apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRMfaLogin([FromBody] EmailLoginModel emailLoginModel)
        {
            _apiOptionalParams.SmsTemplate = "";
            var apiresponse = new MultifactorApi().MultifactorAuthLoginByEmail(emailLoginModel.email, emailLoginModel.password, _apiOptionalParams);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRMfaAuth([FromBody] GoogleAuthenticatorModel googleAuth, [FromQuery(Name = "multi_factor_auth_token")] String secondFactorAuthToken)
        {
            var apiresponse = new MultifactorApi().ValidateGoogleAuthCode(secondFactorAuthToken, googleAuth.googleauthenticatorcode, "");
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRPwlessLogin([FromQuery(Name = "email")] String email, [FromQuery(Name = "verification_url")] String verificationUrl)
        {
            var apiresponse = new PasswordlessLoginApi().PasswordlessLoginByEmail(email, "", verificationUrl);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRPwlessAuth([FromQuery(Name = "verification_token")] String verificationToken)
        {
            var apiresponse = new PasswordlessLoginApi().PasswordlessLoginVerification(verificationToken, "");
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRRegister([FromBody] UserIdentityCreateModel identityCreateModel, [FromQuery(Name = "verification_url")] String verificationUrl)
        {
            _apiOptionalParams.SmsTemplate = "";
            _apiOptionalParams.EmailTemplate = "";
            _apiOptionalParams.VerificationUrl = verificationUrl;

            var sott = new SottRequest
            {
                TimeDifference = "50"
            };

            var apiresponse = new AuthenticationApi().RegisterCustomer(identityCreateModel, _apiOptionalParams, sott);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRVerifyEmail([FromQuery(Name = "verification_token")] String verificationToken)
        {
            var apiresponse = new AuthenticationApi().VerifyEmail(verificationToken, "google.ca", "");
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRForgotPassword([FromBody] ForgotPasswordModel forgotPassModel, [FromQuery(Name = "reset_password_url")] String resetPasswordUrl)
        {
            var apiresponse = new AuthenticationApi().ForgotPassword(forgotPassModel.Email, resetPasswordUrl, "");
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRResetPasswordEmail([FromBody] ResetPasswordModel resetPasswordModel)
        {
            var apiresponse = new AuthenticationApi().ResetPassword(resetPasswordModel);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRChangePassword([FromBody] ChangePasswordModel changePasswordModel, [FromQuery(Name = "auth")] String accessToken)
        {
            var apiresponse = new AuthenticationApi().ChangePassword(accessToken, changePasswordModel);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRSetPassword([FromBody] SetPasswordModel setPasswordModel, [FromQuery(Name = "uid")] String uid)
        {
            var apiresponse = new AccountApi().SetAccountPassword(uid, setPasswordModel.Password);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRUpdate([FromBody] LoginRadiusAccountUpdateModel updateModel, [FromQuery(Name = "uid")] String uid)
        {
            var apiresponse = new AccountApi().UpdateAccount(uid, updateModel);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRCreateCustomObject([FromBody] dynamic customObject, [FromQuery(Name = "auth")] String accessToken, [FromQuery(Name = "object_name")] String objectName)
        {
            var CustomObject = Newtonsoft.Json.JsonConvert.SerializeObject(customObject);
            var apiresponse = new CustomObjectApi().CreateCustomObjectByToken(accessToken, objectName, CustomObject);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRUpdateCustomObject([FromBody] dynamic customObject, [FromQuery(Name = "auth")] String accessToken, [FromQuery(Name = "object_name")] String objectName,
            [FromQuery(Name = "object_id")] String objectId)
        {
            var CustomObject = Newtonsoft.Json.JsonConvert.SerializeObject(customObject);
            var apiresponse = new CustomObjectApi().UpdateByObjectRecordIdAndAccessToken(accessToken, objectId, objectName, CustomObject, fullReplace: true);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRDeleteCustomObject([FromQuery(Name = "auth")] String accessToken, [FromQuery(Name = "object_name")] String objectName, [FromQuery(Name = "object_id")] String objectId)
        {
            var apiresponse = new CustomObjectApi().DeleteByRecordIdAndToken(accessToken, objectId, objectName);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRGetCustomObject([FromQuery(Name = "auth")] String accessToken, [FromQuery(Name = "object_name")] String objectName)
        {
            var apiresponse = new CustomObjectApi().GetByAccessToken(accessToken, objectName);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRMfaResetGoogle([FromQuery(Name = "auth")] String accessToken)
        {
            RemoveOrResetMultifactorAuthentication obj = new RemoveOrResetMultifactorAuthentication();
            obj.googleauthenticator = true;
            var apiresponse = new MultifactorApi().RemoveOrResetMultifactorByAccessToken(obj, accessToken);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRMfaValidate([FromQuery(Name = "auth")] String accessToken)
        {
            _apiOptionalParams.SmsTemplate = "";
            var apiresponse = new MultifactorApi().GetMultifactorAccessToken(accessToken, _apiOptionalParams);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }
        
        public IActionResult LRMfaEnableGoogle([FromBody] GoogleAuthenticatorModel googleAuthenticatorCode, [FromQuery(Name = "auth")] String accessToken)
        {
            var apiresponse = new MultifactorApi().ValidateGoogleAuthCode(accessToken, googleAuthenticatorCode.googleauthenticatorcode);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRGetRoles()
        {
            var apiresponse = new RolesApi().GetRoles();
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRGetRole([FromQuery(Name = "uid")] String uid)
        {
            var apiresponse = new RolesApi().GetAccountRole(uid);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRCreateRole([FromBody] LoginRadiusRolesCreate rolePermissions)
        {
            var apiresponse = new RolesApi().CreateRoles(rolePermissions);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRDeleteRole([FromQuery(Name = "role")] String roleName)
        {
            var apiresponse = new RolesApi().DeleteRole(roleName);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRAssignRole([FromQuery(Name = "uid")] String uid, [FromBody] LoginRadiusAccountRolesUpsert roles)
        {
            var apiresponse = new RolesApi().RolesAssignToUser(uid, roles);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRGetProfile([FromQuery(Name = "auth")] String accessToken)
        {
            var apiresponse = new AuthenticationApi().GetProfile(accessToken);
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
