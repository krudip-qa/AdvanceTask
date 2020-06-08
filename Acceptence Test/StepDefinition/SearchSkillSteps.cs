using InternProject3.pages;
using InternProject3.Utilities;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace InternProject3.Acceptence_Test.StepDefinition
{
    [Binding, Scope(Feature = "SearchSkill")]
    class SearchSkillSteps 
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public SearchSkillSteps(IWebDriver driver)
        {
            _driver = driver;
        }


        //SearchSkill calss
        SearchSkill SearchObj;

        [Given(@"I have entered skill in search Skill text box")]
        public void GivenIHaveEnteredSkillInSearchSkillTextBox()
        {
            Sync.WaitforVisibility(_driver, "XPath", "//*[@placeholder='Search skills']", 20);
            //populate excel 
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "SearchSkill");
            // Enter skill to search
            _driver.FindElement(By.XPath("//*[@placeholder='Search skills']")).SendKeys(ExcelLibHelpers.ReadData(2, "Search Skill") + Keys.Enter);
        }
        
        [When(@"I search skill by category and search user")]
        public void WhenISearchSkillByCategoryAndSearchUser()
        {
            SearchObj = new SearchSkill(_driver);
            SearchObj.SearchskillbyCategory(_driver);
        }
        
        [Then(@"I should able to see search result on screen")]
        public void ThenIShouldAbleToSeeSearchResultOnScreen()
        {
            SearchObj = new SearchSkill(_driver);
            SearchObj.ValidateSearchSkill(_driver);
        }

        [When(@"I search skill by filter")]
        public void WhenISearchSkillByFilter()
        {
            SearchObj = new SearchSkill(_driver);
            SearchObj.SearchSkillbyFilter(_driver);
        }

    }
}
