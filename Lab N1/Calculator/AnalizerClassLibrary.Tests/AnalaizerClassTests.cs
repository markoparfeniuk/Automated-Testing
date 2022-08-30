using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnalaizerClassLibrary.Tests
{
    [TestClass]
    public class AnalaizerClassTests
    {
        public TestContext TestContext { get; set; }

        [DataSource("System.Data.SqlClient", @"Data Source=(LocalDB)\MSSQLLocalDB;Database=UnitTesting;Trusted_Connection=True;MultipleActiveResultSets=true", "TestData", DataAccessMethod.Sequential)]
        [TestMethod]
        public void CreateStack_FromDataSourceTest()
        {
            // Arrange
            string initial = (string)TestContext.DataRow["initial"];
            string expected = (string)TestContext.DataRow["expected"];
            AnalaizerClass.expression = initial;

            // Actual
            string actual = string.Join("", AnalaizerClass.CreateStack().ToArray());

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}