using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.CustomerAuthentication.Email;
using LoginRadiusSDK.V2.Models.Email;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using System.Collections.Generic;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
using static LoginRadiusSDK.V2.Entity.LoginRadiusSecureOneTimeToken;
using LoginRadiusSDK.V2.Models.Identity;
using LoginRadiusSDK.V2.Models.Configuration;
using LoginRadiusSDK.V2.Models.CustomerAuthentication.Password;
using LoginRadiusSDK.V2.Models.Password;

namespace LoginRadiusSDK.V2.Api
{
    public class AuthenticationApi : LoginRadiusResource
    {
        /// <summary>
        /// This API is used to add additional emails to a user's account.
        /// </summary>
        /// <param name="accessToken">Access token for session that is completing action.</param>
        /// <param name="email">Email being added.</param>
        /// <param name="verificationUrl">Verification url sent to email.</param>
        /// <param name="emailTemplate">Email template being sent out.</param>
        /// <returns> LoginRadiusPostResponse: Boolean to show if email was added.</returns>
        public ApiResponse<LoginRadiusPostResponse> AddEmail(string accessToken, AddEmail email,
            string verificationUrl = "", string emailTemplate = "")
        {
            Validate(new[] { email.Email, email.Type, accessToken });
            var additionalQueryParams = new QueryParameters();
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            if (!string.IsNullOrWhiteSpace(verificationUrl))
                additionalQueryParams.Add("verificationUrl", verificationUrl);
            if (!string.IsNullOrWhiteSpace(emailTemplate)) additionalQueryParams.Add("emailTemplate", emailTemplate);
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.POST,
                "email", additionalQueryParams, email.ConvertToJson(), additionalHeaders);
        }

