using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.Configuration;
using LoginRadiusSDK.V2.Util;

namespace LoginRadiusSDK.V2.Api
{
    public class ConfigurationApi : LoginRadiusResource
    {
        /// <summary>
        /// Gets LoginRadius configuration information, dashboard data and other useful information for your current LoginRadius workflows.
        /// </summary>
        /// <returns>ConfigurationResponse: An object containing fields of configuration data.</returns>
        public ApiResponse<ConfigurationResponse> GetConfiguration()
        {
            return ConfigureAndExecute<ConfigurationResponse>(RequestType.Configuration, HttpMethod.GET, null);
        }

        /// <summary>
        /// Gets the current server time.
        /// </summary>
        /// <returns>SottDetails contains server time and location information, along with sott information when using the returned data to create a sott.</returns>
        public ApiResponse<SottDetails> GetServerTime(string timeDifference)
        {
            var additionalQueryParams = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(timeDifference))
                additionalQueryParams.Add("timedifference", timeDifference);
            return ConfigureAndExecute<SottDetails>(RequestType.ServerInfo, HttpMethod.GET, null, additionalQueryParams);
        }

        /// <summary>
        /// Generates a sott.
        /// </summary>
        /// <returns>SottResponseData: Data for a sott.</returns>
        public ApiResponse<SottResponseData> GenerateSott(string timeDifference)
        {
            var additionalQueryParams = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(timeDifference))
                additionalQueryParams.Add("timedifference", timeDifference);
            return ConfigureAndExecute<SottResponseData>(RequestType.Identity, HttpMethod.GET, "sott", additionalQueryParams);
        }

        /// <summary>
        /// Gets the current session details with the access token.
        /// </summary>
        /// <param name="accessToken">Session token associated with a LoginRadius account.</param>
        /// <returns>ActiveSessionDetails: Object containing information on the current session.</returns>
        public ApiResponse<ActiveSessionDetails> GetActiveSessionDetails(string accessToken)
        {
            LoginRadiusArgumentValidator.Validate(new[] { accessToken });
            var additionalQueryParams = new QueryParameters { ["token"] = accessToken };
            return ConfigureAndExecute<ActiveSessionDetails>(RequestType.AdvancedSocial, HttpMethod.GET,
                "access_token/activesession", additionalQueryParams);
        }
    }
}
