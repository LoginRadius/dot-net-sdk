using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.CustomerAuthentication.Phone;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class PasswordLessLogin : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("account");

        public ApiResponse<LoginRadiusPostResponse> PasswordLessLoginByEmail(string email, string passwordlesslogintemplate, string verificationUrl)
        {
            Validate(new [] { email});
            var additionalQueryParams = new QueryParameters
            {
                ["email"] = email,
                ["passwordlesslogintemplate"] = passwordlesslogintemplate,
                ["verificationUrl"] = verificationUrl,
            };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET, "login/passwordlesslogin/email", additionalQueryParams);
        }


        public ApiResponse<LoginRadiusPostResponse> PasswordLessLoginByUserName(string username, string passwordlesslogintemplate,  string verificationUrl)
        {
            Validate(new [] { username, username});
            var additionalQueryParams = new QueryParameters
            {
                ["username"] = username, 
                ["passwordlesslogintemplate"] = passwordlesslogintemplate,
                ["verificationUrl"] = verificationUrl,
            };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET, "login/passwordlesslogin/email", additionalQueryParams);
        }
        public ApiResponse<LoginResponse> PasswordLessLoginVerification(string verificationtoken,string welcomeEmailTemplate="")
        {
            Validate(new [] { verificationtoken });
            var additionalQueryParams = new QueryParameters
            {   ["welcomeEmailTemplate"] = welcomeEmailTemplate,
                ["verificationtoken"] = verificationtoken,
            };
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.GET, "login/passwordlesslogin/email/verify", additionalQueryParams);

        }

        public ApiResponse<ResendOtpResponse> PhoneSendOneTimePasscode(string phone, string smstemplate="")
        {
            Validate(new[] { phone});
            var additionalQueryParams = new QueryParameters
            {
                ["phone"] = phone,
                ["smstemplate"] = smstemplate,
            };
            return ConfigureAndExecute<ResendOtpResponse>(RequestType.Authentication, HttpMethod.GET, "login/passwordlesslogin/otp", additionalQueryParams);

        }

        public ApiResponse<LoginResponse> PhoneLoginUsingOneTimePasscode(PhoneOtpModel phoneOtpModel, string smstemplate="")
        {
           
            var additionalQueryParams = new QueryParameters
            {
              ["smstemplate"] = smstemplate
            };
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.PUT, "login/passwordlesslogin/otp/verify", additionalQueryParams,phoneOtpModel.ConvertToJson());

        }
    }
}