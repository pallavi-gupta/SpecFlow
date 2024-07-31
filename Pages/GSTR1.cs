using NUnit.Framework;
using SpecFlowProject1.Utility;

namespace SpecFlowProject1.Pages;
using OpenQA.Selenium;

public class GSTR1
{
    public IWebDriver driver;
  //  private ExtensionCommonMethod cm ;
    
    public GSTR1(IWebDriver driver)
    {
        this.driver = driver;
     //   cm = new ExtensionCommonMethod(this.driver);
    }
    
    //Locators
   /*  By Dashboard = By.XPath("//*[@class=\"menu-trigger mat-button mat-button-base _mat-animation-noopable\"]");
     By Menu = By.XPath("//mat-icon[contains(text(), 'menu')]");
     By Return = By.XPath("//li[contains(@class,'main-menu ng-star-inserted')]//span[text()= 'Returns']");
     By Gstr = By.XPath("//li[contains(@class,'main-menu ng-star-inserted')]//span[text()= 'GSTR-1']");
     private By Upload = By.XPath(("//div[contains(@class,'page-step-container')]//div[contains(text(),'Upload')]"));
    */

   private IWebElement Dashboard =>
       driver.FindElement(By.XPath("//*[@class=\"menu-trigger mat-button mat-button-base _mat-animation-noopable\"]"));

   private IWebElement Menu =>
       driver.FindElement(By.XPath("//mat-icon[contains(text(), 'menu')]"));

   private IWebElement Return =>
       driver.FindElement(By.XPath("//li[contains(@class,'main-menu ng-star-inserted')]//span[text()= 'Returns']"));

   private IWebElement Gstr =>
       driver.FindElement(By.XPath("//li[contains(@class,'main-menu ng-star-inserted')]//span[text()= 'GSTR-1']"));

   private IWebElement Upload =>
       driver.FindElement(By.XPath("//div[contains(@class,'page-step-container')]//div[contains(text(),'Upload')]"));
  
   private IWebElement Fetch =>
       driver.FindElement(By.XPath("//div[contains(@class,'page-step-container')]//div[contains(text(),'Fetch')]"));

   
     // Methods
    public  void clickOnGSTR1()
    {
        Dashboard.clickElement();
        Menu.clickElement();
        Return.clickElement();
        Gstr.clickElement();
        
     /*   cm.clickElement(Dashboard);
        cm.clickElement(Menu);
        cm.clickElement(Return);
        cm.clickElement(Gstr);*/
    }

    public void ElementUploadVisible()
    {
        bool actual = Upload.ElementVisible(); 
     // bool actual =  cm.ElementVisible(Upload);
      Assert.True(actual);
    }

    public void clickOnFetch()
    {
        Fetch.clickElement();
    }

    public void SelectFInancialYear()
    {
        
    }

    public void ClickOnAplly()
    {
        
    }

    public void ClickOnCheckbox()
    {
        
    }

    public bool VerifyAbortMessage()
    {
        return true;
    }
}