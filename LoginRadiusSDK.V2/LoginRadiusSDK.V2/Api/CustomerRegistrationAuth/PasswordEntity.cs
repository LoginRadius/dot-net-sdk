using System.Collections;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.Password;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class PasswordEntity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("password");

        public ApiResponse<LoginRadiusPostResponse> ForgotPassword(string email,
            LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new ArrayList {email});
            var additionalQueryParams = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(optionalParams.ResetPasswordUrl))
                additionalQueryParams.Add("resetPasswordUrl", optionalParams.ResetPasswordUrl);
            if (!string.IsNullOrWhiteSpace(optionalParams.EmailTemplate))
                additionalQueryParams.Add("emailTemplate", optionalParams.EmailTemplate);

            var bodyparametre = new BodyParameters {["email"] = email};
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Post,
                _resoucePath.ToString(),
                additionalQueryParams, bodyparametre.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse<SmsResponseData>> ForgotPasswordByOtp(string phone,
            LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new ArrayList {phone});
            var additionalQueryParams = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(optionalParams.SmsTemplate))
                additionalQueryParams.Add("SmsTemplate", optionalParams.SmsTemplate);
            var bodyParams = new BodyParameters {["phone"] = phone};
            return ConfigureAndExecute<LoginRadiusPostResponse<SmsResponseData>>(RequestType.Authentication,
                HttpMethod.Post, _resoucePath.ChildObject("otp").ToString(),
                additionalQueryParams, bodyParams.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse> ReSetPassword(ReSetPasswordModel reSetPasswordModel)
        {
            Validate(new ArrayList {reSetPasswordModel.Password, reSetPasswordModel.VToken});
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Put,
                _resoucePath.ToString(),
                null, reSetPasswordModel.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse> ReSetPasswordByOtp(ResetPasswordbyOtpModel reSetPassword)
        {
            Validate(new ArrayList {reSetPassword.Password, reSetPassword.Otp, reSetPassword.Phone});
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Put,
                _resoucePath.ChildObject("otp").ToString(),
                null, reSetPassword.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse> ChangePassword(string accessToken,
            ChangePasswordModel changePasswordModel)
        {
            Validate(new ArrayList {accessToken, changePasswordModel.OldPassword, changePasswordModel.NewPassword});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            var PasswordModel = new BodyParameters
            {
                ["OldPassword"] = changePasswordModel.OldPassword,
                ["NewPassword"] = changePasswordModel.NewPassword
            };


            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Put,
                _resoucePath.ToString(),
                additionalQueryParams, PasswordModel.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse> ResetPasswordBySecurityAnswer(
            ResetPasswordBySecurityAnswerModel resetPasswordModel)
        {
            Validate(new ArrayList
            {
                resetPasswordModel.SecurityAnswer,
                resetPasswordModel.Password,
                resetPasswordModel.UserId
            });
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Put,
                _resoucePath.ChildObject("securityanswer").ToString(),
                null, resetPasswordModel.ConvertToJson());
        }
    }
}