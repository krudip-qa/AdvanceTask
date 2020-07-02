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
    [Binding, Scope(Feature = "Language")]
    class LanguageSteps 
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public LanguageSteps(IWebDriver driver)
        {
            _driver = driver;
        }
       
        //Call language class and define for all functions
        Language LangObj;

        [Given(@"I Click on Language tab under profile")] 
        public void GivenIClickOnLanguageTabUnderProfile()
        {
            LangObj = new Language(_driver);
            LangObj.ClickLanguageTab(_driver);
        }

        [Given(@"I Add Language")]
        public void GivenIAddLanguage()
        {
            LangObj = new Language(_driver);
            //Call the Add language method
            LangObj.AddLanguage(_driver);
        }
        
        [Then(@"I should see Added language display in list")]
        public void ThenIShouldSeeAddedLanguageDisplayInList()
        {
            LangObj = new Language(_driver);
            //call for validation
            LangObj.ValidateAddLanguage(_driver);
        }
        [Given(@"I Update Language")]
        public void GivenIUpdateLanguage()
        {
            LangObj = new Language(_driver);
            //call Edit language
            LangObj.EditLanguage(_driver);
        }
        [Then(@"I should see Updated language display in list")]
        public void ThenIShouldSeeUpdatedLanguageDisplayInList()
        {
            LangObj = new Language(_driver);
            //Call for Validation of Update
            LangObj.ValidateEditLanguage(_driver);
        }
        [Given(@"I Delete language")]
        public void GivenIDeleteLanguage()
        {
            LangObj = new Language(_driver);
            //Call delete method
            LangObj.DeleteLanguage(_driver);
        }
        [Then(@"I should see pop up message display on screen")]
        public void ThenIShouldSeePopUpMessageDisplayOnScreen()
        {
            LangObj = new Language(_driver);
            //validate delete language
            LangObj.ValidateDeleteLanguage(_driver);
        }


    }
}
