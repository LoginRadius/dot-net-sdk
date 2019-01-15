using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;
using Newtonsoft.Json.Linq;
using LoginRadiusSDK.V2.Models.CustomerAuthentication.Login;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class OneTouchLoginApi : LoginRadiusResource
    {

        /// <summary>
        /// This API is used to send a link to a specified email for a frictionless login/registration.
        /// </summary>
        /// <param name="oneTouchEmail">Object containing client guid, email and other login info.</param>
        /// <param name="redirectUrl">Url where the user will redirect after success authentication.</param>
        /// <param name="oneTouchLoginEmailTemplate">Name of the One Touch Login Email Template.</param>
        /// <param name="welcomeEmailTemplate">Name of the Welcome Email Template.</param>
        /// <returns>LoginRadiusPostResponse: Boolean that shows whether the email for one touch login was sent.</returns>
        public ApiResponse<LoginRadiusPostResponse> OneTouchLoginByEmail(OneTouchEmailLoginModel oneTouchEmail, string redirectUrl = "",
            string oneTouchLoginEmailTemplate = "", string welcomeEmailTemplate = "")
        {
            Validate(new[] { oneTouchEmail.email, oneTouchEmail.clientguid });
            var additionalQueryParams = new QueryParameters
            {
                ["redirecturl"] = redirectUrl,
                ["onetouchloginemailtemplate"] = oneTouchLoginEmailTemplate,
                ["welcomeemailtemplate"] = welcomeEmailTemplate
            };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.POST, 
                "onetouchlogin/email", additionalQueryParams, oneTouchEmail.ConvertToJson());
        }

        /// <summary>
        /// This API is used to send a link to a specified email for a frictionless login/registration.
        /// </summary>
        /// <param name="oneTouchPhone">Object containing phone number and other login info.</param>
        /// <param name="smsTemplate">Name of template for SMS.</param>
        /// <returns>ResendOtpResponse: Object containing SMS details.</returns>
        public ApiResponse<ResendOtpResponse> OneTouchLoginByPhone(OneTouchPhoneLoginModel oneTouchPhone, string smsTemplate = "")
        {
            Validate(new[] { oneTouchPhone.phone });
            var additionalQueryParams = new QueryParameters
            {
                ["smstemplate"] = smsTemplate
            };
            return ConfigureAndExecute<ResendOtpResponse>(RequestType.Authentication, HttpMethod.POST,
                "onetouchlogin/phone", additionalQueryParams, oneTouchPhone.ConvertToJson());
        }

        /// <summary>
        /// This API verifies the provided token for One Touch Login.
        /// </summary>
        /// <param name="verificationToken">Token obtained from one touch email login email.</param>
        /// <param name="welcomeEmailTemplate">Name of template for welcome email.</param>
        /// <returns>OneTouchEmailVerificationModel: Booleans for token verification.</returns>
        public ApiResponse<OneTouchEmailVerificationModel> OneTouchLoginEmailVerification(string verificationToken, string welcomeEmailTemplate = "")
        {
            Validate(new[] { verificationToken });
            var additionalQueryParams = new QueryParameters
            {
                ["verificationtoken"] = verificationToken,
                ["welcomeemailtemplate"] = welcomeEmailTemplate
            };
            return ConfigureAndExecute<OneTouchEmailVerificationModel>(RequestType.Authentication, HttpMethod.GET,
                "email/smartlogin", additionalQueryParams);
        }

        /// <summary>
        /// This API verifies the OTP for One Touch Login.
        /// </summary>
        /// <param name="phone">Phone number being logged in.</param>
        /// <param name="otp">OTP being verified.</param>
        /// <param name="smsTemplate">Name of SMS template.</param>
        /// <returns>LoginResponse: LoginRadius profile object with access token.</returns>
        public ApiResponse<LoginResponse> OneTouchLoginOtpVerification(string phone, string otp, string smsTemplate = "")
        {
            Validate(new[] { phone, otp });
            var payload = new JObject {{"phone", phone}};
            var additionalQueryParams = new QueryParameters
            {
                ["otp"] = otp,
                ["smstemplate"] = smsTemplate
            };
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.PUT, 
                "onetouchlogin/phone/verify", additionalQueryParams, payload.ToString());
        }
    }
}
