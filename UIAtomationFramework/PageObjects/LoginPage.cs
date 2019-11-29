using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UIAtomationFramework.Base;
using UIAtomationFramework.Base.Elements;
using UIAtomationFramework.Base.Models;
using UIAtomationFramework.Helpers;

namespace UIAtomationFramework.PageObjects
    {
    public class LoginPage : BaseUIPage
        {
     
        private By enterEmailInput = By.CssSelector("input#user");
        private By enterPasswordInput = By.CssSelector("input#password");
        private By logIn = By.CssSelector("input#login");

        public LoginPage ( IWebDriver webDriver ) : base(webDriver)
            {
            }

        public void LoginToTrello()
            {
            var email =  FindElement(enterEmailInput);
            var password = FindElement(enterPasswordInput);
            email.SendKeys(AppConfig.appSettings.Login);
            password.SendKeys(AppConfig.appSettings.Password);
            SafeClick(logIn);
            //TODO: Assertion






            }        
        }
    }
