using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Design;
using ArtOfTest.WebAii.Design.Execution;
using TestStudioPagePattern.Context;
using TestStudioPagePattern.Lib.AppPages;
using TestStudioPagePattern.Lib.BusinessObjects;
using TestStudioPagePattern.Lib;

namespace TestStudioPagePattern.Tests.TestStudio
{

    public class CreateUserTest : BaseWebAiiTest
    {
        #region [ Dynamic Pages Reference ]

        private Pages _pages;

        /// <summary>
        /// Gets the Pages object that has references
        /// to all the elements, frames or regions
        /// in this project.
        /// </summary>
		public Pages Pages
		{
			get
			{
				if (_pages == null)
				{
					_pages = new Pages(Manager.Current);
				}
				return _pages;
			}
        }

        [CodedStep(@"New Coded Step")]
        public void CreateUserTest_CodedStep()
        {
            AutomationContext.Initialize(Manager);

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

        #endregion

        // Add your test methods here...
    }
}
