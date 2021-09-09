//-----------------------------------------------------------------------
// <copyright file="RiskBasedAuthenticationApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LoginRadiusSDK.V2.Common;
using System.Threading.Tasks;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels;
using LoginRadiusSDK.V2.Models.ResponseModels.UserProfile;
using LoginRadiusSDK.V2.Models.RequestModels;

namespace LoginRadiusSDK.V2.Api.Authentication
{
    public class RiskBasedAuthenticationApi : LoginRadiusResource
    {
        /// <summary>
        /// This API retrieves a copy of the user data based on the Email
        /// </summary>
        /// <param name="emailAuthenticationModel">Model Class containing Definition of payload for Email Authentication API</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="loginUrl">Url where the user is logging from</param>
        /// <param name="passwordDelegation">Password Delegation Allows you to use a third-party service to store your passwords rather than LoginRadius Cloud storage.</param>
        /// <param name="passwordDelegationApp">RiskBased Authentication Password Delegation App</param>
        /// <param name="rbaBrowserEmailTemplate">Risk Based Authentication Browser EmailTemplate</param>
        /// <param name="rbaBrowserSmsTemplate">Risk Based Authentication Browser Sms Template</param>
        /// <param name="rbaCityEmailTemplate">Risk Based Authentication City Email Template</param>
        /// <param name="rbaCitySmsTemplate">Risk Based Authentication City SmsTemplate</param>
        /// <param name="rbaCountryEmailTemplate">Risk Based Authentication Country EmailTemplate</param>
        /// <param name="rbaCountrySmsTemplate">Risk Based Authentication Country SmsTemplate</param>
        /// <param name="rbaIpEmailTemplate">Risk Based Authentication Ip EmailTemplate</param>
        /// <param name="rbaIpSmsTemplate">Risk Based Authentication Ip SmsTemplate</param>
        /// <param name="rbaOneclickEmailTemplate">Risk Based Authentication Oneclick EmailTemplate</param>
        /// <param name="rbaOTPSmsTemplate">Risk Based Authentication Oneclick EmailTemplate</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 9.2.4

