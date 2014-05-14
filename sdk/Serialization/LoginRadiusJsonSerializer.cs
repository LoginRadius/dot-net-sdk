using System.Web.Script.Serialization;

namespace LoginRadius.SDK.Serialization
{
    /// <summary>
    /// The LoginRadiusJsonSerializer class is used to serialize and deserialize to provider response.
    /// </summary>
    /// <typeparam name="T">T refers as loginradius model classes</typeparam>
    internal class LoginRadiusJsonSerializer<T> : ILoginRadiusSerializer<T> where T : class, new() 
    {
        JavaScriptSerializer jsserializer = new JavaScriptSerializer();

        /// <summary>
        /// The Serialize method is used to serialize to loginradius model class into json in string format.
        /// </summary>
        /// <param name="data">data refers as loginradius model class</param>
        /// <returns>Return json response in string format</returns>
        public string Serialize(T data)
        {
            return jsserializer.Serialize(data);
        }

        /// <summary>
        /// The Deserialize method is used to deserialize to provider response into loginradius model classes format.
        /// </summary>
        /// <param name="content">content refers as provider response in string format</param>
        /// <returns>Return response as loginradius model classes format</returns>
        public T Deserialize(string content)
        {
            return jsserializer.Deserialize<T>(content);
        }
    }
}
