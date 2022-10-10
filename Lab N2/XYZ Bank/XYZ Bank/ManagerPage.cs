using OpenQA.Selenium;

namespace XYZ_Bank
{
    public class ManagerPage : BasePage
    {
        public ManagerPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        private IWebElement btnCustomers => driver.FindElement(By.XPath("//button[@ng-click='showCust()']"));

        public void ClickCustomers() => btnCustomers.Click();
    }
}
