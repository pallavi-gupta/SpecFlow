
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowProject1.Utility;

public static class ExtensionCommonMethod
{
    public static string getpropertyvalue(string key)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        
        string path = Path.Combine(currentDirectory.Split("bin")[0], "Testdata", "Data.json");

        JObject jObject = JObject.Parse(File.ReadAllText(path));
        return (jObject[key].ToString());
    }

    // First Argument needs to be the this keyword with data type
    public static void clickElement(this IWebElement locator)
    {
        locator.Click();
    }
    
    public static void enterValue(this IWebElement locator, String value )
    {
       locator.Click();
       locator.Clear();
       locator.SendKeys(value);
    }

    public static bool ElementVisible(this IWebElement locator)
    {
        return locator.Displayed;
    }
    
    public static void DragDrop(IWebElement Sourcelc, IWebElement Destination , IWebDriver driver)
    {
        Actions builder = new Actions(driver);
        builder.ClickAndHold(Sourcelc).MoveToElement(Destination).Release().Perform();
    }

    public static string GetByText(this IWebElement locator)
    {
        return locator.Text;
    }
    
    public static void SelectDropdownByText(this IWebElement locator , string value )
    {
        SelectElement select = new SelectElement(locator);
        select.SelectByText(value);
    }
}