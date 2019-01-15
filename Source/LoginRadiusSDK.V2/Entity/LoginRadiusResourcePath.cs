namespace LoginRadiusSDK.V2.Entity
{
    /// <summary>
    /// LoginRadius SDK object class which is used to construct a link.
    /// </summary>
    public class LoginRadiusResourcePath
    {
        /// <summary>
        ///  returns the object name or child a directory of a link.
        /// </summary>
        public string ObjectName { get; }

        /// <summary>
        ///  sets the object name.
        /// </summary>
        /// <param name="objectName">Name of the sub part of link</param>
        public LoginRadiusResourcePath(string objectName)
        {
            ObjectName = objectName;
        }

        /// <summary>
        ///  method to append a child object (sub directory) of object(domain i.e. api.LoginRadius.com)
        /// </summary>
        /// <param name="childObject"> child object which is to be expand to the URL.</param>
        /// <returns></returns>
        public LoginRadiusResourcePath ChildObject(string childObject)
        {
            return new LoginRadiusResourcePath(ObjectName + "/" + childObject);
        }

        public override string ToString()
        {
            return ObjectName;
        }
    }
}