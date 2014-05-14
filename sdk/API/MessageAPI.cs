using System;
using LoginRadius.SDK.Http;

namespace LoginRadius.SDK.API
{
    /// <summary>
    /// The Message API is used to post messages to the user’s contacts. After using the Contact API, you can send messages to the retrieved contacts.
    /// </summary>
    public class MessageAPI : ILoginRadiusAPI
    {
        HttpClient client = new HttpClient();

        const string Endpoint = "api/v2/message?access_token={0}";

        private string _To;
        private string _Subject;
        private string _Message;

        /// <summary>
        /// The details of the message to be send
        /// </summary>
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        /// <summary>
        /// The subject of the message to be send
        /// </summary>
        public string Subject
        {
            get
            {
                return _Subject;
            }
            set
            {
                _Subject = value;
            }
        }

        /// <summary>
        /// A valid friend id to send the message, it would be fetched from the contacts list
        /// </summary>
        public string To
        {
            get
            {
                return _To;
            }
            set
            {
                _To = value;
            }
        }

        /// <summary>
        /// The Message API is used to post messages to the user’s contacts. After using the Contact API, you can send messages to the retrieved contacts.
        /// </summary>
        /// <param name="token">A valid session token,which is fetch from Access Token API.</param>
        /// <returns></returns>
        public string ExecuteAPI(Guid token)
        {
            string url = string.Format(Constants.APIRootDomain + Endpoint, token);

            HttpRequestParameter httprequestparameter = new HttpRequestParameter();
            httprequestparameter.Add("to", _To);
            httprequestparameter.Add("subject", _Subject);
            httprequestparameter.Add("message", _Message);

            return client.Request(url + "&" + httprequestparameter.ToString(), null, HttpMethod.POST);
        }

        public string ExecuteRawAPI(Guid token)
        {
            throw new NotImplementedException();
        }
    }
}
