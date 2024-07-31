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
public sealed class BirdBankStepDefinition
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
    private ScenarioContext _scenarioContext;
    private IWebDriver driver ;
    BirdBank _birdBank ;
    private static ExtentTest test;

    public BirdBankStepDefinition(ScenarioContext scenarioContext , IWebDriver driver)
    {
        this.driver = driver;
        _scenarioContext = scenarioContext;
        _birdBank = new BirdBank(this.driver);
    }

    [Given("Enter the BirdBank URL")]
    public void EnterThBirdBankeURL()
    {
        Console.WriteLine("**************"+ExtensionCommonMethod.getpropertyvalue("BirdBank"));
        driver.Navigate().GoToUrl(ExtensionCommonMethod.getpropertyvalue("BirdBank"));
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        _birdBank.ClickMainLogin();

    }

    [Given(@"Enter the valid Bird Bank credentials to login")]
    public void EnterValidUsernamePassword()
    { 
        _birdBank.EnterUsername(ExtensionCommonMethod.getpropertyvalue("BirdBankUsername"));
        _birdBank.EnterPassword(ExtensionCommonMethod.getpropertyvalue("BirdBankPassword"));
        _birdBank.ClickLogin();
    }

    [When(@"Navigate to Purchase tab")]
    public void NavigatePurchaseTab() => _birdBank.ClickPurchase();
 

    [When("Select Purchase your digital gold")]
    public void ClickPurchaseGold() => _birdBank.ClickOrderNow();
  
    
    [When("Add (.*) grams of gold to the cart")]
    public void SelectGm(string gm) =>  _birdBank.SelectGram(gm);
  
    
    [Then("Verify the TotalGold (.*)")]
    public void VerifyTotalGold(string total) =>  _birdBank.verifyGm(total);
  

    [When(@"Navigate to Pay Bill tab")]
    public void NavigatePayBillTab()=> _birdBank.ClickPayBill();

    [When("Select (.*) from the Bill Payment Table")]
    public void SelectBiller(string biller) => _birdBank.ClickOnTableRow(biller);
    
    [When("Enter Payment Information")]
    public void EnterPaymentInformation() => _birdBank.SelectPaymentInfo();
    
    [Then("Verify the Confirm Payment Banner")]
    public void VerifyConfirmPaymentBanner() =>  _birdBank.verifyConfirmDone();
    
    [Given("Enter the Practice URL")]
    public void EnterThePracticeURL()
    {
        Console.WriteLine("**************"+ExtensionCommonMethod.getpropertyvalue("BirdBank"));
        driver.Navigate().GoToUrl("https://www.letskodeit.com/practice");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        
        driver.FindElement(By.Id("openwindow")).Click();
     //   _birdBank.ClickMainLogin();

    }
  
}