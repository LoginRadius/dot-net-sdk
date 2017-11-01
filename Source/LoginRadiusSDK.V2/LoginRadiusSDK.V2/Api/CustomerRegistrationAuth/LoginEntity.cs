using System.Collections;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class LoginEntity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("login");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="optionalParams"></param>
        /// <returns></returns>
        public ApiResponse<LoginResponse> LoginByEmail(string email, string password,
            LoginRadiusApiOptionalParams optionalParams, string g_recaptcha_response="")
        {
            Validate(new ArrayList { email, password });
            var additionalQueryParams = new QueryParameters
            {
                {"email", email},
                {"password", password},
                {"g-recaptcha-response", g_recaptcha_response}
            };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.Get,
                _resoucePath.ToString(),
                additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="optionalParams"></param>
        /// <returns></returns>
        public ApiResponse<LoginResponse> LoginByUserName(string username, string password,
            LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new ArrayList { username, password });
            var additionalQueryParams = new QueryParameters { { "username", username }, { "password", password } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.Get,
                _resoucePath.ToString(),
                additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="password"></param>
        /// <param name="optionalParams"></param>
        /// <returns></returns>
        public ApiResponse<LoginResponse> LoginByPhone(string phone, string password,
            LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new ArrayList { phone, password });
            var additionalQueryParams = new QueryParameters { { "phone", phone }, { "password", password } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.Get,
                _resoucePath.ToString(),
                additionalQueryParams);
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
            Validate(new ArrayList { phone, otp });
            var additionalQueryParams = new QueryParameters { { "phone", phone }, { "otp", otp } };
            if (!string.IsNullOrWhiteSpace(optionalParams.SmsTemplate))
                additionalQueryParams.Add("SmsTemplate", optionalParams.SmsTemplate);
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.Get,
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
            Validate(new ArrayList { email, password });
            var additionalQueryParams = new QueryParameters { { "email", email }, { "password", password } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return
                ConfigureAndExecute
                    <TwoFactorAuthenticationResponse<LoginRadiusUserIdentity>>(
                        RequestType.Authentication,
                        HttpMethod.Get, _resoucePath.ChildObject("2FA").ToString(), additionalQueryParams);
        }

        public ApiResponse<TwoFactorAuthenticationResponse<LoginRadiusUserIdentity>>
            TwoFactorAuthLoginByUsername(string username, string password,
                LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new ArrayList { username, password });
            var additionalQueryParams = new QueryParameters { { "username", username }, { "password", password } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return
                ConfigureAndExecute
                    <TwoFactorAuthenticationResponse<LoginRadiusUserIdentity>>(
                        RequestType.Authentication,
                        HttpMethod.Get, _resoucePath.ChildObject("2FA").ToString(), additionalQueryParams);
        }

        public ApiResponse<TwoFactorAuthenticationResponse<LoginRadiusUserIdentity>>
            TwoFactorAuthLoginByPhone(string phone, string password,
                LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new ArrayList { phone, password });
            var additionalQueryParams = new QueryParameters { { "phone", phone }, { "password", password } };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return
                ConfigureAndExecute
                    <TwoFactorAuthenticationResponse<LoginRadiusUserIdentity>>(
                        RequestType.Authentication,
                        HttpMethod.Get, _resoucePath.ChildObject("2FA").ToString(), additionalQueryParams);
        }






        public ApiResponse<LoginResponse<LoginRadiusUserIdentity>>
            TwoFactorLoginAuthentication(string twoFactorAuthenticationToken,
                TwoFactorAuthModel twoFactorLoginAuthentication,
                LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new ArrayList { twoFactorAuthenticationToken });
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
                        HttpMethod.Get, _resoucePath.ChildObject("2FA/verification").ToString(), additionalQueryParams);
        }

        public ApiResponse<LoginRadiusApiResponse<LoginRadiusUserIdentity>>
            SendOneTimePassCode(string phone, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new ArrayList { phone });
            var additionalQueryParams = new QueryParameters
            {
                {"phone", phone}
            };
            if (!string.IsNullOrWhiteSpace(optionalParams.SmsTemplate))
                additionalQueryParams.Add("SmsTemplate", optionalParams.SmsTemplate);
            return
                ConfigureAndExecute
                    <LoginRadiusApiResponse<LoginRadiusUserIdentity>>(
                        RequestType.Authentication,
                        HttpMethod.Get, _resoucePath.ChildObject("otp").ToString(), additionalQueryParams);
        }

        public ApiResponse<SmsResponseData>
            TwoFactorAuthUpdatePhoneNumber(string SecondFactorAuthenticationToken, TwoFactorPhoneAuthModel authModel,
                LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new ArrayList { SecondFactorAuthenticationToken });

            var additionalQueryParams = new QueryParameters
            {
                {"SecondFactorAuthenticationToken", SecondFactorAuthenticationToken}
            };
            var body = new BodyParameters { ["PhoneNo2Fa"] = authModel.PhoneNo2Fa };
            additionalQueryParams.AddOptionalParamsRange(authModel);
            if (!string.IsNullOrWhiteSpace(optionalParams.SmsTemplate))
                additionalQueryParams.Add("smsTemplate2FA", optionalParams.SmsTemplate2Fa);
            return
                ConfigureAndExecute
                    <SmsResponseData>(
                        RequestType.Authentication,
                        HttpMethod.Put, _resoucePath.ChildObject("2FA").ToString(), additionalQueryParams,
                        body.ConvertToJson());
        }


        public ApiResponse<LoginRadiusPostResponse> AutoLoginbyUserName(string username, string clientguid,
            string autologinemailtemplate, string welcomeemailtemplate)
        {
            Validate(new ArrayList { username, clientguid });
            var additionalparams = new QueryParameters { ["username"] = username, ["clientguid"] = clientguid };
            if (!string.IsNullOrEmpty(autologinemailtemplate))
                additionalparams.Add("autologinemailtemplate", autologinemailtemplate);
            if (!string.IsNullOrEmpty(welcomeemailtemplate))
                additionalparams.Add("welcomeemailtemplate", welcomeemailtemplate);
            return ConfigureAndExecute
                <LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Get, "login/autologin",
                    additionalparams);
        }


        public ApiResponse<LoginRadiusPostResponse> AutoLoginbyEmail(string email, string clientguid,
           string autologinemailtemplate, string welcomeemailtemplate)
        {
            Validate(new ArrayList { email, clientguid });
            var additionalparams = new QueryParameters { ["email"] = email, ["clientguid"] = clientguid };

            if (!string.IsNullOrEmpty(autologinemailtemplate))
                additionalparams.Add("autologinemailtemplate", autologinemailtemplate);

            if (!string.IsNullOrEmpty(welcomeemailtemplate))
                additionalparams.Add("welcomeemailtemplate", welcomeemailtemplate);
            return ConfigureAndExecute
                <LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Get, "login/autologin",
                    additionalparams);
        }



        public ApiResponse<LoginResponse> AutoLoginbyPing(string clientguid)
        {
            Validate(new ArrayList { clientguid });
            var additionalparams = new QueryParameters { ["clientguid"] = clientguid };
            return ConfigureAndExecute
                <LoginResponse>(RequestType.Authentication, HttpMethod.Get, "login/autologin/ping",
                    additionalparams);
        }
    }
}