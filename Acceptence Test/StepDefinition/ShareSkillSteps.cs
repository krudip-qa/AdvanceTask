using InternProject3.pages;
using InternProject3.Utilities;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;


namespace InternProject3.Acceptence_Test.StepDefinition
{
    [Binding, Scope(Feature = "ShareSkill")]
    class ShareSkillSteps 
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public ShareSkillSteps(IWebDriver driver)
        {
            _driver = driver;
        }


        ShareSkill ShareSkillObj;

        [Given(@"I click on share skill tab")]
        public void GivenIClickOnShareSkillTab()
        {
            ShareSkillObj = new ShareSkill(_driver);
            ShareSkillObj.ClickShareskill(_driver);
        }

        [When(@"I Enter share skill")]
        public void WhenIEnterShareSkill()
        {
            ShareSkillObj = new ShareSkill(_driver);
            ShareSkillObj.EnterShareSkill(_driver);
        }
        
        [Then(@"I should able to see entered skill in manage listing")]
        public void ThenIShouldAbleToSeeEnteredSkillInManageListing()
        {
            ShareSkillObj = new ShareSkill(_driver);
            ShareSkillObj.ValidateShareSkill(_driver);
        }
        [When(@"I Edit share skill")]
        public void WhenIEditShareSkill()
        {
            ShareSkillObj = new ShareSkill(_driver);
            ShareSkillObj.EditShareSkill(_driver);
        }

        [Then(@"I should able to see Edited skill in manage listing")]
        public void ThenIShouldAbleToSeeEditedSkillInManageListing()
        {
            ShareSkillObj = new ShareSkill(_driver);
            ShareSkillObj.ValidateEditShareSkill(_driver);
        }

    }
}
