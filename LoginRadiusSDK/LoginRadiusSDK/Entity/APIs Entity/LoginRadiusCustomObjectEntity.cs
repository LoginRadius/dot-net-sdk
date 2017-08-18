using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LoginRadiusSDK.Models;
using LoginRadiusSDK.Models.Object;
using LoginRadiusSDK.Utility;
using LoginRadiusSDK.Utility.Http;
using LoginRadiusSDK.Utility.Serialization;

namespace LoginRadiusSDK.Entity
{
    public class LoginRadiusCustomObjectEntity : LoginRadiusServerEntity
    {
        private readonly LoginRadiusObject _object = new LoginRadiusObject("user/customObject");
        private readonly LoginRadiusArgumentValidator _validate = new LoginRadiusArgumentValidator();
        private ArrayList _valuesToCheck;

        public LoginRadiusCustomObjectEntity()
        {
        }
        public LoginRadiusCustomObjectEntity(string apikey, string apisecret)
            : base(apikey,apisecret)
        {
        }

        /// <summary>
        /// Method is used to write information in JSON format to the custom object for the specified account.
        /// </summary>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        ///  <param name="accountId">Account Id is a uniquely generated string used for determination of a user account.</param>
        ///  <param name="customObject">Valid JSON obj as per your schema.</param>
        public LoginRadiusPostResponse UpsertCustomObject(string accountId, string objectId, object customObject)
        {
            _valuesToCheck = new ArrayList {objectId, accountId, customObject};
            _validate.Validate(_valuesToCheck, "UpsertCustomObject");
            var getRequest = new HttpRequestParameter
            {
                {"accountid", accountId},
                {"objectid", objectId}
            };

            var response = Post(_object.ChildObject("upsert"), getRequest, customObject.Serialize());

            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Method is used to retrieve the Custom Object for the specified account based on the account Id(UID).
        /// </summary>
        /// <param name="accountId">Account Id is a uniquely generated string used for determination of a user account.</param>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        public CustomObjectResponse GetCustomObjectbyAccountId(string accountId, string objectId)
        {
            _valuesToCheck = new ArrayList {accountId, objectId};
            _validate.Validate(_valuesToCheck, "GetCustomObjectbyAccountId");
            var getRequest = new HttpRequestParameter
            {
                {"accountid", accountId},
                {"objectid", objectId}
            };

            var response = Get(_object, getRequest);

            return response.Deserialize<CustomObjectResponse>();
        }

        /// <summary>
        /// Method is used to retrieve the Custom Object for the specified account based on the account Id(UID).
        /// </summary>
        /// <param name="accountIds">Account Id is a uniquely generated string used for determination of a user account.</param>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        public List<CustomObjectResponse> GetCustomObjectbyMultipleAccountId(List<string> accountIds, string objectId)
        {
            _valuesToCheck = new ArrayList {accountIds, objectId};
            _validate.Validate(_valuesToCheck, "GetCustomObjectbyMultipleAccountId");

            var multipleAccountdId = accountIds.Aggregate(string.Empty, (current, accountId) => current + "," + accountId);

            var getRequest = new HttpRequestParameter
            {
                {"accountids", multipleAccountdId},
                {"objectid", objectId}
            };

            var response = Get(_object, getRequest);

            return response.Deserialize<List<CustomObjectResponse>>();
        }

        /// <summary>
        /// This method is used to check the presence of a Custom Object for the specified account ID(UID)
        /// </summary>
        /// <param name="accountId">The identifier for each user account, it may have multiple IDs(identifier for each social platform) attached with</param>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        /// <returns></returns>
        public LoginRadiusCustomObjectCheckResponse CheckCustomObject(string accountId, string objectId)
        {
            _valuesToCheck = new ArrayList {accountId, objectId};
            _validate.Validate(_valuesToCheck, "Check Custom Object");
            var getRequest = new HttpRequestParameter
            {
                {"objectid", objectId},{"accountid",accountId}
            };

            var response = Get(_object.ChildObject("check"), getRequest);
            return response.Deserialize<LoginRadiusCustomObjectCheckResponse>();
        }

        /// <summary>
        /// Method is used to retrieve all of the specified Custom Objects based on the Object Id.
        /// </summary>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        public List<CustomObjectResponse> GetCustomObjectbyObjectId(string objectId)
        {
            _valuesToCheck = new ArrayList {objectId};
            _validate.Validate(_valuesToCheck, "Get Custom Object by ObjectId");
            var getRequest = new HttpRequestParameter
            {
                {"objectid", objectId}
            };

            var response = Get(_object, getRequest);
            return response.Deserialize<List<CustomObjectResponse>>();
        }

        /// <summary>
        /// Method  is used to retrieve all of the Custom Objects based on the specified query.
        /// </summary>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        /// <param name="query">Selection query in valid XML format.</param>
        /// <param name="cursor">Cursor or indexvalue value in case the data is large.</param>
        public List<CustomObjectResponse> GetCustomObjectbyQuery(string objectId, string query, string cursor)
        {
            _valuesToCheck = new ArrayList {objectId, query, cursor};
            _validate.Validate(_valuesToCheck, "Get Custom Object");
            var getRequest = new HttpRequestParameter
            {
                {"objectid", objectId},
                {"query", query},
                {"cursor", cursor}
            };
            var response = Get(_object, getRequest);
            return response.Deserialize<List<CustomObjectResponse>>();
        }

        /// <summary>
        /// Method  is used to retrieve all of the Custom objects based on the Object Id.
        /// </summary>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        /// <param name="cursor">Cursor or indexvalue value in case the data is large.</param>
        public List<CustomObjectResponse> GetAllCustomObject(string objectId, string cursor)
        {
            _valuesToCheck = new ArrayList {objectId, cursor};
            _validate.Validate(_valuesToCheck, "Get All Custom Object");
            var getRequest = new HttpRequestParameter
            {
                {"objectid", objectId},
                {"cursor", cursor}
            };

            var response = Get(_object, getRequest);
            return response.Deserialize<List<CustomObjectResponse>>();
        }

        /// <summary>
        /// Method  is used to get the current storage information for a specified Custom Object.
        /// </summary>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        public CustomObjectStats GetCustomObjectStats(string objectId)
        {
            _valuesToCheck = new ArrayList {objectId};
            _validate.Validate(_valuesToCheck, "Get Custom Object Stats");

            var getRequest = new HttpRequestParameter
            {
                {"objectid", objectId}
            };

            var response = Get(_object.ChildObject("stats"), getRequest);
            return response.Deserialize<CustomObjectStats>();
        }

        /// <summary>
        /// Method is used to remove the specified Custom Object based on the account Id(UID).
        /// </summary>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        ///  <param name="accountId">Account Id is a uniquely generated string used for determination of a user account.</param>
        /// <param name="isblock"></param>
        public LoginRadiusPostResponse DeleteCustomObject(string accountId, string objectId, bool isblock)
        {
            _valuesToCheck = new ArrayList {objectId, accountId};
            _validate.Validate(_valuesToCheck, "Delete Custom Object");
            var getRequest = new HttpRequestParameter
            {
                {"accountid", accountId},
                {"objectid", objectId}
            };
            var loginRadiusBlockUnblockModel = new LoginRadiusBlockUnblockModel
            {
                IsBlock = isblock
            };
            var response = Post(_object.ChildObject("status"), getRequest, loginRadiusBlockUnblockModel.Serialize());
            return response.Deserialize<LoginRadiusPostResponse>();
        }
    }
}
