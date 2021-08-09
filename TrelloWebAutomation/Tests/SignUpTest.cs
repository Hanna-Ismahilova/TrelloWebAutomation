using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using UITrelloAutomationFramework.Base;
using UITrelloAutomationFramework.Helpers;
using UITrelloAutomationFramework.PageObjects;

namespace TrelloWebAutomation.Tests
{

    [TestFixture]
    class SignUpTest : DriverInit
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
        public void Trello_1_SignUp_in_Trello()
        {

            //Cannot be done because of CAPTCHA
            SignUpPage signUp = new(webDriver);

            _ = new Bogus.DataSets.Name().FullName();

            signUp.SignUpInTrello();

            HomePage homePage = new(webDriver);
            homePage.GetPersonalBoardsText
                .Should().Contain("Personal Boards");

        }

        [Test, Retry(3)]
        public void Trello_2_SignUp_in_Trello_via_Google_Acct()
        {
            SignUpPage signUpPage = new(webDriver);
            signUpPage.SignUpInTrelloViaGoogleAcct();

        }



    }
}
