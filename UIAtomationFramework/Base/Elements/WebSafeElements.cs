using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using UIAtomationFramework.PageObjects;

namespace UIAtomationFramework.Base.Elements
    {
    public abstract class WebSafeElements : IWebElement
        {

        private readonly ISearchContext _selenium;
        private By _by;
        private readonly bool _breakIfNotFound;
        private readonly double _timeout;
        protected IWebDriver _webDriver;
        private string _failMessage;
        private string _failMessageException;

        public WebSafeElements ( )
            {

            }



        public WebSafeElements (IWebDriver webDriver )
            {
            _webDriver = webDriver;

            }

        public WebSafeElements ( ISearchContext selenium, By by, double timeout, bool breakIfNotFound )
            {
            _selenium = selenium;
            _by = by;
            _timeout = timeout;
            _breakIfNotFound = breakIfNotFound;

            }


        public string TagName => throw new NotImplementedException();

        public string Text => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public bool Selected => throw new NotImplementedException();

        public Point Location => throw new NotImplementedException();

        public Size Size => throw new NotImplementedException();

        public bool Displayed => throw new NotImplementedException();

        public void Clear ( )
            {
            throw new NotImplementedException();
            }

        #region Clicks
        public void SafeClick ( By locator )
            {
            FindElement(locator).Click();
            }

        #endregion

        #region InterfaceImplementation
        public IWebElement FindElement ( By locator )
            {
            //stopwatch
            try
                {
                return _selenium.FindElement(locator);

                }
            catch ( System.Exception ex )
                {
                _failMessage = $"Element with locator {locator} not found";
                _failMessageException = ex.ToString();
                }
            return _webDriver.FindElement(locator);
            }

        public ReadOnlyCollection<IWebElement> FindElements ( By by )
            {
            throw new NotImplementedException();
            }
        #endregion
        public string GetAttribute ( string attributeName )
            {
            throw new NotImplementedException();
            }

        public string GetCssValue ( string propertyName )
            {
            throw new NotImplementedException();
            }

        public string GetProperty ( string propertyName )
            {
            throw new NotImplementedException();
            }

        public void SendKeys ( string text )
            {
            throw new NotImplementedException();
            }

        public void Submit ( )
            {
            throw new NotImplementedException();
            }

        public void Click ( )
            {
            throw new NotImplementedException();
            }
        }
    }
