using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginradiusSdk.Entity.AppSettings
{
    public static class LoginRadiusAppSettings
    {
        private static string _AppKey;
        private static string _AppSecret;
        private static string _AppName;

        public static void AppSettingInitialization(string AppKey, string AppSecret, string AppName)
        {
            _AppKey = AppKey;
            _AppSecret = AppSecret;
            _AppName = AppName;
        }

        public static string AppKey
        {
            get
            {
                if (string.IsNullOrEmpty(_AppKey))
                {
                    _AppKey = ConfigurationManager.AppSettings["loginradius:apikey"];
                    if (string.IsNullOrEmpty(_AppKey))
                    {
                        throw new Exception("apikey not found in application.json");
                    }
                }
                return _AppKey;
            }
            set { _AppKey = value; }
        }

        public static string AppSecret
        {
            get
            {
                if (string.IsNullOrEmpty(_AppSecret))
                {
                    _AppSecret = ConfigurationManager.AppSettings["loginradius:apisecret"];
                    if (string.IsNullOrEmpty(_AppSecret))
                    {
                        throw new Exception("apisecret not found in application.json");
                    }
                }
                return _AppSecret;
            }
            set { _AppSecret = value; }
        }

        public static string AppName
        {
            get
            {
                if (string.IsNullOrEmpty(_AppName))
                {
                    _AppName = ConfigurationManager.AppSettings["loginradius:appname"];
                    if (string.IsNullOrEmpty(_AppName))
                    {
                        throw new Exception("appname not found in application.json");
                    }
                }
                return _AppName;
            }

            set { _AppName = value; }
        }
    }
}