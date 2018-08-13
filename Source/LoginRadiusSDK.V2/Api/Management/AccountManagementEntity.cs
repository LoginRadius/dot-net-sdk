using System.Collections.Generic;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.CustomerAuthentication.Account;
using LoginRadiusSDK.V2.Models.Identity;
using LoginRadiusSDK.V2.Models.Object;
using LoginRadiusSDK.V2.Models.UserProfile;
using LoginRadiusSDK.V2.Util;
using static LoginRadiusSDK.V2.Util.LoginRadiusArgumentValidator;
using LoginRadiusSDK.V2.Models.Password;

namespace LoginRadiusSDK.V2.Api
{
    public class AccountManagementEntity : LoginRadiusResource
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userIdentity"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusUserIdentity> CreateAccount(UserIdentityCreateModel userIdentity)
        {
            Validate(new List<object> { userIdentity.Email, userIdentity.Password });
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.POST, null,
                userIdentity.ConvertToJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusUserIdentity> GetAccountProfileByEmail(string email)
        {
            Validate(new [] { email });
            var additionalQueryParams = new QueryParameters { { nameof(email), email } };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.GET, null,
                additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusUserIdentity> GetAccountProfileByUserName(string userName)
        {
            Validate(new [] { userName });
            var additionalQueryParams = new QueryParameters { { nameof(userName), userName } };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.GET, null,
                additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusUserIdentity> GetAccountProfileByPhone(string phone)
        {
            Validate(new [] { phone });
            var additionalQueryParams = new QueryParameters { { nameof(phone), phone } };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.GET, null,
                additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusUserIdentity> GetAccountProfileByUid(string uId)
        {
            Validate(new [] { uId });
            var pattern = new LoginRadiusResoucePath("{0}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.GET, resourcePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusUserIdentity> UpdateAccount(string uId, LoginRadiusAccountUpdateModel user)
        {
            Validate(new [] { uId });
            var pattern = new LoginRadiusResoucePath("{0}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.PUT, resourcePath,
                user.ConvertToJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusDeleteResponse> DeleteAccount(string uId)
        {
            Validate(new [] { uId });
            var pattern = new LoginRadiusResoucePath("{0}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.DELETE, resourcePath,
                "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ApiResponse<HashPassword> SetAccountPassword(string uId, string password)
        {
            Validate(new [] { uId, password });
            var pattern = new LoginRadiusResoucePath("{0}/password").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            var passwordbody = new BodyParameters { [nameof(password)] = password };
            return ConfigureAndExecute<HashPassword>(RequestType.Identity, HttpMethod.PUT, resourcePath,
                passwordbody.ConvertToJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        public ApiResponse<HashPassword> GetAccountPassword(string uId)
        {
            Validate(new [] { uId });
            var pattern = new LoginRadiusResoucePath("{0}/password").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            return ConfigureAndExecute<HashPassword>(RequestType.Identity, HttpMethod.GET, resourcePath, "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="model"></param>
        /// <param name="smsTemplate"></param>
        /// <returns></returns>
        public ApiResponse<UpdatePhoneResponse> PhoneNumberUpdate(string accessToken, ResetPasswordbyOtpModel model, 
            string smsTemplate = "")
        {
            Validate(new[] { accessToken });
            var additionalparms = new QueryParameters { { nameof(smsTemplate), smsTemplate }, { "access_token", accessToken } };
            return ConfigureAndExecute<UpdatePhoneResponse>(RequestType.Authentication, HttpMethod.PUT, "phone", additionalparms, model.ConvertToJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusUserIdentity> ChangeAccountPhone(string uId, string phone)
        {
            Validate(new [] { uId });
            var pattern = new LoginRadiusResoucePath("{0}/PhoneId").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            var payload = new BodyParameters { [nameof(phone)] = phone };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.PUT, resourcePath,
                payload.ConvertToJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public ApiResponse<ForgotPasswordToken> GetForgotPasswordToken(string email = "", string username = "")
        {
            var payload = new BodyParameters { [nameof(email)] = email, [nameof(username)] = username };
            return ConfigureAndExecute<ForgotPasswordToken>(RequestType.Identity, HttpMethod.POST, "forgot/token",
                payload.ConvertToJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusVerification> EmailVerificationToken(string email)
        {
            Validate(new [] { email });
            var payload = new BodyParameters { [nameof(email)] = email };
            return ConfigureAndExecute<LoginRadiusVerification>(RequestType.Identity, HttpMethod.POST, "verify/token",
                payload.ConvertToJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public ApiResponse<AccessTokenResponse> AccessTokenBasedUID(string uid)
        {
            Validate(new [] { uid });
            var additionalQueryParams = new QueryParameters { { nameof(uid), uid } };
            return ConfigureAndExecute<AccessTokenResponse>(RequestType.Identity, HttpMethod.GET, "access_token",
                additionalQueryParams);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public ApiResponse<AccessTokenResponse> Token_Validity(string accessToken)
        {
            Validate(new [] { accessToken });
            var additionalQueryParams = new QueryParameters { { "access_token", accessToken } };
            return ConfigureAndExecute<AccessTokenResponse>(RequestType.Authentication, HttpMethod.GET,
                "access_token/validate", additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusPostResponse> Token_Invalidate(string accessToken)
        {
            Validate(new [] { accessToken });
            var additionalQueryParams = new QueryParameters { { "access_token", accessToken } };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.GET,
                "access_token/invalidate", additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public ApiResponse<AccessTokenResponse> User_impersonation(string uid)
        {
            Validate(new [] { uid });
            var additionalQueryParams = new QueryParameters { { nameof(uid), uid } };
            return ConfigureAndExecute<AccessTokenResponse>(RequestType.Identity, HttpMethod.GET, "access_token",
                additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ApiResponse<LoginRadiusUserIdentity> PhoneUpdateSecurityQuestion(string uid,
              SecurityQuestion obj)
        {
            Validate(new [] { uid });
            var pattern = new LoginRadiusResoucePath("{0}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid });
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.PUT, resourcePath,
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
                additionalparams.Add(nameof(optionalParams.VerificationUrl), optionalParams.VerificationUrl);
            if (!string.IsNullOrEmpty(optionalParams.EmailTemplate))
                additionalparams.Add(nameof(optionalParams.EmailTemplate), optionalParams.EmailTemplate);
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Identity, HttpMethod.PUT, resourcePath, additionalparams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeDifference"></param>
        /// <returns></returns>
        public ApiResponse<SottResponseData> GetSott(int timeDifference = 10)
        {
            Validate(new [] { timeDifference });
            var additionalQueryParams = new QueryParameters { { nameof(timeDifference), timeDifference.ToString() } };
            return ConfigureAndExecute<SottResponseData>(RequestType.Identity, HttpMethod.GET, "sott", additionalQueryParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public ApiResponse<AccountIdentities> GetAccountIdentitiesByEmail(string email)
        {
            Validate(new[] { email });
            var additionalQueryParams = new QueryParameters { { nameof(email), email } };
            return ConfigureAndExecute<AccountIdentities>(RequestType.Identity, HttpMethod.GET, "identities", additionalQueryParams);
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
            if (!string.IsNullOrEmpty(optionalParams.SmsTemplate)) additionalparams.Add(nameof(optionalParams.SmsTemplate), optionalParams.SmsTemplate);
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Identity, HttpMethod.PUT, resourcePath, additionalparams);
        }
    }
}