using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using UITrelloAutomationFramework.Helpers;

namespace UITrelloAutomationFramework.Base
{
    public class DriverInit : BaseUIPage
    {
        public DriverInit(IWebDriver webDriver) : base(webDriver)
        {

        }

        public DriverInit()
        {

        }

        public static IWebDriver WebDriverStart()
        {

            switch (AppConfig.appSettings.Browser.ToLower())
            {
                case "chrome":
                    return _webDriver is null
                                    ? _webDriver = new ChromeDriver() : _webDriver;
                //case "firefox":
                //    return _webDriver is null
                //                    ? _webDriver = new FirefoxDriver() : _webDriver;
                //case "edge":
                //    return _webDriver is null
                //                    ? _webDriver = new EdgeDriver() : _webDriver;
                default:
                    return null;
            }
        }
        public static void LoadPage()
        {
            _webDriver.Url = AppConfig.appSettings.URLMain;
        }

        public static void WebDriverStop()
        {
            _webDriver.Dispose();
        }

    }
}
