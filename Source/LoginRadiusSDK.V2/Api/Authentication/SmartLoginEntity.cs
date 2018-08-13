using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;
using System;
using System.Collections.Generic;
using System.Text;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api.Authentication
{
   public class SmartLoginEntity : LoginRadiusResource
    {
        public ApiResponse<LoginRadiusPostResponse> SmartLoginByEmail(string email,string clientguid, string smartloginemailtemplate="", string welcomeemailtemplate="",string redirecturl="")
        {
            Validate(new[] { email, clientguid });
            var additionalQueryParams = new QueryParameters
            {
                ["email"] = email,
                ["clientguid"] = clientguid,
                ["smartloginemailtemplate"] = smartloginemailtemplate,
                ["welcomeemailtemplate"] = welcomeemailtemplate,
                ["redirecturl"] = redirecturl
            };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET, "login/smartlogin", additionalQueryParams);
        }



        public ApiResponse<LoginRadiusPostResponse> SmartLoginByUserName(string username, string clientguid, string smartloginemailtemplate = "", string welcomeemailtemplate = "", string redirecturl = "")
        {
            Validate(new[] { username, clientguid });
            var additionalQueryParams = new QueryParameters
            {
                ["username"] = username,
                ["clientguid"] = clientguid,
                ["smartloginemailtemplate"] = smartloginemailtemplate,
                ["welcomeemailtemplate"] = welcomeemailtemplate,
                ["redirecturl"] = redirecturl
            };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET, "login/smartlogin", additionalQueryParams);
        }

        public ApiResponse<LoginResponse> SmartLoginPing( string clientguid)
        {
            Validate(new[] { clientguid });
            var additionalQueryParams = new QueryParameters
            {
                ["clientguid"] = clientguid
            };
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.GET, "login/smartlogin/ping", additionalQueryParams);
        }


        public ApiResponse<LoginResponse> SmartLoginVerifyToken(string verificationtoken,string welcomeemailtemplate="")
        {
            Validate(new[] { verificationtoken });
            var additionalQueryParams = new QueryParameters
            {
                ["verificationtoken"] = verificationtoken,
                ["welcomeemailtemplate"] = welcomeemailtemplate
            };
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.GET, "email/smartlogin", additionalQueryParams);
        }

    }
}
