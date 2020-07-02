using InternProject3.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InternProject3.pages.Profile
{
    class Description
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public Description(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Initialise Description WebElements
        protected IWebElement DescriptionPenIcon => _driver.FindElement(By.XPath(".//*[@class='ui fluid card']/div/div[1]/h3/span/i"));
        protected IWebElement DescriptionTextArea => _driver.FindElement(By.XPath(".//textarea[@name='value']"));
        protected IWebElement DescriptionText => _driver.FindElement(By.Name("value"));
        protected IWebElement SaveButton => _driver.FindElement(By.XPath(".//button[@type='button']"));



        #endregion

        public void ClickDescription(IWebDriver driver)
        {
            Sync.WaitforVisibility(_driver, "XPath", ".//*[@class='ui fluid card']/div/div[1]/h3/span/i", 10);
           
            //click on a pen button to write text in Description
            DescriptionPenIcon.Click();
        }

        //Add Description
        public void ProfileDescription(IWebDriver driver)
        {
            //Populate ExcelLibHelper
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileDescription");
           
            //clear the text 
            DescriptionTextArea.Clear();
            
            //write into textbox
            DescriptionText.SendKeys(ExcelLibHelpers.ReadData(2, "Description"));
            
            //click on  Save button 
            SaveButton.Click();
           
        }

        //Validation - should see details in text filed
        public void ValidateDescription(IWebDriver driver)
        {
            //Populate ExcelLibHelper
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileDescription");
           
            //Get value from excel
            string ExpectedValue = ExcelLibHelpers.ReadData(2, "Description");
            
            //Get the text from Description text field
            String ActualValue = DescriptionText.Text;
            
            //Compair Excel text and Description text 
            try
            {
                Assert.That(ActualValue, Is.EqualTo(ExpectedValue));
                Console.WriteLine(ActualValue);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        
        }

        //Edit Description
        public void EditDescription(IWebDriver driver)
        {
            //Populate ExcelLibHelper
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileDescription");
            
            //clear the text 
            DescriptionTextArea.Clear();
            
            //write into textbox
            DescriptionText.SendKeys(ExcelLibHelpers.ReadData(2, "Edit Description"));
            
            //click on  Save button 
            SaveButton.Click();

        }

        //Validate Edited Details in Description Text
        public void ValidateEditedDescription(IWebDriver driver)
        {
            //Populate ExcelLibHelper
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileDescription");
           
            //Get value from excel
            string ExpectedValue = ExcelLibHelpers.ReadData(2, "Edit Description");
            
            //Get the text from Description text field
            String ActualValue = DescriptionText.Text;
            
            //Compair Excel text and Description text 
            try
            {
                Assert.That(ActualValue, Is.EqualTo(ExpectedValue));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
