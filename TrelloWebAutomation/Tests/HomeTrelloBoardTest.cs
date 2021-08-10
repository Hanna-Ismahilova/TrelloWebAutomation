using NUnit.Framework;
using OpenQA.Selenium;
using UITrelloAutomationFramework.Base;
using UITrelloAutomationFramework.Helpers;
using UITrelloAutomationFramework.PageObjects;

namespace TrelloWebAutomation.Tests
{
    public class HomeTrelloBoardTest : DriverInit
    {
        private IWebDriver webDriver;

        [SetUp]
        public void Setup()
        {
            AppConfig.Load();
            webDriver = WebDriverStart();
            LoadPage();

            webDriver.Manage().Window.Maximize();

            LoginPage login = new(webDriver);
            login.GoToLoginPage();
            login.EnterUserEmailToLoginToTrello(AppConfig.appSettings.Login);
            login.WaitForLoginWithAtlassianButton();
            login.LoginWithAttlassian();
            login.EnterPasswordToLoginToTrello(AppConfig.appSettings.Password);
            login.LoginOnWelcomeNavBar();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            WebDriverStop();
        }

        [Test]
        public void CreateANewTrelloBoard()
        {
            HomePage_CRUDActionsWithBoard boardCRUDActions = new(webDriver);
            

        }

        [Test]
        public void CloseATrelloBoard()
        {

        }

        [Test]
        public void ReopenClosedATrelloBoard()
        {

        }

        [Test]
        public void PermanentlyDeleteATrelloBoard()
        {

        }


    }
}
