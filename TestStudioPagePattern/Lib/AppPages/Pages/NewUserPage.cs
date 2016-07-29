using ArtOfTest.WebAii.Controls.HtmlControls;
using TestStudioPagePattern.Lib.BusinessObjects;
using TestStudioPagePattern.Lib;

namespace TestStudioPagePattern.Lib.AppPages.Pages
{
    public class NewUserPage : BasePage
    {
        private static NewUserPage _instance;
        public static NewUserPage Instance
        {
            get
            {
                if (_instance == null) _instance = new NewUserPage();
                return _instance;
            }
        }

        private NewUserPage() { }

        public HtmlInputEmail EmailTextbox
		{
			get
			{
				return GetByExpression<HtmlInputEmail>("name=email");
			}
		}		
        public HtmlInputText FirstNameTextbox
		{
			get
			{
				return GetByExpression<HtmlInputText>("name=firstName");
			}
		}
		public HtmlInputText LastNameTextbox
		{
			get
			{
				return GetByExpression<HtmlInputText>("name=lastName");
			}
		}		
        public HtmlInputPassword PasswordTextbox
		{
			get
			{
				return GetByExpression<HtmlInputPassword>("name=password");
			}
		}		
        public HtmlInputPassword RepeatPasswordTextbox
		{
			get
			{
				return GetByExpression<HtmlInputPassword>("name=passwordRepeat");
			}
		}		
        public HtmlInputCheckBox IsAdminCheckbox
		{
			get
			{
				return GetByExpression<HtmlInputCheckBox>("type=checkbox");
			}
		}		
        public HtmlButton SaveButton
		{
			get
			{
				return GetByExpression<HtmlButton>("class=~save");
			}
		}
		public HtmlButton RevertButton
		{
			get
			{
				return GetByExpression<HtmlButton>("class=~revert");
			}
		}		

        public NewUserPage PopulateUser(User user)
        {
            EmailTextbox.SetTextAndTrigger(user.Email);
            FirstNameTextbox.SetTextAndTrigger(user.FirstName);
            LastNameTextbox.SetTextAndTrigger(user.LastName);
            PasswordTextbox.SetTextAndTrigger(user.Password);
            RepeatPasswordTextbox.SetTextAndTrigger(user.Password);

            return this;
        }
    }
}
