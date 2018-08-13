using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRadiusSDK.V2.Models.Configuration
{
  public  class ConfigurationResponse
    {
        public SocialSchema SocialSchema { get; set; }
        public List<RegistrationFormSchema> RegistrationFormSchema { get; set; }
        public SecurityQuestions SecurityQuestions { get; set; }
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
        public TwoFactorAuthenticationData TwoFactorAuthentication { get; set; }
        public bool IsRememberMe { get; set; }
        public string V2RecaptchaSiteKey { get; set; }
        public string QQTencentCaptchaKey { get; set; }
        public bool NoRegistration { get; set; }
        public object CustomDomain { get; set; }
        public PrivacyPolicyConfiguration PrivacyPolicyConfiguration { get; set; }
    }
}
