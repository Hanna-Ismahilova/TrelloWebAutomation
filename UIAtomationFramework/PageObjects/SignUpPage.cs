using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UIAtomationFramework.Base;
using UIAtomationFramework.Helpers;

namespace UIAtomationFramework.PageObjects
    {
    public class SignUpPage : BaseUIPage

        {

        private By signUpButtonOnwelcomePage = By.XPath("//body//nav[@class='navbar py-3']//a[@href='/signup']");
        private By enterEmailSignUpInput = By.XPath("/html//input[@id='email']");
        private By signUpContinueButton = By.XPath("/html//input[@id='signup-submit']");
        private By enterFullNameSignUpInput = By.XPath("/html//input[@id='displayName']");
        private By createPasswordSignUpInput = By.XPath("/html//input[@id='password']");
        private By signUpButton = By.XPath("//button[@id='signup-submit']//span[@class='css-t5emrf']");

        public SignUpPage ( IWebDriver webDriver ) : base(webDriver)
            {

            }

        public void SignUpInTrello ( )
            {
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            SafeClick(signUpButtonOnwelcomePage);

            var emailSignup = FindElement(enterEmailSignUpInput);
            emailSignup.SendKeys(SignUpDataBogus.signUpData.SignUpEmail);

            SafeClick(signUpContinueButton);

            var fullNameSignUp = FindElement(enterFullNameSignUpInput);
            fullNameSignUp.SendKeys(SignUpDataBogus.signUpData.SignUpFullName);
            var passwordSignUp = FindElement(createPasswordSignUpInput);
            passwordSignUp.SendKeys(SignUpDataBogus.signUpData.SignUpCreatePassword);

            SafeClick(signUpButton);

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            }

                          
        }
    }
