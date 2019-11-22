using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using UIAtomationFramework.Helpers;

namespace UIAtomationFramework.Base
{
    public class DriverInit : BaseUITest
    {

        public static IWebDriver WebDriverStart()
        {
            
            switch (AppConfig.appSettings.Browser.ToLower())
            {
                case "chrome":
                    return _webDriver is null 
                                    ? _webDriver=new ChromeDriver() : _webDriver;
                default:
                    return null;
            }
        }

        public static void LoadPage()
        {
            _webDriver.Url = AppConfig.appSettings.URL;
        }

        public static void WebDriverStop()
        {
            _webDriver.Close();
        }
      
    }
}
