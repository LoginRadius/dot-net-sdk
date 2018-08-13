using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.CustomerAuthentication.Email;
using LoginRadiusSDK.V2.Models.Email;
using LoginRadiusSDK.V2.Util;
using System.Collections.Generic;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class EmailEntity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("email");

        public ApiResponse<LoginRadiusPostResponse> AddEmail(string access_token, AddEmail email,
            string verificationUrl = "", string emailTemplate = "")
        {
            Validate(new [] {email.Email, email.Type, access_token });
            var additionalQueryParams = new QueryParameters();
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + access_token };
            if (!string.IsNullOrWhiteSpace(verificationUrl))
                additionalQueryParams.Add("verificationUrl", verificationUrl);
            if (!string.IsNullOrWhiteSpace(emailTemplate)) additionalQueryParams.Add("emailTemplate", emailTemplate);
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.POST,
                _resoucePath.ToString(), additionalQueryParams, email.ConvertToJson(), additionalHeaders);
        }

        public ApiResponse<LoginRadiusDeleteResponse> RemoveEmail(string access_token, string email)
        {
            Validate(new [] { access_token, email});
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + access_token };
            var body = new BodyParameters {["email"] = email};

            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.DELETE,
                _resoucePath.ToString(),null, body.ConvertToJson(),additionalHeaders);
        }

        public ApiResponse<LoginRadiusPostResponse> VerifyEmail(string vToken, string url,
            string welcomeEmailTemplate = "")
        {
            Validate(new [] {vToken, url});
            var additionalQueryParams = new QueryParameters {["VerificationToken"] = vToken, ["url"] = url};
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
                additionalQueryParams.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET,
                _resoucePath.ToString(),
                additionalQueryParams);
        }

        public ApiResponse<LoginRadiusPostResponse<Data>> VerifyEmailByOtp(VerifyEmailModel verifyEmailModel,string url="",
           string welcomeEmailTemplate = "")
        {
            Validate(new[] { verifyEmailModel.email ,verifyEmailModel.otp });
            var additionalQueryParams = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
                additionalQueryParams.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            if (!string.IsNullOrWhiteSpace(url))
                additionalQueryParams.Add("url", url);
            return ConfigureAndExecute<LoginRadiusPostResponse<Data>>(RequestType.Authentication, HttpMethod.PUT,
                _resoucePath.ToString(), additionalQueryParams,verifyEmailModel.ConvertToJson());
        }

        public ApiResponse<LogiinRadiusExistsResponse> CheckEmailAvailablity(string email)
        {
            Validate(new [] {email});
            var additionalQueryParams = new QueryParameters {["email"] = email};
            return ConfigureAndExecute<LogiinRadiusExistsResponse>(RequestType.Authentication, HttpMethod.GET,
                _resoucePath.ToString(),
                additionalQueryParams);
        }
    }
}