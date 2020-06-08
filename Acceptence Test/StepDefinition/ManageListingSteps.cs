using InternProject3.pages;
using InternProject3.Utilities;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace InternProject3.Acceptence_Test.StepDefinition
{
    [Binding, Scope(Feature = "ManageListing")]
    class ManageListingSteps 
    {        
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public ManageListingSteps(IWebDriver driver)
        {
            _driver = driver;
        }

       

        [Given(@"I have click on manage listing tab")]
        public void GivenIHaveClickOnManageListingTab()
        {
            //scenarioContext.Set("Delete", "managelisting");
             //wait
            Sync.WaitforVisibility(_driver, "LinkText", "Manage Listings", 20);
            
            //Click on manage listing TAb
            _driver.FindElement(By.LinkText("Manage Listings")).Click();

        }
        [When(@"I view manage listing")]
        public void WhenIViewManageListing()
        {
            ManageListing ListingObj = new ManageListing(_driver);
            ListingObj.View(_driver);
        }

        [Then(@"I should able to navigate to Service Detail page")]
        public void ThenIShouldAbleToNavigateToServiceDetailPage()
        {
            ManageListing ListingObj = new ManageListing(_driver);
            ListingObj.ValidateView(_driver);
        }

        [Given(@"I Edit manage listing")]
        public void GivenIEditManageListing()
        {
            Sync.WaitforVisibility(_driver, "XPath", "(//i[@class='outline write icon'])[1]", 10);
            //CLick on Edit button 
            _driver.FindElement(By.XPath("(//i[@class='outline write icon'])[1]")).Click();

        }

        [Then(@"I should able to navigate to Service listing page")]
        public void ThenIShouldAbleToNavigateToServiceListingPage()
        {
            ManageListing ListingObj = new ManageListing(_driver);
            ListingObj.EditManageList(_driver);
        }

        [Then(@"I should able to see Edited skill details in manage listing page")]
        public void ThenIShouldAbleToSeeEditedSkillDetailsInManageListingPage()
        {
            ManageListing ListingObj = new ManageListing(_driver);
            ListingObj.ValidateEditManageList(_driver);
        }

        [When(@"I Delete manage listing")]
        public void WhenIDeleteManageListing()
        {
            ManageListing ListingObj = new ManageListing(_driver);
            ListingObj.DeleteManageList(_driver);
        }
                                
        
        [Then(@"I should able to see confirmation pop up on screen")]
        public void ThenIShouldAbleToSeeConfirmationPopUpOnScreen()
        {
            ManageListing ListingObj = new ManageListing(_driver);
            ListingObj.ValidateDeleteManageList(_driver);
        }
    }
}
