using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using UITrelloAutomationFramework.Base;

namespace UITrelloAutomationFramework.PageObjects
{
    public class SignUpPage : BaseUIPage

    {
        private static readonly WebDriverWait wait = new(driver: _webDriver, timeout: TimeSpan.FromSeconds(10));

        private readonly By signUpButtonOnwelcomePage = By.XPath("//body//nav[@class='navbar py-3']//a[@href='/signup']");
        private readonly By enterEmailSignUpInput = By.XPath("/html//input[@id='email']");
        private readonly By signUpContinueButton = By.XPath("/html//input[@id='signup-submit']");
        private readonly By enterFullNameSignUpInput = By.XPath("/html//input[@id='displayName']");
        private readonly By createPasswordSignUpInput = By.XPath("/html//input[@id='password']");
        private readonly By signUpButton = By.XPath("//button[@id='signup-submit']//span[@class='css-t5emrf']");
        private readonly By viaGoogleAcctBtn = By.XPath("/ html//div[@id='google']");
        private readonly By useAnotherAccountBtn = By.ClassName("BHzsHc");
        private readonly By enterEmailFieldWhenSignUpViaGoogleAcct = By.XPath("/html//input[@id='identifierId']");
        private readonly By enterPasswordFieldWhenSignUpViaGoogleAcct = By.XPath("/html//div[@id='password']//input[@name='password']");
        private readonly By nextBtn = By.XPath("//div[@id='identifierNext']//button[@type='button']/span[@class='VfPpkd-vQzf8d']");



        public SignUpPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public void SignUpInTrello()
        {
            SafeClick(signUpButtonOnwelcomePage);
            var emailSignup = FindElement(enterEmailSignUpInput);
            string email = new Bogus.DataSets.Internet("en_GB").Email();
            emailSignup.SendKeys(email);

            SafeClick(signUpContinueButton);

            var fullNameSignUp = FindElement(enterFullNameSignUpInput);
            string fullName = new Bogus.DataSets.Name("en_GB").FullName();
            fullNameSignUp.SendKeys(fullName);
            var passwordSignUp = FindElement(createPasswordSignUpInput);
            string pwd = new Bogus.DataSets.Internet("en_GB").Password();
            passwordSignUp.SendKeys(pwd);

            SafeClick(signUpButton);


        }

        public void EnterUserEmailToSignUpViaGoogleAcct(string signUpViaGoogleAcct)
        {
            var email = FindElement(enterEmailFieldWhenSignUpViaGoogleAcct);
            email.SendKeys(signUpViaGoogleAcct);
        }

        public void EnterUserPasswordToSignUpViaGoogleAcct(string signUpViaGoogleAcct)
        {
            var password = FindElement(enterEmailFieldWhenSignUpViaGoogleAcct);
            password.SendKeys(signUpViaGoogleAcct);
        }

        #region ClickOnElement
        public void ClickSignUpBtnOnWelcomePage() => Click(signUpButtonOnwelcomePage);
        public void ClickSignUpViaGoogleAcct() => Click(viaGoogleAcctBtn);
        public void ClickUseAnotherAccount() => Click(useAnotherAccountBtn);
        public void ClickOnNextButton() => Click(nextBtn);


        #endregion


        #region GetMessageText
        #endregion


        #region WaitForElement
        public void WaitForEmailFieldWhenSignUpViaGoogleAcct() => wait.Until(d => d.FindElement(enterEmailFieldWhenSignUpViaGoogleAcct));
        public void WaitForPasswordFieldWhenSignUpViaGoogleAcct() => wait.Until(d => d.FindElement(enterPasswordFieldWhenSignUpViaGoogleAcct));
        public void WaitForUseAnotherAccountBtn() => wait.Until(d => d.FindElement(useAnotherAccountBtn));

        #endregion


    }
}
