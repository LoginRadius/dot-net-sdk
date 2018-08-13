using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;
using System.Collections.Generic;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class PhoneEntity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("phone");

        public ApiResponse<LogiinRadiusExistsResponse> CheckPhoneAvailablity(string phone)
        {
            Validate(new [] {phone});
            var additionalQueryParams = new QueryParameters {["phone"] = phone};
            return ConfigureAndExecute<LogiinRadiusExistsResponse>(RequestType.Authentication, HttpMethod.GET,
                _resoucePath.ToString(),
                additionalQueryParams);
        }
       
        public ApiResponse<LoginRadiusPostResponse<PhoneUpsertResponse>> UpSertPhone(string accessToken, string phone,
            string smsTemplate = "")
        {
            Validate(new [] {accessToken, phone});
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            var additionalQueryParams = new QueryParameters ();

            var bodyeryParams = new BodyParameters {["phone"] = phone};


            if (!string.IsNullOrWhiteSpace(smsTemplate)) additionalQueryParams["smsTemplate"] = smsTemplate;
            return ConfigureAndExecute<LoginRadiusPostResponse<PhoneUpsertResponse>>(RequestType.Authentication,
                HttpMethod.PUT, _resoucePath.ToString(),
                additionalQueryParams, bodyeryParams.ConvertToJson(),additionalHeaders);
        }

        public ApiResponse<LoginRadiusPostResponse> VerifyOtpByAccessToken(string accessToken, string otp,
            string smsTemplate = "")
        {
            Validate(new [] {accessToken, otp});
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            var additionalQueryParams = new QueryParameters { ["otp"] = otp};
            if (!string.IsNullOrWhiteSpace(smsTemplate)) additionalQueryParams["smsTemplate"] = smsTemplate;
            var pattern = _resoucePath.ChildObject("otp").ToString();
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT, pattern,
                additionalQueryParams,null,additionalHeaders);
        }

        public ApiResponse<LoginResponse> VerifyOtp(string phoneNumber, string otp, string smsTemplate = "")
        {
            Validate(new [] {phoneNumber, otp});
            var additionalQueryParams = new QueryParameters {["Otp"] = otp};

            var bodyParams = new BodyParameters {["phone"] = phoneNumber};
            if (!string.IsNullOrWhiteSpace(smsTemplate)) additionalQueryParams["smsTemplate"] = smsTemplate;
            var pattern = _resoucePath.ChildObject("otp").ToString();
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.PUT, pattern,
                additionalQueryParams, bodyParams.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse> ResendOtpByAccessToken(string accessToken, string phoneNumber,
            string smsTemplate = "")
        {
            Validate(new [] {phoneNumber});
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            var additionalQueryParams = new QueryParameters ();
            if (!string.IsNullOrWhiteSpace(smsTemplate)) additionalQueryParams["smsTemplate"] = smsTemplate;
            var pattern = _resoucePath.ChildObject("otp").ToString();
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.POST, pattern,
                additionalQueryParams, phoneNumber,additionalHeaders);
        }

        public ApiResponse<ResendOtpResponse> ResendOtp(string phoneNumber, string smsTemplate = "")
        {
            Validate(new [] {phoneNumber});
            var bodyParams = new BodyParameters {["phone"] = phoneNumber};
            var additionalQueryParams = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(smsTemplate)) additionalQueryParams["smsTemplate"] = smsTemplate;
            var pattern = _resoucePath.ChildObject("otp").ToString();
            return ConfigureAndExecute<ResendOtpResponse>(RequestType.Authentication, HttpMethod.POST, pattern,
                additionalQueryParams, bodyParams.ConvertToJson());
        }

        public ApiResponse<LoginRadiusDeleteResponse> RemovePhoneIdByAccessToken(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.DELETE,
                _resoucePath.ToString(), null,null,additionalHeaders);
        }
    }
}