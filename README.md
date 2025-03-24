# LoginRadius .NET SDK


![Home Image](http://docs.lrcontent.com/resources/github/banner-1544x500.png)

## Introduction ##

LoginRadius ASP.NET Customer Registration wrapper provides access to LoginRadius Identity Management Platform API.

LoginRadius is an Identity Management Platform that simplifies user registration while securing data. LoginRadius Platform simplifies and secures your user registration process, increases conversion with Social Login that combines 30 major social platforms, and offers a full solution with Traditional User Registration. You can gather a wealth of user profile data from Social Login or Traditional User Registration. 

LoginRadius centralizes it all in one place, making it easy to manage and access. Easily integrate LoginRadius with all of your third-party applications, like MailChimp, Google Analytics, Livefyre and many more, making it easy to utilize the data you are capturing.

LoginRadius helps businesses boost user engagement on their web/mobile platform, manage online identities, utilize social media for marketing, capture accurate consumer data, and get unique social insight into their customer base.

Please visit [here](http://www.loginradius.com/) for more information.


## Prerequisites

* .NET 4.0 or later / .NetStandard 1.3 or later

## Installation
This documentation presumes you have worked through the client-side implementation to setup your LoginRadius User Registration interfaces that will serve the initial registration and login process. Details on this can be found in the [getting started guide](https://www.loginradius.com/docs/api/v2/getting-started/introduction).

**Note: **LoginRadius uses the industry standard TLS 1.2 protocol, designed to help protect the privacy of information communicated over the Internet. In order to use the LoginRadius .Net SDK, add the following code before instantiating your web service in your project's `Global.asax` file.

```c#
ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
```

## Importing Required Libraries
- Download the User Registration .Net SDK from [Github](https://github.com/LoginRadius/dot-net-sdk)

- Copy LoginRadiusSDK.V2.dll and LoginRadiusSDK.V2.pdb files into the References directory of your ASP.NET project.

OR

- Run the following command in the NuGet Package Manager Console:

```
PM> Install-Package LoginRadiusSDK.NET
```

OR

- Open the solution using Visual Studio 2019.

- Build the project and note where the .nupkg file is located.

- Access the NuGet Package Manager Settings and import the directory where the .nupkg file is located.

- Access the "Manage NuGet Packages for Solutions..." tool change the source to the newly created source and select and install the LoginRadius SDK

Next, include the following namespaces in your project:


```c#
using LoginRadiusSDK.V2.Api;
using LoginRadiusSDK.V2.Models;
```
## Quickstart Guide

Before using the SDK, you must initialize the SDK with the help of following code:
API Key and secret of your LoginRadius site. This information can be found in your LoginRadius account as described [here](https://www.loginradius.com/docs/api/v2/admin-console/platform-security/api-key-and-secret/#api-key-and-secret)

```c#
LoginRadiusSdkGlobalConfig.ApiKey = "__API_KEY__";
LoginRadiusSdkGlobalConfig.ApiSecret = "__API_SECRET__";
LoginRadiusSdkGlobalConfig.AppName = "__LoginRadius_APP_NAME__";
LoginRadiusSdkGlobalConfig.ApiRequestSigning ="false";
LoginRadiusSdkGlobalConfig.ConnectionTimeout = 30000; // Connection Timeout (milliseconds)
LoginRadiusSdkGlobalConfig.ProxyAddress = "__HTTP_PROXY_ADDRESS__"; // Absolute Proxy URI
LoginRadiusSdkGlobalConfig.ProxyCredentials = "__HTTP_PROXY_CREDENTIALS__"; // Proxy Credentials in the format 'USERNAME:PASSWORD'
LoginRadiusSdkGlobalConfig.RequestRetries = 3;
LoginRadiusSdkGlobalConfig.ApiRegion = "_region_";
LoginRadiusSdkGlobalConfig.DomainName = "https://api.loginradius.com/";
```

OR

For ASP.NET. in  `web.config`:
```xml
  <configSections>
    <section name="loginradius" type="LoginRadiusSDK.V2.SDKConfigHandler, LoginRadiusSDK.V2" />
  </configSections>

  <!-- LoginRadius SDK settings -->
  <loginradius>
    <settings>
      <add name="apiKey" value="__API_KEY__" />
      <add name="apiSecret" value="__API_SECRET__" />
      <add name="appName" value="__LoginRadius_APP_NAME__"/>
	  <add name="ApiRequestSigning" value="false"/>
      <add name="proxyAddress" value="__HTTP_PROXY_ADDRESS__" /> <!-- Absolute Proxy URI -->
      <add name="proxyCredentials" value="__HTTP_PROXY_CREDENTIALS__" /> <!-- Proxy Credentials in the format 'USERNAME:PASSWORD' -->
      <add name="connectionTimeout" value="__HTTP_CONNECTION_TIMEOUT__" /> <!-- Connection Timeout (milliseconds) -->
      <add name="requestRetries" value="__HTTP_CONNECTION_RETRY__" />
      <add name="apiRegion" value="_region_" />
      <add name="domainName" value="https://api.loginradius.com/" />
    </settings>
  </loginradius>
```
OR

For .NET Core, in `appsettings.json`:

**JSON**
```json
"loginradius": {
    "apiKey": "__API_KEY__",
    "apiSecret": "__API_SECRET__",
    "appName" : "__LoginRadius_APP_NAME__",
	"ApiRequestSigning" : "false",
    "proxyAddress" : "__HTTP_PROXY_ADDRESS__",
    "proxyCredentials" : "__HTTP_PROXY_CREDENTIAL__",
    "connectionTimeout" : "__HTTP_CONNECTION_TIMEOUT__",
    "requestRetries" : "__HTTP_CONNECTION_RETRY__",
    "apiRegion": "_region_",
    "domainName" : "https://api.loginradius.com/"
  }

 ```

 ### Custom Domain
When initializing the SDK, optionally specify a custom domain.
Example : In appsettings.json, add following statement - 

```json
"domainName" : "https://api.loginradius.com/"
```



### API Request Signing
When initializing the SDK, you can optionally specify enabling this feature. Enabling this feature means the customer does not need to pass an API secret in an API request. Instead, they can pass a dynamically generated hash value. This feature will also make sure that the message is not tampered during transit when someone calls our APIs.
Example : In appsettings.json, add following statement -

```json
"ApiRequestSigning" : "false"
```

X-Origin-IP
LoginRadius allows you add X-Origin-IP in your headers and it determines the IP address of the client's request,this can also be useful to overcome analytics discrepancies where the analytics depend on header data.


```json
"originIp" : "<Client-Ip-Address>"
```

## APIs



### Authentication API


List of APIs in this Section:<br>
[PUT : Auth Update Profile by Token](#UpdateProfileByAccessToken-put-)<br>
[PUT : Auth Unlock Account by Access Token](#UnlockAccountByToken-put-)<br>
[PUT : Auth Verify Email By OTP](#VerifyEmailByOTP-put-)<br>
[PUT : Auth Reset Password by Security Answer and Email](#ResetPasswordBySecurityAnswerAndEmail-put-)<br>
[PUT : Auth Reset Password by Security Answer and Phone](#ResetPasswordBySecurityAnswerAndPhone-put-)<br>
[PUT : Auth Reset Password by Security Answer and UserName](#ResetPasswordBySecurityAnswerAndUserName-put-)<br>
[PUT : Auth Reset Password by Reset Token](#ResetPasswordByResetToken-put-)<br>
[PUT : Auth Reset Password by OTP](#ResetPasswordByEmailOTP-put-)<br>
[PUT : Auth Reset Password by OTP and UserName](#ResetPasswordByOTPAndUserName-put-)<br>
[PUT : Auth Change Password](#ChangePassword-put-)<br>
[POST : Auth Link Social Identities](#LinkSocialIdentities-post-)<br>
[POST : Auth Link Social Identities By Ping](#LinkSocialIdentitiesByPing-post-)<br>
[PUT : Auth Set or Change UserName](#SetOrChangeUserName-put-)<br>
[PUT : Auth Resend Email Verification](#AuthResendEmailVerification-put-)<br>
[POST : Auth Add Email](#AddEmail-post-)<br>
[POST : Auth Login by Email](#LoginByEmail-post-)<br>
[POST : Auth Login by Username](#LoginByUserName-post-)<br>
[POST : Auth Forgot Password](#ForgotPassword-post-)<br>
[POST : Auth User Registration by Email](#UserRegistrationByEmail-post-)<br>
[POST : Auth User Registration By Captcha](#UserRegistrationByCaptcha-post-)<br>
[GET : Get Security Questions By Email](#GetSecurityQuestionsByEmail-get-)<br>
[GET : Get Security Questions By UserName](#GetSecurityQuestionsByUserName-get-)<br>
[GET : Get Security Questions By Phone](#GetSecurityQuestionsByPhone-get-)<br>
[GET : Get Security Questions By Access Token](#GetSecurityQuestionsByAccessToken-get-)<br>
[GET : Auth Validate Access token](#AuthValidateAccessToken-get-)<br>
[GET : Access Token Invalidate](#AuthInValidateAccessToken-get-)<br>
[GET : Access Token Info](#GetAccessTokenInfo-get-)<br>
[GET : Auth Read all Profiles by Token](#GetProfileByAccessToken-get-)<br>
[GET : Auth Send Welcome Email](#SendWelcomeEmail-get-)<br>
[GET : Auth Delete Account](#DeleteAccountByDeleteToken-get-)<br>
[GET : Get Profile By Ping](#GetProfileByPing-get-)<br>
[GET : Auth Check Email Availability](#CheckEmailAvailability-get-)<br>
[GET : Auth Verify Email](#VerifyEmail-get-)<br>
[GET : Auth Social Identity](#GetSocialIdentity-get-)<br>
[GET : Auth Check UserName Availability](#CheckUserNameAvailability-get-)<br>
[GET : Auth Privacy Policy Accept](#AcceptPrivacyPolicy-get-)<br>
[GET : Auth Privacy Policy History By Access Token](#GetPrivacyPolicyHistoryByAccessToken-get-)<br>
[GET : Auth send verification Email for linking social profiles](#AuthSendVerificationEmailForLinkingSocialProfiles-get-)<br>
[DELETE : Auth Delete Account with Email Confirmation](#DeleteAccountWithEmailConfirmation-delete-)<br>
[DELETE : Auth Remove Email](#RemoveEmail-delete-)<br>
[DELETE : Auth Unlink Social Identities](#UnlinkSocialIdentities-delete-)<br>



<h6 id="UpdateProfileByAccessToken-put-">Auth Update Profile by Token (PUT)</h6>


This API is used to update the user's profile by passing the access_token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-update-profile-by-token/)



```c#

var accessToken = "accessToken"; //Required
UserProfileUpdateModel userProfileUpdateModel = new UserProfileUpdateModel{
FirstName ="<FirstName>",
LastName ="<LastName>"
}; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
; //Optional
var smsTemplate = "smsTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var isVoiceOtp = false; //Optional
var options = "options"; //Optional
var apiResponse = new AuthenticationApi().UpdateProfileByAccessToken(accessToken, userProfileUpdateModel, emailTemplate, fields, smsTemplate, verificationUrl, isVoiceOtp, options).Result;
```


<h6 id="UnlockAccountByToken-put-">Auth Unlock Account by Access Token (PUT)</h6>

This API is used to allow a customer with a valid access_token to unlock their account provided that they successfully pass the prompted Bot Protection challenges. The Block or Suspend block types are not applicable for this API. For additional details see our Auth Security Configuration documentation.You are only required to pass the Post Parameters that correspond to the prompted challenges. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-unlock-account-by-access-token/)



```c#

var accessToken = "accessToken"; //Required
UnlockProfileModel unlockProfileModel = new UnlockProfileModel{
G_recaptcha_response ="<G-recaptcha-response>"
}; //Required
var apiResponse = new AuthenticationApi().UnlockAccountByToken(accessToken, unlockProfileModel).Result;
```


<h6 id="VerifyEmailByOTP-put-">Auth Verify Email By OTP (PUT)</h6>

This API is used to verify the email of user when the OTP Email verification flow is enabled, please note that you must contact LoginRadius to have this feature enabled. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-verify-email-by-otp/)



```c#

EmailVerificationByOtpModel emailVerificationByOtpModel = new EmailVerificationByOtpModel{
Email ="<Email>",
Otp ="<Otp>"
}; //Required
string fields = null; //Optional
var url = "url"; //Optional
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new AuthenticationApi().VerifyEmailByOTP(emailVerificationByOtpModel, fields, url, welcomeEmailTemplate).Result;
```


<h6 id="ResetPasswordBySecurityAnswerAndEmail-put-">Auth Reset Password by Security Answer and Email (PUT)</h6>

This API is used to reset password for the specified account by security question [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-reset-password-by-email)



```c#

ResetPasswordBySecurityAnswerAndEmailModel resetPasswordBySecurityAnswerAndEmailModel = new ResetPasswordBySecurityAnswerAndEmailModel{
Email ="<Email>",
Password ="<Password>",
SecurityAnswer = new Dictionary<String,String>{
["QuestionID"] = "Answer"
}
}; //Required
var apiResponse = new AuthenticationApi().ResetPasswordBySecurityAnswerAndEmail(resetPasswordBySecurityAnswerAndEmailModel).Result;
```


<h6 id="ResetPasswordBySecurityAnswerAndPhone-put-">Auth Reset Password by Security Answer and Phone (PUT)</h6>

This API is used to reset password for the specified account by security question [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-reset-password-by-phone)



```c#

ResetPasswordBySecurityAnswerAndPhoneModel resetPasswordBySecurityAnswerAndPhoneModel = new ResetPasswordBySecurityAnswerAndPhoneModel{
Password ="<Password>",
Phone ="<Phone>",
SecurityAnswer = new Dictionary<String,String>{
["QuestionID"] = "Answer"
}
}; //Required
var apiResponse = new AuthenticationApi().ResetPasswordBySecurityAnswerAndPhone(resetPasswordBySecurityAnswerAndPhoneModel).Result;
```


<h6 id="ResetPasswordBySecurityAnswerAndUserName-put-">Auth Reset Password by Security Answer and UserName (PUT)</h6>

This API is used to reset password for the specified account by security question [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-reset-password-by-username)



```c#

ResetPasswordBySecurityAnswerAndUserNameModel resetPasswordBySecurityAnswerAndUserNameModel = new ResetPasswordBySecurityAnswerAndUserNameModel{
Password ="<Password>",
SecurityAnswer = new Dictionary<String,String>{
["QuestionID"] = "Answer"
},
UserName ="<UserName>"
}; //Required
var apiResponse = new AuthenticationApi().ResetPasswordBySecurityAnswerAndUserName(resetPasswordBySecurityAnswerAndUserNameModel).Result;
```


<h6 id="ResetPasswordByResetToken-put-">Auth Reset Password by Reset Token (PUT)</h6>

This API is used to set a new password for the specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-reset-password-by-reset-token)



```c#

ResetPasswordByResetTokenModel resetPasswordByResetTokenModel = new ResetPasswordByResetTokenModel{
Password ="<Password>",
ResetToken ="<ResetToken>"
}; //Required
var apiResponse = new AuthenticationApi().ResetPasswordByResetToken(resetPasswordByResetTokenModel).Result;
```


<h6 id="ResetPasswordByEmailOTP-put-">Auth Reset Password by OTP (PUT)</h6>

This API is used to set a new password for the specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-reset-password-by-otp)



```c#

ResetPasswordByEmailAndOtpModel resetPasswordByEmailAndOtpModel = new ResetPasswordByEmailAndOtpModel{
Email ="<Email>",
Otp ="<Otp>",
Password ="<Password>"
}; //Required
var apiResponse = new AuthenticationApi().ResetPasswordByEmailOTP(resetPasswordByEmailAndOtpModel).Result;
```


<h6 id="ResetPasswordByOTPAndUserName-put-">Auth Reset Password by OTP and UserName (PUT)</h6>

This API is used to set a new password for the specified account if you are using the username as the unique identifier in your workflow [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-reset-password-by-otp-and-username/)



```c#

ResetPasswordByUserNameModel resetPasswordByUserNameModel = new ResetPasswordByUserNameModel{
Otp ="<Otp>",
Password ="<Password>",
UserName ="<UserName>"
}; //Required
var apiResponse = new AuthenticationApi().ResetPasswordByOTPAndUserName(resetPasswordByUserNameModel).Result;
```


<h6 id="ChangePassword-put-">Auth Change Password (PUT)</h6>

This API is used to change the accounts password based on the previous password [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-change-password)



```c#

var accessToken = "accessToken"; //Required
var newPassword = "newPassword"; //Required
var oldPassword = "oldPassword"; //Required
var apiResponse = new AuthenticationApi().ChangePassword(accessToken, newPassword, oldPassword).Result;
```


<h6 id="LinkSocialIdentities-post-">Auth Link Social Identities (POST)</h6>

This API is used to link up a social provider account with the specified account based on the access token and the social providers user access token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-link-social-identities)



```c#

var accessToken = "accessToken"; //Required
var candidateToken = "candidateToken"; //Required
var apiResponse = new AuthenticationApi().LinkSocialIdentities(accessToken, candidateToken).Result;
```

<h6 id="LinkSocialIdentitiesByPing-post-">Auth Link Social Identities By Ping (POST)</h6>

This API is used to link up a social provider account with an existing LoginRadius account on the basis of ping and the social providers user access token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-link-social-identities-by-ping)



```c#

var accessToken = "accessToken"; //Required
var clientGuid = "clientGuid"; //Required
var apiResponse = new AuthenticationApi().LinkSocialIdentitiesByPing(accessToken, clientGuid).Result;
```

<h6 id="SetOrChangeUserName-put-">Auth Set or Change UserName (PUT)</h6>

This API is used to set or change UserName by access token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-set-or-change-user-name/)



```c#

var accessToken = "accessToken"; //Required
var username = "username"; //Required
var apiResponse = new AuthenticationApi().SetOrChangeUserName(accessToken, username).Result;
```


<h6 id="AuthResendEmailVerification-put-">Auth Resend Email Verification (PUT)</h6>

This API resends the verification email to the user. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-resend-email-verification/)



```c#

var email = "email"; //Required
var emailTemplate = "emailTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new AuthenticationApi().AuthResendEmailVerification(email, emailTemplate, verificationUrl).Result;
```


<h6 id="AddEmail-post-">Auth Add Email (POST)</h6>

This API is used to add additional emails to a user's account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-add-email)



```c#

var accessToken = "accessToken"; //Required
var email = "email"; //Required
var type = "type"; //Required
var emailTemplate = "emailTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new AuthenticationApi().AddEmail(accessToken, email, type, emailTemplate, verificationUrl).Result;
```


<h6 id="LoginByEmail-post-">Auth Login by Email (POST)</h6>

This API retrieves a copy of the user data based on the Email [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-login-by-email)



```c#

EmailAuthenticationModel emailAuthenticationModel = new EmailAuthenticationModel{
Email ="<Email>",
Password ="<Password>"
}; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
var loginUrl = "loginUrl"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new AuthenticationApi().LoginByEmail(emailAuthenticationModel, emailTemplate, fields, loginUrl, verificationUrl).Result;
```


<h6 id="LoginByUserName-post-">Auth Login by Username (POST)</h6>

This API retrieves a copy of the user data based on the Username [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-login-by-username)



```c#

UserNameAuthenticationModel userNameAuthenticationModel = new UserNameAuthenticationModel{
Password ="<Password>",
Username ="<Username>"
}; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
var loginUrl = "loginUrl"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new AuthenticationApi().LoginByUserName(userNameAuthenticationModel, emailTemplate, fields, loginUrl, verificationUrl).Result;
```


<h6 id="ForgotPassword-post-">Auth Forgot Password (POST)</h6>

This API is used to send the reset password url to a specified account. Note: If you have the UserName workflow enabled, you may replace the 'email' parameter with 'username' [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-forgot-password)



```c#

var email = "email"; //Required
var resetPasswordUrl = "resetPasswordUrl"; //Required
var emailTemplate = "emailTemplate"; //Optional
var apiResponse = new AuthenticationApi().ForgotPassword(email, resetPasswordUrl, emailTemplate).Result;
```


<h6 id="UserRegistrationByEmail-post-">Auth User Registration by Email (POST)</h6>

This API creates a user in the database as well as sends a verification email to the user. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-user-registration-by-email)



```c#

AuthUserRegistrationModel authUserRegistrationModel = new AuthUserRegistrationModel{
Email = new List<EmailModel>{
new EmailModel{
Type ="<Type>",
Value ="<Value>"
}},
FirstName ="<FirstName>",
LastName ="<LastName>",
Password ="<Password>"
}; //Required
var sott = "sott"; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
var options = "options"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var isVoiceOtp = false; //Optional
var apiResponse = new AuthenticationApi().UserRegistrationByEmail(authUserRegistrationModel, sott, emailTemplate, fields, options, verificationUrl, welcomeEmailTemplate, isVoiceOtp).Result;
```


<h6 id="UserRegistrationByCaptcha-post-">Auth User Registration By Captcha (POST)</h6>

This API creates a user in the database as well as sends a verification email to the user. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-user-registration-by-recaptcha)



```c#

AuthUserRegistrationModelWithCaptcha authUserRegistrationModelWithCaptcha = new AuthUserRegistrationModelWithCaptcha{
Email = new List<EmailModel>{
new EmailModel{
Type ="<Type>",
Value ="<Value>"
}},
FirstName ="<FirstName>",
G_recaptcha_response ="<G-recaptcha-response>",
LastName ="<LastName>",
Password ="<Password>"
}; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
var options = "options"; //Optional
var smsTemplate = "smsTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var isVoiceOtp = false; //Optional
var apiResponse = new AuthenticationApi().UserRegistrationByCaptcha(authUserRegistrationModelWithCaptcha, emailTemplate, fields, options, smsTemplate, verificationUrl, welcomeEmailTemplate, isVoiceOtp).Result;
```


<h6 id="GetSecurityQuestionsByEmail-get-">Get Security Questions By Email (GET)</h6>

This API is used to retrieve the list of questions that are configured on the respective LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/security-questions-by-email/)



```c#

var email = "email"; //Required
var apiResponse = new AuthenticationApi().GetSecurityQuestionsByEmail(email).Result;
```


<h6 id="GetSecurityQuestionsByUserName-get-">Get Security Questions By UserName (GET)</h6>

This API is used to retrieve the list of questions that are configured on the respective LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/security-questions-by-user-name/)



```c#

var userName = "userName"; //Required
var apiResponse = new AuthenticationApi().GetSecurityQuestionsByUserName(userName).Result;
```


<h6 id="GetSecurityQuestionsByPhone-get-">Get Security Questions By Phone (GET)</h6>

This API is used to retrieve the list of questions that are configured on the respective LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/security-questions-by-phone/)



```c#

var phone = "phone"; //Required
var apiResponse = new AuthenticationApi().GetSecurityQuestionsByPhone(phone).Result;
```


<h6 id="GetSecurityQuestionsByAccessToken-get-">Get Security Questions By Access Token (GET)</h6>

This API is used to retrieve the list of questions that are configured on the respective LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/security-questions-by-access-token/)



```c#

var accessToken = "accessToken"; //Required
var apiResponse = new AuthenticationApi().GetSecurityQuestionsByAccessToken(accessToken).Result;
```


<h6 id="AuthValidateAccessToken-get-">Auth Validate Access token (GET)</h6>

This api validates access token, if valid then returns a response with its expiry otherwise error. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-validate-access-token/)



```c#

var accessToken = "accessToken"; //Required
var apiResponse = new AuthenticationApi().AuthValidateAccessToken(accessToken).Result;
```


<h6 id="AuthInValidateAccessToken-get-">Access Token Invalidate (GET)</h6>

This api call invalidates the active access token or expires an access token's validity. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-invalidate-access-token/)



```c#

var accessToken = "accessToken"; //Required
var preventRefresh = true; //Optional
var apiResponse = new AuthenticationApi().AuthInValidateAccessToken(accessToken, preventRefresh).Result;
```


<h6 id="GetAccessTokenInfo-get-">Access Token Info (GET)</h6>

This api call provide the active access token Information [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-access-token-info/)



```c#

var accessToken = "accessToken"; //Required
var apiResponse = new AuthenticationApi().GetAccessTokenInfo(accessToken).Result;
```


<h6 id="GetProfileByAccessToken-get-">Auth Read all Profiles by Token (GET)</h6>

This API retrieves a copy of the user data based on the access_token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-read-profiles-by-token/)



```c#

var accessToken = "accessToken"; //Required
string fields = null; //Optional
var emailTemplate = "emailTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new AuthenticationApi().GetProfileByAccessToken(accessToken,fields, emailTemplate, verificationUrl, welcomeEmailTemplate).Result;
```



<h6 id="SendWelcomeEmail-get-">Auth Send Welcome Email (GET)</h6>

This API sends a welcome email [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-send-welcome-email/)



```c#

var accessToken = "accessToken"; //Required
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new AuthenticationApi().SendWelcomeEmail(accessToken, welcomeEmailTemplate).Result;
```


<h6 id="DeleteAccountByDeleteToken-get-">Auth Delete Account (GET)</h6>

This API is used to delete an account by passing it a delete token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-delete-account/)



```c#

var deleteToken = "deleteToken"; //Required
var apiResponse = new AuthenticationApi().DeleteAccountByDeleteToken(deleteToken).Result;
```

<h6 id="GetProfileByPing-get-">Get Profile By Ping (GET)</h6>

This API is used to get a user's profile using the clientGuid parameter if no callback feature enabled [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-get-profile-by-ping/)



```c#

var clientGuid = "clientGuid"; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
var verificationUrl = "verificationUrl"; //Optional
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new AuthenticationApi().GetProfileByPing(clientGuid, emailTemplate, fields, verificationUrl, welcomeEmailTemplate).Result;
```


<h6 id="CheckEmailAvailability-get-">Auth Check Email Availability (GET)</h6>

This API is used to check the email exists or not on your site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-email-availability/)



```c#

var email = "email"; //Required
var apiResponse = new AuthenticationApi().CheckEmailAvailability(email).Result;
```


<h6 id="VerifyEmail-get-">Auth Verify Email (GET)</h6>

This API is used to verify the email of user. Note: This API will only return the full profile if you have 'Enable auto login after email verification' set in your LoginRadius Admin Console's Email Workflow settings under 'Verification Email'. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-verify-email/)



```c#

var verificationToken = "verificationToken"; //Required
string fields = null; //Optional
var url = "url"; //Optional
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var uuid = "uuid"; //Optional
var apiResponse = new AuthenticationApi().VerifyEmail(verificationToken, fields, url, welcomeEmailTemplate,uuid).Result;
```


<h6 id="GetSocialIdentity-get-">Auth Social Identity (GET)</h6>

This API is called just after account linking API and it prevents the raas profile of the second account from getting created. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-social-identity)



```c#

var accessToken = "accessToken"; //Required
string fields = null; //Optional
var apiResponse = new AuthenticationApi().GetSocialIdentity(accessToken, fields).Result;
```


<h6 id="CheckUserNameAvailability-get-">Auth Check UserName Availability (GET)</h6>

This API is used to check the UserName exists or not on your site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-username-availability/)



```c#

var username = "username"; //Required
var apiResponse = new AuthenticationApi().CheckUserNameAvailability(username).Result;
```


<h6 id="AcceptPrivacyPolicy-get-">Auth Privacy Policy Accept (GET)</h6>

This API is used to update the privacy policy stored in the user's profile by providing the access_token of the user accepting the privacy policy [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-privacy-policy-accept)



```c#

var accessToken = "accessToken"; //Required
string fields = null; //Optional
var apiResponse = new AuthenticationApi().AcceptPrivacyPolicy(accessToken, fields).Result;
```


<h6 id="GetPrivacyPolicyHistoryByAccessToken-get-">Auth Privacy Policy History By Access Token (GET)</h6>

This API will return all the accepted privacy policies for the user by providing the access_token of that user. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/privacy-policy-history-by-access-token/)



```c#

var accessToken = "accessToken"; //Required
var apiResponse = new AuthenticationApi().GetPrivacyPolicyHistoryByAccessToken(accessToken).Result;
```

<h6 id="AuthSendVerificationEmailForLinkingSocialProfiles-get-">Auth send verification Email for linking social profiles (GET)</h6>

This API is used to Send verification email to the unverified email of the social profile. This API can be used only incase of optional verification workflow. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-send-verification-for-social-email/)



```c#

var accessToken = "accessToken"; //Required
var clientguid = "clientguid"; //Required
var apiResponse = new AuthenticationApi().AuthSendVerificationEmailForLinkingSocialProfiles(accessToken, clientguid).Result;
```


<h6 id="DeleteAccountWithEmailConfirmation-delete-">Auth Delete Account with Email Confirmation (DELETE)</h6>

This API will send a confirmation email for account deletion to the customer's email when passed the customer's access token [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-delete-account-with-email-confirmation/)



```c#

var accessToken = "accessToken"; //Required
var deleteUrl = "deleteUrl"; //Optional
var emailTemplate = "emailTemplate"; //Optional
var apiResponse = new AuthenticationApi().DeleteAccountWithEmailConfirmation(accessToken, deleteUrl, emailTemplate).Result;
```


<h6 id="RemoveEmail-delete-">Auth Remove Email (DELETE)</h6>

This API is used to remove additional emails from a user's account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-remove-email)



```c#

var accessToken = "accessToken"; //Required
var email = "email"; //Required
var apiResponse = new AuthenticationApi().RemoveEmail(accessToken, email).Result;
```


<h6 id="UnlinkSocialIdentities-delete-">Auth Unlink Social Identities (DELETE)</h6>

This API is used to unlink up a social provider account with the specified account based on the access token and the social providers user access token. The unlinked account will automatically get removed from your database. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-unlink-social-identities)



```c#

var accessToken = "accessToken"; //Required
var provider = "provider"; //Required
var providerId = "providerId"; //Required
var apiResponse = new AuthenticationApi().UnlinkSocialIdentities(accessToken, provider, providerId).Result;
```







### Account API


List of APIs in this Section:<br>
[PUT : Account Update](#UpdateAccountByUid-put-)<br>
[PUT : Update Phone ID by UID](#UpdatePhoneIDByUid-put-)<br>
[PUT : Account Set Password](#SetAccountPasswordByUid-put-)<br>
[PUT : Account Invalidate Verification Email](#InvalidateAccountEmailVerification-put-)<br>
[PUT : Reset phone ID verification](#ResetPhoneIDVerificationByUid-put-)<br>
[PUT : Upsert Email](#UpsertEmail-put-)<br>
[PUT : Update UID](#AccountUpdateUid-put-)<br>
[POST : Account Create](#CreateAccount-post-)<br>
[POST : Forgot Password token](#GetForgotPasswordToken-post-)<br>
[POST : Email Verification token](#GetEmailVerificationToken-post-)<br>
[POST : Multipurpose Email Token Generation API](#MultipurposeEmailTokenGeneration-post-)<br>
[POST : Multipurpose SMS OTP Generation API](#MultipurposeSMSOTPGeneration-post-)<br>
[GET : Get Privacy Policy History By Uid](#GetPrivacyPolicyHistoryByUid-get-)<br>
[GET : Account Profiles by Email](#GetAccountProfileByEmail-get-)<br>
[GET : Account Profiles by Username](#GetAccountProfileByUserName-get-)<br>
[GET : Account Profile by Phone ID](#GetAccountProfileByPhone-get-)<br>
[GET : Account Profiles by UID](#GetAccountProfileByUid-get-)<br>
[GET : Account Password](#GetAccountPasswordHashByUid-get-)<br>
[GET : Access Token based on UID or User impersonation API](#GetAccessTokenByUid-get-)<br>
[GET : Refresh Access Token by Refresh Token](#RefreshAccessTokenByRefreshToken-get-)<br>
[GET : Revoke Refresh Token](#RevokeRefreshToken-get-)<br>
[GET : Account Identities by Email](#GetAccountIdentitiesByEmail-get-)<br>
[DELETE : Account Delete](#DeleteAccountByUid-delete-)<br>
[DELETE : Account Remove Email](#RemoveEmail-delete-)<br>
[DELETE : Revoke All Refresh Token](#RevokeAllRefreshToken-delete-)<br>
[DELETE : Delete User Profiles By Email](#AccountDeleteByEmail-delete-)<br>



<h6 id="UpdateAccountByUid-put-">Account Update (PUT)</h6>

This API is used to update the information of existing accounts in your Cloud Storage. See our Advanced API Usage section <a href='https://www.loginradius.com/docs/api/v2/customer-identity-api/advanced-api-usage/'>Here</a> for more capabilities. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-update)



```c#

AccountUserProfileUpdateModel accountUserProfileUpdateModel = new AccountUserProfileUpdateModel{
FirstName ="<FirstName>",
LastName ="<LastName>"
}; //Required
var uid = "uid"; //Required
string fields = null; //Optional
; //Optional
var apiResponse = new AccountApi().UpdateAccountByUid(accountUserProfileUpdateModel, uid, fields).Result;
```


<h6 id="UpdatePhoneIDByUid-put-">Update Phone ID by UID (PUT)</h6>

This API is used to update the PhoneId by using the Uid's. Admin can update the PhoneId's for both the verified and unverified profiles. It will directly replace the PhoneId and bypass the OTP verification process. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/update-phoneid-by-uid)



```c#

var phone = "phone"; //Required
var uid = "uid"; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().UpdatePhoneIDByUid(phone, uid, fields).Result;
```


<h6 id="SetAccountPasswordByUid-put-">Account Set Password (PUT)</h6>

This API is used to set the password of an account in Cloud Storage. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-set-password)



```c#

var password = "password"; //Required
var uid = "uid"; //Required
var apiResponse = new AccountApi().SetAccountPasswordByUid(password, uid).Result;
```


<h6 id="InvalidateAccountEmailVerification-put-">Account Invalidate Verification Email (PUT)</h6>

This API is used to invalidate the Email Verification status on an account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-invalidate-verification-email)



```c#

var uid = "uid"; //Required
var emailTemplate = "emailTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new AccountApi().InvalidateAccountEmailVerification(uid, emailTemplate, verificationUrl).Result;
```


<h6 id="ResetPhoneIDVerificationByUid-put-">Reset phone ID verification (PUT)</h6>

This API Allows you to reset the phone no verification of an end user’s account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/reset-phone-id-verification)



```c#

var uid = "uid"; //Required
var smsTemplate = "smsTemplate"; //Optional
var isVoiceOtp = false; //Optional
var apiResponse = new AccountApi().ResetPhoneIDVerificationByUid(uid, smsTemplate, isVoiceOtp).Result;
```


<h6 id="UpsertEmail-put-">Upsert Email (PUT)</h6>

This API is used to add/upsert another emails in account profile by different-different email types. If the email type is same then it will simply update the existing email, otherwise it will add a new email in Email array. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/upsert-email)



```c#

UpsertEmailModel upsertEmailModel = new UpsertEmailModel{
Email = new List<EmailModel>{
new EmailModel{
Type ="<Type>",
Value ="<Value>"
}}
}; //Required
var uid = "uid"; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().UpsertEmail(upsertEmailModel, uid, fields).Result;
```


<h6 id="AccountUpdateUid-put-">Update UID (PUT)</h6>

This API is used to update a user's Uid. It will update all profiles, custom objects and consent management logs associated with the Uid. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-update/)



```c#

UpdateUidModel updateUidModel = new UpdateUidModel{
NewUid ="<NewUid>"
}; //Required
var uid = "uid"; //Required
var apiResponse = new AccountApi().AccountUpdateUid(updateUidModel, uid).Result;
```



<h6 id="CreateAccount-post-">Account Create (POST)</h6>

This API is used to create an account in Cloud Storage. This API bypass the normal email verification process and manually creates the user. <br><br>In order to use this API, you need to format a JSON request body with all of the mandatory fields [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-create)



```c#

AccountCreateModel accountCreateModel = new AccountCreateModel{
Email = new List<EmailModel>{
new EmailModel{
Type ="<Type>",
Value ="<Value>"
}},
FirstName ="<FirstName>",
LastName ="<LastName>",
Password ="<Password>"
}; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().CreateAccount(accountCreateModel, fields).Result;
```


<h6 id="GetForgotPasswordToken-post-">Forgot Password token (POST)</h6>

This API Returns a Forgot Password Token it can also be used to send a Forgot Password email to the customer. Note: If you have the UserName workflow enabled, you may replace the 'email' parameter with 'username' in the body. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/get-forgot-password-token)



```c#

var email = "email"; //Required
var emailTemplate = "emailTemplate"; //Optional
var resetPasswordUrl = "resetPasswordUrl"; //Optional
var sendEmail = true; //Optional
var apiResponse = new AccountApi().GetForgotPasswordToken(email, emailTemplate, resetPasswordUrl, sendEmail).Result;
```


<h6 id="GetEmailVerificationToken-post-">Email Verification token (POST)</h6>

This API Returns an Email Verification token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/get-email-verification-token)



```c#

var email = "email"; //Required
var apiResponse = new AccountApi().GetEmailVerificationToken(email).Result;
```


<h6 id="MultipurposeEmailTokenGeneration-post-">Multipurpose Email Token Generation API (POST)</h6>

This API generate Email tokens and Email OTPs for Email verification, Add email, Forgot password, Delete user, Passwordless login, Forgot pin, One-touch login and Auto login. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/multipurpose-token-and-sms-otp-generation-api/multipurpose-email-token-generation/)



```c#

MultiEmailToken multiEmailToken = new MultiEmailToken{
Clientguid ="<Clientguid>",
Email ="<Email>",
Name ="<Name>",
Type ="<Type>",
Uid ="<Uid>",
UserName ="<UserName>"
}; //Required
var tokentype = "tokentype"; //Required
var apiResponse = new AccountApi().MultipurposeEmailTokenGeneration(multiEmailToken, tokentype).Result;
```


<h6 id="MultipurposeSMSOTPGeneration-post-">Multipurpose SMS OTP Generation API (POST)</h6>

This API generates SMS OTP for Add phone, Phone Id verification, Forgot password, Forgot pin, One-touch login, smart login and Passwordless login. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/multipurpose-token-and-sms-otp-generation-api/multipurpose-sms-otp-generation/)



```c#

MultiSmsOtp multiSmsOtp = new MultiSmsOtp{
Name ="<Name>",
Phone ="<Phone>",
Uid ="<Uid>"
}; //Required
var smsotptype = "smsotptype"; //Required
var apiResponse = new AccountApi().MultipurposeSMSOTPGeneration(multiSmsOtp, smsotptype).Result;
```


<h6 id="GetPrivacyPolicyHistoryByUid-get-">Get Privacy Policy History By Uid (GET)</h6>

This API is used to retrieve all of the accepted Policies by the user, associated with their UID. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/privacy-policy-history-by-uid/)



```c#

var uid = "uid"; //Required
var apiResponse = new AccountApi().GetPrivacyPolicyHistoryByUid(uid).Result;
```


<h6 id="GetAccountProfileByEmail-get-">Account Profiles by Email (GET)</h6>

This API is used to retrieve all of the profile data, associated with the specified account by email in Cloud Storage. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-profiles-by-email)



```c#

var email = "email"; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().GetAccountProfileByEmail(email, fields).Result;
```


<h6 id="GetAccountProfileByUserName-get-">Account Profiles by Username (GET)</h6>

This API is used to retrieve all of the profile data associated with the specified account by user name in Cloud Storage. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-profiles-by-user-name)



```c#

var userName = "userName"; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().GetAccountProfileByUserName(userName, fields).Result;
```


<h6 id="GetAccountProfileByPhone-get-">Account Profile by Phone ID (GET)</h6>

This API is used to retrieve all of the profile data, associated with the account by phone number in Cloud Storage. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-profiles-by-phone-id/)



```c#

var phone = "phone"; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().GetAccountProfileByPhone(phone, fields).Result;
```


<h6 id="GetAccountProfileByUid-get-">Account Profiles by UID (GET)</h6>

This API is used to retrieve all of the profile data, associated with the account by uid in Cloud Storage. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-profiles-by-uid)



```c#

var uid = "uid"; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().GetAccountProfileByUid(uid, fields).Result;
```


<h6 id="GetAccountPasswordHashByUid-get-">Account Password (GET)</h6>

This API use to retrive the hashed password of a specified account in Cloud Storage. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-password)



```c#

var uid = "uid"; //Required
var apiResponse = new AccountApi().GetAccountPasswordHashByUid(uid).Result;
```


<h6 id="GetAccessTokenByUid-get-">Access Token based on UID or User impersonation API (GET)</h6>

The API is used to get LoginRadius access token based on UID. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-impersonation-api)



```c#

var uid = "uid"; //Required
var apiResponse = new AccountApi().GetAccessTokenByUid(uid).Result;
```


<h6 id="RefreshAccessTokenByRefreshToken-get-">Refresh Access Token by Refresh Token (GET)</h6>

This API is used to refresh an access_token via it's associated refresh_token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/refresh-token/refresh-access-token-by-refresh-token)



```c#

var refreshToken = "refreshToken"; //Required
var apiResponse = new AccountApi().RefreshAccessTokenByRefreshToken(refreshToken).Result;
```


<h6 id="RevokeRefreshToken-get-">Revoke Refresh Token (GET)</h6>

The Revoke Refresh Access Token API is used to revoke a refresh token or the Provider Access Token, revoking an existing refresh token will invalidate the refresh token but the associated access token will work until the expiry. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/refresh-token/revoke-refresh-token)



```c#

var refreshToken = "refreshToken"; //Required
var apiResponse = new AccountApi().RevokeRefreshToken(refreshToken).Result;
```


<h6 id="GetAccountIdentitiesByEmail-get-">Account Identities by Email (GET)</h6>

Note: This is intended for specific workflows where an email may be associated to multiple UIDs. This API is used to retrieve all of the identities (UID and Profiles), associated with a specified email in Cloud Storage. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-identities-by-email)



```c#

var email = "email"; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().GetAccountIdentitiesByEmail(email, fields).Result;
```


<h6 id="DeleteAccountByUid-delete-">Account Delete (DELETE)</h6>

This API deletes the Users account and allows them to re-register for a new account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-delete)



```c#

var uid = "uid"; //Required
var apiResponse = new AccountApi().DeleteAccountByUid(uid).Result;
```


<h6 id="RemoveEmail-delete-">Account Remove Email (DELETE)</h6>

Use this API to Remove emails from a user Account [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-email-delete)



```c#

var email = "email"; //Required
var uid = "uid"; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().RemoveEmail(email, uid, fields).Result;
```

<h6 id="RevokeAllRefreshToken-delete-">Revoke All Refresh Token (DELETE)</h6>

The Revoke All Refresh Access Token API is used to revoke all refresh tokens for a specific user. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/refresh-token/revoke-all-refresh-token/)



```c#

var uid = "uid"; //Required
var apiResponse = new AccountApi().RevokeAllRefreshToken(uid).Result;
```

<h6 id="AccountDeleteByEmail-delete-">Delete User Profiles By Email (DELETE)</h6>

This API is used to delete all user profiles associated with an Email. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-email-delete/)



```c#

var email = "email"; //Required
var apiResponse = new AccountApi().AccountDeleteByEmail(email).Result;
```







### Social API


List of APIs in this Section:<br>
[GET : Access Token](#ExchangeAccessToken-get-)<br>
[GET : Refresh Token](#RefreshAccessToken-get-)<br>
[GET : Token Validate](#ValidateAccessToken-get-)<br>
[GET : Access Token Invalidate](#InValidateAccessToken-get-)<br>
[GET : Get Active Session Details](#GetActiveSession-get-)<br>
[GET : Get Active Session By Account Id](#GetActiveSessionByAccountID-get-)<br>
[GET : Get Active Session By Profile Id](#GetActiveSessionByProfileID-get-)<br>


<h6 id="ExchangeAccessToken-get-">Access Token (GET)</h6>

This API Is used to translate the Request Token returned during authentication into an Access Token that can be used with other API calls. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/access-token)



```c#

var token = "token"; //Required
var apiResponse = new SocialApi().ExchangeAccessToken(token).Result;
```


<h6 id="RefreshAccessToken-get-">Refresh Token (GET)</h6>

The Refresh Access Token API is used to refresh the provider access token after authentication. It will be valid for up to 60 days on LoginRadius depending on the provider. In order to use the access token in other APIs, always refresh the token using this API.<br><br><b>Supported Providers :</b> Facebook,Yahoo,Google,Twitter, Linkedin.<br><br> Contact LoginRadius support team to enable this API. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/refresh-token/refresh-token)



```c#

var accessToken = "accessToken"; //Required
var expiresIn = 0; //Optional
var isWeb = true; //Optional
var apiResponse = new SocialApi().RefreshAccessToken(accessToken, expiresIn, isWeb).Result;
```


<h6 id="ValidateAccessToken-get-">Token Validate (GET)</h6>

This API validates access token, if valid then returns a response with its expiry otherwise error. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/validate-access-token)



```c#

var accessToken = "accessToken"; //Required
var apiResponse = new SocialApi().ValidateAccessToken(accessToken).Result;
```


<h6 id="InValidateAccessToken-get-">Access Token Invalidate (GET)</h6>

This api invalidates the active access token or expires an access token validity. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/invalidate-access-token)



```c#

var accessToken = "accessToken"; //Required
var apiResponse = new SocialApi().InValidateAccessToken(accessToken).Result;
```


<h6 id="GetActiveSession-get-">Get Active Session Details (GET)</h6>

This api is use to get all active session by Access Token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/get-active-session-details)



```c#

var token = "token"; //Required
var apiResponse = new SocialApi().GetActiveSession(token).Result;
```


<h6 id="GetActiveSessionByAccountID-get-">Get Active Session By Account Id (GET)</h6>

This api is used to get all active sessions by AccountID(UID). [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/active-session-by-account-id/)



```c#

var accountId = "accountId"; //Required
var apiResponse = new SocialApi().GetActiveSessionByAccountID(accountId).Result;
```


<h6 id="GetActiveSessionByProfileID-get-">Get Active Session By Profile Id (GET)</h6>

This api is used to get all active sessions by ProfileId. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/active-session-by-profile-id/)



```c#

var profileId = "profileId"; //Required
var apiResponse = new SocialApi().GetActiveSessionByProfileID(profileId).Result;
```



### CustomObject API


List of APIs in this Section:<br>
[PUT : Custom Object Update by Access Token](#UpdateCustomObjectByToken-put-)<br>
[PUT : Custom Object Update by UID](#UpdateCustomObjectByUid-put-)<br>
[POST : Create Custom Object by Token](#CreateCustomObjectByToken-post-)<br>
[POST : Create Custom Object by UID](#CreateCustomObjectByUid-post-)<br>
[GET : Custom Object by Token](#GetCustomObjectByToken-get-)<br>
[GET : Custom Object by ObjectRecordId and Token](#GetCustomObjectByRecordIDAndToken-get-)<br>
[GET : Custom Object By UID](#GetCustomObjectByUid-get-)<br>
[GET : Custom Object by ObjectRecordId and UID](#GetCustomObjectByRecordID-get-)<br>
[DELETE : Custom Object Delete by Record Id And Token](#DeleteCustomObjectByToken-delete-)<br>
[DELETE : Account Delete Custom Object by ObjectRecordId](#DeleteCustomObjectByRecordID-delete-)<br>

>**Note:** `CustomObject` must be valid JSON. For example:

```c#
public class cobj
  {
        public string field1 { get; set; }
        public string field2 { get; set; }
  }
```
```c#
cobj customObject = new cobj();
customObject.field1 = "XXXX";
customObject.field2 = "YYYY";
```



<h6 id="UpdateCustomObjectByToken-put-">Custom Object Update by Access Token (PUT)</h6>

This API is used to update the specified custom object data of the specified account. If the value of updatetype is 'replace' then it will fully replace custom object with the new custom object and if the value of updatetype is 'partialreplace' then it will perform an upsert type operation [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/custom-object-update-by-objectrecordid-and-token)



```c#

var accessToken = "accessToken"; //Required
var objectName = "objectName"; //Required
var objectRecordId = "objectRecordId"; //Required

CustomObjectUpdateOperationType updateType = CustomObjectUpdateOperationType.Default; //Optional
var apiResponse = new CustomObjectApi().UpdateCustomObjectByToken(accessToken, objectName, objectRecordId, customObject, updateType).Result;
```


<h6 id="UpdateCustomObjectByUid-put-">Custom Object Update by UID (PUT)</h6>

This API is used to update the specified custom object data of a specified account. If the value of updatetype is 'replace' then it will fully replace custom object with new custom object and if the value of updatetype is partialreplace then it will perform an upsert type operation. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/custom-object-update-by-objectrecordid-and-uid)



```c#

var objectName = "objectName"; //Required
var objectRecordId = "objectRecordId"; //Required

var uid = "uid"; //Required
CustomObjectUpdateOperationType updateType = CustomObjectUpdateOperationType.Default; //Optional
var apiResponse = new CustomObjectApi().UpdateCustomObjectByUid(objectName, objectRecordId, customObject, uid, updateType).Result;
```


<h6 id="CreateCustomObjectByToken-post-">Create Custom Object by Token (POST)</h6>

This API is used to write information in JSON format to the custom object for the specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/create-custom-object-by-token)



```c#

var accessToken = "accessToken"; //Required
var objectName = "objectName"; //Required

var apiResponse = new CustomObjectApi().CreateCustomObjectByToken(accessToken, objectName, customObject).Result;
```


<h6 id="CreateCustomObjectByUid-post-">Create Custom Object by UID (POST)</h6>

This API is used to write information in JSON format to the custom object for the specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/create-custom-object-by-uid)



```c#

var objectName = "objectName"; //Required

var uid = "uid"; //Required
var apiResponse = new CustomObjectApi().CreateCustomObjectByUid(objectName, customObject, uid).Result;
```


<h6 id="GetCustomObjectByToken-get-">Custom Object by Token (GET)</h6>

This API is used to retrieve the specified Custom Object data for the specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/custom-object-by-token)



```c#

var accessToken = "accessToken"; //Required
var objectName = "objectName"; //Required
var apiResponse = new CustomObjectApi().GetCustomObjectByToken(accessToken, objectName).Result;
```


<h6 id="GetCustomObjectByRecordIDAndToken-get-">Custom Object by ObjectRecordId and Token (GET)</h6>

This API is used to retrieve the Custom Object data for the specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/custom-object-by-objectrecordid-and-token)



```c#

var accessToken = "accessToken"; //Required
var objectName = "objectName"; //Required
var objectRecordId = "objectRecordId"; //Required
var apiResponse = new CustomObjectApi().GetCustomObjectByRecordIDAndToken(accessToken, objectName, objectRecordId).Result;
```


<h6 id="GetCustomObjectByUid-get-">Custom Object By UID (GET)</h6>

This API is used to retrieve all the custom objects by UID from cloud storage. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/custom-object-by-uid)



```c#

var objectName = "objectName"; //Required
var uid = "uid"; //Required
var apiResponse = new CustomObjectApi().GetCustomObjectByUid(objectName, uid).Result;
```


<h6 id="GetCustomObjectByRecordID-get-">Custom Object by ObjectRecordId and UID (GET)</h6>

This API is used to retrieve the Custom Object data for the specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/custom-object-by-objectrecordid-and-uid)



```c#

var objectName = "objectName"; //Required
var objectRecordId = "objectRecordId"; //Required
var uid = "uid"; //Required
var apiResponse = new CustomObjectApi().GetCustomObjectByRecordID(objectName, objectRecordId, uid).Result;
```


<h6 id="DeleteCustomObjectByToken-delete-">Custom Object Delete by Record Id And Token (DELETE)</h6>

This API is used to remove the specified Custom Object data using ObjectRecordId of a specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/custom-object-delete-by-objectrecordid-and-token)



```c#

var accessToken = "accessToken"; //Required
var objectName = "objectName"; //Required
var objectRecordId = "objectRecordId"; //Required
var apiResponse = new CustomObjectApi().DeleteCustomObjectByToken(accessToken, objectName, objectRecordId).Result;
```


<h6 id="DeleteCustomObjectByRecordID-delete-">Account Delete Custom Object by ObjectRecordId (DELETE)</h6>

This API is used to remove the specified Custom Object data using ObjectRecordId of specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/custom-object-delete-by-objectrecordid-and-uid)



```c#

var objectName = "objectName"; //Required
var objectRecordId = "objectRecordId"; //Required
var uid = "uid"; //Required
var apiResponse = new CustomObjectApi().DeleteCustomObjectByRecordID(objectName, objectRecordId, uid).Result;
```







### PhoneAuthentication API


List of APIs in this Section:<br>
[PUT : Phone Reset Password by OTP](#ResetPasswordByPhoneOTP-put-)<br>
[PUT : Phone Verification OTP](#PhoneVerificationByOTP-put-)<br>
[PUT : Phone Verification OTP by Token](#PhoneVerificationOTPByAccessToken-put-)<br>
[PUT : Phone Number Update](#UpdatePhoneNumber-put-)<br>
[POST : Phone Login](#LoginByPhone-post-)<br>
[POST : Phone Forgot Password by OTP](#ForgotPasswordByPhoneOTP-post-)<br>
[POST : Phone Resend Verification OTP](#PhoneResendVerificationOTP-post-)<br>
[POST : Phone Resend Verification OTP By Token](#PhoneResendVerificationOTPByToken-post-)<br>
[POST : Phone User Registration by SMS](#UserRegistrationByPhone-post-)<br>
[GET : Phone Number Availability](#CheckPhoneNumberAvailability-get-)<br>
[DELETE : Remove Phone ID by Access Token](#RemovePhoneIDByAccessToken-delete-)<br>



<h6 id="ResetPasswordByPhoneOTP-put-">Phone Reset Password by OTP (PUT)</h6>

This API is used to reset the password [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-reset-password-by-otp)



```c#

ResetPasswordByOTPModel resetPasswordByOTPModel = new ResetPasswordByOTPModel{
Otp ="<Otp>",
Password ="<Password>",
Phone ="<Phone>"
}; //Required
var apiResponse = new PhoneAuthenticationApi().ResetPasswordByPhoneOTP(resetPasswordByOTPModel).Result;
```


<h6 id="PhoneVerificationByOTP-put-">Phone Verification OTP (PUT)</h6>

This API is used to validate the verification code sent to verify a user's phone number [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-verify-otp)



```c#

var otp = "otp"; //Required
var phone = "phone"; //Required
string fields = null; //Optional
var smsTemplate = "smsTemplate"; //Optional
var isVoiceOtp = false; //Optional
var apiResponse = new PhoneAuthenticationApi().PhoneVerificationByOTP(otp, phone, fields, smsTemplate, isVoiceOtp).Result;
```


<h6 id="PhoneVerificationOTPByAccessToken-put-">Phone Verification OTP by Token (PUT)</h6>

This API is used to consume the verification code sent to verify a user's phone number. Use this call for front-end purposes in cases where the user is already logged in by passing the user's access token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-verify-otp-by-token)



```c#

var accessToken = "accessToken"; //Required
var otp = "otp"; //Required
var smsTemplate = "smsTemplate"; //Optional
var isVoiceOtp = false; //Optional
var apiResponse = new PhoneAuthenticationApi().PhoneVerificationOTPByAccessToken(accessToken, otp, smsTemplate, isVoiceOtp).Result;
```


<h6 id="UpdatePhoneNumber-put-">Phone Number Update (PUT)</h6>

This API is used to update the login Phone Number of users [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-number-update)



```c#

var accessToken = "accessToken"; //Required
var phone = "phone"; //Required
var smsTemplate = "smsTemplate"; //Optional
var isVoiceOtp = false; //Optional
var apiResponse = new PhoneAuthenticationApi().UpdatePhoneNumber(accessToken, phone, smsTemplate, isVoiceOtp).Result;
```


<h6 id="LoginByPhone-post-">Phone Login (POST)</h6>

This API retrieves a copy of the user data based on the Phone [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-login)



```c#

PhoneAuthenticationModel phoneAuthenticationModel = new PhoneAuthenticationModel{
Password ="<Password>",
Phone ="<Phone>"
}; //Required
string fields = null; //Optional
var loginUrl = "loginUrl"; //Optional
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new PhoneAuthenticationApi().LoginByPhone(phoneAuthenticationModel, fields, loginUrl, smsTemplate).Result;
```


<h6 id="ForgotPasswordByPhoneOTP-post-">Phone Forgot Password by OTP (POST)</h6>

This API is used to send the OTP to reset the account password. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-forgot-password-by-otp)



```c#

var phone = "phone"; //Required
var smsTemplate = "smsTemplate"; //Optional
var isVoiceOtp = false; //Optional
var apiResponse = new PhoneAuthenticationApi().ForgotPasswordByPhoneOTP(phone, smsTemplate, isVoiceOtp).Result;
```


<h6 id="PhoneResendVerificationOTP-post-">Phone Resend Verification OTP (POST)</h6>

This API is used to resend a verification OTP to verify a user's Phone Number. The user will receive a verification code that they will need to input [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-resend-otp)



```c#

var phone = "phone"; //Required
var smsTemplate = "smsTemplate"; //Optional
var isVoiceOtp = false; //Optional
var apiResponse = new PhoneAuthenticationApi().PhoneResendVerificationOTP(phone, smsTemplate, isVoiceOtp).Result;
```


<h6 id="PhoneResendVerificationOTPByToken-post-">Phone Resend Verification OTP By Token (POST)</h6>

This API is used to resend a verification OTP to verify a user's Phone Number in cases in which an active token already exists [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-resend-otp-by-token)



```c#

var accessToken = "accessToken"; //Required
var phone = "phone"; //Required
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new PhoneAuthenticationApi().PhoneResendVerificationOTPByToken(accessToken, phone, smsTemplate).Result;
```


<h6 id="UserRegistrationByPhone-post-">Phone User Registration by SMS (POST)</h6>

This API registers the new users into your Cloud Storage and triggers the phone verification process. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-user-registration-by-sms)



```c#

AuthUserRegistrationModel authUserRegistrationModel = new AuthUserRegistrationModel{
Email = new List<EmailModel>{
new EmailModel{
Type ="<Type>",
Value ="<Value>"
}},
FirstName ="<FirstName>",
LastName ="<LastName>",
Password ="<Password>",
PhoneId ="<PhoneId>"
}; //Required
var sott = "sott"; //Required
string fields = null; //Optional
var options = "options"; //Optional
var smsTemplate = "smsTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var emailTemplate = "emailTemplate"; //Optional
var isVoiceOtp = false; //Optional
var apiResponse = new PhoneAuthenticationApi().UserRegistrationByPhone(authUserRegistrationModel, sott, fields, options,smsTemplate, verificationUrl, welcomeEmailTemplate, emailTemplate, isVoiceOtp).Result;
```

<h6 id="CheckPhoneNumberAvailability-get-">Phone Number Availability (GET)</h6>

This API is used to check the Phone Number exists or not on your site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-number-availability)



```c#

var phone = "phone"; //Required
var apiResponse = new PhoneAuthenticationApi().CheckPhoneNumberAvailability(phone).Result;
```


<h6 id="RemovePhoneIDByAccessToken-delete-">Remove Phone ID by Access Token (DELETE)</h6>

This API is used to delete the Phone ID on a user's account via the access_token [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/remove-phone-id-by-access-token)



```c#

var accessToken = "accessToken"; //Required
var apiResponse = new PhoneAuthenticationApi().RemovePhoneIDByAccessToken(accessToken).Result;
```







### MultiFactorAuthentication API


List of APIs in this Section:<br>
[PUT : Update MFA Setting](#MFAUpdateSetting-put-)<br>
[PUT : MFA Update Phone Number by Token](#MFAUpdatePhoneNumberByToken-put-)<br>
[PUT : Verify MFA Email OTP by Access Token](#MFAValidateEmailOtpByAccessToken-put-)<br>
[PUT : Update MFA Security Question by Access Token](#MFASecurityQuestionAnswerByAccessToken-put-)<br>
[PUT : MFA Validate OTP](#MFAValidateOTPByPhone-put-)<br>
[PUT : MFA Validate Backup code](#MFAValidateBackupCode-put-)<br>
[PUT : MFA Update Phone Number](#MFAUpdatePhoneNumber-put-)<br>
[PUT : Verify MFA Email OTP by MFA Token](#MFAValidateEmailOtp-put-)<br>
[PUT : Update MFA Security Question by MFA Token](#MFASecurityQuestionAnswer-put-)<br>
[PUT : MFA Validate Authenticator Code](#MFAValidateAuthenticatorCode-put-)<br>
[PUT : MFA Verify Authenticator Code](#MFAVerifyAuthenticatorCode-put-)<br>
[POST : MFA Email Login](#MFALoginByEmail-post-)<br>
[POST : MFA UserName Login](#MFALoginByUserName-post-)<br>
[POST : MFA Phone Login](#MFALoginByPhone-post-)<br>
[POST : Send MFA Email OTP by MFA Token](#MFAEmailOTP-post-)<br>
[POST : Verify MFA Security Question by MFA Token](#MFASecurityQuestionAnswerVerification-post-)<br>
[GET : MFA Validate Access Token](#MFAConfigureByAccessToken-get-)<br>
[GET : MFA Backup Code by Access Token](#MFABackupCodeByAccessToken-get-)<br>
[GET : Reset Backup Code by Access Token](#MFAResetBackupCodeByAccessToken-get-)<br>
[GET : Send MFA Email OTP by Access Token](#MFAEmailOtpByAccessToken-get-)<br>
[GET : MFA Resend Otp](#MFAResendOTP-get-)<br>
[GET : MFA Backup Code by UID](#MFABackupCodeByUid-get-)<br>
[GET : MFA Reset Backup Code by UID](#MFAResetBackupCodeByUid-get-)<br>
[DELETE : MFA Reset Google Authenticator by Token](#MFAResetGoogleAuthByToken-delete-)<br>
[DELETE : MFA Reset SMS Authenticator by Token](#MFAResetSMSAuthByToken-delete-)<br>
[DELETE : Reset MFA Email OTP Authenticator By Access Token](#MFAResetEmailOtpAuthenticatorByAccessToken-delete-)<br>
[DELETE : MFA Reset Security Question Authenticator By Access Token](#MFAResetSecurityQuestionAuthenticatorByAccessToken-delete-)<br>
[DELETE : MFA Reset SMS Authenticator By UID](#MFAResetSMSAuthenticatorByUid-delete-)<br>
[DELETE : MFA Reset Google Authenticator By UID](#MFAResetGoogleAuthenticatorByUid-delete-)<br>
[DELETE : Reset MFA Email OTP Authenticator Settings by Uid](#MFAResetEmailOtpAuthenticatorByUid-delete-)<br>
[DELETE : Reset MFA Security Question Authenticator Settings by Uid](#MFAResetSecurityQuestionAuthenticatorByUid-delete-)<br>



<h6 id="MFAUpdateSetting-put-">Update MFA Setting (PUT)</h6>

This API is used to trigger the Multi-factor authentication settings after login for secure actions [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/sms-authenticator/update-mfa-setting/)



```c#

var accessToken = "accessToken"; //Required
MultiFactorAuthModelWithLockout multiFactorAuthModelWithLockout = new MultiFactorAuthModelWithLockout{
Otp ="<Otp>"
}; //Required
string fields = null; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAUpdateSetting(accessToken, multiFactorAuthModelWithLockout, fields).Result;
```


<h6 id="MFAUpdatePhoneNumberByToken-put-">MFA Update Phone Number by Token (PUT)</h6>

This API is used to update the Multi-factor authentication phone number by sending the verification OTP to the provided phone number [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/sms-authenticator/mfa-update-phone-number-by-token/)



```c#

var accessToken = "accessToken"; //Required
var phoneNo2FA = "phoneNo2FA"; //Required
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var isVoiceOtp = false; //Optional
var options = "options"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAUpdatePhoneNumberByToken(accessToken, phoneNo2FA, smsTemplate2FA, isVoiceOtp, options).Result;
```


<h6 id="MFAValidateEmailOtpByAccessToken-put-">Verify MFA Email OTP by Access Token (PUT)</h6>

This API is used to set up MFA Email OTP authenticator on profile after login. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/verify-mfa-otp-by-access-token/)



```c#

var accessToken = "accessToken"; //Required
MultiFactorAuthModelByEmailOtpWithLockout multiFactorAuthModelByEmailOtpWithLockout = new MultiFactorAuthModelByEmailOtpWithLockout{
  EmailId="emailid",
  Otp="otp"
}; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAValidateEmailOtpByAccessToken(accessToken, multiFactorAuthModelByEmailOtpWithLockout).Result;
```


<h6 id="MFASecurityQuestionAnswerByAccessToken-put-">Update MFA Security Question by Access Token (PUT)</h6>

This API is used to set up MFA Security Question authenticator on profile after login. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/update-mfa-security-question-by-access-token)



```c#

var accessToken = "accessToken"; //Required
SecurityQuestionAnswerModelByAccessToken securityQuestionAnswerModelByAccessToken = new SecurityQuestionAnswerModelByAccessToken{
ReplaceSecurityQuestionAnswer = false,
SecurityQuestionAnswer = new List<SecurityQuestionOptionalModel> { 
new SecurityQuestionOptionalModel
{
QuestionId="",
Answer=""       
}}
};  //Required
var apiResponse = new MultiFactorAuthenticationApi().MFASecurityQuestionAnswerByAccessToken(accessToken, securityQuestionAnswerModelByAccessToken).Result;
```


<h6 id="MFAValidateOTPByPhone-put-">MFA Validate OTP (PUT)</h6>

This API is used to login via Multi-factor authentication by passing the One Time Password received via SMS [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/sms-authenticator/mfa-validate-otp/)



```c#

MultiFactorAuthModelWithLockout multiFactorAuthModelWithLockout = new MultiFactorAuthModelWithLockout{
Otp ="<Otp>"
}; //Required
var secondFactorAuthenticationToken = "secondFactorAuthenticationToken"; //Required
string fields = null; //Optional
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var rbaBrowserEmailTemplate = "rbaBrowserEmailTemplate"; //Optional
var rbaCityEmailTemplate = "rbaCityEmailTemplate"; //Optional
var rbaCountryEmailTemplate = "rbaCountryEmailTemplate"; //Optional
var rbaIpEmailTemplate = "rbaIpEmailTemplate"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAValidateOTPByPhone(multiFactorAuthModelWithLockout, secondFactorAuthenticationToken, fields, smsTemplate2FA, rbaBrowserEmailTemplate, rbaCityEmailTemplate, rbaCountryEmailTemplate, rbaIpEmailTemplate).Result;
```


<h6 id="MFAValidateBackupCode-put-">MFA Validate Backup code (PUT)</h6>

This API is used to validate the backup code provided by the user and if valid, we return an access token allowing the user to login incases where Multi-factor authentication (MFA) is enabled and the secondary factor is unavailable. When a user initially downloads the Backup codes, We generate 10 codes, each code can only be consumed once. if any user attempts to go over the number of invalid login attempts configured in the Dashboard then the account gets blocked automatically [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/backup-codes/mfa-validate-backup-code/)



```c#

MultiFactorAuthModelByBackupCode multiFactorAuthModelByBackupCode = new MultiFactorAuthModelByBackupCode{
BackupCode ="<BackupCode>"
}; //Required
var secondFactorAuthenticationToken = "secondFactorAuthenticationToken"; //Required
string fields = null; //Optional
var rbaBrowserEmailTemplate = "rbaBrowserEmailTemplate"; //Optional
var rbaCityEmailTemplate = "rbaCityEmailTemplate"; //Optional
var rbaCountryEmailTemplate = "rbaCountryEmailTemplate"; //Optional
var rbaIpEmailTemplate = "rbaIpEmailTemplate"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAValidateBackupCode(multiFactorAuthModelByBackupCode, secondFactorAuthenticationToken, fields, rbaBrowserEmailTemplate, rbaCityEmailTemplate, rbaCountryEmailTemplate, rbaIpEmailTemplate).Result;
```


<h6 id="MFAUpdatePhoneNumber-put-">MFA Update Phone Number (PUT)</h6>

This API is used to update (if configured) the phone number used for Multi-factor authentication by sending the verification OTP to the provided phone number [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/sms-authenticator/mfa-update-phone-number/)



```c#

var phoneNo2FA = "phoneNo2FA"; //Required
var secondFactorAuthenticationToken = "secondFactorAuthenticationToken"; //Required
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var isVoiceOtp = false; //Optional
var options = "options"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAUpdatePhoneNumber(phoneNo2FA, secondFactorAuthenticationToken, smsTemplate2FA, isVoiceOtp,options).Result;
```


<h6 id="MFAValidateEmailOtp-put-">Verify MFA Email OTP by MFA Token (PUT)</h6>

This API is used to Verify MFA Email OTP by MFA Token [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/verify-mfa-email-otp-by-mfa-token/)



```c#

MultiFactorAuthModelByEmailOtp multiFactorAuthModelByEmailOtp = new MultiFactorAuthModelByEmailOtp{
  EmailId="emailId",
  Otp="otp"
}; //Required
var secondFactorAuthenticationToken = "secondFactorAuthenticationToken"; //Required
var rbaBrowserEmailTemplate = "rbaBrowserEmailTemplate"; //Optional
var rbaCityEmailTemplate = "rbaCityEmailTemplate"; //Optional
var rbaCountryEmailTemplate = "rbaCountryEmailTemplate"; //Optional
var rbaIpEmailTemplate = "rbaIpEmailTemplate"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAValidateEmailOtp(multiFactorAuthModelByEmailOtp, secondFactorAuthenticationToken, rbaBrowserEmailTemplate, rbaCityEmailTemplate, rbaCountryEmailTemplate, rbaIpEmailTemplate).Result;
```


<h6 id="MFASecurityQuestionAnswer-put-">Update MFA Security Question by MFA Token (PUT)</h6>

This API is used to set the security questions on the profile with the MFA token when MFA flow is required. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/update-mfa-security-question-by-mfa-token/)



```c#

SecurityQuestionAnswerUpdateModel securityQuestionAnswerUpdateModel = new SecurityQuestionAnswerUpdateModel {
SecurityQuestionAnswer = new List<SecurityQuestionModel> {
new SecurityQuestionModel
{
QuestionId="db7****8a73e4******bd9****8c20",
Answer="<answer"
}
}
}; //Required
var secondFactorAuthenticationToken = "secondFactorAuthenticationToken"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFASecurityQuestionAnswer(securityQuestionAnswerUpdateModel, secondFactorAuthenticationToken).Result;
```

<h6 id="MFAValidateAuthenticatorCode-put-">MFA Validate Authenticator Code (PUT)</h6>

This API is used to login to a user's account during the second MFA step with an Authenticator Code. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/authenticator/mfa-validate-authenticator-code/)



```c#

MultiFactorAuthModelByAuthenticatorCode multiFactorAuthModelByAuthenticatorCode = new MultiFactorAuthModelByAuthenticatorCode{
AuthenticatorCode ="<AuthenticatorCode>"
}; //Required
var secondfactorauthenticationtoken = "secondfactorauthenticationtoken"; //Required
string fields = null; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAValidateAuthenticatorCode(multiFactorAuthModelByAuthenticatorCode, secondfactorauthenticationtoken, fields).Result;
```

<h6 id="MFAVerifyAuthenticatorCode-put-">MFA Verify Authenticator Code (PUT)</h6>

This API is used to validate an Authenticator Code as part of the MFA process. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/authenticator/mfa-verify-authenticator-code/)



```c#

var accessToken = "accessToken"; //Required
MultiFactorAuthModelByAuthenticatorCodeSecurityAnswer multiFactorAuthModelByAuthenticatorCodeSecurityAnswer = new MultiFactorAuthModelByAuthenticatorCodeSecurityAnswer{
AuthenticatorCode ="<AuthenticatorCode>"
}; //Required
string fields = null; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAVerifyAuthenticatorCode(accessToken, multiFactorAuthModelByAuthenticatorCodeSecurityAnswer, fields).Result;
```

<h6 id="MFALoginByEmail-post-">MFA Email Login (POST)</h6>

This API can be used to login by emailid on a Multi-factor authentication enabled LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/mfa-email-login)



```c#

var email = "email"; //Required
var password = "password"; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
var loginUrl = "loginUrl"; //Optional
var smsTemplate = "smsTemplate"; //Optional
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var emailTemplate2FA = "emailTemplate2FA"; //Optional
var isVoiceOtp = false; //Optional
var options = "options"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFALoginByEmail(email, password, emailTemplate, fields, loginUrl, smsTemplate, smsTemplate2FA, verificationUrl, emailTemplate2FA, isVoiceOtp, options).Result;
```


<h6 id="MFALoginByUserName-post-">MFA UserName Login (POST)</h6>

This API can be used to login by username on a Multi-factor authentication enabled LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/mfa-user-name-login)



```c#

var password = "password"; //Required
var username = "username"; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
var loginUrl = "loginUrl"; //Optional
var smsTemplate = "smsTemplate"; //Optional
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var emailTemplate2FA = "emailTemplate2FA"; //Optional
var isVoiceOtp = false; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFALoginByUserName(password, username, emailTemplate, fields, loginUrl, smsTemplate, smsTemplate2FA, verificationUrl, emailTemplate2FA, isVoiceOtp).Result;
```


<h6 id="MFALoginByPhone-post-">MFA Phone Login (POST)</h6>

This API can be used to login by Phone on a Multi-factor authentication enabled LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/mfa-phone-login)



```c#

var password = "password"; //Required
var phone = "phone"; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
var loginUrl = "loginUrl"; //Optional
var smsTemplate = "smsTemplate"; //Optional
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var emailTemplate2FA = "emailTemplate2FA"; //Optional
var isVoiceOtp = false; //Optional
var options = "options"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFALoginByPhone(password, phone, emailTemplate, emailTemplate2FA, fields, loginUrl, smsTemplate, smsTemplate2FA, verificationUrl, isVoiceOtp, options).Result;
```


<h6 id="MFAEmailOTP-post-">Send MFA Email OTP by MFA Token (POST)</h6>

An API designed to send the MFA Email OTP to the email. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/send-mfa-email-otp-by-mfa-token/)



```c#

EmailIdModel emailIdModel = new EmailIdModel{
EmailId= "emailId"
}; //Required
var secondFactorAuthenticationToken = "secondFactorAuthenticationToken"; //Required
var emailTemplate2FA = "emailTemplate2FA"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAEmailOTP(emailIdModel, secondFactorAuthenticationToken, emailTemplate2FA).Result;
```


<h6 id="MFASecurityQuestionAnswerVerification-post-">Verify MFA Security Question by MFA Token (POST)</h6>

This API is used to login to a user's account during the second MFA step via answering the security questions.[More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/verify-mfa-security-question-by-mfa-token/)



```c#

SecurityQuestionAnswerUpdateModel securityQuestionAnswerUpdateModel = new SecurityQuestionAnswerUpdateModel
{
SecurityQuestionAnswer =new List<SecurityQuestionModel>{
new SecurityQuestionModel
{
QuestionId = "db7****8a73e4******bd9****8c20",
Answer = "<answer>"
}
}
}; //Required
var secondFactorAuthenticationToken = "secondFactorAuthenticationToken"; //Required
var rbaBrowserEmailTemplate = "rbaBrowserEmailTemplate"; //Optional
var rbaCityEmailTemplate = "rbaCityEmailTemplate"; //Optional
var rbaCountryEmailTemplate = "rbaCountryEmailTemplate"; //Optional
var rbaIpEmailTemplate = "rbaIpEmailTemplate"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFASecurityQuestionAnswerVerification(securityQuestionAnswerUpdateModel, secondFactorAuthenticationToken, rbaBrowserEmailTemplate, rbaCityEmailTemplate, rbaCountryEmailTemplate, rbaIpEmailTemplate).Result;
```


<h6 id="MFAConfigureByAccessToken-get-">MFA Validate Access Token (GET)</h6>

This API is used to configure the Multi-factor authentication after login by using the access token when MFA is set as optional on the LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/mfa-validate-access-token/)



```c#

var accessToken = "accessToken"; //Required
var isVoiceOtp = false; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAConfigureByAccessToken(accessToken, isVoiceOtp).Result;
```


<h6 id="MFABackupCodeByAccessToken-get-">MFA Backup Code by Access Token (GET)</h6>

This API is used to get a set of backup codes via access token to allow the user login on a site that has Multi-factor Authentication enabled in the event that the user does not have a secondary factor available. We generate 10 codes, each code can only be consumed once. If any user attempts to go over the number of invalid login attempts configured in the Dashboard then the account gets blocked automatically [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/backup-codes/mfa-backup-code-by-access-token/)



```c#

var accessToken = "accessToken"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFABackupCodeByAccessToken(accessToken).Result;
```


<h6 id="MFAResetBackupCodeByAccessToken-get-">Reset Backup Code by Access Token (GET)</h6>

API is used to reset the backup codes on a given account via the access token. This API call will generate 10 new codes, each code can only be consumed once [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/backup-codes/mfa-reset-backup-code-by-access-token/)



```c#

var accessToken = "accessToken"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAResetBackupCodeByAccessToken(accessToken).Result;
```


<h6 id="MFAEmailOtpByAccessToken-get-">Send MFA Email OTP by Access Token (GET)</h6>

This API is created to send the OTP to the email if email OTP authenticator is enabled in app's MFA configuration. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/send-mfa-email-otp-by-access-token/)



```c#

var accessToken = "accessToken"; //Required
var emailId = "emailId"; //Required
var emailTemplate2FA = "emailTemplate2FA"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAEmailOtpByAccessToken(accessToken, emailId, emailTemplate2FA).Result;
```


<h6 id="MFAResendOTP-get-">MFA Resend Otp (GET)</h6>

This API is used to resending the verification OTP to the provided phone number [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/resend-twofactorauthentication-otp/)



```c#

var secondFactorAuthenticationToken = "secondFactorAuthenticationToken"; //Required
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var isVoiceOtp = false; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAResendOTP(secondFactorAuthenticationToken, smsTemplate2FA, isVoiceOtp).Result;
```


<h6 id="MFABackupCodeByUid-get-">MFA Backup Code by UID (GET)</h6>

This API is used to reset the backup codes on a given account via the UID. This API call will generate 10 new codes, each code can only be consumed once. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/backup-codes/mfa-backup-code-by-uid/)



```c#

var uid = "uid"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFABackupCodeByUid(uid).Result;
```


<h6 id="MFAResetBackupCodeByUid-get-">MFA Reset Backup Code by UID (GET)</h6>

This API is used to reset the backup codes on a given account via the UID. This API call will generate 10 new codes, each code can only be consumed once. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/backup-codes/mfa-reset-backup-code-by-uid/)



```c#

var uid = "uid"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAResetBackupCodeByUid(uid).Result;
```


<h6 id="MFAResetAuthenticatorByToken-delete-">MFA Reset Authenticator by Token (DELETE)</h6>

This API Resets the Google Authenticator configurations on a given account via the access token [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/authenticator/mfa-reset-authenticator-by-token/)



```c#

var accessToken = "accessToken"; //Required
var googleAuthenticator = true; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAResetAuthenticatorByToken(accessToken, googleAuthenticator).Result;
```


<h6 id="MFAResetSMSAuthByToken-delete-">MFA Reset SMS Authenticator by Token (DELETE)</h6>

This API resets the SMS Authenticator configurations on a given account via the access token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/sms-authenticator/mfa-reset-sms-authenticator-by-token/)



```c#

var accessToken = "accessToken"; //Required
var otpAuthenticator = true; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAResetSMSAuthByToken(accessToken, otpAuthenticator).Result;
```


<h6 id="MFAResetEmailOtpAuthenticatorByAccessToken-delete-">Reset MFA Email OTP Authenticator By Access Token (DELETE)</h6>

This API is used to reset the Email OTP Authenticator settings for an MFA-enabled user [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/reset-mfa-email-otp-authenticator-access-token/)



```c#

var accessToken = "accessToken"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAResetEmailOtpAuthenticatorByAccessToken(accessToken).Result;
```


<h6 id="MFAResetSecurityQuestionAuthenticatorByAccessToken-delete-">MFA Reset Security Question Authenticator By Access Token (DELETE)</h6>

This API is used to Reset MFA Security Question Authenticator By Access Token [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/reset-mfa-security-question-by-access-token/)



```c#

var accessToken = "accessToken"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAResetSecurityQuestionAuthenticatorByAccessToken(accessToken).Result;
```


<h6 id="MFAResetSMSAuthenticatorByUid-delete-">MFA Reset SMS Authenticator By UID (DELETE)</h6>

This API resets the SMS Authenticator configurations on a given account via the UID. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/sms-authenticator/mfa-reset-sms-authenticator-by-uid/)



```c#

var otpAuthenticator = true; //Required
var uid = "uid"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAResetSMSAuthenticatorByUid(otpAuthenticator, uid).Result;
```


<h6 id="MFAResetAuthenticatorByUid-delete-">MFA Reset Authenticator By UID (DELETE)</h6>

This API resets the Google Authenticator configurations on a given account via the UID. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/authenticator/mfa-reset-authenticator-by-uid/)



```c#

var authenticator = true; //Required
var uid = "uid"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAResetAuthenticatorByUid(authenticator, uid).Result;
```


<h6 id="MFAResetEmailOtpAuthenticatorByUid-delete-">Reset MFA Email OTP Authenticator Settings by Uid (DELETE)</h6>

This API is used to reset the Email OTP Authenticator settings for an MFA-enabled user. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/backup-codes/reset-mfa-email-otp-authenticator-settings-by-uid/)



```c#

var uid = "uid"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAResetEmailOtpAuthenticatorByUid(uid).Result;
```


<h6 id="MFAResetSecurityQuestionAuthenticatorByUid-delete-">Reset MFA Security Question Authenticator Settings by Uid (DELETE)</h6>

This API is used to reset the Security Question Authenticator settings for an MFA-enabled user. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/backup-codes/reset-mfa-security-question-authenticator-settings-by-uid/)



```c#

var uid = "uid"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAResetSecurityQuestionAuthenticatorByUid(uid).Result;
```







### PINAuthentication API


List of APIs in this Section:<br>
[PUT : Reset PIN By ResetToken](#ResetPINByResetToken-put-)<br>
[PUT : Reset PIN By SecurityAnswer And Email](#ResetPINByEmailAndSecurityAnswer-put-)<br>
[PUT : Reset PIN By SecurityAnswer And Username](#ResetPINByUsernameAndSecurityAnswer-put-)<br>
[PUT : Reset PIN By SecurityAnswer And Phone](#ResetPINByPhoneAndSecurityAnswer-put-)<br>
[PUT : Change PIN By Token](#ChangePINByAccessToken-put-)<br>
[PUT : Reset PIN by Phone and OTP](#ResetPINByPhoneAndOtp-put-)<br>
[PUT : Reset PIN by Email and OTP](#ResetPINByEmailAndOtp-put-)<br>
[PUT : Reset PIN by Username and OTP](#ResetPINByUsernameAndOtp-put-)<br>
[POST : PIN Login](#PINLogin-post-)<br>
[POST : Forgot PIN By Email](#SendForgotPINEmailByEmail-post-)<br>
[POST : Forgot PIN By UserName](#SendForgotPINEmailByUsername-post-)<br>
[POST : Forgot PIN By Phone](#SendForgotPINSMSByPhone-post-)<br>
[POST : Set PIN By PinAuthToken](#SetPINByPinAuthToken-post-)<br>
[GET : Invalidate PIN Session Token](#InValidatePinSessionToken-get-)<br>



<h6 id="ResetPINByResetToken-put-">Reset PIN By ResetToken (PUT)</h6>

This API is used to reset pin using reset token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/reset-pin-by-resettoken/)



```c#

ResetPINByResetToken resetPINByResetToken = new ResetPINByResetToken{
PIN ="<PIN>",
ResetToken ="<ResetToken>"
}; //Required
var apiResponse = new PINAuthenticationApi().ResetPINByResetToken(resetPINByResetToken).Result;
```


<h6 id="ResetPINByEmailAndSecurityAnswer-put-">Reset PIN By SecurityAnswer And Email (PUT)</h6>

This API is used to reset pin using security question answer and email. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/reset-pin-by-securityanswer-and-email/)



```c#

ResetPINBySecurityQuestionAnswerAndEmailModel resetPINBySecurityQuestionAnswerAndEmailModel = new ResetPINBySecurityQuestionAnswerAndEmailModel{
Email ="<Email>",
PIN ="<PIN>",
SecurityAnswer = new Dictionary<String,String>{
["QuestionID"] = "Answer"
}
}; //Required
var apiResponse = new PINAuthenticationApi().ResetPINByEmailAndSecurityAnswer(resetPINBySecurityQuestionAnswerAndEmailModel).Result;
```


<h6 id="ResetPINByUsernameAndSecurityAnswer-put-">Reset PIN By SecurityAnswer And Username (PUT)</h6>

This API is used to reset pin using security question answer and username. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/reset-pin-by-securityanswer-and-username/)



```c#

ResetPINBySecurityQuestionAnswerAndUsernameModel resetPINBySecurityQuestionAnswerAndUsernameModel = new ResetPINBySecurityQuestionAnswerAndUsernameModel{
PIN ="<PIN>",
SecurityAnswer = new Dictionary<String,String>{
["QuestionID"] = "Answer"
},
Username ="<Username>"
}; //Required
var apiResponse = new PINAuthenticationApi().ResetPINByUsernameAndSecurityAnswer(resetPINBySecurityQuestionAnswerAndUsernameModel).Result;
```


<h6 id="ResetPINByPhoneAndSecurityAnswer-put-">Reset PIN By SecurityAnswer And Phone (PUT)</h6>

This API is used to reset pin using security question answer and phone. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/reset-pin-by-securityanswer-and-phone/)



```c#

ResetPINBySecurityQuestionAnswerAndPhoneModel resetPINBySecurityQuestionAnswerAndPhoneModel = new ResetPINBySecurityQuestionAnswerAndPhoneModel{
Phone ="<Phone>",
PIN ="<PIN>",
SecurityAnswer = new Dictionary<String,String>{
["QuestionID"] = "Answer"
}
}; //Required
var apiResponse = new PINAuthenticationApi().ResetPINByPhoneAndSecurityAnswer(resetPINBySecurityQuestionAnswerAndPhoneModel).Result;
```


<h6 id="ChangePINByAccessToken-put-">Change PIN By Token (PUT)</h6>

This API is used to change a user's PIN using access token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/change-pin-by-access-token/)



```c#

var accessToken = "accessToken"; //Required
ChangePINModel changePINModel = new ChangePINModel{
NewPIN ="<NewPIN>",
OldPIN ="<OldPIN>"
}; //Required
var apiResponse = new PINAuthenticationApi().ChangePINByAccessToken(accessToken, changePINModel).Result;
```


<h6 id="ResetPINByPhoneAndOtp-put-">Reset PIN by Phone and OTP (PUT)</h6>

This API is used to reset pin using phoneId and OTP. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/reset-pin-by-phone-and-otp/)



```c#

ResetPINByPhoneAndOTPModel resetPINByPhoneAndOTPModel = new ResetPINByPhoneAndOTPModel{
Otp ="<Otp>",
Phone ="<Phone>",
PIN ="<PIN>"
}; //Required
var apiResponse = new PINAuthenticationApi().ResetPINByPhoneAndOtp(resetPINByPhoneAndOTPModel).Result;
```


<h6 id="ResetPINByEmailAndOtp-put-">Reset PIN by Email and OTP (PUT)</h6>

This API is used to reset pin using email and OTP. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/reset-pin-by-email-and-otp/)



```c#

ResetPINByEmailAndOtpModel resetPINByEmailAndOtpModel = new ResetPINByEmailAndOtpModel{
Email ="<Email>",
Otp ="<Otp>",
PIN ="<PIN>"
}; //Required
var apiResponse = new PINAuthenticationApi().ResetPINByEmailAndOtp(resetPINByEmailAndOtpModel).Result;
```


<h6 id="ResetPINByUsernameAndOtp-put-">Reset PIN by Username and OTP (PUT)</h6>

This API is used to reset pin using username and OTP. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/reset-pin-by-username-and-otp/)



```c#

ResetPINByUsernameAndOtpModel resetPINByUsernameAndOtpModel = new ResetPINByUsernameAndOtpModel{
Otp ="<Otp>",
PIN ="<PIN>",
Username ="<Username>"
}; //Required
var apiResponse = new PINAuthenticationApi().ResetPINByUsernameAndOtp(resetPINByUsernameAndOtpModel).Result;
```


<h6 id="PINLogin-post-">PIN Login (POST)</h6>

This API is used to login a user by pin and session_token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/login-by-pin/)



```c#

LoginByPINModel loginByPINModel = new LoginByPINModel{
PIN ="<PIN>"
}; //Required
var sessionToken = "sessionToken"; //Required
var apiResponse = new PINAuthenticationApi().PINLogin(loginByPINModel, sessionToken).Result;
```


<h6 id="SendForgotPINEmailByEmail-post-">Forgot PIN By Email (POST)</h6>

This API sends the reset pin email to specified email address. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/forgot-pin-by-email/)



```c#

ForgotPINLinkByEmailModel forgotPINLinkByEmailModel = new ForgotPINLinkByEmailModel{
Email ="<Email>"
}; //Required
var emailTemplate = "emailTemplate"; //Optional
var resetPINUrl = "resetPINUrl"; //Optional
var apiResponse = new PINAuthenticationApi().SendForgotPINEmailByEmail(forgotPINLinkByEmailModel, emailTemplate, resetPINUrl).Result;
```


<h6 id="SendForgotPINEmailByUsername-post-">Forgot PIN By UserName (POST)</h6>

This API sends the reset pin email using username. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/forgot-pin-by-username/)



```c#

ForgotPINLinkByUserNameModel forgotPINLinkByUserNameModel = new ForgotPINLinkByUserNameModel{
UserName ="<UserName>"
}; //Required
var emailTemplate = "emailTemplate"; //Optional
var resetPINUrl = "resetPINUrl"; //Optional
var apiResponse = new PINAuthenticationApi().SendForgotPINEmailByUsername(forgotPINLinkByUserNameModel, emailTemplate, resetPINUrl).Result;
```


<h6 id="SendForgotPINSMSByPhone-post-">Forgot PIN By Phone (POST)</h6>

This API sends the OTP to specified phone number [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/forgot-pin-by-phone/)



```c#

ForgotPINOtpByPhoneModel forgotPINOtpByPhoneModel = new ForgotPINOtpByPhoneModel{
Phone ="<Phone>"
}; //Required
var smsTemplate = "smsTemplate"; //Optional
var isVoiceOtp = false; //Optional
var apiResponse = new PINAuthenticationApi().SendForgotPINSMSByPhone(forgotPINOtpByPhoneModel, smsTemplate, isVoiceOtp).Result;
```


<h6 id="SetPINByPinAuthToken-post-">Set PIN By PinAuthToken (POST)</h6>

This API is used to change a user's PIN using Pin Auth token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/set-pin-by-pinauthtoken/)



```c#

PINRequiredModel pinRequiredModel = new PINRequiredModel{
PIN ="<PIN>"
}; //Required
var pinAuthToken = "pinAuthToken"; //Required
var apiResponse = new PINAuthenticationApi().SetPINByPinAuthToken(pinRequiredModel, pinAuthToken).Result;
```


<h6 id="InValidatePinSessionToken-get-">Invalidate PIN Session Token (GET)</h6>

This API is used to invalidate pin session token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/invalidate-pin-session-token/)



```c#

var sessionToken = "sessionToken"; //Required
var apiResponse = new PINAuthenticationApi().InValidatePinSessionToken(sessionToken).Result;
```






### ReAuthentication API


List of APIs in this Section:<br>
[PUT : Validate MFA by OTP](#MFAReAuthenticateByOTP-put-)<br>
[PUT : Validate MFA by Backup Code](#MFAReAuthenticateByBackupCode-put-)<br>
[PUT : Validate MFA by Password](#MFAReAuthenticateByPassword-put-)<br>
[PUT : MFA Re-authentication by PIN](#VerifyPINAuthentication-put-)<br>
[PUT : MFA Re-authentication by Email OTP](#ReAuthValidateEmailOtp-put-)<br>
[PUT : MFA Step-Up Authentication by Authenticator Code](#MFAReAuthenticateByAuthenticatorCode-put-)<br>
[POST : Verify Multifactor OTP Authentication](#VerifyMultiFactorOtpReauthentication-post-)<br>
[POST : Verify Multifactor Password Authentication](#VerifyMultiFactorPasswordReauthentication-post-)<br>
[POST : Verify Multifactor PIN Authentication](#VerifyMultiFactorPINReauthentication-post-)<br>
[POST : MFA Re-authentication by Security Question](#ReAuthBySecurityQuestion-post-)<br>
[GET : Multi Factor Re-Authenticate](#MFAReAuthenticate-get-)<br>
[GET : Send MFA Re-auth Email OTP by Access Token](#ReAuthSendEmailOtp-get-)<br>



<h6 id="MFAReAuthenticateByOTP-put-">Validate MFA by OTP (PUT)</h6>

This API is used to re-authenticate via Multi-factor authentication by passing the One Time Password received via SMS [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/re-authentication/mfa/re-auth-by-otp/)



```c#

var accessToken = "accessToken"; //Required
ReauthByOtpModel reauthByOtpModel = new ReauthByOtpModel{
Otp ="<Otp>"
}; //Required
var apiResponse = new ReAuthenticationApi().MFAReAuthenticateByOTP(accessToken, reauthByOtpModel).Result;
```


<h6 id="MFAReAuthenticateByBackupCode-put-">Validate MFA by Backup Code (PUT)</h6>

This API is used to re-authenticate by set of backup codes via access token on the site that has Multi-factor authentication enabled in re-authentication for the user that does not have the device [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/re-authentication/mfa/re-auth-by-backup-code/)



```c#

var accessToken = "accessToken"; //Required
ReauthByBackupCodeModel reauthByBackupCodeModel = new ReauthByBackupCodeModel{
BackupCode ="<BackupCode>"
}; //Required
var apiResponse = new ReAuthenticationApi().MFAReAuthenticateByBackupCode(accessToken, reauthByBackupCodeModel).Result;
```


<h6 id="MFAReAuthenticateByPassword-put-">Validate MFA by Password (PUT)</h6>

This API is used to re-authenticate via Multi-factor-authentication by passing the password [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/re-authentication/re-auth-by-password)



```c#

var accessToken = "accessToken"; //Required
PasswordEventBasedAuthModelWithLockout passwordEventBasedAuthModelWithLockout = new PasswordEventBasedAuthModelWithLockout{
Password ="<Password>"
}; //Required
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var apiResponse = new ReAuthenticationApi().MFAReAuthenticateByPassword(accessToken, passwordEventBasedAuthModelWithLockout, smsTemplate2FA).Result;
```


<h6 id="VerifyPINAuthentication-put-">MFA Re-authentication by PIN (PUT)</h6>

This API is used to validate the triggered MFA authentication flow with a password. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/re-authentication/pin/re-auth-by-pin/)



```c#

var accessToken = "accessToken"; //Required
PINAuthEventBasedAuthModelWithLockout pinAuthEventBasedAuthModelWithLockout = new PINAuthEventBasedAuthModelWithLockout{
PIN ="<PIN>"
}; //Required
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var apiResponse = new ReAuthenticationApi().VerifyPINAuthentication(accessToken, pinAuthEventBasedAuthModelWithLockout, smsTemplate2FA).Result;
```



<h6 id="ReAuthValidateEmailOtp-put-">MFA Re-authentication by Email OTP (PUT)</h6>

This API is used to validate the triggered MFA authentication flow with an Email OTP. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/re-authentication/mfa-re-auth-by-email-otp/)



```c#

var accessToken = "accessToken"; //Required
ReauthByEmailOtpModel reauthByEmailOtpModel = new ReauthByEmailOtpModel{
EmailId="emailId",
Otp="otp"
}; //Required
var apiResponse = new ReAuthenticationApi().ReAuthValidateEmailOtp(accessToken, reauthByEmailOtpModel).Result;
```

<h6 id="MFAReAuthenticateByAuthenticatorCode-put-">MFA Step-Up Authentication by Authenticator Code (PUT)</h6>

This API is used to validate the triggered MFA authentication flow with the Authenticator Code. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/re-authentication/mfa/re-auth-by-otp/)



```c#

var accessToken = "accessToken"; //Required
MultiFactorAuthModelByAuthenticatorCode multiFactorAuthModelByAuthenticatorCode = new MultiFactorAuthModelByAuthenticatorCode{
  AuthenticatorCode ="<AuthenticatorCode>"
}; //Required
var apiResponse = new ReAuthenticationApi().MFAReAuthenticateByAuthenticatorCode(accessToken, multiFactorAuthModelByAuthenticatorCode).Result;
```

<h6 id="VerifyMultiFactorOtpReauthentication-post-">Verify Multifactor OTP Authentication (POST)</h6>

This API is used on the server-side to validate and verify the re-authentication token created by the MFA re-authentication API. This API checks re-authentications created by OTP. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/re-authentication/mfa/re-auth-validate-mfa/)



```c#

EventBasedMultiFactorToken eventBasedMultiFactorToken = new EventBasedMultiFactorToken{
SecondFactorValidationToken ="<SecondFactorValidationToken>"
}; //Required
var uid = "uid"; //Required
var apiResponse = new ReAuthenticationApi().VerifyMultiFactorOtpReauthentication(eventBasedMultiFactorToken, uid).Result;
```


<h6 id="VerifyMultiFactorPasswordReauthentication-post-">Verify Multifactor Password Authentication (POST)</h6>

This API is used on the server-side to validate and verify the re-authentication token created by the MFA re-authentication API. This API checks re-authentications created by password. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/re-authentication/re-auth-validate-password/)



```c#

EventBasedMultiFactorToken eventBasedMultiFactorToken = new EventBasedMultiFactorToken{
SecondFactorValidationToken ="<SecondFactorValidationToken>"
}; //Required
var uid = "uid"; //Required
var apiResponse = new ReAuthenticationApi().VerifyMultiFactorPasswordReauthentication(eventBasedMultiFactorToken, uid).Result;
```


<h6 id="VerifyMultiFactorPINReauthentication-post-">Verify Multifactor PIN Authentication (POST)</h6>

This API is used on the server-side to validate and verify the re-authentication token created by the MFA re-authentication API. This API checks re-authentications created by PIN. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/re-authentication/pin/re-auth-validate-pin/)



```c#

EventBasedMultiFactorToken eventBasedMultiFactorToken = new EventBasedMultiFactorToken{
SecondFactorValidationToken ="<SecondFactorValidationToken>"
}; //Required
var uid = "uid"; //Required
var apiResponse = new ReAuthenticationApi().VerifyMultiFactorPINReauthentication(eventBasedMultiFactorToken, uid).Result;
```


<h6 id="ReAuthBySecurityQuestion-post-">MFA Re-authentication by Security Question (POST)</h6>

This API is used to validate the triggered MFA re-authentication flow with security questions answers. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/re-authentication/mfa-re-authentication-by-security-question/)



```c#

var accessToken = "accessToken"; //Required
SecurityQuestionAnswerUpdateModel securityQuestionAnswerUpdateModel = new SecurityQuestionAnswerUpdateModel
{
SecurityQuestionAnswer = new List<SecurityQuestionModel> {
new SecurityQuestionModel
{
QuestionId = "db7****8a73e4******bd9****8c20",
Answer = "<answer>"
}
}
}; //Required
var apiResponse = new ReAuthenticationApi().ReAuthBySecurityQuestion(accessToken, securityQuestionAnswerUpdateModel).Result;
```


<h6 id="MFAReAuthenticate-get-">Multi Factor Re-Authenticate (GET)</h6>

This API is used to trigger the Multi-Factor Autentication workflow for the provided access token [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/re-authentication/re-auth-trigger/)



```c#

var accessToken = "accessToken"; //Required
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var isVoiceOtp = false; //Optional
var apiResponse = new ReAuthenticationApi().MFAReAuthenticate(accessToken, smsTemplate2FA, isVoiceOtp).Result;
```


<h6 id="ReAuthSendEmailOtp-get-">Send MFA Re-auth Email OTP by Access Token (GET)</h6>

This API is used to send the MFA Email OTP to the email for Re-authentication [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/re-authentication/send-mfa-re-auth-email-otp-by-access-token/)



```c#

var accessToken = "accessToken"; //Required
var emailId = "emailId"; //Required
var emailTemplate2FA = "emailTemplate2FA"; //Optional
var apiResponse = new ReAuthenticationApi().ReAuthSendEmailOtp(accessToken, emailId, emailTemplate2FA).Result;
```







### ConsentManagement API


List of APIs in this Section:<br>
[PUT : Update Consent By Access Token](#UpdateConsentProfileByAccessToken-put-)<br>
[POST : Consent By ConsentToken](#SubmitConsentByConsentToken-post-)<br>
[POST : Post Consent By Access Token](#SubmitConsentByAccessToken-post-)<br>
[GET : Get Consent Logs By Uid](#GetConsentLogsByUid-get-)<br>
[GET : Get Consent Log by Access Token](#GetConsentLogs-get-)<br>
[GET : Get Verify Consent By Access Token](#VerifyConsentByAccessToken-get-)<br>



<h6 id="UpdateConsentProfileByAccessToken-put-">Update Consent By Access Token (PUT)</h6>

This API is to update consents using access token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/consent-management/update-consent-by-access-token/)



```c#

var accessToken = "accessToken"; //Required
ConsentUpdateModel consentUpdateModel = new ConsentUpdateModel{
Consents = new List<ConsentDataModel>{
new ConsentDataModel{
ConsentOptionId ="<ConsentOptionId>",
IsAccepted = true
}}
}; //Required
var apiResponse = new ConsentManagementApi().UpdateConsentProfileByAccessToken(accessToken, consentUpdateModel).Result;
```


<h6 id="SubmitConsentByConsentToken-post-">Consent By ConsentToken (POST)</h6>

This API is to submit consent form using consent token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/consent-management/consent-by-consent-token/)



```c#

var consentToken = "consentToken"; //Required
ConsentSubmitModel consentSubmitModel = new ConsentSubmitModel{
Data = new List<ConsentDataModel>{
new ConsentDataModel{
ConsentOptionId ="<ConsentOptionId>",
IsAccepted = true
}},
Events = new List<ConsentEventModel>{
new ConsentEventModel{
Event ="<Event>",
IsCustom = true
}}
}; //Required
var apiResponse = new ConsentManagementApi().SubmitConsentByConsentToken(consentToken, consentSubmitModel).Result;
```


<h6 id="SubmitConsentByAccessToken-post-">Post Consent By Access Token (POST)</h6>

API to provide a way to end user to submit a consent form for particular event type. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/consent-management/consent-by-access-token/)



```c#

var accessToken = "accessToken"; //Required
ConsentSubmitModel consentSubmitModel = new ConsentSubmitModel{
Data = new List<ConsentDataModel>{
new ConsentDataModel{
ConsentOptionId ="<ConsentOptionId>",
IsAccepted = true
}},
Events = new List<ConsentEventModel>{
new ConsentEventModel{
Event ="<Event>",
IsCustom = true
}}
}; //Required
var apiResponse = new ConsentManagementApi().SubmitConsentByAccessToken(accessToken, consentSubmitModel).Result;
```


<h6 id="GetConsentLogsByUid-get-">Get Consent Logs By Uid (GET)</h6>

This API is used to get the Consent logs of the user. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/consent-management/consent-log-by-uid/)



```c#

var uid = "uid"; //Required
var apiResponse = new ConsentManagementApi().GetConsentLogsByUid(uid).Result;
```


<h6 id="GetConsentLogs-get-">Get Consent Log by Access Token (GET)</h6>

This API is used to fetch consent logs. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/consent-management/consent-log-by-access-token/)



```c#

var accessToken = "accessToken"; //Required
var apiResponse = new ConsentManagementApi().GetConsentLogs(accessToken).Result;
```


<h6 id="VerifyConsentByAccessToken-get-">Get Verify Consent By Access Token (GET)</h6>

This API is used to check if consent is submitted for a particular event or not. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/consent-management/verify-consent-by-access-token/)



```c#

var accessToken = "accessToken"; //Required
var @event = "@event"; //Required
var isCustom = true; //Required
var apiResponse = new ConsentManagementApi().VerifyConsentByAccessToken(accessToken, @event, isCustom).Result;
```







### SmartLogin API


List of APIs in this Section:<br>
[GET : Smart Login Verify Token](#SmartLoginTokenVerification-get-)<br>
[GET : Smart Login By Email](#SmartLoginByEmail-get-)<br>
[GET : Smart Login By Username](#SmartLoginByUserName-get-)<br>
[GET : Smart Login Ping](#SmartLoginPing-get-)<br>



<h6 id="SmartLoginTokenVerification-get-">Smart Login Verify Token (GET)</h6>

This API verifies the provided token for Smart Login [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/smart-login/smart-login-verify-token/)



```c#

var verificationToken = "verificationToken"; //Required
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new SmartLoginApi().SmartLoginTokenVerification(verificationToken, welcomeEmailTemplate).Result;
```


<h6 id="SmartLoginByEmail-get-">Smart Login By Email (GET)</h6>

This API sends a Smart Login link to the user's Email Id. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/smart-login/smart-login-by-email)



```c#

var clientGuid = "clientGuid"; //Required
var email = "email"; //Required
var redirectUrl = "redirectUrl"; //Optional
var smartLoginEmailTemplate = "smartLoginEmailTemplate"; //Optional
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new SmartLoginApi().SmartLoginByEmail(clientGuid, email, redirectUrl, smartLoginEmailTemplate, welcomeEmailTemplate).Result;
```


<h6 id="SmartLoginByUserName-get-">Smart Login By Username (GET)</h6>

This API sends a Smart Login link to the user's Email Id. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/smart-login/smart-login-by-username)



```c#

var clientGuid = "clientGuid"; //Required
var username = "username"; //Required
var redirectUrl = "redirectUrl"; //Optional
var smartLoginEmailTemplate = "smartLoginEmailTemplate"; //Optional
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new SmartLoginApi().SmartLoginByUserName(clientGuid, username, redirectUrl, smartLoginEmailTemplate, welcomeEmailTemplate).Result;
```


<h6 id="SmartLoginPing-get-">Smart Login Ping (GET)</h6>

This API is used to check if the Smart Login link has been clicked or not [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/smart-login/smart-login-ping)



```c#

var clientGuid = "clientGuid"; //Required
string fields = null; //Optional
var apiResponse = new SmartLoginApi().SmartLoginPing(clientGuid, fields).Result;
```







### OneTouchLogin API


List of APIs in this Section:<br>
[PUT : One Touch OTP Verification](#OneTouchLoginOTPVerification-put-)<br>
[POST : One Touch Login by Email](#OneTouchLoginByEmail-post-)<br>
[POST : One Touch Login by Phone](#OneTouchLoginByPhone-post-)<br>
[GET : One Touch Email Verification](#OneTouchEmailVerification-get-)<br>
[GET : One Touch Login Ping](#OneTouchLoginPing-get-)<br>



<h6 id="OneTouchLoginOTPVerification-put-">One Touch OTP Verification (PUT)</h6>

This API is used to verify the otp for One Touch Login. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/one-touch-login/one-touch-otp-verification/)



```c#

var otp = "otp"; //Required
var phone = "phone"; //Required
string fields = null; //Optional
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new OneTouchLoginApi().OneTouchLoginOTPVerification(otp, phone, fields, smsTemplate).Result;
```


<h6 id="OneTouchLoginByEmail-post-">One Touch Login by Email (POST)</h6>

This API is used to send a link to a specified email for a frictionless login/registration [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/one-touch-login/one-touch-login-by-email-captcha/)



```c#

OneTouchLoginByEmailModel oneTouchLoginByEmailModel = new OneTouchLoginByEmailModel{
Clientguid ="<Clientguid>",
Email ="<Email>",
G_recaptcha_response ="<G-recaptcha-response>"
}; //Required
var oneTouchLoginEmailTemplate = "oneTouchLoginEmailTemplate"; //Optional
var redirecturl = "redirecturl"; //Optional
var welcomeemailtemplate = "welcomeemailtemplate"; //Optional
var apiResponse = new OneTouchLoginApi().OneTouchLoginByEmail(oneTouchLoginByEmailModel, oneTouchLoginEmailTemplate, redirecturl, welcomeemailtemplate).Result;
```


<h6 id="OneTouchLoginByPhone-post-">One Touch Login by Phone (POST)</h6>

This API is used to send one time password to a given phone number for a frictionless login/registration. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/one-touch-login/one-touch-login-by-phone-captcha/)



```c#

OneTouchLoginByPhoneModel oneTouchLoginByPhoneModel = new OneTouchLoginByPhoneModel{
G_recaptcha_response ="<G-recaptcha-response>",
Phone ="<Phone>"
}; //Required
var smsTemplate = "smsTemplate"; //Optional
var isVoiceOtp = false; //Optional
var apiResponse = new OneTouchLoginApi().OneTouchLoginByPhone(oneTouchLoginByPhoneModel, smsTemplate, isVoiceOtp).Result;
```


<h6 id="OneTouchEmailVerification-get-">One Touch Email Verification (GET)</h6>

This API verifies the provided token for One Touch Login [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/one-touch-login/one-touch-email-verification)



```c#

var verificationToken = "verificationToken"; //Required
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new OneTouchLoginApi().OneTouchEmailVerification(verificationToken, welcomeEmailTemplate).Result;
```


<h6 id="OneTouchLoginPing-get-">One Touch Login Ping (GET)</h6>

This API is used to check if the One Touch Login link has been clicked or not. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/one-touch-login/one-touch-login-ping/)



```c#

var clientGuid = "clientGuid"; //Required
string fields = null; //Optional
var apiResponse = new OneTouchLoginApi().OneTouchLoginPing(clientGuid, fields).Result;
```







### PasswordLessLogin API


List of APIs in this Section:<br>
[PUT : Passwordless Login Phone Verification](#PasswordlessLoginPhoneVerification-put-)<br>
[POST : Passwordless Login Verification By Email And OTP ](#PasswordlessLoginVerificationByEmailAndOTP-post-)<br>
[POST : Passwordless Login Verification By User Name And OTP](#PasswordlessLoginVerificationByUserNameAndOTP-post-)<br>
[GET : Passwordless Login by Phone](#PasswordlessLoginByPhone-get-)<br>
[GET : Passwordless Login By Email](#PasswordlessLoginByEmail-get-)<br>
[GET : Passwordless Login By UserName](#PasswordlessLoginByUserName-get-)<br>
[GET : Passwordless Login Verification](#PasswordlessLoginVerification-get-)<br>



<h6 id="PasswordlessLoginPhoneVerification-put-">Passwordless Login Phone Verification (PUT)</h6>

This API verifies an account by OTP and allows the customer to login. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/passwordless-login/passwordless-login-phone-verification)



```c#

PasswordLessLoginOtpModel passwordLessLoginOtpModel = new PasswordLessLoginOtpModel{
Otp ="<Otp>",
Phone ="<Phone>"
}; //Required
string fields = null; //Optional
var smsTemplate = "smsTemplate"; //Optional
var isVoiceOtp = false; //Optional
var apiResponse = new PasswordLessLoginApi().PasswordlessLoginPhoneVerification(passwordLessLoginOtpModel, fields, smsTemplate, isVoiceOtp).Result;
```


<h6 id="PasswordlessLoginVerificationByEmailAndOTP-post-">Passwordless Login Verification By Email And OTP  (POST)</h6>

This API is used to verify the otp sent to the email when doing a passwordless login.  [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/passwordless-login/passwordless-login-verification-by-email-and-otp)



```c#

PasswordLessLoginByEmailAndOtpModel passwordLessLoginByEmailAndOtpModel = new PasswordLessLoginByEmailAndOtpModel{
  Otp ="<Otp>",
  Email ="<Email>"
}; //Required
string fields = null; //Optional
var apiResponse = new PasswordLessLoginApi().PasswordlessLoginVerificationByEmailAndOTP(passwordLessLoginByEmailAndOtpModel, fields).Result;
```


<h6 id="PasswordlessLoginVerificationByUserNameAndOTP-post-">Passwordless Login Verification By User Name And OTP (POST)</h6>

This API is used to verify the otp sent to the email when doing a passwordless login. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/passwordless-login/passwordless-login-verification-by-username-and-otp)



```c#

PasswordLessLoginByUserNameAndOtpModel passwordLessLoginByUserNameAndOtpModel = new PasswordLessLoginByUserNameAndOtpModel{
  Otp ="<Otp>",
  UserName ="<UserName>"
}; //Required
string fields = null; //Optional
var apiResponse = new PasswordLessLoginApi().PasswordlessLoginVerificationByUserNameAndOTP(passwordLessLoginByUserNameAndOtpModel, fields).Result;
```


<h6 id="PasswordlessLoginByPhone-get-">Passwordless Login by Phone (GET)</h6>

API can be used to send a One-time Passcode (OTP) provided that the account has a verified PhoneID [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/passwordless-login/passwordless-login-by-phone)



```c#

var phone = "phone"; //Required
var smsTemplate = "smsTemplate"; //Optional
var isVoiceOtp = false; //Optional
var apiResponse = new PasswordLessLoginApi().PasswordlessLoginByPhone(phone, smsTemplate, isVoiceOtp).Result;
```


<h6 id="PasswordlessLoginByEmail-get-">Passwordless Login By Email (GET)</h6>

This API is used to send a Passwordless Login verification link to the provided Email ID [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/passwordless-login/passwordless-login-by-email)



```c#

var email = "email"; //Required
var passwordLessLoginTemplate = "passwordLessLoginTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new PasswordLessLoginApi().PasswordlessLoginByEmail(email, passwordLessLoginTemplate, verificationUrl).Result;
```


<h6 id="PasswordlessLoginByUserName-get-">Passwordless Login By UserName (GET)</h6>

This API is used to send a Passwordless Login Verification Link to a customer by providing their UserName [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/passwordless-login/passwordless-login-by-username)



```c#

var username = "username"; //Required
var passwordLessLoginTemplate = "passwordLessLoginTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new PasswordLessLoginApi().PasswordlessLoginByUserName(username, passwordLessLoginTemplate, verificationUrl).Result;
```


<h6 id="PasswordlessLoginVerification-get-">Passwordless Login Verification (GET)</h6>

This API is used to verify the Passwordless Login verification link. Note: If you are using Passwordless Login by Phone you will need to use the Passwordless Login Phone Verification API [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/passwordless-login/passwordless-login-verification)



```c#

var verificationToken = "verificationToken"; //Required
string fields = null; //Optional
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new PasswordLessLoginApi().PasswordlessLoginVerification(verificationToken, fields, welcomeEmailTemplate).Result;
```







### Configuration API


List of APIs in this Section:<br>[GET : Get Configurations](#getConfigurations-get-)<br>
[GET : Get Server Time](#GetServerInfo-get-)<br>

<h6 id="getConfigurations-get-">Get Configurations (GET)</h6>

This API is used to get the configurations which are set in the LoginRadius Dashboard for a particular LoginRadius site/environment [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/configuration/get-configurations/)



```c#
var apiResponse = new ConfigurationApi().GetConfigurations().Result;
```

<h6 id="GetServerInfo-get-">Get Server Time (GET)</h6>

This API allows you to query your LoginRadius account for basic server information and server time information which is useful when generating an SOTT token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/configuration/get-server-time/)



```c#

var timeDifference = 0; //Optional
var apiResponse = new ConfigurationApi().GetServerInfo(timeDifference).Result;
```







### Role API


List of APIs in this Section:<br>
[PUT : Assign Roles by UID](#AssignRolesByUid-put-)<br>
[PUT : Upsert Context](#UpdateRoleContextByUid-put-)<br>
[PUT : Add Permissions to Role](#AddRolePermissions-put-)<br>
[POST : Roles Create](#CreateRoles-post-)<br>
[GET : Roles by UID](#GetRolesByUid-get-)<br>
[GET : Get Context with Roles and Permissions](#GetRoleContextByUid-get-)<br>
[GET : Role Context profile](#GetRoleContextByContextName-get-)<br>
[GET : Roles List](#GetRolesList-get-)<br>
[DELETE : Unassign Roles by UID](#UnassignRolesByUid-delete-)<br>
[DELETE : Delete Role Context](#DeleteRoleContextByUid-delete-)<br>
[DELETE : Delete Role from Context](#DeleteRolesFromRoleContextByUid-delete-)<br>
[DELETE : Delete Additional Permission from Context](#DeleteAdditionalPermissionFromRoleContextByUid-delete-)<br>
[DELETE : Account Delete Role](#DeleteRole-delete-)<br>
[DELETE : Remove Permissions](#RemoveRolePermissions-delete-)<br>



<h6 id="AssignRolesByUid-put-">Assign Roles by UID (PUT)</h6>

This API is used to assign your desired roles to a given user. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/assign-roles-by-uid/)



```c#

AccountRolesModel accountRolesModel = new AccountRolesModel{
Roles = new List<String>{"Roles"}
}; //Required
var uid = "uid"; //Required
var apiResponse = new RoleApi().AssignRolesByUid(accountRolesModel, uid).Result;
```


<h6 id="UpdateRoleContextByUid-put-">Upsert Context (PUT)</h6>

This API creates a Context with a set of Roles [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/upsert-context)



```c#

AccountRoleContextModel accountRoleContextModel = new AccountRoleContextModel{
RoleContext = new List<RoleContextRoleModel>{
new RoleContextRoleModel{
AdditionalPermissions = new List<String>{"AdditionalPermissions"},
Context ="<Context>",
Expiration ="<Expiration>",
Roles = new List<String>{"Roles"}
}}
}; //Required
var uid = "uid"; //Required
var apiResponse = new RoleApi().UpdateRoleContextByUid(accountRoleContextModel, uid).Result;
```


<h6 id="AddRolePermissions-put-">Add Permissions to Role (PUT)</h6>

This API is used to add permissions to a given role. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/add-permissions-to-role)



```c#

PermissionsModel permissionsModel = new PermissionsModel{
Permissions = new List<String>{"Permissions"}
}; //Required
var role = "role"; //Required
var apiResponse = new RoleApi().AddRolePermissions(permissionsModel, role).Result;
```


<h6 id="CreateRoles-post-">Roles Create (POST)</h6>

This API creates a role with permissions. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/roles-create)



```c#

RolesModel rolesModel = new RolesModel{
Roles = new List<RoleModel>{
new RoleModel{
Name ="<Name>",
Permissions = new Dictionary<String,Boolean>{
["Permission_name"] = true
}
}}
}; //Required
var apiResponse = new RoleApi().CreateRoles(rolesModel).Result;
```


<h6 id="GetRolesByUid-get-">Roles by UID (GET)</h6>

API is used to retrieve all the assigned roles of a particular User. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/get-roles-by-uid)



```c#

var uid = "uid"; //Required
var apiResponse = new RoleApi().GetRolesByUid(uid).Result;
```


<h6 id="GetRoleContextByUid-get-">Get Context with Roles and Permissions (GET)</h6>

This API Gets the contexts that have been configured and the associated roles and permissions. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/get-context)



```c#

var uid = "uid"; //Required
var apiResponse = new RoleApi().GetRoleContextByUid(uid).Result;
```


<h6 id="GetRoleContextByContextName-get-">Role Context profile (GET)</h6>

The API is used to retrieve role context by the context name. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/role-context-profile/)



```c#

var contextName = "contextName"; //Required
var apiResponse = new RoleApi().GetRoleContextByContextName(contextName).Result;
```


<h6 id="GetRolesList-get-">Roles List (GET)</h6>

This API retrieves the complete list of created roles with permissions of your app. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/roles-list)



```c#

var apiResponse = new RoleApi().GetRolesList().Result;
```


<h6 id="UnassignRolesByUid-delete-">Unassign Roles by UID (DELETE)</h6>

This API is used to unassign roles from a user. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/unassign-roles-by-uid)



```c#

AccountRolesModel accountRolesModel = new AccountRolesModel{
Roles = new List<String>{"Roles"}
}; //Required
var uid = "uid"; //Required
var apiResponse = new RoleApi().UnassignRolesByUid(accountRolesModel, uid).Result;
```


<h6 id="DeleteRoleContextByUid-delete-">Delete Role Context (DELETE)</h6>

This API Deletes the specified Role Context [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/delete-context)



```c#

var contextName = "contextName"; //Required
var uid = "uid"; //Required
var apiResponse = new RoleApi().DeleteRoleContextByUid(contextName, uid).Result;
```


<h6 id="DeleteRolesFromRoleContextByUid-delete-">Delete Role from Context (DELETE)</h6>

This API Deletes the specified Role from a Context. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/delete-role-from-context/)



```c#

var contextName = "contextName"; //Required
RoleContextRemoveRoleModel roleContextRemoveRoleModel = new RoleContextRemoveRoleModel{
Roles = new List<String>{"Roles"}
}; //Required
var uid = "uid"; //Required
var apiResponse = new RoleApi().DeleteRolesFromRoleContextByUid(contextName, roleContextRemoveRoleModel, uid).Result;
```


<h6 id="DeleteAdditionalPermissionFromRoleContextByUid-delete-">Delete Additional Permission from Context (DELETE)</h6>

This API Deletes Additional Permissions from Context. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/delete-permissions-from-context)



```c#

var contextName = "contextName"; //Required
RoleContextAdditionalPermissionRemoveRoleModel roleContextAdditionalPermissionRemoveRoleModel = new RoleContextAdditionalPermissionRemoveRoleModel{
AdditionalPermissions = new List<String>{"AdditionalPermissions"}
}; //Required
var uid = "uid"; //Required
var apiResponse = new RoleApi().DeleteAdditionalPermissionFromRoleContextByUid(contextName, roleContextAdditionalPermissionRemoveRoleModel, uid).Result;
```


<h6 id="DeleteRole-delete-">Account Delete Role (DELETE)</h6>

This API is used to delete the role. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/delete-role)



```c#

var role = "role"; //Required
var apiResponse = new RoleApi().DeleteRole(role).Result;
```


<h6 id="RemoveRolePermissions-delete-">Remove Permissions (DELETE)</h6>

API is used to remove permissions from a role. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/remove-permissions)



```c#

PermissionsModel permissionsModel = new PermissionsModel{
Permissions = new List<String>{"Permissions"}
}; //Required
var role = "role"; //Required
var apiResponse = new RoleApi().RemoveRolePermissions(permissionsModel, role).Result;
```






### RiskBasedAuthentication API


List of APIs in this Section:<br>
[POST : Risk Based Authentication Login by Email](#RBALoginByEmail-post-)<br>
[POST : Risk Based Authentication Login by Username](#RBALoginByUserName-post-)<br>
[POST : Risk Based Authentication Phone Login](#RBALoginByPhone-post-)<br>



<h6 id="RBALoginByEmail-post-">Risk Based Authentication Login by Email (POST)</h6>

This API retrieves a copy of the user data based on the Email [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-login-by-email)



```c#

EmailAuthenticationModel emailAuthenticationModel = new EmailAuthenticationModel{
Email ="<Email>",
Password ="<Password>"
}; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
var loginUrl = "loginUrl"; //Optional
var passwordDelegation = true; //Optional
var passwordDelegationApp = "passwordDelegationApp"; //Optional
var rbaBrowserEmailTemplate = "rbaBrowserEmailTemplate"; //Optional
var rbaBrowserSmsTemplate = "rbaBrowserSmsTemplate"; //Optional
var rbaCityEmailTemplate = "rbaCityEmailTemplate"; //Optional
var rbaCitySmsTemplate = "rbaCitySmsTemplate"; //Optional
var rbaCountryEmailTemplate = "rbaCountryEmailTemplate"; //Optional
var rbaCountrySmsTemplate = "rbaCountrySmsTemplate"; //Optional
var rbaIpEmailTemplate = "rbaIpEmailTemplate"; //Optional
var rbaIpSmsTemplate = "rbaIpSmsTemplate"; //Optional
var rbaOneclickEmailTemplate = "rbaOneclickEmailTemplate"; //Optional
var rbaOTPSmsTemplate = "rbaOTPSmsTemplate"; //Optional
var smsTemplate = "smsTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new RiskBasedAuthenticationApi().RBALoginByEmail(emailAuthenticationModel, emailTemplate, fields, loginUrl, passwordDelegation, passwordDelegationApp, rbaBrowserEmailTemplate, rbaBrowserSmsTemplate, rbaCityEmailTemplate, rbaCitySmsTemplate, rbaCountryEmailTemplate, rbaCountrySmsTemplate, rbaIpEmailTemplate, rbaIpSmsTemplate, rbaOneclickEmailTemplate, rbaOTPSmsTemplate, smsTemplate, verificationUrl).Result;
```


<h6 id="RBALoginByUserName-post-">Risk Based Authentication Login by Username (POST)</h6>

This API retrieves a copy of the user data based on the Username [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-login-by-username)



```c#

UserNameAuthenticationModel userNameAuthenticationModel = new UserNameAuthenticationModel{
Password ="<Password>",
Username ="<Username>"
}; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
var loginUrl = "loginUrl"; //Optional
var passwordDelegation = true; //Optional
var passwordDelegationApp = "passwordDelegationApp"; //Optional
var rbaBrowserEmailTemplate = "rbaBrowserEmailTemplate"; //Optional
var rbaBrowserSmsTemplate = "rbaBrowserSmsTemplate"; //Optional
var rbaCityEmailTemplate = "rbaCityEmailTemplate"; //Optional
var rbaCitySmsTemplate = "rbaCitySmsTemplate"; //Optional
var rbaCountryEmailTemplate = "rbaCountryEmailTemplate"; //Optional
var rbaCountrySmsTemplate = "rbaCountrySmsTemplate"; //Optional
var rbaIpEmailTemplate = "rbaIpEmailTemplate"; //Optional
var rbaIpSmsTemplate = "rbaIpSmsTemplate"; //Optional
var rbaOneclickEmailTemplate = "rbaOneclickEmailTemplate"; //Optional
var rbaOTPSmsTemplate = "rbaOTPSmsTemplate"; //Optional
var smsTemplate = "smsTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new RiskBasedAuthenticationApi().RBALoginByUserName(userNameAuthenticationModel, emailTemplate, fields, loginUrl, passwordDelegation, passwordDelegationApp, rbaBrowserEmailTemplate, rbaBrowserSmsTemplate, rbaCityEmailTemplate, rbaCitySmsTemplate, rbaCountryEmailTemplate, rbaCountrySmsTemplate, rbaIpEmailTemplate, rbaIpSmsTemplate, rbaOneclickEmailTemplate, rbaOTPSmsTemplate, smsTemplate, verificationUrl).Result;
```


<h6 id="RBALoginByPhone-post-">Risk Based Authentication Phone Login (POST)</h6>

This API retrieves a copy of the user data based on the Phone [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-login)



```c#

PhoneAuthenticationModel phoneAuthenticationModel = new PhoneAuthenticationModel{
Password ="<Password>",
Phone ="<Phone>"
}; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
var loginUrl = "loginUrl"; //Optional
var passwordDelegation = true; //Optional
var passwordDelegationApp = "passwordDelegationApp"; //Optional
var rbaBrowserEmailTemplate = "rbaBrowserEmailTemplate"; //Optional
var rbaBrowserSmsTemplate = "rbaBrowserSmsTemplate"; //Optional
var rbaCityEmailTemplate = "rbaCityEmailTemplate"; //Optional
var rbaCitySmsTemplate = "rbaCitySmsTemplate"; //Optional
var rbaCountryEmailTemplate = "rbaCountryEmailTemplate"; //Optional
var rbaCountrySmsTemplate = "rbaCountrySmsTemplate"; //Optional
var rbaIpEmailTemplate = "rbaIpEmailTemplate"; //Optional
var rbaIpSmsTemplate = "rbaIpSmsTemplate"; //Optional
var rbaOneclickEmailTemplate = "rbaOneclickEmailTemplate"; //Optional
var rbaOTPSmsTemplate = "rbaOTPSmsTemplate"; //Optional
var smsTemplate = "smsTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new RiskBasedAuthenticationApi().RBALoginByPhone(phoneAuthenticationModel, emailTemplate, fields, loginUrl, passwordDelegation, passwordDelegationApp, rbaBrowserEmailTemplate, rbaBrowserSmsTemplate, rbaCityEmailTemplate, rbaCitySmsTemplate, rbaCountryEmailTemplate, rbaCountrySmsTemplate, rbaIpEmailTemplate, rbaIpSmsTemplate, rbaOneclickEmailTemplate, rbaOTPSmsTemplate, smsTemplate, verificationUrl).Result;
```







### Sott API


List of APIs in this Section:<br>
[GET : Generate SOTT](#GenerateSott-get-)<br>



<h6 id="GenerateSott-get-">Generate SOTT (GET)</h6>

This API allows you to generate SOTT with a given expiration time. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/session/generate-sott-token)



```c#

var timeDifference = 0; //Optional
var apiResponse = new SottApi().GenerateSott(timeDifference).Result;
```







### NativeSocial API


List of APIs in this Section:<br>
[GET : Access Token via Facebook Token](#GetAccessTokenByFacebookAccessToken-get-)<br>
[GET : Access Token via Twitter Token](#GetAccessTokenByTwitterAccessToken-get-)<br>
[GET : Access Token via Google Token](#GetAccessTokenByGoogleAccessToken-get-)<br>
[GET : Access Token using google JWT token for Native Mobile Login](#GetAccessTokenByGoogleJWTAccessToken-get-)<br>
[GET : Access Token via Linkedin Token](#GetAccessTokenByLinkedinAccessToken-get-)<br>
[GET : Get Access Token By Foursquare Access Token](#GetAccessTokenByFoursquareAccessToken-get-)<br>
[GET : Access Token via Apple Id Code](#GetAccessTokenByAppleIdCode-get-)<br>
[GET : Access Token via WeChat Code](#GetAccessTokenByWeChatCode-get-)<br>
[GET : Access Token via Google AuthCode](#GetAccessTokenByGoogleAuthCode-get-)<br>
[GET : Get Access Token via Custom JWT Token](#AccessTokenViaCustomJWTToken-get-)<br>




<h6 id="GetAccessTokenByFacebookAccessToken-get-">Access Token via Facebook Token (GET)</h6>

The API is used to get LoginRadius access token by sending Facebook's access token. It will be valid for the specific duration of time specified in the response. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-facebook-token/)



```c#

var fbAccessToken = "fbAccessToken"; //Required
var socialAppName = "socialAppName"; //Optional
var apiResponse = new NativeSocialApi().GetAccessTokenByFacebookAccessToken(fbAccessToken, socialAppName).Result;
```


<h6 id="GetAccessTokenByTwitterAccessToken-get-">Access Token via Twitter Token (GET)</h6>

The API is used to get LoginRadius access token by sending Twitter's access token. It will be valid for the specific duration of time specified in the response. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-twitter-token)



```c#

var twAccessToken = "twAccessToken"; //Required
var twTokenSecret = "twTokenSecret"; //Required
var socialAppName = "socialAppName"; //Optional
var apiResponse = new NativeSocialApi().GetAccessTokenByTwitterAccessToken(twAccessToken, twTokenSecret, socialAppName).Result;
```


<h6 id="GetAccessTokenByGoogleAccessToken-get-">Access Token via Google Token (GET)</h6>

The API is used to get LoginRadius access token by sending Google's access token. It will be valid for the specific duration of time specified in the response. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-google-token)



```c#

var googleAccessToken = "googleAccessToken"; //Required
var clientId = "clientId"; //Optional
var refreshToken = "refreshToken"; //Optional
var socialAppName = "socialAppName"; //Optional
var apiResponse = new NativeSocialApi().GetAccessTokenByGoogleAccessToken(googleAccessToken, clientId, refreshToken, socialAppName).Result;
```


<h6 id="GetAccessTokenByGoogleJWTAccessToken-get-">Access Token using google JWT token for Native Mobile Login (GET)</h6>

This API is used to Get LoginRadius Access Token using google jwt id token for google native mobile login/registration. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-googlejwt)



```c#

var idToken = "idToken"; //Required
var apiResponse = new NativeSocialApi().GetAccessTokenByGoogleJWTAccessToken(idToken).Result;
```


<h6 id="GetAccessTokenByLinkedinAccessToken-get-">Access Token via Linkedin Token (GET)</h6>

The API is used to get LoginRadius access token by sending Linkedin's access token. It will be valid for the specific duration of time specified in the response. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-linkedin-token/)



```c#

var lnAccessToken = "lnAccessToken"; //Required
var socialAppName = "socialAppName"; //Optional
var apiResponse = new NativeSocialApi().GetAccessTokenByLinkedinAccessToken(lnAccessToken, socialAppName).Result;
```


<h6 id="GetAccessTokenByFoursquareAccessToken-get-">Get Access Token By Foursquare Access Token (GET)</h6>

The API is used to get LoginRadius access token by sending Foursquare's access token. It will be valid for the specific duration of time specified in the response. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-foursquare-token/)



```c#

var fsAccessToken = "fsAccessToken"; //Required
var apiResponse = new NativeSocialApi().GetAccessTokenByFoursquareAccessToken(fsAccessToken).Result;
```

<h6 id="GetAccessTokenByAppleIdCode-get-">Access Token via Apple Id Code (GET)</h6>

The API is used to get LoginRadius access token by sending a valid Apple ID OAuth Code. It will be valid for the specific duration of time specified in the response. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-apple-id-code)



```c#

var code = "code"; //Required
var socialAppName = "socialAppName"; //Optional
var apiResponse = new NativeSocialApi().GetAccessTokenByAppleIdCode(code, socialAppName).Result;
```


<h6 id="GetAccessTokenByWeChatCode-get-">Access Token via WeChat Code (GET)</h6>

This API is used to retrieve a LoginRadius access token by passing in a valid WeChat OAuth Code. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-wechat-code)



```c#

var code = "code"; //Required
var apiResponse = new NativeSocialApi().GetAccessTokenByWeChatCode(code).Result;
```



<h6 id="GetAccessTokenByGoogleAuthCode-get-">Access Token via Google AuthCode (GET)</h6>

The API is used to get LoginRadius access token by sending Google's AuthCode. It will be valid for the specific duration of time specified in the response. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-google-auth-code)



```c#

var googleAuthcode = "googleAuthcode"; //Required
var socialAppName = "socialAppName"; //Optional
var apiResponse = new NativeSocialApi().GetAccessTokenByGoogleAuthCode(googleAuthcode,socialAppName).Result;
```

<h6 id="AccessTokenViaCustomJWTToken-get-">Get Access Token via Custom JWT Token (GET)</h6>

This API is used to retrieve a LoginRadius access token by passing in a valid custom JWT token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-by-custom-jwt-token/)



```c#

var idToken = "idToken"; //Required
var providername = "providername"; //Required
var apiResponse = new NativeSocialApi().AccessTokenViaCustomJWTToken(idToken, providername).Result;
```






### WebHook API


List of APIs in this Section:<br>
[PUT : Update Webhook Subscription](#UpdateWebhookSubscription-put-)<br>
[POST : Create Webhook Subscription](#CreateWebhookSubscription-post-)<br>
[GET : Get Webhook Subscription Detail](#GetWebhookSubscriptionDetail-get-)<br>
[GET : List All Webhooks](#ListAllWebhooks-get-)<br>
[GET : Get Webhook Events](#GetWebhookEvents-get-)<br>
[DELETE : Delete Webhook Subscription](#DeleteWebhookSubscription-delete-)<br>



<h6 id="UpdateWebhookSubscription-put-">Update Webhook Subscription (PUT)</h6>

This API is used to update a webhook subscription [More Info](https://www.loginradius.com/docs/api/v2/integrations/webhooks/webhook-update)



```c#

var hookId = "hookId"; //Required
WebHookSubscriptionUpdateModel webHookSubscriptionUpdateModel = new WebHookSubscriptionUpdateModel
{
    
        Headers = new Dictionary<string, string>
        {
            { "header1", "value1" },
            { "header2", "value2" }
        },
        QueryParams = new Dictionary<string, string>
        {
            { "param1", "value1" },
            { "param2", "value2" }
        },
        Authentication = new WebhookAuthenticationModel
        {
            AuthType = "Bearer", // Ensure the AuthType is set correctly
            BearerToken = new WebhookBearerToken
            {
                Token = "ssss"
            }
        }
}; //Required
var apiResponse = new WebHookApi().UpdateWebhookSubscription(hookId, webHookSubscriptionUpdateModel);
```


<h6 id="CreateWebhookSubscription-post-">Create Webhook Subscription (POST)</h6>

This API is used to create a new webhook subscription on your LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/integrations/webhooks/webhook-subscribe)



```c#

WebHookSubscribeModel webHookSubscribeModel = new WebHookSubscribeModel
{
    Event = "<Event>",
    Name = "<Name>",
    TargetUrl = "<TargetUrl>",
    Headers = new Dictionary<string, string>
    {
        { "header1", "value1" },
        { "header2", "value2" }
    },
    QueryParams = new Dictionary<string, string>
    {
        { "param1", "value1" },
        { "param2", "value2" }
    },
    Authentication = new WebhookAuthenticationModel
    {
        AuthType = "Basic", // Ensure the AuthType is set correctly
        BasicAuth = new WebhookAuthCredentials
        {
            Username = "",
            Password = ""
        }
    },
}; //Required
var apiResponse = new WebHookApi().CreateWebhookSubscription(webHookSubscribeModel);
```


<h6 id="GetWebhookSubscriptionDetail-get-">Get Webhook Subscription Detail (GET)</h6>

This API is used to get details of a webhook subscription by Id [More Info](https://www.loginradius.com/docs/api/v2/integrations/webhooks/webhook-subscribed-urls)



```c#

var hookId = "hookId"; //Required
var apiResponse = new WebHookApi().GetWebhookSubscriptionDetail(hookId);
```


<h6 id="ListAllWebhooks-get-">List All Webhooks (GET)</h6>

This API is used to get the list of all the webhooks [More Info](https://www.loginradius.com/docs/api/v2/integrations/webhooks/webhook-list)



```c#

var apiResponse = new WebHookApi().ListAllWebhooks();
```


<h6 id="GetWebhookEvents-get-">Get Webhook Events (GET)</h6>

This API is used to retrieve all the webhook events. [More Info](https://www.loginradius.com/docs/api/v2/integrations/webhooks/webhook-events)



```c#

var apiResponse = new WebHookApi().GetWebhookEvents();
```


<h6 id="DeleteWebhookSubscription-delete-">Delete Webhook Subscription (DELETE)</h6>

This API is used to delete webhook subscription [More Info](https://www.loginradius.com/docs/api/v2/integrations/webhooks/webhook-unsubscribe)



```c#

var hookId = "hookId"; //Required
var apiResponse = new WebHookApi().DeleteWebhookSubscription(hookId);
```


### SlidingToken API


List of APIs in this Section:<br>
[GET : Get Sliding Access Token](#SlidingAccessToken-get-)<br>



<h6 id="SlidingAccessToken-get-"> (GET)</h6>

 This API is used to get access token and refresh token with the expired/nonexpired access token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/refresh-token/sliding-access-token)



```c#

var accessToken = "accessToken"; //Required
var apiResponse = new SlidingTokenApi().SlidingAccessToken(accessToken).Result;
```


### JWT Token Validate

This is the inbuilt SDK JWT Token Validate method and we are using the JwtSecurityTokenHandler for this.The JwtSecurityTokenHandler class in the System.IdentityModel.Tokens.Jwt (opens new window)package will handle the low-level details of validating a JWT.

This method will return an instance of JwtSecurityToken if the token is valid. But in the case of any type error the method return System.Exception in the same class.

Note:- This method is supported only .NET 45 or later / .NetStandard 2.0 or later

```c#
JwtValidationParameters jwtParameters = new JwtValidationParameters
{
  JwtToken = "",
  Secret = ""
};

var jwt = new JwtTokenValidation().validateJwtToken(jwtParameters);
  if(jwt.Error != null) {

    // write your code here
  }

```
### Generate SOTT Manually

SOTT is a secure one-time token that can be created using the API key, API secret, and a timestamp ( start time and end time ). You can manually create a SOTT using the following util function. 

```c#
LoginRadiusSecureOneTimeToken _sott = new LoginRadiusSecureOneTimeToken();

// You can pass the start and end time interval and the SOTT will be valid for this time duration, StartTime and EndTime are optional but if passing the value then both value need to be passed.

var sott = new SottRequest
{

StartTime = "2017-05-15 07:10:42", // Valid Start Date with Date and time

EndTime="2017-05-15 07:20:42", // Valid End Date with Date and time

//do not pass the time difference if you are passing startTime & endTime.

TimeDifference="10" // (Optional) The time difference will be used to set the expiration time of SOTT, If you do not pass time difference then the default expiration time of SOTT is 10 minutes.
};

var apiKey = ""; //(Optional) LoginRadius Api Key.

var apiSecret = ""; //(Optional) LoginRadius Api Secret (Only Primary Api Secret is used to generate the SOTT manually).

var getLrServerTime=false; //(Optional) If true it will call LoginRadius Get Server Time Api and fetch basic server information and server time information which is useful when generating an SOTT token.

//The LoginRadius API key and primary API secret can be passed additionally, If the credentials will not be passed then this SOTT function will pick the API credentials from the SDK configuration.  


var generatedSott=_sott.GetSott(sott,apiKey,apiSecret,getLrServerTime);

```

## Demo
We have configured a sample ASP.net project with extended social profile data, webhook Apis, Account APis. You can get a copy of our demo project at [GitHub](https://github.com/LoginRadius/dot-net-sdk/tree/master/Samples/dot-net-demo).
