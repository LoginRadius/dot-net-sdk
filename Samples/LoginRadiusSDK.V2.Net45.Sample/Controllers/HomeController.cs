using System.Collections.Generic;
using System.Web.Mvc;
using LoginRadiusSDK.V2.Api;


namespace LoginRadiusSDK.V2.Net45.Sample.Controllers
{
    public class HomeController : Controller
    {
        private const string AccessTokenKey = "access_token";

        // GET: Home
        public ActionResult Index()
        {
            // Uncomment to set SDK configuration explicitly. 
            //LoginRadiusSdkGlobalConfig.ApiKey = "";
            //LoginRadiusSdkGlobalConfig.ApiSecret = "";
            //LoginRadiusSdkGlobalConfig.AppName = "";

            // In order to set Request Retries uncomment below line. 
            //LoginRadiusSdkGlobalConfig.RequestRetries = 3;
            var sott = new AccountManagementEntity().GetSott(30);

            ViewBag.Sott = sott.RestException == null ? sott.Response.Sott : null;
            return View();
        }

        [HttpPost]
        public JsonResult GetUserProfile(string token)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                Session[AccessTokenKey] = token;
            }
           
            var api = new AccountEntity();
            var apiResponse = api.GetProfile(token);
            return Json(apiResponse);
        }
    }

}