        /// <summary>
        /// This API is used to send the reset password url to a specified account.
        /// Note: If you have the UserName workflow enabled, you may replace the 'email' parameter with 'username'.
        /// </summary>
        /// <param name="email">Email associated with a LoginRadius account.</param>
        /// <param name="resetPasswordUrl">Reset password url sent to email.</param>
        /// <param name="emailTemplate">Email template being sent out.</param>
        /// <returns> LoginRadiusPostResponse: Boolean to show if email was added.</returns>
        public ApiResponse<LoginRadiusPostResponse> ForgotPassword(string email, string resetPasswordUrl = "", string emailTemplate = "")
        {
            Validate(new[] { email, resetPasswordUrl });
            var additionalQueryParams = new QueryParameters
            {
                {"resetPasswordUrl", resetPasswordUrl}, {"emailTemplate", emailTemplate}
            };

            var bodyParameter = new BodyParameters { ["email"] = email };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.POST,
                "password", additionalQueryParams, bodyParameter.ConvertToJson());
        }

        /// <summary>
        /// This API creates a user in the database as well as sends a verification email to the user.
        /// </summary>
        /// <param name="socialUserProfile">LoginRadius Profile that is being created.</param>
        /// <param name="optionalParams">Gets or sets API optional parameters, <see cref="LoginRadiusApiOptionalParams"/></param>
        /// <param name="sottAuth">Settings for the SOTT generated to register.</param>
        /// <returns> LoginRadiusPostResponse: Boolean to show if account was registered.</returns>
        public ApiResponse<LoginRadiusPostResponse> RegisterCustomer(UserIdentityCreateModel socialUserProfile,
            LoginRadiusApiOptionalParams optionalParams, SottRequest sottAuth)
        {
            var additionalQueryParams = new QueryParameters();
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.SottAuthorizationHeader] = "" };
            additionalQueryParams.AddOptionalParamsRange(optionalParams);

            if (!string.IsNullOrWhiteSpace(sottAuth.Sott))
            {
                additionalHeaders[BaseConstants.SottAuthorizationHeader] = sottAuth.Sott;
            }
            else
            {
                var timeDifference = new QueryParameters { ["timedifference"] = sottAuth.TimeDifference };
                var sottResponse = ConfigureAndExecute<SottDetails>(RequestType.ServerInfo, HttpMethod.GET, null, timeDifference);

                if (sottResponse.Response?.Sott != null)
                {
                    sottAuth.StartTime = sottResponse.Response.Sott.StartTime;
                    sottAuth.EndTime = sottResponse.Response.Sott.EndTime;
                    sottAuth.TimeDifference = sottResponse.Response.Sott.TimeDifference;
                }
                additionalHeaders[BaseConstants.SottAuthorizationHeader] = GetSott(sottAuth);
            }

            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.POST,
                "register", additionalQueryParams, socialUserProfile.ConvertToJson(), additionalHeaders);
        }

        /// <summary>
        /// This API retrieves a copy of the user data based on the email and generates an access token for the account.
        /// </summary>
        /// <param name="payload">JSON string storing login information.</param>
        /// <param name="optionalParams">Gets or sets API optional parameters, <see cref="LoginRadiusApiOptionalParams"/></param>
        /// <returns> LoginResponse: Login Response containing accessToken and user profile data.</returns>
        public ApiResponse<LoginResponse> LoginByEmail(string payload, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { payload });
            var additionalQueryParams = new QueryParameters();
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.POST, "login", 
                additionalQueryParams, payload);
        }

        /// <summary>
        /// This API retrieves a copy of the user data based on the username.
        /// </summary>
        /// <param name="payload">JSON string storing login information.</param>
        /// <param name="optionalParams">Gets or sets API optional parameters, <see cref="LoginRadiusApiOptionalParams"/></param>
        /// <returns> LoginResponse: Login Response containing accessToken and user profile data.</returns>
        public ApiResponse<LoginResponse> LoginByUserName(string payload, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { payload });
            var additionalQueryParams = new QueryParameters();
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            return ConfigureAndExecute<LoginResponse>(RequestType.Authentication, HttpMethod.POST, "login",
                additionalQueryParams, payload);
        }

        /// <summary>
        /// This API is used to check the email exists or not on your site.
        /// </summary>
        /// <param name="email"> Email being checked.</param>
        /// <returns>LoginRadiusExistsResponse: Boolean to show if email exists.</returns>
        public ApiResponse<LoginRadiusExistsResponse> CheckEmailAvailability(string email)
        {
            Validate(new[] { email });
            var additionalQueryParams = new QueryParameters { ["email"] = email };
            return ConfigureAndExecute<LoginRadiusExistsResponse>(RequestType.Authentication, HttpMethod.GET,
                "email", additionalQueryParams);
        }

        /// <summary>
        /// This API is used to check the UserName exists or not on your site.
        /// </summary>
        /// <param name="userName">Username being checked.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean to show if userName was deleted.</returns>
        public ApiResponse<LoginRadiusExistsResponse> CheckUserNameAvailability(string userName)
        {
            Validate(new[] { userName });
            var additionalQueryParams = new QueryParameters { ["username"] = userName };
            return ConfigureAndExecute<LoginRadiusExistsResponse>(RequestType.Authentication, HttpMethod.GET,
                "username", additionalQueryParams);
        }

        /// <summary>
        /// This API retrieves a copy of the user data based on the access_token.
        /// </summary>
        /// <param name="accessToken">Access token for the current session.</param>
        /// <returns>LoginRadiusUserIdentity: The LoginRadius profile.</returns>
        public ApiResponse<LoginRadiusUserIdentity> GetProfile(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Authentication, HttpMethod.GET, "account",
                null, null, additionalHeaders);
        }

        /// <summary>
        /// This API is used to update the privacy policy stored in the user's profile by providing the access_token of the user accepting the privacy policy.
        /// </summary>
        /// <param name="accessToken">Access token for the current session.</param>
        /// <returns>LoginRadiusUserIdentity: The LoginRadius profile.</returns>
        public ApiResponse<LoginRadiusUserIdentity> PrivacyPolicyAccept(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };

            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Authentication, HttpMethod.GET, "privacypolicy/accept",
               null, null, additionalHeaders);
        }

        /// <summary>
        /// This API will send a welcome email.
        /// </summary>
        /// <param name="accessToken">Access token for the current session.</param>
        /// <param name="welcomeEmailTemplate">Name of the welcome email template.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if welcome email was sent.</returns>
        public ApiResponse<LoginRadiusPostResponse> SendWelcomeEmail(string accessToken, string welcomeEmailTemplate = "")
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            var additionalQueryParams = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
                additionalQueryParams.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET,
                "account/sendwelcomeemail", additionalQueryParams, null, additionalHeaders);
        }

        /// <summary>
        /// This API is called just before account linking API and it prevents the raas profile of the second account from getting created.
        /// </summary>
        /// <param name="accessToken">Access token for the current session.</param>
        /// <returns>LoginRadiusSocialUserProfile: Boolean to show if account was deleted.</returns>
        public ApiResponse<LoginRadiusSocialUserProfile> AuthSocialIdentity(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<LoginRadiusSocialUserProfile>(RequestType.Authentication, HttpMethod.GET,
                "socialidentity", null, null, additionalHeaders);
        }

        /// <summary>
        /// This api validates access token, if valid then returns a response with its expiry otherwise error.
        /// </summary>
        /// <param name="accessToken">Access token for the current session.</param>
        /// <returns>AccessTokenResponse: The updated access token and its new expiry time.</returns>
        public ApiResponse<AccessTokenResponse> AuthValidateAccessToken(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<AccessTokenResponse>(RequestType.Authentication, HttpMethod.GET,
                "access_token/validate", null, null, additionalHeaders);
        }

        /// <summary>
        /// This API is used to obtain information on the provided access token.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <returns>AccessTokenResponse: Info on the provided account token.</returns>
        public ApiResponse<AccessTokenResponse> AccessTokenInfo(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>()
            {
                [BaseConstants.AccessTokenAuthorizationHeader] =
                    BaseConstants.AccessTokenBearerHeader + accessToken
            };
            return ConfigureAndExecute<AccessTokenResponse>(RequestType.Authentication, HttpMethod.GET,
                "access_token", null, null, additionalHeaders);
        }

        /// <summary>
        /// This API is used to verify the email of user. Note: This API will only return the full profile if you have
        /// 'Enable auto login after email verification' set in your LoginRadius Dashboard's Email Workflow settings under 'Verification Email'.
        /// </summary>
        /// <param name="verificationToken">Verification token received in the email.</param>
        /// <param name="url">Mention URL to log the main URL(Domain name) in Database.</param>
        /// <param name="welcomeEmailTemplate">Email template for welcome email.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if email verification was successful.</returns>
        public ApiResponse<LoginRadiusPostResponse<Data>> VerifyEmail(string verificationToken, string url,
            string welcomeEmailTemplate = "")
        {
            Validate(new[] { verificationToken, url });
            var additionalQueryParams = new QueryParameters { ["VerificationToken"] = verificationToken, ["url"] = url };
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
                additionalQueryParams.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            return ConfigureAndExecute<LoginRadiusPostResponse<Data>>(RequestType.Authentication, HttpMethod.GET,
                "email", additionalQueryParams);
        }

        /// <summary>
        /// This API sends a verification email with an OTP.
        /// </summary>
        /// <param name="verifyEmailModel">Uid associated with a LoginRadius account.</param>
        /// <param name="url">Mention URL to log the main URL(Domain name) in Database.</param>
        /// <param name="welcomeEmailTemplate">Email template for welcome email.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if email verification was successful.</returns>
        public ApiResponse<LoginRadiusPostResponse<Data>> VerifyEmailByOtp(VerifyEmailModel verifyEmailModel, string url = "",
           string welcomeEmailTemplate = "")
        {
            Validate(new[] { verifyEmailModel.email, verifyEmailModel.otp });
            var additionalQueryParams = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
                additionalQueryParams.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            if (!string.IsNullOrWhiteSpace(url)) additionalQueryParams.Add("url", url);
            return ConfigureAndExecute<LoginRadiusPostResponse<Data>>(RequestType.Authentication, HttpMethod.PUT,
                "email", additionalQueryParams, verifyEmailModel.ConvertToJson());
        }

        /// <summary>
        /// API is used to delete account using delete token.
        /// </summary>
        /// <param name="deleteToken">Delete Token sent to the email.</param>
        /// <returns><see cref="LoginRadiusPostResponse"/>Boolean to show if account was deleted</returns>
        public ApiResponse<LoginRadiusPostResponse> DeleteProfile(string deleteToken)
        {
            Validate(new[] { deleteToken });
            var additionalQueryParams = new QueryParameters { { nameof(deleteToken), deleteToken } };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET,
                "account/delete", additionalQueryParams);
        }

        /// <summary>
        /// This api call invalidates the active access_token or expires an access token's validity.
        /// </summary>
        /// <param name="accessToken">Access token being invalidated.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if the token was invalidated.</returns>
        public ApiResponse<LoginRadiusPostResponse> AuthInvalidateAccessToken(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET,
                "access_token/invalidate", null, null, additionalHeaders);
        }

        /// <summary>
        /// This API is used to retrieve the list of questions that are configured on the respective LoginRadius site.
        /// </summary>
        /// <param name="accessToken">Session token associated with the security questions needing to be retrieved.</param>
        /// <returns>List of SecurityQuestionGet: The list of security questions.</returns>
        public ApiResponse<List<SecurityQuestionGet>> SecurityQuestionByAccessToken(string accessToken)
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<List<SecurityQuestionGet>>(RequestType.Authentication, HttpMethod.GET,
                "securityquestion/accesstoken", null, null, additionalHeaders);
        }

        /// <summary>
        /// This API is used to retrieve the list of questions that are configured on the respective LoginRadius site.
        /// </summary>
        /// <param name="email">Email associated with the security questions needing to be retrieved.</param>
        /// <returns>List of SecurityQuestionGet: The list of security questions.</returns>
        public ApiResponse<List<SecurityQuestionGet>> SecurityQuestionByEmail(string email)
        {
            Validate(new[] { email });
            var additionalQueryParams = new QueryParameters { [nameof(email)] = email };
            return ConfigureAndExecute<List<SecurityQuestionGet>>(RequestType.Authentication, HttpMethod.GET,
                "securityquestion/email", additionalQueryParams, null);
        }

        /// <summary>
        /// This API is used to retrieve the list of questions that are configured on the respective LoginRadius site.
        /// </summary>
        /// <param name="username">Username associated with the security questions needing to be retrieved.</param>
        /// <returns>List of SecurityQuestionGet: The list of security questions.</returns>
        public ApiResponse<List<SecurityQuestionGet>> SecurityQuestionByUserName(string username)
        {
            Validate(new[] { username });
            var additionalQueryParams = new QueryParameters { [nameof(username)] = username };
            return ConfigureAndExecute<List<SecurityQuestionGet>>(RequestType.Authentication, HttpMethod.GET,
                "securityquestion/username", additionalQueryParams, null);
        }

        /// <summary>
        /// This API is used to retrieve the list of questions that are configured on the respective LoginRadius site.
        /// </summary>
        /// <param name="phone">Phone number associated with the security questions needing to be retrieved.</param>
        /// <returns>List of SecurityQuestionGet: The list of security questions.</returns>
        public ApiResponse<List<SecurityQuestionGet>> SecurityQuestionByPhone(string phone)
        {
            Validate(new[] { phone });
            var additionalQueryParams = new QueryParameters { [nameof(phone)] = phone };
            return ConfigureAndExecute<List<SecurityQuestionGet>>(RequestType.Authentication, HttpMethod.GET,
                "securityquestion/phone", additionalQueryParams, null);
        }

        /// <summary>
        /// This API is used to change the accounts password based on the previous password.
        /// </summary>
        /// <param name="accessToken">Session token where password change is occuring.</param>
        /// <param name="changePasswordModel">Object containing old and new password parameters.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if password was changed.</returns>
        public ApiResponse<LoginRadiusPostResponse> ChangePassword(string accessToken, ChangePasswordModel changePasswordModel)
        {
            Validate(new[] { accessToken, changePasswordModel.OldPassword, changePasswordModel.NewPassword });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            var passwordModel = new BodyParameters
            {
                ["OldPassword"] = changePasswordModel.OldPassword,
                ["NewPassword"] = changePasswordModel.NewPassword
            };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT,
                "password/change", null, passwordModel.ConvertToJson(), additionalHeaders);
        }

        /// <summary>
        /// This API is used to link up a social provider account with the specified account based on the access token and the social providers user access token.
        /// </summary>
        /// <param name="accessToken">Session token where linking is taking place.</param>
        /// <param name="candidateToken">Access token generated when completing a social login with no attached LoginRadius account.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if account was successfully linked.</returns>
        public ApiResponse<LoginRadiusPostResponse> LinkAccount(string accessToken, string candidateToken)
        {
            Validate(new[] { accessToken, candidateToken });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            var bodyParams = new BodyParameters { ["candidateToken"] = candidateToken };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT,
                "socialidentity", null, bodyParams.ConvertToJson(), additionalHeaders);
        }

        /// <summary>
        /// This API resends the verification email to the user.
        /// </summary>
        /// <param name="email">Email being verified.</param>
        /// <param name="verificationUrl">Url where user should go to verify.</param>
        /// <param name="emailTemplate">Email template name.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if email has been sent out.</returns>
        public ApiResponse<LoginRadiusPostResponse> ResendVerificationEmail(string email, string verificationUrl = "",
            string emailTemplate = "")
        {
            var additionalQueryParams = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(verificationUrl)) additionalQueryParams.Add("verificationUrl", verificationUrl);
            if (!string.IsNullOrWhiteSpace(emailTemplate)) additionalQueryParams.Add("emailTemplate", emailTemplate);
            var bodyParams = new BodyParameters { ["Email"] = email };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT,
                "register", additionalQueryParams, bodyParams.ConvertToJson());
        }

        /// <summary>
        /// This API is used to set a new password for the specified account.
        /// </summary>
        /// <param name="resetPasswordModel">Object containing reset token, new password and other optional parameters.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if password was successfully changed.</returns>
        public ApiResponse<LoginRadiusPostResponse> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            Validate(new[] { resetPasswordModel.Password, resetPasswordModel.ResetToken });
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT,
                "password/reset", null, resetPasswordModel.ConvertToJson());
        }

        /// <summary>
        /// This API is used to set a new password for the specified account.
        /// </summary>
        /// <param name="resetPasswordOtpModel">Object containing otp, new password, email and other optional parameters.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if account password was reset successfully.</returns>
        public ApiResponse<LoginRadiusPostResponse<Data>> AuthResetPasswordByOtp(ResetPasswordByEmailAndOtpModel resetPasswordOtpModel)
        {
            Validate(new[] { resetPasswordOtpModel.password, resetPasswordOtpModel.otp, resetPasswordOtpModel.email });
            return ConfigureAndExecute<LoginRadiusPostResponse<Data>>(RequestType.Authentication, HttpMethod.PUT, 
                "password/reset", null, resetPasswordOtpModel.ConvertToJson());
        }

        /// <summary>
        /// This API is used to reset password for the specified account by security question.
        /// </summary>
        /// <param name="resetPasswordModel">Object containing security answer, new password, email and other parameters.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if password was changed successfully.</returns>
        public ApiResponse<LoginRadiusPostResponse<Data>> ResetPasswordBySecurityAnswerAndEmail(
            ResetPasswordBySecurityAnswerModelAndEmail resetPasswordModel)
        {
            Validate(new List<object>
            {
                resetPasswordModel.SecurityAnswer,
                resetPasswordModel.Password,
                resetPasswordModel.Email
            });
            return ConfigureAndExecute<LoginRadiusPostResponse<Data>>(RequestType.Authentication, HttpMethod.PUT,
                "password/securityanswer", null, resetPasswordModel.ConvertToJson());
        }

        /// <summary>
        /// This API is used to reset password for the specified account by security question.
        /// </summary>
        /// <param name="resetPasswordModel">Object containing security answer, new password, phone and other parameters.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if password was changed successfully.</returns>
        public ApiResponse<LoginRadiusPostResponse<Data>> ResetPasswordBySecurityAnswerAndPhone(
            ResetPasswordBySecurityAnswerModelAndPhone resetPasswordModel)
        {
            Validate(new List<object>
            {
                resetPasswordModel.SecurityAnswer,
                resetPasswordModel.Password,
                resetPasswordModel.Phone
            });
            return ConfigureAndExecute<LoginRadiusPostResponse<Data>>(RequestType.Authentication, HttpMethod.PUT,
                "password/securityanswer", null, resetPasswordModel.ConvertToJson());
        }

        /// <summary>
        /// This API is used to reset password for the specified account by security question.
        /// </summary>
        /// <param name="resetPasswordModel">Object containing security answer, new password, username and other parameters.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if password was changed successfully.</returns>
        public ApiResponse<LoginRadiusPostResponse<Data>> ResetPasswordBySecurityAnswerAndUserName(
            ResetPasswordBySecurityAnswerModelAndUserName resetPasswordModel)
        {
            Validate(new List<object>
            {
                resetPasswordModel.SecurityAnswer,
                resetPasswordModel.Password,
                resetPasswordModel.Username
            });
            return ConfigureAndExecute<LoginRadiusPostResponse<Data>>(RequestType.Authentication, HttpMethod.PUT,
                "password/securityanswer", null, resetPasswordModel.ConvertToJson());
        }

        /// <summary>
        /// This API is used to set or change UserName by access token.
        /// </summary>
        /// <param name="accessToken">Session token for username being updated.</param>
        /// <param name="userName">New username.</param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if username was updated.</returns>
        public ApiResponse<LoginRadiusPostResponse> UpdateUserName(string accessToken, string userName)
        {
            Validate(new[] { accessToken, userName });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            var bodyParams = new BodyParameters { ["username"] = userName }.ConvertToJson();
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.PUT,
                "username", null, bodyParams, additionalHeaders);
        }

        /// <summary>
        /// This API is used to update the profile.
        /// </summary>
        /// <param name="accessToken">Session token for profile being updated.</param>
        /// <param name="userProfile">The object containing data for the updated profile.</param>
        /// <param name="optionalParams">Extra optional parameters.</param>
        /// <returns>PostResponse: Boolean to show if profile was updated, along with profile object.</returns>
        public ApiResponse<PostResponse> UpdateProfile(string accessToken, LoginRadiusUserIdentity userProfile,
            LoginRadiusApiOptionalParams optionalParams)
        {
            userProfile.Email?.Clear();
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters();
            additionalQueryParams.AddOptionalParamsRange(optionalParams);
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<PostResponse>(RequestType.Authentication, HttpMethod.PUT,
                "account", additionalQueryParams, userProfile.ConvertToJson(), additionalHeaders);
        }

        /// <summary>
        /// This API is used to update the security question for a user.
        /// </summary>
        /// <param name="accessToken">Session token for security question settings being updated.</param>
        /// <param name="securityQuestionAnswerPost">The object containing the updated security question settings.</param>
        /// <returns>PostResponse: Boolean to show if profile was updated, along with profile object.</returns>
        public ApiResponse<PostResponse> UpdateSecurityQuestionByAccessToken(string accessToken,
            SecurityQuestionAnswerPost securityQuestionAnswerPost)
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<PostResponse>(RequestType.Authentication, HttpMethod.PUT,
                "account", null, securityQuestionAnswerPost.ConvertToJson(), additionalHeaders);
        }

        /// <summary>
        /// This API sends an email to the user with a delete token.
        /// </summary>
        /// <param name="accessToken">Session token for the account being deleted.</param>
        /// <param name="loginRadiusApiOptionalParams">Extra optional parameters.</param>
        /// <returns>CustomerRegistrationDeleteResponse: Boolean to show if delete email was sent.</returns>
        public ApiResponse<CustomerRegistrationDeleteResponse> DeleteAccountWithEmailConfirmation(
            string accessToken, LoginRadiusApiOptionalParams loginRadiusApiOptionalParams)
        {
            Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters
            {
                [nameof(loginRadiusApiOptionalParams.DeleteUrl)] = loginRadiusApiOptionalParams.DeleteUrl,
                [nameof(loginRadiusApiOptionalParams.EmailTemplate)] = loginRadiusApiOptionalParams.EmailTemplate
            };
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<CustomerRegistrationDeleteResponse>(RequestType.Authentication,
                HttpMethod.DELETE, "account", additionalQueryParams, null, additionalHeaders);
        }

        /// <summary>
        /// This API removes an email from an account which has more than one email.
        /// </summary>
        /// <param name="accessToken">Session token associated with account with the target email.</param>
        /// <param name="email">Email being removed.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean to show if email was deleted.</returns>
        public ApiResponse<LoginRadiusDeleteResponse> RemoveEmail(string accessToken, string email)
        {
            Validate(new[] { accessToken, email });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            var body = new BodyParameters { ["email"] = email };

            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.DELETE,
                "email", null, body.ConvertToJson(), additionalHeaders);
        }

        /// <summary>
        /// This API unlinks the account from a social profile.
        /// </summary>
        /// <param name="accessToken">Session token associated with a LoginRadius account.</param>
        /// <param name="unlinkModel">Session token associated with a LoginRadius account.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean to show if account was deleted.</returns>
        public ApiResponse<LoginRadiusDeleteResponse> UnLinkAccount(string accessToken, UnlinkProfileModel unlinkModel)
        {
            Validate(new[] { accessToken });
            var additionalHeaders = new Dictionary<string, string>() { [BaseConstants.AccessTokenAuthorizationHeader] = 
                BaseConstants.AccessTokenBearerHeader + accessToken };
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Authentication, HttpMethod.DELETE,
                "socialidentity", null, unlinkModel.ConvertToJson(), additionalHeaders);
        }
    }
}
