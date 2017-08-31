using System.Collections;
using LoginRadiusSDK.V2.Entity;
using LoginRadiusSDK.V2.Models;
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
            Validate(new ArrayList { userIdentity.Email, userIdentity.Password });
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.Post, null,
                userIdentity.ConvertToJson());
        }

        public ApiResponse<LoginRadiusUserIdentity> GetAccountProfileByEmail(string email)
        {
            Validate(new ArrayList { email });
            var additionalQueryParams = new QueryParameters { { "email", email } };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.Get, null,
                additionalQueryParams);
        }

        public ApiResponse<LoginRadiusUserIdentity> GetAccountProfileByUserName(string userName)
        {
            Validate(new ArrayList { userName });
            var additionalQueryParams = new QueryParameters { { "username", userName } };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.Get, null,
                additionalQueryParams);
        }

        public ApiResponse<LoginRadiusUserIdentity> GetAccountProfileByPhone(string phone)
        {
            Validate(new ArrayList { phone });
            var additionalQueryParams = new QueryParameters { { "phone", phone } };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.Get, null,
                additionalQueryParams);
        }

        public ApiResponse<LoginRadiusUserIdentity> GetAccountProfileByUid(string uId)
        {
            Validate(new ArrayList { uId });
            var pattern = new LoginRadiusResoucePath("{0}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.Get, resourcePath);
        }

        public ApiResponse<LoginRadiusUserIdentity> UpdateAccount(string uId, LoginRadiusAccountUpdateModel user)
        {
            Validate(new ArrayList { uId });
            var pattern = new LoginRadiusResoucePath("{0}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.Put, resourcePath,
                user.ConvertToJson());
        }

        public ApiResponse<LoginRadiusDeleteResponse> DeleteAccount(string uId)
        {
            Validate(new ArrayList { uId });
            var pattern = new LoginRadiusResoucePath("{0}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            return ConfigureAndExecute<LoginRadiusDeleteResponse>(RequestType.Identity, HttpMethod.Delete, resourcePath,
                "");
        }

        public ApiResponse<HashPassword> SetAccountPassword(string uId, string password)
        {
            Validate(new ArrayList { uId, password });
            var pattern = new LoginRadiusResoucePath("{0}/password").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            var passwordbody = new BodyParameters { ["password"] = password };
            return ConfigureAndExecute<HashPassword>(RequestType.Identity, HttpMethod.Put, resourcePath,
                passwordbody.ConvertToJson());
        }

        public ApiResponse<HashPassword> GetAccountPassword(string uId)
        {
            Validate(new ArrayList { uId });
            var pattern = new LoginRadiusResoucePath("{0}/password").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            return ConfigureAndExecute<HashPassword>(RequestType.Identity, HttpMethod.Get, resourcePath, "");
        }

        public ApiResponse<UpdatePhoneResponse> PhoneNumberUpdate(string access_token, ResetPasswordbyOtpModel model , string smsTemplate = "")
        {
            Validate(new ArrayList { access_token });
            var additionalparms = new QueryParameters();
            additionalparms.Add("smsTemplate", smsTemplate);
            additionalparms.Add("access_token", access_token);

            return ConfigureAndExecute<UpdatePhoneResponse>(RequestType.Authentication, HttpMethod.Put, "phone", additionalparms, model.ConvertToJson());
        }

        public ApiResponse<LoginRadiusUserIdentity> ChangeAccountPhone(string uId, string phone)
        {
            Validate(new ArrayList { uId });
            var pattern = new LoginRadiusResoucePath("{0}/PhoneId").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uId });
            var payload = new BodyParameters { ["phone"] = phone };
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.Put, resourcePath,
                payload.ConvertToJson());
        }


        public ApiResponse<LoginRadiusPassword> GetForgotPasswordToken(string email)
        {
            Validate(new ArrayList { email });
            var payload = new BodyParameters { ["email"] = email };
            return ConfigureAndExecute<LoginRadiusPassword>(RequestType.Identity, HttpMethod.Post, "forgot/token",
                payload.ConvertToJson());
        }


        public ApiResponse<LoginRadiusVerification> EmailVerificationToken(string email)
        {
            Validate(new ArrayList { email });
            var payload = new BodyParameters { ["email"] = email };
            return ConfigureAndExecute<LoginRadiusVerification>(RequestType.Identity, HttpMethod.Post, "verify/token",
                payload.ConvertToJson());
        }

        public ApiResponse<AccessTokenResponse> AccessTokenBasedUID(string uid)
        {
            Validate(new ArrayList { uid });
            var additionalQueryParams = new QueryParameters { { "uid", uid } };
            return ConfigureAndExecute<AccessTokenResponse>(RequestType.Identity, HttpMethod.Get, "access_token",
                additionalQueryParams);
        }

        public ApiResponse<AccessTokenResponse> Token_Validity(string access_token)
        {
            Validate(new ArrayList { access_token });
            var additionalQueryParams = new QueryParameters { { "access_token", access_token } };
            return ConfigureAndExecute<AccessTokenResponse>(RequestType.Authentication, HttpMethod.Get,
                "access_token/validate", additionalQueryParams);
        }

        public ApiResponse<LoginRadiusPostResponse> Token_Invalidate(string access_token)
        {
            Validate(new ArrayList { access_token });
            var additionalQueryParams = new QueryParameters { { "access_token", access_token } };
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Authentication, HttpMethod.Get,
                "access_token/invalidate", additionalQueryParams);
        }

        public ApiResponse<AccessTokenResponse> User_impersonation(string uid)
        {
            Validate(new ArrayList { uid });
            var additionalQueryParams = new QueryParameters { { "uid", uid } };
            return ConfigureAndExecute<AccessTokenResponse>(RequestType.Identity, HttpMethod.Get, "access_token",
                additionalQueryParams);
        }


        public ApiResponse<LoginRadiusUserIdentity> PhoneUpdateSecurityQuestion(string uid,
              SecurityQuestion obj)
        {
            Validate(new ArrayList { uid });
            var pattern = new LoginRadiusResoucePath("{0}").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid });
            return ConfigureAndExecute<LoginRadiusUserIdentity>(RequestType.Identity, HttpMethod.Put, resourcePath,
                obj.ConvertToJson());
        }



        public ApiResponse<LoginRadiusPostResponse> AccountInvalidateVerificationEmail(string uid, LoginRadiusApiOptionalParams _LoginRadiusApiOptionalParams)
        {
            Validate(new ArrayList { uid });
            var pattern = new LoginRadiusResoucePath("{0}/invalidateemail").ToString();
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { uid });
            var additionalparams = new QueryParameters();
            if (!string.IsNullOrEmpty(_LoginRadiusApiOptionalParams.VerificationUrl))
                additionalparams.Add("verificationUrl", _LoginRadiusApiOptionalParams.VerificationUrl);
            if (!string.IsNullOrEmpty(_LoginRadiusApiOptionalParams.EmailTemplate))
                additionalparams.Add("EmailTemplate", _LoginRadiusApiOptionalParams.EmailTemplate);
            return ConfigureAndExecute<LoginRadiusPostResponse>(RequestType.Identity, HttpMethod.Put, resourcePath, additionalparams);
        }
    }
}