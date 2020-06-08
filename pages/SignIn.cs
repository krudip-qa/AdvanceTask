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
    class SignIn
    {
        public void SignInSteps(IWebDriver driver)
        {

            //Hit the Url
            driver.Navigate().GoToUrl("http://192.168.99.100:5000/Home");
            //Maximise screen
            driver.Manage().Window.Maximize();

            Sync.WaitforVisibility(driver, "XPath", "//*[@id='home']/div/div/div[1]/div/a", 10);
            //Click n Sign In 
            driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a")).Click();
            //Navigate to Pop up
            driver.SwitchTo().DefaultContent();
            //Populate ExcelLibHelper
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "SignIn");
            //Give Username and Password
            driver.FindElement(By.Name("email")).SendKeys(ExcelLibHelpers.ReadData(2,"Email"));
            //identify password and provide input
            driver.FindElement(By.Name("password")).SendKeys(ExcelLibHelpers.ReadData(2, "Password"));
            //check on checkbox
            driver.FindElement(By.XPath("//input[@name='rememberDetails']")).Click();
            //click on Login button 
            driver.FindElement(By.XPath("//button[@class='fluid ui teal button']")).Click();

            //Assert

            try
            {                
                //Wait untill 
                Sync.WaitforVisibility(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span", 50);
                string LoginText = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")).Text;
                Console.WriteLine(LoginText);
                Thread.Sleep(2000);
                //Assertion for checking condition
                Assert.That(LoginText, Is.EqualTo(ExcelLibHelpers.ReadData(2, "Title ")));
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
