
namespace LoginRadiusSDK.Models.Object
{
    public class User
    {
        private string _birthDate;
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = !string.IsNullOrEmpty(value) ? value.Replace("/", "-") : value; }
        }
        public string City { get; set; }
        public string State { get; set; }
        public string Phonenumber { get; set; }
        public string Nickname { get; set; }
        public string Profilename { get; set; }
        public string Website { get; set; }
        public string Hometown { get; set; }
        public string Industry { get; set; }
        public string Relationshipstatus { get; set; }
        public string Languages { get; set; }
        public string Age { get; set; }
        public string Placeslived { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Company { get; set; }
        public string Postalcode { get; set; }
        public string Emailsubscription { get; set; }
        public object Customfields { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string Timezone { get; set; }
        public string About { get; set; }
        public string Webprofiles { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
    }
}