//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects

{

    public class ConfigResponseModel
    {
        public SocialSchema SocialSchema { get; set; }
        public List<RegistrationFormSchema> RegistrationFormSchema { get; set; }
        public SecurityQuestionsBase SecurityQuestions { get; set; }
        public bool IsHttps { get; set; }
        public string AppName { get; set; }
        public bool IsCustomerRegistration { get; set; }
        public ApiVersion ApiVersion { get; set; }
        public string EmailVerificationFlow { get; set; }
        public bool IsPhoneLogin { get; set; }
        public bool IsDisabledSocialRegistration { get; set; }
        public bool IsDisabledAccountLinking { get; set; }
        public bool IsAgeRestriction { get; set; }
        public bool IsSecurityQuestion { get; set; }
        public bool AskRequiredFieldsOnTraditionalLogin { get; set; }
        public bool IsLogoutOnEmailVerification { get; set; }
        public bool IsNoCallbackForSocialLogin { get; set; }
        public bool IsUserNameLogin { get; set; }
        public bool IsMobileCallbackForSocialLogin { get; set; }
        public bool IsInvisibleRecaptcha { get; set; }
        public bool IsBackendJobEnabled { get; set; }
        public bool AskPasswordOnSocialLogin { get; set; }
        public bool AskEmailIdForUnverifiedUserLogin { get; set; }
        public bool AskOptionalFieldsOnSocialSignup { get; set; }
        public bool IsRiskBasedAuthentication { get; set; }
        public bool IsV2Recaptcha { get; set; }
        public bool CheckPhoneNoAvailabilityOnRegistration { get; set; }
        public bool DuplicateEmailWithUniqueUsername { get; set; }
        public bool StoreOnlyRegistrationFormFieldsForSocial { get; set; }
        public bool OTPEmailVerification { get; set; }
        public LoginLockedConfiguration LoginLockedConfiguration { get; set; }
        public IsInstantSignin IsInstantSignin { get; set; }
        public bool IsLoginOnEmailVerification { get; set; }
        public TwoFactorAuthentication TwoFactorAuthentication { get; set; }
        public bool IsRememberMe { get; set; }
        public string V2RecaptchaSiteKey { get; set; }
        public string QQTencentCaptchaKey { get; set; }
        public bool NoRegistration { get; set; }
        public object CustomDomain { get; set; }
        public PrivacyPolicyConfiguration PrivacyPolicyConfiguration { get; set; }
        public OptionalRecaptchaConfiguration OptionalRecaptchaConfiguration { get; set; }
        public ApiRequestSigningConfig ApiRequestSigningConfig { get; set; }
    }
    public class Provider
    {
        public string Name { get; set; }
        public string Endpoint { get; set; }
    }

    public class SocialSchema
    {
        public List<Provider> Providers { get; set; }
    }

    public class RegistrationFormSchema
    {
        public bool Checked { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string display { get; set; }
        public string rules { get; set; }
        public object options { get; set; }
        public string permission { get; set; }
        public object DataSource { get; set; }
        public string Parent { get; set; }
        public object ParentDataSource { get; set; }
    }

    public class SecurityQuestionsBase
    {
        public List<object> Questions { get; set; }
        public int SecurityQuestionCount { get; set; }
    }

    public class ApiVersion
    {
        public bool v1 { get; set; }
        public bool v2 { get; set; }
    }

    public class SuspendConfiguration
    {
        public int EffectivePeriodInSeconds { get; set; }
    }

    public class LoginLockedConfiguration
    {
        public string LoginLockedType { get; set; }
        public int MaximumFailedLoginAttempts { get; set; }
        public SuspendConfiguration SuspendConfiguration { get; set; }
    }

    public class IsInstantSignin
    {
        public bool EmailLink { get; set; }
        public bool SmsOtp { get; set; }
    }

    public class TwoFactorAuthentication
    {
        public bool IsEnabled { get; set; }
        public bool IsRequired { get; set; }
        public bool IsGoogleAuthenticator { get; set; }
    }

    public class PrivacyPolicyConfiguration
    {
    }

    public class Apis
    {
        public bool PostForgotPasswordByEmail { get; set; }
        public bool PostForgotPasswordByPhone { get; set; }
        public bool PutChangePassword { get; set; }
        public bool PostLoginByEmailAndPassword { get; set; }
        public bool PostLoginByUserNameAndPassword { get; set; }
        public bool PostLoginByPhoneAndPassword { get; set; }
        public bool PutUpdateProfile { get; set; }
    }

    public class OptionalRecaptchaConfiguration
    {
        public bool IsEnabled { get; set; }
        public Apis Apis { get; set; }
    }

    public class ApiRequestSigningConfig
    {
        public bool IsEnabled { get; set; }
        public string Mode { get; set; }
    }
    
	/// <summary>
	///	Response containing Definition of Complete service info data
	/// </summary>
    public class ServiceInfoModel
    {
		/// <summary>
		///	Current time
		/// </summary>
		[JsonProperty(PropertyName = "CurrentTime")]
        public  string CurrentTime {get;set;}

		/// <summary>
		///	Location of server
		/// </summary>
		[JsonProperty(PropertyName = "ServerLocation")]
        public  string ServerLocation {get;set;}

		/// <summary>
		///	server name
		/// </summary>
		[JsonProperty(PropertyName = "ServerName")]
        public  string ServerName {get;set;}

		/// <summary>
		///	SOTT is a secure one time token
		/// </summary>
		[JsonProperty(PropertyName = "Sott")]
        public  ServiceSottInfo Sott {get;set;}

    }
}