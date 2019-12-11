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

        //TODO: negative test cases

        [Test, Retry(3)]
        public void Login()
        {

            LoginPage login = new LoginPage(webDriver);
            login.LoginToTrello();

            CreateFirstBoardPage welcome = new CreateFirstBoardPage(webDriver);
            
            Assert.AreEqual("Welcome to Trello!", welcome.GetWelcomeText);



            }

        }
}
