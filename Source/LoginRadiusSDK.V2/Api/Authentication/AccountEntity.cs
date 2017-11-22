using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
using LoginRadiusSDK.V2.Models.CustomerAuthentication._2FA;
using System.Collections.Generic;
using LoginRadiusSDK.V2.Models.BackupCodes;

namespace LoginRadiusSDK.V2.Api
{
    public class AccountEntity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("account");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusUserIdentity> GetProfile(string accessToken)
        {
            Validate(new [] { accessToken });
            var additionalQueryParams = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(accessToken)) additionalQueryParams.Add("access_Token", accessToken);
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Authentication, HttpMethod.Get,
                _resoucePath.ToString(),
                additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userProfile"></param>
        /// <param name="optionalParams"></param>
        /// <returns></returns>
        public ApiResponse<PostResponse> UpdateProfile(string accessToken,
            LoginRadiusUserIdentity userProfile, LoginRadiusApiOptionalParams optionalParams)
        {
            userProfile.Email?.Clear();
            Validate(new [] { accessToken });
            var additionalQueryParams = new QueryParameters { { "access_token", accessToken } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);

            return ConfigureAndExecute<PostResponse>(RequestType.Authentication, HttpMethod.Put,
                _resoucePath.ToString(),
                additionalQueryParams, userProfile.ConvertToJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="optionalParams"></param>
        /// <returns></returns>
        public ApiResponse<CustomerRegistrationDeleteResponse> DeleteProfile(string accessToken, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new [] { accessToken });
            var additionalQueryParams = new QueryParameters { { "access_token", accessToken } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return ConfigureAndExecute<CustomerRegistrationDeleteResponse>(RequestType.Authentication, HttpMethod.Delete, _resoucePath.ToString(),
                additionalQueryParams);
        }

        /// <summary>
        /// API is used to delete account using delete token.
        /// <para>See <a href="https://docs.loginradius.com/api/v2/">LoginRadius Developer documentation</a> for more information.</para>
        /// </summary>
        /// <param name="deleteToken"></param>
        /// <returns><see cref="LoginRadiusPostResponse"/></returns>
        public ApiResponse<LoginRadiusPostResponse> DeleteProfile(string deleteToken)
        {
            Validate(new[] { deleteToken });
            var additionalQueryParams = new QueryParameters { { "deleteToken", deleteToken } };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Get, 
                _resoucePath.ChildObject("delete").ToString(), additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="optionalParams"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusApiResponse<TwoFactorAuthentication>> GetTwoFactorAuthentication(
            string accessToken, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new [] { accessToken });
            var additionalQueryParams = new QueryParameters { { "access_token", accessToken } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);

            return
                ConfigureAndExecute<LoginRadiusApiResponse<TwoFactorAuthentication>>(
                    RequestType.Authentication, HttpMethod.Get,
                    _resoucePath.ChildObject("2FA").ToString(),
                    additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authModel"></param>
        /// <param name="optionalParams"></param>
        /// <returns></returns>
        public ApiResponse<LoginResponse> VerifyTwoFactorAuthentication(
            TwoFactorAuthModel authModel, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new [] { authModel.GoogleAuthenticatorCode, authModel.Otp });
            var additionalQueryParams = new QueryParameters
            {
                ["SecondFactorAuthenticationToken"] = authModel.SecondFactorAuthenticationToken,
                ["googleAuthenticatorCode"] = authModel.GoogleAuthenticatorCode,
                ["otp"] = authModel.Otp,
                ["smsTemplate2FA"] = optionalParams.SmsTemplate2Fa
            };


            return ConfigureAndExecute<LoginResponse>(
                RequestType.Authentication, HttpMethod.Get,
                "login/2FA/Verification",
                additionalQueryParams);
        }

        public ApiResponse<SmsSendResponse> UpdateTwoFactorAuthentication(string accessToken, TwoFactorPhoneAuthModel authModel, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new [] { accessToken });
            var additionalQueryParams = new QueryParameters { { "access_token", accessToken } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);

            return ConfigureAndExecute<SmsSendResponse>(RequestType.Authentication, HttpMethod.Put, _resoucePath.ChildObject("2FA").ToString(),
                additionalQueryParams, authModel.ConvertToJson());
        }


        public ApiResponse<LoginRadiusDeleteResponse> RemoveOrReset2FAbyUID(RemoveOrResetTwoFactorAuthentication model,
            string uid)
        {
            Validate(new List<object> { model.googleauthenticator, model.otpauthenticator, uid });
            var additionalQueryParams = new QueryParameters { ["uid"] = uid };
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.Delete,
                "2FA/authenticator", additionalQueryParams, model.ConvertToJson());
        }


        public ApiResponse<PhoneUpsertResponse> ResendTwoFAuthenticatorOtp(string secondfactorauthenticationtoken, string smstemplate2Fa)
        {
            Validate(new [] { secondfactorauthenticationtoken, smstemplate2Fa });
            var additionalQueryParams = new QueryParameters
            {
                ["secondfactorauthenticationtoken"] = secondfactorauthenticationtoken,
                ["smstemplate2fa"] = smstemplate2Fa
            };
            return ConfigureAndExecute<PhoneUpsertResponse>(RequestType.Authentication, HttpMethod.Get,
                "login/2FA/resend", additionalQueryParams);
        }


        public ApiResponse<CustomerRegistrationBackupCodeResponse> GetBackupCodeByAccessToken(string accessToken)
        {
            Validate(new [] { accessToken });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken };
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Authentication,
                HttpMethod.Get, "account/2fa/backupcode", additionalQueryParams);
        }

        public ApiResponse<LoginResponse> LoginByBackupCode(string secondFactorAuthenticationToken, string backupcode)
        {
            Validate(new [] { backupcode, secondFactorAuthenticationToken });
            var additionalQueryParams = new QueryParameters
            {
                ["backupcode"] = backupcode,
                ["SecondFactorAuthenticationToken"] = secondFactorAuthenticationToken
            };
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication,
                HttpMethod.Get, "login/2fa/backupcode", additionalQueryParams);
        }

        public ApiResponse<CustomerRegistrationBackupCodeResponse> ResetBackUpCodeByAccessToken(string access_token)
        {
            Validate(new [] { access_token, });
            var additionalQueryParams = new QueryParameters { ["access_token"] = access_token };
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Authentication,
                HttpMethod.Get, "account/2fa/backupcode/reset", additionalQueryParams);
        }

        public ApiResponse<CustomerRegistrationBackupCodeResponse> GetBackupCodeForLoginByUID(string uid)
        {
            Validate(new [] { uid });
            var additionalQueryParams = new QueryParameters { ["uid"] = uid };
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Identity, HttpMethod.Get,
                "2fa/backupcode", additionalQueryParams);
        }

        public ApiResponse<CustomerRegistrationBackupCodeResponse> ResetBackupCodeForLoginByUID(string uid)
        {
            Validate(new [] { uid, });
            var additionalQueryParams = new QueryParameters { ["uid"] = uid };
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Identity, HttpMethod.Get,
                "2fa/backupcode/reset", additionalQueryParams);
        }


        public ApiResponse<PostResponse> UpdateSecurityQuestionbyAccesstoken(string access_token,
            SecurityQuestionAnswerPost securityQuestionAnswerPost)
        {
            Validate(new [] { access_token });
            var additionalQueryParams = new QueryParameters { ["access_token"] = access_token };
            return ConfigureAndExecute<PostResponse>(RequestType.Authentication, HttpMethod.Put,
                "account", additionalQueryParams, securityQuestionAnswerPost.ConvertToJson());
        }


        public ApiResponse<CustomerRegistrationDeleteResponse> DeleteAccountwithEmailConfirmation(
            string accessToken, LoginRadiusApiOptionalParams loginRadiusApiOptionalParams)
        {
            Validate(new [] { accessToken });
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["deleteUrl"] = loginRadiusApiOptionalParams.DeleteUrl,
                ["emailTemplate"] = loginRadiusApiOptionalParams.EmailTemplate
            };
            return ConfigureAndExecute<CustomerRegistrationDeleteResponse>(RequestType.Authentication,
                HttpMethod.Delete, "account", additionalQueryParams);
        }


        public ApiResponse<LoginRadiusSocialUserProfile> PhoneProfilebyPhoneID(string phone)
        {
            Validate(new [] { phone });
            var additionalQueryParams = new QueryParameters
            {
                ["phone"] = phone
            };
            return ConfigureAndExecute<LoginRadiusSocialUserProfile>(RequestType.Identity, HttpMethod.Get, "",
                additionalQueryParams);
        }


        public ApiResponse<List<LoginRadiusSocialUserProfile>> PhoneDeletedProfilebyPhoneID(string phone)
        {
            Validate(new [] { phone });
            var additionalQueryParams = new QueryParameters
            {
                ["phone"] = phone
            };
            return ConfigureAndExecute<List<LoginRadiusSocialUserProfile>>(RequestType.Identity, HttpMethod.Get,
                "identity/archived", additionalQueryParams);
        }


        public ApiResponse<LoginRadiusPostResponse> PhoneUserRegistrationbySMS(Sott sottAuth, LoginRadiusApiOptionalParams loginRadiusApiOptionalParams,
            UserIdentityCreateModel userIdentityCreateModel)
        {
            var additionalparams = new QueryParameters();
            if (string.IsNullOrEmpty(loginRadiusApiOptionalParams.VerificationUrl))
            {
                additionalparams.Add("verificationUrl", loginRadiusApiOptionalParams.VerificationUrl);
            }
            if (string.IsNullOrEmpty(loginRadiusApiOptionalParams.SmsTemplate))
            {
                additionalparams.Add("smsTemplate", loginRadiusApiOptionalParams.SmsTemplate);
            }

            if (sottAuth.StartTime == null)
            {
                var timediffrence = new QueryParameters { ["timedifference"] = sottAuth.TimeDifference };
                var sottresponse = ConfigureAndExecute<SottDetails>(RequestType.ServerInfo, HttpMethod.Get, null, timediffrence);

                if (sottresponse.Response != null) sottAuth = sottresponse.Response.Sott;
            }

            additionalparams.Add("sott", LoginRadiusSecureOneTimeToken.GetSott(sottAuth));

            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Post, "register",
                additionalparams, userIdentityCreateModel.ConvertToJson());
        }


        public ApiResponse<LoginRadiusUserIdentity> TwoFAbyGoogleAuthCodeOROTPbyToken( string  accessToken, string googleauthenticatorcode="", string otp="", string smstemplate2fa= "")
        {
            Validate(new [] { accessToken });

            var additionalparams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["googleauthenticatorcode"] = googleauthenticatorcode,
                ["otp"] = otp,
                ["smstemplate2fa"] = smstemplate2fa
            };

            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Authentication, HttpMethod.Get, "account/2fa/verification",
               additionalparams);
        }
    }
}