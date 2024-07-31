using NUnit.Framework;
using SpecFlowProject1.Utility;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
namespace SpecFlowProject1.Pages;

public class BirdBank
{
    public IWebDriver driver;
    private CommonMethod cm;

    public BirdBank(IWebDriver driver)
    {
        this.driver = driver;
        cm = new CommonMethod(this.driver);
    }

    //Locators
    /*  By Dashboard = By.XPath("//*[@class=\"menu-trigger mat-button mat-button-base _mat-animation-noopable\"]");
      By Menu = By.XPath("//mat-icon[contains(text(), 'menu')]");
      By Return = By.XPath("//li[contains(@class,'main-menu ng-star-inserted')]//span[text()= 'Returns']");
      By Gstr = By.XPath("//li[contains(@class,'main-menu ng-star-inserted')]//span[text()= 'GSTR-1']");
      private By Upload = By.XPath(("//div[contains(@class,'page-step-container')]//div[contains(text(),'Upload')]"));
     */

    private IWebElement LoginBtn => driver.FindElement(By.Id("signin_button"));
    IWebElement Username => driver.FindElement(By.XPath("//*[@name='username']"));
    IWebElement Password => driver.FindElement(By.XPath("//*[@name='password']"));
    IWebElement Login_Loginbtn => driver.FindElement(By.Id("signin"));
    private IWebElement Purchase => driver.FindElement(By.Id("nav-purchase-tab"));

    private IWebElement OrderNow =>
        driver.FindElement(By.XPath("//*[text()='Purchase Your Digital Gold']/following-sibling::span"));

    private IWebElement DropablePurchase => driver.FindElement(By.Id("droppable"));

    string Gram = "//*[text()='value']/ancestor::div[contains(@id,'drag')]";
    private IWebElement selectGm(string gm) => driver.FindElement(By.XPath(Gram.Replace("value", gm)));
    private IWebElement TotalGold => driver.FindElement(By.Id("total_gold"));
    private IWebElement PayBill => driver.FindElement(By.Id("nav-paybills-tab"));

    private By accounttype = By.Id("accounttype");
    IWebElement accounttypedropdown => driver.FindElement(By.Id("accounttype"));
    IWebElement accountnumber1dropdown => driver.FindElement(By.Id("accountnumber1"));
    private IWebElement amount => driver.FindElement(By.Id("amount"));
    private IWebElement confirm => driver.FindElement(By.Id("confirm"));
    private IWebElement paymentDone => driver.FindElement(By.Id("confirmation1"));
    
   private IList<IWebElement> BillerRows => driver.FindElements(By.XPath("//table//tbody//tr"));

    
    // Methods

    public void ClickMainLogin() =>  LoginBtn.Click();
    public void EnterUsername(string uname) => Username.enterValue(uname);
    
    public void EnterPassword(string pass) =>  Password.enterValue(pass);
    
    public void ClickLogin() => Login_Loginbtn.Click();

    public void ClickPurchase() => Purchase.Click();
 
    public void ClickOrderNow() =>  OrderNow.Click();
    
    public void SelectGram(string gm) => 
        ExtensionCommonMethod.DragDrop(selectGm(gm), DropablePurchase, driver);

    public void verifyGm(string total) => Assert.AreEqual(total,TotalGold.GetByText());

    public void ClickPayBill()
    {
        cm.SetImplicitWait(10);
        PayBill.Click();
        cm.SetImplicitWait(10);
    }

    public void ClickOnTableRow(string biller)
    {
        int row = 1;
        foreach (IWebElement tableRow in BillerRows)
        {
            IList<IWebElement> BillerName = tableRow.FindElements(By.XPath("//td[1]"));
            Console.WriteLine("Biller Names List");
            foreach (IWebElement bilrname in BillerName)
            {
                string val = bilrname.Text;
                Console.WriteLine(val);
                if (val.Contains(biller))
                {
                    break;
                }
                else
                {
                    row++;
                }
            }
            
            cm.SetImplicitWait(10);
            IWebElement container = driver.FindElement(By.XPath("//*[@id='payee_data']//table")); 
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollLeft = 2000", container);

            Console.WriteLine("-------Scrolling Done---------");

            cm.SetImplicitWait(10);
            IWebElement YesBankBillerIcon = driver.FindElement(By.XPath("//table//tbody//tr["+row+"]//td[9]")); 
            YesBankBillerIcon.Click();
            
            break;
            }
        
        //   Console.ReadLine();
        Console.WriteLine("--------------");
       
    }
    
    public void SelectPaymentInfo()
    {
        cm.WaitForElement(ExpectedConditions.ElementToBeClickable(accounttype), 10);
        accounttypedropdown.SelectDropdownByText("CreditCard");
        accountnumber1dropdown.SelectDropdownByText("9999000453354530");
        amount.enterValue("50");
        confirm.Click();
        cm.SetImplicitWait(10);
        

       
    }
    
    public void verifyConfirmDone()
    {
        Assert.True(paymentDone.ElementVisible());
    }

}


