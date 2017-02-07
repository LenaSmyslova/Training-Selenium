using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace CSharp_example
{
    /// <summary>
    /// Exercise7: "Menu" scenario for Selenium3 course
    /// </summary>
    [TestFixture]
    public class Exercise7Menu
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Exercise7MenuTest()
        {
            //Login
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("img[title='My Store']")));

            //Menu "Appearence"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=appearance&doc=template']")).Click();
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(By.ClassName("td#content h1")), "Template"));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}