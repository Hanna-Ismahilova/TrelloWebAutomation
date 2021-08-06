using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using UITrelloAutomationFramework.Base;
using UITrelloAutomationFramework.Helpers;
using UITrelloAutomationFramework.PageObjects;

namespace TrelloWebAutomation.Tests
{
    [TestFixture]

    public class LoginTest : DriverInit
    {
        private IWebDriver webDriver;

        [SetUp]
        public void SetUp()
        {
            AppConfig.Load();
            webDriver = WebDriverStart();
            LoadPage();

        }

        [TearDown]
        public void TearDown()
        {
            WebDriverStop();
        }


        [Test, Retry(3)]
        public void Trello_1_LoginToTrello_FirstTime ( )
            {
            LoginPage login = new(webDriver);
            login.GoToLoginPage();
            login.EnterUserEmailToLoginToTrello(AppConfig.appSettings.Login);
            login.LoginWithAttlassian();
            login.EnterPasswordToLoginToTrello(AppConfig.appSettings.Password);
            login.Login();

            HomePage welcome = new(webDriver);
            welcome.GetWelcomeText
                .Should().Contain("Most popular templates");

            }

        //[Test, Retry(2)]
        //[System.Obsolete]
        //public void Trello_6_LoginToTrello_Validation ( )
        //    {
        //    WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        //    LoginPage login = new LoginPage(webDriver);
        //    //Missing email
        //    login.GoToLoginPage();
        //    login.EnterCredsToLoginToTrello("", "");
        //    wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div#error > .error-message")));
        //    login.GetEmailValidationErrorMessage
        //        .Should().Contain("Missing email");

        //    //Invalid pwd
        //    login.EnterCredsToLoginToTrello(AppConfig.appSettings.Login, "");
        //    wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div#error > .error-message")));
        //    login.GetPwdValidationErrorMessage
        //        .Should().Contain("Invalid password");

        //    //Account for the email does not exist
        //    login.EnterCredsToLoginToTrello("hismahilova+3@gmail.com", "test5A12!");
        //    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='error']/p[@class='error-message']")));
        //    login.GetNotExistingAccountValidationErrorMessage
        //        .Should().Contain("There isn't an account for this email");

        //    //Too many incorrect pwd attempts
        //    login.EnterCredsToLoginToTrello("hi.infoshare@gmail.com", "");
        //    login.WaitForTooManyIncorrectPwdAttemptsError();
        //    login.GetTooManyPasswordAttemptsValidationErrorMessage()
        //        .Should().Contain("Too many incorrect password attempts.");


        //    }

        }
}
