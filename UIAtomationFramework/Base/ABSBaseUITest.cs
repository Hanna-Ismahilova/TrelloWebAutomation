using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UIAtomationFramework.Base
    {
    public abstract class ABSBaseUITest
        {
        protected static IWebDriver _webDriver;

        public ABSBaseUITest (IWebDriver webDriver )
            {
            _webDriver = webDriver;
            }
        public ABSBaseUITest()
        {

        }

        //create loop which will searching according to set time + assertation if not found
        public IWebElement FinderElement (By locator )
            {
            return _webDriver.FindElement(locator);
            }

        #region Clicks
        public void SafeClick ( By locator)
            {
            FinderElement(locator).Click();
            }
        #endregion
        }
    }
