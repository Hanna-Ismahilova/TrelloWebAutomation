﻿using OpenQA.Selenium;
using UIAtomationFramework.Base;

namespace UIAtomationFramework.PageObjects
    {
    public class CreateFirstBoardPage : BaseUIPage
        {

        private readonly By welcomeToTrelloText = By.XPath("//div[@class='board-name']//h2/span");

        public CreateFirstBoardPage ( IWebDriver webDriver ) : base(webDriver)
            {

            }

        public string GetWelcomeText
            {

            get { return FindElement(welcomeToTrelloText).Text; }

            }

        }
    }
