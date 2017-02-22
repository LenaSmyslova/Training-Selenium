using System;
using NUnit.Framework;
using OpenQA.Selenium;
//using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace CSharp_example
{
    /// <summary>
    /// Exercise10: "Product" scenario for Selenium3 course
    /// </summary>
    [TestFixture]
    public class Exercise10Product
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
        public void Exercise10ProductTest()
        {
            //Open page
            driver.Url = "http://localhost/litecart/en/";
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("img[title='My Store']")));

            //Get and check Product data from main page
            IWebElement product = driver.FindElement(By.CssSelector("div#box-most-popular li.product:first-child"));
            priceStyleCheck(product, "test");
            //var productName = product.FindElement(By.CssSelector("div.name")).GetAttribute("textContent");
            //string productPriceRegular = string.Empty, productPriceSale = string.Empty, productPrice = string.Empty;
            //if (product.FindElements(By.CssSelector("div.sticker.sale")).Count != 0)
            //{
            //    productPriceRegular = product.FindElement(By.CssSelector("s.regular-price")).GetAttribute("textContent");
            //    productPriceSale = product.FindElement(By.CssSelector("strong.campaign-price")).GetAttribute("textContent");
            //}
            //else
            //{
            //    productPrice = product.FindElement(By.CssSelector("span.price")).GetAttribute("textContent");
            //}
            //product.Click();
            //wait.Until(ExpectedConditions.TitleContains("| Rubber Ducks | My Store"));

            ////Get and check Product data from Product Details page
            //IWebElement productDetails = driver.FindElement(By.CssSelector("div#box-product.box"));
            //Assert.AreEqual(productName, productDetails.FindElement(By.CssSelector("h1")).GetAttribute("textContent"));
            //if (productDetails.FindElements(By.CssSelector("div.sticker.sale")).Count != 0)
            //{
            //    Assert.AreEqual(productPriceRegular, productDetails.FindElement(By.CssSelector("s.regular-price")).GetAttribute("textContent"));
            //    Assert.AreEqual(productPriceSale, productDetails.FindElement(By.CssSelector("strong.campaign-price")).GetAttribute("textContent"));
            //}
            //else
            //{
            //    Assert.AreEqual(productPrice, productDetails.FindElement(By.CssSelector("span.price")).GetAttribute("textContent"));
            //}
        }

        public void priceStyleCheck(IWebElement product, string selector)
        {
            ICapabilities capabilities = ((RemoteWebDriver)driver).Capabilities;
            var browser = capabilities.BrowserName;
            //switch (browser)
            //{
            //    case "internet explorer":

            //        break;

            //    case "firefox":

            //        break;

            //    case "chrome":

            //        break;
            //}
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null; 
        }
    }
}
