using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UIAtomationFramework.Base;
using UIAtomationFramework.Base.Elements;
using UIAtomationFramework.Base.Models;
using UIAtomationFramework.Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace UIAtomationFramework.PageObjects
    {
    public class LoginPage : BaseUIPage
        {

        private By logInButtonOnWelcomePage = By.XPath("//body//nav[@class='navbar py-3']//a[@href='/login']");
        private By enterEmailInput = By.CssSelector("input#user");
        private By loginWithAtlassianButton = By.CssSelector("#login");
        private By continueButton = By.CssSelector("button#login-submit  .css-t5emrf");
        private By enterPasswordInput = By.CssSelector("input#password");
        private By logInButtonOnLoginPage = By.CssSelector("button#login-submit  .css-t5emrf > span");
        

        public LoginPage ( IWebDriver webDriver ) : base(webDriver)
            {
            }

        public void LoginToTrello()
            {
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            SafeClick(logInButtonOnWelcomePage);
            var email =  FindElement(enterEmailInput);
            email.SendKeys(AppConfig.appSettings.Login);
            SafeClick(loginWithAtlassianButton);
            SafeClick(continueButton);
            var password = FindElement(enterPasswordInput);
            password.SendKeys(AppConfig.appSettings.Password);

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            DoubleClick(logInButtonOnLoginPage);
           
            }

        //TODO: method for negative tests LoginToTrello
        }
    }
