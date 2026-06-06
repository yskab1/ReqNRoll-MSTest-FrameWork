using Framework.Core.Reporting;
using FrameWork.Core.UI;
using Reqnroll;


namespace Framework.Tests.Hooks
{
    [Binding]
    public class TestHooks
    {
        private Browser _browser;

        [BeforeTestRun]
        public static void GlobalSetup()
        {

            ExtentReportManager.InitializeReport();
        }

        [BeforeScenario]
        public void InitializeScenarioContext(ScenarioContext scenarioContext)
        {
            _browser = new Browser();
            ExtentReportManager.CreateScenario(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void LogStepExecutionMetrics(ScenarioContext scenarioContext)
        {
            var stepText = scenarioContext.StepContext.StepInfo.Text;
            ExtentReportManager.LogStep(stepText);
        }

        [AfterScenario]
        public void FinalizeScenarioContext(ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError != null)
            {
                // Action on Failure: Grab raw screenshot via runtime driver context
                string screenshotBase64 = _browser?.CaptureScreenshotAsBase64();
                string exceptionDetails = scenarioContext.TestError.Message;

                ExtentReportManager.LogFail(exceptionDetails, screenshotBase64);
            }
            else
            {
                ExtentReportManager.LogPass("Scenario execution verified and completed with zero errors.");
            }

            _browser?.Quit();
        }

        [AfterTestRun]
        public static void GlobalTearDown()
        {
            ExtentReportManager.FinalizeReport();
        }
    }
}