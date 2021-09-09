//-----------------------------------------------------------------------
// <copyright file="CustomRegistrationDataApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using LoginRadiusSDK.V2.Common;
using System.Threading.Tasks;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects;
using LoginRadiusSDK.V2.Models.RequestModels;

namespace LoginRadiusSDK.V2.Api.Advanced
{
    public class CustomRegistrationDataApi : LoginRadiusResource
    {
        /// <summary>
        /// This API is used to retrieve dropdown data.
        /// </summary>
        /// <param name="type">Type of the Datasource</param>
        /// <param name="limit">Retrieve number of records at a time(max limit is 50)</param>
        /// <param name="parentId">Id of parent dropdown member(if any).</param>
        /// <param name="skip">Skip number of records from start</param>
        /// <returns>Complete user Registration data</returns>
        /// 7.1

        public async Task<ApiResponse<List<RegistrationDataField>>> AuthGetRegistrationData(string type, int? limit = null,
        string parentId = null, int? skip = null)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(type));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (limit != null)
            {
               queryParameters.Add("limit", limit.ToString());
            }
            if (!string.IsNullOrWhiteSpace(parentId))
            {
               queryParameters.Add("parentId", parentId);
            }
            if (skip != null)
            {
               queryParameters.Add("skip", skip.ToString());
            }

            var resourcePath = $"identity/v2/auth/registrationdata/{type}";
            
            return await ConfigureAndExecute<List<RegistrationDataField>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API allows you to validate code for a particular dropdown member.
        /// </summary>
        /// <param name="code">Secret Code</param>
        /// <param name="recordId">Selected dropdown item’s record id</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 7.2

        public async Task<ApiResponse<PostValidationResponse>> ValidateRegistrationDataCode(string code, string recordId)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(code));
            }
            if (string.IsNullOrWhiteSpace(recordId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(recordId));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var bodyParameters = new BodyParameters
            {
                { "code", code },
                { "recordId", recordId }
            };

            var resourcePath = "identity/v2/auth/registrationdata/validatecode";
            
            return await ConfigureAndExecute<PostValidationResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to retrieve dropdown data.
        /// </summary>
        /// <param name="type">Type of the Datasource</param>
        /// <param name="limit">Retrive number of records at a time(max limit is 50</param>
        /// <param name="parentId">Id of parent dropdown member(if any).</param>
        /// <param name="skip">Skip number of records from start</param>
        /// <returns>Complete user Registration data Fields</returns>
        /// 16.1

        public async Task<ApiResponse<List<RegistrationDataField>>> GetRegistrationData(string type, int? limit = null,
        string parentId = null, int? skip = null)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(type));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };
            if (limit != null)
            {
               queryParameters.Add("limit", limit.ToString());
            }
            if (!string.IsNullOrWhiteSpace(parentId))
            {
               queryParameters.Add("parentId", parentId);
            }
            if (skip != null)
            {
               queryParameters.Add("skip", skip.ToString());
            }

            var resourcePath = $"identity/v2/manage/registrationdata/{type}";
            
            return await ConfigureAndExecute<List<RegistrationDataField>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API allows you to fill data into a dropdown list which you have created for user Registration. For more details on how to use this API please see our Custom Registration Data Overview
        /// </summary>
        /// <param name="registrationDataCreateModelList">Model Class containing Definition of List of Registration Data</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 16.2

        public async Task<ApiResponse<PostResponse>> AddRegistrationData(RegistrationDataCreateModelList registrationDataCreateModelList)
        {
            if (registrationDataCreateModelList == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(registrationDataCreateModelList));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = "identity/v2/manage/registrationdata";
            
            return await ConfigureAndExecute<PostResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(registrationDataCreateModelList));
        }
        /// <summary>
        /// This API allows you to update a dropdown item
        /// </summary>
        /// <param name="registrationDataUpdateModel">Model Class containing Definition of payload for Registration Data update API</param>
        /// <param name="recordId">Registration data RecordId</param>
        /// <returns>Complete user Registration data Field</returns>
        /// 16.3

        public async Task<ApiResponse<UserProfilePostResponse<RegistrationDataField>>> UpdateRegistrationData(RegistrationDataUpdateModel registrationDataUpdateModel, string recordId)
        {
            if (registrationDataUpdateModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(registrationDataUpdateModel));
            }
            if (string.IsNullOrWhiteSpace(recordId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(recordId));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/registrationdata/{recordId}";
            
            return await ConfigureAndExecute<UserProfilePostResponse<RegistrationDataField>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(registrationDataUpdateModel));
        }
        /// <summary>
        /// This API allows you to delete an item from a dropdown list.
        /// </summary>
        /// <param name="recordId">Registration data RecordId</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 16.4

        public async Task<ApiResponse<DeleteResponse>> DeleteRegistrationData(string recordId)
        {
            if (string.IsNullOrWhiteSpace(recordId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(recordId));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/registrationdata/{recordId}";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API allows you to delete all records contained in a datasource.
        /// </summary>
        /// <param name="type">Type of the Datasource</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 16.5

        public async Task<ApiResponse<DeleteResponse>> DeleteAllRecordsByDataSource(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(type));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = $"identity/v2/manage/registrationdata/type/{type}";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, null);
        }
    }
}