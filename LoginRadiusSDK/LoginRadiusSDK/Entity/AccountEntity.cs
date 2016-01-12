using System.Collections;
using System.Collections.Generic;
using LoginRadiusSDK.Utility.Serialization;
using LoginRadiusSDK.Utility.Http;
using LoginRadiusSDK.Models;
using LoginRadiusSDK.Models.Object;
using LoginRadiusSDK.Utility;
namespace LoginRadiusSDK.Entity
{
    public class AccountEntity : LoginRadiusEntityBase
    {
        readonly LoginRadiusArgumentValidator _validate=new LoginRadiusArgumentValidator();
        readonly LoginRadiusObject _object = new LoginRadiusObject("account");
        private ArrayList _valuesToCheck;

        /// <summary>
        /// Represents a method which is used to link a social account with a specified provider user account.
        /// </summary>
        /// <param name="accountId">An account id is set of unique numerics and characters that uniquely identifies a user's account.</param>
        /// <param name="provider">A supported Social provider name in lower case which is to be linked</param>
        ///  <param name="providerId">The ID of the social provider.</param>
        public LoginRadiusPostResponse LinkAccount(string accountId, string provider, string providerId)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { accountId, provider, providerId }, "LinkAccount");

            var postRequest = new HttpRequestParameter
            {
                {"accountid", accountId},
                {"provider", provider},
                {"providerid", providerId}
            };

            var response = Post(_object.ChildObject("link"), postRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method which is used to remove the link between a users account and the specified provider’s user account.
        /// </summary>
        /// <param name="accountId">An account id is set of unique numerics and characters that uniquely identifies a user's account.</param>
        /// <param name="provider">A supported social provider in lower case which is to be unlinked.</param>
        ///  <param name="providerId">The ID of the social provider.</param>
        public LoginRadiusPostResponse UnlinkAccount(string accountId, string provider, string providerId)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { accountId, provider, providerId }, "UnlinkAccount");
            var postRequest = new HttpRequestParameter
            {
                { "accountid", accountId},
                { "provider", provider },
                { "providerid", providerId }
            };

