using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.CustomerAuthentication._2FA;
using LoginRadiusSDK.V2.Models.CustomerAuthentication.Auth;
using LoginRadiusSDK.V2.Models.CustomerManagement.Identity;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using System.Collections;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api.CustomerRegistrationAuth
{
    public class AccessToken : LoginRadiusResource
    {
        private readonly LoginRadiusArgumentValidator _validate = new LoginRadiusArgumentValidator();

        public ApiResponse<AccessTokenResponse> TokenValidity(string access_token)
        {
            Validate(new ArrayList {access_token});
            var additionalQueryParams = new QueryParameters {{"access_token", access_token}};
            return ConfigureAndExecute<AccessTokenResponse>(RequestType.Authentication, HttpMethod.Get,
                "access_token/Validate", additionalQueryParams);
        }


        public ApiResponse<LoginRadiusPostResponse> InvalidateAccessToken(string access_token)
        {
            Validate(new ArrayList {access_token});
            var additionalQueryParams = new QueryParameters {{"access_token", access_token}};
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Get,
                "access_token/InValidate", additionalQueryParams);
        }


        public ApiResponse<LoginRadiusDeleteResponse> RemoveOrReset2FAbyAccessToken(
            RemoveOrResetTwoFactorAuthentication model, string access_token)
        {
            Validate(new ArrayList {model.otpauthenticator, model.googleauthenticator});
            var additionalQueryParams = new QueryParameters {{"access_token", access_token}};
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.Delete,
                "account/2FA/authenticator", additionalQueryParams, model.ConvertToJson());
        }


        public ApiResponse<Auth> AccessTokenGoogleJWT(string id_token)
        {
            Validate(new ArrayList {id_token});
            var additionalQueryParams = new QueryParameters {{"id_token", id_token}};
            return ConfigureAndExecute<Auth>(RequestType.AdvancedSocial, HttpMethod.Get, "access_token/googlejwt",
                additionalQueryParams);
        }


        public ApiResponse<LoginRadiusDeleteResponse> RemoveOrReset2FAbyAccessToken(bool otpauthenticator,
            bool googleauthenticator, string access_token)
        {
            Validate(new ArrayList {otpauthenticator, googleauthenticator});
            var pattern = new LoginRadiusResoucePath("{0}{1}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] {otpauthenticator, googleauthenticator});
            var additionalQueryParams = new QueryParameters {{"access_token", access_token}};
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.Delete,
                "account/2FA/authenticator", additionalQueryParams, resourcePath);
        }


        public ApiResponse<LoginRadiusDeleteResponse> RemoveOrReset2FAbyUID(RemoveOrResetTwoFactorAuthentication model,
            string uid)
        {
            Validate(new ArrayList {model.googleauthenticator, model.otpauthenticator, uid});
            var additionalQueryParams = new QueryParameters {["uid"] = uid};
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.Delete,
                "2FA/authenticator", additionalQueryParams, model.ConvertToJson());
        }


        public ApiResponse<LoginResponse> RegistrationWithRecaptcha(string apikey, LoginRadiusAccountUpdateModel model)
        {
            Validate(new ArrayList {apikey});
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.Post, "register/captcha",
                model.ConvertToJson());
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

        public ApiResponse<BOLSecondFactorAuthenticationSettings> TwoFactorAuthenticationbyToken(string access_token, string smsTemplate2FA)
        {
            Validate(new ArrayList { access_token });
            var additionalQueryParams = new QueryParameters
            {
                ["access_token"] = access_token

            };
            if (!string.IsNullOrEmpty(smsTemplate2FA))
            {
                additionalQueryParams.Add("smsTemplate2FA", smsTemplate2FA);
            }
            return ConfigureAndExecute<BOLSecondFactorAuthenticationSettings>(RequestType.Authentication, HttpMethod.Get, "/account/2fa", additionalQueryParams);
        }
    }
}