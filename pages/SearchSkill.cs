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

        //Constructor for dependency injection
        public SearchSkill(IWebDriver driver)
        {
            _driver = driver;
        }
        //SearchSkill by All categories and Sub-Category
        public void SearchskillbyCategory(IWebDriver driver)
        {
            Sync.WaitforVisibility(driver, "XPath", "//*[@class='four wide column']/div/div/a[7]", 20);
            //populate excel 
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "SearchSkill");
            //Click on one of the category og All categories
            driver.FindElement(By.XPath("//*[@class='four wide column']/div/div/a[7]")).Click();
            //Click on Sub-Category
            driver.FindElement(By.XPath("//*[@class='four wide column']/div/div/a[11]")).Click();
            //Enter Search skill
            driver.FindElement(By.XPath("//*[@class='four wide column']/div[2]/input")).SendKeys(ExcelLibHelpers.ReadData(2, "Search Skill"));
            //Enter Search User
            driver.FindElement(By.XPath("//*[@class='four wide column']/div[3]/div/div/div/input")).SendKeys(ExcelLibHelpers.ReadData(2, "Search User"));
            //Sync.WaitforVisibility(driver, "XPath", "//*[@class='results transition visible']/div[1]", 20);
            ////Choose first option
            //IWebElement select = driver.FindElement(By.XPath("//*[@class='results transition visible']/div[1]"));
       
        }   

        //Validation - 
        public void ValidateSearchSkill(IWebDriver driver)
        {
            Sync.WaitforVisibility(driver, "XPath", "//*[@class='ui stackable three cards']/div[1]/div/a[2]/p", 10);
            //Get the skill name from search results   
            string ActualValue = driver.FindElement(By.XPath("//*[@class='ui stackable three cards']/div[1]/div/a[2]/p")).Text;
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
            IWebElement filter = driver.FindElement(By.XPath("//*[@class='ui buttons']"));
            //Stored list of buttons
            IList<IWebElement> buttonList = filter.FindElements(By.TagName("button"));
            //Convert into int and count the number of buttons
            int count = buttonList.Count();
            
            //Loop the button list and match with exceldata
            for (int i = 1; i <= count; i++)
            {
               ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "SearchSkill");
               //This xpath used for all button -place the i value and make then button
                string buttontType = driver.FindElement(By.XPath("//*[@class='ui buttons']/button[" + i + "]")).Text;
                //check if that button name matched with excel data 
                if (buttontType == ExcelLibHelpers.ReadData(2, "Button Type"))
                {
                    //click on button
                    driver.FindElement(By.XPath("//*[@class='ui buttons']/button[" + i + "]")).Click();
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
