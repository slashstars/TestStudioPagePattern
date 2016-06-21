using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStudioPagePattern.Context;
using TestStudioPagePattern.Lib;
using TestStudioPagePattern.Lib.AppPages;
using TestStudioPagePattern.Lib.BusinessObjects;

namespace TestStudioPagePattern.Tests.NUnit
{
    [TestFixture]
    public class CreateUserTestFixture
    {
        [Test]
        public void CreateUserTest()
        {
            var admin = new User
            {
                Email = "admin@abc.com",
                Password = "changeme"
            };
            var newUser = new User
            {
                Email = "jane.doe@email.com",
                FirstName = "Jane",
                LastName = "Doe",
                Password = "1234567890",
                IsAdmin = true
            };
            AutomationContext.Manager.ActiveBrowser.NavigateTo("/");
                        
            AppPages.CurrentProjectsPage
                .Header
                .LogInButton.CheckEnabledAndClick();
           
            AppPages.LogInModal
                .PopulateUser(admin)
                .SignInButton.CheckEnabledAndClick();

            AppPages.CurrentProjectsPage.Header.LogOutButton.Wait.ForVisible();

            AppPages.CurrentProjectsPage
                .Header
                .AdminLink.Click();

            AppPages.CurrentProjectsPage
                .Header
                .ManageUsersLink.Click();

            AppPages.ManageUsersPage
                .NewUserButton.CheckEnabledAndClick();

            AppPages.NewUserPage
                .PopulateUser(newUser)
                .SaveButton.CheckEnabledAndClick();

            AppPages.ManageUsersPage.SuccessAlertDiv.Wait.ForVisible();
        }
    }
}
