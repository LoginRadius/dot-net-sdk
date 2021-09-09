//-----------------------------------------------------------------------
// <copyright file="CustomObjectApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LoginRadiusSDK.V2.Common;
using System.Threading.Tasks;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels;
using LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects;
using LoginRadiusSDK.V2.Models.Enums;

namespace LoginRadiusSDK.V2.Api.Advanced
{
    public class CustomObjectApi : LoginRadiusResource
    {
        /// <summary>
        /// This API is used to write information in JSON format to the custom object for the specified account.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="objectName">LoginRadius Custom Object Name</param>
        /// <param name="payload">LoginRadius Custom Object Name</param>
        /// <returns>Response containing Definition for Complete user custom object data</returns>
        /// 6.1

        public async Task<ApiResponse<UserCustomObjectData>> CreateCustomObjectByToken(string accessToken, string objectName,
        object payload)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(objectName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(objectName));
            }
            if (payload == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(payload));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "objectName", objectName }
            };

            var resourcePath = "identity/v2/auth/customobject";
            
            return await ConfigureAndExecute<UserCustomObjectData>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(payload));
        }
        /// <summary>
        /// This API is used to update the specified custom object data of the specified account. If the value of updatetype is 'replace' then it will fully replace custom object with the new custom object and if the value of updatetype is 'partialreplace' then it will perform an upsert type operation
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="objectName">LoginRadius Custom Object Name</param>
        /// <param name="objectRecordId">Unique identifier of the user's record in Custom Object</param>
        /// <param name="payload">LoginRadius Custom Object Name</param>
        /// <param name="updateType">Possible values: replace, partialreplace.</param>
        /// <returns>Response containing Definition for Complete user custom object data</returns>
        /// 6.2

        public async Task<ApiResponse<UserCustomObjectData>> UpdateCustomObjectByToken(string accessToken, string objectName,
        string objectRecordId, object payload, CustomObjectUpdateOperationType? updateType = null)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(objectName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(objectName));
            }
            if (string.IsNullOrWhiteSpace(objectRecordId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(objectRecordId));
            }
            if (payload == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(payload));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "objectName", objectName }
            };
            if (updateType != null)
            {
               queryParameters.Add("updateType", updateType.ToString());
            }

            var resourcePath = $"identity/v2/auth/customobject/{objectRecordId}";
            
            return await ConfigureAndExecute<UserCustomObjectData>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(payload));
        }
        /// <summary>
        /// This API is used to retrieve the specified Custom Object data for the specified account.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="objectName">LoginRadius Custom Object Name</param>
        /// <returns>Complete user CustomObject data</returns>
        /// 6.3

        public async Task<ApiResponse<ListData<UserCustomObjectData>>> GetCustomObjectByToken(string accessToken, string objectName)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(objectName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(objectName));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "objectName", objectName }
            };

            var resourcePath = "identity/v2/auth/customobject";
            
            return await ConfigureAndExecute<ListData<UserCustomObjectData>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to retrieve the Custom Object data for the specified account.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="objectName">LoginRadius Custom Object Name</param>
        /// <param name="objectRecordId">Unique identifier of the user's record in Custom Object</param>
        /// <returns>Response containing Definition for Complete user custom object data</returns>
        /// 6.4

        public async Task<ApiResponse<UserCustomObjectData>> GetCustomObjectByRecordIDAndToken(string accessToken, string objectName,
        string objectRecordId)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(objectName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(objectName));
            }
            if (string.IsNullOrWhiteSpace(objectRecordId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(objectRecordId));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "objectName", objectName }
            };

            var resourcePath = $"identity/v2/auth/customobject/{objectRecordId}";
            
            return await ConfigureAndExecute<UserCustomObjectData>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to remove the specified Custom Object data using ObjectRecordId of a specified account.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="objectName">LoginRadius Custom Object Name</param>
        /// <param name="objectRecordId">Unique identifier of the user's record in Custom Object</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 6.5

        public async Task<ApiResponse<DeleteResponse>> DeleteCustomObjectByToken(string accessToken, string objectName,
        string objectRecordId)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(objectName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(objectName));
            }
            if (string.IsNullOrWhiteSpace(objectRecordId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(objectRecordId));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "objectName", objectName }
            };

            var resourcePath = $"identity/v2/auth/customobject/{objectRecordId}";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to write information in JSON format to the custom object for the specified account.
        /// </summary>
        /// <param name="objectName">LoginRadius Custom Object Name</param>
        /// <param name="payload">LoginRadius Custom Object Name</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition for Complete user custom object data</returns>
        /// 19.1

        public async Task<ApiResponse<UserCustomObjectData>> CreateCustomObjectByUid(string objectName, object payload,
        string uid)
        {
            if (string.IsNullOrWhiteSpace(objectName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(objectName));
            }
            if (payload == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(payload));
            }
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "objectName", objectName }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/customobject";
            
            return await ConfigureAndExecute<UserCustomObjectData>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(payload));
        }
        /// <summary>
        /// This API is used to update the specified custom object data of a specified account. If the value of updatetype is 'replace' then it will fully replace custom object with new custom object and if the value of updatetype is partialreplace then it will perform an upsert type operation.
        /// </summary>
        /// <param name="objectName">LoginRadius Custom Object Name</param>
        /// <param name="objectRecordId">Unique identifier of the user's record in Custom Object</param>
        /// <param name="payload">LoginRadius Custom Object Name</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <param name="updateType">Possible values: replace, partialreplace.</param>
        /// <returns>Response containing Definition for Complete user custom object data</returns>
        /// 19.2

        public async Task<ApiResponse<UserCustomObjectData>> UpdateCustomObjectByUid(string objectName, string objectRecordId,
        object payload, string uid, CustomObjectUpdateOperationType? updateType = null)
        {
            if (string.IsNullOrWhiteSpace(objectName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(objectName));
            }
            if (string.IsNullOrWhiteSpace(objectRecordId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(objectRecordId));
            }
            if (payload == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(payload));
            }
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "objectName", objectName }
            };
            if (updateType != null)
            {
               queryParameters.Add("updateType", updateType.ToString());
            }

            var resourcePath = $"identity/v2/manage/account/{uid}/customobject/{objectRecordId}";
            
            return await ConfigureAndExecute<UserCustomObjectData>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(payload));
        }
        /// <summary>
        /// This API is used to retrieve all the custom objects by UID from cloud storage.
        /// </summary>
        /// <param name="objectName">LoginRadius Custom Object Name</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Complete user CustomObject data</returns>
        /// 19.3

        public async Task<ApiResponse<ListData<UserCustomObjectData>>> GetCustomObjectByUid(string objectName, string uid)
        {
            if (string.IsNullOrWhiteSpace(objectName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(objectName));
            }
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "objectName", objectName }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/customobject";
            
            return await ConfigureAndExecute<ListData<UserCustomObjectData>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to retrieve the Custom Object data for the specified account.
        /// </summary>
        /// <param name="objectName">LoginRadius Custom Object Name</param>
        /// <param name="objectRecordId">Unique identifier of the user's record in Custom Object</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition for Complete user custom object data</returns>
        /// 19.4

        public async Task<ApiResponse<UserCustomObjectData>> GetCustomObjectByRecordID(string objectName, string objectRecordId,
        string uid)
        {
            if (string.IsNullOrWhiteSpace(objectName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(objectName));
            }
            if (string.IsNullOrWhiteSpace(objectRecordId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(objectRecordId));
            }
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "objectName", objectName }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/customobject/{objectRecordId}";
            
            return await ConfigureAndExecute<UserCustomObjectData>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to remove the specified Custom Object data using ObjectRecordId of specified account.
        /// </summary>
        /// <param name="objectName">LoginRadius Custom Object Name</param>
        /// <param name="objectRecordId">Unique identifier of the user's record in Custom Object</param>
        /// <param name="uid">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 19.5

        public async Task<ApiResponse<DeleteResponse>> DeleteCustomObjectByRecordID(string objectName, string objectRecordId,
        string uid)
        {
            if (string.IsNullOrWhiteSpace(objectName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(objectName));
            }
            if (string.IsNullOrWhiteSpace(objectRecordId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(objectRecordId));
            }
            if (string.IsNullOrWhiteSpace(uid))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(uid));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "objectName", objectName }
            };

            var resourcePath = $"identity/v2/manage/account/{uid}/customobject/{objectRecordId}";
            
            return await ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, null);
        }
    }
}