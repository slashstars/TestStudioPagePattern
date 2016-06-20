using ArtOfTest.WebAii.Core;
using System;
using System.Configuration;

namespace TestStudioPagePattern.Context
{
    public static class AutomationContext
    {
        private static Manager _manager;
        public static Manager Manager
        {
            get
            {
                return _manager;
            }
        }

        public static void Initialize()
        {
            if (_manager != null) CleanUp();
            _manager = new Manager(true);
            _manager.Settings.Web.DefaultBrowser = GetDefaultBrowser();

            string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
            if(baseUrl != null && baseUrl.Trim() != string.Empty)
            {
                _manager.Settings.Web.BaseUrl = baseUrl;
            }
            _manager.Start();
        }

        public static void Initialize(Manager manager)
        {
            if (_manager != null) CleanUp();
            _manager = manager;
        }

        public static void CleanUp()
        {
            if (_manager == null) return;
            _manager.ActiveBrowser?.ClearCache(BrowserCacheType.Cookies);
            _manager.ActiveBrowser?.Close();
            _manager.Dispose();
            _manager = null;
        }

        private static BrowserType GetDefaultBrowser()
        {
            string defaultBrowserString = ConfigurationManager.AppSettings["defaultBrowser"];
            if (defaultBrowserString == "FireFox") return BrowserType.FireFox;
            if (defaultBrowserString == "Chrome") return BrowserType.Chrome;
            if (defaultBrowserString == "Safari") return BrowserType.Safari;
            if (defaultBrowserString == "InternetExplorer") return BrowserType.InternetExplorer;

            throw new Exception("Unsupported defaultBrowser. defaultBrowser should be one of the following: FireFox, Chrome, Safari, InternetExplorer.");

        }
    }
}
