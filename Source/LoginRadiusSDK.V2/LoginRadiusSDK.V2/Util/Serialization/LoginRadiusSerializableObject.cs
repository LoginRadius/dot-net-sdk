namespace LoginRadiusSDK.V2.Util.Serialization
{
    public abstract class LoginRadiusSerializableObject : ILoginRadiusSerializableObject
    {
        /// <summary>
        /// Converts this object to a JSON string.
        /// </summary>
        /// <returns>A JSON-formatted string.</returns>
        public virtual string ConvertToJson()
        {
            return JsonFormatter.ConvertToJson(this);
        }
    }
}