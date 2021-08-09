using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using UITrelloAutomationFramework.Base;

namespace UITrelloAutomationFramework.PageObjects
{
    public class HomePage : BaseUIPage
    {

        private readonly By homePagePersonalBoardsText = By.XPath("/html//div[@id='content']/div[@class='member-boards-view']/div[@class='js-boards-page']/div[@class='js-react-root']//div[@class='home-container']//h3[@class='boards-page-board-section-header-name']");
        private readonly By welcomeToTrelloText = By.XPath("/html//div[@id='content']/div[@class='member-boards-view']/div[@class='js-boards-page']/div[@class='js-react-root']//div[@class='home-container']/div[@class='home-sticky-container']//h2[.='Most popular templates']");

         static readonly WebDriverWait wait = new(driver: _webDriver, timeout: TimeSpan.FromSeconds(10));

        public HomePage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public string GetPersonalBoardsText
        {
            get { return FindElement(homePagePersonalBoardsText).Text; }
        }

        public string GetWelcomeText
        {

            get { return FindElement(welcomeToTrelloText).Text; }

        }

        public void WaitForGetWelcomeText() => wait.Until(d => d.FindElement(welcomeToTrelloText));
      
    }
}
