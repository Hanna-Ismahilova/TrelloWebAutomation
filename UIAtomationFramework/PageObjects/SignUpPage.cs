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

        public void SignUpInTrello ()
            {
            //to remove after refactoring method FindElement
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            SafeClick(signUpButtonOnwelcomePage);
            var emailSignup = FindElement(enterEmailSignUpInput);
            string email = new Bogus.DataSets.Internet("en_GB").Email();
            //emailSignup.SendKeys(person.Email);
            emailSignup.SendKeys(email);

            SafeClick(signUpContinueButton);

            var fullNameSignUp = FindElement(enterFullNameSignUpInput);
            string fullName = new Bogus.DataSets.Name("en_GB").FullName();
             //fullNameSignUp.SendKeys(person.FullName);
            fullNameSignUp.SendKeys(fullName);
            var passwordSignUp = FindElement(createPasswordSignUpInput);
            string pwd = new Bogus.DataSets.Internet("en_GB").Password();
            //passwordSignUp.SendKeys(person.Password);
            passwordSignUp.SendKeys(pwd);

            SafeClick(signUpButton);
            //to remove after refactoring method FindElement
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            }
   

        }
    }
