using InternProject3.pages.Profile;
using InternProject3.Utilities;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace InternProject3.Acceptence_Test.StepDefinition.ProfileSteps
{
    [Binding, Scope(Feature = "Skill")]
    class SkillSteps
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public SkillSteps(IWebDriver driver)
        {
            _driver = driver;
        }


        Skill skillObj;

        [Given(@"I click on skill tab under profile")]
        public void GivenIClickOnSkillTabUnderProfile()
        {
            Thread.Sleep(2000);
            //click on a Skill Tab
            _driver.FindElement(By.XPath(".//a[@data-tab='second']")).Click();
        }
        
        [Given(@"I Add skill")]
        public void GivenIAddSkill()
        {
            skillObj = new Skill(_driver);
            skillObj.AddSkill(_driver);
        }


        [Then(@"I should able to see entered skill display in list")]
        public void ThenIShouldAbleToSeeEnteredSkillDisplayInList()
        {
            skillObj = new Skill(_driver);
            skillObj.ValidateAddSkill(_driver);
        }
       
        [Given(@"I Edit Skill")]
        public void GivenIEditSkill()
        {
            skillObj = new Skill(_driver);
            skillObj.EditSkill(_driver);
        }

        [Then(@"I should be able to see updated skill in skill list")]
        public void ThenIShouldBeAbleToSeeUpdatedSkillInSkillList()
        {
            skillObj = new Skill(_driver);
            skillObj.validateUpdatedSkill(_driver);
        }
        [Given(@"I delete skill")]
        public void GivenIDeleteSkill()
        {
            skillObj = new Skill(_driver);
            skillObj.DeleteSkill(_driver);
        }

        [Then(@"I should be able to see deleted skill in list")]
        public void ThenIShouldBeAbleToSeeDeletedSkillInList()
        {
            skillObj = new Skill(_driver);
            skillObj.ValidateDeleteSkill(_driver);
        }
    }
}
