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
This documentation presumes you have worked through the client-side implementation to setup your LoginRadius User Registration interfaces that will serve the initial registration and login process. Details on this can be found in the [getting started guide](/api/v2/getting-started/introduction).

**Note: **LoginRadius uses the industry standard TLS 1.2 protocol, designed to help protect the privacy of information communicated over the Internet. In order to use the LoginRadius .Net SDK, add the following code before instantiating your web service in your project's `Global.asax` file.

```
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


```
using LoginRadiusSDK.V2.Api;
using LoginRadiusSDK.V2.Models;
```
##Quickstart Guide

Set your [app credentials](/api/v2/getting-started/get-api-key-and-secret):

```
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
```
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
```
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

```
"domainName" : "https://api.loginradius.com/"
```



### API Request Signing
When initializing the SDK, you can optionally specify enabling this feature. Enabling this feature means the customer does not need to pass an API secret in an API request. Instead, they can pass a dynamically generated hash value. This feature will also make sure that the message is not tampered during transit when someone calls our APIs.
Example : In appsettings.json, add following statement -

```
"ApiRequestSigning" : "false"
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
[PUT : Auth Link Social Identities](#LinkSocialIdentities-put-)<br>
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
[GET : Auth Check Email Availability](#CheckEmailAvailability-get-)<br>
[GET : Auth Verify Email](#VerifyEmail-get-)<br>
[GET : Auth Social Identity](#GetSocialIdentity-get-)<br>
[GET : Auth Check UserName Availability](#CheckUserNameAvailability-get-)<br>
[GET : Auth Privacy Policy Accept](#AcceptPrivacyPolicy-get-)<br>
[GET : Auth Privacy Policy History By Access Token](#GetPrivacyPolicyHistoryByAccessToken-get-)<br>
[DELETE : Auth Delete Account with Email Confirmation](#DeleteAccountWithEmailConfirmation-delete-)<br>
[DELETE : Auth Remove Email](#RemoveEmail-delete-)<br>
[DELETE : Auth Unlink Social Identities](#UnlinkSocialIdentities-delete-)<br>



<h6 id="UpdateProfileByAccessToken-put-">Auth Update Profile by Token (PUT)</h6>
This API is used to update the user's profile by passing the access_token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-update-profile-by-token/)



```

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
var apiResponse = new AuthenticationApi().UpdateProfileByAccessToken(accessToken, userProfileUpdateModel, emailTemplate, fields, smsTemplate, verificationUrl);
```


<h6 id="UnlockAccountByToken-put-">Auth Unlock Account by Access Token (PUT)</h6>
This API is used to allow a customer with a valid access_token to unlock their account provided that they successfully pass the prompted Bot Protection challenges. The Block or Suspend block types are not applicable for this API. For additional details see our Auth Security Configuration documentation.You are only required to pass the Post Parameters that correspond to the prompted challenges. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-unlock-account-by-access-token/)



```

var accessToken = "accessToken"; //Required
UnlockProfileModel unlockProfileModel = new UnlockProfileModel{
G_recaptcha_response ="<G-recaptcha-response>"
}; //Required
var apiResponse = new AuthenticationApi().UnlockAccountByToken(accessToken, unlockProfileModel);
```


<h6 id="VerifyEmailByOTP-put-">Auth Verify Email By OTP (PUT)</h6>
This API is used to verify the email of user when the OTP Email verification flow is enabled, please note that you must contact LoginRadius to have this feature enabled. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-verify-email-by-otp/)



```

EmailVerificationByOtpModel emailVerificationByOtpModel = new EmailVerificationByOtpModel{
Email ="<Email>",
Otp ="<Otp>"
}; //Required
string fields = null; //Optional
var url = "url"; //Optional
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new AuthenticationApi().VerifyEmailByOTP(emailVerificationByOtpModel, fields, url, welcomeEmailTemplate);
```


<h6 id="ResetPasswordBySecurityAnswerAndEmail-put-">Auth Reset Password by Security Answer and Email (PUT)</h6>
This API is used to reset password for the specified account by security question [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-reset-password-by-email)



```

ResetPasswordBySecurityAnswerAndEmailModel resetPasswordBySecurityAnswerAndEmailModel = new ResetPasswordBySecurityAnswerAndEmailModel{
Email ="<Email>",
Password ="<Password>",
SecurityAnswer = new Dictionary<String,String>{
["QuestionID"] = "Answer"
}
}; //Required
var apiResponse = new AuthenticationApi().ResetPasswordBySecurityAnswerAndEmail(resetPasswordBySecurityAnswerAndEmailModel);
```


<h6 id="ResetPasswordBySecurityAnswerAndPhone-put-">Auth Reset Password by Security Answer and Phone (PUT)</h6>
This API is used to reset password for the specified account by security question [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-reset-password-by-phone)



```

ResetPasswordBySecurityAnswerAndPhoneModel resetPasswordBySecurityAnswerAndPhoneModel = new ResetPasswordBySecurityAnswerAndPhoneModel{
Password ="<Password>",
Phone ="<Phone>",
SecurityAnswer = new Dictionary<String,String>{
["QuestionID"] = "Answer"
}
}; //Required
var apiResponse = new AuthenticationApi().ResetPasswordBySecurityAnswerAndPhone(resetPasswordBySecurityAnswerAndPhoneModel);
```


<h6 id="ResetPasswordBySecurityAnswerAndUserName-put-">Auth Reset Password by Security Answer and UserName (PUT)</h6>
This API is used to reset password for the specified account by security question [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-reset-password-by-username)



```

ResetPasswordBySecurityAnswerAndUserNameModel resetPasswordBySecurityAnswerAndUserNameModel = new ResetPasswordBySecurityAnswerAndUserNameModel{
Password ="<Password>",
SecurityAnswer = new Dictionary<String,String>{
["QuestionID"] = "Answer"
},
UserName ="<UserName>"
}; //Required
var apiResponse = new AuthenticationApi().ResetPasswordBySecurityAnswerAndUserName(resetPasswordBySecurityAnswerAndUserNameModel);
```


<h6 id="ResetPasswordByResetToken-put-">Auth Reset Password by Reset Token (PUT)</h6>
This API is used to set a new password for the specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-reset-password-by-reset-token)



```

ResetPasswordByResetTokenModel resetPasswordByResetTokenModel = new ResetPasswordByResetTokenModel{
Password ="<Password>",
ResetToken ="<ResetToken>"
}; //Required
var apiResponse = new AuthenticationApi().ResetPasswordByResetToken(resetPasswordByResetTokenModel);
```


<h6 id="ResetPasswordByEmailOTP-put-">Auth Reset Password by OTP (PUT)</h6>
This API is used to set a new password for the specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-reset-password-by-otp)



```

ResetPasswordByEmailAndOtpModel resetPasswordByEmailAndOtpModel = new ResetPasswordByEmailAndOtpModel{
Email ="<Email>",
Otp ="<Otp>",
Password ="<Password>"
}; //Required
var apiResponse = new AuthenticationApi().ResetPasswordByEmailOTP(resetPasswordByEmailAndOtpModel);
```


<h6 id="ResetPasswordByOTPAndUserName-put-">Auth Reset Password by OTP and UserName (PUT)</h6>
This API is used to set a new password for the specified account if you are using the username as the unique identifier in your workflow [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-reset-password-by-otp-and-username/)



```

ResetPasswordByUserNameModel resetPasswordByUserNameModel = new ResetPasswordByUserNameModel{
Otp ="<Otp>",
Password ="<Password>",
UserName ="<UserName>"
}; //Required
var apiResponse = new AuthenticationApi().ResetPasswordByOTPAndUserName(resetPasswordByUserNameModel);
```


<h6 id="ChangePassword-put-">Auth Change Password (PUT)</h6>
This API is used to change the accounts password based on the previous password [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-change-password)



```

var accessToken = "accessToken"; //Required
var newPassword = "newPassword"; //Required
var oldPassword = "oldPassword"; //Required
var apiResponse = new AuthenticationApi().ChangePassword(accessToken, newPassword, oldPassword);
```


<h6 id="LinkSocialIdentities-put-">Auth Link Social Identities (PUT)</h6>
This API is used to link up a social provider account with the specified account based on the access token and the social providers user access token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-link-social-identities)



```

var accessToken = "accessToken"; //Required
var candidateToken = "candidateToken"; //Required
var apiResponse = new AuthenticationApi().LinkSocialIdentities(accessToken, candidateToken);
```


<h6 id="SetOrChangeUserName-put-">Auth Set or Change UserName (PUT)</h6>
This API is used to set or change UserName by access token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-set-or-change-user-name/)



```

var accessToken = "accessToken"; //Required
var username = "username"; //Required
var apiResponse = new AuthenticationApi().SetOrChangeUserName(accessToken, username);
```


<h6 id="AuthResendEmailVerification-put-">Auth Resend Email Verification (PUT)</h6>
This API resends the verification email to the user. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-resend-email-verification/)



```

var email = "email"; //Required
var emailTemplate = "emailTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new AuthenticationApi().AuthResendEmailVerification(email, emailTemplate, verificationUrl);
```


<h6 id="AddEmail-post-">Auth Add Email (POST)</h6>
This API is used to add additional emails to a user's account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-add-email)



```

var accessToken = "accessToken"; //Required
var email = "email"; //Required
var type = "type"; //Required
var emailTemplate = "emailTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new AuthenticationApi().AddEmail(accessToken, email, type, emailTemplate, verificationUrl);
```


<h6 id="LoginByEmail-post-">Auth Login by Email (POST)</h6>
This API retrieves a copy of the user data based on the Email [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-login-by-email)



```

EmailAuthenticationModel emailAuthenticationModel = new EmailAuthenticationModel{
Email ="<Email>",
Password ="<Password>"
}; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
var loginUrl = "loginUrl"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new AuthenticationApi().LoginByEmail(emailAuthenticationModel, emailTemplate, fields, loginUrl, verificationUrl);
```


<h6 id="LoginByUserName-post-">Auth Login by Username (POST)</h6>
This API retrieves a copy of the user data based on the Username [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-login-by-username)



```

UserNameAuthenticationModel userNameAuthenticationModel = new UserNameAuthenticationModel{
Password ="<Password>",
Username ="<Username>"
}; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
var loginUrl = "loginUrl"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new AuthenticationApi().LoginByUserName(userNameAuthenticationModel, emailTemplate, fields, loginUrl, verificationUrl);
```


<h6 id="ForgotPassword-post-">Auth Forgot Password (POST)</h6>
This API is used to send the reset password url to a specified account. Note: If you have the UserName workflow enabled, you may replace the 'email' parameter with 'username' [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-forgot-password)



```

var email = "email"; //Required
var resetPasswordUrl = "resetPasswordUrl"; //Required
var emailTemplate = "emailTemplate"; //Optional
var apiResponse = new AuthenticationApi().ForgotPassword(email, resetPasswordUrl, emailTemplate);
```


<h6 id="UserRegistrationByEmail-post-">Auth User Registration by Email (POST)</h6>
This API creates a user in the database as well as sends a verification email to the user. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-user-registration-by-email)



```

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
var apiResponse = new AuthenticationApi().UserRegistrationByEmail(authUserRegistrationModel, sott, emailTemplate, fields, options, verificationUrl, welcomeEmailTemplate);
```


<h6 id="UserRegistrationByCaptcha-post-">Auth User Registration By Captcha (POST)</h6>
This API creates a user in the database as well as sends a verification email to the user. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-user-registration-by-recaptcha)



```

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
var apiResponse = new AuthenticationApi().UserRegistrationByCaptcha(authUserRegistrationModelWithCaptcha, emailTemplate, fields, options, smsTemplate, verificationUrl, welcomeEmailTemplate);
```


<h6 id="GetSecurityQuestionsByEmail-get-">Get Security Questions By Email (GET)</h6>
This API is used to retrieve the list of questions that are configured on the respective LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/security-questions-by-email/)



```

var email = "email"; //Required
var apiResponse = new AuthenticationApi().GetSecurityQuestionsByEmail(email);
```


<h6 id="GetSecurityQuestionsByUserName-get-">Get Security Questions By UserName (GET)</h6>
This API is used to retrieve the list of questions that are configured on the respective LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/security-questions-by-user-name/)



```

var userName = "userName"; //Required
var apiResponse = new AuthenticationApi().GetSecurityQuestionsByUserName(userName);
```


<h6 id="GetSecurityQuestionsByPhone-get-">Get Security Questions By Phone (GET)</h6>
This API is used to retrieve the list of questions that are configured on the respective LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/security-questions-by-phone/)



```

var phone = "phone"; //Required
var apiResponse = new AuthenticationApi().GetSecurityQuestionsByPhone(phone);
```


<h6 id="GetSecurityQuestionsByAccessToken-get-">Get Security Questions By Access Token (GET)</h6>
This API is used to retrieve the list of questions that are configured on the respective LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/security-questions-by-access-token/)



```

var accessToken = "accessToken"; //Required
var apiResponse = new AuthenticationApi().GetSecurityQuestionsByAccessToken(accessToken);
```


<h6 id="AuthValidateAccessToken-get-">Auth Validate Access token (GET)</h6>
This api validates access token, if valid then returns a response with its expiry otherwise error. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-validate-access-token/)



```

var accessToken = "accessToken"; //Required
var apiResponse = new AuthenticationApi().AuthValidateAccessToken(accessToken);
```


<h6 id="AuthInValidateAccessToken-get-">Access Token Invalidate (GET)</h6>
This api call invalidates the active access token or expires an access token's validity. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-invalidate-access-token/)



```

var accessToken = "accessToken"; //Required
var preventRefresh = true; //Optional
var apiResponse = new AuthenticationApi().AuthInValidateAccessToken(accessToken, preventRefresh);
```


<h6 id="GetAccessTokenInfo-get-">Access Token Info (GET)</h6>
This api call provide the active access token Information [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-access-token-info/)



```

