using ArtOfTest.WebAii.Controls.HtmlControls;
using System;
using TestStudioPagePattern.Context;

namespace TestStudioPagePattern.Lib
{
    public static class Extensions
    {
        public static void SetTextAndTrigger(this HtmlControl element, string text, string triggerEvent = "input")
        {
            string script =
                "angular.element(" + element.ClientSideLocator + ").val('" + text + "').trigger('" + triggerEvent + "')";
            AutomationContext.Manager.ActiveBrowser.Actions.InvokeScript(script);
        }

        public static void CheckEnabledAndClick(this HtmlButton button)
        {
            if (button == null) throw new Exception("Button is null.");
            if (!button.IsEnabled) throw new Exception("Button " + button.TextContent + " was disabled.");
            button.Click();
        }
    }
}
