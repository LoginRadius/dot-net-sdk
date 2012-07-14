LoginRadius's DOT Net SDK is used to implement Social Login on your ASP.Net website

Description: LoginRadius's DOT net SDK is a development kit that lets you integrate Social Login through providers such as Facebook, Google, Twitter, and over 20 more on a ASP.Net website. The SDK also fetches user profile data and can be customized from your LoginRadius user account. Ex: social icon sets, login interface, provider settings, etc. The SDK works with C#.Net and VB.Net both languages. You can also use the SDK for your Asp.Net MVC websites.

Steps to implement LoginRadius Asp.Net SDK:

Step 1: Add SDK file reference and LoginRadiusSDKv2 Namespace

        Add SDK references in web project or LoginRadiusSDK.dll, LoginRadiusDataObject.dll and Newtonsoft.Json.dll to the bin directory (in visual studio website project).
        Add namespace in the code behind file 
        For C#.Net : using LoginRadiusSDKv2;
        For VB.Net : Imports LoginRadiusSDKv2
        
Step 2: Validate, authenticate and store data from LoginRadius [This step is same for ASP.Net webform as well as MVC pattern]

        On the page load event of your callback page, create an object of LoginRadius by passing your unique secret key.
        For C#.Net: LoginRadius loginradius = new LoginRadius('Your API Secret key goes here');
        For VB.Net: Dim loginradius As New LoginRadius('Your API Secret key goes here')

Step 3: Validate LoginRadius 'IsAuthenticated' property. After successful validation, access user profile data such as ID, FirstName, Email, LastName, BirthDate, Country, NickName, Gender, ProfileName, etc. using GetBasicUserProfile() method.
        For C#.Net: 
        
        LoginRadiusSDKv2.LoginRadius loginradius = new LoginRadiusSDKv2.LoginRadius("Your API Secret key goes here");
        if (loginradius.IsAuthenticated) {  
              LoginRadiusDataModal.LoginRadiusDataObject.Objects.BasicUserLoginRadiusUserProfile userprofile = loginradius.GetBasicUserProfile();  
              //fetch all properties like  
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

          For VB.Net:
          
          Dim loginradius As New LoginRadiusSDKv2.LoginRadius("Your API Secret key goes here")    
          If loginradius.IsAuthenticated Then
               Dim userprofile As LoginRadiusDataModal.LoginRadiusDataObject.Objects.BasicUserLoginRadiusUserProfile = loginradius.GetBasicUserProfile()  
              'fetch all properties like  
              'userprofile.BirthDate -- Birth date of user  
              'If userprofile.Country != null  
              '  
              '    userprofile.Country.Code - country code  
              '    userprofile.Country.Name - country name  
              'End If  
              '  
              'Email id generic list   
              'If userprofile.Email != null   
              '  
              '    For Each email In userprofile.Email  
              '       
              '        email.Type -- email type (like Primary , Secondary)  
              '        email.Value -- email ID  
              '    Next email     
              '      
              'End If  
            
              'userprofile.FirstName -- first name of user  
              'userprofile.FullName -- full name of user   
              'userprofile.Gender -- gender of user  
              'userprofile.ID -- ID of user on provider   
              'userprofile.LastName -- last name of user  
              'userprofile.MiddleName -- middle name of user  
              'userprofile.NickName -- nick name of user  
              'userprofile.Prefix -- prefix of user's name  
              'userprofile.ProfileName -- screenname/username of user   
              'userprofile.Provider -- provider name from where user has authenticated   
              'userprofile.Suffix -- suffix of user's name  
          End If
Note: Few providers like Twitter, LinkedIn, etc. doesn't provide email address with User Profile data, so you need to handle these cases in your callback page.

These are the quick and easy steps to integrate Social Login on your ASP.Net website, if you have any questions or need a further assistance please contact us at hello@loginradius.com.