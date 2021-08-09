using NUnit.Framework;
using OpenQA.Selenium;
using UITrelloAutomationFramework.Base;
using UITrelloAutomationFramework.Helpers;

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
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            WebDriverStop();
        }

        [Test]
        public void CreateANewTrelloBoard()
        {

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
