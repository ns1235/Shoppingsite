using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace OnlineShopping.PageObjects
{
    class Order
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[@title=\"Women\"]")]
        public IWebElement Womenbtn { get; set; }

        [FindsBy(How = How.LinkText, Using = "Tops")]
        public IWebElement Toplink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"categories_block_left\"]/div/ul/li[1]//a[contains(text(), \"T-shirts\")]")]
        public IWebElement Tshirtlink { get; set; }

        [FindsBy(How = How.XPath, Using= "//img[@title='Faded Short Sleeve T-shirts']")]
        public IWebElement ProductImg { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Add to cart')]")]
        public IWebElement Addtocart { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title=\"Proceed to checkout\"]")]
        public IWebElement Proceed { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"center_column\"]/p[2]/a[1]/span")]
        public IWebElement CartCheckout { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type=\"submit\"]/span[contains(text(), \"Proceed to checkout\")]")]
        public IWebElement CartCheckouttwo { get; set; }        

        [FindsBy(How = How.Id, Using = "cgv")]
        public IWebElement Terms { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title=\"Pay by bank wire\"]")]
        public IWebElement Paymentoption { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'I confirm my order')]")]
        public IWebElement Confirmbtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"center_column\"]/div/p/strong")]
        public IWebElement CartSummSuccessMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id=\"address_invoice\"]/li[@class=\"address_firstname address_lastname\"]")]
        public IWebElement AddName { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id=\"address_invoice\"]/li[@class=\"address_company\"]")]
        public IWebElement AddCompany { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id=\"address_invoice\"]/li[@class=\"address_address1 address_address2\"]")]
        public IWebElement Address { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id=\"address_invoice\"]/li[@class=\"address_city address_state_name address_postcode\"]")]
        public IWebElement AddCityState { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id=\"address_invoice\"]/li[@class=\"address_country_name\"]")]
        public IWebElement AddCounty { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id=\"address_invoice\"]/li[@class=\"address_phone_mobile\"]")]
        public IWebElement AddPhone { get; set; }

        [FindsBy(How = How.Id, Using = "total_product")]
        public IWebElement TotalProduct { get; set; }
        [FindsBy(How = How.Id, Using = "total_shipping")]
        public IWebElement TotalShipping { get; set; }
        [FindsBy(How = How.Id, Using = "total_tax")]
        public IWebElement Tax { get; set; }
        [FindsBy(How = How.Id, Using = "total_price")]
        public IWebElement Total { get; set; }


        public Order(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToTshirtLink()
        {
            Womenbtn.Click();
            Thread.Sleep(10000);
            Toplink.Click();
            Thread.Sleep(10000);
            Tshirtlink.Click();
        }

        public void AddtoCart()
        {

            Actions action = new Actions(driver);
            action.MoveToElement(ProductImg).Perform();
            Addtocart.Click();
            Thread.Sleep(10000);
            Proceed.Click();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", Proceed);

        }

        public void OrderSummary()
        {
            Assert.AreEqual(TotalProduct.Text, "$16.51");
            Assert.AreEqual(TotalShipping.Text, "$2.00");
            Assert.AreEqual(Tax.Text, "$0.74");
            Assert.AreEqual(Total.Text, "$19.25");
            CartCheckout.Click();
            Thread.Sleep(10000);
        }

        public void OrderAddress()
        {
            
            Assert.AreEqual(AddName.Text, "Test Test");
            Assert.AreEqual(AddCompany.Text, "Company");
            Assert.AreEqual(Address.Text, "Address");
            Assert.AreEqual(AddCityState.Text, "City, Alabama 12345");
            Assert.AreEqual(AddCounty.Text, "United States");
            Assert.AreEqual(AddPhone.Text, "1234567890");
            CartCheckouttwo.Click();
            Thread.Sleep(10000);
        }
        public void OrderTshirt()
        {
            
            Terms.Click();
            CartCheckouttwo.Click();
            Thread.Sleep(10000);
            Paymentoption.Click();
            Confirmbtn.Click();
            Thread.Sleep(10000);            
            Assert.AreEqual(CartSummSuccessMsg.Text.ToString(),"Your order on My Store is complete.");
        }
    }
}
