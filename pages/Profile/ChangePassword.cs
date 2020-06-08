using InternProject3.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProject3.pages.Profile
{
    class ChangePassword
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public ChangePassword(IWebDriver driver)
        {
            _driver = driver;
        }
        public void PasswordChange(IWebDriver driver)
        {      
            //Populate ExcelLibHelper
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ChangePassword");
            //Enter current password
            driver.FindElement(By.XPath("//*[@autocomplete='new-password']/div[1]/input")).SendKeys("Current Password");
            //Enter New passWord
            driver.FindElement(By.XPath("//*[@autocomplete='new-password']/div[2]/input")).SendKeys("New Password");
            //Enter Confirm  password
            driver.FindElement(By.XPath("//*[@autocomplete='new-password']/div[3]/input")).SendKeys("Confirm Password");
            //Click on Save button
            driver.FindElement(By.XPath("//*[@autocomplete='new-password']/div[4]/button")).Click();
           
        }
        public void ValidationPasswordChange(IWebDriver driver)
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
