// -----------------------------------------------------------------------
// <copyright file="LoginRadiusContact.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace LoginRadiusSDK.Models.Comment
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LoginRadiusComment 
    {
       public string CommentId
        {
            get;
            set;
        }

       public string Published
        {
            get;
            set;
        }
       public string Updated
        {
            get;
            set;
        }

       public string Name
        {
            get;
            set;
        }

       public string ProfileUrl
        {
            get;
            set;
        }

       public string ImageUrl
        {
            get;
            set;
        }

       public string UserId
        {
            get;
            set;
        }
       public string Type
        {
            get;
            set;
        }
       public string Comment
        {
            get;
            set;
        }

       public List<ReplyList> ReplyList { get; set; }

    }
    public class ReplyList
    {
        public string ReplyId
        {
            get;
            set;
        }
        public string ReplyUrl
        {
            get;
            set;
        }
    }
    
}
