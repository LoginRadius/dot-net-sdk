using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using LoginRadiusSDK.Utility.Serialization;
using LoginRadiusSDK.Utility.Http;
using LoginRadiusSDK.Models;
using LoginRadiusSDK.Models.Object;
using LoginRadiusSDK.Models.UserProfile;
using LoginRadiusSDK.Utility;
namespace LoginRadiusSDK.Entity
{
<<<<<<< HEAD
    public class LoginRadiusAccountEntity : LoginRadiusEntityBase
=======
    public class LoginRadiusAccountEntity : LoginRadiusServerEntity
>>>>>>> master
    {
        readonly LoginRadiusArgumentValidator _validate=new LoginRadiusArgumentValidator();
        private readonly LoginRadiusObject _object = new LoginRadiusObject("account");
        private ArrayList _valuesToCheck;

<<<<<<< HEAD
=======
        public LoginRadiusAccountEntity()
        {
        }
        public LoginRadiusAccountEntity(string apikey, string apisecret)
            : base(apikey,apisecret)
        {
        }

>>>>>>> master
        /// <summary>
        /// Method which is used to link a social account with a specified provider user account.
        /// </summary>
        /// <param name="accountId">An account id is set of unique numerics and characters that uniquely identifies a user's account.</param>
        /// <param name="provider">A supported Social provider name in lower case which is to be linked</param>
        ///  <param name="providerId">The ID of the social provider.</param>
        public LoginRadiusPostResponse LinkAccount(string accountId, string provider, string providerId)
        {
            _valuesToCheck = new ArrayList {accountId, provider, providerId};
            _validate.Validate(_valuesToCheck, "LinkAccount");

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
        /// Method which is used to remove the link between a users account and the specified provider’s user account.
        /// </summary>
        /// <param name="accountId">An account id is set of unique numerics and characters that uniquely identifies a user's account.</param>
        /// <param name="provider">A supported social provider in lower case which is to be unlinked.</param>
        ///  <param name="providerId">The ID of the social provider.</param>
        public LoginRadiusPostResponse UnlinkAccount(string accountId, string provider, string providerId)
        {
            _valuesToCheck = new ArrayList {accountId, provider, providerId};
            _validate.Validate(_valuesToCheck, "UnlinkAccount");
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
        /// Method which is used to retrieve all of the profile data from each of the linked social provider accounts associated with the account.
        /// </summary>
        /// <param name="accountId">An account id is set of unique numerics and characters that uniquely identifies a user's account or the identifier for each user account, it may have multiple IDs.</param>
        public List<RaasUserprofile> GetAccountProfiles(string accountId)
        {
            _valuesToCheck = new ArrayList {accountId};
            _validate.Validate(_valuesToCheck, "GetAccount");
            var getRequest = new HttpRequestParameter
            {
                { "accountid", accountId}
            };
            var response = Get(_object, getRequest);
            return response.Deserialize<List<RaasUserprofile>>();
        }

        /// <summary>
        /// Method which is used to block or unblock a Users account. It prevents them from logging in our registering for a new account.
        /// </summary>
        /// <param name="accountId">An account id is set of unique numerics and characters that uniquely identifies a user's account or the identifier for each user account.</param>
        /// <param name="isBlock">True or False , defines the status to be set. </param>
        public LoginRadiusPostResponse SetAccountStatus(string accountId, bool isBlock)
        {
            _valuesToCheck = new ArrayList {accountId, isBlock};
            _validate.Validate(_valuesToCheck, "SetAccountStatus");
            var getRequest = new HttpRequestParameter
            {
                { "accountid", accountId }
            };
            LoginRadiusBlockUnblockModel loginRadiusBlockUnblockModel = new LoginRadiusBlockUnblockModel
            {
                IsBlock = isBlock
            };
            var json = new JavaScriptSerializer().Serialize(loginRadiusBlockUnblockModel);
            var response = Post(_object.ChildObject("status"), getRequest, json);

            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Method which is used to deletes the Users account and allows them to re-register for a new account.
        /// </summary>
        /// <param name="accountId">An account id is set of unique numerics and characters that uniquely identifies a user's account or the identifier for each user account, it may have multiple IDs.</param>
        public LoginRadiusPostResponse DeleteAccount(string accountId)
        {
            _valuesToCheck = new ArrayList {accountId};
            _validate.Validate(_valuesToCheck, "DeleteAccount");
            var getRequest = new HttpRequestParameter
            {
                { "accountid", accountId }
            };
            var response = Get(_object.ChildObject("delete"), getRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Method which deletes the User account with email confirmation and allows them to re-register for a new account.
        /// </summary>
        /// <param name="accountId">An account id is set of unique numerics and characters that uniquely identifies a user's account or the identifier for each user account.</param>
        /// <param name="deleteUserLink">Link that handles the delete logic</param>
        /// <param name="template">Name of the email template to be send for the delete confirmation</param>
        public LoginRadiusPostResponse DeleteAccountWithEmailConfirmation(string accountId, string deleteUserLink, string template)
        {
            _valuesToCheck = new ArrayList {accountId, deleteUserLink};
            _validate.Validate(_valuesToCheck, "DeleteAccount");
            var getRequest = new HttpRequestParameter
            {
                { "accountid", accountId },
                {"deleteuserlink",deleteUserLink}
            };
            if (!string.IsNullOrWhiteSpace(template))
            {
                getRequest.Add("template", template);
            }
            var response = Get(_object.ChildObject("deleteuseremail"), getRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Method is used to change the password field of an account, user need to know the old password before you change it.
        /// </summary>
        /// <param name="accountId">An account id is set of unique numerics and characters that uniquely identifies a user's account or the identifier for each user account.</param>
        ///  <param name="oldPassword">Old Password is the current passowrd of a user or password is to be changed.</param>
        ///  <param name="newPassword">A new unique set of characters and numbers which is to be used as a new passsword.</param>
        public LoginRadiusPostResponse ChangeAccountPassword(string accountId, string oldPassword, string newPassword)
        {
            _valuesToCheck = new ArrayList {accountId, newPassword, oldPassword};
            _validate.Validate(_valuesToCheck, "Change Password");
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
        /// Method  is used to retrieve the accounts encrypted hashed password based on account ID(UID).
        /// </summary>
        /// <param name="accountId">the identifier for each user account.</param>
        public HashPassword GetAccountPassword(string accountId)
        {
            _valuesToCheck = new ArrayList {accountId};
            _validate.Validate(_valuesToCheck, "Get Account Password");
               var getRequest = new HttpRequestParameter
            {
                {"accountid", accountId}
            };
            var response = Get(_object.ChildObject("password"), getRequest);
            return response.Deserialize<HashPassword>();
        }

        /// <summary>
        /// Method is used to set a new password for the specified account. It is meant to be used as an admin feature or post authentication.
        /// </summary>
        /// <param name="accountId">the identifier for each user account.</param>
        ///  <param name="password">A password is a string of characters used for authenticating a user or account password to be set.</param>
        public LoginRadiusPostResponse SetAccountPassword(string accountId, string password)
        {
            _valuesToCheck = new ArrayList {accountId, password};
            _validate.Validate(_valuesToCheck, "Set Account Password");
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
        /// Method is used for changing user name by account Id.
        /// </summary>
        /// <param name="accountId">the identifier for each user account.</param>
        ///  <param name="currentusername">Current Username or username to be changed.</param>
        /// <param name="newusername">New username</param>
        public LoginRadiusPostResponse ChangeAccountUsername(string accountId, string currentusername,string newusername)
        {
            _valuesToCheck = new ArrayList {accountId, currentusername, newusername};
            _validate.Validate(_valuesToCheck, "Change Account Username");
            var postRequest = new HttpRequestParameter
            {
                {"oldusername", currentusername},
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
        public LoginRadiusEmailResponse CheckAccountUsername(string username)
        {
            _valuesToCheck = new ArrayList {username};
            _validate.Validate(_valuesToCheck, "Check Account Username");
            var getRequest = new HttpRequestParameter
            {
                {"username", username}
            };

            var response = Get(new LoginRadiusObject("user").ChildObject("checkusername"), getRequest);
            return response.Deserialize<LoginRadiusEmailResponse>();
        }

        /// <summary>
        /// Represents a method is  is used for set user name by account Id.
        /// </summary>
        /// <param name="accountId">the identifier for each user account.</param>
        /// <param name="newusername">New Username to be set</param>
        public LoginRadiusPostResponse SetAccountUsername(string accountId,string newusername)
        {
            _valuesToCheck = new ArrayList {accountId, newusername};
            _validate.Validate(_valuesToCheck, "Set Account Username");
            var postRequest = new HttpRequestParameter
            {
                {"newusername", newusername}
            };
            var getRequest = new HttpRequestParameter
            {
                {"accountid", accountId}
            };
            var response = Post(_object.ChildObject("setusername"), getRequest,postRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Method for profile data and authentication of a user. 
        /// </summary>
        /// <param name="emailid">An email is an unique set of characters and numerics that uniquely identifies a user.</param>
        /// <param name="password">A password is a string of characters used for authenticating a user.</param>
        /// <param name="accountid">Account Id is a uniquely generated string used for determination of a user account.</param>
        public LoginRadiusPostResponse UserCreateRegistrationProfile(string accountid, string emailid, string password)
        {
            _valuesToCheck = new ArrayList {accountid, emailid, password};
            _validate.Validate(_valuesToCheck, "User Create Registration Profile");
            var postRequest = new HttpRequestParameter
            {
                {"accountid", accountid},
                {"password", password},
                {"emailid", emailid}
            };
            var response = Post(_object.ChildObject("profile"), postRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Method  is used to add or remove additional emails to a user's account.
        /// </summary>
        /// <param name="accountid">Account Id is a uniquely generated string used for determination of a user account.</param>
        /// <param name="action">Add or remove.</param>
        /// <param name="emailId">Email address.</param>
        /// <param name="emailType">Email Type like "Business" or Personal.</param>
        public LoginRadiusPostResponse UserEmailAddOrRemove(string accountid, string action, string emailId, string emailType)
        {
            _valuesToCheck = new ArrayList {accountid, emailType, action, emailId};
            _validate.Validate(_valuesToCheck, "User Email Add or Remove");
            var getRequest = new HttpRequestParameter
            {
                {"accountid", accountid},
                {"action", action}
            };
            var postRequest = new HttpRequestParameter
            {
                {"EmailId", emailId},
                {"EmailType", emailType}
            };

            var response = Post(_object.ChildObject("email"), getRequest, postRequest);
            return response.Deserialize<LoginRadiusPostResponse>();
        }

        /// <summary>
        /// Method generates a forgot password token so you can manually pass into the reset password page and reset someone's password.
        /// </summary>
        /// <param name="emailId">Email address.</param>
        public LoginRadiusForgotPasswordTokenResponse GetPasswordForgotToken(string emailId)
        {
            _valuesToCheck = new ArrayList {emailId};
            _validate.Validate(_valuesToCheck, "Get Password Forgot Token");
            var getRequest = new HttpRequestParameter
            {
                { "email", emailId }
            };
            var response = Get(_object.ChildObject("password").ChildObject("forgot"), getRequest);
            return response.Deserialize<LoginRadiusForgotPasswordTokenResponse>();
        }

        /// <summary>
        /// This method is used to generate an email-token that can be sent out to a user in a link in order to verify their email.
        /// </summary>
        /// <param name="emailId">User's email address</param>
        /// <param name="link">Verification Url link address</param>
        /// <param name="template">Verification Email Template,Optional</param>
        /// <returns></returns>
        public LoginRadiusEmailVerificationToken ResendUserVerificationEmail(string emailId, string link, string template)
        {
            _valuesToCheck = new ArrayList {emailId, link};
            _validate.Validate(_valuesToCheck, "Resend User Verification Email");
            var getRequest = new HttpRequestParameter
            {
                { "emailid", emailId },{"link",link}
            };
            if (!string.IsNullOrWhiteSpace(template))
            {
                getRequest.Add("template", template);
            }
            var response = Get(_object.ChildObject("verificationemail"), getRequest);
            return response.Deserialize<LoginRadiusEmailVerificationToken>();
        }
    }
}
