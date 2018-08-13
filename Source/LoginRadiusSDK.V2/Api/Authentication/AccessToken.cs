using System.Collections.Generic;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.CustomerAuthentication.Auth;
using LoginRadiusSDK.V2.Models.CustomerAuthentication._2FA;
using LoginRadiusSDK.V2.Models.Identity;
using LoginRadiusSDK.V2.Util;

namespace LoginRadiusSDK.V2.Api
{
    public class AccessToken : LoginRadiusResource
    {
        private readonly LoginRadiusArgumentValidator _validate = new LoginRadiusArgumentValidator();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public ApiResponse<AccessTokenResponse> TokenValidity(string access_token)
        {
            LoginRadiusArgumentValidator.Validate(new[] { access_token });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + access_token };
            return ConfigureAndExecute<AccessTokenResponse>(RequestType.Authentication, HttpMethod.GET,
                "access_token/Validate", null,null, additionalHeaders);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusPostResponse> InvalidateAccessToken(string access_token)
        {
            LoginRadiusArgumentValidator.Validate(new[] { access_token });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + access_token };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET,
                "access_token/InValidate", null,null, additionalHeaders);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusDeleteResponse> RemoveOrReset2FAbyAccessToken(RemoveOrResetTwoFactorAuthentication model,
            string access_token)
        {
            LoginRadiusArgumentValidator.Validate(new[] { model.otpauthenticator, model.googleauthenticator });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + access_token };
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.DELETE,
                "account/2FA/authenticator", null, model.ConvertToJson(), additionalHeaders);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_token"></param>
        /// <returns></returns>
        public ApiResponse<Auth> AccessTokenGoogleJWT(string id_token)
        {
            LoginRadiusArgumentValidator.Validate(new[] { id_token });
            var additionalQueryParams = new QueryParameters { { nameof(id_token), id_token } };
            return ConfigureAndExecute<Auth>(RequestType.AdvancedSocial, HttpMethod.GET, "access_token/googlejwt",
                additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otpauthenticator"></param>
        /// <param name="googleauthenticator"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusDeleteResponse> RemoveOrReset2FAbyAccessToken(bool otpauthenticator,
            bool googleauthenticator, string access_token)
        {
            LoginRadiusArgumentValidator.Validate(new[] { otpauthenticator, googleauthenticator });
            var pattern = new LoginRadiusResoucePath("{0}{1}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { otpauthenticator, googleauthenticator });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + access_token };
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.DELETE,
                "account/2FA/authenticator", null, resourcePath, additionalHeaders);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusDeleteResponse> RemoveOrReset2FAbyUID(RemoveOrResetTwoFactorAuthentication model,
            string uid)
        {
            LoginRadiusArgumentValidator.Validate(new List<object> { model.googleauthenticator, model.otpauthenticator, uid });
            var additionalQueryParams = new QueryParameters { [nameof(uid)] = uid };
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.DELETE,
                "2FA/authenticator", additionalQueryParams, model.ConvertToJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="secondfactorauthenticationtoken"></param>
        /// <param name="smstemplate2fa"></param>
        /// <returns></returns>
        public ApiResponse<PhoneUpsertResponse> ResendTwoFAuthenticatorOtp(string secondfactorauthenticationtoken,
            string smstemplate2fa)
        {
            LoginRadiusArgumentValidator.Validate(new[] { secondfactorauthenticationtoken, smstemplate2fa });
            var additionalQueryParams = new QueryParameters
            {
                [nameof(secondfactorauthenticationtoken)] = secondfactorauthenticationtoken,
                [nameof(smstemplate2fa)] = smstemplate2fa
            };
            return ConfigureAndExecute<PhoneUpsertResponse>(RequestType.Authentication, HttpMethod.GET,
                "login/2FA/resend", additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="smsTemplate2FA"></param>
        /// <returns></returns>
        public ApiResponse<SecondFactorAuthenticationSettings> TwoFactorAuthenticationbyToken(string access_token, string smsTemplate2FA)
        {
            LoginRadiusArgumentValidator.Validate(new[] { access_token });
            var additionalQueryParams = new QueryParameters();
            additionalQueryParams.TryAdd(nameof(smsTemplate2FA), smsTemplate2FA);
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + access_token };
            return ConfigureAndExecute<SecondFactorAuthenticationSettings>(RequestType.Authentication, HttpMethod.GET, "/account/2fa", additionalQueryParams,null, additionalHeaders);
        }
    }
}