using InternProject3.pages;
using InternProject3.pages.Profile;
using InternProject3.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InternProject3
{
    class Program
    {
        static void Main(string[] args)
        {
            ////define driver 
            //GlobalDriver.driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application");
           
            //Thread.Sleep(2000);
            ////Hit the Url
            //GlobalDriver.driver.Navigate().GoToUrl("http://192.168.99.100:5000/Home");
            ////Maximise screen
            //GlobalDriver.driver.Manage().Window.Maximize();

            ////create an Page object for SignIn Page 
            //SignIn logInObj = new SignIn();
            //logInObj.SignInSteps(GlobalDriver.driver);

            ////create an Page object for SignUp Page 
            //SignUp joinObj = new SignUp();
            //joinObj.Join(GlobalDriver.driver);

            ////Profile page -
            ////Description
            //Description DescriptionObj = new Description();
            //DescriptionObj.ProfileDescription(GlobalDriver.driver);
            ////Language
            //Language LangObj = new Language();
            //LangObj.AddLanguage(GlobalDriver.driver);
            ////Skill
            //Skill SkillObj = new Skill();
            //SkillObj.ProfileSkill(GlobalDriver.driver);
            ////Education
            //Education EduObj = new Education();
            //EduObj.ProfileEducation(GlobalDriver.driver);
            ////Certificate
            //Certificate CertyObj = new Certificate();
            //CertyObj.ProfileCertificate(GlobalDriver.driver);
            ////ProfileDetail - NameTitle,Location,Avaibility,Hour
            //ProfileDetail DetailObj = new ProfileDetail();
            //DetailObj.NameTitle(GlobalDriver.driver);
            //DetailObj.Availability(GlobalDriver.driver);
            //DetailObj.Hour(GlobalDriver.driver);
            //DetailObj.EarnTarget(GlobalDriver.driver);
                                            
        }
    }
}
