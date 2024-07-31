using AventStack.ExtentReports;
using BoDi;
using OpenQA.Selenium.Chrome;
using SpecFlowProject1.Utility;
using SpecFlowProject1.Drivers;
using OpenQA.Selenium;
using AventStack.ExtentReports.Gherkin.Model;

namespace SpecFlowProject1.Hooks 
{
    [Binding]
    public class Hooks  : ExtentReport
    {
        private static ExtentReports extent;
        private static ExtentTest featurename;
        private static ExtentTest ScenarioName;
        private readonly ScenarioContext _scenarioContext;
        public readonly IObjectContainer _Container;
        WebDrivers webDrivers = new WebDrivers();

        public Hooks(IObjectContainer container , ScenarioContext scenarioContext)
        {
            _Container = container;
            _scenarioContext = scenarioContext;
        }
        
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("BeforeTestRun Started ");

           ExtentReportInit();
           
            Console.WriteLine("BeforeTestRun Ends ");

        }
        
        [AfterTestRun]
        public  static void AfterTestRun()
        {
            Console.WriteLine();
            Console.WriteLine("AfterTestRun Started ");
            SeleniumEmailReport SER = new SeleniumEmailReport();
            SER.Mail();
            ExtentReportTearDown();
            
            Console.WriteLine("AfterTestRun Ends ");
            Console.WriteLine();

        }
        
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("BeforeFeature Started ");
            ExtentReportInit();
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
       
            Console.WriteLine("BeforeFeature Ends ");
            Console.WriteLine();

        }
        
        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("AfterFeature Started ");
            
            Console.WriteLine("AfterFeature Ends ");

        }
        
        [BeforeScenario]
        public  void BeforeScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine("BeforeScenario Started ");

         //   Driver driver= new Driver(_scenarioContext);
         //   _scenarioContext.Set(driver,"Driver");
         
        
         IWebDriver driver =webDrivers.GetBrowserInstance();
                
                // new ChromeDriver();
            driver.Manage().Window.Maximize();
         
            _Container.RegisterInstanceAs<IWebDriver>(driver);
            
             _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            
            Console.WriteLine("BeforeScenario Ends ");

        }
        
        [AfterScenario]
        public  void AfterScenario()
        {
            Console.WriteLine("AfterScenario Started ");
            var driver = _Container.Resolve<IWebDriver>();
            if (driver != null)
            {
                webDrivers.CloseDriver();  
            }
            Console.WriteLine("AfterScenario Ends ");

        }
        
        [BeforeScenarioBlock]
        public  void BeforeScenarioBlock()
        {
            Console.WriteLine("BeforeScenarioBlock Started ");
            Console.WriteLine("BeforeScenarioBlock Ends ");

        }
        
        [AfterScenarioBlock]
        public  void AfterScenarioBlock()
        {
            Console.WriteLine("AfterScenarioBlock Started ");
            Console.WriteLine("AfterScenarioBlock Ends ");

        }
        
        [BeforeStep]
        public  void BeforeStep()
        {
            Console.WriteLine("BeforeStep Started ");
            Console.WriteLine("BeforeStep Ends ");

        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("AfterStep Started ");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            var driver = _Container.Resolve<IWebDriver>();

            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            }

            //When scenario fails
            if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,

                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
            }
        }
    }
}