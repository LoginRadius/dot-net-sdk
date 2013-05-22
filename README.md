LoginRadius library for ASP.NET (C# and VB)
=====
.Net library for the LoginRadius API. Get social authentication, user profile data and send messages using many social network and email clients such as Facebook, Google, Twitter, Yahoo, LinkedIn, etc.

Installation
----
 1. **Font-end interface:** Add social login interface code from your LoginRadius user account to your webpage.
 2. **Call-back setup:** Set-up the callback URL in your LoginRadius user account, this is the URL where user would be redirected after authentication.
 3. **Library set-up and installation:** Add the LoginRadius DLLs into your .Net project and follow the instructions to implement the DLL into your callback page.

Steps to call the library:

     1. Import the Library reference into your code file
     2. Call IsAuthenticated property to check for authentication validation
     3. If success, call GetBasicUserProfile method to get user's profile data.
       [For Premium paid plans: You can call GetUltimateUserProfile method to get Extended user profile data.]
       visit the link for more information to get list of data: https://www.loginradius.com/product/user-profile-data

**Sample code for authentication and get basic profile data**

**C#.Net**

        using LoginRadiusSDK          //Import the library reference

	LoginRadius _loginradius = new LoginRadius("Your-LoginRadius-API-Secret-key"); 
    if(_loginradius.IsAuthenticated) {
    	LoginRadiusBasicUserProfile userprofile = _loginradius.GetBasicUserProfile();
		//fetch all properties for profile data  
          //userprofile.BirthDate -- Birth date of user  
          //if (userprofile.Country != null)  
          //{  
          //    userprofile.Country.Code - country code  
          //    userprofile.Country.Name - country name  
          //}  
          //  
          //Email id generic list   
          //if (userprofile.Email != null)   
          //{  
          //    foreach (var email in userprofile.Email)  
          //    {   
          //        email.Type -- email type (like Primary , Secondary)  
          //        email.Value -- email ID  
          //    }  
          //} 
          //userprofile.FirstName -- first name of user  
          //userprofile.FullName -- full name of user   
          //userprofile.Gender -- gender of user  
          //userprofile.ID -- ID of user on provider   
          //userprofile.LastName -- last name of user  
          //userprofile.MiddleName -- middle name of user  
          //userprofile.NickName -- nick name of user  
          //userprofile.Prefix -- prefix of user's name  
          //userprofile.ProfileName -- screenname/username of user   
          //userprofile.Provider -- provider name from where user has authenticated   
          //userprofile.Suffix -- suffix of user's name
	}

**VB .Net**

	Imports LoginRadiusSDK         //Import the library reference
    If _loginradius.IsAuthenticated Then
	    Dim userprofile As LoginRadiusBasicUserProfile = _loginradius.GetBasicUserProfile()
	     //fetch user profile properties  
          //userprofile.BirthDate -- Birth date of user  
          //if (userprofile.Country != null)  
          //{  
          //    userprofile.Country.Code - country code  
          //    userprofile.Country.Name - country name  
          //}  
          //  
          //Email id generic list   
          //if (userprofile.Email != null)   
          //{  
          //    foreach (var email in userprofile.Email)  
          //    {   
          //        email.Type -- email type (like Primary , Secondary)  
          //        email.Value -- email ID  
          //    }  
          //}  

          //userprofile.FirstName -- first name of user  
          //userprofile.FullName -- full name of user   
          //userprofile.Gender -- gender of user  
          //userprofile.ID -- ID of user on provider   
          //userprofile.LastName -- last name of user  
          //userprofile.MiddleName -- middle name of user  
          //userprofile.NickName -- nick name of user  
          //userprofile.Prefix -- prefix of user's name  
          //userprofile.ProfileName -- screenname/username of user   
          //userprofile.Provider -- provider name from where user has authenticated   
          //userprofile.Suffix -- suffix of user's name
    End If

**Sample code to get Extended user profile (Only for Paid plans - Premium)**

**C#.Net**

    if(_loginradius.IsAuthenticated)
    	var userprofile = _loginradius.GetUltimateUserProfile();

**VB .Net**

    If _loginradius.IsAuthenticated Then
    	Dim userprofile As LoginRadiusUltimateUserProfile = _loginradius.GetUltimateUserProfile()
    End If

**Tip-1:** If you are using MVC then use Post attribute in Action.

**Tip-2:** Few providers like Twitter doesn't provide email address with User Profile data, so you need to handle these cases in your callback page.


Advance features(for Paid customers only)
===

LoginRaidus Contacts API
-----
You can use this API to fetch contacts from users social networks/email clients - Facebook, Twitter, LinkedIn, Google, Yahoo.

> LoginRadius generate a unique session token, when user logs in with
> any of social network. The lifetime of LoginRadius token is 15 mins, get/Save this Token to call this API.

**C#.Net**

    LoginRadiusSDK.LoginRadiusGetContacts LRContacts = new LoginRadiusSDK.LoginRadiusGetContacts ("-LoginRadius-session-Token-", "-Your-LoginRadius-Secret-key-");
    
               	var contactlist = LRContacts.Getcontacts();
               	if (contactlist!= null) {
                   	foreach (var contact in contactlist) {
    		             //contact.ID  - Contact ID
       	                 //contact.Name – Contact Name
     		             //contact.EmailID – Contact EmailId
    		             //contact.Gender – Contact Gender
    		             //contact.PhoneNumber – Contact PhoneNumber
    		             //contact.Status – Contact Status
    		             //contact.Industry – Contact Industry
                         //contact.ImageUrl – Contact Image Url    			
                         //contact.ProfileUrl –Contact Profile Url
                   	}
              }

**​VB.Net**

    Dim LRContacts As New LoginRadiusSDK.LoginRadiusGetContacts
    ("-LoginRadius-Session-Token--","-Your-LoginRadius-Secret-Key-")
    Dim contactlist As LoginRadiusSDK.LoginRadiusGetContacts = 
    LRContacts.Getcontacts()
    If (contactlist.IsNot Nothing) Then
    	For Each contact As String In contactlist
    	      'contact.ID  - Contact ID
      	      'contact.Name - Contact Name
              'contact.EmailID - Contact EmailId
              'contact.Gender - Contact Gender
              'contact.PhoneNumber - Contact PhoneNumber
              'contact.Status - Contact Status
              'contact.Industry - Contact Industry
              'contact.ImageUrl - Contact Image Url    
              'contact.ProfileUrl - Contact Profile Url
            Next 
     End If


LoginRadius Post API
---
You can use this API to Post data to users social networks/email - Facebook, Twitter, LinkedIn, Google, Yahoo.

> LoginRadius generate a unique session token, when user logs in with
> any of social network. The lifetime of LoginRadius token is 15 mins, get/Save this Token to call this API.

**C#.Net**

    LoginRadiusSDK.LoginRadiusStatus
    lrstatusmessage = new LoginRadiusSDK.LoginRadiusStatus
    ('LoginRadius-session-token', 'Your-LoginRadius-Secret-key');
    
     bool directmessage = lrstatusmessage.UpdateStatus(“To”,”Title”,”Url”,”imageurl-”,”status”,”caption”,”description”);
     string success =””;
            if (directmessage) {
              	 success = "Your message has send successfully.";
       		}
          	else {
               	 success = "Message sending failed.";
       		}

**VB .Net**

    Dim lrstatusmessage As New LoginRadiusSDK.LoginRadiusStatus  (‘LoginRadius-session-token’,'Your-LoginRadius-Secret-Key')
    
    Dim contactlist As LoginRadiusSDK.LoginRadiusStatus = lrContect.Getcontacts()
               	If (contactlist.IsNot Nothing) then
    For Each contact As String In contactlist
     bool directmessage = lrstatusmessage.UpdateStatus(“To”,”Title”,”Url”,”imageurl-”,”status”,”-caption-”,”-description-”) string success =””;
          If directmessage.IsNot Nothing Then
     	if directmessage = true Then
              success = "Your message has send successfully."
          	Else
              success = "Message sending failed."
            End If
          End If


Get Posts
--
You can use this API to get posts from users social network - Facebook

> LoginRadius generate a unique session token, when user logs in with
> any of social network. The lifetime of LoginRadius token is 15 mins, get/Save this Token to call this API.

**C#.Net**

    LoginRadiusSDK.LoginRadiusPosts lrPost= new
    LoginRadiusSDK.LoginRadiusPosts ("LoginRadius-session-token", "Your-LoginRadius-API-secret-key");  
       	
    var PostList = lrPost.GetPosts();    
          If (PostList!= null) {
             //fetch all properties like
    	     foreach (var itemPost in PostList) {
    		      // itemPost.ID       	-- id of Post
    		      // itemPost.Place    	-- Place of Post
    		      // itemPost.Name     	-- Name of Post
    		      // itemPost.Likes    	-– Likes of Post
    		      // itemPost.StartTime	-- Start Time of Post
    		      // itemPost.Message  	-- Message of Post
    		      // itemPost.Picture  	-- Picture in Post
    		      // itemPost.Title    	-– Title of Post
    		      // itemPost.Share    	-- Share  of Post
    		      // itemPost.UpdateTime   -- UpdateTime of Post
    	       }     
        }

**VB .Net**

    Dim lrPost As New LoginRadiusSDK.LoginRadiusPosts  ("LoginRadius-session-Token","Your-LoginRadius-Secret-key")
       
    Dim lrPost As LoginRadiusSDK.LoginRadiusPosts = lrContect.GetPosts()	
    	If (PostList.IsNot Nothing) then
               'fetch all properties like
    	   For Each itemPost As String In PostList
    		'itemPost.ID -- id of Post
    		'itemPost.Place -- Place of Post
    		'itemPost.Name  -- Name of Post
    		'itemPost.Likes -- Likes of Post
    		'itemPost.StartTime -- Start Time of Post
    		'itemPost.Message  -- Message of Post
    		'itemPost.Picture -- Picture in Post
    		'itemPost.Title -- Title of Post
    		'itemPost.Share -- Share  of Post
    		'itemPost.UpdateTime -- UpdateTime of Post
    	 Next   
         End If


Get Twitter Mentions
--

You can use this API to get mentions from users social network - Twitter.

> LoginRadius generate a unique session token, when user logs in with
> any of social network. The lifetime of LoginRadius token is 15 mins, get/Save this Token to call this API.

**C#.Net**

    LoginRadiusSDK.LoginRadiusGetMention lrMention = new
    LoginRadiusSDK.LoginRadiusGetMention ("LoginRadius-session-Token","Your-LoginRadius-Secret-key");   
         	
    Var MentionList= lrMention.GetMention ();
     If (MentionList!= null)
     {
      	//fetch all properties like
            foreach (var itemMention in MentionList)
            {
    		// itemMention.ID    	-- id of Mention
    		// itemMention.Place 	-- Place of Mention
    		// itemMention.Name  	-- Name of Mention
    		// itemMention.Text  	-– Text of Mention
    		// itemMention.DateTime -- DateTime  of Mention
    		// itemMention.ImageUrl  -- ImageUrl in Mention
    		// itemMention.Likes 	-- Likes of Mention
    		// itemMention.LinkUrl   -– LinkUrl of Mention
    		// itemMention.Source	-- Source  of Mention
                     	
             }
    }

**VB.Net**

    Dim  lrMention As New LoginRadiusSDK.LoginRadiusGetMention("LoginRadius-session-Token","Your-LoginRadius-Secret-key")
    Dim MentionList As LoginRadiusSDK.LoginRadiusGetMention = lrMention.GetMention ()
     If (MentionList.IsNot Nothing) then
       'fetch all properties like
        For Each itemMention As String In MentionList
         itemMention.ID  -- id of Mention
         itemMention.Place -- Place of Mention
         itemMention.Name -- Name of Mention
         itemMention.Text -- Text of Mention
         itemMention.DateTime -- DateTime  of Mention
         itemMention.ImageUrl -- ImageUrl in Mention
         itemMention.Likes -- Likes of Mention
         itemMention.LinkUrl -- LinkUrl of Mention
         itemMention.Source	-- Source  of Mention
                     	
        Next
    End If


Facebook Groups
--
You can use this API to get groups from users social network - Facebook.

> LoginRadius generate a unique session token, when user logs in with
> any of social network. The lifetime of LoginRadius token is 15 mins, get/Save this Token to call this API.

**C#.Net**

    LoginRadiusSDK.LoginRadiusGetGroups lrGroups= new
    LoginRadiusSDK. LoginRadiusGetGroups ("LoginRadius-session-Token","Your-LoginRadius-Secret-key");   
         	
    Var GroupList= lrGroups.GetGroups ();
    	If (GroupList!= null)
            {
               //fetch all properties like
    	   foreach (var itemGroups in GroupList)
               {
    		// itemEvent.ID -- id of event
    		// itemEvent.Name -- Name of Event
               }
            }

**VB.Net**

    Dim lrGroups As New LoginRadiusSDK.LoginRadiusGetGroups  ("LoginRadius-session-Token","Your-LoginRadius-Secret-key")  
         
    Dim GroupList As LoginRadiusSDK.LoginRadiusGetGroups = lrGroups.GetGroups ()
      If (GroupList.IsNot Nothing) then
           'fetch all properties like
    	For Each itemGroups As String In GroupList
    		'itemEvent.ID -- id of event
                    'itemEvent.Name -- Name of Event
            Next
      End if


Get LinkedIn follow companies
--
You can use this API to get followed companies list from users social network - LinkedIn.

> LoginRadius generate a unique session token, when user logs in with
> any of social network. The lifetime of LoginRadius token is 15 mins, get/Save this Token to call this API.

**C#.Net**

    LoginRadiusSDK.LoginRadiusGetCompaines lrfollowcompanies = new LoginRadiusSDK.LoginRadiusGetCompaines ("LoginRadius-session-Token","Your-LoginRadius-Secret-key");
     Var companylist = lrfollowcompanies.GetFollowCompaines();
      If (companylist!= null)
      {
         foreach (var followcompany in companylist)
         {
    	//followcompany.ID  - followcompany ID
            //followcompany.Name – followcompany Name	
         }
       }

**VB.Net**

    Dim lrfollowcompanies As New LoginRadiusSDK.LoginRadiusGetCompaines  ("LoginRadius-session-Token","Your-LoginRadius-Secret-key")
    Dim companylist As LoginRadiusSDK.LoginRadiusGetCompaines = lrfollowcompanies.GetFollowCompaines()
      If (companylist.IsNot Nothing) then
    	For Each followcompany As String In companylist
                'followcompany.ID  - followcompany ID
                'followcompany.Name - followcompany Name	
            Next
       End If

Get Facebook events
--
You can use this API to get events from users social network - Facebook.

> LoginRadius generate a unique session token, when user logs in with
> any of social network. The lifetime of LoginRadius token is 15 mins, get/Save this Token to call this API.

**C#.Net**

    LoginRadiusSDK.LoginRadiusGetEvents lrEvent = new
    LoginRadiusSDK.LoginRadiusGetEvents ("LoginRadius-session-Token","Your-LoginRadius-Secret-key");       
    Var EventList= lrEvent.GetEvents ();
    
        If (EventList!= null)
        {
           //fetch all properties like
           foreach (var itemEvent in EventList)
           {
     	  //itemEvent.ID     	-- id of event
     	 //itemEvent.Location   -- location of event
            //itemEvent.Name   	-- Name of Event
            //itemEvent.RsvpStatus -– Status of event
            //itemEvent.StartTime  -- Start Time of Event
                    	
            }
        }

**VB .Net**

    Dim lrEvent As New LoginRadiusSDK.LoginRadiusGetEvents  ("LoginRadius-session-Token","Your-LoginRadius-Secret-key")   
    Dim EventList As LoginRadiusSDK.LoginRadiusGetEvents = lrEvent.GetEvents ()
    	If (EventList.IsNot Nothing) then
               'fetch all properties like
    	   For Each itemEvent As String In EventList
    		'itemEvent.ID -- id of event
    		'itemEvent.Location -- location of event
    		'itemEvent.Name -- Name of Event
    		'itemEvent.RsvpStatus -- Status of event
    		'itemEvent.StartTime  -- Start Time of Event
    	    Next
          End If

Get Status
---
You can use this API to get status messages from users social network - Facebook.

> LoginRadius generate a unique session token, when user logs in with
> any of social network. The lifetime of LoginRadius token is 15 mins, get/Save this Token to call this API.

**C#.Net**

    LoginRadiusSDK.LoginRadiusStatus lrstatus = new LoginRadiusSDK.LoginRadiusStatus ("LoginRadius-session-Token","Your-LoginRadius-Secret-key");
       Var statuslist = lrstatus. GetStatuses ();
             If (statuslist!= null)
             {
               foreach (var status in statuslist)
      	   {
                 // status.ID  - status ID
                 // status.ImageUrl– status Image Url  
    	    // status.Likes – status Likes
                // status.Text – status Text
                // status.LinkUrl – status LinkUrl
    	    // status.Place – status place
                // status.Source – status source
                       	
               }
             }

**VB .Net**

    Dim lrstatus As New LoginRadiusSDK.LoginRadiusStatus  ("LoginRadius-session-Token","Your-LoginRadius-Secret-key")
    Dim lrstatusAs LoginRadiusSDK.LoginRadiusStatus =lrstatus. GetStatuses ()
       If (statuslist.IsNot Nothing) then
    	For Each status As String In statuslist
                 'status.ID  - status ID
                 'status.ImageUrl- status Image Url  
    	     'status.Likes - status Likes
     'status.Text - status Text
     	     'status.LinkUrl - status LinkUrl
    	     'status.Place - status place
    	     'status.Source - status source	
             Next
        End If


Get TimeLine
--
Saved/Get Your LoginRadius Token That LoginRadius Provide You When You Login   , authenticate from LoginRadius .

**C#.Net**

    LoginRadiusSDK.LoginRadiusGetTimeLine
    lrtimeline = new LoginRadiusSDK.LoginRadiusGetTimeLine ("LoginRadius-session-Token","Your-LoginRadius-Secret-key");
    	Var timelinelist = lrtimeline.GetTimeLine();
            If (timelinelist!= null)
            {
              foreach (var timeline in timelinelist)
              {
    		// timeline.ID  - timeline ID
    		// timeline.ImageUrl– timeline Image Url  	
    		// timeline.Likes – timeline Likes
    	 	// timeline.Text – timeline Text
    		// timeline.LinkUrl – timeline LinkUrl
    		// timeline.Place – timeline place
    		// timeline.Source – timeline source
               }
            }

**VB.Net**

    Dim lrtimeline As New LoginRadiusSDK.LoginRadiusGetTimeLine ("LoginRadius-session-Token","Your-LoginRadius-Secret-key")
    
    Dim timelinelist As LoginRadiusSDK.LoginRadiusGetTimeLine =  lrtimeline.GetTimeLine()
           If (timelinelist.IsNot Nothing) then
           	For Each timeline As String In timelinelist
    	   'timeline.ID  - timeline ID
     	   'timeline.ImageUrl- timeline Image Url  	
    	   'timeline.Likes - timeline Likes
    	   'timeline.Text - timeline Text
    	   'timeline.LinkUrl - timeline LinkUrl
     	   'timeline.Place - timeline place
    	   'timeline.Source - timeline source
             Next
           End If

**Request:** Please let us know your feedback and comments. If you have any questions or need a further assistance please contact us at hello@loginradius.com.
