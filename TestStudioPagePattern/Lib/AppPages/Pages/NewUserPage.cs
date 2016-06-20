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

        public HtmlInputEmail EmailTextbox => GetByExpression<HtmlInputEmail>("name=email");
        public HtmlInputText FirstNameTextbox => GetByExpression<HtmlInputText>("name=firstName");
        public HtmlInputText LastNameTextbox => GetByExpression<HtmlInputText>("name=lastName");
        public HtmlInputPassword PasswordTextbox => GetByExpression<HtmlInputPassword>("name=password");
        public HtmlInputPassword RepeatPasswordTextbox => GetByExpression<HtmlInputPassword>("name=passwordRepeat");
        public HtmlInputCheckBox IsAdminCheckbox => GetByExpression<HtmlInputCheckBox>("type=checkbox");
        public HtmlButton SaveButton => GetByExpression<HtmlButton>("class=~save");
        public HtmlButton RevertButton => GetByExpression<HtmlButton>("class=~revert");

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