var accessToken = "accessToken"; //Required
var apiResponse = new AuthenticationApi().GetAccessTokenInfo(accessToken);
```


<h6 id="GetProfileByAccessToken-get-">Auth Read all Profiles by Token (GET)</h6>
This API retrieves a copy of the user data based on the access_token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-read-profiles-by-token/)



```

var accessToken = "accessToken"; //Required
string fields = null; //Optional
var apiResponse = new AuthenticationApi().GetProfileByAccessToken(accessToken, fields);
```


<h6 id="SendWelcomeEmail-get-">Auth Send Welcome Email (GET)</h6>
This API sends a welcome email [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-send-welcome-email/)



```

var accessToken = "accessToken"; //Required
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new AuthenticationApi().SendWelcomeEmail(accessToken, welcomeEmailTemplate);
```


<h6 id="DeleteAccountByDeleteToken-get-">Auth Delete Account (GET)</h6>
This API is used to delete an account by passing it a delete token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-delete-account/)



```

var deleteToken = "deleteToken"; //Required
var apiResponse = new AuthenticationApi().DeleteAccountByDeleteToken(deleteToken);
```


<h6 id="CheckEmailAvailability-get-">Auth Check Email Availability (GET)</h6>
This API is used to check the email exists or not on your site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-email-availability/)



```

var email = "email"; //Required
var apiResponse = new AuthenticationApi().CheckEmailAvailability(email);
```


<h6 id="VerifyEmail-get-">Auth Verify Email (GET)</h6>
This API is used to verify the email of user. Note: This API will only return the full profile if you have 'Enable auto login after email verification' set in your LoginRadius Admin Console's Email Workflow settings under 'Verification Email'. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-verify-email/)



```

var verificationToken = "verificationToken"; //Required
string fields = null; //Optional
var url = "url"; //Optional
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new AuthenticationApi().VerifyEmail(verificationToken, fields, url, welcomeEmailTemplate);
```


<h6 id="GetSocialIdentity-get-">Auth Social Identity (GET)</h6>
This API is called just after account linking API and it prevents the raas profile of the second account from getting created. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-social-identity)



```

var accessToken = "accessToken"; //Required
string fields = null; //Optional
var apiResponse = new AuthenticationApi().GetSocialIdentity(accessToken, fields);
```


<h6 id="CheckUserNameAvailability-get-">Auth Check UserName Availability (GET)</h6>
This API is used to check the UserName exists or not on your site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-username-availability/)



```

var username = "username"; //Required
var apiResponse = new AuthenticationApi().CheckUserNameAvailability(username);
```


<h6 id="AcceptPrivacyPolicy-get-">Auth Privacy Policy Accept (GET)</h6>
This API is used to update the privacy policy stored in the user's profile by providing the access_token of the user accepting the privacy policy [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-privacy-policy-accept)



```

var accessToken = "accessToken"; //Required
string fields = null; //Optional
var apiResponse = new AuthenticationApi().AcceptPrivacyPolicy(accessToken, fields);
```


<h6 id="GetPrivacyPolicyHistoryByAccessToken-get-">Auth Privacy Policy History By Access Token (GET)</h6>
This API will return all the accepted privacy policies for the user by providing the access_token of that user. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/privacy-policy-history-by-access-token/)



```

var accessToken = "accessToken"; //Required
var apiResponse = new AuthenticationApi().GetPrivacyPolicyHistoryByAccessToken(accessToken);
```


<h6 id="DeleteAccountWithEmailConfirmation-delete-">Auth Delete Account with Email Confirmation (DELETE)</h6>
This API will send a confirmation email for account deletion to the customer's email when passed the customer's access token [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-delete-account-with-email-confirmation/)



```

var accessToken = "accessToken"; //Required
var deleteUrl = "deleteUrl"; //Optional
var emailTemplate = "emailTemplate"; //Optional
var apiResponse = new AuthenticationApi().DeleteAccountWithEmailConfirmation(accessToken, deleteUrl, emailTemplate);
```


<h6 id="RemoveEmail-delete-">Auth Remove Email (DELETE)</h6>
This API is used to remove additional emails from a user's account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-remove-email)



```

var accessToken = "accessToken"; //Required
var email = "email"; //Required
var apiResponse = new AuthenticationApi().RemoveEmail(accessToken, email);
```


<h6 id="UnlinkSocialIdentities-delete-">Auth Unlink Social Identities (DELETE)</h6>
This API is used to unlink up a social provider account with the specified account based on the access token and the social providers user access token. The unlinked account will automatically get removed from your database. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-unlink-social-identities)



```

var accessToken = "accessToken"; //Required
var provider = "provider"; //Required
var providerId = "providerId"; //Required
var apiResponse = new AuthenticationApi().UnlinkSocialIdentities(accessToken, provider, providerId);
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
[DELETE : Delete User Profiles By Email](#AccountDeleteByEmail-delete-)<br>



<h6 id="UpdateAccountByUid-put-">Account Update (PUT)</h6>
This API is used to update the information of existing accounts in your Cloud Storage. See our Advanced API Usage section <a href='https://www.loginradius.com/docs/api/v2/customer-identity-api/advanced-api-usage/'>Here</a> for more capabilities. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-update)



```

AccountUserProfileUpdateModel accountUserProfileUpdateModel = new AccountUserProfileUpdateModel{
FirstName ="<FirstName>",
LastName ="<LastName>"
}; //Required
var uid = "uid"; //Required
string fields = null; //Optional
; //Optional
var apiResponse = new AccountApi().UpdateAccountByUid(accountUserProfileUpdateModel, uid, fields);
```


<h6 id="UpdatePhoneIDByUid-put-">Update Phone ID by UID (PUT)</h6>
This API is used to update the PhoneId by using the Uid's. Admin can update the PhoneId's for both the verified and unverified profiles. It will directly replace the PhoneId and bypass the OTP verification process. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/update-phoneid-by-uid)



```

var phone = "phone"; //Required
var uid = "uid"; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().UpdatePhoneIDByUid(phone, uid, fields);
```


<h6 id="SetAccountPasswordByUid-put-">Account Set Password (PUT)</h6>
This API is used to set the password of an account in Cloud Storage. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-set-password)



```

var password = "password"; //Required
var uid = "uid"; //Required
var apiResponse = new AccountApi().SetAccountPasswordByUid(password, uid);
```


<h6 id="InvalidateAccountEmailVerification-put-">Account Invalidate Verification Email (PUT)</h6>
This API is used to invalidate the Email Verification status on an account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-invalidate-verification-email)



```

var uid = "uid"; //Required
var emailTemplate = "emailTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new AccountApi().InvalidateAccountEmailVerification(uid, emailTemplate, verificationUrl);
```


<h6 id="ResetPhoneIDVerificationByUid-put-">Reset phone ID verification (PUT)</h6>
This API Allows you to reset the phone no verification of an end user’s account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/reset-phone-id-verification)



```

var uid = "uid"; //Required
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new AccountApi().ResetPhoneIDVerificationByUid(uid, smsTemplate);
```


<h6 id="UpsertEmail-put-">Upsert Email (PUT)</h6>
This API is used to add/upsert another emails in account profile by different-different email types. If the email type is same then it will simply update the existing email, otherwise it will add a new email in Email array. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/upsert-email)



```

UpsertEmailModel upsertEmailModel = new UpsertEmailModel{
Email = new List<EmailModel>{
new EmailModel{
Type ="<Type>",
Value ="<Value>"
}}
}; //Required
var uid = "uid"; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().UpsertEmail(upsertEmailModel, uid, fields);
```


<h6 id="AccountUpdateUid-put-">Update UID (PUT)</h6>
This API is used to update a user's Uid. It will update all profiles, custom objects and consent management logs associated with the Uid. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-update/)



```

UpdateUidModel updateUidModel = new UpdateUidModel{
NewUid ="<NewUid>"
}; //Required
var uid = "uid"; //Required
var apiResponse = new AccountApi().AccountUpdateUid(updateUidModel, uid);
```


<h6 id="CreateAccount-post-">Account Create (POST)</h6>
This API is used to create an account in Cloud Storage. This API bypass the normal email verification process and manually creates the user. <br><br>In order to use this API, you need to format a JSON request body with all of the mandatory fields [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-create)



```

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
var apiResponse = new AccountApi().CreateAccount(accountCreateModel, fields);
```


<h6 id="GetForgotPasswordToken-post-">Forgot Password token (POST)</h6>
This API Returns a Forgot Password Token it can also be used to send a Forgot Password email to the customer. Note: If you have the UserName workflow enabled, you may replace the 'email' parameter with 'username' in the body. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/get-forgot-password-token)



```

var email = "email"; //Required
var emailTemplate = "emailTemplate"; //Optional
var resetPasswordUrl = "resetPasswordUrl"; //Optional
var sendEmail = true; //Optional
var apiResponse = new AccountApi().GetForgotPasswordToken(email, emailTemplate, resetPasswordUrl, sendEmail);
```


<h6 id="GetEmailVerificationToken-post-">Email Verification token (POST)</h6>
This API Returns an Email Verification token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/get-email-verification-token)



```

var email = "email"; //Required
var apiResponse = new AccountApi().GetEmailVerificationToken(email);
```


<h6 id="GetPrivacyPolicyHistoryByUid-get-">Get Privacy Policy History By Uid (GET)</h6>
This API is used to retrieve all of the accepted Policies by the user, associated with their UID. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/privacy-policy-history-by-uid/)



```

var uid = "uid"; //Required
var apiResponse = new AccountApi().GetPrivacyPolicyHistoryByUid(uid);
```


<h6 id="GetAccountProfileByEmail-get-">Account Profiles by Email (GET)</h6>
This API is used to retrieve all of the profile data, associated with the specified account by email in Cloud Storage. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-profiles-by-email)



```

var email = "email"; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().GetAccountProfileByEmail(email, fields);
```


<h6 id="GetAccountProfileByUserName-get-">Account Profiles by Username (GET)</h6>
This API is used to retrieve all of the profile data associated with the specified account by user name in Cloud Storage. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-profiles-by-user-name)



```

var userName = "userName"; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().GetAccountProfileByUserName(userName, fields);
```


<h6 id="GetAccountProfileByPhone-get-">Account Profile by Phone ID (GET)</h6>
This API is used to retrieve all of the profile data, associated with the account by phone number in Cloud Storage. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-profiles-by-phone-id/)



```

var phone = "phone"; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().GetAccountProfileByPhone(phone, fields);
```


<h6 id="GetAccountProfileByUid-get-">Account Profiles by UID (GET)</h6>
This API is used to retrieve all of the profile data, associated with the account by uid in Cloud Storage. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-profiles-by-uid)



```

var uid = "uid"; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().GetAccountProfileByUid(uid, fields);
```


<h6 id="GetAccountPasswordHashByUid-get-">Account Password (GET)</h6>
This API use to retrive the hashed password of a specified account in Cloud Storage. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-password)



```

var uid = "uid"; //Required
var apiResponse = new AccountApi().GetAccountPasswordHashByUid(uid);
```


<h6 id="GetAccessTokenByUid-get-">Access Token based on UID or User impersonation API (GET)</h6>
The API is used to get LoginRadius access token based on UID. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-impersonation-api)



```

var uid = "uid"; //Required
var apiResponse = new AccountApi().GetAccessTokenByUid(uid);
```


<h6 id="RefreshAccessTokenByRefreshToken-get-">Refresh Access Token by Refresh Token (GET)</h6>
This API is used to refresh an access_token via it's associated refresh_token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/refresh-token/refresh-access-token-by-refresh-token)



```

var refreshToken = "refreshToken"; //Required
var apiResponse = new AccountApi().RefreshAccessTokenByRefreshToken(refreshToken);
```


<h6 id="RevokeRefreshToken-get-">Revoke Refresh Token (GET)</h6>
The Revoke Refresh Access Token API is used to revoke a refresh token or the Provider Access Token, revoking an existing refresh token will invalidate the refresh token but the associated access token will work until the expiry. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/refresh-token/revoke-refresh-token)



```

var refreshToken = "refreshToken"; //Required
var apiResponse = new AccountApi().RevokeRefreshToken(refreshToken);
```


<h6 id="GetAccountIdentitiesByEmail-get-">Account Identities by Email (GET)</h6>
Note: This is intended for specific workflows where an email may be associated to multiple UIDs. This API is used to retrieve all of the identities (UID and Profiles), associated with a specified email in Cloud Storage. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-identities-by-email)



```

var email = "email"; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().GetAccountIdentitiesByEmail(email, fields);
```


<h6 id="DeleteAccountByUid-delete-">Account Delete (DELETE)</h6>
This API deletes the Users account and allows them to re-register for a new account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-delete)



```

var uid = "uid"; //Required
var apiResponse = new AccountApi().DeleteAccountByUid(uid);
```


<h6 id="RemoveEmail-delete-">Account Remove Email (DELETE)</h6>
Use this API to Remove emails from a user Account [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-email-delete)



```

var email = "email"; //Required
var uid = "uid"; //Required
string fields = null; //Optional
var apiResponse = new AccountApi().RemoveEmail(email, uid, fields);
```


<h6 id="AccountDeleteByEmail-delete-">Delete User Profiles By Email (DELETE)</h6>
This API is used to delete all user profiles associated with an Email. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/account/account-email-delete/)



```

var email = "email"; //Required
var apiResponse = new AccountApi().AccountDeleteByEmail(email);
```







### Social API


