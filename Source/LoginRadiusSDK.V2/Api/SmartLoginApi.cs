using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.CustomerAuthentication.Login;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class SmartLoginApi : LoginRadiusResource
    {
        /// <summary>
        /// This API sends a Smart Login link to the user's Email Id.
        /// </summary>
        /// <param name="email">Email of account being logged in.</param>
        /// <param name="clientguid">Unique client guid.</param>
        /// <param name="smartloginemailtemplate">Smart login email template name.</param>
        /// <param name="welcomeemailtemplate">Welcome email template name.</param>
        /// <param name="redirecturl">Redirection url after successful smart login.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if smart login email was sent.</returns>
        public ApiResponse<LoginRadiusPostResponse> SmartLoginByEmail(string email, string clientguid, 
            string smartloginemailtemplate = "", string welcomeemailtemplate = "", string redirecturl = "")
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
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET, 
                "login/smartlogin", additionalQueryParams);
        }

        /// <summary>
        /// This API sends a Smart Login link to the user's Username.
        /// </summary>
        /// <param name="username">Username of account being logged in.</param>
        /// <param name="clientguid">Unique client guid.</param>
        /// <param name="smartloginemailtemplate">Smart login email template name.</param>
        /// <param name="welcomeemailtemplate">Welcome email template name.</param>
        /// <param name="redirecturl">Redirection url after successful smart login.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if smart login email was sent.</returns>
        public ApiResponse<LoginRadiusPostResponse> SmartLoginByUserName(string username, string clientguid, 
            string smartloginemailtemplate = "", string welcomeemailtemplate = "", string redirecturl = "")
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
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET, 
                "login/smartlogin", additionalQueryParams);
        }

        /// <summary>
        /// This API is used to check if the Smart Login link has been clicked or not.
        /// </summary>
        /// <param name="clientguid">Used Unique client guid.</param>
        /// <returns>LoginResponse: LR Profile with access token.</returns>
        public ApiResponse<LoginResponse> SmartLoginPing(string clientguid)
        {
            Validate(new[] { clientguid });
            var additionalQueryParams = new QueryParameters
            {
                ["clientguid"] = clientguid
            };
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.GET, 
                "login/smartlogin/ping", additionalQueryParams);
        }

        /// <summary>
        /// This API verifies the provided token for Smart Login.
        /// </summary>
        /// <param name="verificationtoken">Verification token being verified.</param>
        /// <param name="welcomeemailtemplate">Welcome email template name.</param>
        /// <returns>LoginResponse: LR Profile with access token.</returns>
        public ApiResponse<OneTouchEmailVerificationModel> SmartLoginVerifyToken(string verificationtoken, string welcomeemailtemplate = "")
        {
            Validate(new[] { verificationtoken });
            var additionalQueryParams = new QueryParameters
            {
                ["verificationtoken"] = verificationtoken,
                ["welcomeemailtemplate"] = welcomeemailtemplate
            };
            return ConfigureAndExecute<OneTouchEmailVerificationModel>(RequestType.Authentication, HttpMethod.GET, 
                "email/smartlogin", additionalQueryParams);
        }

    }
}
