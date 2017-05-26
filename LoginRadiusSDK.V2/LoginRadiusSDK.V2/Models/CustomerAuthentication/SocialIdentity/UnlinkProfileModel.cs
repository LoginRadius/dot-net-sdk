using LoginRadiusSDK.V2.Util.Serialization;

namespace LoginRadiusSDK.V2.Models
{
    public class UnlinkProfileModel : LoginRadiusSerializableObject
    {
        public string Provider { get; set; }
        public string ProviderId { get; set; }
    }
}