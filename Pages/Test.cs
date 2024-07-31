using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;

namespace SpecFlowProject1.Pages;

 [TestFixture]
    public class Tests
    {
       /* private ExtentReports _extent;
        private ExtentTest _test;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Initialize ExtentReports
            var htmlReporter = new ExtentHtmlReporter("extentReport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            
            Console.WriteLine(" // Initialize ExtentReports Done");
        }

        [SetUp]
        public void SetUp()
        {
            // Create a test in the report
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            
            Console.WriteLine("// Create a test in the report");
        }

        [Test]
        public void Test1()
        {
            try
            {
                // Test logic
                Assert.IsTrue(true);

                // Log success
                _test.Pass("Test1 passed successfully.");
            }
            catch (Exception ex)
            {
                // Log failure
                _test.Fail("Test1 failed with exception: " + ex.Message);
                throw;
            }
        }

        [Test]
        public void Test2()
        {
            try
            {
                // Test logic
                Assert.IsTrue(false);

                // Log success
                _test.Pass("Test2 passed successfully.");
            }
            catch (Exception ex)
            {
                // Log failure
                _test.Fail("Test2 failed with exception: " + ex.Message);
                throw;
            }
        }

        [TearDown]
        public void TearDown()
        {
            // Log test result
            
            Console.WriteLine("Tear Down Entered");
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                _test.Fail("Test failed with message: " + message);
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                _test.Pass("Test passed.");
            }
            Console.WriteLine("Tear Down Done");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Flush the report
            _extent.Flush();
            Console.WriteLine("Flush Done");
        }
   */ }
