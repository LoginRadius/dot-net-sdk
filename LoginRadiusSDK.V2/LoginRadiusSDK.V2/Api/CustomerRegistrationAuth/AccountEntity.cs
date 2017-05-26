using System.Collections;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
using LoginRadiusSDK.V2.Models.Social.Password;
using LoginRadiusSDK.V2.Models.CustomerAuthentication._2FA;
using System.Web.Script.Serialization;
using LoginRadiusSDK.V2.Models.Backup;
using System.Collections.Generic;

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
            Validate(new ArrayList {accessToken});
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


            Validate(new ArrayList {accessToken});
            var additionalQueryParams = new QueryParameters {{"access_token", accessToken}};
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
            Validate(new ArrayList {accessToken});
            var additionalQueryParams = new QueryParameters {{"access_token", accessToken}};
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
            Validate(new ArrayList {accessToken});
            var additionalQueryParams = new QueryParameters {{"accessToken", accessToken}};
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
        /// <param name="accessToken"></param>
        /// <param name="authModel"></param>
        /// <param name="optionalParams"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusApiResponse<LoginRadiusUserIdentity>> VerifyTwoFactorAuthentication(
            TwoFactorAuthModel authModel, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new ArrayList {authModel.GoogleAuthenticatorCode, authModel.Otp});
            var additionalQueryParams = new QueryParameters
            {
                ["SecondFactorAuthenticationToken"] = authModel.SecondFactorAuthenticationToken,
                ["googleAuthenticatorCode"] = authModel.GoogleAuthenticatorCode,
                ["otp"] = authModel.Otp,
                ["smsTemplate2FA"] = optionalParams.SmsTemplate2Fa
            };


            return ConfigureAndExecute<LoginRadiusApiResponse<LoginRadiusUserIdentity>>(
                RequestType.Authentication, HttpMethod.Get,
                "login/2FA/Verification",
                additionalQueryParams);
        }

        public ApiResponse<LoginRadiusApiResponse<SmsResponseData>> UpdateTwoFactorAuthentication(string accessToken,
            TwoFactorPhoneAuthModel authModel, LoginRadiusApiOptionalParams optionalParams)
        {
            var a = authModel.ConvertToJson();
            Validate(new ArrayList {accessToken});
            var additionalQueryParams = new QueryParameters {{ "access_token", accessToken}};
            additionalQueryParams.AddOptionalParamsRange(optionalParams);

            return ConfigureAndExecute<LoginRadiusApiResponse<SmsResponseData>>(
                RequestType.Authentication, HttpMethod.Put, _resoucePath.ChildObject("2FA").ToString(),
                additionalQueryParams,authModel.ConvertToJson());
        }


        public ApiResponse<LoginRadiusDeleteResponse> RemoveOrReset2FAbyUID(RemoveOrResetTwoFactorAuthentication model,
            string uid)
        {
            Validate(new ArrayList {model.googleauthenticator, model.otpauthenticator, uid});
            var additionalQueryParams = new QueryParameters {["uid"] = uid};
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.Delete,
                "2FA/authenticator", additionalQueryParams, model.ConvertToJson());
        }


        public ApiResponse<PhoneUpsertResponse> ResendTwoFAuthenticatorOtp(string secondfactorauthenticationtoken,
            string smstemplate2fa)
        {
            Validate(new ArrayList {secondfactorauthenticationtoken, smstemplate2fa});
            var additionalQueryParams = new QueryParameters
            {
                ["secondfactorauthenticationtoken"] = secondfactorauthenticationtoken,
                ["smstemplate2fa"] = smstemplate2fa
            };
            return ConfigureAndExecute<PhoneUpsertResponse>(RequestType.Authentication, HttpMethod.Get,
                "login/2FA/resend", additionalQueryParams);
        }


        public ApiResponse<CustomerRegistrationBackupCodeResponse> GetBackupCodeByAccessToken(string access_token)
        {
            Validate(new ArrayList {access_token});
            var additionalQueryParams = new QueryParameters {["access_token"] = access_token};
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Authentication,
                HttpMethod.Get, "account/2fa/backupcode", additionalQueryParams);
        }

        public ApiResponse<CustomerRegistrationBackupCodeResponse> LoginByBackupCode(
            string SecondFactorAuthenticationToken, string backupcode)
        {
            Validate(new ArrayList {backupcode, SecondFactorAuthenticationToken});
            var additionalQueryParams = new QueryParameters
            {
                ["backupcode"] = backupcode,
                ["SecondFactorAuthenticationToken"] = SecondFactorAuthenticationToken
            };
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Authentication,
                HttpMethod.Get, "login/2fa/backupcode", additionalQueryParams);
        }

        public ApiResponse<CustomerRegistrationBackupCodeResponse> ResetBackUpCodeByAccessToken(string access_token)
        {
            Validate(new ArrayList {access_token,});
            var additionalQueryParams = new QueryParameters {["access_token"] = access_token};
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Authentication,
                HttpMethod.Get, "account/2fa/backupcode/reset", additionalQueryParams);
        }

        public ApiResponse<CustomerRegistrationBackupCodeResponse> GetBackupCodeForLoginByUID(string uid)
        {
            Validate(new ArrayList {uid});
            var additionalQueryParams = new QueryParameters {["uid"] = uid};
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Identity, HttpMethod.Get,
                "account/2fa/backupcode", additionalQueryParams);
        }

        public ApiResponse<CustomerRegistrationBackupCodeResponse> ResetBackupCodeForLoginByUID(string uid)
        {
            Validate(new ArrayList {uid,});
            var additionalQueryParams = new QueryParameters {["uid"] = uid};
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Identity, HttpMethod.Get,
                "2fa/backupcode/reset", additionalQueryParams);
        }


        public ApiResponse<LoginRadiusIdentityUserList> UpdateSecurityQuestionbyAccesstoken(string access_token,
            SecurityQuestionAnswerPost _SecurityQuestionAnswerPost)
        {
            Validate(new ArrayList {access_token});
            var additionalQueryParams = new QueryParameters {["access_token"] = access_token};
            return ConfigureAndExecute<LoginRadiusIdentityUserList>(RequestType.Authentication, HttpMethod.Put,
                "account", additionalQueryParams, _SecurityQuestionAnswerPost.ConvertToJson());
        }


        public ApiResponse<BolCustomerRegistrationDeleteResponse> DeleteAccountwithEmailConfirmation(
            string access_token, LoginRadiusApiOptionalParams _LoginRadiusApiOptionalParams)
        {
            Validate(new ArrayList {access_token});
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = access_token,
                ["deleteUrl"] = _LoginRadiusApiOptionalParams.DeleteUrl,
                ["emailTemplate"] = _LoginRadiusApiOptionalParams.EmailTemplate
            };
            return ConfigureAndExecute<BolCustomerRegistrationDeleteResponse>(RequestType.Authentication,
                HttpMethod.Delete, "account", additionalQueryParams);
        }


        public ApiResponse<LoginRadiusSocialUserProfile> PhoneProfilebyPhoneID(string phone)
        {
            Validate(new ArrayList {phone});
            var additionalQueryParams = new QueryParameters
            {
                ["phone"] = phone
            };
            return ConfigureAndExecute<LoginRadiusSocialUserProfile>(RequestType.Identity, HttpMethod.Get, "",
                additionalQueryParams);
        }


        public ApiResponse<List<LoginRadiusSocialUserProfile>> PhoneDeletedProfilebyPhoneID(string phone)
        {
            Validate(new ArrayList {phone});
            var additionalQueryParams = new QueryParameters
            {
                ["phone"] = phone,
                ["apikey"] = System.Configuration.ConfigurationManager.AppSettings["loginradius:apikey"],
                ["apisecret"] = System.Configuration.ConfigurationManager.AppSettings["loginradius:apisecret"]
            };
            return ConfigureAndExecute<List<LoginRadiusSocialUserProfile>>(RequestType.Social, HttpMethod.Get,
                "identity/archived", additionalQueryParams);
        }


        public ApiResponse<LoginRadiusPostResponse> PhoneUserRegistrationbySMS(SottDetails _SottDetails,
            LoginRadiusApiOptionalParams _LoginRadiusApiOptionalParams,
            UserIdentityCreateModel _UserIdentityCreateModel)
        {
            var additionalparams = new QueryParameters();
            if (string.IsNullOrEmpty(_LoginRadiusApiOptionalParams.VerificationUrl))
            {
                additionalparams.Add("verificationUrl", _LoginRadiusApiOptionalParams.VerificationUrl);
            }
            if (string.IsNullOrEmpty(_LoginRadiusApiOptionalParams.SmsTemplate))
            {
                additionalparams.Add("smsTemplate", _LoginRadiusApiOptionalParams.SmsTemplate);
            }


            var timediffrence = new QueryParameters {["timedifference"] = _SottDetails.Sott.TimeDifference};

            if (_SottDetails.Sott.StartTime == null)
            {
                ApiResponse<SottDetails> sottresponse =
                    ConfigureAndExecute<SottDetails>(RequestType.ServerInfo, HttpMethod.Get, null, timediffrence);

                if (sottresponse.Response != null)
                {
                    _SottDetails = sottresponse.Response;
                }
            }

            additionalparams.Add("sott", LoginRadiusSecureOneTimeToken.GetSott(_SottDetails));

            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Post, "register",
                additionalparams, _UserIdentityCreateModel.ConvertToJson());
        }
    }
}