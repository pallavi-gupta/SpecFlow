using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Gherkin.CucumberMessages.Types;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject1.Hooks;
using OpenQA.Selenium.Chrome;
using SpecFlowProject1.Drivers;
using SpecFlowProject1.Pages;
using SpecFlowProject1.Utility;
using WebDriver = SpecFlowProject1.Drivers.WebDrivers;

namespace SpecFlowProject1.Steps;
using NUnit;

[Binding]
public sealed class GSTR1StepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
    private ScenarioContext _scenarioContext;
    private IWebDriver driver ;
    Login ln ;
    GSTR1 gstr;
    private static ExtentTest test;
   // private ExtensionCommonMethod cm;
   
  //   private var htmlreporrter = new ExtentSparkReporter("/Users/pallavigupta/Projects/SpecFlowCalculator/SpecFlowProject1/Reports/index.html");
    
  //  private readonly Calculator _calculator = new Calculator();


    public GSTR1StepDefinitions(ScenarioContext scenarioContext , IWebDriver driver)
    {
        this.driver = driver;
        _scenarioContext = scenarioContext;
        //cm = new ExtensionCommonMethod(this.driver);
        gstr = new GSTR1(this.driver);
        ln = new Login(this.driver);
    }

    [Given("Enter the PWC URL")]
    public void EnterThePWCURL()
    {
        Console.WriteLine("**************"+ExtensionCommonMethod.getpropertyvalue("URL"));
        driver.Navigate().GoToUrl(ExtensionCommonMethod.getpropertyvalue("URL"));
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

     //  driver = _scenarioContext.Get<WebDriver>("Driver").Setup();
     //  driver.Url = cm.getpropertyvalue("URL");
    }

    [Given(@"Enter the (.*) and (.*)")]
    public void EnterUsernamePassword(string username , string password)
    { 
       ln.EnterUsername(username);
       ln.EnterPassword(password);
       ln.ClickLogin();
    }
    
    [When("User clicks on GSTR1 page")]
    public void UserClickOnGSTR1Page()
    {
        gstr.clickOnGSTR1();
    }
    
    [Then("Verify User Navigates to the GSTR1 Page")]
    public void VerifyUserOnGSTR1Page()
    {
        gstr.ElementUploadVisible();
    }
    
    [Then("Verify User should see incorrect cred error")]
    public void verifyIncorrectpasswrdError()
    {
        bool vis = ln.ErrorMsgVisible();
       Assert.True(vis);
    }

    
    [Given(@"Enter the valid credentials to login")]
    public void EnterUsernamePassword()
    { 
        ln.EnterUsernamePassword();
    }
   
}