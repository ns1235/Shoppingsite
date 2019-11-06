using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OnlineShopping.PageObjects;

namespace OnlineShopping.PageObjects
{
    class OrderHistory
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[@title=\"View my customer account\"]")]
        public IWebElement MyAccountbtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), \"Order history and details\")]")]
        public IWebElement Orderhistorybtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@id=\"order-list\"]")]
        public IWebElement getAccountOrderListTable { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@id='order-list']/tbody/tr/td")]
        public IWebElement getAccountOrderListRef { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@id='order-list']/tbody/tr[1]/td[7]/a[1]")]
        public IWebElement Detailbtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='block-order-detail']/form[1]/div[@id='order-detail-content']/table[@class='table table-bordered']/tbody/tr[@class='item']/td[@class='bold']/label")]
        public IWebElement Product { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='order_qte_span editable']")]
        public IWebElement Productqty { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='order-detail-content']/table/tbody/tr[@class='item']/td[@class='price'][2]/label")]
        public IWebElement ProductTotalprice { get; set; }


        public OrderHistory(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ValidateOrderHistory()
        {
            MyAccountbtn.Click();
            Orderhistorybtn.Click();
            Assert.AreEqual(true,getAccountOrderListTable.Displayed);
            Thread.Sleep(2000);
            Detailbtn.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.AreEqual(Product.Text, "Faded Short Sleeve T-shirts - Color : Orange, Size : S");
            Assert.AreEqual(Productqty.Text, "1");
            Assert.AreEqual(ProductTotalprice.Text, "$16.51");
        }
    }
}
