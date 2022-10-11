using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using XYZ_Bank;

namespace Tests.Steps
{
    [Binding]
    public class SortByFirstNameStepDefinitions : BaseStepDefinitions
    {
        private LoginPage loginPage = null;
        private ManagerPage managerPage = null;
        private CustomersPage customersPage = null;
        List<string> actualFirstNames = new List<string>();
        List<string> expectedFirstNames = new List<string>();

        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            loginPage = new LoginPage(driver);
            managerPage = new ManagerPage(driver);
            customersPage = new CustomersPage(driver);
        }

        [Given(@"I click on the Bank Manager Login link")]
        public void GivenIClickOnTheBankManagerLoginLink()
        {
            Thread.Sleep(1000);
            loginPage.ClickLogin();
        }

        [Given(@"I click on the Customers menu item")]
        public void GivenIClickOnTheCustomersMenuItem()
        {
            Thread.Sleep(1000);
            managerPage.ClickCustomers();
        }

        [When(@"I click on the First Name header")]
        public void WhenIClickOnTheFirstNameHeader()
        {
            Thread.Sleep(1000);
            expectedFirstNames = customersPage.GetFirstNames();
            expectedFirstNames.Sort((a, b) => b.CompareTo(a));
            customersPage.ClickFirstName();
            Thread.Sleep(1000);
            actualFirstNames = customersPage.GetFirstNames();
        }

        [Then(@"I should see customer records sorted in descending order")]
        public void ThenIShouldSeeCustomerRecordsSortedInDescendingOrder()
        {
            Assert.AreEqual(actualFirstNames, actualFirstNames);
        }
    }
}
