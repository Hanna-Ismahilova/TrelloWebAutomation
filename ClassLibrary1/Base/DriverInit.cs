﻿using OpenQA.Selenium;
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

        public IWebDriver WebDriverStart()
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
        public void LoadPage()
        {
            _webDriver.Url = AppConfig.appSettings.URLMain;
        }

        public void WebDriverStop()
        {
            _webDriver.Dispose();
        }

    }
}
