using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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

            //Add product to basket
            driver.FindElement(By.CssSelector("div#box-most-popular li.product:first-child")).Click();

        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }