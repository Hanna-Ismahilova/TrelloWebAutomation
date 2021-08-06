using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace UITrelloAutomationFramework.Base.Elements
{
    public abstract class WebSafeElements : IWebElement
    {

        private readonly ISearchContext _selenium;
        private readonly By _locator;
        private readonly bool _breakIfNotFound;
        private readonly double _timeout;
        protected static IWebDriver _webDriver;
        protected IWebElement _webElement;
        private string _failMessage;
        private string _failMessageException;

        public WebSafeElements()
        {

        }
        public WebSafeElements(IWebDriver webDriver)
        {
            _webDriver = webDriver;

        }

        public WebSafeElements(ISearchContext selenium, By by, double timeout, bool breakIfNotFound)
        {
            _selenium = selenium;
            _locator = by;
            _timeout = timeout;
            _breakIfNotFound = breakIfNotFound;

        }

        public string TagName => throw new NotImplementedException();

        public string Text(By locator)
        {
            FindElement(locator).Text.CompareTo(locator);
            return null;
        }

        public bool Enabled => throw new NotImplementedException();

        public bool Selected => throw new NotImplementedException();

        public Point Location => throw new NotImplementedException();

        public Size Size => throw new NotImplementedException();

        public bool Displayed => throw new NotImplementedException();

        string IWebElement.Text => _webElement.Text;

        public void Clear()
        {
            throw new NotImplementedException();
        }

        #region Clicks
        public void SafeClick(By locator)
        {
            FindElement(locator).Click();
        }

        public Actions DoubleClick(By locator)
        {
            FindElement(locator).Click();
            return null;
        }

        #endregion

        #region InterfaceImplementation
        public IWebElement FindElement(By locator)
        {

                try
                {
                    return _selenium.FindElement(locator);

                }
                catch (Exception ex)
                {
                    _failMessage = $"Element with locator {locator} not found";
                    _failMessageException = ex.ToString();
                }
                return _webDriver.FindElement(locator);
        }
    

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }
        #endregion
        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            throw new NotImplementedException();
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public void Click(By locator)
        {
            FindElement(locator).Click();
        }

        #region Helpers
        private dynamic ReturnOrFail(object toCheck)
        {
            if (toCheck == null)
            {
                switch (_breakIfNotFound)
                {
                    case true:
                        Assert.Fail($"{_failMessage} during {_timeout} seconds.Exception:{_failMessageException}");
                        break;
                    case false:
                        return null;
                }
            }
            return toCheck;
        }

        public void Click()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
