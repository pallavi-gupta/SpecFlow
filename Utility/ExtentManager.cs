namespace SpecFlowProject1.Utility;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

public static class ExtentManager
{
    private static ExtentReports extent;
    private static ExtentHtmlReporter htmlReporter;

    public static ExtentReports GetExtent()
    {
        if (extent == null)
        {
            string reportPath = System.IO.Directory.GetCurrentDirectory()+"/Reports/extent-report.html"; // Update with your desired path
            htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            // Customize your report here - optional
            extent.AddSystemInfo("Environment", "Testing Environment");

            // You can add more information to your report, such as a logo or custom information
            // htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

        }
        return extent;
    }

    public static void FlushExtent()
    {
        if (extent != null)
        {
            extent.Flush();
        }
    }
}