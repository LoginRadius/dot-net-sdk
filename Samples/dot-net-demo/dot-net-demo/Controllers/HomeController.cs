﻿using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dot_net_demo.Models;

using LoginRadiusSDK.V2.Api.Advanced;
using LoginRadiusSDK.V2.Api.Authentication;
using LoginRadiusSDK.V2.Models.RequestModels;

using LoginRadiusSDK.V2.Common;
using LoginRadiusSDK.V2.Api.Account;

namespace dot_net_demo.Controllers
{
    public class HomeController : Controller
    {
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

            string fields = null;
            EmailAuthenticationModel log = new EmailAuthenticationModel
            {
                Email = emailLoginModel.Email,
                Password = emailLoginModel.Password
            };
            var apiresponse = new AuthenticationApi().LoginByEmail(log, fields).Result;

            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRMfaLogin([FromBody] EmailLoginModel emailLoginModel)
        {
            var apiresponse = new MultiFactorAuthenticationApi().MFALoginByEmail(emailLoginModel.Email, emailLoginModel.Password).Result;

            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRMfaAuth([FromBody] MultiFactorAuthModelByAuthenticatorCode multiFactorAuthModelByAuthenticatorCode, [FromQuery(Name = "multi_factor_auth_token")] String secondFactorAuthToken)
        {
            var apiresponse = new MultiFactorAuthenticationApi().MFAValidateAuthenticatorCode(multiFactorAuthModelByAuthenticatorCode, secondFactorAuthToken).Result;
            
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRPwlessLogin([FromQuery(Name = "email")] String email, [FromQuery(Name = "verification_url")] String verificationUrl)
        {
            var apiresponse = new PasswordLessLoginApi().PasswordlessLoginByEmail(email, "", verificationUrl).Result;

            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRPwlessAuth([FromQuery(Name = "verification_token")] String verificationToken)
        {
            var apiresponse = new PasswordLessLoginApi().PasswordlessLoginVerification(verificationToken).Result;

            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRRegister([FromBody] AuthUserRegistrationModel identityCreateModel, [FromQuery(Name = "verification_url")] String verificationUrl)
        {
            LoginRadiusSecureOneTimeToken _sott = new LoginRadiusSecureOneTimeToken();
            var sott = new SottRequest
            {
                TimeDifference = "50"
            };
            var apiresponse = new AuthenticationApi().UserRegistrationByEmail(identityCreateModel, _sott.GetSott(sott), null,null, verificationUrl,null).Result;

            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRVerifyEmail([FromQuery(Name = "verification_token")] String verificationToken)
        {
            var apiresponse = new AuthenticationApi().VerifyEmail(verificationToken, "google.ca", "").Result;

            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRForgotPassword([FromBody] ForgotPasswordModel forgotPassModel, [FromQuery(Name = "reset_password_url")] String resetPasswordUrl)
        {
            var apiresponse = new AuthenticationApi().ForgotPassword(forgotPassModel.Email, resetPasswordUrl, "").Result;
            
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRResetPasswordEmail([FromBody] ResetPasswordModel resetPasswordModel)
        {
            ResetPasswordByResetTokenModel reset = new ResetPasswordByResetTokenModel
            {
                Password = resetPasswordModel.password,
                ResetToken = resetPasswordModel.resettoken
            };
            var apiresponse = new AuthenticationApi().ResetPasswordByResetToken(reset).Result;

            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRChangePassword([FromBody] ChangePasswordModel changePasswordModel, [FromQuery(Name = "auth")] String accessToken)
        {
            var apiresponse = new AuthenticationApi().ChangePassword(accessToken, changePasswordModel.newPassword, changePasswordModel.oldPassword).Result;

            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRSetPassword([FromBody] SetPasswordModel setPasswordModel, [FromQuery(Name = "uid")] String uid)
        {
            var apiresponse = new AccountApi().SetAccountPasswordByUid(setPasswordModel.Password, uid).Result;

            if (apiresponse.RestException != null)
                {
                   return StatusCode(400, Json(apiresponse.RestException));
                }
                return Json(apiresponse.Response);
        }

        public IActionResult LRUpdate([FromBody] AccountUserProfileUpdateModel updateModel, [FromQuery(Name = "uid")] String uid)
        {
            var apiresponse = new AccountApi().UpdateAccountByUid(updateModel, uid).Result;
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRCreateCustomObject([FromBody] dynamic customObject, [FromQuery(Name = "auth")] String accessToken, [FromQuery(Name = "object_name")] String objectName)
        {
            var apiresponse = new CustomObjectApi().CreateCustomObjectByToken(accessToken, objectName, customObject).Result;

            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRUpdateCustomObject([FromBody] dynamic customObject, [FromQuery(Name = "auth")] String accessToken, [FromQuery(Name = "object_name")] String objectName, [FromQuery(Name = "object_id")] String objectId)
        {

            var apiresponse = new CustomObjectApi().UpdateCustomObjectByToken(accessToken, objectName, objectId, customObject).Result;

            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRDeleteCustomObject([FromQuery(Name = "auth")] String accessToken, [FromQuery(Name = "object_name")] String objectName, [FromQuery(Name = "object_id")] String objectId)
        {
            var apiresponse = new CustomObjectApi().DeleteCustomObjectByToken(accessToken, objectName, objectId).Result;

            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRGetCustomObject([FromQuery(Name = "auth")] String accessToken, [FromQuery(Name = "object_name")] String objectName)
        {
            var apiresponse = new CustomObjectApi().GetCustomObjectByToken(accessToken, objectName).Result;

            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRMfaResetGoogle([FromQuery(Name = "auth")] String accessToken)
        {
            var apiresponse = new MultiFactorAuthenticationApi().MFAResetAuthenticatorByToken(accessToken, true).Result;

            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRMfaValidate([FromQuery(Name = "auth")] String accessToken)
        {
            var apiresponse = new MultiFactorAuthenticationApi().MFAConfigureByAccessToken(accessToken,false).Result;

            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRMfaEnableGoogle([FromBody] MultiFactorAuthModelByAuthenticatorCodeSecurityAnswer multiFactorAuthModelByAuthenticatorCodeSecurityAnswer, [FromQuery(Name = "auth")] String accessToken)
        {
            var apiresponse = new MultiFactorAuthenticationApi().MFAVerifyAuthenticatorCode(accessToken, multiFactorAuthModelByAuthenticatorCodeSecurityAnswer).Result;

            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRGetRoles()
        {
            var apiresponse = new RoleApi().GetRolesList().Result;
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRGetRole([FromQuery(Name = "uid")] String uid)
        {
            var apiresponse = new RoleApi().GetRolesByUid(uid).Result;
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRCreateRole([FromBody] RolesModel rolePermissions)
        {
            var apiresponse = new RoleApi().CreateRoles(rolePermissions).Result;

            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRDeleteRole([FromQuery(Name = "role")] String roleName)
        {
            var apiresponse = new RoleApi().DeleteRole(roleName).Result;
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRAssignRole([FromQuery(Name = "uid")] String uid, [FromBody] AccountRolesModel roles)
        {
            var apiresponse = new RoleApi().AssignRolesByUid(roles, uid).Result;
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult LRGetProfile([FromQuery(Name = "auth")] String accessToken)
        {
            var apiresponse = new AuthenticationApi().GetProfileByAccessToken(accessToken).Result;
            if (apiresponse.RestException != null)
            {
                return StatusCode(400, Json(apiresponse.RestException));
            }
            return Json(apiresponse.Response);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}