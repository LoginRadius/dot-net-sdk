using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using System.Collections.Generic;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
using LoginRadiusSDK.V2.Models.Identity;
using LoginRadiusSDK.V2.Models.CustomerAuthentication.Account;
using LoginRadiusSDK.V2.Models.Object;

namespace LoginRadiusSDK.V2.Api
{
    public class AccountApi : LoginRadiusResource
    {
        /// <summary>
        /// This API is used to create an account in Cloud Storage. This API bypasses the normal email verification process and manually creates the user. 
        /// </summary>
        /// <param name="userIdentity">UserIdentityCreateModel: An object holding the LoginRadius Profile on which the account is created.</param>
        /// <returns>LoginRadiusUserIdentity: The account profile.</returns>
        public ApiResponse<LoginRadiusUserIdentity> CreateAccount(UserIdentityCreateModel userIdentity)
        {
            Validate(new List<object> { userIdentity.Email, userIdentity.Password });
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.POST, null,
                userIdentity.ConvertToJson());
        }

        /// <summary>
        /// This API returns an Email Verification token.
        /// </summary>
        /// <param name="email">The email of the user being verified.</param>
        /// <returns>LoginRadiusVerification: A verification token.</returns>
        public ApiResponse<LoginRadiusVerification> EmailVerificationToken(string email)
        {
            Validate(new[] { email });
            var payload = new BodyParameters { [nameof(email)] = email };
            return ConfigureAndExecute<LoginRadiusVerification>(RequestType.Identity, HttpMethod.POST, "verify/token",
                payload.ConvertToJson());
        }

        /// <summary>
        /// This API returns a forgot password token. Fill in the appropriate arguments depending on login flow.
        /// </summary>
        /// <param name="email"> The email of the user resetting password when login flow is email. Leave blank otherwise.</param>
        /// <param name="username">The username of the user resetting password when login flow is username. Leave blank otherwise.</param>
        /// <returns>ForgotPasswordToken: A Password Reset token.</returns>
        public ApiResponse<ForgotPasswordToken> GetForgotPasswordToken(string email = "", string username = "")
        {
            var payload = new BodyParameters { [nameof(email)] = email, [nameof(username)] = username };
            return ConfigureAndExecute<ForgotPasswordToken>(RequestType.Identity, HttpMethod.POST, "forgot/token",
                payload.ConvertToJson());
        }

        /// <summary>
        /// This is intended for specific work flows where an email may be associated to multiple UIDs.
        /// This API is used to retrieve all of the identities (UID and Profiles), associated with a specified email in Cloud Storage.
        /// </summary>
        /// <param name="email">A valid email associated with a LoginRadius account.</param>
        /// <returns>AccountIdentities: The profiles associated with the passed in email.</returns>
        public ApiResponse<AccountIdentities> GetAccountIdentitiesByEmail(string email)
        {
            Validate(new[] { email });
            var additionalQueryParams = new QueryParameters { { nameof(email), email } };
            return ConfigureAndExecute<AccountIdentities>(RequestType.Identity, HttpMethod.GET, "identities", additionalQueryParams);
        }

        /// <summary>
        /// The API is used to get a LoginRadius access token based on UID.
        /// </summary>
        /// <param name="uid">UID of a LoginRadius account.</param>
        /// <returns>AccessTokenResponse: A generated access token for the account with the expiry time.</returns>
        public ApiResponse<AccessTokenResponse> UserImpersonation(string uid)
        {
            Validate(new[] { uid });
            var additionalQueryParams = new QueryParameters { { nameof(uid), uid } };
            return ConfigureAndExecute<AccessTokenResponse>(RequestType.Identity, HttpMethod.GET, "access_token",
                additionalQueryParams);
        }

