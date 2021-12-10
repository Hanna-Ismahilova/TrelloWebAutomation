using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
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

        //public RemoteWebDriver Driver { get; set; }
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

        //public MediaEntityModelProvider CaptureScreenshotAndReturnModel(string name)
        //{
        //    var screenshot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;
        //    return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name).Build();

        //}
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
