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

        public HtmlButton NewUserButton
		{
			get
			{
				return GetByExpression<HtmlButton>("textContent=New User");
			}
		}
		
        public HtmlDiv SuccessAlertDiv
		{
			get
			{
				return GetByExpression<HtmlDiv>(new string[] { "tagname=div", "class=~alert-success" });
			}
		}
		
    }
}
