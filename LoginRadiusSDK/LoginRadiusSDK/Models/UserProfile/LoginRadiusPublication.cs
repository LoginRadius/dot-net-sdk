using System.Collections.Generic;

namespace LoginRadiusSDK.Models.UserProfile
{
     public class LoginRadiusPublication 
    {

        public string Id { get; set; }

        public string Title { get; set; }
      
        public string Publisher { get; set; }

        public List<LoginRadiusPublicationsAuthors> Authors { get; set; }
        
        public string Date { get; set; }
       
        public string Url { get; set; }
        
        public string Summary { get; set; }


    }

     public class LoginRadiusPublicationsAuthors
    {
        
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
