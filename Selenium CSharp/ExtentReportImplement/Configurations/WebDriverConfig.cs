using OpenQA.Selenium.Chrome;

namespace Selenium_CSharp.Configurations;

/// <summary>
/// Represent the driver using for operations in selenium
/// </summary>
public sealed class WebDriverConfig
{
    /// <summary>
    /// Implement an instance of <see cref="ChromeDriver"/>
    /// </summary>
    public ChromeDriver WebDriver { get; }

    /// <summary>
    /// Implement an interface <see cref="WebDriverConfig"/>
    /// </summary>
    public WebDriverConfig()
    {
        ChromeOptions options = new();
        WebDriver = new ChromeDriver(options);
        WebDriver.Manage().Window.Maximize();
    }
}