        /// <summary>
        /// You can use this API to retrieve the hashed password of a specified account in Cloud Storage.
        /// </summary>
        /// <param name="uid">UID of a LoginRadius account.</param>
        /// <returns>HashPassword: The hashed password for the account.</returns>
        public ApiResponse<HashPassword> GetAccountPassword(string uid)
        {
            Validate(new[] { uid });
            var pattern = new LoginRadiusResourcePath("{0}/password").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid });
            return ConfigureAndExecute<HashPassword>(RequestType.Identity, HttpMethod.GET, resourcePath, "");
        }

        /// <summary>
        /// This API is used to retrieve all of the profile data, associated with the specified account by email in Cloud Storage.
        /// </summary>
        /// <param name="email">Email associated with a LoginRadius account.</param>
        /// <returns>LoginRadiusUserIdentity: The account profile.</returns>
        public ApiResponse<LoginRadiusUserIdentity> GetAccountProfileByEmail(string email)
        {
            Validate(new[] { email });
            var additionalQueryParams = new QueryParameters { { nameof(email), email } };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.GET, null,
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to retrieve all of the profile data, associated with the specified account by username in Cloud Storage.
        /// </summary>
        /// <param name="username">Username associated with a LoginRadius account.</param>
        /// <returns>LoginRadiusUserIdentity: The account profile.</returns>
        public ApiResponse<LoginRadiusUserIdentity> GetAccountProfileByUserName(string username)
        {
            Validate(new[] { username });
            var additionalQueryParams = new QueryParameters { { nameof(username), username } };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.GET, null,
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to retrieve all of the profile data, associated with the specified account by phone in Cloud Storage.
        /// </summary>
        /// <param name="phone">Phone associated with a LoginRadius account.</param>
        /// <returns>LoginRadiusUserIdentity: The account profile.</returns>
        public ApiResponse<LoginRadiusUserIdentity> GetAccountProfileByPhone(string phone)
        {
            Validate(new[] { phone });
            var additionalQueryParams = new QueryParameters { { nameof(phone), phone } };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.GET, null,
                additionalQueryParams);
        }

        /// <summary>
        /// This API is used to retrieve all of the profile data, associated with the specified account by uid in Cloud Storage.
        /// </summary>
        /// <param name="uid">Uid associated with a LoginRadius account.</param>
        /// <returns>LoginRadiusUserIdentity: The account profile.</returns>
        public ApiResponse<LoginRadiusUserIdentity> GetAccountProfileByUid(string uid)
        {
            Validate(new[] { uid });
            var pattern = new LoginRadiusResourcePath("{0}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid });
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.GET, resourcePath);
        }

        /// <summary>
        /// This API is used to set the password of an account in Cloud Storage.
        /// </summary>
        /// <param name="uid">Uid associated with a LoginRadius account.</param>
        /// <param name="password">The new password.</param>
        /// <returns>HashPassword: Hashed version of the new password.</returns>
        public ApiResponse<HashPassword> SetAccountPassword(string uid, string password)
        {
            Validate(new[] { uid, password });
            var pattern = new LoginRadiusResourcePath("{0}/password").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid });
            var passwordBody = new BodyParameters { [nameof(password)] = password };
            return ConfigureAndExecute<HashPassword>(RequestType.Identity, HttpMethod.PUT, resourcePath,
                passwordBody.ConvertToJson());
        }

        /// <summary>
        /// This API is used to update the information of existing accounts in your Cloud Storage.
        /// See our Advanced API Usage section Here for more capabilities.
        /// </summary>
        /// <param name="uid">Uid associated with a LoginRadius account.</param>
        /// <param name="user">LoginRadiusAccountUpdateModel: Profile object with updated fields.</param>
        /// <returns>LoginRadiusUserIdentity: The updated account profile.</returns>
        public ApiResponse<LoginRadiusUserIdentity> UpdateAccount(string uid, LoginRadiusAccountUpdateModel user)
        {
            Validate(new[] { uid });
            var pattern = new LoginRadiusResourcePath("{0}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid });
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.PUT, resourcePath,
                user.ConvertToJson());
        }

        /// <summary>
        /// This API is used to update security questions configuration on an existing account.
        /// </summary>
        /// <param name="uid">Uid associated with a LoginRadius account.</param>
        /// <param name="obj">SecurityQuestion: The newly updated security question/answer.</param>
        /// <returns>LoginRadiusUserIdentity: The profile with the updated security question/answer.</returns>
        public ApiResponse<LoginRadiusUserIdentity> UpdateSecurityQuestion(string uid, SecurityQuestion obj)
        {
            Validate(new[] { uid });
            var pattern = new LoginRadiusResourcePath("{0}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid });
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.PUT, resourcePath,
                obj.ConvertToJson());
        }

        /// <summary>
        /// This API is used to invalidate the Email Verification status on an account.
        /// </summary>
        /// <param name="uid">Uid associated with a LoginRadius account.</param>
        /// <param name="optionalParams">Gets or sets API optional parameters, <see cref="LoginRadiusApiOptionalParams"/></param>
        /// <returns>LoginRadiusPostResponse: Boolean to show if the result was successful.</returns>
        public ApiResponse<LoginRadiusPostResponse> InvalidateEmailVerification(string uid, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { uid });
            var pattern = new LoginRadiusResourcePath("{0}/invalidateemail").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid });
            var additionalParams = new QueryParameters();
            if (!string.IsNullOrEmpty(optionalParams.VerificationUrl))
                additionalParams.Add(nameof(optionalParams.VerificationUrl), optionalParams.VerificationUrl);
            if (!string.IsNullOrEmpty(optionalParams.EmailTemplate))
                additionalParams.Add(nameof(optionalParams.EmailTemplate), optionalParams.EmailTemplate);
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Identity, HttpMethod.PUT, resourcePath, additionalParams);
        }

        /// <summary>
        /// Use this API to Remove emails from a user account.
        /// </summary>
        /// <param name="uid">Uid associated with a LoginRadius account.</param>
        /// <param name="email">Email to be deleted.</param>
        /// <returns>LoginRadiusUserIdentity: The profile with the deleted email.</returns>
        public ApiResponse<LoginRadiusUserIdentity> DeleteEmail(string uid, string email)
        {
            Validate(new[] { uid, email });
            var pattern = new LoginRadiusResourcePath("{0}/email").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid });
            var body = new BodyParameters { ["email"] = email };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.DELETE, resourcePath,
                body.ConvertToJson());
        }

        /// <summary>
        /// This API deletes the Users account and allows them to re-register for a new account.
        /// </summary>
        /// <param name="uid">Uid associated with a LoginRadius account.</param>
        /// <returns>LoginRadiusDeleteResponse: Boolean to show if account was deleted.</returns>
        public ApiResponse<LoginRadiusDeleteResponse> DeleteAccount(string uid)
        {
            Validate(new[] { uid });
            var pattern = new LoginRadiusResourcePath("{0}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.DELETE, resourcePath, "");
        }
    }
}
