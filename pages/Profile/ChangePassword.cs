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

        #region Initialise Change Password WebElements

       protected IWebElement CurrentPasswordTextField => _driver.FindElement(By.XPath("//*[@autocomplete='new-password']/div[1]/input"));
        protected IWebElement NewPasswordTextField => _driver.FindElement(By.XPath("//*[@autocomplete='new-password']/div[2]/input"));
        protected IWebElement ConfirmPasswordTextField => _driver.FindElement(By.XPath("//*[@autocomplete='new-password']/div[3]/input"));
        protected IWebElement SaveButton => _driver.FindElement(By.XPath("//*[@autocomplete='new-password']/div[4]/button"));
        protected IWebElement PopUpMessage => _driver.FindElement(By.ClassName("ns-box-inner"));
        protected IWebElement PopUpDelete => _driver.FindElement(By.ClassName("ns-close"));

        #endregion

        public void PasswordChange(IWebDriver driver)
        {      
            //Populate ExcelLibHelper
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "ChangePassword");
            //Enter current password
            CurrentPasswordTextField.SendKeys("Current Password");
            //Enter New passWord
            NewPasswordTextField.SendKeys("New Password");
            //Enter Confirm  password
            ConfirmPasswordTextField.SendKeys("Confirm Password");
            //Click on Save button
            SaveButton.Click();
           
        }
        public void ValidationPasswordChange(IWebDriver driver)
        {
            //Get the pop up message 
            //wait untill pop up window findout 
            Sync.WaitforVisibility(driver, "ClassName", "ns-box-inner", 20);
            //Get the text from pop up window 
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string msglang = PopUpMessage.Text;
            Console.WriteLine(msglang);
            PopUpDelete.Click();
            driver.SwitchTo().DefaultContent();
        }

    }
}
