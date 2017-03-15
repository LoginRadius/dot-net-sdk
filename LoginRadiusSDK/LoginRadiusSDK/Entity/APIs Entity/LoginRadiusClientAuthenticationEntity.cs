using System.Collections;
using LoginRadiusSDK.Utility.Serialization;
using LoginRadiusSDK.Utility.Http;
using LoginRadiusSDK.Models;
using LoginRadiusSDK.Utility;

namespace LoginRadiusSDK.Entity
{
    public class LoginRadiusClientAuthenticationEntity : LoginRadiusClientEntity
    {
        private readonly LoginRadiusObject _object = new LoginRadiusObject("auth");
        private readonly LoginRadiusArgumentValidator _validate = new LoginRadiusArgumentValidator();
        private ArrayList _valuesToCheck;

        public LoginRadiusClientAuthenticationEntity()
        {
        }
        public LoginRadiusClientAuthenticationEntity(string apikey)
            : base(apikey)
        {
        }

        /// <summary>
        /// Method to verify the email of user. 
        /// </summary>
        /// <param name="vtoken">Uniquely generated identifier key by LoginRadius.</param>
        /// <param name="url">URL on which page user landed</param>
        /// <param name="welcomeEmailTemplate">Name of email template</param>
        public LoginRadiusPostResponse VerifyEmail(string vtoken, string url, string welcomeEmailTemplate)
        {
            _valuesToCheck = new ArrayList { vtoken, url };
            _validate.Validate(_valuesToCheck, "Verify Email");
            var getRequest = new HttpRequestParameter
            {
                { "vtoken", vtoken }, { "url", url }
            };
            if (!string.IsNullOrWhiteSpace(welcomeEmailTemplate))
            {
                getRequest.Add("welcomeEmailTemplate", welcomeEmailTemplate);
            }
            var response = Get(_object.ChildObject("verifyemail"), getRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }
    }
}