using InternProject3.pages.Profile;
using InternProject3.Utilities;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace InternProject3.Acceptence_Test.StepDefinition.ProfileSteps
{
    [Binding, Scope(Feature = "Description")]
    class DescriptionSteps 
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public DescriptionSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        //Description
        Description DescriptionObj;

        [Given(@"I should click on pen button beside Description")]
        public void GivenIShouldClickOnPenButtonBesideDescription()
        {
            DescriptionObj = new Description(_driver);
            DescriptionObj.ClickDescription(_driver);
        }      

        [When(@"I Enter details")]
        public void WhenIEnterDetails()
        {
            DescriptionObj = new Description(_driver);
            DescriptionObj.ProfileDescription(_driver);
        }

        [Then(@"I should see details in text Field")]
        public void ThenIShouldSeeDetailsInTextField()
        {
            DescriptionObj = new Description(_driver);
            DescriptionObj.ValidateDescription(_driver);
        }

        [When(@"I  Update details")]
        public void WhenIUpdateDetails()
        {
            DescriptionObj = new Description(_driver);
            DescriptionObj.EditDescription(_driver);
        }
        
              
        [Then(@"I should see updated details in text Field")]
        public void ThenIShouldSeeUpdatedDetailsInTextField()
        {
            DescriptionObj = new Description(_driver);
            DescriptionObj.ValidateEditedDescription(_driver);
        }
    }
}
