using Bogus;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UIAtomationFramework.Base;
using UIAtomationFramework.Helpers;
using UIAtomationFramework.PageObjects;

namespace TrelloWebAutomation.Tests
    {
    
    [TestFixture]
    class SignUpTest : DriverInit
            {
            private IWebDriver webDriver;

            [SetUp]
            public void SetUp ( )
                {
                AppConfig.Load();
                webDriver = WebDriverStart();
                LoadPage();

                }

            [TearDown]
            public void TearDown ( )
                {
                WebDriverStop();
                }

        [Test, Retry(3)]
        public void Trello_9_SignUp_in_Trello ( )
            {
            SignUpPage signUp = new SignUpPage(webDriver);
            signUp.SignUpInTrello();

            HomePage homePage = new HomePage(webDriver);
            homePage.





            }






        }
    }
