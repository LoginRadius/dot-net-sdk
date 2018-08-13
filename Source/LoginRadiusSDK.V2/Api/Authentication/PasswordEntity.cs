using System.Collections.Generic;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.CustomerAuthentication.Password;
using LoginRadiusSDK.V2.Models.Password;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class PasswordEntity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("password");

        public ApiResponse<LoginRadiusPostResponse> ForgotPassword(string email, string resetPasswordUrl ="" , string emailTemplate = "")
        {
            Validate(new [] {email, resetPasswordUrl });
            var additionalQueryParams = new QueryParameters();
                additionalQueryParams.Add("resetPasswordUrl", resetPasswordUrl);
                additionalQueryParams.Add("emailTemplate", emailTemplate);

            var bodyparametre = new BodyParameters {["email"] = email};
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.POST,
                _resoucePath.ToString(),
                additionalQueryParams, bodyparametre.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse<SmsResponseData>> ForgotPasswordByOtp(string phone,
            LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new [] {phone});
            var additionalQueryParams = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(optionalParams.SmsTemplate))
                additionalQueryParams.Add("SmsTemplate", optionalParams.SmsTemplate);
            var bodyParams = new BodyParameters {["phone"] = phone};
            return ConfigureAndExecute<LoginRadiusPostResponse<SmsResponseData>>(RequestType.Authentication,
                HttpMethod.POST, _resoucePath.ChildObject("otp").ToString(),
                additionalQueryParams, bodyParams.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse> ReSetPassword(ReSetPasswordModel reSetPasswordModel)
        {
            Validate(new [] {reSetPasswordModel.Password, reSetPasswordModel.VToken});
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT,
                _resoucePath.ChildObject("reset").ToString(),
                null, reSetPasswordModel.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse> PhoneReSetPasswordByOtp(ResetPasswordbyOtpModel reSetPassword)
        {
            Validate(new [] {reSetPassword.Password, reSetPassword.Otp, reSetPassword.Phone});
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT,
                _resoucePath.ChildObject("otp").ToString(),
                null, reSetPassword.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse> AuthResetPasswordByOtp(ResetPasswordByEmailAndOtpModel resetPassword)
        {
            Validate(new[] { resetPassword.password, resetPassword.otp, resetPassword.email });
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT, _resoucePath.ChildObject("reset").ToString(),
                null, resetPassword.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse> ChangePassword(string accessToken,
            ChangePasswordModel changePasswordModel)
        {
            Validate(new [] {accessToken, changePasswordModel.OldPassword, changePasswordModel.NewPassword});
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            var PasswordModel = new BodyParameters
            {
                ["OldPassword"] = changePasswordModel.OldPassword,
                ["NewPassword"] = changePasswordModel.NewPassword
            };


            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT,
                _resoucePath.ChildObject("change").ToString(),
                null, PasswordModel.ConvertToJson(),additionalHeaders);
        }

        public ApiResponse<LoginRadiusPostResponse> ResetPasswordBySecurityAnswerAndEmail(
            ResetPasswordBySecurityAnswerModelAndEmail resetPasswordModel)
        {
            Validate(new List<object>
            {
                resetPasswordModel.SecurityAnswer,
                resetPasswordModel.password,
                resetPasswordModel.email
            });
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT,
                _resoucePath.ChildObject("securityanswer").ToString(),
                null, resetPasswordModel.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse> ResetPasswordBySecurityAnswerAndUserName(
           ResetPasswordBySecurityAnswerModelAndUserName resetPasswordModel)
        {
            Validate(new List<object>
            {
                resetPasswordModel.SecurityAnswer,
                resetPasswordModel.password,
                resetPasswordModel.username
            });
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT,
                _resoucePath.ChildObject("securityanswer").ToString(),
                null, resetPasswordModel.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse> ResetPasswordBySecurityAnswerAndPhone(
           ResetPasswordBySecurityAnswerModelAndPhone resetPasswordModel)
        {
            Validate(new List<object>
            {
                resetPasswordModel.SecurityAnswer,
                resetPasswordModel.password,
                resetPasswordModel.phone
            });
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT,
                _resoucePath.ChildObject("securityanswer").ToString(),
                null, resetPasswordModel.ConvertToJson());
        }
    }
}