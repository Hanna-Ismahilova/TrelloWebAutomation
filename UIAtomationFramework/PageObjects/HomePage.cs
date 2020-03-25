using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UIAtomationFramework.Base;

namespace UIAtomationFramework.PageObjects
    {
    public class HomePage : BaseUIPage
        {

        private readonly By homePagePersonalBoardsText = By.XPath("/html//div[@id='content']/div[@class='member-boards-view']/div[@class='js-boards-page']/div[@class='js-react-root']//div[@class='home-container']//h3[@class='boards-page-board-section-header-name']");


        public HomePage ( IWebDriver webDriver ) : base(webDriver)
            {

            }

        public string GetPersonalBoardsText
            {

            get { return FindElement(homePagePersonalBoardsText).Text; }

            }




        }
    }
