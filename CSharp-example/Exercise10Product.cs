using System;
using NUnit.Framework;
using OpenQA.Selenium;
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
            var productName = product.FindElement(By.CssSelector("div.name")).GetAttribute("textContent");
            string productPriceRegular = string.Empty, productPriceSale = string.Empty, productPrice = string.Empty;
            if (product.FindElements(By.CssSelector("div.sticker.sale")).Count != 0)
            {
                productPriceRegular = product.FindElement(By.CssSelector("s.regular-price")).GetAttribute("textContent");
                productPriceSale = product.FindElement(By.CssSelector("strong.campaign-price")).GetAttribute("textContent");
                priceStyleCheck(product, "strong.campaign-price", "s.regular-price", false);
            }
            else
            {
                productPrice = product.FindElement(By.CssSelector("span.price")).GetAttribute("textContent");
            }
            product.Click();
            wait.Until(ExpectedConditions.TitleContains("| Rubber Ducks | My Store"));

            //Get and check Product data from Product Details page
            IWebElement productDetails = driver.FindElement(By.CssSelector("div#box-product.box"));
            Assert.AreEqual(productName, productDetails.FindElement(By.CssSelector("h1")).GetAttribute("textContent"));
            if (productDetails.FindElements(By.CssSelector("div.sticker.sale")).Count != 0)
            {
                Assert.AreEqual(productPriceRegular, productDetails.FindElement(By.CssSelector("s.regular-price")).GetAttribute("textContent"));
                Assert.AreEqual(productPriceSale, productDetails.FindElement(By.CssSelector("strong.campaign-price")).GetAttribute("textContent"));
                priceStyleCheck(productDetails, "strong.campaign-price", "s.regular-price", true);
            }
            else
            {
                Assert.AreEqual(productPrice, productDetails.FindElement(By.CssSelector("span.price")).GetAttribute("textContent"));
            }
        }

        public void priceStyleCheck(IWebElement selectedproduct, string selectorSale, string selectorRegular, bool isDetails)
        {
            ICapabilities capabilities = ((RemoteWebDriver)driver).Capabilities;
            var browser = capabilities.BrowserName;
            switch (browser)
            {
                case "internet explorer":
                    //Check style for regular price
                    Assert.AreEqual("rgb(119, 119, 119)", selectedproduct.FindElement(By.CssSelector(selectorRegular)).GetCssValue("color"));
                    Assert.AreEqual("line-through", selectedproduct.FindElement(By.CssSelector(selectorRegular)).GetCssValue("text-decoration"));
                    Assert.Less(selectedproduct.FindElement(By.CssSelector(selectorRegular)).GetCssValue("font-size"), selectedproduct.FindElement(By.CssSelector(selectorSale)).GetCssValue("font-size"));
                    //Check style for sale price
                    Assert.AreEqual("rgb(204, 0, 0)", selectedproduct.FindElement(By.CssSelector(selectorSale)).GetCssValue("color"));
                    Assert.AreEqual("900", selectedproduct.FindElement(By.CssSelector(selectorSale)).GetCssValue("font-weight"));
                    break;

                case "firefox":
                    //Check style for regular price
                    Assert.AreEqual("rgb(119, 119, 119)", selectedproduct.FindElement(By.CssSelector(selectorRegular)).GetCssValue("color"));
                    Assert.AreEqual("line-through", selectedproduct.FindElement(By.CssSelector(selectorRegular)).GetCssValue("text-decoration"));
                    Assert.Less(selectedproduct.FindElement(By.CssSelector(selectorRegular)).GetCssValue("font-size"), selectedproduct.FindElement(By.CssSelector(selectorSale)).GetCssValue("font-size"));
                    //Check style for sale price
                    Assert.AreEqual("rgb(204, 0, 0)", selectedproduct.FindElement(By.CssSelector(selectorSale)).GetCssValue("color"));
                    Assert.AreEqual("900", selectedproduct.FindElement(By.CssSelector(selectorSale)).GetCssValue("font-weight"));
                    break;

                case "chrome":
                    //Check style for regular price
                    if (isDetails == false)
                    {
                        Assert.AreEqual("rgba(119, 119, 119, 1)", selectedproduct.FindElement(By.CssSelector(selectorRegular)).GetCssValue("color"));
                    }
                    else
                    {
                        Assert.AreEqual("rgba(102, 102, 102, 1)", selectedproduct.FindElement(By.CssSelector(selectorRegular)).GetCssValue("color"));
                    }
                    Assert.AreEqual("line-through", selectedproduct.FindElement(By.CssSelector(selectorRegular)).GetCssValue("text-decoration"));
                    Assert.Less(selectedproduct.FindElement(By.CssSelector(selectorRegular)).GetCssValue("font-size"), selectedproduct.FindElement(By.CssSelector(selectorSale)).GetCssValue("font-size"));
                    //Check style for sale price
                    Assert.AreEqual("rgba(204, 0, 0, 1)", selectedproduct.FindElement(By.CssSelector(selectorSale)).GetCssValue("color"));
                    Assert.AreEqual("bold", selectedproduct.FindElement(By.CssSelector(selectorSale)).GetCssValue("font-weight"));
                    break;
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
