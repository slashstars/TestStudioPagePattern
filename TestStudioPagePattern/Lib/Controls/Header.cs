using ArtOfTest.WebAii.Controls.HtmlControls;
using TestStudioPagePattern.Lib.Base;

namespace TestStudioPagePattern.Lib.Controls
{
    public class Header : BaseAutomation
    {
        public Header()
        {
            scopeFindExpression = new string[] { "tagname=div", "ng-controller=HeaderCtrl"};
        }

        public HtmlButton LogInButton => GetByExpression<HtmlButton>(new string[] { "tagname=button", "textContent=Log in" });
        public HtmlButton LogOutButton => GetByExpression<HtmlButton>(new string[] { "tagname=button", "class=~logout" });
        public HtmlAnchor AdminLink => GetByExpression<HtmlAnchor>("id=adminmenu");
        public HtmlAnchor ManageUsersLink => GetByExpression<HtmlAnchor>("textContent=Manage Users");
    }
}
