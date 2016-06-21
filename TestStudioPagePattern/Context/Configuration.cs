using ArtOfTest.WebAii.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStudioPagePattern.Context
{
    public static class Configuration
    {
        public static BrowserType DefaultBrowser
        {
            get
            {
                string defaultBrowserString = ConfigurationManager.AppSettings["defaultBrowser"];
                if (defaultBrowserString == null || defaultBrowserString.Trim() == string.Empty)
                {
                    defaultBrowserString = "FireFox";
                }
                if (defaultBrowserString == "FireFox") return BrowserType.FireFox;
                if (defaultBrowserString == "Chrome") return BrowserType.Chrome;
                if (defaultBrowserString == "Safari") return BrowserType.Safari;
                if (defaultBrowserString == "InternetExplorer") return BrowserType.InternetExplorer;

                throw new Exception("Unsupported defaultBrowser. defaultBrowser should be one of the following: FireFox, Chrome, Safari, InternetExplorer.");
            }
        }

        public static string BaseUrl
        {
            get
            {
                string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
                if (baseUrl == null || baseUrl.Trim() == string.Empty)
                {
                    baseUrl = "http://localhost:3000";
                }

                return baseUrl;
            }
        }
    }
}
