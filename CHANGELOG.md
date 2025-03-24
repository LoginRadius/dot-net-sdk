> **LoginRadius .NET SDK Change Log** provides information regarding what has changed, more specifically what changes, improvements and bug fix has been made to the SDK. For more details please refer to the [LoginRadius API Documention](https://docs.loginradius.com/api/v2/sdk-libraries/aspnet)


# Version 11.7.0

**Release Date:** March 24, 2025

## Enhancements

We've introduced a brand-new set of Webhook APIs, designed with enhanced functionality and flexibility. These new APIs support advanced features including:

- Custom header configuration  
- Query parameter support  
- Webhook authentication methods (Bearer Token and Basic Auth)  
- Support for a custom `Name` parameter to label each webhook subscription

As part of this upgrade, the legacy Webhook APIs have been deprecated in favor of the new, more robust versions.

## Newly Added APIs

- `GetWebhookSubscriptionDetail` – Retrieve detailed information about a specific webhook subscription  
- `CreateWebhookSubscription` – Create a new webhook subscription with advanced configuration options  
- `DeleteWebhookSubscription` – Remove an existing webhook subscription  
- `UpdateWebhookSubscription` – Modify an existing webhook subscription  
- `ListAllWebhooks` – Retrieve a list of all configured webhook subscriptions  
- `GetWebhookEvents` – Fetch available webhook events supported by the system  

## Deprecated APIs

The following legacy APIs have been deprecated:

- `webHookUnsubscribe`  
- `WebhookTest`  
- `WebHookSubscribe`  
- `getWebHookSubscribedURLs`  

# Version 11.6.0

Release on **July 02, 2024**

## Added following APIs:
- `MFAValidateAuthenticatorCode`
- `MFAVerifyAuthenticatorCode`
- `RevokeAllRefreshToken `
- `MultipurposeEmailTokenGeneration`
- `MultipurposeSMSOTPGeneration`
- `MFAReAuthenticateByAuthenticatorCode`
- `AuthSendVerificationEmailForLinkingSocialProfiles `
- `SlidingAccessToken`
- `AccessTokenViaCustomJWTToken`
- `MFAResetAuthenticatorByToken`
- `MFAResetAuthenticatorByUid`

## Enhancements
- Added `isVoiceOtp` parameter in `ResetPhoneIDVerificationByUid` API
- Added `isVoiceOtp` parameter in `MFAConfigureByAccessToken` API
- Added `isVoiceOtp` and `options` parameter in `MFAUpdatePhoneNumberByToken` API
- Added `isVoiceOtp`, `emailTemplate2FA` and `options` parameter in `MFALoginByEmail` API
- Added `isVoiceOtp` and `emailTemplate2FA` parameter in `MFALoginByUserName` API
- Added `isVoiceOtp` , `emailTemplate2FA` and `options` parameter in `MFALoginByPhone` API
- Added `isVoiceOtp` and `options` parameter in `MFAUpdatePhoneNumber` API
- Added `isVoiceOtp` parameter in `MFAResendOTP` API
- Added `isVoiceOtp` parameter in `MFAReAuthenticate` API
- Added `isVoiceOtp` and `options` parameter in `UpdateProfileByAccessToken` API
- Added `isVoiceOtp` parameter in `UserRegistrationByEmail` API
- Added `isVoiceOtp` parameter in `UserRegistrationByCaptcha` API
- Added `isVoiceOtp` parameter in `OneTouchLoginByPhone` API
- Added `isVoiceOtp` parameter in `PasswordlessLoginPhoneVerification` API
- Added `isVoiceOtp` parameter in `PasswordlessLoginByPhone` API
- Added `isVoiceOtp` parameter in `ForgotPasswordByPhoneOTP` API
- Added `isVoiceOtp` parameter in `PhoneVerificationByOTP` API
- Added `isVoiceOtp` parameter in `PhoneVerificationOTPByAccessToken` API
- Added `isVoiceOtp` parameter in `PhoneResendVerificationOTP` API
- Added `isVoiceOtp` parameter in `UpdatePhoneNumber` API
- Added `isVoiceOtp` and `emailTemplate` parameter in `UserRegistrationByPhone` API
- Added `isVoiceOtp` parameter in `SendForgotPINSMSByPhone` API
- Added `uuid` parameter in `VerifyEmail` API

## Removed the following parameter

-`smsTemplate2FA` parameter in `MFAConfigureByAccessToken` API



## Removed (Deprecated) APIs:
- `MFAValidateGoogleAuthCode`
- `MFAReAuthenticateByGoogleAuth`
- `MFAResetGoogleAuthByToken `
- `MFAResetGoogleAuthenticatorByUid`
- `MFAUpdateByAccessToken`


# Version 11.5.0

Release on **January 23, 2023**


## Enhancements
- Added `emailTemplate` parameter in `UserRegistrationByPhone` Api

## Removed (Deprecated) APIs:
- `AuthGetRegistrationData`
- `ValidateRegistrationDataCode`
- `GetRegistrationData`
- `AddRegistrationData`
- `UpdateRegistrationData`
- `DeleteRegistrationData`
- `DeleteAllRecordsByDataSource`
- `GetAccessTokenByVkontakteAccessToken`
- `GetAlbum`
- `GetAlbumsWithCursor`
- `GetAudios`
- `GetAudiosWithCursor`
- `GetCheckIns`
- `GetCheckInsWithCursor`
- `GetContacts`
- `GetEvents`
- `GetEventsWithCursor`
- `GetFollowings`
- `GetFollowingsWithCursor`
- `GetGroups`
- `GetGroupsWithCursor`
- `GetLikes`
- `GetLikesWithCursor`
- `GetMentions`
- `PostMessage`
- `GetPage`
- `GetPhotos`
- `GetPosts`
- `StatusPosting`
- `TrackableStatusPosting`
- `GetTrackableStatusStats`
- `TrackableStatusFetching`
- `GetVideos`
- `GetRefreshedSocialUserProfile`

# Version 11.4.1

Release on **August 04, 2022**

## Enhancements

- Updated Newtonsoft.Json library 12.0.2 to 13.0.1

# Version 11.4.0

Release on **June 01, 2022**

## Enhancements

- Added additional parameter `TimeDifference` & `getLrServerTime` in `GetSott` function.
- Enhancement in `README.md` file.

# Version 11.3.0

Release on **January 28, 2022**

## Enhancements

- Added a feature to add ApiKey and ApiSecret directly in LoginRadius manual SOTT generation method.
- Code optimization for better performance.
- Improved the Exception handling for various connection-related exceptions. 
- Added Licence and Contribution Guideline files.

## Breaking Changes

For developers migrating from v11.2.0, there will be 1 minor breaking change in terms of SDK implementation. In this version, we have added a feature to add ApiKey & ApiSecret directly into the manual SOTT generation method `GetSott()`.

# Version 11.2.0

Release on **September 7, 2021**

## Enhancements
- Minor code refactor.
- Support for appsettings.Environment.json : For example, the appsettings.Production.json and appsettings.Development.json files. The environment version of the file is loaded based on the IHostingEnvironment.EnvironmentName.
- Added X-Origin-IP header support.
- Added 429 error code handling for "Too Many Request in a particular time frame".
- Updated Jquery with latest version(3.6.0) in SDK Demo

## Added new multiple APIs for better user experience
- MFAEmailOtpByAccessToken
- MFAValidateEmailOtpByAccessToken
- MFAResetEmailOtpAuthenticatorByAccessToken
- MFASecurityQuestionAnswerByAccessToken
- MFAResetSecurityQuestionAuthenticatorByAccessToken
- MFAEmailOTP
- MFAValidateEmailOtp
- MFASecurityQuestionAnswer
- MFASecurityQuestionAnswerVerification
- MFAResetEmailOtpAuthenticatorByUid
- MFAResetSecurityQuestionAuthenticatorByUid
- ReAuthValidateEmailOtp
- ReAuthSendEmailOtp
- ReAuthBySecurityQuestion
- PasswordlessLoginVerificationByUserNameAndOTP
- PasswordlessLoginVerificationByEmailAndOTP
- GetProfileByPing
- GetAccessTokenByWeChatCode
- GetAccessTokenByAppleIdCode
- LinkSocialIdentitiesByPing (POST)
- linkSocialIdentities(POST)

## Removed APIs:

- GetSocialUserProfile
- linkSocialIdentity (PUT)
- getSocialIdentity (GET)

#### Added `EmailTemplate2FA` parameter in the following API 
- MFALoginByEmail
- MFALoginByUserName
- MFALoginByPhone

#### Added 	`RbaBrowserEmailTemplate`, `RbaCityEmailTemplate` ,`RbaCountryEmailTemplate` , `RbaIpEmailTemplate` parameter in the following API 
- MFAValidateOTPByPhone
- MFAValidateGoogleAuthCode
- MFAValidateBackupCode

#### Added 	`emailTemplate`, `verificationUrl` ,`welcomeEmailTemplate`  parameter in the following API 

- GetProfileByAccessToken

## Removed `smsTemplate2FA`  parameter from the following API

- mfaValidateGoogleAuthCode

#### Added 	`isWeb`  parameter in the following API 
- RefreshAccessToken

#### Added 	`socialAppName`  parameter in the following Native Social Login API 
- GetAccessTokenByFacebookAccessToken
- GetAccessTokenByTwitterAccessToken
- GetAccessTokenByGoogleAccessToken
- GetAccessTokenByLinkedinAccessToken
- GetAccessTokenByAppleIdCode
- GetAccessTokenByGoogleAuthCode

# Version 11.0.0
Release on **March 05, 2021**

## Enhancements

- Updated all API Method in async/await to solving thread performance or scalability problems.
- Added new JWT Token Validate Method in SDK.

# Version 10.0.0
Release on **September 30, 2019**

## Enhancements
This full version release includes major changes with several improvements and optimizations :

- Enhanced the coding standards of SDK to follow industry programming styles and best practices.
- Enhanced security standards of SDK.
- Reduced code between the business layer and persistence layer for optimization of SDK performance.
- Added internal parameter validations in the API function.
- ApiKey and ApiSecret usage redundancy removed.
- All LoginRadius related features need to be defined once only and SDK will handle them automatically.
- Improved the naming conventions of API functions for better readability.
- Better Error and Exception Handling for LoginRadius API Response in SDK.
- Revamped complete SDK and restructured it with latest API function names and parameters.
- Added detailed description to API functions and parameters for better understanding.
- Updated the demo according to latest SDK changes.
- Implemented API Region Feature.
- Handled additional Data coming in error response of API.
- Handled Password less proxy credentials settings.
- Strong Name Signed the library.


## Added new multiple APIs for better user experience

 - Update Phone ID by UID
 - Upsert Email
 - Role Context profile
 - MFA Resend OTP
 - User Registration By Captcha
 - Get Access Token via Linkedin Token
 - Get Access Token By Foursquare Access Token
 - Get Active Session By Account Id
 - Get Active Session By Profile Id
 - Delete User Profiles By Email
 - Verify Multifactor OTP Authentication
 - Verify Multifactor Password Authentication
 - Verify Multifactor PIN Authentication
 - Update UID
 - MFA Re-authentication by PIN
 - Pin Login
 - Forgot Pin By Email
 - Forgot Pin By UserName
 - Reset PIN By ResetToken
 - Reset PIN By SecurityAnswer And Email
 - Reset PIN By SecurityAnswer And Username
 - Reset PIN By SecurityAnswer And Phone
 - Forgot Pin By Phone
 - Change Pin By Token
 - Reset PIN by Phone and OTP
 - Reset PIN by Email and OTP
 - Reset PIN by Username and OTP
 - Set Pin By PinAuthToken
 - Invalidate Pin Session Token
 - Submit Consent By ConsentToken
 - Get Consent Logs
 - Submit Consent By AccessToken
 - Verify Consent By AccessToken
 - Update Consent Profile By AccessToken
 - Get Consent Logs By Uid
 - Album With Cursor
 - Audio With Cursor
 - Check In With Cursor
 - Event With Cursor
 - Following With Cursor
 - Group With Cursor
 - Like With Cursor


## Removed APIs:

- GetCompanies API
- Getstatus API

# Version 10.0.0-beta
Release on **August 5, 2019**

## Enhancements
This beta version release includes major changes with several improvements and optimizations :

- Enhanced the coding standards of SDK to follow industry programming styles and best practices.
- Enhanced security standards of SDK.
- Reduced code between the business layer and persistence layer for optimization of SDK performance.
- Added internal parameter validations in the API function.
- ApiKey and ApiSecret usage redundancy removed.
- All LoginRadius related features need to be defined once only and SDK will handle them automatically.
- Improved the naming conventions of API functions for better readability.
- Better Error and Exception Handling for LoginRadius API Response in SDK.
- Revamped complete SDK and restructured it with latest API function names and parameters.
- Added detailed description to API functions and parameters for better understanding.
- Updated the demo according to latest SDK changes.
- Implemented API Region Feature.


## Added new multiple APIs for better user experience

- Update Phone ID by UID
- Upsert Email
- Role Context profile
- MFA Resend OTP
- User Registration By Captcha
- Get Access Token via Linkedin Token
- Get Access Token By Foursquare Access Token
- Get Active Session By Account Id
- Get Active Session By Profile Id


## Removed APIs:

- GetCompanies API

# Version 5.2.0
Release on **January 15, 2019**

> **Note: The version contains several breaking changes.**

## Enhancements

  - SDK has been re-structured to match the structure of the LoginRadius API Docs
  - Several method names have had their spelling errors fixed
  - Demo for the SDK has been updated and is properly functional
  - Update Account in the Account APIs have been updated to include ExternalIds
  - A variable named domainName is now defined in the configurations that allow the user to define a custom API domain
  - The Multifactor re-authentication APIs are now included within the SDK

# Version 5.1.0
Release on **August 13, 2018**

## Enhancements

  - Added Access Token on Registration Event.
  - Simplified API Request Signing without API secret.
  - Request Access Token Pass in Header.
  - Added option to Prevent Sending Email Verification.
  - API Route Changes for better naming.
  - Enforce Recaptcha for Auth APIs.
  - Added Otp Lockout feature.
  - Updating Demos with LoginSurface for login/Registration.
  - Added new multiple APIs for better user experience.
  - Added api to Remove Phone ID by access token.
  - Added auth api to verify email and reset password by OTP.
  - Added api Account Identities by Email.
  - Added api to get sott from server.
  - Added api to add, get, delete and update registration data.
  - Validate secret code api is added.
  - Added auth apis to login by email, username and phone using POST method.
  - Added auth apis to Reset password by security answer and username/email/phone.
  - Get Configurations api is added.
  - One touch Login apis by email and OTP are added.
  - One touch OTP Verification api is also added.
  - Smart Login by Email/Username/Ping and verify token apis are added.
  - Passwordless login by email,username and verification apis are added.
  - Added apis for phone login using OTP and to send OTP.
  - Added apis to update MFA settings and MFA Authentication by Access token and to verify MFA by backup code.
  - Apis to validate MFA by Google authentication code, OTP, Backup code and password are added.

## Bug Fixes

  - Fixed http method naming convention issue.
  - Fixed serialization related issue in datetime parsing from .net to javascript.
  
  
# Version 5.0.3
Release on **April 26, 2018**

## Enhancements

  - Server validation error model add to the "RestException"
  - **username** param add to GetForgotPasswordToken
  - dependency update 

# Version 5.0.2
Release on **Jan 22, 2018**

## Enhancements

  - Added partial and full replace option to custom object update API.
  
# Version 5.0.1
Release on **Jan 12, 2018**

## Bug Fixes

  - Parsing issue fixed in custom object API.
  
# Version 5.0.0
Release on **Nov 21, 2017**

> **Note: The version contains several breaking changes.**

## Enhancements

  - Significantly improved code performance.
  - Project Moved to .NetStandard to target NetFramework and NetCore build or framework. 
  - Run-time config not found exception ignored.
  - New LoginRadius API changes add, includes various APIs and new response properties.  
  - Namespaces and method refactor. 

# Version 4.0.4
Release on **Nov 1, 2017**

## Enhancements

  - Significantly improved code performance.
  - Added a new LoginRadius JS driven sample project. 
  
## Bug Fixes

  - Config read fix
  - SOTT build fix

  
# Version 4.0.2
Released on **May 25, 2017**

- Bug Fixes.
- Performance improvement.
- See the documentation [here](https://docs.loginradius.com/api/v2/sdk-libraries/aspnet)


# Version 4.0.1
Released on **May 15, 2017**

- Bug Fixes.


# Version 4.0.0
Released on **May 15, 2017**

## Enhancements

Updated with V2 APIs
- Added new multiple APIs for better user experience.
- Improved structure and naming convention
- Improved security feature
- Added Phone Authentication APIs to handle phone login,registration and verification etc.
- Added APIs for two factore authentication
- Added web hook APIs
- Add start and end time for SOTT to validate it for long time frame.
- Add API to get server time for SOTT if don't pass the start and end time.
- Improved SOTT feature.
- Add Email prompt auto login APIs.
- Add Role Context and additional permission APIs


# Version 3.1.1
Released on **June 27,  2016**

## Enhancements

  - Significantly improved code performance.
  - Added new data fields to LoginRadius user profile.
  - Changed Encoding to UTF8 from ASCII.
  - The API's entity has been classified, classes and namespaces have re-written for the ease of implementation and more relevant naming conventions.
  - LoginRadius cloud APIs added.
  - Some new LoginRadius custom object APIs added.
  - Handled network connection error and failures.

## Bug Fixes

  - Custom Object Upsert bug fix.
  
  
# Version 3.1.2
Released on **March 15,  2017**

## Bug Fixes

  - Added missing parameter in register API.
  - Added email verification
