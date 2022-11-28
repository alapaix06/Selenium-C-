using AventStack.ExtentReports;
using OpenQA.Selenium;
using Optional;

namespace Selenium_CSharp.Extent.Utility.ExtentReport;

/// <summary>
/// / Class that contains the different methods for the answers of the tests and integrates them as extent reports
/// </summary>
public sealed class ReportLog
{
    private IWebDriver _driver;
    
    /// <summary>
    /// Method that performs pass the log in the test report
    /// </summary>
    /// <param name="message">Successful completion pass message</param>
    public static void Pass(string message)
    {
        ExtentTestManager.GetTest().Pass(message);
    }
    
    /// <summary>
    ///  Method that performs fail the log in the test report
    /// </summary>
    /// <param name="message">Successful completion fail message</param>
    /// <param name="media">Media type elements, whether they are images and screenshots</param>
    public static void Fail(string message, Option<MediaEntityModelProvider> media)
    {
        media.Match(
            some: (value) =>
            {
                ExtentTestManager.GetTest().Fail(message, value);
            },
            none: () =>
            {
                ExtentTestManager.GetTest().Fail(message);
            });
    }
    
    /// <summary>
    /// Method that performs skip the log in the test report
    /// </summary>
    /// <param name="message">Successful completion skipped message</param>
    public static void Skip(string message)
    {
        ExtentTestManager.GetTest().Skip(message);
    }
}