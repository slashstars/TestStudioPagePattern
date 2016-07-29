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

		public static int ExecutionDelay
		{
			get
			{
				string executionDelay = ConfigurationManager.AppSettings["executionDelay"];
				int result;
				if(Int32.TryParse(executionDelay, out result))
				{
					return result;
				}
				return 0;
			}
		}

		public static int ElementWaitTimeout
		{
			get
			{
				string elementWaitTimeout = ConfigurationManager.AppSettings["elementWaitTimeout"];
				int result;
				if (Int32.TryParse(elementWaitTimeout, out result))
				{
					return result;
				}
				return 0;
			}
		}

		public static bool AnnotateExecution
		{
			get
			{
				string annotateExecution = ConfigurationManager.AppSettings["annotateExecution"];
				bool result;
				if (Boolean.TryParse(annotateExecution, out result))
				{
					return result;
				}
				return false;
			}
		}

		public static AnnotationMode AnnotationMode
		{
			get
			{
				string annotationMode = ConfigurationManager.AppSettings["annotationMode"];
				if (annotationMode == null || annotationMode.Trim() == string.Empty)
				{
					annotationMode = "All";
				}
				if (annotationMode == "All") return AnnotationMode.All;
				if (annotationMode == "NativeOnly") return AnnotationMode.NativeOnly;
				if (annotationMode == "CustomOnly") return AnnotationMode.CustomOnly;

				throw new Exception("Unsupported annotationMode. annotationMode should be one of the following: All, NativeOnly, CustomOnly.");
			}
		}
	}
}
