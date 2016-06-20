using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStudioPagePattern.Lib.AppPages.Modals;
using TestStudioPagePattern.Lib.AppPages.Pages;

namespace TestStudioPagePattern.Lib.AppPages
{
    public static class AppPages
    {
        public static NewUserPage NewUserPage => NewUserPage.Instance;
        public static CurrentProjectsPage CurrentProjectsPage => CurrentProjectsPage.Instance;
        public static ManageUsersPage ManageUsersPage => ManageUsersPage.Instance;
        public static LogInModal LogInModal => LogInModal.Instance;
    }
}
