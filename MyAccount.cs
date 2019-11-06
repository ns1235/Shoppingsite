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
    class MyAccount
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), \"My personal information\")]")]
        public IWebElement PersonalInfo { get; set; }

        [FindsBy(How = How.Id, Using = "firstname")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "old_passwd")]
        public IWebElement OldPassword { get; set; }

        [FindsBy(How = How.Name, Using = "submitIdentity")]
        public IWebElement Save { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='center_column']/div[@class='box']/p[@class='alert alert-success']")]
        public IWebElement message { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title=\"View my customer account\"]")]
        public IWebElement Account { get; set; }

        public MyAccount(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        public void UpdateName()
        {
            PersonalInfo.Click();
            Thread.Sleep(2000);
            FirstName.Clear();
            FirstName.SendKeys("Testauto");
            OldPassword.SendKeys("testing");
            Save.Click();
            Assert.AreEqual("Your personal information has been successfully updated.",message.Text.ToString());
            Assert.AreEqual("Testauto Test", Account.Text.ToString());
        }

        public void RevertName()
        {
            Account.Click();
            PersonalInfo.Click();
            Thread.Sleep(2000);
            FirstName.Clear();
            FirstName.SendKeys("Test");
            OldPassword.SendKeys("testing");
            Save.Click();
            Assert.AreEqual("Your personal information has been successfully updated.", message.Text.ToString());

        }
    }
}
