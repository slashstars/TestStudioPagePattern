using TestStudioPagePattern.Lib.Base;

namespace TestStudioPagePattern.Lib.AppPages.Modals
{
    public class BaseModal : BaseAutomation
    {
        protected BaseModal()
        {
            scopeFindExpression = new string[]{ "tagname=div", "class=modal" };
        }
    }
}
