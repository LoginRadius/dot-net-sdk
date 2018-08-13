using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRadiusSDK.V2.Api.Configuration
{
   public class ConfigurationEntity : LoginRadiusResource
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ApiResponse<ConfigurationResponse> GetConfiguration(){
            return ConfigureAndExecute<ConfigurationResponse>(RequestType.Configuration, HttpMethod.GET, null);
        }
    }
}
