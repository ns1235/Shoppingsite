using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineShopping.PageObjects
{
    class loginpage
    {


        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "login")]        
        public IWebElement SignInbtn { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        public IWebElement LogInbtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title=\"View my customer account\"]")]
        public IWebElement MyAccount { get; set; }



        public loginpage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ClickOnSignIn()
        {
            SignInbtn.Click();
        }

        public void Login()
        {
            Email.SendKeys("catchmeniharika@gmail.com");
            Password.SendKeys("testing");
            LogInbtn.Submit();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.AreEqual("Test Test",MyAccount.Text);
        }

        
    }
}
