using TechTalk.SpecFlow;
using XYZ_Bank;

namespace Tests.Steps
{
    [Binding]
    public class ManagerStepDefinitions : BaseSteps
    {
        private ManagerPage managerPage;

        [Given(@"I click on the Customers menu item")]
        public void GivenIClickOnTheCustomersMenuItem()
        {
            managerPage = new ManagerPage(driver);
            Thread.Sleep(1000);
            managerPage.ClickCustomers();
        }
    }
}
