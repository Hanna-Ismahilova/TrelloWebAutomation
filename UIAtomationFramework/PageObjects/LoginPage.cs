using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Net.Mime;
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
        private By logInButtonOnLoginPage = By.CssSelector("input#login");
        private By loginButtonOnLoginPageForValidation = By.XPath("//input[@id='login']");

        private readonly By missingEmail = By.CssSelector("div#error > .error-message");
        private readonly By missingPassword = By.CssSelector("div#error > .error-message");
        private readonly By tooManyIncorrectPwdAttempts = By.XPath("//div[@id='error']/p[@class='error-message']");
        





        public LoginPage ( IWebDriver webDriver ) : base(webDriver)
            {
            }

        public void LoginToTrello (string login, string pwd)
            {
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var email =  FindElement(enterEmailInput);
            email.SendKeys(login);
            //SafeClick(loginWithAtlassianButton);
            //SafeClick(continueButton);
            var password = FindElement(enterPasswordInput);
            password.SendKeys(pwd);

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            DoubleClick(logInButtonOnLoginPage);
           
            }
        public void GoToLoginPage ( )
            {
            SafeClick(logInButtonOnWelcomePage);

            }

        public string GetEmailValidationErrorMessage 
            {

            get { return FindElement(missingEmail).Text; }

            }

        public string GetPwdValidationErrorMessage
            {
            get { return FindElement(missingPassword).Text; }
            }

        public string  GetTooManyPasswordAttemptsValidationErrorMessage ( )
            {
            var errorMessage = "Too many incorrect password attempts.";
            do
                {
                SafeClick(loginButtonOnLoginPageForValidation);

                } while ( tooManyIncorrectPwdAttempts == null );

            return errorMessage;
            

            }

        //Create method which will check if 'Too many incorrect password attempts. You can try again in 300 seconds' is displayed and will check
        // till it disappears and then will click 'login' button again and will check if Invalid password error message appears.
      



        }
    }
