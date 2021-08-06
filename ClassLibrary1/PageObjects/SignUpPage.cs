using OpenQA.Selenium;
using UITrelloAutomationFramework.Base;

namespace UITrelloAutomationFramework.PageObjects
{
    public class SignUpPage : BaseUIPage

    {

        private readonly By signUpButtonOnwelcomePage = By.XPath("//body//nav[@class='navbar py-3']//a[@href='/signup']");
        private readonly By enterEmailSignUpInput = By.XPath("/html//input[@id='email']");
        private readonly By signUpContinueButton = By.XPath("/html//input[@id='signup-submit']");
        private readonly By enterFullNameSignUpInput = By.XPath("/html//input[@id='displayName']");
        private readonly By createPasswordSignUpInput = By.XPath("/html//input[@id='password']");
        private readonly By signUpButton = By.XPath("//button[@id='signup-submit']//span[@class='css-t5emrf']");

        //TODO:
        private readonly By viaGoogleAcct = By.XPath("/ html//div[@id='google']");

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

        public void SignUpInTrelloViaGoogleAcct()
        {
            SafeClick(signUpButtonOnwelcomePage);
            SafeClick(viaGoogleAcct);

        }


    }
}
