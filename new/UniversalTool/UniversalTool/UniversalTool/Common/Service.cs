using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace UniversalTool.Common
{
    public class Service
    {
        static string _serviceUrl = Convert.ToString(ConfigurationManager.AppSettings["ServiceUrl"]);
        static string authenticateDatabase = "authenticateDatabase";
        public static string connectToDatabase(string databaseCredentials)
        {
            
            {
                var url = string.Format("{0}/{1}", _serviceUrl, authenticateDatabase);

                WebClient web = new WebClient();
                string response = web.UploadString(url, databaseCredentials);
                return response;
            }
          
        }
    }
}