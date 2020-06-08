using InternProject3.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//It will Covers Name, Location, Avaibilities, Hours, Earn Hours 

namespace InternProject3.pages.Profile
{
    class ProfileDetail
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public ProfileDetail(IWebDriver driver)
        {
            _driver = driver;
        }
        //Function for Name Title
        public void NameTitle(IWebDriver driver)
        {
            //Populate ExcelLibHelper
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileDetail");
            Sync.WaitforVisibility(driver, "XPath", ".//div[@class='title']/i", 10);
            // Click on Drop - Down button to enter name Details
            driver.FindElement(By.XPath(".//div[@class='title']/i")).Click();
            //Enter first Name 
            Sync.WaitforVisibility(driver, "XPath", ".//input[@name='firstName']", 10);
            //CLear FirstName Text Field 
            driver.FindElement(By.XPath(".//input[@name='firstName']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='firstName']")).SendKeys(ExcelLibHelpers.ReadData(2, "FirstName"));
            //Enter Last Name 
            //CLear lastName Text Field 
            driver.FindElement(By.XPath(".//input[@name='lastName']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='lastName']")).SendKeys(ExcelLibHelpers.ReadData(2, "LastName"));
            //Click on SAVE button 
            driver.FindElement(By.XPath(".//button[@class='ui teal button']")).Click();

        }
        //Validation for name 
        public void ValidateName(IWebDriver driver)
        {
            Thread.Sleep(2000);
            //Populate ExcelLibHelper
             ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileDetail");
            Sync.WaitforVisibility(driver, "XPath", ".//div[@class='title']", 30);
            //Assert - get the name from title and match with provided details
            string Actual = driver.FindElement(By.XPath(".//div[@class='title']")).Text;
            string expected = ExcelLibHelpers.ReadData(2, "Name Title");
                    
            try
            {
               Assert.AreEqual(Actual, expected);
             
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Function for Availability
        public void Availability(IWebDriver driver)
        {
            //Populate ExcelLibHelper
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileDetail");
            Sync.WaitforVisibility(driver, "XPath", ".//div[@class='ui list']/div[2]/div/span/i", 10);
            //click on pen button to Select Availability from part time or full time
            driver.FindElement(By.XPath(".//div[@class='ui list']/div[2]/div/span/i")).Click();
            //click on Drp-Down Arrow // Xpath - .//select[@name="availabiltyType"]
            driver.FindElement(By.Name("availabiltyType")).Click();
            IWebElement Availability = driver.FindElement(By.Name("availabiltyType"));
            Thread.Sleep(1000);
            Actions actions = new Actions(driver);
            actions.MoveToElement(Availability).Build().Perform();
            Sync.WaitforVisibility(driver, "TagName", "option", 20);
            IList<IWebElement> HourList = Availability.FindElements(By.TagName("option"));
            //String AvaibilityType = driver.FindElement(By.Name("availabiltyType")).Text;
            int Count = HourList.Count();
            Boolean result = true;
            try
            {
                for (int i = 1; i <= Count; i++)
                {
                    //Console.WriteLine(HourList[i].Text);
                    if (HourList[i].Text == ExcelLibHelpers.ReadData(3, "Availability"))
                    {
                        HourList[i].Click();
                        //For Console 
                        Console.WriteLine(HourList[i].Text);
                        _ = result;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
               
        //Function for Hour
        public void Hour(IWebDriver driver)
        {
            //Populate ExcelLibHelper
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileDetail");
            Sync.WaitforVisibility(driver, "XPath", ".//div[@class='ui list']/div[3]/div/span/i", 10);
            //click on Pen button to Edit
            driver.FindElement(By.XPath(".//div[@class='ui list']/div[3]/div/span/i")).Click();
            //Click on Drop-Down 
            driver.FindElement(By.Name("availabiltyHour")).Click();
            //Save Hour WebElemets into Element variable
            IWebElement AvailableHour = driver.FindElement(By.Name("availabiltyHour"));
            Thread.Sleep(1000);
            Actions actions = new Actions(driver);
            actions.MoveToElement(AvailableHour).Build().Perform();
            Sync.WaitforVisibility(driver, "TagName", "option", 10);
            //List the Hours options using tagname "option" - It suppose to be 4 
            IList<IWebElement> HourList = AvailableHour.FindElements(By.TagName("option"));
            Boolean result = true;
            //Conver Listed Hours into size  
            int Count = HourList.Count();
            //Using for loop iterate all option
            for (int i = 1; i < Count; i++)
            {
                //Console.WriteLine(HourList[i].Text);
                //Compair Listed hour with Excel data
                if (HourList[i].Text == ExcelLibHelpers.ReadData(2, "Hours"))
                {
                    //If condition true it will click and break the loop after condition satisfaction
                    HourList[i].Click();
                    ////Been Selected
                    //Console.WriteLine(HourList[i].Text);
                    _ = result;
                    break;
                }
            }
        }

        //Function for Earn Target
        public void EarnTarget(IWebDriver driver)
        {

            Sync.WaitforVisibility(driver, "XPath", ".//*[@class='ui list']/div[4]/div/span/i", 10);
            //Populate ExcelLibHelper
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileDetail");
            //Click on pen button to Edit data
            driver.FindElement(By.XPath(".//*[@class='ui list']/div[4]/div/span/i")).Click();
            //Click on Drop-Down button
            driver.FindElement(By.Name("availabiltyTarget")).Click();
            IWebElement EarnType = driver.FindElement(By.Name("availabiltyTarget"));
            Thread.Sleep(1000);
            Actions actions = new Actions(driver);
            actions.MoveToElement(EarnType).Build().Perform();
            Sync.WaitforVisibility(driver, "TagName", "option", 10);
            //List the Hours options using tagname "option" - It suppose to be 4 
            IList<IWebElement> EarnList = EarnType.FindElements(By.TagName("option"));
            Boolean result = true;
            int Count = EarnList.Count();
            for(int i = 1; i < Count; i++)
            {
                //Console.WriteLine(EarnList[i].Text);
                if(EarnList[i].Text == ExcelLibHelpers.ReadData(4, "Earn Target"))
                {
                    EarnList[i].Click();
                    //For Console
                    //Console.WriteLine(EarnList[i].Text);
                    _ = result;
                    break;
                }
            }
        }

        //Validation for Avaibility, Hours and Earn Target 
        public void Validation(IWebDriver driver)
        {
            //For assertion get the text from pop up for sucessfull editing hours
            Sync.WaitforVisibility(driver, "ClassName", "ns-box-inner", 10);
            //Get the text from pop up window 
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string msglang = driver.FindElement(By.ClassName("ns-box-inner")).Text;
            Console.WriteLine(msglang);
            //close the pop up
            driver.FindElement(By.ClassName("ns-close")).Click();
            driver.SwitchTo().DefaultContent();

        }

    }
}
