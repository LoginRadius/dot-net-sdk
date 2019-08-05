//-----------------------------------------------------------------------
// <copyright file="ModelClass" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
namespace LoginRadiusSDK.V2.Models.RequestModels

{

    /// <summary>
    ///	Model Class containing Definition of payload for Auth User Registration by Recaptcha API
    /// </summary>
    public class AuthUserRegistrationModelWithCaptcha:AuthUserRegistrationModel
    {
		/// <summary>
		///	The acknowledgement received by Google in Google recaptcha authorisation process.
		/// </summary>
		[JsonProperty(PropertyName = "g-recaptcha-response")]
        public  string G_recaptcha_response {get;set;}

		/// <summary>
		///	the value of the user's random string retrieved from the QQ captcha
		/// </summary>
		[JsonProperty(PropertyName = "qq_captcha_randstr")]
        public  string Qq_captcha_randstr {get;set;}

		/// <summary>
		///	QQ Captcha ticket received from QQ in the QQ Captcha authorization process
		/// </summary>
		[JsonProperty(PropertyName = "qq_captcha_ticket")]
        public  string Qq_captcha_ticket {get;set;}

		/// <summary>
		///	V1 recaptcha field (optional in case of V2 recaptcha)
		/// </summary>
		[JsonProperty(PropertyName = "recaptcha_challenge_field")]
        public  string Recaptcha_challenge_field {get;set;}

		/// <summary>
		///	V1 recaptcha field (optional in case of V2 recaptcha)
		/// </summary>
		[JsonProperty(PropertyName = "recaptcha_response_field")]
        public  string Recaptcha_response_field {get;set;}

    }
}