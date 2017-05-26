using System.Collections;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class PhoneEntity : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("phone");

        public ApiResponse<LogiinRadiusExistsResponse> CheckPhoneAvailablity(string phone)
        {
            Validate(new ArrayList {phone});
            var additionalQueryParams = new QueryParameters {["phone"] = phone};
            return ConfigureAndExecute<LogiinRadiusExistsResponse>(RequestType.Authentication, HttpMethod.Get,
                _resoucePath.ToString(),
                additionalQueryParams);
        }

        public ApiResponse<LoginRadiusPostResponse<PhoneUpsertResponse>> UpSertPhone(string accessToken, string phone,
            string smsTemplate = "")
        {
            Validate(new ArrayList {accessToken, phone});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};

            var bodyeryParams = new BodyParameters {["phone"] = phone};


            if (!string.IsNullOrWhiteSpace(smsTemplate)) additionalQueryParams["smsTemplate"] = smsTemplate;
            return ConfigureAndExecute<LoginRadiusPostResponse<PhoneUpsertResponse>>(RequestType.Authentication,
                HttpMethod.Put, _resoucePath.ToString(),
                additionalQueryParams, bodyeryParams.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse> VerifyOtpByAccessToken(string accessToken, string otp,
            string smsTemplate = "")
        {
            Validate(new ArrayList {accessToken, otp});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken, ["otp"] = otp};
            if (!string.IsNullOrWhiteSpace(smsTemplate)) additionalQueryParams["smsTemplate"] = smsTemplate;
            var pattern = _resoucePath.ChildObject("otp").ToString();
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Put, pattern,
                additionalQueryParams);
        }

        public ApiResponse<LoginResponse> VerifyOtp(string phoneNumber, string otp, string smsTemplate = "")
        {
            Validate(new ArrayList {phoneNumber, otp});
            var additionalQueryParams = new QueryParameters {["Otp"] = otp};

            var bodyParams = new BodyParameters {["phone"] = phoneNumber};
            if (!string.IsNullOrWhiteSpace(smsTemplate)) additionalQueryParams["smsTemplate"] = smsTemplate;
            var pattern = _resoucePath.ChildObject("otp").ToString();
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.Put, pattern,
                additionalQueryParams, bodyParams.ConvertToJson());
        }

        public ApiResponse<LoginRadiusPostResponse> ResendOtpByAccessToken(string accessToken, string phoneNumber,
            string smsTemplate = "")
        {
            Validate(new ArrayList {phoneNumber});
            var additionalQueryParams = new QueryParameters {["access_token"] = accessToken};
            if (!string.IsNullOrWhiteSpace(smsTemplate)) additionalQueryParams["smsTemplate"] = smsTemplate;
            var pattern = _resoucePath.ChildObject("otp").ToString();
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Post, pattern,
                additionalQueryParams, phoneNumber);
        }

        public ApiResponse<ResendOtpResponse> ResendOtp(string phoneNumber, string smsTemplate = "")
        {
            Validate(new ArrayList {phoneNumber});
            var bodyParams = new BodyParameters {["phone"] = phoneNumber};
            var additionalQueryParams = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(smsTemplate)) additionalQueryParams["smsTemplate"] = smsTemplate;
            var pattern = _resoucePath.ChildObject("otp").ToString();
            return ConfigureAndExecute<ResendOtpResponse>(RequestType.Authentication, HttpMethod.Post, pattern,
                additionalQueryParams, bodyParams.ConvertToJson());
        }
    }
}