using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRadiusSDK.V2.Models.Configuration
{
    public class SecurityQuestions
    {
        public List<SecurityQuestionGet> Questions { get; set; }
    }

    public class SecurityQuestionGet
    {
        public string QuestionID { get; set; }
        public string Question { get; set; }
    }
}
