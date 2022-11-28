using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Optional;

namespace Selenium_CSharp.Extent.Utility.ExtentReport;

/// <summary>
/// Class containing the service that configures and instantiates extent report.
/// </summary>
public sealed class ExtentService
{
    private static ExtentReports _extent;

    /// <summary>
    /// Method that configures the extent report
    /// </summary>
    /// <returns>configuration and instance of extent report</returns>
    public static ExtentReports GetExtent()
    {
        Option<ExtentReports> extentReportOption = _extent.SomeNotNull();
        
        extentReportOption.MatchNone(() =>
        {
            _extent = new ExtentReports();
            string reportDir = Path.Combine(Utility.GetProjectDirectory(), "Reports");
            string path = Path.Combine(reportDir, "index.html");
            ExtentHtmlReporter reporter = new(path);
            reporter.Config.DocumentTitle = "Framework Report";
            reporter.Config.ReportName = "Automation Reporter";
            reporter.Config.Theme = Theme.Standard;
            _extent.AttachReporter(reporter);
        });
        return _extent;
    }
}