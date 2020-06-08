using InternProject3.pages.Profile;
using InternProject3.Utilities;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace InternProject3.Acceptence_Test.StepDefinition.ProfileSteps
{
    [Binding,Scope(Feature = "Certificate")]
    class CertificateSteps
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public CertificateSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        //Certificate
        Certificate CertyObj;

        [Given(@"I should click on certificate tab under profile")]
        public void GivenIShouldClickOnCertificateTabUnderProfile()
        {
            //wait
            Sync.WaitforVisibility(_driver, "XPath", ".//a[@data-tab='fourth']", 10);
            //click on Certificate Tab
            _driver.FindElement(By.XPath(".//a[@data-tab='fourth']")).Click();
        }
        
        [When(@"I add Certidicate")]
        public void WhenIAddCertidicate()
        {
            CertyObj = new Certificate(_driver);
            CertyObj.ProfileAddCertificate(_driver);
        }


        [Then(@"I should able to see Added details Certificate in list")]
        public void ThenIShouldAbleToSeeAddedDetailsCertificateInList()
        {
            CertyObj = new Certificate(_driver);
            CertyObj.ValidateAddCerticate(_driver);
        }

        [When(@"I Edit certificate")]
        public void WhenIEditCertificate()
        {
            CertyObj = new Certificate(_driver);
            CertyObj.EditCertificate(_driver);
        }

        [Then(@"I should be able to see edit details Certificate in list")]
        public void ThenIShouldBeAbleToSeeEditDetailsCertificateInList()
        {
            CertyObj = new Certificate(_driver);
            CertyObj.ValidateEditedCertificate(_driver);
        }

        [When(@"I Delete certificate")]
        public void WhenIDeleteCertificate()
        {
            CertyObj = new Certificate(_driver);
            CertyObj.DeleteCertificate(_driver);
        }


        [Then(@"I should be able to see conformation pop up message on screen")]
        public void ThenIShouldBeAbleToSeeConformationPopUpMessageOnScreen()
        {
            CertyObj = new Certificate(_driver);
            CertyObj.ValidateDeleteCertificate(_driver);
        }
    }
}
