//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.ResponseModels

{

    /// <summary>
    ///	Response containing Definition of Complete Multi-Factor Authentication Settings data
    /// </summary>
    public class MultiFactorAuthenticationSettingsResponse
    {
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

    }
}