            var response = Post(_object.ChildObject("unlink"), postRequest);

            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method which is used to create Raas(Traditional) user profile of a social account.
        /// </summary>
        /// <param name="accountId">An account id is set of unique numerics and characters that uniquely identifies a user's account.</param>
        /// <param name="emailId">email address.</param>
        ///  <param name="password">A password is a string of characters used for authenticating a user or user password to be set.</param>
        public LoginRadiusPostResponse CreateRaaSProfile(string accountId, string emailId,string password)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { accountId, emailId, password }, "RaaS Profile");
            var postRequest = new HttpRequestParameter
            {
                { "accountid", accountId},
                { "emailid", emailId},
                { "password", password }
            };

            var response = Post(_object.ChildObject("profile"), postRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method which is used to retrieve all of the profile data from each of the linked social provider accounts associated with the account.
        /// </summary>
        /// <param name="accountId">An account id is set of unique numerics and characters that uniquely identifies a user's account or the identifier for each user account, it may have multiple IDs.</param>
        public List<RaasUserprofile> GetAccountProfiles(string accountId)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { accountId }, "GetAccount");
            var getRequest = new HttpRequestParameter
            {
                { "accountid", accountId}
            };

            var response = Get(_object, getRequest);

            return response.Deserialize<List<RaasUserprofile>>();
        }

        /// <summary>
        /// Represents a method which is used to block or unblock a Users account. It prevents them from logging in our registering for a new account.
        /// </summary>
        /// <param name="accountId">An account id is set of unique numerics and characters that uniquely identifies a user's account or the identifier for each user account.</param>
        /// <param name="isBlock">True or False , defines the status to be set. </param>
        public LoginRadiusPostResponse SetAccountStatus(string accountId, bool isBlock)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { accountId, isBlock }, "SetAccountStatus");
            var getRequest = new HttpRequestParameter
            {
                { "uid", accountId }
            };
            var postRequest = new HttpRequestParameter
            {
                { "isblock ", isBlock ? "true" :"false" }
            };

            var response = Post(new LoginRadiusObject("user").ChildObject("status"), getRequest, postRequest);

            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method which is used to deletes the Users account and allows them to re-register for a new account.
        /// </summary>
        /// <param name="accountId">An account id is set of unique numerics and characters that uniquely identifies a user's account or the identifier for each user account, it may have multiple IDs.</param>
        public LoginRadiusPostResponse DeleteAccount(string accountId)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { accountId }, "DeleteAccount");
            var getRequest = new HttpRequestParameter
            {
                { "uid", accountId }
            };

            var response = Post(new LoginRadiusObject("user").ChildObject("delete"), getRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method is used to change the password field of an account, user need to know the old password before you change it.
        /// </summary>
        /// <param name="accountId">An account id is set of unique numerics and characters that uniquely identifies a user's account or the identifier for each user account.</param>
        ///  <param name="oldPassword">Old Password is the current passowrd of a user or password is to be changed.</param>
        ///  <param name="newPassword">A new unique set of characters and numbers which is to be used as a new passsword.</param>
        public LoginRadiusPostResponse ChangeAccountPassword(string accountId, string oldPassword, string newPassword)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { accountId, newPassword, oldPassword }, "Change Password");
            var postRequest = new HttpRequestParameter
            {
                {"oldpassword", oldPassword},
                {"newpassword", newPassword}
            };
            var getRequest = new HttpRequestParameter
            {
                {"accountid", accountId}
            };

            var response = Post(_object.ChildObject("password"), getRequest, postRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method  is used to retrieve the accounts encrypted hashed password based on account ID(UID).
        /// </summary>
        /// <param name="accountId">the identifier for each user account.</param>
        public LoginRadiusPostResponse GetAccountPassword(string accountId)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { accountId }, "Account Password");
               var getRequest = new HttpRequestParameter
            {
                {"accountid", accountId}
            };

            var response = Get(_object.ChildObject("password"), getRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method is used to set a new password for the specified account. It is meant to be used as an admin feature or post authentication.
        /// </summary>
        /// <param name="accountId">the identifier for each user account.</param>
        ///  <param name="password">A password is a string of characters used for authenticating a user or account password to be set.</param>
        public LoginRadiusPostResponse SetAccountPassword(string accountId, string password)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { accountId, password }, "Set Password");
            var postRequest = new HttpRequestParameter
            {
                {"password", password}
            };
            var getRequest = new HttpRequestParameter
            {
                {"action", "setpassword"},
                {"accountid", accountId}
            };

            var response = Post(_object.ChildObject("password"), getRequest, postRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method is used for changing user name by account Id.
        /// </summary>
        /// <param name="accountId">the identifier for each user account.</param>
        ///  <param name="currentusername">Current Username or username to be changed.</param>
        /// <param name="newusername">New username</param>
        public LoginRadiusPostResponse ChangeAccountUsername(string accountId, string currentusername,string newusername)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { accountId, currentusername, newusername }, "Change Account Username");
            var postRequest = new HttpRequestParameter
            {
                {"currentusername", currentusername},
                {"newusername",newusername }
            };
            var getRequest = new HttpRequestParameter
            {
                {"accountid", accountId}
            };

            var response = Post(_object.ChildObject("changeusername"), getRequest, postRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method is used to check username exists or not on your site.
        /// </summary>
        /// <param name="username">Username to be check</param>
        public LoginRadiusPostResponse CheckAccountUsername(string username)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { username }, "Check Account Username");
            var getRequest = new HttpRequestParameter
            {
                {"username", username}
            };

            var response = Post(new LoginRadiusObject("user").ChildObject("checkusername"), getRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Represents a method is  is used for set user name by account Id.
        /// </summary>
        /// <param name="newusername">New Username to be set</param>
        public LoginRadiusPostResponse SetAccountUsername(string newusername)
        {
            _validate.Validate(_valuesToCheck = new ArrayList() { newusername }, "Set Account Username");
            var getRequest = new HttpRequestParameter
            {
                {"newusername", newusername}
            };

            var response = Post(_object.ChildObject("setusername"), getRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }
    }
}
