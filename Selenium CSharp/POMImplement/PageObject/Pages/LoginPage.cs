using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium_CSharp.POMImplement.PageObject.Pages;

/// <summary>
/// Class that references the login page
/// </summary>
public sealed class LoginPage : BasePage
{
    private readonly string _textExpected = "Logged In Successfully";
    
    /// <summary>
    /// Implement an instance of <see cref="LoginPage"/> 
    /// </summary>
    /// <param name="driver">Property that assigns the values of the browser controller interface</param>
    public LoginPage(IWebDriver driver) : base(driver)
    {
        PageFactory.InitElements(driver, this);
    }

    [FindsBy(How = How.Id, Using = "username")]
    [CacheLookup]
    private IWebElement Username { get; set; }

    [FindsBy(How = How.Id, Using = "password")]
    [CacheLookup]
    private IWebElement Password { get; set; }

    [FindsBy(How = How.Id, Using = "submit")]
    [CacheLookup]
    private IWebElement Submit { get; set; }

    [FindsBy(How = How.XPath, Using = "//h1[contains(@class,'post-title')]")]
    [CacheLookup]
    private IWebElement LabelLoginSuccess { get; set; }

    /// <summary>
    /// Method to login
    /// </summary>
    /// <param name="username">property that receives the string from a user</param>
    /// <param name="password">property that receives the string from a password</param>
    public void Login(string username, string password)
    {
        WaitElementClickable(Username);
        Username.SendKeys(username);
        Password.SendKeys(password);
        Submit.Submit();
    }

    /// <summary>
    /// Method that waits for the login label success
    /// </summary>
    /// <returns>true if the element was displayed</returns>
    public bool IsLoginSuccess()
    {
        WaitElementByText(LabelLoginSuccess, _textExpected);
        return LabelLoginSuccess.Displayed;
    }
    
    /// <summary>
    /// Method that looks for the title of the page
    /// </summary>
    /// <returns>A string of the page title</returns>
    public string PageTitle()
    {
        return Driver.Title;
    }
}