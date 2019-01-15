using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginRadiusSDK.V2.Api;
using LoginRadiusSDK.V2.Models;
using LoginRadiusSDK.V2.Models.CustomerAuthentication.Login;
using LoginRadiusSDK.V2.Models.UserProfile;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_demo.Controllers
{
    public class TestController : Controller
    {
        LoginRadiusApiOptionalParams _apiOptionalParams = new LoginRadiusApiOptionalParams();
        public IActionResult Whoo()
        {
            LoginRadiusApiOptionalParams apiOptionalParams = new LoginRadiusApiOptionalParams();
            apiOptionalParams.VerificationUrl = "";
            apiOptionalParams.G_Recaptcha_Response = "";

            UserNameLoginModel userNameLoginModel = new UserNameLoginModel { username = "XXX", password = "xxxx" };
            var apiresponse = new AuthenticationApi().LoginByUserName(userNameLoginModel.ConvertToJson(), apiOptionalParams);

            return null;
        }
        
    }
}