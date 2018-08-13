using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.CustomerAuthentication._2FA;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class LoginEntity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("login");

        /// <summary>
        /// Login by Email and Password and API retrieves a copy of the user data.
        /// See <a href="https://docs.loginradius.com/api/v2/">LoginRadius Developer documentation</a> for more information.
        /// </summary>
        /// <param name="email">Email of the user [REQUIRED]</param>
        /// <param name="password">Password of the user [REQUIRED]</param>
        /// <param name="optionalParams">Gets or sets API optional parameters, <see cref="LoginRadiusApiOptionalParams"/></param>
        /// <param name="gRecaptchaResponse">
        /// It is only required for locked accounts when logging in. You need to pass valid a recaptcha value in api for login if account gets locked after continous n number of unsuccessful login attempts
        /// (Number of login attempts can be set through user account). Details about this feature can be located. 
        /// See <a href="https://docs.loginradius.com/api/v2/user-registration/advanced-api-usage#loginlockedtype4"/>>
        /// </param>
        /// <returns>
        /// Login Response containing accessToken and user profile data, See <a href="https://docs.loginradius.com/api/v2/user-registration/post-auth-login-by-email">PayPal Developer documentation</a> for more information.
        /// </returns>
        public ApiResponse<LoginResponse> LoginByEmail(string payload, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { payload });
            var additionalQueryParams = new QueryParameters();
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.POST, _resoucePath.ToString(), additionalQueryParams,payload);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password">Password of the user [REQUIRED]</param>
        /// <param name="optionalParams">Gets or sets API optional parameters, <see cref="LoginRadiusApiOptionalParams"/></param>
        /// <returns></returns>
        public ApiResponse<LoginResponse> LoginByUserName(string payload, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { payload });
            var additionalQueryParams = new QueryParameters();
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.POST, _resoucePath.ToString(),
                additionalQueryParams,payload);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="password"></param>
        /// <param name="optionalParams"></param>
        /// <returns></returns>
        public ApiResponse<LoginResponse> LoginByPhone(string payload, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { payload });
            var additionalQueryParams = new QueryParameters();
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.POST,
                _resoucePath.ToString(),additionalQueryParams, payload);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="otp"></param>
        /// <param name="optionalParams"></param>
        /// <returns></returns>
        public ApiResponse<LoginResponse> LoginByOneTimePassCode(string phone, string otp,
            LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { phone, otp });
            var additionalQueryParams = new QueryParameters { { "phone", phone }, { "otp", otp } };
            if (!string.IsNullOrWhiteSpace(optionalParams.SmsTemplate))
                additionalQueryParams.Add("SmsTemplate", optionalParams.SmsTemplate);
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.GET,
                _resoucePath.ToString(),
                additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="optionalParams"></param>
        /// <returns></returns>
        public ApiResponse<TwoFactorAuthenticationResponse<LoginRadiusUserIdentity>>
            TwoFactorAuthLoginByEmail(string email, string password,
                LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { email, password });
            var additionalQueryParams = new QueryParameters { { "email", email }, { "password", password } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return
                ConfigureAndExecute
                    <TwoFactorAuthenticationResponse<LoginRadiusUserIdentity>>(
                        RequestType.Authentication,
                        HttpMethod.GET, _resoucePath.ChildObject("2FA").ToString(), additionalQueryParams);
        }

        public ApiResponse<TwoFactorAuthenticationResponse<LoginRadiusUserIdentity>>
            TwoFactorAuthLoginByUsername(string username, string password,
                LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { username, password });
            var additionalQueryParams = new QueryParameters { { "username", username }, { "password", password } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return
                ConfigureAndExecute
                    <TwoFactorAuthenticationResponse<LoginRadiusUserIdentity>>(
                        RequestType.Authentication,
                        HttpMethod.GET, _resoucePath.ChildObject("2FA").ToString(), additionalQueryParams);
        }

        public ApiResponse<TwoFactorAuthenticationResponse<LoginRadiusUserIdentity>> TwoFactorAuthLoginByPhone(string phone, string password,
            LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { phone, password });
            var additionalQueryParams = new QueryParameters { { "phone", phone }, { "password", password } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return ConfigureAndExecute<TwoFactorAuthenticationResponse<LoginRadiusUserIdentity>>(RequestType.Authentication,
                        HttpMethod.GET, _resoucePath.ChildObject("2FA").ToString(), additionalQueryParams);
        }

        public ApiResponse<LoginResponse<LoginRadiusUserIdentity>>
            TwoFactorLoginAuthentication(string twoFactorAuthenticationToken,
                TwoFactorAuthModel twoFactorLoginAuthentication,
                LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { twoFactorAuthenticationToken });
            var additionalQueryParams = new QueryParameters
            {
                {"TwoFactorAuthenticationToken", twoFactorAuthenticationToken}
            };
            additionalQueryParams.AddOptionalParamsRange(twoFactorLoginAuthentication);
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return
                ConfigureAndExecute
                    <LoginResponse<LoginRadiusUserIdentity>>(
                        RequestType.Authentication,
                        HttpMethod.GET, _resoucePath.ChildObject("2FA/verification").ToString(), additionalQueryParams);
        }

        public ApiResponse<ResendOtpResponse> SendOneTimePassCode(string phone, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { phone });
            var additionalQueryParams = new QueryParameters
            {
                {"phone", phone}
            };
            if (!string.IsNullOrWhiteSpace(optionalParams.SmsTemplate)) additionalQueryParams.Add("SmsTemplate", optionalParams.SmsTemplate);
            return ConfigureAndExecute<ResendOtpResponse>(RequestType.Authentication, HttpMethod.GET, _resoucePath.ChildObject("otp").ToString(), 
                additionalQueryParams);
        }

        public ApiResponse<SmsResponseData> TwoFactorAuthUpdatePhoneNumber(string secondFactorAuthenticationToken, TwoFactorPhoneAuthModel authModel, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { secondFactorAuthenticationToken });

            var additionalQueryParams = new QueryParameters
            {
                {"SecondFactorAuthenticationToken", secondFactorAuthenticationToken}
            };
            var body = new BodyParameters { ["PhoneNo2Fa"] = authModel.PhoneNo2Fa };
            additionalQueryParams.AddOptionalParamsRange(authModel);
            if (!string.IsNullOrWhiteSpace(optionalParams.SmsTemplate))
                additionalQueryParams.Add("smsTemplate2FA", optionalParams.SmsTemplate2Fa);
            return ConfigureAndExecute<SmsResponseData>(RequestType.Authentication, HttpMethod.PUT, _resoucePath.ChildObject("2FA").ToString(),
                additionalQueryParams, body.ConvertToJson());
        }


        public ApiResponse<LoginRadiusPostResponse> AutoLoginbyUserName(string username, string clientguid,
            string autologinemailtemplate, string welcomeemailtemplate)
        {
            Validate(new[] { username, clientguid });
            var additionalparams = new QueryParameters { ["username"] = username, ["clientguid"] = clientguid };
            if (!string.IsNullOrEmpty(autologinemailtemplate))
                additionalparams.Add("autologinemailtemplate", autologinemailtemplate);
            if (!string.IsNullOrEmpty(welcomeemailtemplate))
                additionalparams.Add("welcomeemailtemplate", welcomeemailtemplate);
            return ConfigureAndExecute
                <LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET, "login/autologin",
                    additionalparams);
        }


        public ApiResponse<LoginRadiusPostResponse> AutoLoginbyEmail(string email, string clientguid,
           string autologinemailtemplate, string welcomeemailtemplate)
        {
            Validate(new[] { email, clientguid });
            var additionalparams = new QueryParameters { ["email"] = email, ["clientguid"] = clientguid };

            additionalparams.TryAdd(nameof(autologinemailtemplate), autologinemailtemplate);
            additionalparams.TryAdd(nameof(welcomeemailtemplate), welcomeemailtemplate);

            return ConfigureAndExecute <LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET, "login/autologin",
                    additionalparams);
        }



        public ApiResponse<LoginResponse> AutoLoginbyPing(string clientguid)
        {
            Validate(new[] { clientguid });
            var additionalparams = new QueryParameters { ["clientguid"] = clientguid };
            return ConfigureAndExecute
                <LoginResponse>(RequestType.Authentication, HttpMethod.GET, "login/autologin/ping",
                    additionalparams);
        }

        public ApiResponse<LoginRadiusUserIdentity> TwoFALoginByGoogleAuthCode(string secondfactorauthenticationtoken,string googleauthenticatorcode,  string SmsTemplate2Fa ="")
        {
            Validate(new[] { secondfactorauthenticationtoken });

            var additionalQueryParams = new QueryParameters
            {
                {"secondfactorauthenticationtoken", secondfactorauthenticationtoken}
            };
            var body = new BodyParameters { ["googleauthenticatorcode"] = googleauthenticatorcode };
            if (!string.IsNullOrWhiteSpace(SmsTemplate2Fa))
                additionalQueryParams.Add("smsTemplate2FA", SmsTemplate2Fa);
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Authentication, HttpMethod.PUT, _resoucePath.ChildObject("2FA/verification/googleauthenticatorcode").ToString(),
                additionalQueryParams, body.ConvertToJson());
        }


        public ApiResponse<LoginResponse> TwoFALoginByOtp(string secondfactorauthenticationtoken, TwoFactorUpdateSettingsModel twoFactorUpdateSettingsModel, string SmsTemplate2Fa ="")
        {
            Validate(new[] { secondfactorauthenticationtoken, twoFactorUpdateSettingsModel.otp });

            var additionalQueryParams = new QueryParameters
            {
                {"secondfactorauthenticationtoken", secondfactorauthenticationtoken}
            };
            if (!string.IsNullOrWhiteSpace(SmsTemplate2Fa))
                additionalQueryParams.Add("smsTemplate2FA", SmsTemplate2Fa);
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.PUT, _resoucePath.ChildObject("2fa/verification/otp").ToString(),
                additionalQueryParams, twoFactorUpdateSettingsModel.ConvertToJson());
        }


        public ApiResponse<LoginResponse> TwoFAValidateBackupCode(string secondfactorauthenticationtoken,string backupcode)
        {
            Validate(new[] { secondfactorauthenticationtoken, backupcode });

            var additionalQueryParams = new QueryParameters
            {
                {"secondfactorauthenticationtoken", secondfactorauthenticationtoken}
            };
            var body = new BodyParameters { ["backupcode"] = backupcode };
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.PUT, _resoucePath.ChildObject("2fa/verification/backupcode").ToString(),
                additionalQueryParams, body.ConvertToJson());
        }


    }
}