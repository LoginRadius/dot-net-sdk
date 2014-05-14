namespace LoginRadius.SDK.Models.UserProfile
{
    public class LoginRadiusPosition 
    {
        /// <summary>
        /// Facebook : position and Linkedin : <title> node
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Facebook : description and Linkedin : <summary> node
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Facebook : start_date and Linkedin : <start-date> node
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// Facebook : end_date and Linkedin : <end-date> node
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// Facebook : logic (if end date is null then isCurrent true) and Linkedin : <is-current> node
        /// </summary>
        public string IsCurrent { get; set; }


        public LoginRadiusPositionCompany Comapny { get; set; }


        public LoginRadiusPositionCompany Company { get { return Comapny; } }

        /// <summary>
        /// Facebook : work.location
        /// </summary>
        public string Location { get; set; }
    }
}
