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
public sealed class BirdBankStepDef
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
    private ScenarioContext _scenarioContext;
    private IWebDriver driver ;
    BirdBank _birdBank ;
    private static ExtentTest test;

    public BirdBankStepDef(ScenarioContext scenarioContext , IWebDriver driver)
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
        
      /*  _birdBank.ClickPurchase();
        _birdBank.ClickOrderNow();
        _birdBank.SelectGram("10");
        _birdBank.SelectGram("50");
        _birdBank.verifyGm();*/

    }

    [When(@"Navigate to Purchase tab")]
    public void NavigatePurchaseTab()
    {
        _birdBank.ClickPurchase();
    }

    [When("Select Purchase your digital gold")]
    public void ClickPurchaseGold()
    {
        _birdBank.ClickOrderNow();
    }
    
    [When("Add (.*) grams of gold to the cart")]
    public void SelectGm(string gm)
    {
        _birdBank.SelectGram(gm);
    }
    
    [Then("Verify the TotalGold")]
    public void VerifyTotalGold()
    {
        _birdBank.verifyGm();
    }

}