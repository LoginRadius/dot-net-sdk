using System.Collections.Generic;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.CustomerAuthentication.Account;
using LoginRadiusSDK.V2.Models.Object;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
using LoginRadiusSDK.V2.Models.CustomerManagement.Identity;
using LoginRadiusSDK.V2.Models.Social.Password;
using LoginRadiusSDK.V2.Models.Password;

namespace LoginRadiusSDK.V2.Api
{
    public class AccountManagementEntity : LoginRadiusResource
    {
        public ApiResponse<LoginRadiusUserIdentity> CreateAccount(UserIdentityCreateModel userIdentity)
        {
            Validate(new List<object> { userIdentity.Email, userIdentity.Password });
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.Post, null,
                userIdentity.ConvertToJson());
        }

        public ApiResponse<LoginRadiusUserIdentity> GetAccountProfileByEmail(string email)
        {
            Validate(new [] { email });
            var additionalQueryParams = new QueryParameters { { "email", email } };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.Get, null,
                additionalQueryParams);
        }

        public ApiResponse<LoginRadiusUserIdentity> GetAccountProfileByUserName(string userName)
        {
            Validate(new [] { userName });
            var additionalQueryParams = new QueryParameters { { "username", userName } };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.Get, null,
                additionalQueryParams);
        }

        public ApiResponse<LoginRadiusUserIdentity> GetAccountProfileByPhone(string phone)
        {
            Validate(new [] { phone });
            var additionalQueryParams = new QueryParameters { { "phone", phone } };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.Get, null,
                additionalQueryParams);
        }

        public ApiResponse<LoginRadiusUserIdentity> GetAccountProfileByUid(string uId)
        {
            Validate(new [] { uId });
            var pattern = new LoginRadiusResoucePath("{0}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.Get, resourcePath);
        }

        public ApiResponse<LoginRadiusUserIdentity> UpdateAccount(string uId, LoginRadiusAccountUpdateModel user)
        {
            Validate(new [] { uId });
            var pattern = new LoginRadiusResoucePath("{0}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.Put, resourcePath,
                user.ConvertToJson());
        }

        public ApiResponse<LoginRadiusDeleteResponse> DeleteAccount(string uId)
        {
            Validate(new [] { uId });
            var pattern = new LoginRadiusResoucePath("{0}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.Delete, resourcePath,
                "");
        }

        public ApiResponse<HashPassword> SetAccountPassword(string uId, string password)
        {
            Validate(new [] { uId, password });
            var pattern = new LoginRadiusResoucePath("{0}/password").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            var passwordbody = new BodyParameters { ["password"] = password };
            return ConfigureAndExecute<HashPassword>(RequestType.Identity, HttpMethod.Put, resourcePath,
                passwordbody.ConvertToJson());
        }

        public ApiResponse<HashPassword> GetAccountPassword(string uId)
        {
            Validate(new [] { uId });
            var pattern = new LoginRadiusResoucePath("{0}/password").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            return ConfigureAndExecute<HashPassword>(RequestType.Identity, HttpMethod.Get, resourcePath, "");
        }

        public ApiResponse<UpdatePhoneResponse> PhoneNumberUpdate(string accessToken, ResetPasswordbyOtpModel model , string smsTemplate = "")
        {
            Validate(new [] { accessToken });
            var additionalparms = new QueryParameters {{"smsTemplate", smsTemplate}, {"access_token", accessToken}};
            return ConfigureAndExecute<UpdatePhoneResponse>(RequestType.Authentication, HttpMethod.Put, "phone", additionalparms, model.ConvertToJson());
        }

        public ApiResponse<LoginRadiusUserIdentity> ChangeAccountPhone(string uId, string phone)
        {
            Validate(new [] { uId });
            var pattern = new LoginRadiusResoucePath("{0}/PhoneId").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            var payload = new BodyParameters { ["phone"] = phone };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.Put, resourcePath,
                payload.ConvertToJson());
        }


        public ApiResponse<LoginRadiusPassword> GetForgotPasswordToken(string email)
        {
            Validate(new [] { email });
            var payload = new BodyParameters { ["email"] = email };
            return ConfigureAndExecute<LoginRadiusPassword>(RequestType.Identity, HttpMethod.Post, "forgot/token",
                payload.ConvertToJson());
        }


        public ApiResponse<LoginRadiusVerification> EmailVerificationToken(string email)
        {
            Validate(new [] { email });
            var payload = new BodyParameters { ["email"] = email };
            return ConfigureAndExecute<LoginRadiusVerification>(RequestType.Identity, HttpMethod.Post, "verify/token",
                payload.ConvertToJson());
        }

        public ApiResponse<AccessTokenResponse> AccessTokenBasedUID(string uid)
        {
            Validate(new [] { uid });
            var additionalQueryParams = new QueryParameters { { "uid", uid } };
            return ConfigureAndExecute<AccessTokenResponse>(RequestType.Identity, HttpMethod.Get, "access_token",
                additionalQueryParams);
        }

        public ApiResponse<AccessTokenResponse> Token_Validity(string accessToken)
        {
            Validate(new [] { accessToken });
            var additionalQueryParams = new QueryParameters { { "access_token", accessToken } };
            return ConfigureAndExecute<AccessTokenResponse>(RequestType.Authentication, HttpMethod.Get,
                "access_token/validate", additionalQueryParams);
        }

        public ApiResponse<LoginRadiusPostResponse> Token_Invalidate(string accessToken)
        {
            Validate(new [] { accessToken });
            var additionalQueryParams = new QueryParameters { { "access_token", accessToken } };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Get,
                "access_token/invalidate", additionalQueryParams);
        }

        public ApiResponse<AccessTokenResponse> User_impersonation(string uid)
        {
            Validate(new [] { uid });
            var additionalQueryParams = new QueryParameters { { "uid", uid } };
            return ConfigureAndExecute<AccessTokenResponse>(RequestType.Identity, HttpMethod.Get, "access_token",
                additionalQueryParams);
        }


        public ApiResponse<LoginRadiusUserIdentity> PhoneUpdateSecurityQuestion(string uid,
              SecurityQuestion obj)
        {
            Validate(new [] { uid });
            var pattern = new LoginRadiusResoucePath("{0}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid });
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.Put, resourcePath,
                obj.ConvertToJson());
        }

        /// <summary>
        /// Resets email verfication process for a user's account. <para> See <a href="https://docs.loginradius.com/api/v2/">LoginRadius Developer documentation</a> for more information. </para>
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <param name="optionalParams">Gets or sets API optional parameters, <see cref="LoginRadiusApiOptionalParams"/></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusPostResponse> ResetEmailIdVerification(string uid, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new [] { uid });
            var pattern = new LoginRadiusResoucePath("{0}/invalidateemail").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid });
            var additionalparams = new QueryParameters();
            if (!string.IsNullOrEmpty(optionalParams.VerificationUrl))
                additionalparams.Add("verificationUrl", optionalParams.VerificationUrl);
            if (!string.IsNullOrEmpty(optionalParams.EmailTemplate))
                additionalparams.Add("EmailTemplate", optionalParams.EmailTemplate);
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Identity, HttpMethod.Put, resourcePath, additionalparams);
        }

        public ApiResponse<SottResponseData> GetSott(int timeDifference = 10)
        {
            Validate(new [] { timeDifference });
            var additionalQueryParams = new QueryParameters { { "timedifference", timeDifference.ToString() } };
            return ConfigureAndExecute<SottResponseData>(RequestType.Identity, HttpMethod.Get, "sott", additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public ApiResponse<AccountIdentities> GetAccountIdentitiesByEmail(string email)
        {
            Validate(new[] { email });
            var additionalQueryParams = new QueryParameters { { "email", email } };
            return ConfigureAndExecute<AccountIdentities>(RequestType.Identity, HttpMethod.Get, "identities", additionalQueryParams);
        }

        /// <summary>
        /// Resets Phone ID verfication process for a user's account. See <a href="https://docs.loginradius.com/api/v2/">LoginRadius Developer documentation</a> for more information.
        /// </summary>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <param name="optionalParams">Gets or sets API optional parameters, <see cref="LoginRadiusApiOptionalParams"/></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusPostResponse> ResetPhoneIdVerification(string uid, LoginRadiusApiOptionalParams optionalParams)
        {
            Validate(new[] { uid });
            var pattern = new LoginRadiusResoucePath("{0}/invalidatephone").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid });
            var additionalparams = new QueryParameters();
            if (!string.IsNullOrEmpty(optionalParams.EmailTemplate)) additionalparams.Add("SmsTemplate", optionalParams.EmailTemplate);
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Identity, HttpMethod.Put, resourcePath, additionalparams);
        }
    }
}