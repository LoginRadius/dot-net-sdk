using System.Collections;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
using LoginRadiusSDK.V2.Models.CustomerAuthentication._2FA;
using System.Web.Script.Serialization;
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
            Validate(new ArrayList { accessToken });
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
            if (userProfile.Email != null)
                userProfile.Email.Clear();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string profileData = js.Serialize(userProfile);


            Validate(new ArrayList { accessToken });
            var additionalQueryParams = new QueryParameters { { "access_token", accessToken } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);

            return ConfigureAndExecute<PostResponse>(RequestType.Authentication, HttpMethod.Put,
                _resoucePath.ToString(),
                additionalQueryParams, profileData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="optionalParams"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusDeleteResponse> DeleteProfile(string accessToken,
            LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new ArrayList { accessToken });
            var additionalQueryParams = new QueryParameters { { "access_token", accessToken } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.Delete,
                _resoucePath.ToString(),
                additionalQueryParams);
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
            Validate(new ArrayList { accessToken });
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
            Validate(new ArrayList { authModel.GoogleAuthenticatorCode, authModel.Otp });
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

        public ApiResponse<BOLSMSResponseData> UpdateTwoFactorAuthentication(string accessToken,
            TwoFactorPhoneAuthModel authModel, LoginRadiusApiOptionalParams optionalParams)
        {
            var a = authModel.ConvertToJson();
            Validate(new ArrayList { accessToken });
            var additionalQueryParams = new QueryParameters { { "access_token", accessToken } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);

            return ConfigureAndExecute<BOLSMSResponseData>(
                RequestType.Authentication, HttpMethod.Put, _resoucePath.ChildObject("2FA").ToString(),
                additionalQueryParams, authModel.ConvertToJson());
        }


        public ApiResponse<LoginRadiusDeleteResponse> RemoveOrReset2FAbyUID(RemoveOrResetTwoFactorAuthentication model,
            string uid)
        {
            Validate(new ArrayList { model.googleauthenticator, model.otpauthenticator, uid });
            var additionalQueryParams = new QueryParameters { ["uid"] = uid };
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.Delete,
                "2FA/authenticator", additionalQueryParams, model.ConvertToJson());
        }


        public ApiResponse<PhoneUpsertResponse> ResendTwoFAuthenticatorOtp(string secondfactorauthenticationtoken,
            string smstemplate2fa)
        {
            Validate(new ArrayList { secondfactorauthenticationtoken, smstemplate2fa });
            var additionalQueryParams = new QueryParameters
            {
                ["secondfactorauthenticationtoken"] = secondfactorauthenticationtoken,
                ["smstemplate2fa"] = smstemplate2fa
            };
            return ConfigureAndExecute<PhoneUpsertResponse>(RequestType.Authentication, HttpMethod.Get,
                "login/2FA/resend", additionalQueryParams);
        }


        public ApiResponse<CustomerRegistrationBackupCodeResponse> GetBackupCodeByAccessToken(string accessToken)
        {
            Validate(new ArrayList { accessToken });
            var additionalQueryParams = new QueryParameters { ["access_token"] = accessToken };
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Authentication,
                HttpMethod.Get, "account/2fa/backupcode", additionalQueryParams);
        }

        public ApiResponse<LoginResponse> LoginByBackupCode(string secondFactorAuthenticationToken, string backupcode)
        {
            Validate(new ArrayList { backupcode, secondFactorAuthenticationToken });
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
            Validate(new ArrayList { access_token, });
            var additionalQueryParams = new QueryParameters { ["access_token"] = access_token };
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Authentication,
                HttpMethod.Get, "account/2fa/backupcode/reset", additionalQueryParams);
        }

        public ApiResponse<CustomerRegistrationBackupCodeResponse> GetBackupCodeForLoginByUID(string uid)
        {
            Validate(new ArrayList { uid });
            var additionalQueryParams = new QueryParameters { ["uid"] = uid };
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Identity, HttpMethod.Get,
                "2fa/backupcode", additionalQueryParams);
        }

        public ApiResponse<CustomerRegistrationBackupCodeResponse> ResetBackupCodeForLoginByUID(string uid)
        {
            Validate(new ArrayList { uid, });
            var additionalQueryParams = new QueryParameters { ["uid"] = uid };
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Identity, HttpMethod.Get,
                "2fa/backupcode/reset", additionalQueryParams);
        }


        public ApiResponse<PostResponse> UpdateSecurityQuestionbyAccesstoken(string access_token,
            SecurityQuestionAnswerPost _SecurityQuestionAnswerPost)
        {
            Validate(new ArrayList { access_token });
            var additionalQueryParams = new QueryParameters { ["access_token"] = access_token };
            return ConfigureAndExecute<PostResponse>(RequestType.Authentication, HttpMethod.Put,
                "account", additionalQueryParams, _SecurityQuestionAnswerPost.ConvertToJson());
        }


        public ApiResponse<BolCustomerRegistrationDeleteResponse> DeleteAccountwithEmailConfirmation(
            string accessToken, LoginRadiusApiOptionalParams loginRadiusApiOptionalParams)
        {
            Validate(new ArrayList { accessToken });
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = accessToken,
                ["deleteUrl"] = loginRadiusApiOptionalParams.DeleteUrl,
                ["emailTemplate"] = loginRadiusApiOptionalParams.EmailTemplate
            };
            return ConfigureAndExecute<BolCustomerRegistrationDeleteResponse>(RequestType.Authentication,
                HttpMethod.Delete, "account", additionalQueryParams);
        }


        public ApiResponse<LoginRadiusSocialUserProfile> PhoneProfilebyPhoneID(string phone)
        {
            Validate(new ArrayList { phone });
            var additionalQueryParams = new QueryParameters
            {
                ["phone"] = phone
            };
            return ConfigureAndExecute<LoginRadiusSocialUserProfile>(RequestType.Identity, HttpMethod.Get, "",
                additionalQueryParams);
        }


        public ApiResponse<List<LoginRadiusSocialUserProfile>> PhoneDeletedProfilebyPhoneID(string phone)
        {
            Validate(new ArrayList { phone });
            var additionalQueryParams = new QueryParameters
            {
                ["phone"] = phone
            };
            return ConfigureAndExecute<List<LoginRadiusSocialUserProfile>>(RequestType.Identity, HttpMethod.Get,
                "identity/archived", additionalQueryParams);
        }


        public ApiResponse<LoginRadiusPostResponse> PhoneUserRegistrationbySMS(SottDetails sottDetails,
            LoginRadiusApiOptionalParams loginRadiusApiOptionalParams,
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


            var timediffrence = new QueryParameters { ["timedifference"] = sottDetails.Sott.TimeDifference };

            if (sottDetails.Sott.StartTime == null)
            {
                ApiResponse<SottDetails> sottresponse =
                    ConfigureAndExecute<SottDetails>(RequestType.ServerInfo, HttpMethod.Get, null, timediffrence);

                if (sottresponse.Response != null)
                {
                    sottDetails = sottresponse.Response;
                }
            }

            additionalparams.Add("sott", LoginRadiusSecureOneTimeToken.GetSott(sottDetails));

            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Post, "register",
                additionalparams, userIdentityCreateModel.ConvertToJson());
        }


        public ApiResponse<LoginRadiusUserIdentity> TwoFAbyGoogleAuthCodeOROTPbyToken( string  accessToken, string googleauthenticatorcode="", string otp="", string smstemplate2fa= "")
        {
            Validate(new ArrayList { accessToken });

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