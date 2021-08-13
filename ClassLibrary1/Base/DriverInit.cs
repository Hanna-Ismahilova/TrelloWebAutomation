using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

                //todo Firefox,IE itd
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
