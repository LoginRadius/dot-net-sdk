// -----------------------------------------------------------------------
// <copyright file="LoginRadiusCustomInterface.cs" company="LoginRadius">
// Copyright Loginradius 2011-2012
// </copyright>
// -----------------------------------------------------------------------
using System;
using LoginRadiusDataObject.CustomInterface.Model;
using System.Net;

namespace LoginRadiusSDK
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LoginRadiusCustomInterface
    {
        readonly InterfaceModel interfacemodel = new InterfaceModel();

        public LoginRadiusCustomInterface(string apikey)
        {
            if (Extensions.IsGuid(apikey))
            {
                string url = string.Format("https://devhub.loginradius.com/getinterfaceinfo/{0}", apikey);

                WebClient webclient = new WebClient();

                string interfaceresponse = webclient.DownloadString(url);
               
                interfacemodel = (InterfaceModel)Newtonsoft.Json.JsonConvert.DeserializeObject(interfaceresponse, typeof(InterfaceModel));
            }
            else
            {
                throw new Exception("Invalid Api key please use valid Guid format api key");
            }
        }

        public InterfaceModel InterfaceModel
        {
            get
            {
                return this.interfacemodel;
            }
        }
    }
}