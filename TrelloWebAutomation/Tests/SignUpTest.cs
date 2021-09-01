using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using UITrelloAutomationFramework.Base;
using UITrelloAutomationFramework.Helpers;
using UITrelloAutomationFramework.PageObjects;

namespace TrelloWebAutomation.Tests
{

    [TestFixture]
    [Category("Smoke: SignUp")]
    [Ignore("Ignore a fixture")]
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
        public void SignUp_in_Trello()
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
        public void SignUp_in_Trello_via_Google_Acct()
        {
            //Cannot be done because of Trello protection
            SignUpPage signUpPage = new(webDriver);
            signUpPage.ClickSignUpBtnOnWelcomePage();
            signUpPage.ClickSignUpViaGoogleAcct();
            signUpPage.WaitForEmailFieldWhenSignUpViaGoogleAcct();
            signUpPage.EnterUserEmailToSignUpViaGoogleAcct(AppConfig.appSettings.Login);
            signUpPage.ClickOnNextButton();
            signUpPage.WaitForPasswordFieldWhenSignUpViaGoogleAcct();
            signUpPage.EnterUserPasswordToSignUpViaGoogleAcct(AppConfig.appSettings.Password);
            signUpPage.ClickOnNextButton();


        }



    }
}
