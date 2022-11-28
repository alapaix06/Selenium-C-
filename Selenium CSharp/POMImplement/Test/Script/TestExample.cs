using NUnit.Framework;
using Optional;
using Selenium_CSharp.Configurations;
using Selenium_CSharp.ExtentReport.Utility.ExtentReport;
using Selenium_CSharp.POMImplement.PageObject.Pages;


namespace Selenium_CSharp.POMImplement.Test.Script;

/*
 * This class is used to test the functionality of the Login Page
 */
[TestFixture]
public sealed class TestExample : TestBase
{
    private WebDriverConfig _config;
    private LoginPage _loginPage;
    private readonly string _baseUrl = "https://practicetestautomation.com/practice-test-login/";
    private readonly string _titleExpected = "Logged In Successfully | Practice Test Automation";

    /// <summary>
    /// Method that configures everything that the tests need to start.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _config = new WebDriverConfig();
        Driver = _config.WebDriver;
        _loginPage = new LoginPage(Driver);
        ExtentTestManager.CreatTest(TestContext.CurrentContext.Test.Name, Option.None<string>());
    }

    /// <summary>
    /// Test the functionality of the Login Page
    /// </summary>
    /// <param name="username">receive username for login</param>
    /// <param name="password">receive password for login</param>
    [Test, Order(1), Parallelizable]
    [TestCase("student", "Password123")]
    public void Test_Example_Page_Object_Model(string username, string password)
    {
        Driver.Navigate().GoToUrl(_baseUrl);
        _loginPage.Login(username, password);
        Assert.AreEqual(_titleExpected, Driver.Title);
        Assert.IsTrue(_loginPage.IsLoginSuccess());
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