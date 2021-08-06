using OpenQA.Selenium;
using UITrelloAutomationFramework.Base.Elements;

namespace UITrelloAutomationFramework.Base
{
    public class BaseUIPage : WebSafeElements
    {
        public BaseUIPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public BaseUIPage()
        {

        }
    }
}
