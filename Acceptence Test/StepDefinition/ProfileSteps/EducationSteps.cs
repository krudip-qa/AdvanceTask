using InternProject3.pages.Profile;
using InternProject3.Utilities;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace InternProject3
{
    [Binding, Scope(Feature = "Education")]
    class EducationSteps
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public EducationSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        //Education
        Education EduObj;
        
        [Given(@"I should able to click on Education tab under profile")]
        public void GivenIShouldAbleToClickOnEducationTabUnderProfile()
        {
            EduObj = new Education(_driver);
            EduObj.Educationtab(_driver);
        }
        
        [When(@"I add education")]
        public void WhenIAddEducation()
        {
            EduObj = new Education(_driver);
            EduObj.AddEducation(_driver);
        }

        [Then(@"I should be able to see added education in list")]
        public void ThenIShouldBeAbleToSeeAddedEducationInList()
        {
            EduObj = new Education(_driver);
            EduObj.ValidateAddedEducation(_driver);
        }

        [When(@"I edit education")]
        public void WhenIEditEducation()
        {
            EduObj = new Education(_driver);
            EduObj.EditEducation(GlobalDriver.driver);
        }

        [Then(@"I should be able to see updated education in list")]
        public void ThenIShouldBeAbleToSeeUpdatedEducationInList()
        {
            EduObj = new Education(_driver);
            EduObj.ValidateEditedEducation(_driver);
        }

        [When(@"I delete education")]
        public void WhenIDeleteEducation()
        {
            EduObj = new Education(_driver);
            EduObj.DeleteEducation(_driver);
        }
           
        [Then(@"It should display a pop up message on screen")]
        public void ThenItShouldDisplayAPopUpMessageOnScreen()
        {
            EduObj = new Education(_driver);
            EduObj.ValidateDeleteEducation(_driver);
        }
    }
}
