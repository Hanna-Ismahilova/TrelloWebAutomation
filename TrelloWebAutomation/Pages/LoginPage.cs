using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using UIAtomationFramework.Base;
using UIAtomationFramework.Helpers;

namespace TrelloWebAutomation.Pages
{
    public class LoginPage : BaseUITest
    {

        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void LogIn()
        {
            FinderElement(By.XPath("")).SendKeys(AppConfig.appSettings.Login);
            FinderElement(By.XPath("")).SendKeys(AppConfig.appSettings.Password);
        }

    }
}
