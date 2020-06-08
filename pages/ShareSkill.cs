using AutoItX3Lib;
using InternProject3.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InternProject3.pages
{
    class ShareSkill 
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public ShareSkill(IWebDriver driver)
        {
            _driver = driver;
        }

        //Enter share skill details 
        public void EnterShareSkill(IWebDriver driver)
        {
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "AddShareskill");
           //wait
            Sync.WaitforVisibility(driver, "Name", "title", 10);
            //find Out Title textField
            driver.FindElement(By.Name("title")).SendKeys(ExcelLibHelpers.ReadData(2, "Title"));
          
            //find Out Description  textField
            driver.FindElement(By.Name("description")).SendKeys(ExcelLibHelpers.ReadData(2, "Description"));

            //find Out Category droupdown
            driver.FindElement(By.Name("categoryId")).SendKeys(ExcelLibHelpers.ReadData(2, "Category"));

            //find Out  Sub Category droupdown 
            driver.FindElement(By.Name("subcategoryId")).SendKeys(ExcelLibHelpers.ReadData(2, "Sub Category"));

            //find Out  Tag 
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div[1]/div/div/div/input")).SendKeys(ExcelLibHelpers.ReadData(2, "Tag") + Keys.Enter);

            //find Out  Service Type - Radio Button
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div")).Click();

            //find Out  Location Type - Radio Button
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")).Click();

             //Available Days table
             //Click on Start Date DropDown 
            driver.FindElement(By.Name("startDate")).SendKeys(ExcelLibHelpers.ReadData(2, "Start Date"));

            //Click on End Date DropDown 
            driver.FindElement(By.Name("endDate")).SendKeys(ExcelLibHelpers.ReadData(2, "End Date"));

            //Loop for Start time and End time table
            for (int i = 2; i < 9; i++)
            {
                //Click on Start Date DropDown 
                driver.FindElement(By.XPath("//div[" + i + "]/div[2]/input")).SendKeys(ExcelLibHelpers.ReadData(i, "Start Time"));

                for (int j = 2; j < 9; j++)
                {
                    //Click on End Date DropDown 
                    driver.FindElement(By.XPath("//div[" + j + "]/div[3]/input")).SendKeys(ExcelLibHelpers.ReadData(j, "End Time"));
                }
                
            }                   

            //find Out Skill Trade radio button
            driver.FindElement(By.XPath(".//*[@name='skillTrades' and @value='true']")).Click();

            //Find out Skill Exchange Text-Field
            driver.FindElement(By.XPath("//div[@cl" +
            "ass='form-wrapper']//input[@placeholder='Add new tag']")).SendKeys(ExcelLibHelpers.ReadData(2, "Skill Exchange") + Keys.Enter);

            //Find Out + "Work Sample" button to upload file
            driver.FindElement(By.XPath(".//*[@class='ui grid']/span/i")).Click();

            //Handle the window that not belongs to Browser -AutoIt - see blog for more info
            //below line execute the AutoIT script
            //Create an object for AutoIt 
            AutoItX3 autoIt = new AutoItX3();
            //This statement Active the window and perform set of auctions 
            autoIt.WinActivate("Open");
            Thread.Sleep(1000);
            //set the path to open the file on browser 
            autoIt.Send(@"D:\InternPro\InternProject3\AutoIt\scrummeeting.png");
            Thread.Sleep(1000);
            //It will click on "Open" button 
            autoIt.Send("{ENTER}");

            ////Select File 
            //driver.FindElement(By.Id("selectFile")).Click();

            //Find Out Active radio button 
            driver.FindElement(By.XPath("//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']/div[1]/input[@value='true']")).Click();

            //find SAVE button-
            driver.FindElement(By.XPath(".//*[@value='Save' and @type='button']")).Click();
      
        }

        //Validate - Entered share skill should be in manage listing 
        public void ValidateShareSkill(IWebDriver driver)
        {
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "AddShareskill");
            //wait
            Sync.WaitforVisibility(driver, "LinkText", "Manage Listings", 20);
            //For Assertion - After click on save button skill saved in manage list page
            //need to go Manage Listing Tab first and get category and titlt text 

            //Click on manage listing TAb
            driver.FindElement(By.LinkText("Manage Listings")).Click();

            Sync.WaitforVisibility(driver, "XPath", ".//table[@class='ui striped table']/tbody/tr[1]/td[2]", 20);
            //Get Category of Manage List
            String ManageListCategory = driver.FindElement(By.XPath(".//table[@class='ui striped table']/tbody/tr[1]/td[2]")).Text;

            //Get title of Manage List
            String ManageTitle = driver.FindElement(By.XPath(".//table[@class='ui striped table']/tbody/tr[1]/td[3]")).Text;

            try
            {
                //For Assertion - After Save Skills For varification,
                //Goto manage list page and match Title and Cetegory with Excel Enter Skill 
                Assert.AreEqual(ManageTitle, ExcelLibHelpers.ReadData(2, "Title"));
                Assert.AreEqual(ManageListCategory, ExcelLibHelpers.ReadData(2, "Category"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Edit Share skill details
        public void EditShareSkill(IWebDriver driver)
        {
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "EditShareSkill");
            //wait
            Sync.WaitforVisibility(driver, "Name", "title", 10);
            //find Out Title textField
            driver.FindElement(By.Name("title")).SendKeys(ExcelLibHelpers.ReadData(2, "Title"));
           
            //find Out Description  textField
            driver.FindElement(By.Name("description")).SendKeys(ExcelLibHelpers.ReadData(2, "Description"));

            //find Out Category droupdown
            driver.FindElement(By.Name("categoryId")).SendKeys(ExcelLibHelpers.ReadData(2, "Category"));

            //find Out  Sub Category droupdown 
            driver.FindElement(By.Name("subcategoryId")).SendKeys(ExcelLibHelpers.ReadData(2, "Sub Category"));

            //find Out  Tag 
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div[1]/div/div/div/input"))
                .SendKeys(ExcelLibHelpers.ReadData(2, "Tag") + Keys.Enter + ExcelLibHelpers.ReadData(3, "Tag") + Keys.Enter);

            //find Out  Service Type - Radio Button
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div")).Click();

            //find Out  Location Type - Radio Button
            driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")).Click();

            //Available Days table
            //Click on Start Date DropDown 
            driver.FindElement(By.Name("startDate")).SendKeys(ExcelLibHelpers.ReadData(2, "Start Date"));

            //Click on End Date DropDown 
            driver.FindElement(By.Name("endDate")).SendKeys(ExcelLibHelpers.ReadData(2, "End Date"));

            //Loop for Start time and End time table
            for (int i = 2; i < 9; i++)
            {
                //Click on Start Date DropDown 
                driver.FindElement(By.XPath("//div[" + i + "]/div[2]/input")).SendKeys(ExcelLibHelpers.ReadData(i, "Start Time"));

                for (int j = 2; j < 9; j++)
                {
                    //Click on End Date DropDown 
                    driver.FindElement(By.XPath("//div[" + j + "]/div[3]/input")).SendKeys(ExcelLibHelpers.ReadData(j, "End Time"));
                }

            }

            //find Out Skill Trade radio button
            driver.FindElement(By.XPath(".//*[@name='skillTrades' and @value='true']")).Click();

            //Find out Skill Exchange Text-Field
            driver.FindElement(By.XPath("//div[@cl" +
            "ass='form-wrapper']//input[@placeholder='Add new tag']"))
                .SendKeys(ExcelLibHelpers.ReadData(2, "Skill Exchange") + Keys.Enter + ExcelLibHelpers.ReadData(3, "Skill Exchange") + Keys.Enter);

            //Find Out + "Work Sample" button to upload file
            driver.FindElement(By.XPath(".//*[@class='ui grid']/span/i")).Click();

            //Handle the window that not belongs to Browser -AutoIt - see blog for more info
            //below line execute the AutoIT script
            //Create an object for AutoIt 
            AutoItX3 autoIt = new AutoItX3();
            //This statement Active the window and perform set of auctions 
            autoIt.WinActivate("Open");
            Thread.Sleep(1000);
            //set the path to open the file on browser 
            autoIt.Send(@"D:\InternPro\InternProject3\AutoIt\scrummeeting.png");
            Thread.Sleep(1000);
            //It will click on "Open" button 
            autoIt.Send("{ENTER}");

            ////Select File 
            //driver.FindElement(By.Id("selectFile")).Click();

            //Find Out Active radio button 
            driver.FindElement(By.XPath("//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']/div[1]/input[@value='true']")).Click();

            //find SAVE button-
            driver.FindElement(By.XPath(".//*[@value='Save' and @type='button']")).Click();

        }

        //Validate Edited details 
        public void ValidateEditShareSkill(IWebDriver driver)
        {
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "EditShareSkill");
            //wait
            Sync.WaitforVisibility(driver, "LinkText", "Manage Listings", 10);
            //For Assertion - After click on save button skill saved in manage list page
            //need to go Manage Listing Tab first and get category and titlt text 

            //Click on manage listing Tab
            driver.FindElement(By.LinkText("Manage Listings")).Click();

            Sync.WaitforVisibility(driver, "XPath", ".//table[@class='ui striped table']/tbody/tr[1]/td[2]", 10);
            //Get Category of Manage List
            String ManageListCategory = driver.FindElement(By.XPath(".//table[@class='ui striped table']/tbody/tr[1]/td[2]")).Text;

            //Get title of Manage List
            String ManageTitle = driver.FindElement(By.XPath(".//table[@class='ui striped table']/tbody/tr[1]/td[3]")).Text;

            try
            {
                //For Assertion - After Save Skills For varification,
                //Goto manage list page and match Title and Cetegory with Excel Enter Skill 
                Assert.AreEqual(ManageTitle, ExcelLibHelpers.ReadData(2, "Title"));
                Assert.AreEqual(ManageListCategory, ExcelLibHelpers.ReadData(2, "Category"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}

