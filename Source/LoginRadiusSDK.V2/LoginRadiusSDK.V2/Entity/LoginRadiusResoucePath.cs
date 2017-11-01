namespace LoginRadiusSDK.V2.Entity
{
    /// <summary>
    /// LoginRadius SDK object class which is used to construct a link.
    /// </summary>
    public class LoginRadiusResoucePath
    {
        /// <summary>
        ///  returns the object name or child a dierectory of a link.
        /// </summary>
        public string ObjectName { get; }

        /// <summary>
        ///  sets the object name.
        /// </summary>
        /// <param name="objectName">Name of the sub part of link</param>
        public LoginRadiusResoucePath(string objectName)
        {
            ObjectName = objectName;
        }

        /// <summary>
        ///  method to append a child object (sub dierectory) of object(domain i.e. api.LoginRadius.com)
        /// </summary>
        /// <param name="childObject"> child object which is to be expand to the URL.</param>
        /// <returns></returns>
        public LoginRadiusResoucePath ChildObject(string childObject)
        {
            return new LoginRadiusResoucePath(ObjectName + "/" + childObject);
        }

        public override string ToString()
        {
            return ObjectName;
        }
    }
}