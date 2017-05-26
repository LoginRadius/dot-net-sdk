using System.Collections;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.Email;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class EmailEntity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("email");

        public ApiResponse<LoginRadiusPostResponse> AddEmail(string accessToken, AddEmail email,
            string verificationUrl = "", string emailTemplate = "")
        {
            Validate(new ArrayList {email.Email, email.Type, accessToken});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            if (!string.IsNullOrWhiteSpace(verificationUrl))
                additionalQueryParams.Add("verificationUrl", verificationUrl);
            if (!string.IsNullOrWhiteSpace(emailTemplate)) additionalQueryParams.Add("emailTemplate", emailTemplate);
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Post,
                _resoucePath.ToString(),
                additionalQueryParams, email.ConvertToJson());
        }

        public ApiResponse<LoginRadiusDeleteResponse> RemoveEmail(string accessToken, string email)
        {
            Validate(new ArrayList {email});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            var body = new BodyParameters {["email"] = email};

            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.Delete,
                _resoucePath.ToString(),
                additionalQueryParams, body.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse> VerifyEmail(string vToken, string url,
            string welcomeEmailTemplate = "")
        {
            Validate(new ArrayList {vToken, url});
            var additionalQueryParams = new QueryParameters {["VerificationToken"] = vToken, ["url"] = url};
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
                additionalQueryParams.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Get,
                _resoucePath.ToString(),
                additionalQueryParams);
        }

        public ApiResponse<LogiinRadiusExistsResponse> CheckEmailAvailablity(string email)
        {
            Validate(new ArrayList {email});
            var additionalQueryParams = new QueryParameters {["email"] = email};
            return ConfigureAndExecute<LogiinRadiusExistsResponse>(RequestType.Authentication, HttpMethod.Get,
                _resoucePath.ToString(),
                additionalQueryParams);
        }
    }
}