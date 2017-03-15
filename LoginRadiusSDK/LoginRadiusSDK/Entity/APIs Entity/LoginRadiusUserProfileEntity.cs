using System.Collections;
using LoginRadiusSDK.Utility.Serialization;
using LoginRadiusSDK.Utility.Http;
using LoginRadiusSDK.Models;
using LoginRadiusSDK.Models.Object;
using LoginRadiusSDK.Models.UserProfile;
using LoginRadiusSDK.Utility;

namespace LoginRadiusSDK.Entity
{
    public class LoginRadiusUserProfileEntity : LoginRadiusServerEntity
    {
        private readonly LoginRadiusObject _object = new LoginRadiusObject("user");
        private readonly LoginRadiusArgumentValidator _validate = new LoginRadiusArgumentValidator();
        private ArrayList _valuesToCheck;

        public LoginRadiusUserProfileEntity()
        {
        }
        public LoginRadiusUserProfileEntity(string apikey, string apisecret)
            : base(apikey,apisecret)
        {
        }

        /// <summary>
        /// Method to authenticate users and returns the profile data associated with the authenticated user.
        /// </summary>
        /// <param name="emailId">A username is a name or email that uniquely identifies a user.</param>
        /// <param name="password">A password is a string of characters used for authenticating a user.</param>
        public RaasUserprofile AuthenticateUser(string emailId, string password)
        {
            _valuesToCheck = new ArrayList {emailId, password};
            _validate.Validate(_valuesToCheck, "Authenticate User");

            var getRequest = new HttpRequestParameter { { "username", emailId }, { "password", password } };

            var response = Get(_object, getRequest);

            return response.Deserialize<RaasUserprofile>();
        }

        /// <summary>
        /// Method to create a new user profile data with required parameters.
        /// </summary>
        /// <param name="user">User is a set of parameters used for creating a user.</param>
        public RaasUserprofile CreateUser(User user)
        {
            _valuesToCheck = new ArrayList {user.EmailId, user.Password};
            _validate.Validate(_valuesToCheck, "Create User");
            var json = user.Serialize();
            var response = Post(_object, json);
            return response.Deserialize<RaasUserprofile>();
        }

        /// <summary>
        /// Method to delete a user profile with email confirmation. 
        /// </summary>
        /// <param name="userid">A userid is set of unique numerics and characters that uniquely identifies a user.</param>
        /// <param name="deleteuserlink">Delete user link is an URL which handles the logic of deleting a user and this URL is to be emailed to the user for confirmation.</param>
        /// <param name="template">Name of email template</param>
        public LoginRadiusPostResponse DeleteUser(string userid, string deleteuserlink, string template)
        {
            _valuesToCheck = new ArrayList {userid, deleteuserlink};
            _validate.Validate(_valuesToCheck, "Delete User");
            var getRequest = new HttpRequestParameter
            {
                { "userid", userid }, { "deleteuserlink", deleteuserlink }
            };
            if (!string.IsNullOrWhiteSpace(template))
            {
                getRequest.Add("template", template);
            }
            var response = Get(_object.ChildObject("deleteuseremail"), getRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Method checks for the existence of the specified email address in your Cloud Storage.
        /// </summary>
        /// <param name="emailId">Email address.</param>
        public LoginRadiusEmailResponse CheckUserEmail(string emailId)
        {
            _valuesToCheck = new ArrayList {emailId};
            _validate.Validate(_valuesToCheck, "Check User Email");
            var getRequest = new HttpRequestParameter { { "email", emailId } };
            var response = Get(_object.ChildObject("checkemail"), getRequest);
            return response.Deserialize<LoginRadiusEmailResponse>();
        }

        /// <summary>
        /// Method for profile data and authentication of a user by userid. 
        /// </summary>
        /// <param name="userid">A userid is set of unique numerics and characters that uniquely identifies a user.</param>
        public RaasUserprofile GetUser(string userid)
        {
            _valuesToCheck = new ArrayList {userid};
            _validate.Validate(_valuesToCheck, "GetUser");
            var getRequest = new HttpRequestParameter { { "userid", userid } };
            var response = Get(_object, getRequest);
            return response.Deserialize<RaasUserprofile>();
        }

        /// <summary>
        /// Represents a method that retrieves the profile data associated with the specific user using the passing in email address.
        /// </summary>
        /// <param name="emailId">An email is an unique set of characters and numerics that uniquely identifies a user or email address.</param>
        public RaasUserprofile GetUserbyEmail(string emailId)
        {
            _valuesToCheck = new ArrayList {emailId};
            _validate.Validate(_valuesToCheck, "Get User by Email");
            var getRequest = new HttpRequestParameter { { "emailId", emailId } };
            var response = Get(_object, getRequest);
            return response.Deserialize<RaasUserprofile>();
        }

        /// <summary>
        /// Represents a method to register a new user profile with required parameters into your Cloud Storage and triggers the email verification process.
        /// </summary>
        /// <param name="user">User is a set of parameters used for registering a user.</param>
        public LoginRadiusPostResponse RegisterUser(UserRegistrationModel user)
        {
            _valuesToCheck = new ArrayList {user.EmailId, user.Password};
            _validate.Validate(_valuesToCheck, "RegisterUser");
            var json = user.Serialize();
            var response = Post(_object.ChildObject("register"), json);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method to update a user profile 
        /// </summary>
        /// <param name="user">User is a set of parameters used for creating a user with required parameters.</param>
        /// <param name="userid">A userid is set of unique numerics and characters that uniquely identifies a user.</param>
        public LoginRadiusPostResponse UpdateUser(string userid, User user)
        {
            _valuesToCheck = new ArrayList {userid};
            _validate.Validate(_valuesToCheck, "UpdateUser");
            var getRequest = new HttpRequestParameter
            {
                {"userid", userid}
            };
            var jsonString = user.Serialize();
            var response = Post(_object, getRequest, jsonString);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Method to change a user password.
        /// </summary>
        /// <param name="userid">A userid is set of unique numerics and characters that uniquely identifies a user.</param>
        ///  <param name="oldPassword">Old Password is the current passowrd of a user or password is to be changed.</param>
        ///  <param name="newPassword">A new unique set of characters and numbers which is to be used as a passsword.</param>
        public LoginRadiusPostResponse ChangePassword(string userid, string oldPassword, string newPassword)
        {
            _valuesToCheck = new ArrayList {userid, newPassword, oldPassword};
            _validate.Validate(_valuesToCheck, "ChangePassword");
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
        /// Method to set the password of user for social profile and traditional profile .
        /// </summary>
        /// <param name="userid">A userid is set of unique numerics and characters that uniquely identifies a user.</param>
        /// <param name="password">A password is a string of characters used for authenticating a user.</param>
        public LoginRadiusPostResponse SetPassword(string userid, string password)
        {
            _valuesToCheck = new ArrayList {userid, password};
            _validate.Validate(_valuesToCheck, "SetPassword");
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
        /// Method which returns the encrypted hashed password for the specified User..
        /// </summary>
        /// <param name="userid">A userid is set of unique numerics and characters that uniquely identifies a user.</param>
        public HashPassword GetHashPassword(string userid)
        {
            _valuesToCheck = new ArrayList {userid};
            _validate.Validate(_valuesToCheck, "Get Hash Password");
            var getRequest = new HttpRequestParameter
            {
                { "userid", userid }
            };
            var response = Get(_object.ChildObject("password"), getRequest);
            return response.Deserialize<HashPassword>();
        }
    }
}