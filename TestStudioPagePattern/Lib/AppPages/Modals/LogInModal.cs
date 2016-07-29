using ArtOfTest.WebAii.Controls.HtmlControls;
using TestStudioPagePattern.Lib.BusinessObjects;

namespace TestStudioPagePattern.Lib.AppPages.Modals
{
    public class LogInModal : BaseModal
    {
        private static LogInModal _instance;
        public static LogInModal Instance
        {
            get
            {
                if (_instance == null) _instance = new LogInModal();
                return _instance;
            }
        }

        private LogInModal() { }

        public HtmlInputEmail EmailTextbox
		{
			get
			{
				return GetByExpression<HtmlInputEmail>("name=login");
			}			
		}
        public HtmlInputPassword PasswordTextbox
		{
			get
			{
				return GetByExpression<HtmlInputPassword>("name=pass");
			}
		}
		public HtmlButton SignInButton
		{
			get
			{
				return GetByExpression<HtmlButton>(new string[] { "tagname=button", "class=~login" });
			}
		}		
        public HtmlButton ClearButton
		{
			get
			{
				return GetByExpression<HtmlButton>(new string[] { "tagname=button", "class=~clear" });
			}
		}			
        public HtmlButton CancelButton
		{
			get
			{
				return GetByExpression<HtmlButton>(new string[] { "tagname=button", "class=~cancel" });
			}
		}		

        public LogInModal PopulateUser(User user)
        {
            EmailTextbox.SetTextAndTrigger(user.Email);
            PasswordTextbox.SetTextAndTrigger(user.Password);
            return this;
        }
    }
}
