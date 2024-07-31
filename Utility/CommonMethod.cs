
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProject1.Utility;

public class CommonMethod
{
    IWebDriver driver;
     WebDriverWait Webwait;
    
    public CommonMethod(IWebDriver driver) {
        this.driver = driver;
        Webwait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
    
    public string getpropertyvalue(string key)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        
        string path = Path.Combine(currentDirectory.Split("bin")[0], "Testdata", "Data.json");

        JObject jObject = JObject.Parse(File.ReadAllText(path));
        return (jObject[key].ToString());
    }

    public WebDriverWait wait()
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
    public  void clickElement(By lc)
    {
//        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

         wait().Until(ExpectedConditions.ElementExists(lc));
         driver.FindElement(lc).Click();
    }
  
    
    public  void enterValue(By lc, String value )
    {
        wait().Until(ExpectedConditions.ElementExists(lc));

       driver.FindElement(lc).Click();
       driver.FindElement(lc).Clear();
       driver.FindElement(lc).SendKeys(value);
    }

    public bool ElementVisible(By lc)
    {
        wait().Until(ExpectedConditions.ElementExists(lc));
        return driver.FindElement(lc).Displayed;
    }

    public void SetImplicitWait(int seconds)
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
    }
    
    public void WaitForElement(Func<IWebDriver, IWebElement> condition, int timeoutInSeconds)
    {
        try
        {
            // Use WebDriverWait to wait for the specified condition
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            customWait.Until(condition);
        }
        catch (WebDriverTimeoutException ex)
        {
            Console.WriteLine($"Timeout waiting for element: {ex.Message}");
            throw;
        }
    }
}