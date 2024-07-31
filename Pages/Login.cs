using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject1.Utility;

namespace SpecFlowProject1.Pages;

public class Login
{
    // Locators
    /* By Username = By.XPath("//input[@formcontrolname=\"username\"]"); 
     By Password = By.XPath("//input[@formcontrolname=\"password\"]");
     By Login_btn = By.XPath("//button[text()= ' Login  ']");
     private By Error = By.XPath("//mat-hint");*/
     
    public IWebDriver driver;
//    private ExtensionCommonMethod cm;
    
    // Locators using extension methods

     IWebElement Username => driver.FindElement(By.XPath("//input[@formcontrolname=\"username\"]"));
     IWebElement Password => driver.FindElement(By.XPath("//input[@formcontrolname=\"password\"]"));
     IWebElement Login_btn => driver.FindElement(By.XPath("//button[text()= ' Login  ']"));
     IWebElement Error => driver.FindElement(By.XPath("//mat-hint"));

    public Login(IWebDriver driver)
    {
        this.driver = driver;
     //   cm = new ExtensionCommonMethod(this.driver);
    }

    public void EnterUsername(string uname)
    {
        Username.enterValue(uname);
       // cm.enterValue(Username,uname);
    }
    
    public void EnterPassword(string pass)
    {
        Password.enterValue(pass);
        //cm.enterValue(Password,pass);
    }
    
    public void ClickLogin()
    {
        Login_btn.Click();
      //  cm.clickElement(Login_btn);
    }

    public bool ErrorMsgVisible()
    {
        return Error.ElementVisible();
//        return cm.ElementVisible(Error);
    }

    public void EnterUsernamePassword()
    {
        EnterUsername(ExtensionCommonMethod.getpropertyvalue("Username"));
        EnterUsername(ExtensionCommonMethod.getpropertyvalue("Password"));
        ClickLogin();
    }
}