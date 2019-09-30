using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
#if !NET_40
using System.Net.Http;
#endif
using LoginRadiusSDK.V2.Exception;

namespace LoginRadiusSDK.V2
{
    /// <summary>
    ///  ConnectionManager retrieves HttpConnection objects used by API service
    /// </summary>
    public sealed class ConnectionManager
    {
        /// <summary>
        /// System.Lazy type guarantees thread-safe lazy-construction
        /// static holder for instance, need to use lambda to construct since constructor private
        /// </summary>
        private static readonly Lazy<ConnectionManager> LazyConnectionManager =
            new Lazy<ConnectionManager>(() => new ConnectionManager());

        /// <summary>
        /// Accessor for the Singleton instance of ConnectionManager
        /// </summary>
        public static ConnectionManager Instance => LazyConnectionManager.Value;

        /// <summary>
        /// Create and Config a HttpWebRequest
        /// </summary>
        /// <param name="config">Config properties</param>
        /// <param name="url">Url to connect to</param>
        /// <param name="headers"></param>
        /// <param name="authHeaders"></param>
        /// <returns></returns>
        public HttpWebRequest GetConnection(ConcurrentDictionary<string, string> config, string url, Dictionary<string, string> headers = null,
            Dictionary<string, string> authHeaders = null)
        {
            HttpWebRequest httpRequest;
            try
            {
                httpRequest = (HttpWebRequest)WebRequest.Create(url);
            }
            catch (UriFormatException)
            {
                throw new ConfigException("Invalid URI: " + url);
            }

            // Set connection timeout
            if (!config.ContainsKey(LRConfigConstants.HttpConnectionTimeoutConfig) || !int.TryParse(config[LRConfigConstants.HttpConnectionTimeoutConfig], out int connectionTimeout))
            {
                int.TryParse(ConfigManager.GetDefault(LRConfigConstants.HttpConnectionTimeoutConfig),
                    out connectionTimeout);
            }

#if !NETSTANDARD1_3
            httpRequest.Timeout = connectionTimeout;

            // Set request proxy for tunnelling http requests via a proxy server
            Uri proxyUri;
            if (config.ContainsKey(LRConfigConstants.HttpProxyAddressConfig) &&
                !string.IsNullOrWhiteSpace(config[LRConfigConstants.HttpProxyAddressConfig]) &&
                Uri.TryCreate(config[LRConfigConstants.HttpProxyAddressConfig], UriKind.Absolute, out proxyUri))
            {
                WebProxy requestProxy = new WebProxy {Address = new Uri(config[LRConfigConstants.HttpProxyAddressConfig])};
                if (config.ContainsKey(LRConfigConstants.HttpProxyCredentialConfig) && !string.IsNullOrWhiteSpace(config[LRConfigConstants.HttpProxyCredentialConfig]))
                {
                    string proxyCredentials = config[LRConfigConstants.HttpProxyCredentialConfig];
                    string[] proxyDetails = proxyCredentials.Split(':');
                    if (proxyDetails.Length == 2)
                    {
                        requestProxy.Credentials = new NetworkCredential(proxyDetails[0], proxyDetails[1]);
                    }else{
            requestProxy.Credentials = new NetworkCredential(proxyDetails[0],"");
           
                }
            }
                httpRequest.Proxy = requestProxy;
            }
#endif
            if (authHeaders != null && authHeaders.Any())
            {
                foreach (var authHeader in authHeaders)
                {
                    httpRequest.Headers[authHeader.Key] = authHeader.Value;
                }
            }

            if (headers != null && headers.Any())
            {
                foreach (var header in headers)
                {
                    httpRequest.Headers[header.Key] = header.Value;
                }
            }

#if NetFramework
            // Don't set the Expect: 100-continue header as it's not supported and can negatively impact performance.
            httpRequest.ServicePoint.Expect100Continue = false;
#endif

            return httpRequest;
        }
    }
}