using InternProject3.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InternProject3.pages
{
    class SignUp
    {
        public void Join(IWebDriver driver)
        {
            Sync.WaitforVisibility(driver, "XPath", "//*[@id='home']/div/div/div[1]/div/button", 20);
            //Click on Join Link
            driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/button")).Click();
            //Find Out First Name TextField
            driver.FindElement(By.Name("firstName")).SendKeys("krupa");
            //Find Out Last Name TextField
            driver.FindElement(By.Name("lastName")).SendKeys("Parekh");
            //Find Out Email Address TextField
            driver.FindElement(By.Name("email")).SendKeys("krupaparekh2104@gmail.com");
            //Find Out password TextField
            driver.FindElement(By.Name("password")).SendKeys("QaKrupa");
            //Find Out Conform password TextField
            driver.FindElement(By.Name("confirmPassword")).SendKeys("QaKrupa");
            //Check on Check-box of I Agree
            driver.FindElement(By.Name("terms")).Click();
            //Find Out Join Button
            driver.FindElement(By.Id("submit-btn")).Click();
            
           
            //once register successfull went to same window and waiting for SignIn 
            //Call SignIn method
            //create an Page object for SignIn Page 
            SignIn logInObj = new SignIn();
            logInObj.SignInSteps(GlobalDriver.driver);
            Thread.Sleep(2000);
            //After LogIn Find out "Text" like "Hi Krupa"
            String Text = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")).Text;
            Console.WriteLine(Text);

        }
    }
}
