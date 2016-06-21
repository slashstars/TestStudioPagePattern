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

        /// <summary>
        /// Initialize context. Intended for use by NUnit runner.
        /// </summary>
        public static void Initialize()
        {
            if (_manager != null) CleanUp();
            _manager = new Manager(true);
            _manager.Settings.Web.DefaultBrowser = Configuration.DefaultBrowser;
            _manager.Settings.Web.BaseUrl = Configuration.BaseUrl;
            _manager.Start();
            _manager.LaunchNewBrowser();
        }

        /// <summary>
        /// Initialize context. Intended for use by Test Studio runner.
        /// </summary>
        public static void Initialize(Manager manager)
        {
            if (_manager != null) CleanUp();
            
            _manager = manager;
            #if DEBUG
            _manager.Settings.Web.DefaultBrowser = Configuration.DefaultBrowser;
            _manager.Settings.Web.BaseUrl = Configuration.BaseUrl;            
            _manager.ActiveBrowser.Close();
            _manager.LaunchNewBrowser();
            #endif
        }

        public static void CleanUp()
        {
            if (_manager == null) return;
            _manager.ActiveBrowser?.ClearCache(BrowserCacheType.Cookies);
            _manager.ActiveBrowser?.Close();
            _manager.Dispose();
            _manager = null;
        }
    }
}
