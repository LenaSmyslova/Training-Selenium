using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

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
            driver = new InternetExplorerDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }


        [Test]
        public void Exercise10ProductTest()
        {
            //Open page
            driver.Url = "http://localhost/litecart/en/";
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("img[title='My Store']")));

            //Get Product data from main page
            IWebElement product = driver.FindElement(By.CssSelector("div#box-campaigns li.product:nth-of-type(1)"));

        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
