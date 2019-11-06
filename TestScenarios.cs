using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OnlineShopping.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OnlineShoppingNew
{
    [TestClass]
    public class TestScenarios
    {
        [TestMethod]
        public void TestMethod1_UpdateName()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.automationpractice.com";
            Thread.Sleep(3000);
            driver.Manage().Window.Maximize();

            var LoginPage = new loginpage(driver);
            LoginPage.ClickOnSignIn();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);          
            LoginPage.Login();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var myaccount = new MyAccount(driver);
            myaccount.UpdateName();
            myaccount.RevertName();

            driver.Close();

        }

        [TestMethod]
        public void TestMethod2_OrderTshirt()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.automationpractice.com";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            var LoginPage = new loginpage(driver);
            LoginPage.ClickOnSignIn();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage.Login();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var order = new Order(driver);
            order.NavigateToTshirtLink();
            order.AddtoCart();
            order.OrderSummary();
            order.OrderAddress();
            order.OrderTshirt();

            var orderhistory = new OrderHistory(driver);
            orderhistory.ValidateOrderHistory();
            driver.Close();

        }

    }
}
