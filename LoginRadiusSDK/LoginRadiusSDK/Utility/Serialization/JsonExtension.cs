// -----------------------------------------------------------------------
// <copyright file="JsonExtension.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Web.Script.Serialization;

namespace LoginRadiusSDK.Utility.Serialization
{
    /// <summary>
    /// LoginRadius class for JSON serialization and deserialization.
    /// </summary>
    public static class JsonExtension
    {
        public static string Serialize(this object value)
        {
            var js = new JavaScriptSerializer();
            return js.Serialize(value);
        }

        public static T Deserialize<T>(this string value)
        {
            var js = new JavaScriptSerializer();
            return js.Deserialize<T>(value);
        }
    }
}
