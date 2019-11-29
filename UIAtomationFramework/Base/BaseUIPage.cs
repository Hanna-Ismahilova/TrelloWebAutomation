using OpenQA.Selenium;
using UIAtomationFramework.Base.Elements;

namespace UIAtomationFramework.Base
{
    public class BaseUIPage : WebSafeElements
    {
        public BaseUIPage ( IWebDriver webDriver) : base(webDriver)
        {
        }
        public BaseUIPage ( )
        {

        }


    }


}
