using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api.Authentication
{
   public class OneTouchLoginEntity : LoginRadiusResource
    {

        public ApiResponse<LoginRadiusPostResponse> OneTouchLoginByEmail(string email, string clientguid, string name="",string onetouchloginemailtemplate = "", string welcomeemailtemplate = "", string redirecturl = "")
        {
            Validate(new[] { email, clientguid });
            var additionalQueryParams = new QueryParameters
            {
                ["email"] = email,
                ["clientguid"] = clientguid,
                ["name"] = name,
                ["onetouchloginemailtemplate"] = onetouchloginemailtemplate,
                ["welcomeemailtemplate"] = welcomeemailtemplate,
                ["redirecturl"] = redirecturl
            };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET, "onetouchlogin/email", additionalQueryParams);
        }

        public ApiResponse<ResendOtpResponse> OneTouchLoginByPhone(string phone, string name = "", string smstemplate = "")
        {
            Validate(new[] { phone });
            var additionalQueryParams = new QueryParameters
            {
                ["phone"] = phone,
                ["name"] = name,
                ["smstemplate"] = smstemplate
            };
            return ConfigureAndExecute<ResendOtpResponse>(RequestType.Authentication, HttpMethod.GET, "onetouchlogin/phone", additionalQueryParams);
        }


        public ApiResponse<LoginResponse> OneTouchLoginOtpVerification(string phone, string otp , string smstemplate = "")
        {
            Validate(new[] { phone,otp });
            var payload = new JObject();
            payload.Add("phone", phone);
            var additionalQueryParams = new QueryParameters
            {
                ["otp"] = otp,
                ["smstemplate"] = smstemplate
            };
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.PUT, "onetouchlogin/phone/verify", additionalQueryParams,payload.ToString());
        }

    }
}
