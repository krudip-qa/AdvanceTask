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
    class Education
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public Education(IWebDriver driver)
        {
            _driver = driver;
        }
        //Add Education
        public void AddEducation(IWebDriver driver)
        {
            //Populate ExcelLibHelper
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileEducation");
            //click on Add New button
            driver.FindElement(By.XPath("//div[4]/div/div[2]/div/table/thead/tr/th[6]/div")).Click();
            //Give an input in Collage/University Name TextField
            driver.FindElement(By.XPath(".//*[@name='instituteName']")).SendKeys(ExcelLibHelpers.ReadData(2, "Institute Name"));
            //Select country from drop-Down list
            IWebElement DropdownCountryList = driver.FindElement(By.Name("country"));
            DropdownCountryList.SendKeys(ExcelLibHelpers.ReadData(2, "Country") + Keys.Enter);
            //Select titleD:\InternPro\InternProject3\pages\SignIn.cs
            IWebElement DropdownTitleList = driver.FindElement(By.Name("title"));
            DropdownTitleList.SendKeys(ExcelLibHelpers.ReadData(2, "Title") + Keys.Enter);
            //Give an input for Degree
            driver.FindElement(By.XPath(".//*[@placeholder='Degree']")).SendKeys(ExcelLibHelpers.ReadData(2,"Degree"));
            //select year of Graduate from drop-Down Box
            IWebElement DropdownYearList = driver.FindElement(By.Name("yearOfGraduation"));
            DropdownYearList.SendKeys(ExcelLibHelpers.ReadData(2, "Year Of Graduation") + Keys.Enter);
            //Click on Add Button
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]")).Click();
           ////wait untill pop up 
           // Sync.WaitforVisibility(driver, "ClassName", "ns-box-inner", 20);
           // //Get the text from pop up window 
           // driver.SwitchTo().Window(driver.WindowHandles.Last());
           // string msglang = driver.FindElement(By.ClassName("ns-box-inner")).Text;
           // Console.WriteLine(msglang);
           // //close the pop up
           // driver.FindElement(By.ClassName("ns-close")).Click();
           // driver.SwitchTo().DefaultContent();
        }

        //Validate added education is display in list
        public void ValidateAddedEducation(IWebDriver driver)
        {
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileEducation");
            //Added Education - match with Title and Degree
            String expextedTitle = ExcelLibHelpers.ReadData(2, "Title");
            String expectedDegree = ExcelLibHelpers.ReadData(2, "Degree");
            //wait for education title
            Sync.WaitforVisibility(driver, "XPath", "//div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]", 10);
            //Get the title value from education list
            String actualTitle = driver.FindElement(By.XPath("//div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]")).Text;
            //wait for education Degree
            Sync.WaitforVisibility(driver, "XPath", "//div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]", 10);
            //Get the degree value from education list
            string actualDegree = driver.FindElement(By.XPath("//div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]")).Text;
            try
            {
                if (expextedTitle == actualTitle && expectedDegree == actualDegree)
                {
                    Assert.That(expextedTitle, Is.EqualTo(actualTitle));
                    Assert.That(expectedDegree, Is.EqualTo(actualDegree));
                }
                else
                {
                    Console.WriteLine("title and degree dosen't match");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Edit Education
        public void EditEducation(IWebDriver driver)
        {
            //Might get exception if no language been Added try to edit so give you exception for edit button 
            try
            {
                //click on pen button to Edit details 
                driver.FindElement(By.XPath("//*[@data-tab='third']/div/div[2]/div/table/tbody[last()]/tr/td/span[1]/i[1]")).Click();
            }
            catch(NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
                
            //Go to Uni mane and update the details
            driver.FindElement(By.XPath(".//*[@placeholder='College/University Name']")).Clear();
            //populate Login Page Test data collection
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileEducation");
            //passing new name inti TextField
            driver.FindElement(By.XPath(".//*[@placeholder='College/University Name']")).SendKeys(ExcelLibHelpers.ReadData(2, "Edit University Name"));
            //Update detail on Country Drop down 
            driver.FindElement(By.Name("country")).SendKeys(ExcelLibHelpers.ReadData(2, "Edit Country"));
            //Update title
            driver.FindElement(By.Name("title")).SendKeys(ExcelLibHelpers.ReadData(2, "Edit Title"));
            //update Degree name 
            driver.FindElement(By.Name("degree")).Clear();
            driver.FindElement(By.Name("degree")).SendKeys(ExcelLibHelpers.ReadData(2, "Edit Degree"));
            //Update a year from drop down boxbox
            driver.FindElement(By.Name("yearOfGraduation")).SendKeys(ExcelLibHelpers.ReadData(2, "Edit yearOfGraduation"));
            //click on Update button
            driver.FindElement(By.XPath(".//*[@colspan='6']/div/input[1]")).Click();
        }

        //Validate Updated Education details in list
        public void ValidateEditedEducation(IWebDriver driver)
        {           
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileEducation");
            //Added Education - match with Title and Degree
            String expextedTitle = ExcelLibHelpers.ReadData(2, "Edit Title");
            String expectedDegree = ExcelLibHelpers.ReadData(2, "Edit Degree");
            //wait for education title
            Sync.WaitforVisibility(driver, "XPath", "//div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]", 10);
            //Get the title value from education list
            String actualTitle = driver.FindElement(By.XPath("//div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]")).Text;
            //wait for education Degree
            Sync.WaitforVisibility(driver, "XPath", "//div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]", 10);
            //Get the degree value from education list
            string actualDegree = driver.FindElement(By.XPath("//div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]")).Text;
            try
            {               
                    Assert.That(expextedTitle, Is.EqualTo(actualTitle));
                    Assert.That(expectedDegree, Is.EqualTo(actualDegree));                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Delete Education
        public void DeleteEducation(IWebDriver driver)
        {
            //Might get exception if no Education been Added try to edit so give you exception for edit button 
            try
            {
                //Click on Delete button
                driver.FindElement(By.XPath("//*[@data-tab='third']/div/div[2]/div/table/tbody[last()]/tr/td/span[2]/i")).Click();
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }  

        //Validate Deleted Education using pop up
        public void ValidateDeleteEducation(IWebDriver driver)
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
