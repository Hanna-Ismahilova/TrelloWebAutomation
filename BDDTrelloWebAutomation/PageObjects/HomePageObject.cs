using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using UITrelloAutomationFramework.Base;

namespace BDDTrelloWebAutomation.PageObjects
{
    public class HomePageObject : BaseUIPage
    {
        public HomePageObject(IWebDriver webDriver) : base(webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebDriver WebDriver { get; }
        private static readonly WebDriverWait wait = new WebDriverWait(driver: _webDriver, timeout: TimeSpan.FromSeconds(10));
        public IWebElement TextMostPopularTemplate
        {
            get
            {
                return wait.Until(d => d.FindElement(By.XPath("/html//div[@id='content']/div[@class='member-boards-view']/div[@class='js-boards-page']/div[@class='js-react-root']//div[@class='home-container']/div[@class='home-sticky-container']//h2[.='Most popular templates']")));
            }
            
        }
        public bool DisplayMostPopularTemplateText() => TextMostPopularTemplate.Displayed;

    }
}
