using System;

namespace LoginRadiusSDK.Entity
{
    /// <summary>
    /// LoginRadius SDK object class which is used to construct a link.
    /// </summary>
    public class LoginRadiusObject
    {
        private readonly string _objectName;

        /// <summary>
        ///  returns the object name or child a dierectory of a link.
        /// </summary>
        public String ObjectName
        {
            get { return _objectName; }
        }

        /// <summary>
        ///  sets the object name.
        /// </summary>
        /// <param name="objectName">Name of the sub part of link</param>
        public LoginRadiusObject(string objectName)
        {
            _objectName = objectName;
        }

        /// <summary>
        ///  method to append a child object (sub dierectory) of object(domain i.e. api.LoginRadius.com)
        /// </summary>
        /// <param name="childObject"> child object which is to be expand to the URL.</param>
        /// <returns></returns>
        public LoginRadiusObject ChildObject(string childObject)
        {
            return new LoginRadiusObject(_objectName + "/" + childObject);
        }
    }
}
