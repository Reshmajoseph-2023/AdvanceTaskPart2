using AventStack.ExtentReports;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using AdvancedtaskSpecflow.Utilities;
using NUnit.Framework;
using System.Drawing.Imaging;
using OpenQA.Selenium.Support.Extensions;
using AventStack.ExtentReports.Model;
using Gherkin.CucumberMessages.Types;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using Gherkin.Ast;
using Feature = AventStack.ExtentReports.Gherkin.Model.Feature;


namespace AdvancedtaskSpecflow.Hooks
{
    [Binding]
    public class Hooks:CommonDriver
    {
      
        public static ExtentReports extent;
        public static ExtentTest test;
        private string errorMessage;
        private static ExtentTest feature;

           [BeforeTestRun]
            public static void ExtentStart()
            {
                extent = new ExtentReports();
                Console.WriteLine("Sasikala");
                var SparkReporter = new ExtentSparkReporter("C:\\Users\\reshm\\source\\repos\\second\\AdvancedtaskSpecflow\\AdvancedtaskSpecflow\\ExtentReport\\Extentreport.html");
                extent.AttachReporter(SparkReporter);
                SparkReporter.Config.ReportName = "AUTOMATION STATUS REPORT";
                SparkReporter.Config.DocumentTitle = "AUTOMATION STATUS REPORT";
                extent.AddSystemInfo("Application", "Project Mars");
                extent.AddSystemInfo("Browser", "Chrome");
                extent.AddSystemInfo("OS", "Windows");
        }
       
            [BeforeScenario]
            public void BeforeScenario()
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:5000/Home");
                test = extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
            }

            [AfterScenario]
            public void AfterScenario()
            {
            string scenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
            if (ScenarioContext.Current.TestError == null)
            {

                test.Log(Status.Pass, "Test Passed");
                //test.AddScreenCaptureFromPath(screenshotPath, "Screenshot");
                
                CaptureScreenshot(scenarioTitle+"_Pass");
            }

            else
            {
                //Log status and error message into extent reports
                errorMessage = TestContext.CurrentContext.Result.Message;
                test.Log(Status.Fail, "Test Failed");
                test.Fail($"Scenario '{scenarioTitle}' failed: {ScenarioContext.Current.TestError.Message}");


                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                // Convert the screenshot to Base64
                byte[] imageArray = Convert.FromBase64String(screenshot.AsBase64EncodedString);
                string screenshotBase64 = Convert.ToBase64String(imageArray);
                test.Log(Status.Error, "<b>Screenshot of failure:</b><br><img src='data:image/png;base64," + screenshotBase64 + "' width='600' height='400'>");

              
                //log screenshot into screenshots folder
                CaptureScreenshot(scenarioTitle + "_Fail");

            }

            driver.Quit();
    }
            [AfterTestRun]
            public static void ExtentClose()
            {
                extent.Flush();
            }

            public void CaptureScreenshot(string scenarioTitle)
            {
            string screenshotFileName = $"screenshot_{scenarioTitle}";
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string filePath = "C:\\Users\\reshm\\source\\repos\\second\\AdvancedtaskSpecflow\\AdvancedtaskSpecflow\\Screenshots";
            string screenshotPath = Path.Combine(filePath, $"{screenshotFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            screenshot.SaveAsFile(screenshotPath);

            }
    }
}