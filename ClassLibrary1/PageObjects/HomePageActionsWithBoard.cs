using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using UITrelloAutomationFramework.Base;

namespace UITrelloAutomationFramework.PageObjects
{
    public class HomePageActionsWithBoard : BaseUIPage
    {

        private readonly By homePagePersonalBoardsText = By.XPath("");
        private readonly By createNewBoardBtn = By.CssSelector(".mod-add");
        private readonly By createBoardSubmitBtn = By.CssSelector("[data-test-id='create-board-submit-button']");
        private readonly By addBoardTitleField = By.XPath("/html//div[@id='layer-manager-overlay']//div[@class='_3Rzqg7dIYw-6jk']//input");
        private readonly By boardTitleText = By.XPath("/html//div[@id='content']//div[@href='#']/h1[.='Test']");
        private static readonly WebDriverWait wait = new(driver: _webDriver, timeout: TimeSpan.FromSeconds(10));

        public HomePageActionsWithBoard(IWebDriver webDriver) : base(webDriver)
        {

        }

        #region EnterData
        public void EnterTitleToCreateANewBoard(string boardTitle)
        {
            var title = FindElement(addBoardTitleField);
            title.SendKeys(boardTitle);
        }

        #endregion

        #region ClickOnElement
        public void ClickOnCreateNewBoardBtn() => Click(createNewBoardBtn);
        public void ClickOnCreateBoardSubmitBtn() => Click(createBoardSubmitBtn);

        #endregion

        #region GetMessageText
        public string GetBoardTitleText => FindElement(boardTitleText).Text;

        #endregion

        #region WaitForElement
        public void WaitForCreateNewBoardBtn() => wait.Until(d => d.FindElement(createNewBoardBtn)); 
        public void WaitForBoardTitleText() => wait.Until(d => d.FindElement(boardTitleText)); 
        #endregion

    }
}
