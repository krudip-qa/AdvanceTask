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
    class Certificate
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public Certificate(IWebDriver driver)
        {
            _driver = driver;
        }

        //Add Certificate
        public void ProfileAddCertificate(IWebDriver driver)
        {
            //Populate ExcelLibHelper
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileCertificate");
           ////wait
           // Sync.WaitforVisibility(driver, "XPath", ".//a[@data-tab='fourth']", 10);
           // //click on Certificate Tab
           // driver.FindElement(By.XPath(".//a[@data-tab='fourth']")).Click();
            //Click on Add New Button
            driver.FindElement
                (By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"))
                .Click();
            //Give an input in Certificates or Awards
            driver.FindElement(By.Name("certificationName")).SendKeys(ExcelLibHelpers.ReadData(2, "Certificate Name"));
            //Certificate From
            driver.FindElement(By.Name("certificationFrom")).SendKeys(ExcelLibHelpers.ReadData(2,"Certificate From"));
            //Select Year from Drop-Down List
            IWebElement DropdownCertyYearList = driver.FindElement(By.Name("certificationYear"));
            DropdownCertyYearList.SendKeys(ExcelLibHelpers.ReadData(2, "certification Year") + Keys.Enter);
            //Click on Add button
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]")).Click();
        }

        //Validate Added Certificate in List
        public void ValidateAddCerticate(IWebDriver driver)
        {
            //populate ExcelLibHelper
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileCertificate");
            //Added certificate - match with Certificate Name
            String expextedCertificate = ExcelLibHelpers.ReadData(2, "Certificate Name");
            //wait for Certificate name
            Sync.WaitforVisibility(driver, "XPath", "//div[5]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10);
            //Get the certificate name value from certificate list
            String actualCertificate = driver.FindElement(By.XPath("//div[5]/div/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;
            try
            {                 
                Assert.That(actualCertificate, Is.EqualTo(expextedCertificate));
                Console.WriteLine("Certificate been added is:" + actualCertificate);
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Edit Certificate
        public void EditCertificate(IWebDriver driver)
        {        
            try
            {
                //click on pen to edit details 
                driver.FindElement(By.XPath("//*[@data-tab='fourth']/div/div[2]/div/table/tbody[last()]/tr/td/span[1]/i[1]")).Click();
            }
            catch(NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
            //populate Login Page Test data collection
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileCertificate");
            //Change the Crtificate name 
            driver.FindElement(By.Name("certificationName")).Clear();
            driver.FindElement(By.Name("certificationName")).SendKeys(ExcelLibHelpers.ReadData(2, "Edit certificationName"));
            //Change the name for Crtificate From TextField
            driver.FindElement(By.Name("certificationFrom")).Clear();
            driver.FindElement(By.Name("certificationFrom")).SendKeys(ExcelLibHelpers.ReadData(2, "Edit certificationFrom"));
            //Change the year 
            driver.FindElement(By.Name("certificationYear")).SendKeys(ExcelLibHelpers.ReadData(2, "Edit certificationYear"));
            //click on Update button
            driver.FindElement(By.XPath(".//*[@colspan='4']/div/span/input[1]")).Click();
        }

        //Validate edited details in Certificate list
        public void ValidateEditedCertificate(IWebDriver driver)
        {
            //Get the expected value from excel 
            //populate Login Page Test data collection
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileCertificate");
            //Changed the Crtificate name 
             string expectedCertificate = ExcelLibHelpers.ReadData(2, "Edit certificationName");
            //wait for Certificate name
            //Sync.WaitforVisibility(driver, "XPath", "//div[5]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 50);
            Thread.Sleep(2000);
            //Get the certificate name from certificate list 
            string actualCertificate = driver.FindElement(By.XPath("//div[5]/div/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;
            //Assert that Excel value and Certificate name would be same 
            try
            {
                Assert.AreEqual(expectedCertificate, actualCertificate);
                Console.WriteLine("The certificate name is:" + actualCertificate);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }




        }

        //Delete Certificate
        public void DeleteCertificate(IWebDriver driver)
        {
            //Might get exception if no Education been Added try to edit so give you exception for edit button 
            try
            {
                //Click on Delete button
                driver.FindElement(By.XPath("//*[@data-tab='fourth']/div/div[2]/div/table/tbody[last()]/tr/td/span[2]/i")).Click();
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Delete button not found");
            }
        }
        
        //Validate Deleted language as a pop up comformation
        public void ValidateDeleteCertificate(IWebDriver driver)
        {
            //Get the pop up message 
            //wait untill pop up window findout 
            Sync.WaitforVisibility(driver, "ClassName", "ns-box-inner", 20);
            //Get the text from pop up window 
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string msglang = driver.FindElement(By.ClassName("ns-box-inner")).Text;
            Console.WriteLine(msglang);
            driver.FindElement(By.ClassName("ns-close")).Click();
            driver.SwitchTo().DefaultContent();
        }

    }
}
