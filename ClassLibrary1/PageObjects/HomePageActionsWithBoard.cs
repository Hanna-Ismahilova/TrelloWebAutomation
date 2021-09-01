using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using UITrelloAutomationFramework.Base;

namespace UITrelloAutomationFramework.PageObjects
{
    public class HomePageActionsWithBoard : BaseUIPage
    {

        //private readonly By homePagePersonalBoardsText = By.XPath("");
        private readonly By createNewBoardBtn = By.CssSelector(".mod-add");
        private readonly By createBoardSubmitBtn = By.CssSelector("[data-test-id='create-board-submit-button']");
        private readonly By showMenuSidebarBtn = By.CssSelector(".js-show-sidebar");
        private readonly By menuSidebarMoreBtn = By.CssSelector("li:nth-of-type(6) > .board-menu-navigation-item-link");
        private readonly By closeSidebarMenuBtn = By.CssSelector("a[title='Close the board menu.']");
        private readonly By closeBoardBtn = By.CssSelector(".board-menu-navigation-item-link.js-close-board");
        private readonly By alertCloseBtn = By.CssSelector(".full.js-confirm.nch-button.nch-button--danger");
        private readonly By reOpenBoardBtn = By.CssSelector(".js-reopen");
        private readonly By parmanentlyDeleteBoardBtn = By.CssSelector(".js-delete.quiet");
        private readonly By confirmBoardDeletionBtn = By.CssSelector(".full.js-confirm.nch-button.nch-button--danger");
        //private readonly By closeSidebarMenuBtn = By.CssSelector(string.Format("a[title='Close the board menu.']"));
        private readonly By existingBoardTile = By.CssSelector("div[title='Test'] > div");
        private readonly By addBoardTitleField = By.XPath("/html//div[@id='layer-manager-overlay']//div[@class='_3Rzqg7dIYw-6jk']//input");
        private readonly By boardTitleText = By.XPath("/html//div[@id='content']//div[@href='#']/h1[.='Test']");
        private readonly By closeBoardAlertDescriptionText = By.CssSelector(".js-tab-parent.u-fancy-scrollbar p");
        private readonly By boardNotFoundText = By.XPath("/html//div[@id='content']//h1[.='Board not found.']");

        private static readonly WebDriverWait wait = new(driver: _webDriver, timeout: TimeSpan.FromMinutes(1));

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
        public void ClickOnExistingBoardTile() => Click(existingBoardTile);
        public void ClickOnShowMenuSidebar() => Click(showMenuSidebarBtn);
        public void ClickOnMoreBtn() => Click(menuSidebarMoreBtn);
        public void ClickCloseBoardMenuBtn() => Click(closeSidebarMenuBtn);
        public void ClickOnCloseBoardBtn() => Click(closeBoardBtn);
        public void ClickOnAlertCloseBtn() => Click(alertCloseBtn);
        public void ClickOnPermanentlyDeleteBoardBtn() => Click(parmanentlyDeleteBoardBtn);
        public void ClickOnReOpenBtn() => Click(reOpenBoardBtn);
        public void ClickOnDeleteOnDeleteBoardBtn() => Click(confirmBoardDeletionBtn);


        #endregion

        #region Actions
        public void Scroll()
        {
            var element = FindElement(menuSidebarMoreBtn);
            Actions actions = new(_webDriver);
            actions.MoveToElement(element);
            actions.Perform();

        }

        public void DoActionIfSidebarIsOpenedOrClosed()
        {
            if (closeSidebarMenuBtn != null )
            {
                ClickOnMoreBtn();


            }
            else if (showMenuSidebarBtn != null)
            {
                ClickOnShowMenuSidebar();
                ClickOnMoreBtn();
            }

           
        }

        public void JSExecutorForShowSideBar()
        {
            var showBar = _webDriver.FindElement(By.CssSelector(".js-show-sidebar"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_webElement;
            executor.ExecuteScript("argument[0].click();", showBar);
        }
 
        #endregion

        #region GetMessageText
        public string GetBoardTitleText => FindElement(boardTitleText).Text;
        public string GetCloseBoardAlertDescriptionText => FindElement(closeBoardAlertDescriptionText).Text;
        public string GetBoardNotFoundText => FindElement(boardNotFoundText).Text;

        #endregion

        #region WaitForElement
        public void WaitForCreateNewBoardBtn() => wait.Until(d => d.FindElement(createNewBoardBtn)); 
        public void WaitForBoardTitleText() => wait.Until(d => d.FindElement(boardTitleText)); 
        public void WaitForExistingBoardTile() => wait.Until(d => d.FindElement(existingBoardTile));
        public void WaitForPermanentlyDeleteBoard() => wait.Until(d => d.FindElement(parmanentlyDeleteBoardBtn));
        public void WaitForReOpenBtn() => wait.Until(d => d.FindElement(reOpenBoardBtn));
        public void WaitForShowSidebarBtn() => wait.Until(d => d.FindElement(showMenuSidebarBtn));
        public void WaitForBoardNotFoundText() => wait.Until(d => d.FindElement(boardNotFoundText));
       
        #endregion

 
    }
}
