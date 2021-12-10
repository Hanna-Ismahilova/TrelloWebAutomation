using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using UITrelloAutomationFramework.Base;
using UITrelloAutomationFramework.Helpers;
using UITrelloAutomationFramework.PageObjects;

namespace TrelloWebAutomation.Tests
{
    [TestFixture]
    [Category("Smoke: Boards")]
    public class HomeTrelloBoardTest : DriverInit
    {
        private IWebDriver webDriver;
        ExtentReports extent = null;
        ExtentTest test = null;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Hanna_Ismahilova\Documents\GitHub\TrelloWebAutomation\ClassLibrary1\ExtentReports\HomeTrelloBoardTest.html");
            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void Setup()
        {
            test = extent.CreateTest("Any Test").Info("Test Started");//it will start logging to the report

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
            extent.Flush();
        }

        [Test]
        public void CreateANewTrelloBoard()
        {
            test = extent.CreateTest("CreateANewTrelloBoard").Info("Test Started");//it will start logging to the report

            HomePageActionsWithBoard boardActions = new(webDriver);
            boardActions.WaitForCreateNewBoardBtn();
            boardActions.ClickOnCreateNewBoardBtn();
            boardActions.EnterTitleToCreateANewBoard("Test");
            boardActions.ClickOnCreateBoardSubmitBtn();
            boardActions.WaitForBoardTitleText();
            boardActions.GetBoardTitleText
                .Should().Equals("Test");

            test.Log(Status.Info, "BoardTitle is correct");
            test.Log(Status.Pass, "Passed");
        }

        [Test]
        public void CloseReopenATrelloBoard()
        {
            HomePageActionsWithBoard boardActions = new (webDriver);
            boardActions.WaitForExistingBoardTile();
            boardActions.ClickOnExistingBoardTile();
            boardActions.WaitForShowSidebarBtn();
            boardActions.ClickOnShowMenuSidebar();
            boardActions.Scroll();
            boardActions.ClickOnMoreBtn();
            boardActions.ClickOnCloseBoardBtn();
            boardActions.ClickOnAlertCloseBtn();
            boardActions.WaitForReOpenBtn();
            boardActions.ClickOnReOpenBtn();
            boardActions.WaitForBoardTitleText();
            boardActions.GetBoardTitleText
                .Should().Equals("Test");
        }

        [Test]
        public void PermanentlyDeleteATrelloBoard()
        {
            HomePageActionsWithBoard boardActions = new(webDriver);
            boardActions.WaitForExistingBoardTile();
            boardActions.ClickOnExistingBoardTile();
            boardActions.WaitForBoardTitleText();
            boardActions.ClickOnShowMenuSidebar();
            boardActions.Scroll();
            boardActions.ClickOnMoreBtn();
            boardActions.ClickOnCloseBoardBtn();
            boardActions.ClickOnAlertCloseBtn();
            boardActions.WaitForPermanentlyDeleteBoard();
            boardActions.ClickOnPermanentlyDeleteBoardBtn();
            boardActions.ClickOnDeleteOnDeleteBoardBtn();
            boardActions.WaitForBoardNotFoundText();
            boardActions.GetBoardNotFoundText
                .Should().Contain("Board not found.");
        }
    }
}
