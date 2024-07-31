using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject1.Utility;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace SpecFlowProject1.Drivers
{
    public class WebDrivers
    {
         IWebDriver driver;

        public IWebDriver GetBrowserInstance()
        {
            string brow = ExtensionCommonMethod.getpropertyvalue("Browser").ToLower();
            switch (brow)
            {
                case "firefox":
                    configFirefoxDriver();
                    break;

                case "chrome":
                    configChromeDriver();
                    break;

                case "ie":
                    configIEDriver();
                    break;

                default: Console.WriteLine("Incorrect ");
                    break;
            }

            return driver;
        }

        private void configFirefoxDriver()
        {
            driver = new FirefoxDriver();
        }
        
        private void configChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            
            driver = new ChromeDriver();
        }
        
        private void configIEDriver()
        {
            driver = new InternetExplorerDriver();
        }


        public void CloseDriver()
        {
            driver.Quit();
        }
    }
}