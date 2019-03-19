> **LoginRadius .NET SDK Change Log** provides information regarding what has changed, more specifically what changes, improvements and bug fix has been made to the SDK. For more details please refer to the [LoginRadius API Documention](https://docs.loginradius.com/api/v2/sdk-libraries/aspnet)

### Version 5.2.1
Release on **March 19, 2019**

##### Enhancements
  -- Added gzip Accept-Encoding HTTPS header in requests sent to LoginRadius server

### Version 5.2.0
Release on **January 15, 2019**

> **Note: The version contains several breaking changes.**

##### Enhancements

  - SDK has been re-structured to match the structure of the LoginRadius API Docs
  - Several method names have had their spelling errors fixed
  - Demo for the SDK has been updated and is properly functional
  - Update Account in the Account APIs have been updated to include ExternalIds
  - A variable named domainName is now defined in the configurations that allow the user to define a custom API domain
  - The Multifactor re-authentication APIs are now included within the SDK

### Version 5.1.0
Release on **August 13, 2018**

##### Enhancements

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

##### Bug Fixes

  - Fixed http method naming convention issue.
  - Fixed serialization related issue in datetime parsing from .net to javascript.
  
  
### Version 5.0.3
Release on **April 26, 2018**

##### Enhancements

  - Server validation error model add to the "RestException"
  - **username** param add to GetForgotPasswordToken
  - dependency update 

### Version 5.0.2
Release on **Jan 22, 2018**

##### Enhancements

  - Added partial and full replace option to custom object update API.
  
### Version 5.0.1
Release on **Jan 12, 2018**

##### Bug Fixes

  - Parsing issue fixed in custom object API.
  
### Version 5.0.0
Release on **Nov 21, 2017**

> **Note: The version contains several breaking changes.**

##### Enhancements

  - Significantly improved code performance.
  - Project Moved to .NetStandard to target NetFramework and NetCore build or framework. 
  - Run-time config not found exception ignored.
  - New LoginRadius API changes add, includes various APIs and new response properties.  
  - Namespaces and method refactor. 

### Version 4.0.4
Release on **Nov 1, 2017**

##### Enhancements

  - Significantly improved code performance.
  - Added a new LoginRadius JS driven sample project. 
  
##### Bug Fixes

  - Config read fix
  - SOTT build fix

  
### Version 4.0.2
Released on **May 25, 2017**

- Bug Fixes.
- Performance improvement.
- See the documentation [here](https://docs.loginradius.com/api/v2/sdk-libraries/aspnet)


### Version 4.0.1
Released on **May 15, 2017**

- Bug Fixes.


### Version 4.0.0
Released on **May 15, 2017**

##### Enhancements

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


### Version 3.1.1
Released on **June 27,  2016**

##### Enhancements

  - Significantly improved code performance.
  - Added new data fields to LoginRadius user profile.
  - Changed Encoding to UTF8 from ASCII.
  - The API's entity has been classified, classes and namespaces have re-written for the ease of implementation and more relevant naming conventions.
  - LoginRadius cloud APIs added.
  - Some new LoginRadius custom object APIs added.
  - Handled network connection error and failures.

##### Bug Fixes

  - Custom Object Upsert bug fix.
  
  
### Version 3.1.2
Released on **March 15,  2017**

##### Bug Fixes

  - Added missing parameter in register API.
  - Added email verification
