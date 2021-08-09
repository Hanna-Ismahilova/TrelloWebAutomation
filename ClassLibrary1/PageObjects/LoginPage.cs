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
        private readonly By loginToMakeValidationMsgDisplayedButton = By.Id("login");
        //private readonly By continueButton = By.CssSelector("button#login-submit  .css-t5emrf");
        private readonly By enterPasswordInput = By.XPath("//*[@id='password']");
        private readonly By logInButtonOnLoginPage = By.Id("login-submit");
        private readonly By loginButtonOnLoginPageForValidation = By.XPath("//input[@id='login']");
        private readonly By missingEmail = By.CssSelector("div#error > .error-message");
        private readonly By missingEmailPassword = By.Id("password-error");
        private readonly By accountNotExist = By.XPath("//div[@id='error']/p[@class='error-message']");
        private readonly By tooManyIncorrectPwdAttempts = By.XPath("//*[@id='error']/p");

        private static readonly WebDriverWait wait = new(driver: _webDriver, timeout: TimeSpan.FromSeconds(10));

        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void EnterUserEmailToLoginToTrello(string login)
        {
            var email = FindElement(enterEmailInput);
            email.SendKeys(login);
        }
        public void EnterPasswordToLoginToTrello(string pwd)
        {    
            var password = FindElement(enterPasswordInput);
            password.SendKeys(pwd);
        }

        #region ClickOnElement
        public void LoginOnWelcomeNavBar() => Click(logInButtonOnLoginPage);
        public void LoginWithAttlassian() => Click(loginWithAtlassianButton);
        public void LoginWithButtonUnderPwdField() => Click(loginWithLoginAfterEnterPwdButton);
        public void LoginToMakeValidationMsgDisplayed() => Click(loginToMakeValidationMsgDisplayedButton);
        public void LoginButtonLoginPageForValidation() => Click(loginButtonOnLoginPageForValidation);
        public void GoToLoginPage() => Click(logInButtonOnWelcomePage);
        #endregion

        #region GetMessageText
        public string GetEmailValidationErrorMessage => FindElement(missingEmail).Text;
        public string GetPwdValidationErrorMessage => FindElement(missingEmailPassword).Text;
        public string GetNotExistingAccountValidationErrorMessage => FindElement(accountNotExist).Text;

        public bool GetTooManyPasswordAttemptsValidationErrorMessage()
        {
            do
            {
                LoginButtonLoginPageForValidation();
                
            } while (FindElement(tooManyIncorrectPwdAttempts) != null);

            return FindElement(tooManyIncorrectPwdAttempts).Displayed;
        }
        #endregion

        #region WaitForElement
        public void WaitForLoginWithAtlassianButton() => wait.Until(d => d.FindElement(loginWithAtlassianButton));
        public string WaitForTooManyIncorrectPwdAttemptsError() => wait.Until(d => d.FindElement(tooManyIncorrectPwdAttempts)).Text;
        public void WaitUntilTooManyIncorrectPwdAttemptsErrorDisappear() => wait.Until(d => d.FindElement(tooManyIncorrectPwdAttempts));
        public void WaitForEmailValidationErrorMessage() => wait.Until(d => d.FindElement(missingEmail));
        public void WaitForPwdValidationErrorMessage() => wait.Until(d => d.FindElement(missingEmailPassword));
        public void WaitForNotExistingAccountValidationErrorMessage() => wait.Until(d => d.FindElement(accountNotExist));
        #endregion

    }
}

