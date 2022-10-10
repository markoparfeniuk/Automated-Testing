using NUnit.Framework;
using XYZ_Bank;

namespace Tests
{
    public class BankManagerLoginTests : BaseTest
    {
        [Test]
        public void SortCustomersByFirstName()
        {
            // Arrange
            List<string> actualFirstNames = new List<string>();
            List<string> expectedFirstNames = new List<string>();
            LoginPage loginPage = new LoginPage(driver);
            ManagerPage managerPage = new ManagerPage(driver);
            CustomersPage customersPage = new CustomersPage(driver);

            // Act
            Thread.Sleep(1000);
            loginPage.ClickLogin();
            Thread.Sleep(1000);
            managerPage.ClickCustomers();
            Thread.Sleep(1000);
            expectedFirstNames = customersPage.GetFirstNames();
            expectedFirstNames.Sort((a, b) => b.CompareTo(a));
            customersPage.ClickFirstName();
            Thread.Sleep(1000);
            actualFirstNames = customersPage.GetFirstNames();

            // Assert
            Assert.AreEqual(expectedFirstNames, actualFirstNames);
        }
    }
}
