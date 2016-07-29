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
			_manager.Settings.ElementWaitTimeout = Configuration.ElementWaitTimeout;
			_manager.Settings.ExecutionDelay = Configuration.ExecutionDelay;
			_manager.Settings.AnnotationMode = Configuration.AnnotationMode;
			_manager.Settings.AnnotateExecution = Configuration.AnnotateExecution;
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
			_manager.Settings.ElementWaitTimeout = Configuration.ElementWaitTimeout;
			_manager.Settings.ExecutionDelay = Configuration.ExecutionDelay;
			_manager.Settings.AnnotationMode = Configuration.AnnotationMode;
			_manager.Settings.AnnotateExecution = Configuration.AnnotateExecution;
			_manager.ActiveBrowser.Close();
            _manager.LaunchNewBrowser();
            #endif
        }

        public static void CleanUp()
        {
            if (_manager == null) return;
			if(_manager.ActiveBrowser != null)
			{
				_manager.ActiveBrowser.ClearCache(BrowserCacheType.Cookies);
				_manager.ActiveBrowser.Close();
			}
            _manager.Dispose();
            _manager = null;
        }
    }
}
