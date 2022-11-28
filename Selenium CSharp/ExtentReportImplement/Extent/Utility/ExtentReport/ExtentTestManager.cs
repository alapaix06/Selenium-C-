using System;
using System.Runtime.CompilerServices;
using AventStack.ExtentReports;
using Optional;

namespace Selenium_CSharp.ExtentReport.Utility.ExtentReport;

/// <summary>
/// Class that handles the elements of extent reports, to create test cases and others.
/// </summary>
public sealed class ExtentTestManager
{
    [ThreadStatic] private static ExtentTest _parentTest;

    [ThreadStatic] private static ExtentTest _childTest;

    /// <summary>
    /// Method to create the parent test, this will store all the child tests.
    /// </summary>
    /// <param name="testName">Get the name of the test</param>
    /// <param name="description">description of the test</param>
    /// <returns> the configured parent test</returns>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static ExtentTest CreateParentTests(string testName, Option<string> description)
    {
        description.Match(
            some: (value) =>
            {
                _parentTest = ExtentService.GetExtent().CreateTest(testName, value);
            },
            none: () =>
            {
                _parentTest = ExtentService.GetExtent().CreateTest(testName);
            });
        return _parentTest;
    }
    
    /// <summary>
    /// Method to create the sub tests, these run for each test that is in the test.
    /// </summary>
    /// <param name="testName">Get the name of the test</param>
    /// <param name="description">description of the test</param>
    /// <returns> the configured child test</returns>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static ExtentTest CreatTest(string testName, Option<string> description)
    {
        description.Match(
            some: (value) =>
            {
                _childTest = _parentTest.CreateNode(testName, value);
            },
            none: () =>
            {
                _childTest = _parentTest.CreateNode(testName);
            });
        return _childTest;
    }
    
    /// <summary>
    /// Method to obtain the result of the child test
    /// </summary>
    /// <returns>the configured child test</returns>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static ExtentTest GetTest()
    {
        return _childTest;
    }
}