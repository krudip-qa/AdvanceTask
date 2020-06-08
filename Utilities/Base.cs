using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using InternProject3.pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace InternProject3.Utilities
{
    class Base
    {

        #region To Access path from MarsResource file
        public static string ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenshotPath;
        public static string ExtentReportPath = MarsResource.ExtentReportPath;
        #endregion

        //#region
        //Global Variable for Extend report
        //private static ExtentTest featureName;
        //private static ExtentTest scenario;
        //private static ExtentReports extent;
        //private static ExtentHtmlReporter htmlReporter;
        //#endregion

        //#region
        //[BeforeTestRun]
        //public static void InitializeReport()
        //{
        //    htmlReporter = new ExtentHtmlReporter(ExtentReportPath);
        //    htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
        //    htmlReporter.Config.DocumentTitle = "Test Report | Krupa Parekh";
        //    htmlReporter.Config.ReportName = "Test Report | Krupa Parekh";
        //    extent = new ExtentReports();
        //    extent.AttachReporter(htmlReporter);
        //}
        //#endregion

        //#region
        //[BeforeFeature]
        //[Obsolete]
        //public static void BeforeFeature()
        //{
        //    Create dynamic feature name
        //    featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        //}
        //#endregion

        //#region
        //[BeforeScenario]
        //[Obsolete]
        //public void StartUpSteps()
        //{
        //    Open Browser
        //    driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application");

        //    Hit the Url
        //    driver.Navigate().GoToUrl("http://192.168.99.100:5000/Home");
        //    Maximise screen
        //    driver.Manage().Window.Maximize();

        //    htmlReporter = new ExtentHtmlReporter(ExtentReportPath);
        //    htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
        //    htmlReporter.Config.DocumentTitle = "Test Report | Krupa Parekh";
        //    htmlReporter.Config.ReportName = "Test Report | Krupa Parekh";
        //    extent = new ExtentReports();
        //    extent.AttachReporter(htmlReporter);
        //    Create dynamic feature name
        //    featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);


        //    Create dynamic scenario name
        //    scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

        //    create an Page object for SignIn Page
        //    SignIn logInObj = new SignIn();
        //    logInObj.SignInSteps(driver);

        //}
        //#endregion

        //#region
        //[AfterScenario]
        //public void TearDown()
        //{

        //    Take Screenshot before driver close browser
        //    String img = SaveScreenshotClass.SaveScreenshot(GlobalDriver.driver, "Test_Case");


        //    Flush report once test completes
        //    extent.Flush();
        //    driver.Close();

        //}
        //#endregion
        //#region
        //[AfterStep]
        //[Obsolete]
        //public void InsertReportingSteps()
        //{

        //    var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

        //    PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
        //    MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
        //    object TestResult = getter.Invoke(ScenarioContext.Current, null);

        //    if (ScenarioContext.Current.TestError == null)
        //    {
        //        if (stepType == "Given")
        //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
        //        else if (stepType == "When")
        //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
        //        else if (stepType == "Then")
        //            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
        //        else if (stepType == "And")
        //            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
        //    }
        //    else if (ScenarioContext.Current.TestError != null)
        //    {
        //        if (stepType == "Given")
        //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
        //        else if (stepType == "When")
        //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
        //        else if (stepType == "Then")
        //            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
        //    }

        //    Pending Status
        //    if (TestResult.ToString() == "StepDefinitionPending")
        //    {
        //        if (stepType == "Given")
        //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
        //        else if (stepType == "When")
        //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
        //        else if (stepType == "Then")
        //            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

        //    }
        //    #endregion
        //}
    }
}
