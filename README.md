LoginRadius's DOT Net SDK is used to implement Social Login on your ASP.Net website
=========

Description: LoginRadius's DOT net SDK is a development kit that lets you integrate Social Login through providers such as Facebook, Google, Twitter, and over 20 more on a ASP.Net website. The SDK also fetches user profile data and can be customized from your LoginRadius user account. Ex: social icon sets, login interface, provider settings, etc. The SDK works with C#.Net and VB.Net both languages. You can also use the SDK for your Asp.Net MVC websites.

Download <a href="https://github.com/downloads/LoginRadius/Dot-Net-SDK/LoginRadiusSDKv3.0.NET%202.0.zip">Social Login for ASP.Net-2.0</a><br>
Download <a href="https://github.com/downloads/LoginRadius/Dot-Net-SDK/LoginRadiusSDKv3.0.NET%203.5.zip">Social Login for ASP.Net-3.5</a><br>
Download <a href="https://github.com/downloads/LoginRadius/Dot-Net-SDK/LoginRadiusSDKv3.0.NET%204.0.zip">Social Login for ASP.Net-4.0</a><br>


Steps to implement LoginRadius Asp.Net SDK
===

Step 1: Add SDK file reference and LoginRadiusSDKv2 Namespace

Download and Add SDK's DLL files (LoginRadiusSDKv2.dll, LoginRadiusDataObject.dll and Newtonsoft.Json.dll) to your .Net project and references. Then Add namespace in the code behind file. 

        For C#.Net : using LoginRadiusSDKv2;
        
        For VB.Net : Imports LoginRadiusSDKv2
        
Step 2: Create LoginRadius object in your code behind file.

On the page load event of your callback page, create an object of LoginRadius by passing your unique secret key.

        For C#.Net: LoginRadius loginradius = new LoginRadius('Your API Secret key goes here');
        
        For VB.Net: Dim loginradius As New LoginRadius('Your API Secret key goes here')

Step 3: Validate, authenticate and store data from LoginRadius:

Validate LoginRadius 'IsAuthenticated' property. After successful validation, access user profile data such as ID, FirstName, Email, LastName, BirthDate, Country, NickName, Gender, ProfileName, etc. using GetBasicUserProfile() method. [This step is same for ASP.Net webform as well as MVC pattern]

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