using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace CSharp_example
{
    /// <summary>
    /// Exercise8: "Stickers" scenario for Selenium3 course
    /// </summary>
    [TestFixture]
    public class Exercise8Stickers
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new InternetExplorerDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Exercise8StickersTest()
        {
            //Open page
            driver.Url = "http://localhost/litecart/";
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("img[title='My Store']")));

            //Counting all products
            IList<IWebElement> products = driver.FindElements(By.CssSelector("li.product"));

            //Counting stickers for each product
            foreach (IWebElement product in products)
            {
                var stickerCount = product.FindElements(By.CssSelector("div.sticker")).Count;
                Assert.AreEqual(stickerCount, 1);
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