using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace CSharp_example
{
    /// <summary>
    /// Exercise13: "Basket" scenario for Selenium3 course
    /// </summary>
    [TestFixture]
    public class Exercise13Basket
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Exercise13BasketTest()
        {
            //Open page
            driver.Url = "http://localhost/litecart/en/";
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("img[title='My Store']")));

            for(int i = 1; i < 4; i++)
            {
                //Add product to basket
                driver.FindElement(By.CssSelector("div#box-most-popular li.product:first-child")).Click();
                IWebElement productDetails = driver.FindElement(By.CssSelector("div.information"));
                IWebElement basket = driver.FindElement(By.CssSelector("span.quantity"));
                if (productDetails.FindElements(By.Name("options[Size]")).Count > 0)
                {
                    SelectElement selectorSize = new SelectElement(productDetails.FindElement(By.Name("options[Size]")));
                    selectorSize.SelectByValue("Small");
                }
                productDetails.FindElement(By.Name("quantity")).Clear();
                productDetails.FindElement(By.Name("quantity")).SendKeys("1");
                productDetails.FindElement(By.Name("add_cart_product")).Click();
                wait.Until(ExpectedConditions.TextToBePresentInElement(basket, i.ToString()));
                Assert.AreEqual(i.ToString(), driver.FindElement(By.CssSelector("span.quantity")).GetAttribute("textContent"));
                driver.Url = "http://localhost/litecart/en/";
            }

            //Navigate to basket
            driver.FindElement(By.CssSelector("div#cart a.link")).Click();

            //Delete products from basket
            int productCount = driver.FindElements(By.CssSelector("li.item")).Count;
            for(int j = (productCount-1); j > 0; j--)
            {
                IList <IWebElement> basketProducts = driver.FindElements(By.CssSelector("li.item"));
                basketProducts[0].FindElement(By.Name("remove_cart_item")).Click();
                IList<IWebElement> orderSummary = driver.FindElements(By.CssSelector("table.dataTable td.item"));
                wait.Until(ExpectedConditions.StalenessOf(orderSummary[0]));
            }  
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}