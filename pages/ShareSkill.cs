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

        int i;
        int j;

        //Constructor for dependency injection
        public ShareSkill(IWebDriver driver)
        {
            _driver = driver;
        }

        #region   Initialise WebElement of Share skill

        //Click on Share SKill tab
        protected IWebElement ShareSkillTab=>  _driver.FindElement(By.LinkText("Share Skill"));

        //Click on Manageliting Tab
        protected IWebElement ManageListinTab => _driver.FindElement(By.LinkText("Manage Listings"));
        //Enter details 
        protected IWebElement TitleTextBox => _driver.FindElement(By.Name("title"));
        protected IWebElement DescriptionTextBox => _driver.FindElement(By.Name("description"));
        protected IWebElement CategoryDropDown => _driver.FindElement(By.Name("categoryId"));
        protected IWebElement SubCategory => _driver.FindElement(By.Name("subcategoryId"));
        protected IWebElement Tag => _driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div[1]/div/div/div/input"));
        protected IWebElement ServiceType => _driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div"));
        protected IWebElement LocationType => _driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));
        protected IWebElement StartDate => _driver.FindElement(By.Name("startDate"));
        protected IWebElement EndDate => _driver.FindElement(By.Name("endDate"));
        protected IWebElement StartTime => _driver.FindElement(By.XPath("//div[" + i + "]/div[2]/input"));
        protected IWebElement EndTime => _driver.FindElement(By.XPath("//div[" + j + "]/div[3]/input"));
        protected IWebElement SkillTrade => _driver.FindElement(By.XPath(".//*[@name='skillTrades' and @value='true']"));
        protected IWebElement SkillExchange => _driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"));
        protected IWebElement WorkSampleIcon => _driver.FindElement(By.XPath(".//*[@class='ui grid']/span/i"));
        protected IWebElement Active => _driver.FindElement(By.XPath("//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']/div[1]/input[@value='true']"));
        protected IWebElement SaveButton => _driver.FindElement(By.XPath(".//*[@value='Save' and @type='button']"));

        //Validate Added services 
        protected IWebElement GetCategoryfromManageListing => _driver.FindElement(By.XPath(".//table[@class='ui striped table']/tbody/tr[1]/td[2]"));
        protected IWebElement GetTitlefromManageListing => _driver.FindElement(By.XPath(".//table[@class='ui striped table']/tbody/tr[1]/td[3]"));
       

        #endregion

        //Click on Share skill Tab
        public void ClickShareskill(IWebDriver driver)
        {
            //wait untill driver find share skill tab
            Sync.WaitforVisibility(_driver, "LinkText", "Share Skill", 10);
            //Click on share skill tab
            ShareSkillTab.Click();
        }
        //Enter share skill details 
        public void EnterShareSkill(IWebDriver driver)
        {
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "AddShareskill");
            //wait
            Sync.WaitforVisibility(driver, "Name", "title", 10);
            //find Out Title textField
            TitleTextBox.SendKeys(ExcelLibHelpers.ReadData(2, "Title"));
          
            //find Out Description  textField
            DescriptionTextBox.SendKeys(ExcelLibHelpers.ReadData(2, "Description"));

            //find Out Category droupdown
            CategoryDropDown.SendKeys(ExcelLibHelpers.ReadData(2, "Category"));

            //find Out  Sub Category droupdown 
            SubCategory.SendKeys(ExcelLibHelpers.ReadData(2, "Sub Category"));

            //find Out  Tag 
            Tag.SendKeys(ExcelLibHelpers.ReadData(2, "Tag") + Keys.Enter);

            //find Out  Service Type - Radio Button
            ServiceType.Click();

            //find Out  Location Type - Radio Button
            LocationType.Click();

            //Available Days table
            //Click on Start Date DropDown 
            StartDate.SendKeys(ExcelLibHelpers.ReadData(2, "Start Date"));

            //Click on End Date DropDown 
            EndDate.SendKeys(ExcelLibHelpers.ReadData(2, "End Date"));

            //Loop for Start time and End time table
            for (i = 2; i < 9; i++)
            {
                //Click on Start Time DropDown 
                StartTime.SendKeys(ExcelLibHelpers.ReadData(i, "Start Time"));

                for (j = 2; j < 9; j++)
                {
                    //Click on End TIme DropDown 
                    EndTime.SendKeys(ExcelLibHelpers.ReadData(j, "End Time"));
                }
                
            }

            //find Out Skill Trade radio button
            SkillTrade.Click();

            //Find out Skill Exchange Text-Field
            SkillExchange.SendKeys(ExcelLibHelpers.ReadData(2, "Skill Exchange") + Keys.Enter);

            //Find Out + "Work Sample" button to upload file
            WorkSampleIcon.Click();

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
            Active.Click();

            //find SAVE button-
            SaveButton.Click();
      
        }

        //Validate - Entered share skill should be in manage listing 
        public void ValidateShareSkill(IWebDriver driver)
        {
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "AddShareskill");
            //wait
            Sync.WaitforVisibility(driver, "LinkText", "Manage Listings", 20);
            //For Assertion - After click on save button skill saved in manage list page
            //need to go Manage Listing Tab first and get category and titlt text 
            try
            {
                //Click on manage listing TAb
                ManageListinTab.Click();
            }
            catch(NoSuchElementException e)
            {
                Console.WriteLine(e);
            }

            Sync.WaitforVisibility(driver, "XPath", ".//table[@class='ui striped table']/tbody/tr[1]/td[2]", 20);
            //Get Category of Manage List
            String ManageListCategory = GetCategoryfromManageListing.Text;

            //Get title of Manage List
            String ManageTitle = GetTitlefromManageListing.Text;

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
            TitleTextBox.SendKeys(ExcelLibHelpers.ReadData(2, "Title"));
           
            //find Out Description  textField
            DescriptionTextBox.SendKeys(ExcelLibHelpers.ReadData(2, "Description"));

            //find Out Category droupdown
            CategoryDropDown.SendKeys(ExcelLibHelpers.ReadData(2, "Category"));

            //find Out  Sub Category droupdown 
            SubCategory.SendKeys(ExcelLibHelpers.ReadData(2, "Sub Category"));

            //find Out  Tag 
             Tag.SendKeys(ExcelLibHelpers.ReadData(2, "Tag") + Keys.Enter + ExcelLibHelpers.ReadData(3, "Tag") + Keys.Enter);

            //find Out  Service Type - Radio Button
            ServiceType.Click();

            //find Out  Location Type - Radio Button
            LocationType.Click();

            //Available Days table
            //Click on Start Date DropDown 
            StartDate.SendKeys(ExcelLibHelpers.ReadData(2, "Start Date"));

            //Click on End Date DropDown 
            EndDate.SendKeys(ExcelLibHelpers.ReadData(2, "End Date"));

            //Loop for Start time and End time table
            for (i = 2; i < 9; i++)
            {
                //Click on Start Date DropDown 
                StartTime.SendKeys(ExcelLibHelpers.ReadData(i, "Start Time"));

                for (j = 2; j < 9; j++)
                {
                    //Click on End Date DropDown 
                    EndTime.SendKeys(ExcelLibHelpers.ReadData(j, "End Time"));
                }

            }

            //find Out Skill Trade radio button
            SkillTrade.Click();

            //Find out Skill Exchange Text-Field
            SkillExchange.SendKeys(ExcelLibHelpers.ReadData(2, "Skill Exchange") + Keys.Enter + ExcelLibHelpers.ReadData(3, "Skill Exchange") + Keys.Enter);

            //Find Out + "Work Sample" button to upload file
            WorkSampleIcon.Click();

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
            Active.Click();

            //find SAVE button-
            SaveButton.Click();

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
            ManageListinTab.Click();

            Sync.WaitforVisibility(driver, "XPath", ".//table[@class='ui striped table']/tbody/tr[1]/td[2]", 10);
            //Get Category of Manage List
            String ManageListCategory = GetCategoryfromManageListing.Text;

            //Get title of Manage List
            String ManageTitle = GetTitlefromManageListing.Text;

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

