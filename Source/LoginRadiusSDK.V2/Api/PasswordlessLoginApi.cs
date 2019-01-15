using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;

namespace LoginRadiusSDK.V2.Api
{
    public class PasswordlessLoginApi : LoginRadiusResource
    {
        /// <summary>
        /// This API is used to send a Passwordless Login verification link to the provided Email ID.
        /// </summary>
        /// <param name="email">Email of account being logged in.</param>
        /// <param name="passwordlesslogintemplate">Passwordless login email template name.</param>
        /// <param name="verificationUrl">Location of verification url.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if email was sent for passwordless login.</returns>
        public ApiResponse<LoginRadiusPostResponse> PasswordlessLoginByEmail(string email, string passwordlesslogintemplate, 
            string verificationUrl)
        {
            Validate(new[] { email });
            var additionalQueryParams = new QueryParameters
            {
                ["email"] = email,
                ["passwordlesslogintemplate"] = passwordlesslogintemplate,
                ["verificationUrl"] = verificationUrl,
            };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET, 
                "login/passwordlesslogin/email", additionalQueryParams);
        }

        /// <summary>
        /// This API is used to send a Passwordless Login verification link to the provided Username.
        /// </summary>
        /// <param name="username">Username of account being logged in.</param>
        /// <param name="passwordlesslogintemplate">Passwordless login email template name.</param>
        /// <param name="verificationUrl">Location of verification url.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if email was sent for passwordless login.</returns>
        public ApiResponse<LoginRadiusPostResponse> PasswordlessLoginByUserName(string username, string passwordlesslogintemplate, 
            string verificationUrl)
        {
            Validate(new[] { username, username });
            var additionalQueryParams = new QueryParameters
            {
                ["username"] = username,
                ["passwordlesslogintemplate"] = passwordlesslogintemplate,
                ["verificationUrl"] = verificationUrl,
            };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET, 
                "login/passwordlesslogin/email", additionalQueryParams);
        }

        /// <summary>
        /// This API is used to verify the Passwordless Login verification link.
        /// </summary>
        /// <param name="verificationToken">Verification token for passwordless login sent to email.</param>
        /// <param name="welcomeEmailTemplate">Welcome email template name.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if email was sent for passwordless login.</returns>
        public ApiResponse<LoginResponse> PasswordlessLoginVerification(string verificationToken, string welcomeEmailTemplate = "")
        {
            Validate(new[] { verificationToken });
            var additionalQueryParams = new QueryParameters
            {
                ["welcomeEmailTemplate"] = welcomeEmailTemplate,
                ["verificationtoken"] = verificationToken,
            };
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.GET, 
                "login/passwordlesslogin/email/verify", additionalQueryParams);
        }
    }
}