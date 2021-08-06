using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using UITrelloAutomationFramework.Base;

namespace UITrelloAutomationFramework.PageObjects
{
    public class LoginPage : BaseUIPage
    {

        private readonly By logInButtonOnWelcomePage = (By.XPath("//body//nav[@class='navbar py-3']//a[@href='/login']"));
        private readonly By enterEmailInput = By.XPath("/html//input[@id='user']");
        private readonly By loginWithAtlassianButton = By.CssSelector("[value='Log in with Atlassian']");
        private readonly By loginWithLoginAfterEnterPwdButton = By.CssSelector("[value='Log in with Atlassian']");
        private readonly By continueButton = By.CssSelector("button#login-submit  .css-t5emrf");
        private readonly By enterPasswordInput = By.XPath("/html//input[@id='password']");
        private readonly By logInButtonOnLoginPage = By.Id("login-submit");
        private readonly By loginButtonOnLoginPageForValidation = By.XPath("//input[@id='login']");

        private readonly By missingEmailPassword = By.CssSelector("div#error > .error-message");
        private readonly By accountNotExist = By.XPath("//div[@id='error']/p[@class='error-message']");
        private readonly By tooManyIncorrectPwdAttempts = By.XPath("//*[@id='error']/p");

        private static readonly WebDriverWait wait = new WebDriverWait(driver: _webDriver, timeout: TimeSpan.FromSeconds(10));



        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void EnterUserEmailToLoginToTrello(string login )
        {
            var email = FindElement(enterEmailInput);
            email.SendKeys(login);
        
        }
        public void EnterPasswordToLoginToTrello(string pwd)
        {
        
            var password = FindElement(enterPasswordInput);
            password.SendKeys(pwd);
        }

        public void Login()
        {
            Click(logInButtonOnLoginPage);
        }

        public void LoginWithAttlassian()
        {
            Click(loginWithAtlassianButton);
        } 
        public void LoginWithButtonUnderPwdField()
        {
            Click(loginWithLoginAfterEnterPwdButton);
        }
        public void GoToLoginPage()
        {
            Click(logInButtonOnWelcomePage);
        }

        public string GetEmailValidationErrorMessage
        {
            get
            {
                return FindElement(missingEmailPassword).Text;
            }
        }

        [Obsolete]
        public string GetPwdValidationErrorMessage
        {
            get
            {
                return FindElement(missingEmailPassword).Text;
            }
        }

        public string GetNotExistingAccountValidationErrorMessage
        {
            get
            {
                SafeClick(loginButtonOnLoginPageForValidation);

                return FindElement(accountNotExist).Text;
            }
        }

        public string GetTooManyPasswordAttemptsValidationErrorMessage()
        {
            do
            {
                SafeClick(loginButtonOnLoginPageForValidation);
            }
            while (tooManyIncorrectPwdAttempts == null);

            return FindElement(tooManyIncorrectPwdAttempts).Text;
        }

        public string WaitForTooManyIncorrectPwdAttemptsError()
        {
            return wait.Until(d => d.FindElement(tooManyIncorrectPwdAttempts)).Text;
        }

        public void WaitUntilTooManyIncorrectPwdAttemptsErrorDisappear() => wait.Until(ExpectedConditions.InvisibilityOfElementLocated(tooManyIncorrectPwdAttempts));
    }
}

