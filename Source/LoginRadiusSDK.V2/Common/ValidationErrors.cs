namespace LoginRadiusSDK.V2.Common
{
    public class ValidationErrors
    {
        /// <summary>
        /// Represents request payload error field.
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Represents error message or validation message.  
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
