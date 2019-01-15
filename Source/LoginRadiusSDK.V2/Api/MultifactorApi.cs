using System.Collections.Generic;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.BackupCodes;
using LoginRadiusSDK.V2.Models.CustomerAuthentication._2FA;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using Newtonsoft.Json.Linq;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class MultifactorApi : LoginRadiusResource
    {

        /// <summary>
        /// This API can be used to login by email id on a Multi-factor authentication enabled LoginRadius site.
        /// </summary>
        /// <param name="email">Email used for logging in.</param>
        /// <param name="password">Password used for logging in.</param>
        /// <param name="optionalParams">Additional parameters that can be passed in.</param>
        /// <returns>MultifactorAuthenticationResponse: An object that contains data for logging in with multifactor if required or enabled. Otherwise returns LR profile.</returns>
        public ApiResponse<MultifactorAuthenticationResponse<LoginRadiusUserIdentity>>
            MultifactorAuthLoginByEmail(string email, string password, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { email, password });
            var additionalQueryParams = new QueryParameters { { "email", email }, { "password", password } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return ConfigureAndExecute<MultifactorAuthenticationResponse<LoginRadiusUserIdentity>>(
                RequestType.Authentication, HttpMethod.GET, "login/2fa", additionalQueryParams);
        }

        /// <summary>
        /// This API can be used to login by username on a Multi-factor authentication enabled LoginRadius site.
        /// </summary>
        /// <param name="username">Username used for logging in.</param>
        /// <param name="password">Password used for logging in.</param>
        /// <param name="optionalParams">Additional parameters that can be passed in.</param>
        /// <returns>MultifactorAuthenticationResponse: An object that contains data for logging in with multifactor if required or enabled. Otherwise returns LR profile.</returns>
        public ApiResponse<MultifactorAuthenticationResponse<LoginRadiusUserIdentity>>
            MultifactorAuthLoginByUsername(string username, string password, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { username, password });
            var additionalQueryParams = new QueryParameters { { "username", username }, { "password", password } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return ConfigureAndExecute<MultifactorAuthenticationResponse<LoginRadiusUserIdentity>>(
                RequestType.Authentication, HttpMethod.GET, "login/2fa", additionalQueryParams);
        }

        /// <summary>
        /// This API can be used to login by username on a Multi-factor authentication enabled LoginRadius site.
        /// </summary>
        /// <param name="phone">Phone used for logging in.</param>
        /// <param name="password">Password used for logging in.</param>
        /// <param name="optionalParams">Additional parameters that can be passed in.</param>
        /// <returns>MultifactorAuthenticationResponse: An object that contains data for logging in with multifactor if required or enabled. Otherwise returns LR profile.</returns>
        public ApiResponse<MultifactorAuthenticationResponse<LoginRadiusUserIdentity>> MultifactorAuthLoginByPhone(string phone, string password,
            LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { phone, password });
            var additionalQueryParams = new QueryParameters { { "phone", phone }, { "password", password } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return ConfigureAndExecute<MultifactorAuthenticationResponse<LoginRadiusUserIdentity>>(RequestType.Authentication,
                HttpMethod.GET, "login/2fa", additionalQueryParams);
        }

        /// <summary>
        /// Allows you to setup multifactor authentication with an access token when set to optional.
        /// </summary>
        /// <param name="accessToken">Session for account which is setting up multifactor.</param>
        /// <param name="optionalParams">Optional parameters.</param>
        /// <returns>Object for setting up multifactor authentication</returns>
        public ApiResponse<MultifactorAuthentication> GetMultifactorAccessToken(string accessToken,
            LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters();
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<MultifactorAuthentication> (RequestType.Authentication, HttpMethod.GET,
                "account/2fa", additionalQueryParams, null, additionalHeaders);
        }

        /// <summary>
        /// Uses the access token of a multifactor account to generate backup codes.
        /// </summary>
        /// <param name="accessToken">Session for account which is generating backup codes.</param>
        /// <returns>CustomerRegistrationBackupCodeResponse: List of valid backup codes.</returns>
        public ApiResponse<CustomerRegistrationBackupCodeResponse> GetBackupCodeByAccessToken(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Authentication,
                HttpMethod.GET, "account/2fa/backupcode", null, null, additionalHeaders);
        }

        /// <summary>
        /// Uses the access token of a multifactor account to reset a new list of backup codes.
        /// </summary>
        /// <param name="accessToken">Session for account which is resetting backup codes.</param>
        /// <returns>CustomerRegistrationBackupCodeResponse: List of valid backup codes.</returns>
        public ApiResponse<CustomerRegistrationBackupCodeResponse> ResetBackUpCodeByAccessToken(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Authentication, HttpMethod.GET,
                "account/2fa/backupcode/reset", null, null, additionalHeaders);
        }

        /// <summary>
        /// Uses the uid of a multifactor account to generate backup codes.
        /// </summary>
        /// <param name="uid">Uid for account which is generating backup codes.</param>
        /// <returns>CustomerRegistrationBackupCodeResponse: List of valid backup codes.</returns>
        public ApiResponse<CustomerRegistrationBackupCodeResponse> GetBackupCodeByUid(string uid)
        {
            Validate(new[] { uid });
            var additionalQueryParams = new QueryParameters { [nameof(uid)] = uid };
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Identity, HttpMethod.GET,
                "2fa/backupcode", additionalQueryParams);
        }

        /// <summary>
        /// Uses the uid of a multifactor account to reset a new list of backup codes.
        /// </summary>
        /// <param name="uid">Uid for account which is resetting backup codes.</param>
        /// <returns>CustomerRegistrationBackupCodeResponse: List of valid backup codes.</returns>
        public ApiResponse<CustomerRegistrationBackupCodeResponse> ResetBackupCodeByUid(string uid)
        {
            Validate(new[] { uid });
            var additionalQueryParams = new QueryParameters { [nameof(uid)] = uid };
            return ConfigureAndExecute<CustomerRegistrationBackupCodeResponse>(RequestType.Identity, HttpMethod.GET,
                "2fa/backupcode/reset", additionalQueryParams);
        }

        /// <summary>
        /// Validates a backup code to login.
        /// </summary>
        /// <param name="secondfactorauthenticationtoken">Token generated on first step of multifactor login.</param>
        /// <param name="backupCode">Backup code being validated.</param>
        /// <returns>LoginResponse: LoginRadius profile object with access token.</returns>
        public ApiResponse<LoginResponse> ValidateBackupCode(string secondfactorauthenticationtoken, string backupCode)
        {
            Validate(new[] { secondfactorauthenticationtoken, backupCode });

            var additionalQueryParams = new QueryParameters
            {
                {"secondfactorauthenticationtoken", secondfactorauthenticationtoken}
            };
            var body = new BodyParameters { ["backupcode"] = backupCode };
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.PUT, "login/2fa/verification/backupcode",
                additionalQueryParams, body.ConvertToJson());
        }

        /// <summary>
        /// Validates an otp to login.
        /// </summary>
        /// <param name="secondfactorauthenticationtoken">Token generated on first step of multifactor login.</param>
        /// <param name="multifactorUpdateSettingsModel">Object that contains otp data needed to login.</param>
        /// <param name="smsTemplate2Fa">SMS template for login.</param>
        /// <returns>LoginResponse: LoginRadius profile object with access token.</returns>
        public ApiResponse<LoginResponse> ValidateOtp(string secondfactorauthenticationtoken, 
            MultifactorUpdateSettingsModel multifactorUpdateSettingsModel, string smsTemplate2Fa = "")
        {
            Validate(new[] { secondfactorauthenticationtoken, multifactorUpdateSettingsModel.otp });

            var additionalQueryParams = new QueryParameters
            {
                {"secondfactorauthenticationtoken", secondfactorauthenticationtoken}
            };
            if (!string.IsNullOrWhiteSpace(smsTemplate2Fa))
                additionalQueryParams.Add("smsTemplate2FA", smsTemplate2Fa);
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.PUT, "login/2fa/verification/otp",
                additionalQueryParams, multifactorUpdateSettingsModel.ConvertToJson());
        }

        /// <summary>
        /// Validates a google authenticator code to login.
        /// </summary>
        /// <param name="secondfactorauthenticationtoken">Token generated on first step of multifactor login.</param>
        /// <param name="googleauthenticatorcode">The google auth code.</param>
        /// <param name="smsTemplate2Fa">SMS template for login.</param>
        /// <returns>LoginResponse: LoginRadius profile object with access token.</returns>
        public ApiResponse<LoginResponse> ValidateGoogleAuthCode(string secondfactorauthenticationtoken, 
            string googleauthenticatorcode, string smsTemplate2Fa = "")
        {
            Validate(new[] { secondfactorauthenticationtoken });

            var additionalQueryParams = new QueryParameters
            {
                {"secondfactorauthenticationtoken", secondfactorauthenticationtoken}
            };
            var body = new BodyParameters { ["googleauthenticatorcode"] = googleauthenticatorcode };
            if (!string.IsNullOrWhiteSpace(smsTemplate2Fa))
                additionalQueryParams.Add("smsTemplate2FA", smsTemplate2Fa);
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.PUT, "login/2fa/verification/googleauthenticatorcode",
                additionalQueryParams, body.ConvertToJson());
        }

        /// <summary>
        /// Updates the phone number being used for multifactor authentication.
        /// </summary>
        /// <param name="secondFactorAuthenticationToken">Token generated on first step of multifactor login.</param>
        /// <param name="authModel">Object for phone multifactor update.</param>
        /// <param name="optionalParams">Optional parameters.</param>
        /// <returns>SmsResponseData: Object containing information on SMS sent.</returns>
        public ApiResponse<SmsSendResponse> UpdatePhoneNumber(string secondFactorAuthenticationToken, TwoFactorPhoneAuthModel authModel, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { secondFactorAuthenticationToken });

            var additionalQueryParams = new QueryParameters
            {
                {"SecondFactorAuthenticationToken", secondFactorAuthenticationToken}
            };
            var body = new BodyParameters { ["phoneno2fa"] = authModel.PhoneNo2Fa };
            additionalQueryParams.AddOptionalParamsRange(authModel);
            if (!string.IsNullOrWhiteSpace(optionalParams.SmsTemplate))
                additionalQueryParams.Add("smsTemplate2FA", optionalParams.SmsTemplate2Fa);
            return ConfigureAndExecute<SmsSendResponse>(RequestType.Authentication, HttpMethod.PUT, "login/2fa",
                additionalQueryParams, body.ConvertToJson());
        }

        /// <summary>
        /// Sets up the phone number being used for multifactor authentication.
        /// </summary>
        /// <param name="accessToken">Adds a phone for multifactor login.</param>
        /// <param name="authModel">Object for phone multifactor update.</param>
        /// <param name="optionalParams">Optional parameters.</param>
        /// <returns>SmsSendResponse: Object containing information on SMS sent.</returns>
        public ApiResponse<SmsSendResponse> UpdateMultifactorAuthenticationPhone(string accessToken, TwoFactorPhoneAuthModel authModel, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters();
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<SmsSendResponse>(RequestType.Authentication, HttpMethod.PUT, "account/2fa",
                additionalQueryParams, authModel.ConvertToJson(), additionalHeaders);
        }

        /// <summary>
        /// Sets up the multifactor login for a logged in account with Google Authenticator.
        /// </summary>
        /// <param name="accessToken">Session which google authentication is being added.</param>
        /// <param name="googleAuthenticatorCode">Google authenticator code.</param>
        /// <returns>LoginRadiusUserIdentity: LoginRadius identity object.</returns>
        public ApiResponse<LoginRadiusUserIdentity> UpdateMultifactorAuthenticationGoogle(string accessToken, string googleAuthenticatorCode)
        {
            Validate(new[] { accessToken, googleAuthenticatorCode });
            var payload = new JObject();
            payload.Add("GoogleAuthenticatorCode", googleAuthenticatorCode);
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Authentication, HttpMethod.PUT, "account/2fa/verification/googleauthenticatorcode",
                null, payload.ToString(), additionalHeaders);
        }

        /// <summary>
        /// Sets up the multifactor login for a logged in account with Google Authenticator.
        /// </summary>
        /// <param name="accessToken">Session which google authentication is being added.</param>
        /// <param name="multifactorUpdateSettingsModel">New multifactor settings to update.</param>
        /// <returns>LoginRadiusUserIdentity: LoginRadius identity object.</returns>
        public ApiResponse<LoginRadiusUserIdentity> UpdateMultifactorSettings(string accessToken, MultifactorUpdateSettingsModel multifactorUpdateSettingsModel)
        {
            Validate(new[] { accessToken, multifactorUpdateSettingsModel.otp });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Authentication, HttpMethod.PUT, "account/2fa/verification/otp",
                null, multifactorUpdateSettingsModel.ConvertToJson(), additionalHeaders);
        }

        /// <summary>
        /// Resets the multifactor settings on the account with access token.
        /// </summary>
        /// <param name="model">Used to determine whether to reset SMS auth or multifactor auth.</param>
        /// <param name="accessToken">Session which is getting their multifactor reset.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean that shows whether multifactor was reset.</returns>
        public ApiResponse<LoginRadiusDeleteResponse> RemoveOrResetMultifactorByAccessToken(RemoveOrResetMultifactorAuthentication model,
            string accessToken)
        {
            Validate(new[] { model.otpauthenticator, model.googleauthenticator });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.DELETE,
                "account/2fa/authenticator", null, model.ConvertToJson(), additionalHeaders);
        }

        /// <summary>
        /// Resets the multifactor settings on the account with uid.
        /// </summary>
        /// <param name="model">Used to determine whether to reset SMS auth or multifactor auth.</param>
        /// <param name="uid">Uid for account which is getting their multifactor reset.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean that shows whether multifactor was reset.</returns>
        public ApiResponse<LoginRadiusDeleteResponse> RemoveOrResetMultifactorByUid(RemoveOrResetMultifactorAuthentication model,
            string uid)
        {
            Validate(new List<object> { model.googleauthenticator, model.otpauthenticator, uid });
            var additionalQueryParams = new QueryParameters { [nameof(uid)] = uid };
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.DELETE, "2fa/authenticator",
                additionalQueryParams, model.ConvertToJson());
        }

        /// <summary>
        /// This API is used to trigger the Multi-Factor Autentication workflow for the provided access_token.
        /// </summary>
        /// <param name="accessToken">Verifies the current session.</param>
        /// <param name="optionalParams">Additional parameters that can be passed in.</param>
        /// <returns>MultifactorAuthentication: Object for setting up multifactor authentication.</returns>
        public ApiResponse<MultifactorAuthentication> MultifactorReAuth(string accessToken, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>()
            {
                [BaseConstants.AccessTokenAuthorizationHeader] =
                    BaseConstants.AccessTokenBearerHeader + accessToken
            };
            return ConfigureAndExecute<MultifactorAuthentication>(RequestType.Authentication, HttpMethod.GET,
                "/account/reauth/2fa", null, null, additionalHeaders);
        }

        /// <summary>
        /// This API is used to re-authenticate via Multi-factor-authentication by passing the google authenticator code.
        /// </summary>
        /// <param name="accessToken">Verifies the current session.</param>
        /// <param name="googleAuthenticatorCode">Google Auth Code for session being re-validated.</param>
        /// <returns>ValidateMultifactorResponse: Object containing the re-validation token.</returns>
        public ApiResponse<ValidateMultifactorResponse> MultifactorGoogleReAuth(string accessToken, string googleAuthenticatorCode)
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>()
            {
                [BaseConstants.AccessTokenAuthorizationHeader] =
                    BaseConstants.AccessTokenBearerHeader + accessToken
            };
            var body = new BodyParameters { ["googleauthenticatorcode"] = googleAuthenticatorCode };
            return ConfigureAndExecute<ValidateMultifactorResponse>(RequestType.Authentication, HttpMethod.PUT,
                "account/reauth/2fa/googleauthenticatorcode", null, body.ConvertToJson(), additionalHeaders);
        }

        /// <summary>
        /// This API is used to re-authenticate via Multi-factor-authentication by passing the google authenticator code.
        /// </summary>
        /// <param name="accessToken">Verifies the current session.</param>
        /// <param name="backupCode">Backup Code for session being re-validated.</param>
        /// <returns>ValidateMultifactorResponse: Object containing the re-validation token.</returns>
        public ApiResponse<ValidateMultifactorResponse> MultifactorBackupCodeReAuth(string accessToken, string backupCode)
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>()
            {
                [BaseConstants.AccessTokenAuthorizationHeader] =
                    BaseConstants.AccessTokenBearerHeader + accessToken
            };
            var body = new BodyParameters { ["backupcode"] = backupCode };
            return ConfigureAndExecute<ValidateMultifactorResponse>(RequestType.Authentication, HttpMethod.PUT,
                "account/reauth/2fa/backupcode", null, body.ConvertToJson(), additionalHeaders);
        }

        /// <summary>
        /// This API is used to re-authenticate via Multi-factor-authentication by passing the google authenticator code.
        /// </summary>
        /// <param name="accessToken">Verifies the current session.</param>
        /// <param name="multifactorUpdateSettingsModel">Otp data for session being re-validated.</param>
        /// <returns>ValidateMultifactorResponse: Object containing the re-validation token.</returns>
        public ApiResponse<ValidateMultifactorResponse> MultifactorOTPReAuth(string accessToken,
            MultifactorUpdateSettingsModel multifactorUpdateSettingsModel, string smsTemplate2Fa = "")
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>()
            {
                [BaseConstants.AccessTokenAuthorizationHeader] =
                    BaseConstants.AccessTokenBearerHeader + accessToken
            };
            return ConfigureAndExecute<ValidateMultifactorResponse>(RequestType.Authentication, HttpMethod.PUT,
                "account/reauth/2fa/otp", null, multifactorUpdateSettingsModel.ConvertToJson(), additionalHeaders);
        }

        /// <summary>
        /// This API is used to re-authenticate via Multi-factor-authentication by passing the google authenticator code.
        /// </summary>
        /// <param name="accessToken">Verifies the current session.</param>
        /// <param name="multifactorUpdateSettingsModel">Password data for session being re-validated.</param>
        /// <returns>ValidateMultifactorResponse: Object containing the re-validation token.</returns>
        public ApiResponse<ValidateMultifactorResponse> MultifactorPasswordReAuth(string accessToken,
            ValidateTwoFactorByPasswordModel multifactorUpdateSettingsModel, string smsTemplate2Fa = "")
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>()
            {
                [BaseConstants.AccessTokenAuthorizationHeader] =
                    BaseConstants.AccessTokenBearerHeader + accessToken
            };
            return ConfigureAndExecute<ValidateMultifactorResponse>(RequestType.Authentication, HttpMethod.PUT,
                "account/reauth/password", null, multifactorUpdateSettingsModel.ConvertToJson(), additionalHeaders);
        }
    }
}
