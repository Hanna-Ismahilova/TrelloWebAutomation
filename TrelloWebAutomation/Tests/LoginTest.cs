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


        //TODO: add adnotation Retry to repeat the test if it is not successful
        [Test]
        public void Login()
        {
            LoginPage login = new LoginPage(webDriver);
            login.LoginToTrello();
            //Assertion object


            
        }

    }
}
