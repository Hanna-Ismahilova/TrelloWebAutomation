using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using UIAtomationFramework.Helpers;

namespace UIAtomationFramework.Base
{
    public class DriverInit : BaseUIPage
    {
      
        public DriverInit(IWebDriver webDriver) : base(webDriver)
        {
        }
        public DriverInit ( )
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
            _webDriver.Url = AppConfig.appSettings.URL;
        }

        public void WebDriverStop()
        {
            _webDriver.Dispose();
        }
      
    }
}
