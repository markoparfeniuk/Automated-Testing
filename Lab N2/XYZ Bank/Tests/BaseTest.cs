using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}