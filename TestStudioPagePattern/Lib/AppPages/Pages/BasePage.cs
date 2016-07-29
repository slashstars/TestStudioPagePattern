
using TestStudioPagePattern.Lib.Base;
using Controls = TestStudioPagePattern.Lib.Controls;

namespace TestStudioPagePattern.Lib.AppPages.Pages
{
    public abstract class BasePage : BaseAutomation
    {
        public Controls.Header Header
		{
			get
			{
				return new Controls.Header();
			}
		}		
    }
}
