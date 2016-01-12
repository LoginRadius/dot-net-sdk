using System.Collections;
using System.Collections.Generic;
using LoginRadiusSDK.Utility.Serialization;
using LoginRadiusSDK.Utility.Http;
using LoginRadiusSDK.Models;
using LoginRadiusSDK.Models.Object;
using LoginRadiusSDK.Utility;

namespace LoginRadiusSDK.Entity
{
    public class UserprofileEntity : LoginRadiusEntityBase
    {
        private readonly LoginRadiusObject _object = new LoginRadiusObject("user");
        readonly LoginRadiusArgumentValidator _validate = new LoginRadiusArgumentValidator();
        private ArrayList _valuesToCheck;

        /// <summary>
        /// Represents a method for profile data and authentication of a user. 
        /// </summary>
        /// <param name="username">A username is a name or email that uniquely identifies a user.</param>
        /// <param name="password">A password is a string of characters used for authenticating a user.</param>
        public RaasUserprofile GetUser(string username, string password)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { username, password }, "GetUser");

            var getRequest = new HttpRequestParameter { { "username", username }, { "password", password } };

            var response = Get(_object, getRequest);

            return response.Deserialize<RaasUserprofile>();
        }

        /// <summary>
        /// Represents a method for profile data and authentication of a user by userid. 
        /// </summary>
        /// <param name="userid">A userid is set of unique numerics and characters that uniquely identifies a user.</param>
        public RaasUserprofile GetUser(string userid)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { userid }, "GetUser");
           
            var getRequest = new HttpRequestParameter {{"userid", userid}};

            var response = Get(_object, getRequest);

            return response.Deserialize<RaasUserprofile>();
        }

        /// <summary>
        /// Represents a method that retrieves the profile data associated with the specific user using the passing in email address.
        /// </summary>
        /// <param name="emailId">An email is an unique set of characters and numerics that uniquely identifies a user or email address.</param>
        public RaasUserprofile GetUserbyEmail(string emailId)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { emailId }, "GetUser");

            var getRequest = new HttpRequestParameter { { "email", emailId } };

            var response = Get(_object, getRequest);

            return response.Deserialize<RaasUserprofile>();
        }
        /// <summary>
        /// Represents a method to delete a user profile with email confirmation. 
        /// </summary>
        /// <param name="userid">A userid is set of unique numerics and characters that uniquely identifies a user.</param>
        /// <param name="deleteuserlink">Delete user link is an URL which handles the logic of deleting a user and this URL is to be emailed to the user for confirmation.</param>
        public LoginRadiusPostResponse DeleteUser(string userid, string deleteuserlink)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { userid,deleteuserlink }, "GetUser");
            var getRequest = new HttpRequestParameter { { "userid", userid }, { "deleteuserlink", deleteuserlink } };
            var response = Get(_object, getRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method for profile data and authentication of a user. 
        /// </summary>
        /// <param name="emailid">An email is an unique set of characters and numerics that uniquely identifies a user.</param>
        /// <param name="password">A password is a string of characters used for authenticating a user.</param>
        /// <param name="accountid">Account Id is a uniquely generated string used for determination of a user account.</param>
        public LoginRadiusPostResponse UserCreateRegistrationProfile(string accountid,string emailid,string password)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { accountid, emailid, password }, "User Create Registration Profile");
            var postRequest = new HttpRequestParameter
            {
                {"accountid", accountid},
                {"password", password},
                {"emailid", emailid}
            };
            var response = Post(new LoginRadiusObject("account").ChildObject("profile"), postRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method to create a new user profile data with required parameters.
        /// </summary>
        /// <param name="user">User is a set of parameters used for creating a user.</param>
        public RaasUserprofile CreateUser(User user)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { user.EmailId, user.Password, user.FirstName, user.LastName, user.Gender, user.BirthDate }, "CreateUser");
            var postRequest = new HttpRequestParameter
            {
                {"emailid", user.EmailId},
                {"password", user.Password},
                {"firstname", user.FirstName},
                {"lastname", user.LastName},
                {"gender", user.Gender},
                {"birthdate", user.BirthDate}
            };

            var response = Post(_object, postRequest);

            return response.Deserialize<RaasUserprofile>();
        }

        /// <summary>
        /// Represents a method to update a user profile 
        /// </summary>
        /// <param name="user">User is a set of parameters used for creating a user with required parameters.</param>
        /// <param name="userid">A userid is set of unique numerics and characters that uniquely identifies a user.</param>
        public LoginRadiusPostResponse EditUser(string userid, User user)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { userid}, "EditUser");
           
            var getRequest = new HttpRequestParameter
            {
                {"userid", userid}
            };

            var jsonString = user.Serialize();

            var response = Post(_object, getRequest, jsonString);

            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method to register a new user profile with required parameters.
        /// </summary>
        /// <param name="user">User is a set of parameters used for registering a user.</param>
        public LoginRadiusPostResponse RegisterUser(User user)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { user.EmailId, user.Password, user.FirstName, user.LastName, user.Gender, user.BirthDate }, "RegisterUser");
            var postRequest = new HttpRequestParameter
            {
                {"emailid", user.EmailId},
                {"password", user.Password},
                {"firstname", user.FirstName},
                {"lastname", user.LastName},
                {"gender", user.Gender},
                {"birthdate", user.BirthDate}
            };

            var response = Post(_object.ChildObject("register"), postRequest);

            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method to change a user password.
        /// </summary>
        /// <param name="userid">A userid is set of unique numerics and characters that uniquely identifies a user.</param>
        ///  <param name="oldPassword">Old Password is the current passowrd of a user or password is to be changed.</param>
        ///  <param name="newPassword">A new unique set of characters and numbers which is to be used as a passsword.</param>
        public LoginRadiusPostResponse ChangePassword(string userid, string oldPassword, string newPassword)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { userid, newPassword, oldPassword }, "ChangePassword");
            var postRequest = new HttpRequestParameter
            {
                {"oldpassword", oldPassword},
                {"newpassword", newPassword}
            };

            var getRequest = new HttpRequestParameter
            {
                {"userid", userid}
            };

            var response = Post(_object.ChildObject("password"), getRequest, postRequest);

            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method to set the password of user for social profile and traditional profile .
        /// </summary>
        /// <param name="userid">A userid is set of unique numerics and characters that uniquely identifies a user.</param>
        /// <param name="password">A password is a string of characters used for authenticating a user.</param>
        public LoginRadiusPostResponse SetPassword(string userid, string password)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { userid, password }, "SetPassword");
            var postRequest = new HttpRequestParameter
            {
                {"password", password}
            };
            var getRequest = new HttpRequestParameter
            {
                {"action", "setpassword"},
                {"userid", userid}
            };

            var response = Post(_object.ChildObject("password"), getRequest, postRequest);

            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method which returns the encrypted hashed password for the specified User..
        /// </summary>
        /// <param name="userid">A userid is set of unique numerics and characters that uniquely identifies a user.</param>
        public HashPassword GetHashPassword(string userid)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { userid }, "GetHashPassword");
            var getRequest = new HttpRequestParameter {{"userid", userid}};

            var response = Get(_object, getRequest);

            return response.Deserialize<HashPassword>();
        }

        /// <summary>
        /// Method  is used to add or remove additional emails to a users account.
        /// </summary>
        /// <param name="accountid">Account Id is a uniquely generated string used for determination of a user account.</param>
        /// <param name="action">Add or remove.</param>
        /// <param name="emailId">Email address.</param>
        /// <param name="emailType">Email Type like "Business" or Personal.</param>
        public LoginRadiusPostResponse UpsertUserEmail(string accountid,string action,string emailId,string emailType)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { accountid, emailType, action, emailId }, "Upsert User Email");
            var getRequest = new HttpRequestParameter
            {
                {"accountid", accountid},
                {"action", action}
            };
            var postRequest = new HttpRequestParameter
            {
                {"emailId", emailId},
                {"emailType", emailType}
            };

            var response = Post(new LoginRadiusObject("account").ChildObject("email"), getRequest, postRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Method checks for the existence of the specified email address in your Cloud Storage.
        /// </summary>
        /// <param name="emailId">Email address.</param>
        public LoginRadiusEmailResponse CheckUserEmail(string emailId)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { emailId }, "Check User Email");
            var getRequest = new HttpRequestParameter { { "email", emailId } };
            var response = Get(_object.ChildObject("checkemail"), getRequest);
            return response.Deserialize<LoginRadiusEmailResponse>();
        }

        /// <summary>
        /// Method generates a forgot password token so you can manually pass into the reset password page and reset someone's password.
        /// </summary>
        /// <param name="emailId">Email address.</param>
        public LoginRadiusForgotPasswordTokenResponse PasswordForgotToken(string emailId)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { emailId }, "Password Forgot Token");
            var getRequest = new HttpRequestParameter { { "email", emailId } };
            var response = Get(new LoginRadiusObject("account").ChildObject("password").ChildObject("forgot"), getRequest);
            return response.Deserialize<LoginRadiusForgotPasswordTokenResponse>();
        }


        /// <summary>
        /// Method is used to retrieve the Custom Object for the specified account based on the account Id(UID).
        /// </summary>
        /// <param name="accountId">Account Id is a uniquely generated string used for determination of a user account.</param>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        public CustomObjectResponse GetCustomObject(string accountId, string objectId)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { accountId, objectId }, "GetCustomObject");
            var getRequest = new HttpRequestParameter
            {
                {"accountid", accountId},
                {"objectid", objectId}
            };

            var response = Get(_object.ChildObject("customObject"), getRequest);

            return response.Deserialize<CustomObjectResponse>();
        }

        /// <summary>
        /// Method is used to retrieve the Custom Object for the specified account based on the account Id(UID).
        /// </summary>
        /// <param name="accountIds">Account Id is a uniquely generated string used for determination of a user account.</param>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        public CustomObjectResponse GetCustomObject(List<string> accountIds, string objectId)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { accountIds, objectId }, "GetCustomObject");
            var multipleAccountdId = string.Empty;

            foreach (var accountId in accountIds)
            {
                multipleAccountdId = multipleAccountdId + "," + accountId;
            }
            var getRequest = new HttpRequestParameter
            {
                {"accountids", multipleAccountdId},
                {"objectid", objectId}
            };

            var response = Get(_object.ChildObject("customObject"), getRequest);

            return response.Deserialize<CustomObjectResponse>();
        }

        /// <summary>
        /// Method is used to retrieve all of the specified Custom Objects based on the Object Id.
        /// </summary>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        public List<CustomObjectResponse> GetCustomObject(string objectId)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { objectId }, "GetCustomObject");
            var getRequest = new HttpRequestParameter
            {
                {"objectid", objectId}
            };

            var response = Get(_object.ChildObject("customObject"), getRequest);

            return response.Deserialize<List<CustomObjectResponse>>();
        }

        /// <summary>
        /// Method  is used to retrieve all of the Custom Objects based on the specified query.
        /// </summary>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        /// <param name="query">Selection query in valid XML format.</param>
        /// <param name="cursor">Cursor value in case the data is large.</param>
        public List<CustomObjectResponse> GetCustomObject(string objectId, string query, string cursor)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { objectId, query, cursor }, "GetCustomObject");
            var getRequest = new HttpRequestParameter
            {
                {"objectid", objectId},
                {"q", query},
                {"cursor", cursor}
            };

            var response = Get(_object.ChildObject("customObject"), getRequest);

            return response.Deserialize<List<CustomObjectResponse>>();
        }

        /// <summary>
        /// Method  is used to retrieve all of the Custom objects based on the Object Id.
        /// </summary>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        /// <param name="cursor">Cursor value in case the data is large.</param>
        public List<CustomObjectResponse> GetAllCustomObject(string objectId, string cursor)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { objectId, cursor }, "GetAllCustomObject");
            var getRequest = new HttpRequestParameter
            {
                {"objectid", objectId},
                {"cursor", cursor}
            };

            var response = Get(_object.ChildObject("customObject"), getRequest);

            return response.Deserialize<List<CustomObjectResponse>>();
        }

        /// <summary>
        /// Method  is used to get the current storage information for a specified Custom Object.
        /// </summary>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        public CustomObjectStats GetCustomObjectStats(string objectId)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { objectId }, "GetCustomObjectStats");
          
            var getRequest = new HttpRequestParameter
            {
                {"objectid", objectId}
            };

            var response = Get(_object.ChildObject("customObject").ChildObject("stats"), getRequest);

            return response.Deserialize<CustomObjectStats>();
        }

        /// <summary>
        /// Method is used to write information in JSON format to the custom object for the specified account.
        /// </summary>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        ///  <param name="accountId">Account Id is a uniquely generated string used for determination of a user account.</param>
        ///  <param name="customObject">Valid JSON obj as per your schema.</param>
        public LoginRadiusPostResponse UpsertCustomObject(string accountId, string objectId,string customObject)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { objectId, accountId, customObject }, "UpsertCustomObject");
            var postRequest = new HttpRequestParameter
            {
                {"customobject", customObject.Serialize()}
            };
            var getRequest = new HttpRequestParameter
            {
                {"accountid", accountId},
                {"objectid", objectId}
            };

            var response = Post(_object.ChildObject("customObject").ChildObject("upsert"), getRequest, postRequest);

            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Method is used to remove the specified Custom Object based on the account Id(UID).
        /// </summary>
        /// <param name="objectId">LoginRadius Custom Object Id.</param>
        ///  <param name="accountId">Account Id is a uniquely generated string used for determination of a user account.</param>
        public LoginRadiusPostResponse DeleteCustomObject(string accountId, string objectId)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { objectId, accountId }, "DeleteCustomObject");
  
            var getRequest = new HttpRequestParameter
            {
                {"accountid", accountId},
                {"objectid", objectId}
            };

            var response = Post(_object.ChildObject("customObject").ChildObject("status"), getRequest);

            return response.Deserialize<LoginRadiusPostResponse>();
        }
    }
}