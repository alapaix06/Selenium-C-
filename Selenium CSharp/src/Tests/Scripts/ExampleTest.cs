using NUnit.Framework;
using Optional;
using Selenium_CSharp.Configurations;
using Selenium_CSharp.ExtentReport.Utility.ExtentReport;

namespace Selenium_CSharp.Tests.Scripts;

/*
 * This is a sample test class to demonstrate how to use the ExtentReport
 */
public sealed class ExampleTest : TestBase
{
    private WebDriverConfig _driverConfig;
    
    /// <summary>
    /// Method that configures everything that the tests need to start.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _driverConfig = new WebDriverConfig();
        Driver = _driverConfig.WebDriver;
        ExtentTestManager.CreatTest(TestContext.CurrentContext.Test.Name, Option.None<string>());
    }
    
    /// <summary>
    /// Demonstration test of the use of extent reports
    /// </summary>
    [Test]
    public void Example_Test_Using_Extent_Report()
    {
        Driver.Navigate().GoToUrl("https://www.google.com");
    }
    
    /// <summary>
    /// Method to finish test and build the report file
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        EndExtentReport();
        Driver.Dispose();
    }
}