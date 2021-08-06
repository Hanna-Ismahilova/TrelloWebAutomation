

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using UITrelloAutomationFramework.Base;

namespace BDDTrelloWebAutomation.PageObjects
{
    public class LoginPageObject : BaseUIPage
    {

        private readonly By linkLogin = (By.XPath("/html/body/header/nav/div/a[1]"));
        private readonly By textUserEmail = (By.Name("user"));
        private readonly By textUserPassword = (By.Name("password"));
        private readonly By linkLoginWithAtlassian = (By.CssSelector("[value='Log in with Atlassian']"));
        private readonly By linkLoginFinal = (By.XPath("/html//button[@id='login-submit']"));

        public IWebElement WaitForLinkLoginWithAtlassian
        {
            get
            {
                return wait.Until(d => d.FindElement(linkLoginWithAtlassian));
            }
        }

        public LoginPageObject(IWebDriver webDriver) : base(webDriver)
        {

        }

        private static readonly WebDriverWait wait = new(driver: _webDriver, timeout: TimeSpan.FromSeconds(10));

        public void ClickLoginBtnOnMainPage() => Click(linkLogin);
        public void ClickLoginWithAtlassianBtn() => Click(linkLoginWithAtlassian);
        public void ClickFinalLoginBtn() => Click(linkLoginFinal);

        public void LoginForm(string userEmail = "", string pwd = "")
        {
            var email = FindElement(textUserEmail);
            email.SendKeys(userEmail);
            var password = FindElement(textUserPassword);
            password.SendKeys(pwd);
        }
    }
}
