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
    class Skill
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public Skill(IWebDriver driver)
        {
            _driver = driver;
        }
        public void AddSkill(IWebDriver driver)
        {
            //Populate ExcelLibHelper
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileSkill");
            //Wait untill driver find Skill button
            Sync.WaitforVisibility(driver, "XPath", ".//a[@data-tab='second']", 10);
            //click on a Skill Tab
            driver.FindElement(By.XPath(".//a[@data-tab='second']")).Click();
            //click on Add New Button
            driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();
            //give input in Add Skill TextField
            driver.FindElement(By.XPath(".//*[@placeholder='Add Skill']")).SendKeys(ExcelLibHelpers.ReadData(2, "Skill Name"));
            //print the name of added skill from excel
            Console.WriteLine(ExcelLibHelpers.ReadData(2, "Skill Name"));
            //choose Skill Level from drop-down Box
            driver.FindElement(By.XPath("//div[3]/form/div[3]/div/div[2]/div/div/div[2]/select")).Click();
            //Save the dropdown WebElement into webElement variable
            IWebElement SkillDropDown = driver.FindElement(By.XPath("//div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            //List all the Available Options in DropDown
            IList<IWebElement> SkillLevelList = SkillDropDown.FindElements(By.TagName("option"));
            //Count the total number of Options available in list 
            int Count = SkillLevelList.Count();
            Boolean result = true;
           try
            {            
             //Use For loop to iterate and match level with ExcelSheet
             for(int i = 0; i <= Count; i++)
             {
                Console.WriteLine(SkillLevelList[i].Text);
                if (SkillLevelList[i].Text == ExcelLibHelpers.ReadData(2, "Skill Level"))
                {
                   //Click on Skill Level 
                   SkillLevelList[i].Click();
                   Console.WriteLine("Level been selected");
                   _ = result;
                   break;
                }
             }
           }
           catch(Exception e)
           {
              Console.WriteLine(e.Message);
           }
            //click on Add Button 
            driver.FindElement(By.XPath("//div[3]/div/div[2]/div/div/span/input[1]")).Click();
            
        }

        //Validate Added skill 
        public void ValidateAddSkill(IWebDriver driver)
        {
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileSkill");
            //Entered Skill is
            string AddedSkill = ExcelLibHelpers.ReadData(2, "Skill Name");
            //Get the skill from skill list
           string listedSkill = driver.FindElement(By.XPath("//*[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;
            //Added skill should be in list 
            try
            {
                Assert.AreEqual(AddedSkill, listedSkill);
                Console.WriteLine(AddedSkill+" "+"Find in List");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Update Skill
        public void EditSkill(IWebDriver driver)
        {
            Sync.WaitforVisibility(driver, "XPath", ".//a[@data-tab='second']", 10);
            //click on a Skill Tab to Edit Skill
            driver.FindElement(By.XPath(".//a[@data-tab='second']")).Click();
            //click on pen button to edit Skill textbox and droupdown box
            driver.FindElement
                (By.XPath(".//*[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td/span[1]/i")).Click();
            //update the skill into text feild
            driver.FindElement(By.XPath(".//input[@placeholder='Add Skill']")).Clear();
            //populate Login Page Test data collection
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileSkill");
            //write updated skill in here
            driver.FindElement(By.XPath(".//input[@placeholder='Add Skill']")).SendKeys(ExcelLibHelpers.ReadData(2, "Edit Skill"));
            //choose Skill Level from drop-down Box
            driver.FindElement
                (By.XPath("//*[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td/div/div[2]/select")).Click();
            driver.FindElement
                (By.XPath("//*[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td/div/div[2]/select")).
                SendKeys(ExcelLibHelpers.ReadData(2, "Level of Skill"));
            //click on Update button 
            driver.FindElement(By.XPath("//*[@data-tab='second']/div/div[2]/div/table/tbody/tr/td/div/span/input[1]")).Click();
        }

        //Validate Updated skill
        public void validateUpdatedSkill(IWebDriver driver)
        {
            Thread.Sleep(2000);
            //Updated skill is
            String UpdatedSkill = ExcelLibHelpers.ReadData(2, "Edit Skill");
            //Get the text from Skill list 
            string ListedSkill = driver.FindElement(By.XPath(".//*[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;
            //For validation UpdatedSkill and ListedSkill has to be same 
            try
            {
                Assert.AreEqual(UpdatedSkill, ListedSkill);
                Console.WriteLine("Updated Skill is: " + ListedSkill);
            }
             catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        //Delete Skill
        public void DeleteSkill(IWebDriver driver)
        {
            Thread.Sleep(2000);
            //click on a Skill Tab
            driver.FindElement(By.XPath(".//a[@data-tab='second']")).Click();
            try
            {            
                //Click on Delete button
                driver.FindElement
                (By.XPath("//*[@data-tab='second']/div/div[2]/div/table/tbody[last()]/tr/td/span[2]")).Click();
            }
            catch(NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Validate deleted language
        public void ValidateDeleteSkill(IWebDriver driver)
        {
            //Wait untill pop up
            Sync.WaitforVisibility(driver, "ClassName", "ns-box-inner", 10);
            //Get the text from pop up window 
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string msglang = driver.FindElement(By.ClassName("ns-box-inner")).Text;
            Console.WriteLine(msglang);
            driver.FindElement(By.ClassName("ns-close")).Click();
            driver.SwitchTo().DefaultContent();

        }
    }
}


