using InternProject3.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProject3.pages
{
    class SearchSkill
    {
        private readonly IWebDriver _driver;

        int i;

        //Constructor for dependency injection
        public SearchSkill(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Initialise Search Skill WebElements

        //Search SKill
        protected IWebElement SearchSkillTextBox => _driver.FindElement(By.XPath("//*[@placeholder='Search skills']"));
        
        //Seach by Categories
        protected IWebElement SkillCategory => _driver.FindElement(By.XPath("//*[@class='four wide column']/div/div/a[7]"));
        protected IWebElement SubCategory => _driver.FindElement(By.XPath("//*[@class='four wide column']/div/div/a[11]"));
        protected IWebElement SearchSkillinCategories => _driver.FindElement(By.XPath("//*[@class='four wide column']/div[2]/input"));
        protected IWebElement SearchUserName => _driver.FindElement(By.XPath("//*[@class='four wide column']/div[3]/div/div/div/input"));
       
        //Validate
        protected IWebElement GetSkillfromSearchresults => _driver.FindElement(By.XPath("//*[@class='ui stackable three cards']/div[1]/div/a[2]/p"));

        //Search Skill by filter

        //Filter the buttons- Online, Onsite and Show all 
        protected IWebElement filter => _driver.FindElement(By.XPath("//*[@class='ui buttons']"));
        protected IWebElement ButtonType =>  _driver.FindElement(By.XPath("//*[@class='ui buttons']/button[" + i + "]"));
        
        #endregion

        public void SkilltoSearch(IWebDriver driver)
        {
            Sync.WaitforVisibility(_driver, "XPath", "//*[@placeholder='Search skills']", 20);
            //populate excel 
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "SearchSkill");
            // Enter skill to search
            SearchSkillTextBox.SendKeys(ExcelLibHelpers.ReadData(2, "Search Skill") + Keys.Enter);
        }

        //SearchSkill by All categories and Sub-Category
        public void SearchskillbyCategory(IWebDriver driver)
        {
            Sync.WaitforVisibility(driver, "XPath", "//*[@class='four wide column']/div/div/a[7]", 20);
           
            //populate excel 
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "SearchSkill");
            
            //Click on one of the category og All categories
            SkillCategory.Click();
            
            //Click on Sub-Category
            SubCategory.Click();

            //Enter Search skill
            SearchSkillinCategories.SendKeys(ExcelLibHelpers.ReadData(2, "Search Skill"));
            
            //Enter Search User
            SearchUserName.SendKeys(ExcelLibHelpers.ReadData(2, "Search User"));
            
            //Sync.WaitforVisibility(driver, "XPath", "//*[@class='results transition visible']/div[1]", 20);
            ////Choose first option
            //IWebElement select = driver.FindElement(By.XPath("//*[@class='results transition visible']/div[1]"));
       
        }   

        //Validation - 
        public void ValidateSearchSkill(IWebDriver driver)
        {
            Sync.WaitforVisibility(driver, "XPath", "//*[@class='ui stackable three cards']/div[1]/div/a[2]/p", 10);
            //Get the skill name from search results   
            string ActualValue = GetSkillfromSearchresults.Text;
            Console.WriteLine(ActualValue);
            //Get the expected value from excel
            string expectedValue = ExcelLibHelpers.ReadData(2, "Search Skill");
            try
            {
                Assert.That(ActualValue.Contains(expectedValue));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Search by filters
        public void SearchSkillbyFilter(IWebDriver driver)
        {
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "SearchSkill");
            //use the button class for get the list of buttons
            //Stored list of buttons
            IList<IWebElement> buttonList = filter.FindElements(By.TagName("button"));
            //Convert into int and count the number of buttons
            int count = buttonList.Count();
            
            //Loop the button list and match with exceldata
            for (i = 1; i <= count; i++)
            {
               ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "SearchSkill");
               //This xpath used for all button -place the i value and make then button
                string buttontType = ButtonType.Text;
                //check if that button name matched with excel data 
                if (buttontType == ExcelLibHelpers.ReadData(2, "Button Type"))
                {
                    //click on button
                    ButtonType.Click();
                    break;
                }
                else
                {
                    Console.WriteLine("Button not found");
                }


            }
                                   
        }
               
        
    }
}
