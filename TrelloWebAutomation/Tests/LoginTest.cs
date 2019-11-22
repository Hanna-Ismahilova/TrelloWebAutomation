using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UIAtomationFramework.Base;
using UIAtomationFramework.Base.Models;
using UIAtomationFramework.Helpers;

namespace TrelloWebAutomation.Tests
{
    [TestFixture]

    public class LoginTest
    {
        IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {

            AppSettingsModel appSettingsModel = AppConfig.Load();
            _driver = new ChromeDriver();
            _driver.Url = appSettingsModel.URL;


        }

        [TearDown]
        public void TeatDown()
        {

        }

        [Test]
        public void Test001()
        {


        }

    }
}
