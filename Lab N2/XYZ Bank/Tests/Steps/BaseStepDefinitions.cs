using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Tests.Steps
{
    [Binding]
    public class BaseStepDefinitions
    {
        protected IWebDriver driver;

        [BeforeScenario("@smoke")]
        public void BeforeScenarioWithTag()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject/");
        }

        [AfterScenario("@smoke")]
        public void AfterScenarioWithTag()
        {
            driver.Close();
        }
    }
}