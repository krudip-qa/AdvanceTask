using InternProject3.pages;
using InternProject3.pages.Profile;
using InternProject3.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace InternProject3.Acceptence_Test.StepDefinition
{
    [Binding, Scope(Feature = "ProfileDetail")]
    class ProfileDetailSteps
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public ProfileDetailSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        //Every function can use this object
        ProfileDetail DetailObj;

        [When(@"I View name")]
        public void WhenIViewName()
        {
            DetailObj = new ProfileDetail(_driver);
            //Call an object
            //ProfileDetail - NameTitle
            DetailObj.NameTitle(GlobalDriver.driver);
        }
        [Then(@"It Should has first name and last name")]
        public void ThenItShouldHasFirstNameAndLastName()
        {
            DetailObj = new ProfileDetail(_driver);
            DetailObj.ValidateName(_driver);
        }
               
        [When(@"I select Availability")]
        public void WhenISelectAvailability()
        {
            DetailObj = new ProfileDetail(_driver);
            //Call the availability method from profile detail page class
            DetailObj.Availability(_driver);
        }
              
        [When(@"I select an Hours")]
        public void WhenISelectAnHours()
        {
            DetailObj = new ProfileDetail(_driver);
            //Call the Hour method from profile detail page class
            DetailObj.Hour(_driver);
        }
           
        [When(@"I select an Earning Target")]
        public void WhenISelectAnEarningTarget()
        {
            DetailObj = new ProfileDetail(_driver);
            ////Call the Hour method from profile detail page class
            DetailObj.EarnTarget(_driver);
        }

        [Then(@"I should see Confirmation pop up on screen")]
        public void ThenIShouldSeeConfirmationPopUpOnScreen()
        {
            DetailObj = new ProfileDetail(_driver);
            DetailObj.Validation(_driver);
        }


    }
}