        public async Task<ApiResponse<AccessToken<Identity>>> RBALoginByEmail(EmailAuthenticationModel emailAuthenticationModel, string emailTemplate = null,
        string fields = "", string loginUrl = null, bool? passwordDelegation = null, string passwordDelegationApp = null, string rbaBrowserEmailTemplate = null,
        string rbaBrowserSmsTemplate = null, string rbaCityEmailTemplate = null, string rbaCitySmsTemplate = null, string rbaCountryEmailTemplate = null,
        string rbaCountrySmsTemplate = null, string rbaIpEmailTemplate = null, string rbaIpSmsTemplate = null, string rbaOneclickEmailTemplate = null,
        string rbaOTPSmsTemplate = null, string smsTemplate = null, string verificationUrl = null)
        {
            if (emailAuthenticationModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(emailAuthenticationModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(loginUrl))
            {
               queryParameters.Add("loginUrl", loginUrl);
            }
            if (passwordDelegation != false)
            {
               queryParameters.Add("passwordDelegation", passwordDelegation.ToString());
            }
            if (!string.IsNullOrWhiteSpace(passwordDelegationApp))
            {
               queryParameters.Add("passwordDelegationApp", passwordDelegationApp);
            }
            if (!string.IsNullOrWhiteSpace(rbaBrowserEmailTemplate))
            {
               queryParameters.Add("rbaBrowserEmailTemplate", rbaBrowserEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaBrowserSmsTemplate))
            {
               queryParameters.Add("rbaBrowserSmsTemplate", rbaBrowserSmsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCityEmailTemplate))
            {
               queryParameters.Add("rbaCityEmailTemplate", rbaCityEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCitySmsTemplate))
            {
               queryParameters.Add("rbaCitySmsTemplate", rbaCitySmsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCountryEmailTemplate))
            {
               queryParameters.Add("rbaCountryEmailTemplate", rbaCountryEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCountrySmsTemplate))
            {
               queryParameters.Add("rbaCountrySmsTemplate", rbaCountrySmsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaIpEmailTemplate))
            {
               queryParameters.Add("rbaIpEmailTemplate", rbaIpEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaIpSmsTemplate))
            {
               queryParameters.Add("rbaIpSmsTemplate", rbaIpSmsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaOneclickEmailTemplate))
            {
               queryParameters.Add("rbaOneclickEmailTemplate", rbaOneclickEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaOTPSmsTemplate))
            {
               queryParameters.Add("rbaOTPSmsTemplate", rbaOTPSmsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }

            var resourcePath = "identity/v2/auth/login";
            
            return await ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(emailAuthenticationModel));
        }
        /// <summary>
        /// This API retrieves a copy of the user data based on the Username
        /// </summary>
        /// <param name="userNameAuthenticationModel">Model Class containing Definition of payload for Username Authentication API</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="loginUrl">Url where the user is logging from</param>
        /// <param name="passwordDelegation">Password Delegation Allows you to use a third-party service to store your passwords rather than LoginRadius Cloud storage.</param>
        /// <param name="passwordDelegationApp">RiskBased Authentication Password Delegation App</param>
        /// <param name="rbaBrowserEmailTemplate">Risk Based Authentication Browser EmailTemplate</param>
        /// <param name="rbaBrowserSmsTemplate">Risk Based Authentication Browser Sms Template</param>
        /// <param name="rbaCityEmailTemplate">Risk Based Authentication City Email Template</param>
        /// <param name="rbaCitySmsTemplate">Risk Based Authentication City SmsTemplate</param>
        /// <param name="rbaCountryEmailTemplate">Risk Based Authentication Country EmailTemplate</param>
        /// <param name="rbaCountrySmsTemplate">Risk Based Authentication Country SmsTemplate</param>
        /// <param name="rbaIpEmailTemplate">Risk Based Authentication Ip EmailTemplate</param>
        /// <param name="rbaIpSmsTemplate">Risk Based Authentication Ip SmsTemplate</param>
        /// <param name="rbaOneclickEmailTemplate">Risk Based Authentication Oneclick EmailTemplate</param>
        /// <param name="rbaOTPSmsTemplate">Risk Based Authentication OTPSmsTemplate</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 9.2.5

        public async Task<ApiResponse<AccessToken<Identity>>> RBALoginByUserName(UserNameAuthenticationModel userNameAuthenticationModel, string emailTemplate = null,
        string fields = "", string loginUrl = null, bool? passwordDelegation = null, string passwordDelegationApp = null, string rbaBrowserEmailTemplate = null,
        string rbaBrowserSmsTemplate = null, string rbaCityEmailTemplate = null, string rbaCitySmsTemplate = null, string rbaCountryEmailTemplate = null,
        string rbaCountrySmsTemplate = null, string rbaIpEmailTemplate = null, string rbaIpSmsTemplate = null, string rbaOneclickEmailTemplate = null,
        string rbaOTPSmsTemplate = null, string smsTemplate = null, string verificationUrl = null)
        {
            if (userNameAuthenticationModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(userNameAuthenticationModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(loginUrl))
            {
               queryParameters.Add("loginUrl", loginUrl);
            }
            if (passwordDelegation != false)
            {
               queryParameters.Add("passwordDelegation", passwordDelegation.ToString());
            }
            if (!string.IsNullOrWhiteSpace(passwordDelegationApp))
            {
               queryParameters.Add("passwordDelegationApp", passwordDelegationApp);
            }
            if (!string.IsNullOrWhiteSpace(rbaBrowserEmailTemplate))
            {
               queryParameters.Add("rbaBrowserEmailTemplate", rbaBrowserEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaBrowserSmsTemplate))
            {
               queryParameters.Add("rbaBrowserSmsTemplate", rbaBrowserSmsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCityEmailTemplate))
            {
               queryParameters.Add("rbaCityEmailTemplate", rbaCityEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCitySmsTemplate))
            {
               queryParameters.Add("rbaCitySmsTemplate", rbaCitySmsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCountryEmailTemplate))
            {
               queryParameters.Add("rbaCountryEmailTemplate", rbaCountryEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCountrySmsTemplate))
            {
               queryParameters.Add("rbaCountrySmsTemplate", rbaCountrySmsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaIpEmailTemplate))
            {
               queryParameters.Add("rbaIpEmailTemplate", rbaIpEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaIpSmsTemplate))
            {
               queryParameters.Add("rbaIpSmsTemplate", rbaIpSmsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaOneclickEmailTemplate))
            {
               queryParameters.Add("rbaOneclickEmailTemplate", rbaOneclickEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaOTPSmsTemplate))
            {
               queryParameters.Add("rbaOTPSmsTemplate", rbaOTPSmsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }

            var resourcePath = "identity/v2/auth/login";
            
            return await ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(userNameAuthenticationModel));
        }
        /// <summary>
        /// This API retrieves a copy of the user data based on the Phone
        /// </summary>
        /// <param name="phoneAuthenticationModel">Model Class containing Definition of payload for PhoneAuthenticationModel API</param>
        /// <param name="emailTemplate">Email template name</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="loginUrl">Url where the user is logging from</param>
        /// <param name="passwordDelegation">Password Delegation Allows you to use a third-party service to store your passwords rather than LoginRadius Cloud storage.</param>
        /// <param name="passwordDelegationApp">RiskBased Authentication Password Delegation App</param>
        /// <param name="rbaBrowserEmailTemplate">Risk Based Authentication Browser EmailTemplate</param>
        /// <param name="rbaBrowserSmsTemplate">Risk Based Authentication Browser Sms Template</param>
        /// <param name="rbaCityEmailTemplate">Risk Based Authentication City Email Template</param>
        /// <param name="rbaCitySmsTemplate">Risk Based Authentication City SmsTemplate</param>
        /// <param name="rbaCountryEmailTemplate">Risk Based Authentication Country EmailTemplate</param>
        /// <param name="rbaCountrySmsTemplate">Risk Based Authentication Country SmsTemplate</param>
        /// <param name="rbaIpEmailTemplate">Risk Based Authentication Ip EmailTemplate</param>
        /// <param name="rbaIpSmsTemplate">Risk Based Authentication Ip SmsTemplate</param>
        /// <param name="rbaOneclickEmailTemplate">Risk Based Authentication Oneclick EmailTemplate</param>
        /// <param name="rbaOTPSmsTemplate">Risk Based Authentication OTPSmsTemplate</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <param name="verificationUrl">Email verification url</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 9.2.6

        public async Task<ApiResponse<AccessToken<Identity>>> RBALoginByPhone(PhoneAuthenticationModel phoneAuthenticationModel, string emailTemplate = null,
        string fields = "", string loginUrl = null, bool? passwordDelegation = null, string passwordDelegationApp = null, string rbaBrowserEmailTemplate = null,
        string rbaBrowserSmsTemplate = null, string rbaCityEmailTemplate = null, string rbaCitySmsTemplate = null, string rbaCountryEmailTemplate = null,
        string rbaCountrySmsTemplate = null, string rbaIpEmailTemplate = null, string rbaIpSmsTemplate = null, string rbaOneclickEmailTemplate = null,
        string rbaOTPSmsTemplate = null, string smsTemplate = null, string verificationUrl = null)
        {
            if (phoneAuthenticationModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(phoneAuthenticationModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(emailTemplate))
            {
               queryParameters.Add("emailTemplate", emailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(loginUrl))
            {
               queryParameters.Add("loginUrl", loginUrl);
            }
            if (passwordDelegation != false)
            {
               queryParameters.Add("passwordDelegation", passwordDelegation.ToString());
            }
            if (!string.IsNullOrWhiteSpace(passwordDelegationApp))
            {
               queryParameters.Add("passwordDelegationApp", passwordDelegationApp);
            }
            if (!string.IsNullOrWhiteSpace(rbaBrowserEmailTemplate))
            {
               queryParameters.Add("rbaBrowserEmailTemplate", rbaBrowserEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaBrowserSmsTemplate))
            {
               queryParameters.Add("rbaBrowserSmsTemplate", rbaBrowserSmsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCityEmailTemplate))
            {
               queryParameters.Add("rbaCityEmailTemplate", rbaCityEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCitySmsTemplate))
            {
               queryParameters.Add("rbaCitySmsTemplate", rbaCitySmsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCountryEmailTemplate))
            {
               queryParameters.Add("rbaCountryEmailTemplate", rbaCountryEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaCountrySmsTemplate))
            {
               queryParameters.Add("rbaCountrySmsTemplate", rbaCountrySmsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaIpEmailTemplate))
            {
               queryParameters.Add("rbaIpEmailTemplate", rbaIpEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaIpSmsTemplate))
            {
               queryParameters.Add("rbaIpSmsTemplate", rbaIpSmsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaOneclickEmailTemplate))
            {
               queryParameters.Add("rbaOneclickEmailTemplate", rbaOneclickEmailTemplate);
            }
            if (!string.IsNullOrWhiteSpace(rbaOTPSmsTemplate))
            {
               queryParameters.Add("rbaOTPSmsTemplate", rbaOTPSmsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }
            if (!string.IsNullOrWhiteSpace(verificationUrl))
            {
               queryParameters.Add("verificationUrl", verificationUrl);
            }

            var resourcePath = "identity/v2/auth/login";
            
            return await ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(phoneAuthenticationModel));
        }
    }
}