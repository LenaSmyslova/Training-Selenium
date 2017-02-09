using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

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
            driver = new InternetExplorerDriver();
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

            //Counting all parent menu items
            IList<IWebElement> parentCounts = driver.FindElements(By.CssSelector("li#app-"));
            foreach (IWebElement parentCount in parentCounts)
            {
                driver.FindElement(By.CssSelector("li#app-")).Click();
                Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

                //Counting all child menu items
                IList<IWebElement> childCounts = driver.FindElements(By.CssSelector("ul.docs li"));
                if (childCounts.Count > 0)
                {
                    foreach (IWebElement childCount in childCounts)
                    {
                        driver.FindElement(By.CssSelector("ul.docs li")).Click();
                        Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
                    }
                }         
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