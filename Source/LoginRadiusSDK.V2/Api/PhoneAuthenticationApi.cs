using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using System.Collections.Generic;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
using LoginRadiusSDK.V2.Models.CustomerAuthentication.Phone;
using LoginRadiusSDK.V2.Models.Password;


namespace LoginRadiusSDK.V2.Api
{
    public class PhoneAuthenticationApi : LoginRadiusResource
    {
        /// <summary>
        /// This API retrieves a copy of the user data based on the Phone.
        /// </summary>
        /// <param name="payload">Object containing data for logging in</param>
        /// <param name="optionalParams">Additional parameters that may not be needed.</param>
        /// <returns>LoginResponse: Object containing LR profile and access token.</returns>
        public ApiResponse<LoginResponse> LoginByPhone(string payload, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { payload });
            var additionalQueryParams = new QueryParameters();
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.POST,
                "login", additionalQueryParams, payload);
        }

        /// <summary>
        /// This API is used to send the OTP to reset the account password.
        /// </summary>
        /// <param name="phone">Phone number of account having password reset.</param>
        /// <param name="optionalParams">Additional parameters that may not be needed.</param>
        /// <returns>LoginRadiusPostResponse: Boolean showing whether OTP has been sent.</returns>
        public ApiResponse<LoginRadiusPostResponse<SmsResponseData>> ForgotPasswordByOtp(string phone,
            LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { phone });
            var additionalQueryParams = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(optionalParams.SmsTemplate))
                additionalQueryParams.Add("SmsTemplate", optionalParams.SmsTemplate);
            var bodyParams = new BodyParameters { ["phone"] = phone };
            return ConfigureAndExecute<LoginRadiusPostResponse<SmsResponseData>>(RequestType.Authentication,
                HttpMethod.POST, "password/otp", additionalQueryParams, bodyParams.ConvertToJson());
        }

        /// <summary>
        /// This API is used to send the OTP to reset the account password.
        /// </summary>
        /// <param name="phone">Phone number of account having password reset.</param>
        /// <param name="smsTemplate">Name of SMS template.</param>
        /// <returns>ResendOtpResponse: Object containing SMS sent details.</returns>
        public ApiResponse<ResendOtpResponse> ResendOtp(string phone, string smsTemplate = "")
        {
            Validate(new[] { phone });
            var bodyParams = new BodyParameters { ["phone"] = phone };
            var additionalQueryParams = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(smsTemplate)) additionalQueryParams["smsTemplate"] = smsTemplate;
            return ConfigureAndExecute<ResendOtpResponse>(RequestType.Authentication, HttpMethod.POST, "phone/otp",
                additionalQueryParams, bodyParams.ConvertToJson());
        }

        /// <summary>
        /// This API is used to send the OTP to reset the account password.
        /// </summary>
        /// <param name="accessToken">Session which requires the OTP to be sent.</param>
        /// <param name="phone">Phone number of account having password reset.</param>
        /// <param name="smsTemplate">Name of SMS template.</param>
        /// <returns>LoginRadiusPostResponse: Boolean showing whether OTP has been sent.</returns>
        public ApiResponse<LoginRadiusPostResponse> ResendOtpByAccessToken(string accessToken, string phone,
            string smsTemplate = "")
        {
            Validate(new[] { phone });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            var bodyParams = new BodyParameters { ["phone"] = phone };
            var additionalQueryParams = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(smsTemplate)) additionalQueryParams["smsTemplate"] = smsTemplate;
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.POST, "phone/otp",
                additionalQueryParams, bodyParams.ConvertToJson(), additionalHeaders);
        }

        /// <summary>
        /// This API registers the new users into your Cloud Storage and triggers the phone verification process.
        /// </summary>
        /// <param name="sottAuth">Sott used while creating the account.</param>
        /// <param name="loginRadiusApiOptionalParams">Optional parameters.</param>
        /// <param name="userIdentityCreateModel">Object containing information for creating a LoginRadius profile.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show that account was created.</returns>
        public ApiResponse<LoginRadiusPostResponse> PhoneUserRegistrationBySms(Sott sottAuth, 
            LoginRadiusApiOptionalParams loginRadiusApiOptionalParams, UserIdentityCreateModel userIdentityCreateModel)
        {
            var additionalparams = new QueryParameters();

            additionalparams.TryAdd(nameof(loginRadiusApiOptionalParams.VerificationUrl), loginRadiusApiOptionalParams.VerificationUrl);
            additionalparams.TryAdd(nameof(loginRadiusApiOptionalParams.SmsTemplate), loginRadiusApiOptionalParams.SmsTemplate);

            if (sottAuth.StartTime == null)
            {
                var timeDifference = new QueryParameters { [nameof(sottAuth.TimeDifference)] = sottAuth.TimeDifference };
                var sottResponse = ConfigureAndExecute<SottDetails>(RequestType.ServerInfo, HttpMethod.GET, null, timeDifference);

                if (sottResponse.Response != null) sottAuth = sottResponse.Response.Sott;
            }

            additionalparams.Add("sott", LoginRadiusSecureOneTimeToken.GetSott(sottAuth));

            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.POST, "register",
                additionalparams, userIdentityCreateModel.ConvertToJson());
        }

        /// <summary>
        /// This API verifies an account by OTP and allows the user to login.
        /// </summary>
        /// <param name="phoneOtpModel">Object that contains otp data and other info needed for verification.</param>
        /// <param name="smstemplate">SMS template name.</param>
        /// <returns>LoginResponse: Object with LR Profile and access token.</returns>
        public ApiResponse<LoginResponse> LoginUsingOtp(PhoneOtpModel phoneOtpModel, string smstemplate = "")
        {
            Validate(new[] { phoneOtpModel.phone, phoneOtpModel.otp });
            var additionalQueryParams = new QueryParameters
            {
                ["smstemplate"] = smstemplate
            };
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.PUT, 
                "login/passwordlesslogin/otp/verify", additionalQueryParams, phoneOtpModel.ConvertToJson());
        }

        /// <summary>
        /// This API checks whether a phone number exists in your LoginRadius database.
        /// </summary>
        /// <param name="phone">Phone number being checked in the database.</param>
        /// <returns>LoginRadiusExistsResponse: Boolean that is true if phone number already exists.</returns>
        public ApiResponse<LoginRadiusExistsResponse> CheckPhoneAvailability(string phone)
        {
            Validate(new[] { phone });
            var additionalQueryParams = new QueryParameters { ["phone"] = phone };
            return ConfigureAndExecute<LoginRadiusExistsResponse>(RequestType.Authentication, HttpMethod.GET,
                "phone", additionalQueryParams);
        }

        /// <summary>
        /// This API sends an OTP for logging in with a phone.
        /// </summary>
        /// <param name="phone">Phone number associated with account where otp is sent.</param>
        /// <param name="smsTemplate">SMS template name.</param>
        /// <returns>ResendOtpResponse: Object containing SMS sent details.</returns>
        public ApiResponse<ResendOtpResponse> SendOtp(string phone, string smsTemplate = "")
        {
            Validate(new[] { phone });
            var additionalQueryParams = new QueryParameters { ["phone"] = phone };
            if (!string.IsNullOrWhiteSpace(smsTemplate)) additionalQueryParams["smsTemplate"] = smsTemplate;
            return ConfigureAndExecute<ResendOtpResponse>(RequestType.Authentication, HttpMethod.GET,
                "login/passwordlesslogin/otp", additionalQueryParams);
        }

        /// <summary>
        /// Updates phone number for an active session.
        /// </summary>
        /// <param name="accessToken">Session where phone number is being updated.</param>
        /// <param name="phone">New phone number.</param>
        /// <param name="smsTemplate">SMS template name.</param>
        /// <returns>ResendOtpResponse: Object containing SMS sent details.</returns>
        public ApiResponse<LoginRadiusPostResponse<PhoneUpsertResponse>> UpdatePhone(string accessToken, string phone,
            string smsTemplate = "")
        {
            Validate(new[] { accessToken, phone });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            var additionalQueryParams = new QueryParameters();

            var bodyParams = new BodyParameters { ["phone"] = phone };
            
            if (!string.IsNullOrWhiteSpace(smsTemplate)) additionalQueryParams["smsTemplate"] = smsTemplate;
            return ConfigureAndExecute<LoginRadiusPostResponse<PhoneUpsertResponse>>(RequestType.Authentication,
                HttpMethod.PUT, "phone", additionalQueryParams, bodyParams.ConvertToJson(), additionalHeaders);
        }

        /// <summary>
        /// Resets a password using an OTP.
        /// </summary>
        /// <param name="resetPassword">Object containing data needed to send an OTP.</param>
        /// <returns>LoginRadiusPostResponse: Boolean that shows whether the OTP was sent.</returns>
        public ApiResponse<LoginRadiusPostResponse> ResetPasswordByOtp(ResetPasswordByOtpModel resetPassword)
        {
            Validate(new[] { resetPassword.Password, resetPassword.Otp, resetPassword.Phone });
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT,
                "password/otp", null, resetPassword.ConvertToJson());
        }

        /// <summary>
        /// Verifies a phone using an OTP.
        /// </summary>
        /// <param name="phone">Phone number being verified.</param>
        /// <param name="otp">OTP being verified.</param>
        /// <param name="smsTemplate">Name of SMS template.</param>
        /// <returns>LoginResponse: Object containing a LR profile and access token.</returns>
        public ApiResponse<LoginResponse> VerifyOtp(string phone, string otp, string smsTemplate = "")
        {
            Validate(new[] { phone, otp });
            var additionalQueryParams = new QueryParameters { ["otp"] = otp };

            var bodyParams = new BodyParameters { ["phone"] = phone };
            if (!string.IsNullOrWhiteSpace(smsTemplate)) additionalQueryParams["smsTemplate"] = smsTemplate;
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.PUT, "phone/otp",
                additionalQueryParams, bodyParams.ConvertToJson());
        }

        /// <summary>
        /// Verifies a phone for an active session.
        /// </summary>
        /// <param name="accessToken">Session where phone number is being verified.</param>
        /// <param name="otp">OTP being verified..</param>
        /// <param name="smsTemplate">SMS template name.</param>
        /// <returns>LoginRadiusPostResponse: Boolean showing whether the phone number was verified.</returns>
        public ApiResponse<LoginRadiusPostResponse> VerifyOtpByAccessToken(string accessToken, string otp,
            string smsTemplate = "")
        {
            Validate(new[] { accessToken, otp });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            var additionalQueryParams = new QueryParameters { ["otp"] = otp };
            if (!string.IsNullOrWhiteSpace(smsTemplate)) additionalQueryParams["smsTemplate"] = smsTemplate;
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT, "phone/otp",
                additionalQueryParams, null, additionalHeaders);
        }

        /// <summary>
        /// Invalidates a phone's verification status.
        /// </summary>
        /// <param name="uid">Uid for account getting phone number invalidated.</param>
        /// <returns>LoginRadiusPostResponse: Boolean that shows if phone number was invalidated.</returns>
        public ApiResponse<LoginRadiusPostResponse> ResetPhoneIdVerification(string uid)
        {
            Validate(new[] { uid });
            var pattern = new LoginRadiusResourcePath("{0}/invalidatephone").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid });
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Identity, HttpMethod.PUT, resourcePath);
        }

        /// <summary>
        /// Removes a phone number from an account using active session.
        /// </summary>
        /// <param name="accessToken">Session where phone number is being removed.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean that shows if phone ID was removed from account.</returns>
        public ApiResponse<LoginRadiusDeleteResponse> RemovePhoneIdByAccessToken(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.DELETE,
                "phone", null,null,additionalHeaders);
        }
    }
}
