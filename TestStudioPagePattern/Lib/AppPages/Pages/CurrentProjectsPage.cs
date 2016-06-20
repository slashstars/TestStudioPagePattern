using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStudioPagePattern.Lib.AppPages.Pages
{
    public class CurrentProjectsPage : BasePage
    {
        private static CurrentProjectsPage _instance;
        public static CurrentProjectsPage Instance
        {
            get
            {
                if (_instance == null) _instance = new CurrentProjectsPage();
                return _instance;
            }
        } 
        private CurrentProjectsPage() { }
    }
}
