using System;
using LoginRadiusSDK.Entity;
using LoginRadiusSDK.Utility.Http;

namespace LoginRadiusSDK.API
{
    /// <summary>
    /// The Message API is used to post messages to the user’s contacts. After using the Contact API, you can send messages to the retrieved contacts.
    /// </summary>
    public class MessageApi : ILoginRadiusApi
    {
        readonly HttpClient _client = new HttpClient();

        const string Endpoint = "api/v2/message?access_token={0}";

        private string _to;
        private string _subject;
        private string _message;

        /// <summary>
        /// The details of the message to be send
        /// </summary>
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
            }
        }

        /// <summary>
        /// The subject of the message to be send
        /// </summary>
        public string Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
            }
        }

        /// <summary>
        /// A valid friend id to send the message, it would be fetched from the contacts list
        /// </summary>
        public string To
        {
            get
            {
                return _to;
            }
            set
            {
                _to = value;
            }
        }

        /// <summary>
        /// The Message API is used to post messages to the user’s contacts. After using the Contact API, you can send messages to the retrieved contacts.
        /// </summary>
        /// <param name="token">A valid session token,which is fetch from Access Token API.</param>
        /// <returns></returns>
        public string ExecuteApi(Guid token)
        {
            var url = string.Format(Constants.ApiRootDomain + Endpoint, token);

            var httprequestparameter = new HttpRequestParameter
            {
                {"to", _to},
                {"subject", _subject},
                {"message", _message}
            };

            return _client.Request(url + "&" + httprequestparameter, null, HttpMethod.POST);
        }

        public string ExecuteRawApi(Guid token)
        {
            throw new NotImplementedException();
        }
    }
}
