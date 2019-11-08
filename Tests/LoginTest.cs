using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using UIAtomationFramework.Base.Models;
using UIAtomationFramework.Helpers;

namespace TrelloWebAutomation.Tests
    {
    [TestFixture] 

    public class LoginTest
        {
        IWebDriver _driver;

        [SetUp]   
        public void SetUp ( )
            {

            AppSettingsModel appSettingsModel = AppConfig.Load();
            _driver = new ChromeDriver(@"C:\Users\Hanna_Ismahilova\source\repos\TrelloWebAutomation\TrelloWebAutomation\bin\Debug\netcoreapp2.2\chromedriver.exe\");
            _driver.Url = appSettingsModel.URL;
          

            }
        
        [TearDown]
        public void TeatDown ( )
            {

            }

        [Test]
        public void Test001 ( )
            {


            }

        }
    }
