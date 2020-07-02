using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using InternProject3.pages;
using InternProject3.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace InternProject3
{
    [Binding]
    public class Hook
    {
        //Global Variable for Extend report
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;

        //Inject Container - dependency injection concept
        private readonly IObjectContainer _objectContainer;

        private IWebDriver _driver;

        //As a rule of Context depandency need to create constructor and pass object
        public Hook(IObjectContainer objectContainer)
        {
            //Call _objectContainer and pass objectContainer in constructor
            _objectContainer = objectContainer;
        }

      //initialise report and config according to requirement
        [BeforeTestRun]
        public static void InitializeReport()
        {
            htmlReporter = new ExtentHtmlReporter(MarsResource.ExtentReportPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Config.DocumentTitle = "Test Report | Krupa Parekh";
            htmlReporter.Config.ReportName = "Test Report | Krupa Parekh";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        [Obsolete]
        //FeatureContext is available in Befor/After Feature and it's static 
        //so can't inject through constructor 
        //pass as a parameter and change featureContext with (featureContect.Current)
        //For more https://www.youtube.com/watch?v=BqMlHBjpQK4 or see ScenarioContext theory
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }
               

        [BeforeScenario]
        [Obsolete]
        //passing ScenarioContext object due to Context injection Exception -Report
        public void StartUpSteps(ScenarioContext scenarioContext)
        {
            //Open Browser
            _driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application");

            //here we register instance as IWebDriver for _Driver 
            //this object carry forward dependency injector class or steps 
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);

            //Using scenarioContext object we change ScenarioContext.Current to scenarioContext
            ////Create dynamic scenario name
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);

            //create an Page object for SignIn Page 
            SignIn logInObj = new SignIn(_driver);
            logInObj.SignInSteps(_driver);

        }

        //Can not pass ScenarioStepContext as parameter for steps
        //So Used ScenarioContext as instance and 
        //At createNode Used scenarioContext.StepContext
        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            //Used Reflection method for TestStatus property which not expose to outside world
            //using nonPublic method to get Method
            //Invoke scenarioContext.Current to get Test result
            //More see NoteBook
            //PropertyInfo pInfo = typeof(ScenarioStepContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
            //MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            //object TestResult = getter.Invoke(scenarioContext, null);

            ////Use scenarioContext.StepContect insted of ScenarioStepContext.Current
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    //Use scenarioContext.StepContect insted of ScenarioStepContext.Current
                    scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);
            }
            else if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
            }

            ////Pending Status
            //if (TestResult.ToString() == "StepDefinitionPending")
            //{
            //    if (stepType == "Given")
            //        scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
            //    else if (stepType == "When")
            //        scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
            //    else if (stepType == "Then")
            //        scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");

            //}
        }
      
        [AfterScenario]
        public void TearDown()
        {
            // Take Screenshot before driver close browser
            _ = SaveScreenshotClass.SaveScreenshot(_driver, "Test_Case Image");

            //Flush report once test completes
            extent.Flush();

            _driver.Quit();
        }
    }
}
