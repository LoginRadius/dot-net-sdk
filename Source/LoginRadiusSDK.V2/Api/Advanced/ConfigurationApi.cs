//-----------------------------------------------------------------------
// <copyright file="ConfigurationApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using LoginRadiusSDK.V2.Common;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects;

namespace LoginRadiusSDK.V2.Api.Advanced
{
    public class ConfigurationApi : LoginRadiusResource
    {
        /// <summary>
        /// This API is used to get the configurations which are set in the LoginRadius Dashboard for a particular LoginRadius site/environment
        /// </summary>
        /// <returns>Response containing LoginRadius App configurations which are set in the LoginRadius Dashboard for a particular LoginRadius site/environment</returns>
        /// 100
        public ApiResponse<ConfigResponseModel> GetConfigurations()
        {
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            var resourcePath = "ciam/appinfo";
            return ConfigureAndExecute<ConfigResponseModel>(HttpMethod.GET, resourcePath, queryParameters, null);
        }

        /// <summary>
        /// This API allows you to query your LoginRadius account for basic server information and server time information which is useful when generating an SOTT token.
        /// </summary>
        /// <param name="timeDifference">The time difference you would like to pass, If you not pass difference then the default value is 10 minutes</param>
        /// <returns>Response containing Definition of Complete service info data</returns>
        /// 3.1

        public ApiResponse<ServiceInfoModel> GetServerInfo(int? timeDifference = null)
        {
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (timeDifference != null)
            {
               queryParameters.Add("timeDifference", timeDifference.ToString());
            }

            var resourcePath = "identity/v2/serverinfo";
            
            return ConfigureAndExecute<ServiceInfoModel>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
    }
}