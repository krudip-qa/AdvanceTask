using InternProject3.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProject3.pages
{
    class ManageListing 
    {
        private readonly IWebDriver _driver;

        //Constructor for dependency injection
        public ManageListing(IWebDriver driver)
        {
            _driver = driver;
        }

        //View manage listing 
        public void View(IWebDriver driver)
        {            
            //wait
            Sync.WaitforVisibility(driver, "XPath", "(//i[@class='eye icon'])[1]", 10);
           
            //Click on View at manage listing Tab
            driver.FindElement(By.XPath("(//i[@class='eye icon'])[1]")).Click();
        }
        
        //validate View
        public void ValidateView(IWebDriver driver)
        {
            try
            {
                //Assert that if View icon to be clicked than URl Contains "ServiceDetail" 
                String urlTitle = driver.Title;
                Console.WriteLine(urlTitle);
                //Assertion
                Assert.AreEqual("Service Detail", urlTitle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Edit manage list 
        public void EditManageList(IWebDriver driver)
        {
            //calling edit function of share skill here
            ShareSkill shareobj = new ShareSkill(_driver);
            //It will navigate to Service listing page and does the edit action
            shareobj.EditShareSkill(_driver);
        }

        //Validate - you will be on service Listing page
        public void ValidateEditManageList(IWebDriver driver)
        { 
        //calling edit function of share skill here
        ShareSkill shareobj = new ShareSkill(_driver);
        shareobj.ValidateEditShareSkill(_driver);
        }

        //Delete Share Skill Details in 
        public void DeleteManageList(IWebDriver driver)
        {
            Sync.WaitforVisibility(driver, "XPath", "(//i[@class='remove icon'])[1]", 20);
            //Click on Delete button
            driver.FindElement(By.XPath("(//i[@class='remove icon'])[1]")).Click();

            //Wait untill Driver finds pop up YES or NO button to click
            Sync.WaitforVisibility(driver, "XPath", "//div[@class='actions']/button[2]", 2);

            //Click on Yes or No button
            driver.FindElement(By.XPath("//div[@class='actions']/button[2]")).Click();
        }
        // Validate - Delete in manage listsing
        public void ValidateDeleteManageList(IWebDriver driver)
        {
            try
            {
                Sync.WaitforVisibility(driver, "ClassName", "ns-box-inner", 10);
                //Assert - Get the pop up text in PopUpMsg Variable.
                String PopUpMsg = driver.FindElement(By.ClassName("ns-box-inner")).Text;
                //Assert that popUp will open and has not to be null(or Emplty)
                Assert.NotNull(PopUpMsg);
                Console.WriteLine(PopUpMsg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
