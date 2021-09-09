//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels

{

    /// <summary>
    ///	Response containing Definition of Complete Multi-Factor Authentication Settings data
    /// </summary>
    public class MultiFactorAuthenticationSettingsResponse
    {
		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "Email")]
        public  List<string> Email {get;set;}

		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "EmailOTPStatus")]
        public  EmailOtpStatus EmailOTPStatus {get;set;}

		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "IsEmailOtpAuthenticatorVerified")]
        public  bool IsEmailOtpAuthenticatorVerified {get;set;}

		/// <summary>
		///	google authenticator verified or not
		/// </summary>
		[JsonProperty(PropertyName = "IsGoogleAuthenticatorVerified")]
        public  bool IsGoogleAuthenticatorVerified {get;set;}

		/// <summary>
		///	OTP authenticator verified or not
		/// </summary>
		[JsonProperty(PropertyName = "IsOTPAuthenticatorVerified")]
        public  bool IsOTPAuthenticatorVerified {get;set;}

		/// <summary>
		///	
		/// </summary>
		[JsonProperty(PropertyName = "IsSecurityQuestionAuthenticatorVerified")]
        public  bool IsSecurityQuestionAuthenticatorVerified {get;set;}

		/// <summary>
		///	Manual entry code
		/// </summary>
		[JsonProperty(PropertyName = "ManualEntryCode")]
        public  string ManualEntryCode {get;set;}

		/// <summary>
		///	Otp phone number
		/// </summary>
		[JsonProperty(PropertyName = "OTPPhoneNo")]
        public  string OTPPhoneNo {get;set;}

		/// <summary>
		///	OTP status
		/// </summary>
		[JsonProperty(PropertyName = "OTPStatus")]
        public  SMSResponseData OTPStatus {get;set;}

		/// <summary>
		///	QR code
		/// </summary>
		[JsonProperty(PropertyName = "QRCode")]
        public  string QRCode {get;set;}

		/// <summary>
		///	Response containing Definition for Complete SecurityQuestions data
		/// </summary>
		[JsonProperty(PropertyName = "SecurityQuestions")]
        public  List<SecurityQuestions> SecurityQuestions {get;set;}

    }
}