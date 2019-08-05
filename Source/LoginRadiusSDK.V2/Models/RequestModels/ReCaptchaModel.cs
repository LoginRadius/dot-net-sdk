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
    ///	Model Class containing Definition for ReCaptchaBodyModel Property
    /// </summary>
    public class ReCaptchaModel
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

    }
}