using ArtOfTest.WebAii.Controls;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using System;
using System.Threading;
using TestStudioPagePattern.Context;

namespace TestStudioPagePattern.Lib.Base
{
    public abstract class BaseAutomation
    {
        protected string[] scopeFindExpression;
        
        private Manager Manager => AutomationContext.Manager;
        private Browser Browser => Manager.ActiveBrowser;

        public T GetByExpression<T>(string expression, int timeoutMillis = 10000, bool refresh = true, bool waitForAjax = true) where T : HtmlControl, new()
        {
            return GetByExpression<T>(new HtmlFindExpression(expression), timeoutMillis, refresh, waitForAjax);
        }

        public T GetByExpression<T>(string[] expression, int timeoutMillis = 10000, bool refresh = true, bool waitForAjax = true) where T : HtmlControl, new()
        {
            return GetByExpression<T>(new HtmlFindExpression(expression), timeoutMillis, refresh, waitForAjax);
        }

        public T GetByExpression<T>(HtmlFindExpression expression, int timeoutMillis = 10000, bool refresh = true, bool waitForAjax = true) where T : HtmlControl, new()
        {
            if(scopeFindExpression != null && scopeFindExpression.Length > 0)
            {
                expression = PrependFindExpression(expression, scopeFindExpression);
            }

            if (waitForAjax)
            {
                Browser.WaitUntilReady();
                Browser.WaitForAjax(timeoutMillis);
            }
            
            try
            {
                var elemet = Browser.WaitForElement(expression, timeoutMillis, false);
                return elemet.As<T>();
            }
            catch (Exception)
            {
                throw new Exception($"Element of type \"{typeof(T).FullName}\" not found. Find expression: \"{expression.ToString()}\".");
            }
        }

        private static HtmlFindExpression PrependFindExpression(string[] originalExpression, string[] prefixExpression)
        {
            if(prefixExpression == null || prefixExpression.Length <= 0)
            {
                throw new Exception("Prefix expression is invalid.");
            }
			if(originalExpression == null || originalExpression.Length <= 0)
			{
				throw new Exception("Original expression is invalid.");
			}
            HtmlFindExpression prepended = new HtmlFindExpression(prefixExpression);
            prepended.AppendClauses(true, originalExpression);

            return prepended;
        }

        private static HtmlFindExpression PrependFindExpression(HtmlFindExpression originalExpression, string[] prefixExpression)
        {
            return PrependFindExpression(originalExpression.Clauses, prefixExpression);
        }
    }
}
