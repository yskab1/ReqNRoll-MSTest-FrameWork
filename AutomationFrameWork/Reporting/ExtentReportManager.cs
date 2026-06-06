using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using System;
using System.IO;

namespace Framework.Core.Reporting
{
    public static class ExtentReportManager
    {
        private static ExtentReports _extent;
        [ThreadStatic]
        private static ExtentTest _scenarioTest;

        private static readonly string ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "ExecutionReport.html");

        public static void InitializeReport()
        {
            if (_extent == null)
            {
                var directory = Path.GetDirectoryName(ReportPath);
                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

                var htmlReporter = new ExtentSparkReporter(ReportPath);

                // FIX: In v3, use .Configuration() instead of .Config
                htmlReporter.Config.DocumentTitle = "Automation Execution Metrics Dashboard";
                htmlReporter.Config.ReportName = "Automation Report";
                htmlReporter.Config.Theme = Theme.Dark;

                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);

                // FIX: In v3, use AddSystemInfo
                _extent.AddSystemInfo("Execution Framework", ".NET 8 C# Source");
                _extent.AddSystemInfo("Engine Core", "Selenium WebDriver 4");
            }
        }

        public static void CreateScenario(string scenarioName)
        {
            // FIX: Make sure the created test assignment runs smoothly
            _scenarioTest = _extent?.CreateTest(scenarioName);
        }

        public static void LogStep(string stepText)
        {
            _scenarioTest?.Log(Status.Info, stepText);
        }

        public static void LogPass(string details)
        {
            _scenarioTest?.Log(Status.Pass, details);
        }

        public static void LogFail(string errorMessage, string screenshotBase64 = null)
        {
            _scenarioTest?.Log(Status.Fail, $"<b>Execution Failure Message:</b><br/>{errorMessage}");

            if (!string.IsNullOrEmpty(screenshotBase64))
            {
                // FIX: MediaEntityBuilder takes exactly 1 parameter in v3
                var mediaEntity = MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotBase64).Build();
                _scenarioTest?.Fail("Screenshot Attached:", mediaEntity);
            }
        }

        public static void FinalizeReport()
        {
            _extent?.Flush();
        }

    }
}
