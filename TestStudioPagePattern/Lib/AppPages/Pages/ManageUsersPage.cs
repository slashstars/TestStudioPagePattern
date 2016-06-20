using ArtOfTest.WebAii.Controls.HtmlControls;

namespace TestStudioPagePattern.Lib.AppPages.Pages
{
    public class ManageUsersPage : BasePage
    {
        private static ManageUsersPage _instance;
        public static ManageUsersPage Instance
        {
            get
            {
                if (_instance == null) _instance = new ManageUsersPage();
                return _instance;
            }
        }

        private ManageUsersPage() { }

        public HtmlButton NewUserButton => GetByExpression<HtmlButton>("textContent=New User");
        public HtmlDiv SuccessAlertDiv => GetByExpression<HtmlDiv>(new string[] { "tagname=div", "class=~alert-success" });
    }
}
