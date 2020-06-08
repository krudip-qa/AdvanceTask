using InternProject3.pages.Profile;
using InternProject3.Utilities;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace InternProject3.Acceptence_Test.StepDefinition.ProfileSteps
{
    [Binding, Scope(Feature = "ChangePassword")]
    class ChangePasswordSteps
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public ChangePasswordSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        ChangePassword ChangeObj;
        
        [Given(@"I have clicked on Change password")]
        public void GivenIHaveClickedOnChangePassword()
        {
            Sync.WaitforVisibility(_driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span", 50);
            //Goto "Hi Krupa"
            _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")).Click();
            Thread.Sleep(2000);
            //Click on Change password
            _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/div/a[2]")).Click();
        }
        
        [When(@"I change password")]
        public void WhenIChangePassword()
        {
            ChangeObj = new ChangePassword(_driver);
            ChangeObj.PasswordChange(_driver);
        }
        
        [Then(@"I should be able to see conformation pop up")]
        public void ThenIShouldBeAbleToSeeConformationPopUp()
        {
            ChangeObj = new ChangePassword(_driver);
            ChangeObj.ValidationPasswordChange(_driver);
        }
    }
}
