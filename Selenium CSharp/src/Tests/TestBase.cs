using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Optional;
using Selenium_CSharp.ExtentReport.Utility.ExtentReport;

namespace Selenium_CSharp.Tests;

public class TestBase
{
    protected WebDriver Driver;

    /// <summary>
    /// 
    /// </summary>
    [OneTimeSetUp]
    public void StartExtentReport()
    {
        ExtentTestManager.CreateParentTests(GetType().Name, Option.None<string>());
    }

    /// <summary>
    /// 
    /// </summary>
    protected void EndExtentReport()
    {
        TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;

        string? message = TestContext.CurrentContext.Result.Message;
        message = message.SomeWhen(msg => !string.IsNullOrEmpty(msg))
            .Match(
                some: msg => string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.Message),
                none: () => ""
            );

        switch (status)
        {
            case TestStatus.Failed:
                ReportLog.Fail("Fail Test", Option.None<MediaEntityModelProvider>());
                ReportLog.Fail(message, Option.None<MediaEntityModelProvider>());
                ReportLog.Fail("Screenshot", CaptureScreenShot(TestContext.CurrentContext.Test.Name).SomeNotNull());
                break;
            case TestStatus.Skipped:
                ReportLog.Skip("Test Skipped");
                break;
            case TestStatus.Passed:
                ReportLog.Pass("Test Passed");
                break;
        }
    }
    
    /// <summary>
    /// Tear down to end the extent report
    /// </summary>
    [OneTimeTearDown]
    public void TearDownExtent()
    {
        ExtentService.GetExtent().Flush();
    }

    /// <summary>
    /// Method to take screenshot and transform it into a base64
    /// </summary>
    /// <param name="name">the error name</param>
    /// <returns>return base64 string in media model provider</returns>
    private MediaEntityModelProvider CaptureScreenShot(string name)
    {
        string screenshot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;

        return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name).Build();
    }
}