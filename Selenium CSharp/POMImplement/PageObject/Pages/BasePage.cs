using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Selenium_CSharp.POMImplement.PageObject.Pages;

/// <summary>
/// Class contains all methods for using in base pages.
/// </summary>
public class BasePage
{
    protected readonly IWebDriver Driver;
    private readonly WebDriverWait _wait;
    private readonly int _timeout = 5;

    /// <summary>
    /// Implement an instance of <see cref="BasePage"/> 
    /// </summary>
    /// <param name="driver">>Property that assigns the values of the browser controller interface</param>
    protected BasePage(IWebDriver driver)
    {
        this.Driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_timeout));
        PageFactory.InitElements(driver, this);
    }

    /// <summary>
    /// Method for scrolling to the element
    /// </summary>
    /// <param name="element">property for wait expected a web element</param>
    /// <returns></returns>
    protected IWebElement ScrollToElement(IWebElement element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
        return (IWebElement)js.ExecuteScript($"arguments[0].scrollIntoView(true)", element);
    }

    /// <summary>
    /// Method to expect a web element to be clickable
    /// </summary>
    /// <param name="element">property for wait expected a web element</param>
    protected void WaitElementClickable(IWebElement element)
    {
        _wait.Until(ExpectedConditions.ElementToBeClickable(element));
    }
    
    /// <summary>
    /// Method to expect a web element that contains a specific text.
    /// </summary>
    /// <param name="element">property for wait expected a web element</param>
    /// <param name="textExpected">expected text to find element</param>
    protected void WaitElementByText(IWebElement element, string textExpected)
    {
        _wait.Until(ExpectedConditions.TextToBePresentInElement(element, textExpected));
    }
}