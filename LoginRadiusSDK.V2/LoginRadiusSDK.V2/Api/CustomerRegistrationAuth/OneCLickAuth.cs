using System.Collections;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
using LoginRadiusSDK.V2.Models.Social.Password;
using LoginRadiusSDK.V2.Models.CustomerAuthentication._2FA;
using System.Web.Script.Serialization;
using LoginRadiusSDK.V2.Models.Backup;
using System.Collections.Generic;

namespace LoginRadiusSDK.V2.Api
{
    public class OneCLickAuth : LoginRadiusResource
    {
        private readonly LoginRadiusResoucePath _resoucePath = new LoginRadiusResoucePath("account");

        public ApiResponse<LoginRadiusPostResponse> OneClickSigninbyEmail(string email, string oneClickSignIntemplate, string verificationUrl)
        {
            Validate(new ArrayList { email});
            var additionalQueryParams = new QueryParameters
            {
                ["email"] = email,
                ["oneClickSignIntemplate"] = oneClickSignIntemplate,
                ["verificationUrl"] = verificationUrl,
            };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Get, "login/oneclicksignin", additionalQueryParams);
        }


        public ApiResponse<LoginRadiusPostResponse> OneClickSigninbyUsername(string username, string oneClickSignIntemplate,  string verificationUrl)
        {
            Validate(new ArrayList { username, username});
            var additionalQueryParams = new QueryParameters
            {
                ["username"] = username, 
                ["oneClickSignIntemplate"] = oneClickSignIntemplate,
                ["verificationUrl"] = verificationUrl,
            };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Get, "login/oneclicksignin", additionalQueryParams);
        }
        public ApiResponse<LoginResponse> OneClickSigninVerification(string welcomeEmailTemplate, string verificationtoken)
        {
            Validate(new ArrayList { welcomeEmailTemplate, verificationtoken });
            var additionalQueryParams = new QueryParameters
            {   ["welcomeEmailTemplate"] = welcomeEmailTemplate,
                ["verificationtoken"] = verificationtoken,
            };
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.Get, "login/oneclickverify", additionalQueryParams);

        }
    }
}