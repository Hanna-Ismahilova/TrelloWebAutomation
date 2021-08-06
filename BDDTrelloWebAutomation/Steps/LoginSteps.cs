using BDDTrelloWebAutomation.PageObjects;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UITrelloAutomationFramework.Base;

namespace BDDTrelloWebAutomation.Steps
{
    [Binding]
    public sealed class LoginSteps : DriverInit
    {
        private IWebDriver webDriver;

        

        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            LoginPageObject loginPageObject = new(webDriver);
        }

        [Given(@"I click login link")]
        public void GivenIClickLoginLink()
        {
            LoginPageObject loginPageObject = new(webDriver);

            loginPageObject.ClickLoginBtnOnMainPage();
        }

        [Given(@"I enter the following username")]
        public void GivenIEnterTheFollowingUsername(Table table)
        {
            LoginPageObject loginPageObject = new(webDriver);

            dynamic data = table.CreateDynamicInstance();
            loginPageObject.LoginForm((string)data.user, (string)data);
        }

        [Given(@"I click Login With Atlassian button")]
        public void GivenIClickLoginWithAtlassianButton()
        {
            LoginPageObject loginPageObject = new(webDriver);

            loginPageObject.ClickLoginWithAtlassianBtn();
        }

        [Given(@"I enter the following password")]
        public void GivenIEnterTheFollowingPassword(Table table)
        {
            LoginPageObject loginPageObject = new(webDriver);

            dynamic data = table.CreateDynamicInstance();
            loginPageObject.LoginForm((string)data, (string)data.password);
        }

        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            LoginPageObject loginPageObject = new(webDriver);

            loginPageObject.ClickFinalLoginBtn();
        }

        [Then(@"I should see Most popular templates text")]
        public void ThenIShouldSeeMostPopularTemplatesText()
        {
            //CreateFirstBoardPage should be rewriting because I believe the page title is different
            HomePageObject homePage = new(webDriver);
            homePage.DisplayMostPopularTemplateText()
                .Should().BeTrue("Most popular templates");
        }

     

      


    }
}
