using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TrelloWebAutomation.Pages;
using UIAtomationFramework.Base;
using UIAtomationFramework.Base.Models;
using UIAtomationFramework.Helpers;

namespace TrelloWebAutomation.Tests
{
    [TestFixture]

    public class LoginTest : DriverInit
    {
        

        [SetUp]
        public void SetUp()
        {
            AppConfig.Load();
            WebDriverStart();
            LoadPage();


        }

        [TearDown]
        public void TeatDown()
        {
            WebDriverStop();
        }

        [Test]
        public void Test001()
        {
            var login = new LoginPage();
            
        }

    }
}
