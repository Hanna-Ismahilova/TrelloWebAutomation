﻿using System;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UIAtomationFramework.Base;
using UIAtomationFramework.Base.Models;
using UIAtomationFramework.Helpers;
using UIAtomationFramework.PageObjects;

namespace TrelloWebAutomation.Tests
{
    [TestFixture]

    public class LoginTest : DriverInit
    {
        private IWebDriver webDriver;

        [SetUp]
        public void SetUp()
        {
            AppConfig.Load();
            webDriver = WebDriverStart();
            LoadPage();

        }

        [TearDown]
        public void TearDown()
        {
            WebDriverStop();
        }


        [Test, Retry(3)]
        public void Trello_1_LoginToTrello_FirstTime ( )
            {
            LoginPage login = new LoginPage(webDriver);
            login.GoToLoginPage();
            login.LoginToTrello(AppConfig.appSettings.Login, AppConfig.appSettings.Password);

            CreateFirstBoardPage welcome = new CreateFirstBoardPage(webDriver);
            welcome.GetWelcomeText
                .Should().Contain("Welcome to Trello!");

            }

        [Test, Retry(2)]
        [System.Obsolete]
        public void Trello_6_LoginToTrello_Validation ( )
            {

            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            LoginPage login = new LoginPage(webDriver);

            //Missing email
            login.GoToLoginPage();
            login.LoginToTrello("", "");
            login.GetEmailValidationErrorMessage
                .Should().Contain("Missing email");

            //Invalid pwd
            login.LoginToTrello(AppConfig.appSettings.Login, "");
            login.GetPwdValidationErrorMessage
                .Should().Contain("Invalid password");

            //Account for the email does not exist
            login.LoginToTrello("hismahilova+3@gmail.com", "test5A12!");
            login.GetNotExistingAccountValidationErrorMessage
                .Should().Contain("There isn't an account for this email");

            //Too many incorrect pwd attempts
            login.LoginToTrello("hi.infoshare@gmail.com", "");
            login.GetTooManyPasswordAttemptsValidationErrorMessage()
                .Should().Contain("Too many incorrect password attempts.");


            }

        }
}
