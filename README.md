# LoginRadius V1 .NET SDK


![Home Image](http://docs.lrcontent.com/resources/github/banner-1544x500.png)

## Introduction ##

LoginRadius ASP.NET Customer Registration wrapper provides access to LoginRadius Identity Management Platform API.

LoginRadius is an Identity Management Platform that simplifies user registration while securing data. LoginRadius Platform simplifies and secures your user registration process, increases conversion with Social Login that combines 30 major social platforms, and offers a full solution with Traditional User Registration. You can gather a wealth of user profile data from Social Login or Traditional User Registration. 

LoginRadius centralizes it all in one place, making it easy to manage and access. Easily integrate LoginRadius with all of your third-party applications, like MailChimp, Google Analytics, Livefyre and many more, making it easy to utilize the data you are capturing.

LoginRadius helps businesses boost user engagement on their web/mobile platform, manage online identities, utilize social media for marketing, capture accurate consumer data, and get unique social insight into their customer base.

Please visit [here](http://www.loginradius.com/) for more information.


## Prerequisites

* .NET 4.0 or later


## Contents ##

* [Demo Application](https://github.com/LoginRadius/dot-net-sdk/tree/api-v1/demo): It contains a basic demo of the SDK
library
* [SDK](https://github.com/LoginRadius/dot-net-sdk/tree/api-v1/LoginRadiusSDK): It contains all the sourced compiled SDK.

## Demo Application

In order to configure the LoginRadius Demo Application and SDK, set your LoginRadius API Key and Secret to **Web.config**.
```
   <appSettings>
    <add key="loginradius:apikey" value="Your LoginRadius_API_Key"/>
    <add key="loginradius:apisecret" value="Your LoginRadius_API_Secret"/>
    <add key="loginradius:sitename" value="Your LoginRadius_Site_Name"/>
    <add key="loginradius:httpProxyCredential" value="Absolute_HTTP_Proxy_URI"/>
    <add key="loginradius:httpProxyAddress" value="Http_Proxy_Credential"/>
</appSettings>
```
or

```
AppCredentials.AppSettingInitialization("key", "secret", "siteName"); 
// Or if you need to set Http Server Proxy Configuration
AppCredentials.AppSettingInitialization("key", "secret", "siteName", "Absolute HTTP Proxy URI", "Http Proxy Credential(Username:Password)");
```

#### Restore NuGet Packages

NuGet is required to acquire any .NET assembly dependency, You need to restore/download the rest of the demo dependencies via NuGet, as they are not yet part of the Demo. These NuGet dependencies contain facades (type forwarders) that point to mscorlib and Libraries.

Right click on Solution in Solution Explorer and click on "Restore Nuget Packages"

## Documentation

* [Getting Started](https://docs.loginradius.com/api/v1/sdk-libraries/aspnet) - Everything you need to begin using this SDK.

* To install LoginRadius - Customer Registration SDK, run the following command in the NuGet Package Manager Console.

```
PM> Install-Package LoginRadiusSDK.V1.NET -Version 3.2.0
```

General documentation regarding the DotNet REST API and related flows can be found on the [LoginRadius API Documentations](http://apidocs.loginradius.com/) site. 