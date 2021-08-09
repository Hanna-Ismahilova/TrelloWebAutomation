using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using UITrelloAutomationFramework.Base;
using UITrelloAutomationFramework.Helpers;
using UITrelloAutomationFramework.PageObjects;

namespace TrelloWebAutomation.Tests
{
    [TestFixture]
    [Category("Smoke: Login")]
    public class LoginTest : DriverInit
    {
        private IWebDriver webDriver;

        [SetUp]
        public void SetUp()
        {
            AppConfig.Load();
            webDriver = WebDriverStart();
            LoadPage();

            webDriver.Manage().Window.Maximize();

        }

        [OneTimeTearDown]
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
            login.WaitForLoginWithAtlassianButton();
            login.LoginWithAttlassian();
            login.EnterPasswordToLoginToTrello(AppConfig.appSettings.Password);
            login.LoginOnWelcomeNavBar();

            HomePage welcome = new(webDriver);
            welcome.WaitForGetWelcomeText();
            welcome.GetWelcomeText
                .Should().Contain("Most popular templates");
        }

        [Test, Retry(2)]
        public void Trello_6_LoginToTrello_ValidateMissingEmail()
        {
            LoginPage login = new(webDriver);
            login.GoToLoginPage();

            login.EnterUserEmailToLoginToTrello("");
            login.LoginToMakeValidationMsgDisplayed();
            login.WaitForEmailValidationErrorMessage();
            login.GetEmailValidationErrorMessage
                .Should().Contain("Missing email");
        }

        [Test, Retry(2)]
        public void Trello_6_LoginToTrello_ValidateInvalidPwd()
        {
            LoginPage login = new(webDriver);
            login.GoToLoginPage();
  
            login.EnterUserEmailToLoginToTrello(AppConfig.appSettings.Login);
            login.WaitForLoginWithAtlassianButton();
            login.LoginWithAttlassian();
            login.EnterPasswordToLoginToTrello("");
            login.LoginOnWelcomeNavBar();

            login.WaitForPwdValidationErrorMessage();
            login.GetPwdValidationErrorMessage
                .Should().Contain("Enter your password");
        }

        [Test, Retry(2)]
        public void Trello_6_LoginToTrello_ValidateAccountNotExists()
        {
            LoginPage login = new(webDriver);
            login.GoToLoginPage();

            login.EnterUserEmailToLoginToTrello("hismahilova+3@gmail.com");
            login.LoginToMakeValidationMsgDisplayed();
            login.WaitForNotExistingAccountValidationErrorMessage();
            login.GetNotExistingAccountValidationErrorMessage
                .Should().Contain("There isn't an account for this email");
        }

        //[Test, Retry(2)]
        //public void Trello_6_LoginToTrello_ValidateTooManyPwdAttempts()
        //{
        //    LoginPage login = new(webDriver);
        //    login.GoToLoginPage();

        //    login.EnterUserEmailToLoginToTrello("hismahilova+3@gmail.com");
        //    login.EnterPasswordToLoginToTrello("test");
        //    login.LoginToMakeValidationMsgDisplayed();
        //    login.WaitForTooManyIncorrectPwdAttemptsError();
        //    login.GetTooManyPasswordAttemptsValidationErrorMessage()
        //        .Should().BeTrue("Too many incorrect password attempts.");
        //}

    }
}
