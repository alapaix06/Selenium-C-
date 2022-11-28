using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium_CSharp.POMImplement.PageObject.Pages;

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
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    public void Login(string username, string password)
    {
        WaitElementClickable(Username);
        Username.SendKeys(username);
        Password.SendKeys(password);
        Submit.Submit();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsLoginSuccess()
    {
        WaitElementByText(LabelLoginSuccess, _textExpected);
        return LabelLoginSuccess.Displayed;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string PageTitle()
    {
        return Driver.Title;
    }
}