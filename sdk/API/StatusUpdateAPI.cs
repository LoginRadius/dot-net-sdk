using System;
using LoginRadius.SDK.Http;

namespace LoginRadius.SDK.API
{
    /// <summary>
    /// The Status API is used to update the status on the user’s wall.
    /// </summary>
    public class StatusUpdateAPI : ILoginRadiusAPI
    {
        HttpClient client = new HttpClient();

        const string Endpoint = "api/v2/status?access_token={0}";

        private string _title;
        private string _url;
        private string _imageurl;
        private string _caption;
        private string _status;
        private string _description;

        /// <summary>
        /// A title for status message.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// A web link of the status message
        /// </summary>
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        /// <summary>
        /// An image URL of the status message
        /// </summary>
        public string Imageurl
        {
            get { return _imageurl; }
            set { _imageurl = value; }
        }

        /// <summary>
        /// The status message text
        /// </summary>
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// A caption of the status message
        /// </summary>
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        /// <summary>
        /// A description of the status message
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// The Status API is used to update the status on the user’s wall.
        /// </summary>
        /// <param name="token">A valid session token,which is fetch from Access Token API.</param>
        /// <returns></returns>
        public string ExecuteAPI(Guid token)
        {
            string url = string.Format(Constants.APIRootDomain + Endpoint, token);

            HttpRequestParameter httprequestparameter = new HttpRequestParameter();
            httprequestparameter.Add("title", _title);
            httprequestparameter.Add("url", _url);
            httprequestparameter.Add("imageurl", _imageurl);
            httprequestparameter.Add("status", _status);
            httprequestparameter.Add("caption", _caption);
            httprequestparameter.Add("description", _description);
            
            return client.Request(url + "&" +httprequestparameter.ToString()  , null, HttpMethod.POST);
        }

        /// <summary>
        /// No documentation available.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public string ExecuteRawAPI(Guid token)
        {
            throw new NotImplementedException();
        }
    }
}
