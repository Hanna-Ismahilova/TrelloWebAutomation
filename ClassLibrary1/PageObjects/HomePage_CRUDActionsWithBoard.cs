using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using UITrelloAutomationFramework.Base;

namespace UITrelloAutomationFramework.PageObjects
{
    public class HomePage_CRUDActionsWithBoard : BaseUIPage
    {

        private readonly By homePagePersonalBoardsText = By.XPath("");

        private static readonly WebDriverWait wait = new(driver: _webDriver, timeout: TimeSpan.FromSeconds(10));

        public HomePage_CRUDActionsWithBoard(IWebDriver webDriver) : base(webDriver)
        {

        }

        

    }
}
