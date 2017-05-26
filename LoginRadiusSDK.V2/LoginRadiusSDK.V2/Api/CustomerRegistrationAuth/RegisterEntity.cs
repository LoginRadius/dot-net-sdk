using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using System.Collections;
using static LoginRadiusSDK.V2.Entity.LoginRadiusSecureOneTimeToken;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class RegisterEntity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("register");

        public ApiResponse<LoginRadiusPostResponse> RegisterCustomer(UserIdentityCreateModel socialUserProfile,
            LoginRadiusApiOptionalParams optionalParams, SottDetails _SottDetails)
        {
            var additionalQueryParams = new QueryParameters();
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            var timediffrence = new QueryParameters {["timedifference"] = _SottDetails.Sott.TimeDifference};

            if (_SottDetails.Sott.StartTime == null)
            {
                ApiResponse<SottDetails> sottresponse =
                    ConfigureAndExecute<SottDetails>(RequestType.ServerInfo, HttpMethod.Get, null, timediffrence);

                if (sottresponse.Response != null)
                {
                    _SottDetails = sottresponse.Response;
                }
            }

            additionalQueryParams.Add("sott", GetSott(_SottDetails));
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Post,
                _resoucePath.ToString(),
                additionalQueryParams, socialUserProfile.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse> ReSendVerificationEmail(string email, string verificationUrl = "",
            string emailTemplate = "")
        {
            var additionalQueryParams = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(verificationUrl))
                additionalQueryParams.Add("verificationUrl", verificationUrl);
            if (!string.IsNullOrWhiteSpace(emailTemplate)) additionalQueryParams.Add("emailTemplate", emailTemplate);
            var bodyParams = new BodyParameters {["Email"] = email};
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Put,
                _resoucePath.ToString(),
                additionalQueryParams, bodyParams.ConvertToJson());
        }

        public ApiResponse<LoginResponse> RegistrationWithRecaptcha(string apikey, LoginRadiusAccountUpdateModel model)
        {
            Validate(new ArrayList {apikey});
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.Post, "register/captcha",
                model.ConvertToJson());
        }
    }
}