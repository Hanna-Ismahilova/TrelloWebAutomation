using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UITrelloAutomationFramework.Base;
using UITrelloAutomationFramework.Helpers;

namespace BDDTrelloWebAutomation.Steps
{
    [Binding]
    public sealed class Hooks : DriverInit
    {
        private IWebDriver webDriver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            AppConfig.Load();
            webDriver = WebDriverStart();
            LoadPage();

        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriverStop();
        }
    }
}
