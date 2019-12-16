using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UIAtomationFramework.Base;
using UIAtomationFramework.Base.Models;
using UIAtomationFramework.Helpers;
using UIAtomationFramework.PageObjects;

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
            LoginPage login = new LoginPage(webDriver);
            login.GoToLoginPage();
            login.LoginToTrello(AppConfig.appSettings.Login, AppConfig.appSettings.Password);

            CreateFirstBoardPage welcome = new CreateFirstBoardPage(webDriver);
            Assert.AreEqual("Welcome to Trello!", welcome.GetWelcomeText);

            }

        [Test]
        public void Trello_6_LoginToTrello_Validation ( )
            {
            LoginPage login = new LoginPage(webDriver);

            login.GoToLoginPage();
            login.LoginToTrello("", "");
            login.GetEmailValidationErrorMessage
                .Should().Contain("Missing email");

            login.LoginToTrello(AppConfig.appSettings.Login, "");
            login.GetPwdValidationErrorMessage
                .Should().Contain("Invalid password");

            login.LoginToTrello(AppConfig.appSettings.Login, "");
            login.GetTooManyPasswordAttemptsValidationErrorMessage()
                .Should().Contain("Too many incorrect password attempts.");
            

            }

        }
}
