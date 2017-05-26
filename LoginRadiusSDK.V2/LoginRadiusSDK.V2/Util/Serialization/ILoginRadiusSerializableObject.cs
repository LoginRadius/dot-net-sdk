namespace LoginRadiusSDK.V2.Util.Serialization
{
    /// <summary>
    /// Defines an interface for a LoginRadius JSON-serializable object.
    /// </summary>
    public interface ILoginRadiusSerializableObject
    {
        /// <summary>
        /// Converts this object to a JSON string.
        /// </summary>
        /// <returns>A JSON-formatted string.</returns>
        string ConvertToJson();
    }
}