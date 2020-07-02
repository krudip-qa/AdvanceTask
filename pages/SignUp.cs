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
        private readonly IWebDriver _driver;
        //Constructor
        public SignUp(IWebDriver driver)
        {
            _driver = driver;
        }

        #region   Initialise Join WebElements
        
        protected IWebElement JoinTab => _driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/button"));
        protected IWebElement FirstName => _driver.FindElement(By.Name("firstName"));
        protected IWebElement LastName => _driver.FindElement(By.Name("lastName"));
        protected IWebElement Email => _driver.FindElement(By.Name("email"));
        protected IWebElement Password => _driver.FindElement(By.Name("password"));
        protected IWebElement ConformPassword => _driver.FindElement(By.Name("confirmPassword"));
        protected IWebElement CheckBox => _driver.FindElement(By.Name("terms"));
        protected IWebElement JoinButton => _driver.FindElement(By.Id("submit-btn"));

        protected IWebElement ConformationUsername => _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));
        #endregion

        public void StepsforJoin(IWebDriver driver)
        {
            ClickOnJoin(_driver);
            Join(_driver);
            Signin(_driver);
        }

        public void ClickOnJoin(IWebDriver driver)
        {
            Sync.WaitforVisibility(driver, "XPath", "//*[@id='home']/div/div/div[1]/div/button", 20);
            //Click on Join Link
            JoinTab.Click();
        }

        public void Join(IWebDriver driver)
        {

            //Find Out First Name TextField
            FirstName.SendKeys("krupa");
            //Find Out Last Name TextField
            LastName.SendKeys("Parekh");
            //Find Out Email Address TextField
            Email.SendKeys("krupaparekh2104@gmail.com");
            //Find Out password TextField
            Password.SendKeys("QaKrupa");
            //Find Out Conform password TextField
            ConformPassword.SendKeys("QaKrupa");
            //Check on Check-box of I Agree
            CheckBox.Click();
            //Find Out Join Button
            JoinButton.Click();
        }
        public void Signin(IWebDriver driver)
        { 
            //once register successfull went to same window and waiting for SignIn 
            //Call SignIn method
            //create an Page object for SignIn Page 
            SignIn logInObj = new SignIn(driver);
            logInObj.SignInSteps(driver);
            Thread.Sleep(2000);
            //After LogIn Find out "Text" like "Hi Krupa"
            String Text = ConformationUsername.Text;
            Console.WriteLine(Text);

        }

       
    }
}
