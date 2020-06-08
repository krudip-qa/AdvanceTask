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
    class Language
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public Language(IWebDriver driver)
        {
            _driver = driver;
        }
        //Add language
        public void AddLanguage(IWebDriver driver)
        {
            //Populate ExcelLibHelper
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileLanguage");
            
            //click on Language tab
            driver.FindElement(By.XPath(".//a[@data-tab='first']")).Click();
            Thread.Sleep(2000);
            //click on Add New button 
            driver.FindElement(By.XPath("//div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();
            //write language into Add Language Textbox
            driver.FindElement(By.XPath(".//input[@placeholder='Add Language']")).SendKeys(ExcelLibHelpers.ReadData(2, "Language"));
            //Save WebElement of DropDown into WebElement variable
            IWebElement LanguageDropDown = driver.FindElement(By.Name("level"));
            //List all the Available Options from Language DropDown
            IList<IWebElement> LanguageDopDownList = LanguageDropDown.FindElements(By.TagName("option"));
            //Count the totle number of options available in DropDown
            int Count = LanguageDopDownList.Count();
            Boolean result = true;
            try
            {
                //Use loop to iterate List and match options with ExcelSheet
                for (int i = 0; i <= Count; i++)
                {
                    //Console.WriteLine(LanguageDopDownList[i].Text);
                    if (LanguageDopDownList[i].Text == ExcelLibHelpers.ReadData(5, "Language Level"))
                    {
                        LanguageDopDownList[i].Click();
                        //Console.WriteLine(LanguageDopDownList[i].Text);
                        _ = result;
                        break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            //click on Add button
            driver.FindElement(By.XPath(".//*[@value='Add']")).Click();
        }

        //Validate Added language in list
        public void ValidateAddLanguage(IWebDriver driver)
        {
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileLanguage");
            //Added language is
            String expextedValue = ExcelLibHelpers.ReadData(2, "Language");
            Sync.WaitforVisibility(driver, "XPath", "//div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10);
            //Get the text value from language list
            String actualValue = driver.FindElement(By.XPath("//div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;
            try
            {
                //Compair expect and actual value 
                if (expextedValue == actualValue)
                {
                    Assert.AreEqual(expextedValue, actualValue);
                    Console.WriteLine("Added Language is: " + actualValue);
                }
                else
                {
                    Console.WriteLine("Test Fail");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Edit Language
        public void EditLanguage(IWebDriver driver)
        {
            //Might get exception if no language been Added try to edit so give you exception for edit button 
            try
            {
                //Click on pen button to edit details 
                driver.FindElement(By.XPath("//*[@data-tab='first']/div/div[2]/div/table/tbody[1]/tr/td/span[1]/i[1]")).Click();
            }
            catch(NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
           
             //click on Add Language textField and clear textbox
            driver.FindElement(By.XPath(".//td[@colspan='3']/div/div/input")).Clear();
            //populate Login Page Test data collection
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileLanguage");
            //Enter Language
            driver.FindElement(By.XPath(".//td[@colspan='3']/div/div/input")).SendKeys(ExcelLibHelpers.ReadData(2, "Edit Language"));
            //Select Level of language
            IWebElement DropdownEditLangList = driver.FindElement(By.Name("level"));
            DropdownEditLangList.SendKeys(ExcelLibHelpers.ReadData(2, "Level of Language") + Keys.Enter);
            //Click on Update button
            driver.FindElement(By.XPath(".//*[@colspan='3']/div/span/input[1]")).Click();
        }

        //Validate Language been updated in list
        public void ValidateEditLanguage(IWebDriver driver)
        {
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ProfileLanguage");
            //Edited language is
            String expextedValue = ExcelLibHelpers.ReadData(2, "Edit Language");
            Sync.WaitforVisibility(driver, "XPath", "//div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]", 10);
            //Get the text value from language list
            String actualValue = driver.FindElement(By.XPath("//div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]")).Text;

            try
            {
                //Compair expect and actual value 
                if (expextedValue == actualValue)
                {
                    Assert.AreEqual(expextedValue, actualValue);
                }
                else
                {
                    Console.WriteLine("Test Fail");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    
        //Delete Language
        public void DeleteLanguage(IWebDriver driver)
        {           
            //Get name of language to be delete
            String Language = driver.FindElement(By.XPath("//div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]")).Text;
            try
            {
                 //click on X button to delete
                driver.FindElement(By.XPath("//*[@data-tab='first']/div/div[2]/div/table/tbody[1]/tr/td/span[2]/i[1]")).Click();
            }
            catch(NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Deleted Language is: " + Language);
        }
           
        //Validate Language been deleted from list
        public void ValidateDeleteLanguage(IWebDriver driver)
        {
            Sync.WaitforVisibility(driver, "ClassName", "ns-box-inner", 10);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string msglang = driver.FindElement(By.ClassName("ns-box-inner")).Text;
            Console.WriteLine(msglang);
            driver.FindElement(By.ClassName("ns-close")).Click();
            driver.SwitchTo().DefaultContent();

        }
    }
}