List of APIs in this Section:<br>
[POST : Post Message API](#PostMessage-post-)<br>
[POST : Status Posting ](#StatusPosting-post-)<br>
[POST : Trackable Status Posting](#TrackableStatusPosting-post-)<br>
[GET : Access Token](#ExchangeAccessToken-get-)<br>
[GET : Refresh Token](#RefreshAccessToken-get-)<br>
[GET : Token Validate](#ValidateAccessToken-get-)<br>
[GET : Access Token Invalidate](#InValidateAccessToken-get-)<br>
[GET : Get Active Session Details](#GetActiveSession-get-)<br>
[GET : Get Active Session By Account Id](#GetActiveSessionByAccountID-get-)<br>
[GET : Get Active Session By Profile Id](#GetActiveSessionByProfileID-get-)<br>
[GET : Album](#GetAlbums-get-)<br>
[GET : Get Albums with cursor](#GetAlbumsWithCursor-get-)<br>
[GET : Audio](#GetAudios-get-)<br>
[GET : Get Audio With Cursor](#GetAudiosWithCursor-get-)<br>
[GET : Check In](#GetCheckIns-get-)<br>
[GET : Get CheckIns With Cursor](#GetCheckInsWithCursor-get-)<br>
[GET : Contact](#GetContacts-get-)<br>
[GET : Event](#GetEvents-get-)<br>
[GET : Get Events With Cursor](#GetEventsWithCursor-get-)<br>
[GET : Following](#GetFollowings-get-)<br>
[GET : Get Followings With Cursor](#GetFollowingsWithCursor-get-)<br>
[GET : Group](#GetGroups-get-)<br>
[GET : Get Groups With Cursor](#GetGroupsWithCursor-get-)<br>
[GET : Like](#GetLikes-get-)<br>
[GET : Get Likes With Cursor](#GetLikesWithCursor-get-)<br>
[GET : Mention](#GetMentions-get-)<br>
[GET : Page](#GetPage-get-)<br>
[GET : Photo](#GetPhotos-get-)<br>
[GET : Get Post](#GetPosts-get-)<br>
[GET : Get Trackable Status Stats](#GetTrackableStatusStats-get-)<br>
[GET : Trackable Status Fetching](#TrackableStatusFetching-get-)<br>
[GET : User Profile](#GetSocialUserProfile-get-)<br>
[GET : Refresh User Profile](#GetRefreshedSocialUserProfile-get-)<br>
[GET : Video](#GetVideos-get-)<br>



<h6 id="PostMessage-post-">Post Message API (POST)</h6>
Post Message API is used to post messages to the user's contacts.<br><br><b>Supported Providers:</b> Twitter, LinkedIn <br><br>The Message API is used to post messages to the user?s contacts. This is one of the APIs that makes up the LoginRadius Friend Invite System. After using the Contact API, you can send messages to the retrieved contacts. This API requires setting permissions in your LoginRadius Dashboard.<br><br>GET & POST Message API work the same way except the API method is different [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/post-message-api)



```

var accessToken = "accessToken"; //Required
var message = "message"; //Required
var subject = "subject"; //Required
var to = "to"; //Required
var apiResponse = new SocialApi().PostMessage(accessToken, message, subject, to);
```


<h6 id="StatusPosting-post-">Status Posting  (POST)</h6>
The Status API is used to update the status on the user's wall.<br><br><b>Supported Providers:</b>  Facebook, Twitter, LinkedIn [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/status-posting/)



```

var accessToken = "accessToken"; //Required
var caption = "caption"; //Required
var description = "description"; //Required
var imageUrl = "imageUrl"; //Required
var status = "status"; //Required
var title = "title"; //Required
var url = "url"; //Required
var shorturl = "shorturl"; //Optional
var apiResponse = new SocialApi().StatusPosting(accessToken, caption, description, imageUrl, status, title, url, shorturl);
```


<h6 id="TrackableStatusPosting-post-">Trackable Status Posting (POST)</h6>
The Trackable status API works very similar to the Status API but it returns a Post id that you can use to track the stats(shares, likes, comments) for a specific share/post/status update. This API requires setting permissions in your LoginRadius Dashboard.<br><br> The Trackable Status API is used to update the status on the user's wall and return an Post ID value. It is commonly referred to as Permission based sharing or Push notifications.<br><br> POST Input Parameter Format: application/x-www-form-urlencoded [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/trackable-status-posting/)



```

var accessToken = "accessToken"; //Required
StatusModel statusModel = new StatusModel{
Caption ="<Caption>",
Description ="<Description>",
Imageurl ="<Imageurl>",
Status ="<Status>",
Title ="<Title>",
Url ="<Url>"
}; //Required
var apiResponse = new SocialApi().TrackableStatusPosting(accessToken, statusModel);
```


<h6 id="ExchangeAccessToken-get-">Access Token (GET)</h6>
This API Is used to translate the Request Token returned during authentication into an Access Token that can be used with other API calls. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/access-token)



```

var token = "token"; //Required
var apiResponse = new SocialApi().ExchangeAccessToken(token);
```


<h6 id="RefreshAccessToken-get-">Refresh Token (GET)</h6>
The Refresh Access Token API is used to refresh the provider access token after authentication. It will be valid for up to 60 days on LoginRadius depending on the provider. In order to use the access token in other APIs, always refresh the token using this API.<br><br><b>Supported Providers :</b> Facebook,Yahoo,Google,Twitter, Linkedin.<br><br> Contact LoginRadius support team to enable this API. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/refresh-token/refresh-token)



```

var accessToken = "accessToken"; //Required
var expiresIn = 0; //Optional
var apiResponse = new SocialApi().RefreshAccessToken(accessToken, expiresIn);
```


<h6 id="ValidateAccessToken-get-">Token Validate (GET)</h6>
This API validates access token, if valid then returns a response with its expiry otherwise error. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/validate-access-token)



```

var accessToken = "accessToken"; //Required
var apiResponse = new SocialApi().ValidateAccessToken(accessToken);
```


<h6 id="InValidateAccessToken-get-">Access Token Invalidate (GET)</h6>
This api invalidates the active access token or expires an access token validity. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/invalidate-access-token)



```

var accessToken = "accessToken"; //Required
var apiResponse = new SocialApi().InValidateAccessToken(accessToken);
```


<h6 id="GetActiveSession-get-">Get Active Session Details (GET)</h6>
This api is use to get all active session by Access Token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/get-active-session-details)



```

var token = "token"; //Required
var apiResponse = new SocialApi().GetActiveSession(token);
```


<h6 id="GetActiveSessionByAccountID-get-">Get Active Session By Account Id (GET)</h6>
This api is used to get all active sessions by AccountID(UID). [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/active-session-by-account-id/)



```

var accountId = "accountId"; //Required
var apiResponse = new SocialApi().GetActiveSessionByAccountID(accountId);
```


<h6 id="GetActiveSessionByProfileID-get-">Get Active Session By Profile Id (GET)</h6>
This api is used to get all active sessions by ProfileId. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/active-session-by-profile-id/)



```

var profileId = "profileId"; //Required
var apiResponse = new SocialApi().GetActiveSessionByProfileID(profileId);
```


<h6 id="GetAlbums-get-">Album (GET)</h6>
<b>Supported Providers:</b> Facebook, Google, Live, Vkontakte.<br><br> This API returns the photo albums associated with the passed in access tokens Social Profile. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/album/)



```

var accessToken = "accessToken"; //Required
var apiResponse = new SocialApi().GetAlbums(accessToken);
```


<h6 id="GetAlbumsWithCursor-get-">Get Albums with cursor (GET)</h6>
<b>Supported Providers:</b> Facebook, Google, Live, Vkontakte.<br><br> This API returns the photo albums associated with the passed in access tokens Social Profile. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/album/)



```

var accessToken = "accessToken"; //Required
var nextCursor = "nextCursor"; //Required
var apiResponse = new SocialApi().GetAlbumsWithCursor(accessToken, nextCursor);
```


<h6 id="GetAudios-get-">Audio (GET)</h6>
The Audio API is used to get audio files data from the user's social account.<br><br><b>Supported Providers:</b> Live, Vkontakte [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/audio)



```

var accessToken = "accessToken"; //Required
var apiResponse = new SocialApi().GetAudios(accessToken);
```


<h6 id="GetAudiosWithCursor-get-">Get Audio With Cursor (GET)</h6>
The Audio API is used to get audio files data from the user's social account.<br><br><b>Supported Providers:</b> Live, Vkontakte [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/audio)



```

var accessToken = "accessToken"; //Required
var nextCursor = "nextCursor"; //Required
var apiResponse = new SocialApi().GetAudiosWithCursor(accessToken, nextCursor);
```


<h6 id="GetCheckIns-get-">Check In (GET)</h6>
The Check In API is used to get check Ins data from the user's social account.<br><br><b>Supported Providers:</b> Facebook, Foursquare, Vkontakte [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/check-in)



```

var accessToken = "accessToken"; //Required
var apiResponse = new SocialApi().GetCheckIns(accessToken);
```


<h6 id="GetCheckInsWithCursor-get-">Get CheckIns With Cursor (GET)</h6>
The Check In API is used to get check Ins data from the user's social account.<br><br><b>Supported Providers:</b> Facebook, Foursquare, Vkontakte [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/check-in)



```

var accessToken = "accessToken"; //Required
var nextCursor = "nextCursor"; //Required
var apiResponse = new SocialApi().GetCheckInsWithCursor(accessToken, nextCursor);
```


<h6 id="GetContacts-get-">Contact (GET)</h6>
The Contact API is used to get contacts/friends/connections data from the user's social account.This is one of the APIs that makes up the LoginRadius Friend Invite System. The data will normalized into LoginRadius' standard data format. This API requires setting permissions in your LoginRadius Dashboard. <br><br><b>Note:</b> Facebook restricts access to the list of friends that is returned. When using the Contacts API with Facebook you will only receive friends that have accepted some permissions with your app. <br><br><b>Supported Providers:</b> Facebook, Foursquare, Google, LinkedIn, Live, Twitter, Vkontakte, Yahoo [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/contact)



```

var accessToken = "accessToken"; //Required
var nextCursor = "nextCursor"; //Optional
var apiResponse = new SocialApi().GetContacts(accessToken, nextCursor);
```


<h6 id="GetEvents-get-">Event (GET)</h6>
The Event API is used to get the event data from the user's social account.<br><br><b>Supported Providers:</b> Facebook, Live [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/event)



```

var accessToken = "accessToken"; //Required
var apiResponse = new SocialApi().GetEvents(accessToken);
```


<h6 id="GetEventsWithCursor-get-">Get Events With Cursor (GET)</h6>
The Event API is used to get the event data from the user's social account.<br><br><b>Supported Providers:</b> Facebook, Live [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/event)



```

var accessToken = "accessToken"; //Required
var nextCursor = "nextCursor"; //Required
var apiResponse = new SocialApi().GetEventsWithCursor(accessToken, nextCursor);
```


<h6 id="GetFollowings-get-">Following (GET)</h6>
Get the following user list from the user's social account.<br><br><b>Supported Providers:</b> Twitter [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/following)



```

var accessToken = "accessToken"; //Required
var apiResponse = new SocialApi().GetFollowings(accessToken);
```


<h6 id="GetFollowingsWithCursor-get-">Get Followings With Cursor (GET)</h6>
Get the following user list from the user's social account.<br><br><b>Supported Providers:</b> Twitter [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/following)



```

var accessToken = "accessToken"; //Required
var nextCursor = "nextCursor"; //Required
var apiResponse = new SocialApi().GetFollowingsWithCursor(accessToken, nextCursor);
```


<h6 id="GetGroups-get-">Group (GET)</h6>
The Group API is used to get group data from the user's social account.<br><br><b>Supported Providers:</b> Facebook, Vkontakte [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/group)



```

var accessToken = "accessToken"; //Required
var apiResponse = new SocialApi().GetGroups(accessToken);
```


<h6 id="GetGroupsWithCursor-get-">Get Groups With Cursor (GET)</h6>
The Group API is used to get group data from the user's social account.<br><br><b>Supported Providers:</b> Facebook, Vkontakte [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/group)



```

var accessToken = "accessToken"; //Required
var nextCursor = "nextCursor"; //Required
var apiResponse = new SocialApi().GetGroupsWithCursor(accessToken, nextCursor);
```


<h6 id="GetLikes-get-">Like (GET)</h6>
The Like API is used to get likes data from the user's social account.<br><br><b>Supported Providers:</b> Facebook [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/like)



```

var accessToken = "accessToken"; //Required
var apiResponse = new SocialApi().GetLikes(accessToken);
```


<h6 id="GetLikesWithCursor-get-">Get Likes With Cursor (GET)</h6>
The Like API is used to get likes data from the user's social account.<br><br><b>Supported Providers:</b> Facebook [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/like)



```

var accessToken = "accessToken"; //Required
var nextCursor = "nextCursor"; //Required
var apiResponse = new SocialApi().GetLikesWithCursor(accessToken, nextCursor);
```


<h6 id="GetMentions-get-">Mention (GET)</h6>
The Mention API is used to get mentions data from the user's social account.<br><br><b>Supported Providers:</b> Twitter [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/mention)



```

var accessToken = "accessToken"; //Required
var apiResponse = new SocialApi().GetMentions(accessToken);
```


<h6 id="GetPage-get-">Page (GET)</h6>
The Page API is used to get the page data from the user's social account.<br><br><b>Supported Providers:</b>  Facebook, LinkedIn [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/page)



```

var accessToken = "accessToken"; //Required
var pageName = "pageName"; //Required
var apiResponse = new SocialApi().GetPage(accessToken, pageName);
```


<h6 id="GetPhotos-get-">Photo (GET)</h6>
The Photo API is used to get photo data from the user's social account.<br><br><b>Supported Providers:</b>  Facebook, Foursquare, Google, Live, Vkontakte [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/photo)



```

var accessToken = "accessToken"; //Required
var albumId = "albumId"; //Required
var apiResponse = new SocialApi().GetPhotos(accessToken, albumId);
```


<h6 id="GetPosts-get-">Get Post (GET)</h6>
The Post API is used to get post message data from the user's social account.<br><br><b>Supported Providers:</b>  Facebook [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/post)



```

var accessToken = "accessToken"; //Required
var apiResponse = new SocialApi().GetPosts(accessToken);
```


<h6 id="GetTrackableStatusStats-get-">Get Trackable Status Stats (GET)</h6>
The Trackable status API works very similar to the Status API but it returns a Post id that you can use to track the stats(shares, likes, comments) for a specific share/post/status update. This API requires setting permissions in your LoginRadius Dashboard.<br><br> The Trackable Status API is used to update the status on the user's wall and return an Post ID value. It is commonly referred to as Permission based sharing or Push notifications. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/get-trackable-status-stats/)



```

var accessToken = "accessToken"; //Required
var caption = "caption"; //Required
var description = "description"; //Required
var imageUrl = "imageUrl"; //Required
var status = "status"; //Required
var title = "title"; //Required
var url = "url"; //Required
var apiResponse = new SocialApi().GetTrackableStatusStats(accessToken, caption, description, imageUrl, status, title, url);
```


<h6 id="TrackableStatusFetching-get-">Trackable Status Fetching (GET)</h6>
The Trackable status API works very similar to the Status API but it returns a Post id that you can use to track the stats(shares, likes, comments) for a specific share/post/status update. This API requires setting permissions in your LoginRadius Dashboard.<br><br> This API is used to retrieve a tracked post based on the passed in post ID value. This API requires setting permissions in your LoginRadius Dashboard.<br><br> <b>Note:</b> To utilize this API you need to find the ID for the post you want to track, which might require using Trackable Status Posting API first. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/trackable-status-fetching/)



```

var postId = "postId"; //Required
var apiResponse = new SocialApi().TrackableStatusFetching(postId);
```


<h6 id="GetSocialUserProfile-get-">User Profile (GET)</h6>
The User Profile API is used to get social profile data from the user's social account after authentication.<br><br><b>Supported Providers:</b>  All [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/user-profile)



```

var accessToken = "accessToken"; //Required
string fields = null; //Optional
var apiResponse = new SocialApi().GetSocialUserProfile(accessToken, fields);
```


<h6 id="GetRefreshedSocialUserProfile-get-">Refresh User Profile (GET)</h6>
The User Profile API is used to get the latest updated social profile data from the user's social account after authentication. The social profile will be retrieved via oAuth and OpenID protocols. The data is normalized into LoginRadius' standard data format. This API should be called using the access token retrieved from the refresh access token API. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/refresh-token/refresh-user-profile)



```

var accessToken = "accessToken"; //Required
string fields = null; //Optional
var apiResponse = new SocialApi().GetRefreshedSocialUserProfile(accessToken, fields);
```


<h6 id="GetVideos-get-">Video (GET)</h6>
The Video API is used to get video files data from the user's social account.<br><br><b>Supported Providers:</b>   Facebook, Google, Live, Vkontakte [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/advanced-social-api/video)



```

var accessToken = "accessToken"; //Required
var nextCursor = "nextCursor"; //Required
var apiResponse = new SocialApi().GetVideos(accessToken, nextCursor);
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

```
public class cobj
  {
        public string field1 { get; set; }
        public string field2 { get; set; }
  }
```
```
cobj customObject = new cobj();
customObject.field1 = "XXXX";
customObject.field2 = "YYYY";
```



<h6 id="UpdateCustomObjectByToken-put-">Custom Object Update by Access Token (PUT)</h6>
This API is used to update the specified custom object data of the specified account. If the value of updatetype is 'replace' then it will fully replace custom object with the new custom object and if the value of updatetype is 'partialreplace' then it will perform an upsert type operation [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/custom-object-update-by-objectrecordid-and-token)



```

var accessToken = "accessToken"; //Required
var objectName = "objectName"; //Required
var objectRecordId = "objectRecordId"; //Required

CustomObjectUpdateOperationType updateType = CustomObjectUpdateOperationType.Default; //Optional
var apiResponse = new CustomObjectApi().UpdateCustomObjectByToken(accessToken, objectName, objectRecordId, customObject, updateType);
```


<h6 id="UpdateCustomObjectByUid-put-">Custom Object Update by UID (PUT)</h6>
This API is used to update the specified custom object data of a specified account. If the value of updatetype is 'replace' then it will fully replace custom object with new custom object and if the value of updatetype is partialreplace then it will perform an upsert type operation. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/custom-object-update-by-objectrecordid-and-uid)



```

var objectName = "objectName"; //Required
var objectRecordId = "objectRecordId"; //Required

var uid = "uid"; //Required
CustomObjectUpdateOperationType updateType = CustomObjectUpdateOperationType.Default; //Optional
var apiResponse = new CustomObjectApi().UpdateCustomObjectByUid(objectName, objectRecordId, customObject, uid, updateType);
```


<h6 id="CreateCustomObjectByToken-post-">Create Custom Object by Token (POST)</h6>
This API is used to write information in JSON format to the custom object for the specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/create-custom-object-by-token)



```

var accessToken = "accessToken"; //Required
var objectName = "objectName"; //Required

var apiResponse = new CustomObjectApi().CreateCustomObjectByToken(accessToken, objectName, customObject);
```


<h6 id="CreateCustomObjectByUid-post-">Create Custom Object by UID (POST)</h6>
This API is used to write information in JSON format to the custom object for the specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/create-custom-object-by-uid)



```

var objectName = "objectName"; //Required

var uid = "uid"; //Required
var apiResponse = new CustomObjectApi().CreateCustomObjectByUid(objectName, customObject, uid);
```


<h6 id="GetCustomObjectByToken-get-">Custom Object by Token (GET)</h6>
This API is used to retrieve the specified Custom Object data for the specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/custom-object-by-token)



```

var accessToken = "accessToken"; //Required
var objectName = "objectName"; //Required
var apiResponse = new CustomObjectApi().GetCustomObjectByToken(accessToken, objectName);
```


<h6 id="GetCustomObjectByRecordIDAndToken-get-">Custom Object by ObjectRecordId and Token (GET)</h6>
This API is used to retrieve the Custom Object data for the specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/custom-object-by-objectrecordid-and-token)



```

var accessToken = "accessToken"; //Required
var objectName = "objectName"; //Required
var objectRecordId = "objectRecordId"; //Required
var apiResponse = new CustomObjectApi().GetCustomObjectByRecordIDAndToken(accessToken, objectName, objectRecordId);
```


<h6 id="GetCustomObjectByUid-get-">Custom Object By UID (GET)</h6>
This API is used to retrieve all the custom objects by UID from cloud storage. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/custom-object-by-uid)



```

var objectName = "objectName"; //Required
var uid = "uid"; //Required
var apiResponse = new CustomObjectApi().GetCustomObjectByUid(objectName, uid);
```


<h6 id="GetCustomObjectByRecordID-get-">Custom Object by ObjectRecordId and UID (GET)</h6>
This API is used to retrieve the Custom Object data for the specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/custom-object-by-objectrecordid-and-uid)



```

var objectName = "objectName"; //Required
var objectRecordId = "objectRecordId"; //Required
var uid = "uid"; //Required
var apiResponse = new CustomObjectApi().GetCustomObjectByRecordID(objectName, objectRecordId, uid);
```


<h6 id="DeleteCustomObjectByToken-delete-">Custom Object Delete by Record Id And Token (DELETE)</h6>
This API is used to remove the specified Custom Object data using ObjectRecordId of a specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/custom-object-delete-by-objectrecordid-and-token)



```

var accessToken = "accessToken"; //Required
var objectName = "objectName"; //Required
var objectRecordId = "objectRecordId"; //Required
var apiResponse = new CustomObjectApi().DeleteCustomObjectByToken(accessToken, objectName, objectRecordId);
```


<h6 id="DeleteCustomObjectByRecordID-delete-">Account Delete Custom Object by ObjectRecordId (DELETE)</h6>
This API is used to remove the specified Custom Object data using ObjectRecordId of specified account. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-object/custom-object-delete-by-objectrecordid-and-uid)



```

var objectName = "objectName"; //Required
var objectRecordId = "objectRecordId"; //Required
var uid = "uid"; //Required
var apiResponse = new CustomObjectApi().DeleteCustomObjectByRecordID(objectName, objectRecordId, uid);
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



```

ResetPasswordByOTPModel resetPasswordByOTPModel = new ResetPasswordByOTPModel{
Otp ="<Otp>",
Password ="<Password>",
Phone ="<Phone>"
}; //Required
var apiResponse = new PhoneAuthenticationApi().ResetPasswordByPhoneOTP(resetPasswordByOTPModel);
```


<h6 id="PhoneVerificationByOTP-put-">Phone Verification OTP (PUT)</h6>
This API is used to validate the verification code sent to verify a user's phone number [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-verify-otp)



```

var otp = "otp"; //Required
var phone = "phone"; //Required
string fields = null; //Optional
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new PhoneAuthenticationApi().PhoneVerificationByOTP(otp, phone, fields, smsTemplate);
```


<h6 id="PhoneVerificationOTPByAccessToken-put-">Phone Verification OTP by Token (PUT)</h6>
This API is used to consume the verification code sent to verify a user's phone number. Use this call for front-end purposes in cases where the user is already logged in by passing the user's access token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-verify-otp-by-token)



```

var accessToken = "accessToken"; //Required
var otp = "otp"; //Required
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new PhoneAuthenticationApi().PhoneVerificationOTPByAccessToken(accessToken, otp, smsTemplate);
```


<h6 id="UpdatePhoneNumber-put-">Phone Number Update (PUT)</h6>
This API is used to update the login Phone Number of users [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-number-update)



```

var accessToken = "accessToken"; //Required
var phone = "phone"; //Required
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new PhoneAuthenticationApi().UpdatePhoneNumber(accessToken, phone, smsTemplate);
```


<h6 id="LoginByPhone-post-">Phone Login (POST)</h6>
This API retrieves a copy of the user data based on the Phone [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-login)



```

PhoneAuthenticationModel phoneAuthenticationModel = new PhoneAuthenticationModel{
Password ="<Password>",
Phone ="<Phone>"
}; //Required
string fields = null; //Optional
var loginUrl = "loginUrl"; //Optional
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new PhoneAuthenticationApi().LoginByPhone(phoneAuthenticationModel, fields, loginUrl, smsTemplate);
```


<h6 id="ForgotPasswordByPhoneOTP-post-">Phone Forgot Password by OTP (POST)</h6>
This API is used to send the OTP to reset the account password. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-forgot-password-by-otp)



```

var phone = "phone"; //Required
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new PhoneAuthenticationApi().ForgotPasswordByPhoneOTP(phone, smsTemplate);
```


<h6 id="PhoneResendVerificationOTP-post-">Phone Resend Verification OTP (POST)</h6>
This API is used to resend a verification OTP to verify a user's Phone Number. The user will receive a verification code that they will need to input [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-resend-otp)



```

var phone = "phone"; //Required
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new PhoneAuthenticationApi().PhoneResendVerificationOTP(phone, smsTemplate);
```


<h6 id="PhoneResendVerificationOTPByToken-post-">Phone Resend Verification OTP By Token (POST)</h6>
This API is used to resend a verification OTP to verify a user's Phone Number in cases in which an active token already exists [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-resend-otp-by-token)



```

var accessToken = "accessToken"; //Required
var phone = "phone"; //Required
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new PhoneAuthenticationApi().PhoneResendVerificationOTPByToken(accessToken, phone, smsTemplate);
```


<h6 id="UserRegistrationByPhone-post-">Phone User Registration by SMS (POST)</h6>
This API registers the new users into your Cloud Storage and triggers the phone verification process. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-user-registration-by-sms)



```

AuthUserRegistrationModel authUserRegistrationModel = new AuthUserRegistrationModel{
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
var apiResponse = new PhoneAuthenticationApi().UserRegistrationByPhone(authUserRegistrationModel, sott, fields, options, smsTemplate, verificationUrl, welcomeEmailTemplate);
```


<h6 id="CheckPhoneNumberAvailability-get-">Phone Number Availability (GET)</h6>
This API is used to check the Phone Number exists or not on your site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-number-availability)



```

var phone = "phone"; //Required
var apiResponse = new PhoneAuthenticationApi().CheckPhoneNumberAvailability(phone);
```


<h6 id="RemovePhoneIDByAccessToken-delete-">Remove Phone ID by Access Token (DELETE)</h6>
This API is used to delete the Phone ID on a user's account via the access_token [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/remove-phone-id-by-access-token)



```

var accessToken = "accessToken"; //Required
var apiResponse = new PhoneAuthenticationApi().RemovePhoneIDByAccessToken(accessToken);
```







### MultiFactorAuthentication API


List of APIs in this Section:<br>
[PUT : Update MFA Setting](#MFAUpdateSetting-put-)<br>
[PUT : Update MFA by Access Token](#MFAUpdateByAccessToken-put-)<br>
[PUT : MFA Update Phone Number by Token](#MFAUpdatePhoneNumberByToken-put-)<br>
[PUT : MFA Validate OTP](#MFAValidateOTPByPhone-put-)<br>
[PUT : MFA Validate Google Auth Code](#MFAValidateGoogleAuthCode-put-)<br>
[PUT : MFA Validate Backup code](#MFAValidateBackupCode-put-)<br>
[PUT : MFA Update Phone Number](#MFAUpdatePhoneNumber-put-)<br>
[POST : MFA Email Login](#MFALoginByEmail-post-)<br>
[POST : MFA UserName Login](#MFALoginByUserName-post-)<br>
[POST : MFA Phone Login](#MFALoginByPhone-post-)<br>
[GET : MFA Validate Access Token](#MFAConfigureByAccessToken-get-)<br>
[GET : MFA Backup Code by Access Token](#MFABackupCodeByAccessToken-get-)<br>
[GET : Reset Backup Code by Access Token](#MFAResetBackupCodeByAccessToken-get-)<br>
[GET : MFA Resend Otp](#MFAResendOTP-get-)<br>
[GET : MFA Backup Code by UID](#MFABackupCodeByUid-get-)<br>
[GET : MFA Reset Backup Code by UID](#MFAResetBackupCodeByUid-get-)<br>
[DELETE : MFA Reset Google Authenticator by Token](#MFAResetGoogleAuthByToken-delete-)<br>
[DELETE : MFA Reset SMS Authenticator by Token](#MFAResetSMSAuthByToken-delete-)<br>
[DELETE : MFA Reset SMS Authenticator By UID](#MFAResetSMSAuthenticatorByUid-delete-)<br>
[DELETE : MFA Reset Google Authenticator By UID](#MFAResetGoogleAuthenticatorByUid-delete-)<br>



<h6 id="MFAUpdateSetting-put-">Update MFA Setting (PUT)</h6>
This API is used to trigger the Multi-factor authentication settings after login for secure actions [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/sms-authenticator/update-mfa-setting/)



```

var accessToken = "accessToken"; //Required
MultiFactorAuthModelWithLockout multiFactorAuthModelWithLockout = new MultiFactorAuthModelWithLockout{
Otp ="<Otp>"
}; //Required
string fields = null; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAUpdateSetting(accessToken, multiFactorAuthModelWithLockout, fields);
```


<h6 id="MFAUpdateByAccessToken-put-">Update MFA by Access Token (PUT)</h6>
This API is used to Enable Multi-factor authentication by access token on user login [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/google-authenticator/update-mfa-by-access-token/)



```

var accessToken = "accessToken"; //Required
MultiFactorAuthModelByGoogleAuthenticatorCode multiFactorAuthModelByGoogleAuthenticatorCode = new MultiFactorAuthModelByGoogleAuthenticatorCode{
GoogleAuthenticatorCode ="<GoogleAuthenticatorCode>"
}; //Required
string fields = null; //Optional
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAUpdateByAccessToken(accessToken, multiFactorAuthModelByGoogleAuthenticatorCode, fields, smsTemplate);
```


<h6 id="MFAUpdatePhoneNumberByToken-put-">MFA Update Phone Number by Token (PUT)</h6>
This API is used to update the Multi-factor authentication phone number by sending the verification OTP to the provided phone number [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/sms-authenticator/mfa-update-phone-number-by-token/)



```

var accessToken = "accessToken"; //Required
var phoneNo2FA = "phoneNo2FA"; //Required
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAUpdatePhoneNumberByToken(accessToken, phoneNo2FA, smsTemplate2FA);
```


<h6 id="MFAValidateOTPByPhone-put-">MFA Validate OTP (PUT)</h6>
This API is used to login via Multi-factor authentication by passing the One Time Password received via SMS [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/sms-authenticator/mfa-validate-otp/)



```

MultiFactorAuthModelWithLockout multiFactorAuthModelWithLockout = new MultiFactorAuthModelWithLockout{
Otp ="<Otp>"
}; //Required
var secondFactorAuthenticationToken = "secondFactorAuthenticationToken"; //Required
string fields = null; //Optional
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAValidateOTPByPhone(multiFactorAuthModelWithLockout, secondFactorAuthenticationToken, fields, smsTemplate2FA);
```


<h6 id="MFAValidateGoogleAuthCode-put-">MFA Validate Google Auth Code (PUT)</h6>
This API is used to login via Multi-factor-authentication by passing the google authenticator code. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/google-authenticator/mfa-validate-google-auth-code/)



```

var googleAuthenticatorCode = "googleAuthenticatorCode"; //Required
var secondFactorAuthenticationToken = "secondFactorAuthenticationToken"; //Required
string fields = null; //Optional
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAValidateGoogleAuthCode(googleAuthenticatorCode, secondFactorAuthenticationToken, fields, smsTemplate2FA);
```


<h6 id="MFAValidateBackupCode-put-">MFA Validate Backup code (PUT)</h6>
This API is used to validate the backup code provided by the user and if valid, we return an access_token allowing the user to login incases where Multi-factor authentication (MFA) is enabled and the secondary factor is unavailable. When a user initially downloads the Backup codes, We generate 10 codes, each code can only be consumed once. if any user attempts to go over the number of invalid login attempts configured in the Dashboard then the account gets blocked automatically [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/backup-codes/mfa-validate-backup-code/)



```

MultiFactorAuthModelByBackupCode multiFactorAuthModelByBackupCode = new MultiFactorAuthModelByBackupCode{
BackupCode ="<BackupCode>"
}; //Required
var secondFactorAuthenticationToken = "secondFactorAuthenticationToken"; //Required
string fields = null; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAValidateBackupCode(multiFactorAuthModelByBackupCode, secondFactorAuthenticationToken, fields);
```


<h6 id="MFAUpdatePhoneNumber-put-">MFA Update Phone Number (PUT)</h6>
This API is used to update (if configured) the phone number used for Multi-factor authentication by sending the verification OTP to the provided phone number [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/sms-authenticator/mfa-update-phone-number/)



```

var phoneNo2FA = "phoneNo2FA"; //Required
var secondFactorAuthenticationToken = "secondFactorAuthenticationToken"; //Required
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAUpdatePhoneNumber(phoneNo2FA, secondFactorAuthenticationToken, smsTemplate2FA);
```


<h6 id="MFALoginByEmail-post-">MFA Email Login (POST)</h6>
This API can be used to login by emailid on a Multi-factor authentication enabled LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/mfa-email-login)



```

var email = "email"; //Required
var password = "password"; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
var loginUrl = "loginUrl"; //Optional
var smsTemplate = "smsTemplate"; //Optional
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFALoginByEmail(email, password, emailTemplate, fields, loginUrl, smsTemplate, smsTemplate2FA, verificationUrl);
```


<h6 id="MFALoginByUserName-post-">MFA UserName Login (POST)</h6>
This API can be used to login by username on a Multi-factor authentication enabled LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/mfa-user-name-login)



```

var password = "password"; //Required
var username = "username"; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
var loginUrl = "loginUrl"; //Optional
var smsTemplate = "smsTemplate"; //Optional
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFALoginByUserName(password, username, emailTemplate, fields, loginUrl, smsTemplate, smsTemplate2FA, verificationUrl);
```


<h6 id="MFALoginByPhone-post-">MFA Phone Login (POST)</h6>
This API can be used to login by Phone on a Multi-factor authentication enabled LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/mfa-phone-login)



```

var password = "password"; //Required
var phone = "phone"; //Required
var emailTemplate = "emailTemplate"; //Optional
string fields = null; //Optional
var loginUrl = "loginUrl"; //Optional
var smsTemplate = "smsTemplate"; //Optional
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFALoginByPhone(password, phone, emailTemplate, fields, loginUrl, smsTemplate, smsTemplate2FA, verificationUrl);
```


<h6 id="MFAConfigureByAccessToken-get-">MFA Validate Access Token (GET)</h6>
This API is used to configure the Multi-factor authentication after login by using the access_token when MFA is set as optional on the LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/mfa-validate-access-token/)



```

var accessToken = "accessToken"; //Required
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAConfigureByAccessToken(accessToken, smsTemplate2FA);
```


<h6 id="MFABackupCodeByAccessToken-get-">MFA Backup Code by Access Token (GET)</h6>
This API is used to get a set of backup codes via access_token to allow the user login on a site that has Multi-factor Authentication enabled in the event that the user does not have a secondary factor available. We generate 10 codes, each code can only be consumed once. If any user attempts to go over the number of invalid login attempts configured in the Dashboard then the account gets blocked automatically [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/backup-codes/mfa-backup-code-by-access-token/)



```

var accessToken = "accessToken"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFABackupCodeByAccessToken(accessToken);
```


<h6 id="MFAResetBackupCodeByAccessToken-get-">Reset Backup Code by Access Token (GET)</h6>
API is used to reset the backup codes on a given account via the access_token. This API call will generate 10 new codes, each code can only be consumed once [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/backup-codes/mfa-reset-backup-code-by-access-token/)



```

var accessToken = "accessToken"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAResetBackupCodeByAccessToken(accessToken);
```


<h6 id="MFAResendOTP-get-">MFA Resend Otp (GET)</h6>
This API is used to resending the verification OTP to the provided phone number [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/resend-twofactorauthentication-otp/)



```

var secondFactorAuthenticationToken = "secondFactorAuthenticationToken"; //Required
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var apiResponse = new MultiFactorAuthenticationApi().MFAResendOTP(secondFactorAuthenticationToken, smsTemplate2FA);
```


<h6 id="MFABackupCodeByUid-get-">MFA Backup Code by UID (GET)</h6>
This API is used to reset the backup codes on a given account via the UID. This API call will generate 10 new codes, each code can only be consumed once. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/backup-codes/mfa-backup-code-by-uid/)



```

var uid = "uid"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFABackupCodeByUid(uid);
```


<h6 id="MFAResetBackupCodeByUid-get-">MFA Reset Backup Code by UID (GET)</h6>
This API is used to reset the backup codes on a given account via the UID. This API call will generate 10 new codes, each code can only be consumed once. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/backup-codes/mfa-reset-backup-code-by-uid/)



```

var uid = "uid"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAResetBackupCodeByUid(uid);
```


<h6 id="MFAResetGoogleAuthByToken-delete-">MFA Reset Google Authenticator by Token (DELETE)</h6>
This API Resets the Google Authenticator configurations on a given account via the access_token [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/google-authenticator/mfa-reset-google-authenticator-by-token/)



```

var accessToken = "accessToken"; //Required
var googleAuthenticator = true; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAResetGoogleAuthByToken(accessToken, googleAuthenticator);
```


<h6 id="MFAResetSMSAuthByToken-delete-">MFA Reset SMS Authenticator by Token (DELETE)</h6>
This API resets the SMS Authenticator configurations on a given account via the access_token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/sms-authenticator/mfa-reset-sms-authenticator-by-token/)



```

var accessToken = "accessToken"; //Required
var otpAuthenticator = true; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAResetSMSAuthByToken(accessToken, otpAuthenticator);
```


<h6 id="MFAResetSMSAuthenticatorByUid-delete-">MFA Reset SMS Authenticator By UID (DELETE)</h6>
This API resets the SMS Authenticator configurations on a given account via the UID. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/sms-authenticator/mfa-reset-sms-authenticator-by-uid/)



```

var otpAuthenticator = true; //Required
var uid = "uid"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAResetSMSAuthenticatorByUid(otpAuthenticator, uid);
```


<h6 id="MFAResetGoogleAuthenticatorByUid-delete-">MFA Reset Google Authenticator By UID (DELETE)</h6>
This API resets the Google Authenticator configurations on a given account via the UID. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/google-authenticator/mfa-reset-google-authenticator-by-uid/)



```

var googleAuthenticator = true; //Required
var uid = "uid"; //Required
var apiResponse = new MultiFactorAuthenticationApi().MFAResetGoogleAuthenticatorByUid(googleAuthenticator, uid);
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



```

ResetPINByResetToken resetPINByResetToken = new ResetPINByResetToken{
PIN ="<PIN>",
ResetToken ="<ResetToken>"
}; //Required
var apiResponse = new PINAuthenticationApi().ResetPINByResetToken(resetPINByResetToken);
```


<h6 id="ResetPINByEmailAndSecurityAnswer-put-">Reset PIN By SecurityAnswer And Email (PUT)</h6>
This API is used to reset pin using security question answer and email. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/reset-pin-by-securityanswer-and-email/)



```

ResetPINBySecurityQuestionAnswerAndEmailModel resetPINBySecurityQuestionAnswerAndEmailModel = new ResetPINBySecurityQuestionAnswerAndEmailModel{
Email ="<Email>",
PIN ="<PIN>",
SecurityAnswer = new Dictionary<String,String>{
["QuestionID"] = "Answer"
}
}; //Required
var apiResponse = new PINAuthenticationApi().ResetPINByEmailAndSecurityAnswer(resetPINBySecurityQuestionAnswerAndEmailModel);
```


<h6 id="ResetPINByUsernameAndSecurityAnswer-put-">Reset PIN By SecurityAnswer And Username (PUT)</h6>
This API is used to reset pin using security question answer and username. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/reset-pin-by-securityanswer-and-username/)



```

ResetPINBySecurityQuestionAnswerAndUsernameModel resetPINBySecurityQuestionAnswerAndUsernameModel = new ResetPINBySecurityQuestionAnswerAndUsernameModel{
PIN ="<PIN>",
SecurityAnswer = new Dictionary<String,String>{
["QuestionID"] = "Answer"
},
Username ="<Username>"
}; //Required
var apiResponse = new PINAuthenticationApi().ResetPINByUsernameAndSecurityAnswer(resetPINBySecurityQuestionAnswerAndUsernameModel);
```


<h6 id="ResetPINByPhoneAndSecurityAnswer-put-">Reset PIN By SecurityAnswer And Phone (PUT)</h6>
This API is used to reset pin using security question answer and phone. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/reset-pin-by-securityanswer-and-phone/)



```

ResetPINBySecurityQuestionAnswerAndPhoneModel resetPINBySecurityQuestionAnswerAndPhoneModel = new ResetPINBySecurityQuestionAnswerAndPhoneModel{
Phone ="<Phone>",
PIN ="<PIN>",
SecurityAnswer = new Dictionary<String,String>{
["QuestionID"] = "Answer"
}
}; //Required
var apiResponse = new PINAuthenticationApi().ResetPINByPhoneAndSecurityAnswer(resetPINBySecurityQuestionAnswerAndPhoneModel);
```


<h6 id="ChangePINByAccessToken-put-">Change PIN By Token (PUT)</h6>
This API is used to change a user's PIN using access token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/change-pin-by-access-token/)



```

var accessToken = "accessToken"; //Required
ChangePINModel changePINModel = new ChangePINModel{
NewPIN ="<NewPIN>",
OldPIN ="<OldPIN>"
}; //Required
var apiResponse = new PINAuthenticationApi().ChangePINByAccessToken(accessToken, changePINModel);
```


<h6 id="ResetPINByPhoneAndOtp-put-">Reset PIN by Phone and OTP (PUT)</h6>
This API is used to reset pin using phoneId and OTP. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/reset-pin-by-phone-and-otp/)



```

ResetPINByPhoneAndOTPModel resetPINByPhoneAndOTPModel = new ResetPINByPhoneAndOTPModel{
Otp ="<Otp>",
Phone ="<Phone>",
PIN ="<PIN>"
}; //Required
var apiResponse = new PINAuthenticationApi().ResetPINByPhoneAndOtp(resetPINByPhoneAndOTPModel);
```


<h6 id="ResetPINByEmailAndOtp-put-">Reset PIN by Email and OTP (PUT)</h6>
This API is used to reset pin using email and OTP. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/reset-pin-by-email-and-otp/)



```

ResetPINByEmailAndOtpModel resetPINByEmailAndOtpModel = new ResetPINByEmailAndOtpModel{
Email ="<Email>",
Otp ="<Otp>",
PIN ="<PIN>"
}; //Required
var apiResponse = new PINAuthenticationApi().ResetPINByEmailAndOtp(resetPINByEmailAndOtpModel);
```


<h6 id="ResetPINByUsernameAndOtp-put-">Reset PIN by Username and OTP (PUT)</h6>
This API is used to reset pin using username and OTP. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/reset-pin-by-username-and-otp/)



```

ResetPINByUsernameAndOtpModel resetPINByUsernameAndOtpModel = new ResetPINByUsernameAndOtpModel{
Otp ="<Otp>",
PIN ="<PIN>",
Username ="<Username>"
}; //Required
var apiResponse = new PINAuthenticationApi().ResetPINByUsernameAndOtp(resetPINByUsernameAndOtpModel);
```


<h6 id="PINLogin-post-">PIN Login (POST)</h6>
This API is used to login a user by pin and session_token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/login-by-pin/)



```

LoginByPINModel loginByPINModel = new LoginByPINModel{
PIN ="<PIN>"
}; //Required
var sessionToken = "sessionToken"; //Required
var apiResponse = new PINAuthenticationApi().PINLogin(loginByPINModel, sessionToken);
```


<h6 id="SendForgotPINEmailByEmail-post-">Forgot PIN By Email (POST)</h6>
This API sends the reset pin email to specified email address. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/forgot-pin-by-email/)



```

ForgotPINLinkByEmailModel forgotPINLinkByEmailModel = new ForgotPINLinkByEmailModel{
Email ="<Email>"
}; //Required
var emailTemplate = "emailTemplate"; //Optional
var resetPINUrl = "resetPINUrl"; //Optional
var apiResponse = new PINAuthenticationApi().SendForgotPINEmailByEmail(forgotPINLinkByEmailModel, emailTemplate, resetPINUrl);
```


<h6 id="SendForgotPINEmailByUsername-post-">Forgot PIN By UserName (POST)</h6>
This API sends the reset pin email using username. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/forgot-pin-by-username/)



```

ForgotPINLinkByUserNameModel forgotPINLinkByUserNameModel = new ForgotPINLinkByUserNameModel{
UserName ="<UserName>"
}; //Required
var emailTemplate = "emailTemplate"; //Optional
var resetPINUrl = "resetPINUrl"; //Optional
var apiResponse = new PINAuthenticationApi().SendForgotPINEmailByUsername(forgotPINLinkByUserNameModel, emailTemplate, resetPINUrl);
```


<h6 id="SendForgotPINSMSByPhone-post-">Forgot PIN By Phone (POST)</h6>
This API sends the OTP to specified phone number [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/forgot-pin-by-phone/)



```

ForgotPINOtpByPhoneModel forgotPINOtpByPhoneModel = new ForgotPINOtpByPhoneModel{
Phone ="<Phone>"
}; //Required
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new PINAuthenticationApi().SendForgotPINSMSByPhone(forgotPINOtpByPhoneModel, smsTemplate);
```


<h6 id="SetPINByPinAuthToken-post-">Set PIN By PinAuthToken (POST)</h6>
This API is used to change a user's PIN using Pin Auth token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/set-pin-by-pinauthtoken/)



```

PINRequiredModel pinRequiredModel = new PINRequiredModel{
PIN ="<PIN>"
}; //Required
var pinAuthToken = "pinAuthToken"; //Required
var apiResponse = new PINAuthenticationApi().SetPINByPinAuthToken(pinRequiredModel, pinAuthToken);
```


<h6 id="InValidatePinSessionToken-get-">Invalidate PIN Session Token (GET)</h6>
This API is used to invalidate pin session token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/pin-authentication/invalidate-pin-session-token/)



```

var sessionToken = "sessionToken"; //Required
var apiResponse = new PINAuthenticationApi().InValidatePinSessionToken(sessionToken);
```







### ReAuthentication API


List of APIs in this Section:<br>
[PUT : Validate MFA by OTP](#MFAReAuthenticateByOTP-put-)<br>
[PUT : Validate MFA by Backup Code](#MFAReAuthenticateByBackupCode-put-)<br>
[PUT : Validate MFA by Google Authenticator Code](#MFAReAuthenticateByGoogleAuth-put-)<br>
[PUT : Validate MFA by Password](#MFAReAuthenticateByPassword-put-)<br>
[PUT : MFA Re-authentication by PIN](#VerifyPINAuthentication-put-)<br>
[POST : Verify Multifactor OTP Authentication](#VerifyMultiFactorOtpReauthentication-post-)<br>
[POST : Verify Multifactor Password Authentication](#VerifyMultiFactorPasswordReauthentication-post-)<br>
[POST : Verify Multifactor PIN Authentication](#VerifyMultiFactorPINReauthentication-post-)<br>
[GET : Multi Factor Re-Authenticate](#MFAReAuthenticate-get-)<br>



<h6 id="MFAReAuthenticateByOTP-put-">Validate MFA by OTP (PUT)</h6>
This API is used to re-authenticate via Multi-factor authentication by passing the One Time Password received via SMS [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/re-authentication/mfa/re-auth-by-otp/)



```

var accessToken = "accessToken"; //Required
ReauthByOtpModel reauthByOtpModel = new ReauthByOtpModel{
Otp ="<Otp>"
}; //Required
var apiResponse = new ReAuthenticationApi().MFAReAuthenticateByOTP(accessToken, reauthByOtpModel);
```


<h6 id="MFAReAuthenticateByBackupCode-put-">Validate MFA by Backup Code (PUT)</h6>
This API is used to re-authenticate by set of backup codes via access_token on the site that has Multi-factor authentication enabled in re-authentication for the user that does not have the device [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/re-authentication/mfa/re-auth-by-backup-code/)



```

var accessToken = "accessToken"; //Required
ReauthByBackupCodeModel reauthByBackupCodeModel = new ReauthByBackupCodeModel{
BackupCode ="<BackupCode>"
}; //Required
var apiResponse = new ReAuthenticationApi().MFAReAuthenticateByBackupCode(accessToken, reauthByBackupCodeModel);
```


<h6 id="MFAReAuthenticateByGoogleAuth-put-">Validate MFA by Google Authenticator Code (PUT)</h6>
This API is used to re-authenticate via Multi-factor-authentication by passing the google authenticator code [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/re-authentication/re-auth-by-google-authenticator-code)



```

var accessToken = "accessToken"; //Required
ReauthByGoogleAuthenticatorCodeModel reauthByGoogleAuthenticatorCodeModel = new ReauthByGoogleAuthenticatorCodeModel{
GoogleAuthenticatorCode ="<GoogleAuthenticatorCode>"
}; //Required
var apiResponse = new ReAuthenticationApi().MFAReAuthenticateByGoogleAuth(accessToken, reauthByGoogleAuthenticatorCodeModel);
```


<h6 id="MFAReAuthenticateByPassword-put-">Validate MFA by Password (PUT)</h6>
This API is used to re-authenticate via Multi-factor-authentication by passing the password [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/re-authentication/re-auth-by-password)



```

var accessToken = "accessToken"; //Required
PasswordEventBasedAuthModelWithLockout passwordEventBasedAuthModelWithLockout = new PasswordEventBasedAuthModelWithLockout{
Password ="<Password>"
}; //Required
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var apiResponse = new ReAuthenticationApi().MFAReAuthenticateByPassword(accessToken, passwordEventBasedAuthModelWithLockout, smsTemplate2FA);
```


<h6 id="VerifyPINAuthentication-put-">MFA Re-authentication by PIN (PUT)</h6>
This API is used to validate the triggered MFA authentication flow with a password. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/re-authentication/pin/re-auth-by-pin/)



```

var accessToken = "accessToken"; //Required
PINAuthEventBasedAuthModelWithLockout pinAuthEventBasedAuthModelWithLockout = new PINAuthEventBasedAuthModelWithLockout{
PIN ="<PIN>"
}; //Required
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var apiResponse = new ReAuthenticationApi().VerifyPINAuthentication(accessToken, pinAuthEventBasedAuthModelWithLockout, smsTemplate2FA);
```


<h6 id="VerifyMultiFactorOtpReauthentication-post-">Verify Multifactor OTP Authentication (POST)</h6>
This API is used on the server-side to validate and verify the re-authentication token created by the MFA re-authentication API. This API checks re-authentications created by OTP. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/re-authentication/mfa/re-auth-validate-mfa/)



```

EventBasedMultiFactorToken eventBasedMultiFactorToken = new EventBasedMultiFactorToken{
SecondFactorValidationToken ="<SecondFactorValidationToken>"
}; //Required
var uid = "uid"; //Required
var apiResponse = new ReAuthenticationApi().VerifyMultiFactorOtpReauthentication(eventBasedMultiFactorToken, uid);
```


<h6 id="VerifyMultiFactorPasswordReauthentication-post-">Verify Multifactor Password Authentication (POST)</h6>
This API is used on the server-side to validate and verify the re-authentication token created by the MFA re-authentication API. This API checks re-authentications created by password. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/re-authentication/re-auth-validate-password/)



```

EventBasedMultiFactorToken eventBasedMultiFactorToken = new EventBasedMultiFactorToken{
SecondFactorValidationToken ="<SecondFactorValidationToken>"
}; //Required
var uid = "uid"; //Required
var apiResponse = new ReAuthenticationApi().VerifyMultiFactorPasswordReauthentication(eventBasedMultiFactorToken, uid);
```


<h6 id="VerifyMultiFactorPINReauthentication-post-">Verify Multifactor PIN Authentication (POST)</h6>
This API is used on the server-side to validate and verify the re-authentication token created by the MFA re-authentication API. This API checks re-authentications created by PIN. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/re-authentication/pin/re-auth-validate-pin/)



```

EventBasedMultiFactorToken eventBasedMultiFactorToken = new EventBasedMultiFactorToken{
SecondFactorValidationToken ="<SecondFactorValidationToken>"
}; //Required
var uid = "uid"; //Required
var apiResponse = new ReAuthenticationApi().VerifyMultiFactorPINReauthentication(eventBasedMultiFactorToken, uid);
```


<h6 id="MFAReAuthenticate-get-">Multi Factor Re-Authenticate (GET)</h6>
This API is used to trigger the Multi-Factor Autentication workflow for the provided access_token [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/multi-factor-authentication/re-authentication/re-auth-trigger/)



```

var accessToken = "accessToken"; //Required
var smsTemplate2FA = "smsTemplate2FA"; //Optional
var apiResponse = new ReAuthenticationApi().MFAReAuthenticate(accessToken, smsTemplate2FA);
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



```

var accessToken = "accessToken"; //Required
ConsentUpdateModel consentUpdateModel = new ConsentUpdateModel{
Consents = new List<ConsentDataModel>{
new ConsentDataModel{
ConsentOptionId ="<ConsentOptionId>",
IsAccepted = true
}}
}; //Required
var apiResponse = new ConsentManagementApi().UpdateConsentProfileByAccessToken(accessToken, consentUpdateModel);
```


<h6 id="SubmitConsentByConsentToken-post-">Consent By ConsentToken (POST)</h6>
This API is to submit consent form using consent token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/consent-management/consent-by-consent-token/)



```

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
var apiResponse = new ConsentManagementApi().SubmitConsentByConsentToken(consentToken, consentSubmitModel);
```


<h6 id="SubmitConsentByAccessToken-post-">Post Consent By Access Token (POST)</h6>
API to provide a way to end user to submit a consent form for particular event type. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/consent-management/consent-by-access-token/)



```

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
var apiResponse = new ConsentManagementApi().SubmitConsentByAccessToken(accessToken, consentSubmitModel);
```


<h6 id="GetConsentLogsByUid-get-">Get Consent Logs By Uid (GET)</h6>
This API is used to get the Consent logs of the user. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/consent-management/consent-log-by-uid/)



```

var uid = "uid"; //Required
var apiResponse = new ConsentManagementApi().GetConsentLogsByUid(uid);
```


<h6 id="GetConsentLogs-get-">Get Consent Log by Access Token (GET)</h6>
This API is used to fetch consent logs. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/consent-management/consent-log-by-access-token/)



```

var accessToken = "accessToken"; //Required
var apiResponse = new ConsentManagementApi().GetConsentLogs(accessToken);
```


<h6 id="VerifyConsentByAccessToken-get-">Get Verify Consent By Access Token (GET)</h6>
This API is used to check if consent is submitted for a particular event or not. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/consent-management/verify-consent-by-access-token/)



```

var accessToken = "accessToken"; //Required
var @event = "@event"; //Required
var isCustom = true; //Required
var apiResponse = new ConsentManagementApi().VerifyConsentByAccessToken(accessToken, @event, isCustom);
```







### SmartLogin API


List of APIs in this Section:<br>
[GET : Smart Login Verify Token](#SmartLoginTokenVerification-get-)<br>
[GET : Smart Login By Email](#SmartLoginByEmail-get-)<br>
[GET : Smart Login By Username](#SmartLoginByUserName-get-)<br>
[GET : Smart Login Ping](#SmartLoginPing-get-)<br>



<h6 id="SmartLoginTokenVerification-get-">Smart Login Verify Token (GET)</h6>
This API verifies the provided token for Smart Login [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/smart-login/smart-login-verify-token/)



```

var verificationToken = "verificationToken"; //Required
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new SmartLoginApi().SmartLoginTokenVerification(verificationToken, welcomeEmailTemplate);
```


<h6 id="SmartLoginByEmail-get-">Smart Login By Email (GET)</h6>
This API sends a Smart Login link to the user's Email Id. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/smart-login/smart-login-by-email)



```

var clientGuid = "clientGuid"; //Required
var email = "email"; //Required
var redirectUrl = "redirectUrl"; //Optional
var smartLoginEmailTemplate = "smartLoginEmailTemplate"; //Optional
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new SmartLoginApi().SmartLoginByEmail(clientGuid, email, redirectUrl, smartLoginEmailTemplate, welcomeEmailTemplate);
```


<h6 id="SmartLoginByUserName-get-">Smart Login By Username (GET)</h6>
This API sends a Smart Login link to the user's Email Id. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/smart-login/smart-login-by-username)



```

var clientGuid = "clientGuid"; //Required
var username = "username"; //Required
var redirectUrl = "redirectUrl"; //Optional
var smartLoginEmailTemplate = "smartLoginEmailTemplate"; //Optional
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new SmartLoginApi().SmartLoginByUserName(clientGuid, username, redirectUrl, smartLoginEmailTemplate, welcomeEmailTemplate);
```


<h6 id="SmartLoginPing-get-">Smart Login Ping (GET)</h6>
This API is used to check if the Smart Login link has been clicked or not [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/smart-login/smart-login-ping)



```

var clientGuid = "clientGuid"; //Required
string fields = null; //Optional
var apiResponse = new SmartLoginApi().SmartLoginPing(clientGuid, fields);
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



```

var otp = "otp"; //Required
var phone = "phone"; //Required
string fields = null; //Optional
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new OneTouchLoginApi().OneTouchLoginOTPVerification(otp, phone, fields, smsTemplate);
```


<h6 id="OneTouchLoginByEmail-post-">One Touch Login by Email (POST)</h6>
This API is used to send a link to a specified email for a frictionless login/registration [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/one-touch-login/one-touch-login-by-email-captcha/)



```

OneTouchLoginByEmailModel oneTouchLoginByEmailModel = new OneTouchLoginByEmailModel{
Clientguid ="<Clientguid>",
Email ="<Email>",
G_recaptcha_response ="<G-recaptcha-response>"
}; //Required
var oneTouchLoginEmailTemplate = "oneTouchLoginEmailTemplate"; //Optional
var redirecturl = "redirecturl"; //Optional
var welcomeemailtemplate = "welcomeemailtemplate"; //Optional
var apiResponse = new OneTouchLoginApi().OneTouchLoginByEmail(oneTouchLoginByEmailModel, oneTouchLoginEmailTemplate, redirecturl, welcomeemailtemplate);
```


<h6 id="OneTouchLoginByPhone-post-">One Touch Login by Phone (POST)</h6>
This API is used to send one time password to a given phone number for a frictionless login/registration. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/one-touch-login/one-touch-login-by-phone-captcha/)



```

OneTouchLoginByPhoneModel oneTouchLoginByPhoneModel = new OneTouchLoginByPhoneModel{
G_recaptcha_response ="<G-recaptcha-response>",
Phone ="<Phone>"
}; //Required
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new OneTouchLoginApi().OneTouchLoginByPhone(oneTouchLoginByPhoneModel, smsTemplate);
```


<h6 id="OneTouchEmailVerification-get-">One Touch Email Verification (GET)</h6>
This API verifies the provided token for One Touch Login [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/one-touch-login/one-touch-email-verification)



```

var verificationToken = "verificationToken"; //Required
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new OneTouchLoginApi().OneTouchEmailVerification(verificationToken, welcomeEmailTemplate);
```


<h6 id="OneTouchLoginPing-get-">One Touch Login Ping (GET)</h6>
This API is used to check if the One Touch Login link has been clicked or not. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/one-touch-login/one-touch-login-ping/)



```

var clientGuid = "clientGuid"; //Required
string fields = null; //Optional
var apiResponse = new OneTouchLoginApi().OneTouchLoginPing(clientGuid, fields);
```







### PasswordLessLogin API


List of APIs in this Section:<br>
[PUT : Passwordless Login Phone Verification](#PasswordlessLoginPhoneVerification-put-)<br>
[GET : Passwordless Login by Phone](#PasswordlessLoginByPhone-get-)<br>
[GET : Passwordless Login By Email](#PasswordlessLoginByEmail-get-)<br>
[GET : Passwordless Login By UserName](#PasswordlessLoginByUserName-get-)<br>
[GET : Passwordless Login Verification](#PasswordlessLoginVerification-get-)<br>



<h6 id="PasswordlessLoginPhoneVerification-put-">Passwordless Login Phone Verification (PUT)</h6>
This API verifies an account by OTP and allows the customer to login. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/passwordless-login/passwordless-login-phone-verification)



```

PasswordLessLoginOtpModel passwordLessLoginOtpModel = new PasswordLessLoginOtpModel{
Otp ="<Otp>",
Phone ="<Phone>"
}; //Required
string fields = null; //Optional
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new PasswordLessLoginApi().PasswordlessLoginPhoneVerification(passwordLessLoginOtpModel, fields, smsTemplate);
```


<h6 id="PasswordlessLoginByPhone-get-">Passwordless Login by Phone (GET)</h6>
API can be used to send a One-time Passcode (OTP) provided that the account has a verified PhoneID [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/passwordless-login/passwordless-login-by-phone)



```

var phone = "phone"; //Required
var smsTemplate = "smsTemplate"; //Optional
var apiResponse = new PasswordLessLoginApi().PasswordlessLoginByPhone(phone, smsTemplate);
```


<h6 id="PasswordlessLoginByEmail-get-">Passwordless Login By Email (GET)</h6>
This API is used to send a Passwordless Login verification link to the provided Email ID [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/passwordless-login/passwordless-login-by-email)



```

var email = "email"; //Required
var passwordLessLoginTemplate = "passwordLessLoginTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new PasswordLessLoginApi().PasswordlessLoginByEmail(email, passwordLessLoginTemplate, verificationUrl);
```


<h6 id="PasswordlessLoginByUserName-get-">Passwordless Login By UserName (GET)</h6>
This API is used to send a Passwordless Login Verification Link to a customer by providing their UserName [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/passwordless-login/passwordless-login-by-username)



```

var username = "username"; //Required
var passwordLessLoginTemplate = "passwordLessLoginTemplate"; //Optional
var verificationUrl = "verificationUrl"; //Optional
var apiResponse = new PasswordLessLoginApi().PasswordlessLoginByUserName(username, passwordLessLoginTemplate, verificationUrl);
```


<h6 id="PasswordlessLoginVerification-get-">Passwordless Login Verification (GET)</h6>
This API is used to verify the Passwordless Login verification link. Note: If you are using Passwordless Login by Phone you will need to use the Passwordless Login Phone Verification API [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/passwordless-login/passwordless-login-verification)



```

var verificationToken = "verificationToken"; //Required
string fields = null; //Optional
var welcomeEmailTemplate = "welcomeEmailTemplate"; //Optional
var apiResponse = new PasswordLessLoginApi().PasswordlessLoginVerification(verificationToken, fields, welcomeEmailTemplate);
```







### Configuration API


List of APIs in this Section:<br>[GET : Get Configurations](#getConfigurations-get-)<br>
[GET : Get Server Time](#GetServerInfo-get-)<br>

<h6 id="getConfigurations-get-">Get Configurations (GET)</h6>
This API is used to get the configurations which are set in the LoginRadius Dashboard for a particular LoginRadius site/environment [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/configuration/get-configurations/)



```
var apiResponse = new ConfigurationApi().GetConfigurations();
```

<h6 id="GetServerInfo-get-">Get Server Time (GET)</h6>
This API allows you to query your LoginRadius account for basic server information and server time information which is useful when generating an SOTT token. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/configuration/get-server-time/)



```

var timeDifference = 0; //Optional
var apiResponse = new ConfigurationApi().GetServerInfo(timeDifference);
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



```

AccountRolesModel accountRolesModel = new AccountRolesModel{
Roles = new List<String>{"Roles"}
}; //Required
var uid = "uid"; //Required
var apiResponse = new RoleApi().AssignRolesByUid(accountRolesModel, uid);
```


<h6 id="UpdateRoleContextByUid-put-">Upsert Context (PUT)</h6>
This API creates a Context with a set of Roles [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/upsert-context)



```

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
var apiResponse = new RoleApi().UpdateRoleContextByUid(accountRoleContextModel, uid);
```


<h6 id="AddRolePermissions-put-">Add Permissions to Role (PUT)</h6>
This API is used to add permissions to a given role. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/add-permissions-to-role)



```

PermissionsModel permissionsModel = new PermissionsModel{
Permissions = new List<String>{"Permissions"}
}; //Required
var role = "role"; //Required
var apiResponse = new RoleApi().AddRolePermissions(permissionsModel, role);
```


<h6 id="CreateRoles-post-">Roles Create (POST)</h6>
This API creates a role with permissions. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/roles-create)



```

RolesModel rolesModel = new RolesModel{
Roles = new List<RoleModel>{
new RoleModel{
Name ="<Name>",
Permissions = new Dictionary<String,Boolean>{
["Permission_name"] = true
}
}}
}; //Required
var apiResponse = new RoleApi().CreateRoles(rolesModel);
```


<h6 id="GetRolesByUid-get-">Roles by UID (GET)</h6>
API is used to retrieve all the assigned roles of a particular User. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/get-roles-by-uid)



```

var uid = "uid"; //Required
var apiResponse = new RoleApi().GetRolesByUid(uid);
```


<h6 id="GetRoleContextByUid-get-">Get Context with Roles and Permissions (GET)</h6>
This API Gets the contexts that have been configured and the associated roles and permissions. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/get-context)



```

var uid = "uid"; //Required
var apiResponse = new RoleApi().GetRoleContextByUid(uid);
```


<h6 id="GetRoleContextByContextName-get-">Role Context profile (GET)</h6>
The API is used to retrieve role context by the context name. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/role-context-profile/)



```

var contextName = "contextName"; //Required
var apiResponse = new RoleApi().GetRoleContextByContextName(contextName);
```


<h6 id="GetRolesList-get-">Roles List (GET)</h6>
This API retrieves the complete list of created roles with permissions of your app. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/roles-list)



```

var apiResponse = new RoleApi().GetRolesList();
```


<h6 id="UnassignRolesByUid-delete-">Unassign Roles by UID (DELETE)</h6>
This API is used to unassign roles from a user. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/unassign-roles-by-uid)



```

AccountRolesModel accountRolesModel = new AccountRolesModel{
Roles = new List<String>{"Roles"}
}; //Required
var uid = "uid"; //Required
var apiResponse = new RoleApi().UnassignRolesByUid(accountRolesModel, uid);
```


<h6 id="DeleteRoleContextByUid-delete-">Delete Role Context (DELETE)</h6>
This API Deletes the specified Role Context [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/delete-context)



```

var contextName = "contextName"; //Required
var uid = "uid"; //Required
var apiResponse = new RoleApi().DeleteRoleContextByUid(contextName, uid);
```


<h6 id="DeleteRolesFromRoleContextByUid-delete-">Delete Role from Context (DELETE)</h6>
This API Deletes the specified Role from a Context. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/delete-role-from-context/)



```

var contextName = "contextName"; //Required
RoleContextRemoveRoleModel roleContextRemoveRoleModel = new RoleContextRemoveRoleModel{
Roles = new List<String>{"Roles"}
}; //Required
var uid = "uid"; //Required
var apiResponse = new RoleApi().DeleteRolesFromRoleContextByUid(contextName, roleContextRemoveRoleModel, uid);
```


<h6 id="DeleteAdditionalPermissionFromRoleContextByUid-delete-">Delete Additional Permission from Context (DELETE)</h6>
This API Deletes Additional Permissions from Context. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/delete-permissions-from-context)



```

var contextName = "contextName"; //Required
RoleContextAdditionalPermissionRemoveRoleModel roleContextAdditionalPermissionRemoveRoleModel = new RoleContextAdditionalPermissionRemoveRoleModel{
AdditionalPermissions = new List<String>{"AdditionalPermissions"}
}; //Required
var uid = "uid"; //Required
var apiResponse = new RoleApi().DeleteAdditionalPermissionFromRoleContextByUid(contextName, roleContextAdditionalPermissionRemoveRoleModel, uid);
```


<h6 id="DeleteRole-delete-">Account Delete Role (DELETE)</h6>
This API is used to delete the role. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/delete-role)



```

var role = "role"; //Required
var apiResponse = new RoleApi().DeleteRole(role);
```


<h6 id="RemoveRolePermissions-delete-">Remove Permissions (DELETE)</h6>
API is used to remove permissions from a role. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/roles-management/remove-permissions)



```

PermissionsModel permissionsModel = new PermissionsModel{
Permissions = new List<String>{"Permissions"}
}; //Required
var role = "role"; //Required
var apiResponse = new RoleApi().RemoveRolePermissions(permissionsModel, role);
```







### CustomRegistrationData API


List of APIs in this Section:<br>
[PUT : Update Registration Data](#UpdateRegistrationData-put-)<br>
[POST : Validate secret code](#ValidateRegistrationDataCode-post-)<br>
[POST : Add Registration Data](#AddRegistrationData-post-)<br>
[GET : Auth Get Registration Data Server](#AuthGetRegistrationData-get-)<br>
[GET : Get Registration Data](#GetRegistrationData-get-)<br>
[DELETE : Delete Registration Data](#DeleteRegistrationData-delete-)<br>
[DELETE : Delete All Records by Datasource](#DeleteAllRecordsByDataSource-delete-)<br>



<h6 id="UpdateRegistrationData-put-">Update Registration Data (PUT)</h6>
This API allows you to update a dropdown item [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-registration-data/update-registration-data)



```

RegistrationDataUpdateModel registrationDataUpdateModel = new RegistrationDataUpdateModel{
IsActive = true,
Key ="<Key>",
Type ="<Type>",
Value ="<Value>"
}; //Required
var recordId = "recordId"; //Required
var apiResponse = new CustomRegistrationDataApi().UpdateRegistrationData(registrationDataUpdateModel, recordId);
```


<h6 id="ValidateRegistrationDataCode-post-">Validate secret code (POST)</h6>
This API allows you to validate code for a particular dropdown member. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-registration-data/validate-code)



```

var code = "code"; //Required
var recordId = "recordId"; //Required
var apiResponse = new CustomRegistrationDataApi().ValidateRegistrationDataCode(code, recordId);
```


<h6 id="AddRegistrationData-post-">Add Registration Data (POST)</h6>
This API allows you to fill data into a dropdown list which you have created for user Registeration. For more details on how to use this API please see our Custom Registration Data Overview [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-registration-data/add-registration-data)



```

RegistrationDataCreateModelList registrationDataCreateModelList = new RegistrationDataCreateModelList{
Data = new List<RegistrationDataCreateModel>{
new RegistrationDataCreateModel{
Code ="<Code>",
IsActive = true,
Key ="<Key>",
ParentId ="<ParentId>",
Type ="<Type>",
Value ="<Value>"
}}
}; //Required
var apiResponse = new CustomRegistrationDataApi().AddRegistrationData(registrationDataCreateModelList);
```


<h6 id="AuthGetRegistrationData-get-">Auth Get Registration Data Server (GET)</h6>
This API is used to retrieve dropdown data. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-registration-data/auth-get-registration-data)



```

var type = "type"; //Required
var limit = 0; //Optional
var parentId = "parentId"; //Optional
var skip = 0; //Optional
var apiResponse = new CustomRegistrationDataApi().AuthGetRegistrationData(type, limit, parentId, skip);
```


<h6 id="GetRegistrationData-get-">Get Registration Data (GET)</h6>
This API is used to retrieve dropdown data. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-registration-data/get-registration-data)



```

var type = "type"; //Required
var limit = 0; //Optional
var parentId = "parentId"; //Optional
var skip = 0; //Optional
var apiResponse = new CustomRegistrationDataApi().GetRegistrationData(type, limit, parentId, skip);
```


<h6 id="DeleteRegistrationData-delete-">Delete Registration Data (DELETE)</h6>
This API allows you to delete an item from a dropdown list. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-registration-data/delete-registration-data)



```

var recordId = "recordId"; //Required
var apiResponse = new CustomRegistrationDataApi().DeleteRegistrationData(recordId);
```


<h6 id="DeleteAllRecordsByDataSource-delete-">Delete All Records by Datasource (DELETE)</h6>
This API allows you to delete all records contained in a datasource. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/custom-registration-data/delete-all-records-by-datasource)



```

var type = "type"; //Required
var apiResponse = new CustomRegistrationDataApi().DeleteAllRecordsByDataSource(type);
```







### RiskBasedAuthentication API


List of APIs in this Section:<br>
[POST : Risk Based Authentication Login by Email](#RBALoginByEmail-post-)<br>
[POST : Risk Based Authentication Login by Username](#RBALoginByUserName-post-)<br>
[POST : Risk Based Authentication Phone Login](#RBALoginByPhone-post-)<br>



<h6 id="RBALoginByEmail-post-">Risk Based Authentication Login by Email (POST)</h6>
This API retrieves a copy of the user data based on the Email [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-login-by-email)



```

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
var apiResponse = new RiskBasedAuthenticationApi().RBALoginByEmail(emailAuthenticationModel, emailTemplate, fields, loginUrl, passwordDelegation, passwordDelegationApp, rbaBrowserEmailTemplate, rbaBrowserSmsTemplate, rbaCityEmailTemplate, rbaCitySmsTemplate, rbaCountryEmailTemplate, rbaCountrySmsTemplate, rbaIpEmailTemplate, rbaIpSmsTemplate, rbaOneclickEmailTemplate, rbaOTPSmsTemplate, smsTemplate, verificationUrl);
```


<h6 id="RBALoginByUserName-post-">Risk Based Authentication Login by Username (POST)</h6>
This API retrieves a copy of the user data based on the Username [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/authentication/auth-login-by-username)



```

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
var apiResponse = new RiskBasedAuthenticationApi().RBALoginByUserName(userNameAuthenticationModel, emailTemplate, fields, loginUrl, passwordDelegation, passwordDelegationApp, rbaBrowserEmailTemplate, rbaBrowserSmsTemplate, rbaCityEmailTemplate, rbaCitySmsTemplate, rbaCountryEmailTemplate, rbaCountrySmsTemplate, rbaIpEmailTemplate, rbaIpSmsTemplate, rbaOneclickEmailTemplate, rbaOTPSmsTemplate, smsTemplate, verificationUrl);
```


<h6 id="RBALoginByPhone-post-">Risk Based Authentication Phone Login (POST)</h6>
This API retrieves a copy of the user data based on the Phone [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/phone-authentication/phone-login)



```

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
var apiResponse = new RiskBasedAuthenticationApi().RBALoginByPhone(phoneAuthenticationModel, emailTemplate, fields, loginUrl, passwordDelegation, passwordDelegationApp, rbaBrowserEmailTemplate, rbaBrowserSmsTemplate, rbaCityEmailTemplate, rbaCitySmsTemplate, rbaCountryEmailTemplate, rbaCountrySmsTemplate, rbaIpEmailTemplate, rbaIpSmsTemplate, rbaOneclickEmailTemplate, rbaOTPSmsTemplate, smsTemplate, verificationUrl);
```







### Sott API


List of APIs in this Section:<br>
[GET : Generate SOTT](#GenerateSott-get-)<br>



<h6 id="GenerateSott-get-">Generate SOTT (GET)</h6>
This API allows you to generate SOTT with a given expiration time. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/session/generate-sott-token)



```

var timeDifference = 0; //Optional
var apiResponse = new SottApi().GenerateSott(timeDifference);
```







### NativeSocial API


List of APIs in this Section:<br>
[GET : Access Token via Facebook Token](#GetAccessTokenByFacebookAccessToken-get-)<br>
[GET : Access Token via Twitter Token](#GetAccessTokenByTwitterAccessToken-get-)<br>
[GET : Access Token via Google Token](#GetAccessTokenByGoogleAccessToken-get-)<br>
[GET : Access Token using google JWT token for Native Mobile Login](#GetAccessTokenByGoogleJWTAccessToken-get-)<br>
[GET : Access Token via Linkedin Token](#GetAccessTokenByLinkedinAccessToken-get-)<br>
[GET : Get Access Token By Foursquare Access Token](#GetAccessTokenByFoursquareAccessToken-get-)<br>
[GET : Access Token via Vkontakte Token](#GetAccessTokenByVkontakteAccessToken-get-)<br>
[GET : Access Token via Google AuthCode](#GetAccessTokenByGoogleAuthCode-get-)<br>



<h6 id="GetAccessTokenByFacebookAccessToken-get-">Access Token via Facebook Token (GET)</h6>
The API is used to get LoginRadius access token by sending Facebook's access token. It will be valid for the specific duration of time specified in the response. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-facebook-token/)



```

var fbAccessToken = "fbAccessToken"; //Required
var apiResponse = new NativeSocialApi().GetAccessTokenByFacebookAccessToken(fbAccessToken);
```


<h6 id="GetAccessTokenByTwitterAccessToken-get-">Access Token via Twitter Token (GET)</h6>
The API is used to get LoginRadius access token by sending Twitter's access token. It will be valid for the specific duration of time specified in the response. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-twitter-token)



```

var twAccessToken = "twAccessToken"; //Required
var twTokenSecret = "twTokenSecret"; //Required
var apiResponse = new NativeSocialApi().GetAccessTokenByTwitterAccessToken(twAccessToken, twTokenSecret);
```


<h6 id="GetAccessTokenByGoogleAccessToken-get-">Access Token via Google Token (GET)</h6>
The API is used to get LoginRadius access token by sending Google's access token. It will be valid for the specific duration of time specified in the response. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-google-token)



```

var googleAccessToken = "googleAccessToken"; //Required
var clientId = "clientId"; //Optional
var refreshToken = "refreshToken"; //Optional
var apiResponse = new NativeSocialApi().GetAccessTokenByGoogleAccessToken(googleAccessToken, clientId, refreshToken);
```


<h6 id="GetAccessTokenByGoogleJWTAccessToken-get-">Access Token using google JWT token for Native Mobile Login (GET)</h6>
This API is used to Get LoginRadius Access Token using google jwt id token for google native mobile login/registration. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-googlejwt)



```

var idToken = "idToken"; //Required
var apiResponse = new NativeSocialApi().GetAccessTokenByGoogleJWTAccessToken(idToken);
```


<h6 id="GetAccessTokenByLinkedinAccessToken-get-">Access Token via Linkedin Token (GET)</h6>
The API is used to get LoginRadius access token by sending Linkedin's access token. It will be valid for the specific duration of time specified in the response. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-linkedin-token/)



```

var lnAccessToken = "lnAccessToken"; //Required
var apiResponse = new NativeSocialApi().GetAccessTokenByLinkedinAccessToken(lnAccessToken);
```


<h6 id="GetAccessTokenByFoursquareAccessToken-get-">Get Access Token By Foursquare Access Token (GET)</h6>
The API is used to get LoginRadius access token by sending Foursquare's access token. It will be valid for the specific duration of time specified in the response. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-foursquare-token/)



```

var fsAccessToken = "fsAccessToken"; //Required
var apiResponse = new NativeSocialApi().GetAccessTokenByFoursquareAccessToken(fsAccessToken);
```


<h6 id="GetAccessTokenByVkontakteAccessToken-get-">Access Token via Vkontakte Token (GET)</h6>
The API is used to get LoginRadius access token by sending Vkontakte's access token. It will be valid for the specific duration of time specified in the response. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-vkontakte-token)



```

var vkAccessToken = "vkAccessToken"; //Required
var apiResponse = new NativeSocialApi().GetAccessTokenByVkontakteAccessToken(vkAccessToken);
```


<h6 id="GetAccessTokenByGoogleAuthCode-get-">Access Token via Google AuthCode (GET)</h6>
The API is used to get LoginRadius access token by sending Google's AuthCode. It will be valid for the specific duration of time specified in the response. [More Info](https://www.loginradius.com/docs/api/v2/customer-identity-api/social-login/native-social-login-api/access-token-via-google-auth-code)



```

var googleAuthcode = "googleAuthcode"; //Required
var apiResponse = new NativeSocialApi().GetAccessTokenByGoogleAuthCode(googleAuthcode);
```







### WebHook API


List of APIs in this Section:<br>
[POST : Webhook Subscribe](#WebHookSubscribe-post-)<br>
[GET : Webhook Subscribed URLs](#GetWebHookSubscribedURLs-get-)<br>
[GET : Webhook Test](#WebhookTest-get-)<br>
[DELETE : WebHook Unsubscribe](#WebHookUnsubscribe-delete-)<br>



<h6 id="WebHookSubscribe-post-">Webhook Subscribe (POST)</h6>
API can be used to configure a WebHook on your LoginRadius site. Webhooks also work on subscribe and notification model, subscribe your hook and get a notification. Equivalent to RESThook but these provide security on basis of signature and RESThook work on unique URL. Following are the events that are allowed by LoginRadius to trigger a WebHook service call. [More Info](https://www.loginradius.com/docs/api/v2/integrations/webhooks/webhook-subscribe)



```

WebHookSubscribeModel webHookSubscribeModel = new WebHookSubscribeModel{
Event ="<Event>",
TargetUrl ="<TargetUrl>"
}; //Required
var apiResponse = new WebHookApi().WebHookSubscribe(webHookSubscribeModel);
```


<h6 id="GetWebHookSubscribedURLs-get-">Webhook Subscribed URLs (GET)</h6>
This API is used to fatch all the subscribed URLs, for particular event [More Info](https://www.loginradius.com/docs/api/v2/integrations/webhooks/webhook-subscribed-urls)



```

var @event = "@event"; //Required
var apiResponse = new WebHookApi().GetWebHookSubscribedURLs(@event);
```


<h6 id="WebhookTest-get-">Webhook Test (GET)</h6>
API can be used to test a subscribed WebHook. [More Info](https://www.loginradius.com/docs/api/v2/integrations/webhooks/webhook-test)



```

var apiResponse = new WebHookApi().WebhookTest();
```


<h6 id="WebHookUnsubscribe-delete-">WebHook Unsubscribe (DELETE)</h6>
API can be used to unsubscribe a WebHook configured on your LoginRadius site. [More Info](https://www.loginradius.com/docs/api/v2/integrations/webhooks/webhook-unsubscribe)



```

WebHookSubscribeModel webHookSubscribeModel = new WebHookSubscribeModel{
Event ="<Event>",
TargetUrl ="<TargetUrl>"
}; //Required
var apiResponse = new WebHookApi().WebHookUnsubscribe(webHookSubscribeModel);
```







## Demo
We have configured a sample ASP.net project with extended social profile data, webhook Apis, Account APis. You can get a copy of our demo project at [GitHub](https://github.com/LoginRadius/dot-net-sdk/tree/master/Samples/dot-net-demo).

