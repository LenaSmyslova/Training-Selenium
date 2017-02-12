using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_example
{
    /// <summary>
    /// Exercise9.1: "Sorting" for countries scenario for Selenium3 course
    /// </summary>
    [TestFixture]
    public class Exercise9Sorting1
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new InternetExplorerDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        //Check initial sorting
        public void sortingCheck(IList<IWebElement> item)
        {
            IList<String> itemActual = new List<String>();

            //Get text for all listed items
            for (int i = 0; i < item.Count; i++)
            {
                itemActual.Add(item[i].GetAttribute("textContent"));
            }

            //Sort all listed items
            IList<String> itemSorted = new List<String>();
            itemSorted = itemActual;
            itemSorted.OrderBy(a => a);

            //Check initial sorting
            Assert.IsTrue(itemSorted.SequenceEqual(itemActual));
        }

        [Test]
        public void Exercise9Sorting1Test()
        {
            //Login
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("img[title='My Store']")));

            //Check sorting for all listed countries
            IList<IWebElement> countries = driver.FindElements(By.CssSelector("tr.row td:nth-of-type(5)"));
            sortingCheck(countries);

            //Check sorting for countries where zones <> 0
            for (int i = 1; i <= countries.Count; i++)
            {
                var cssSelectorToFindCounrty = "tr:nth-of-type(" + i + ") td:nth-of-type(6)";
                var cssSelectorToClickCounrty = "tr:nth-of-type(" + i + ") td:nth-of-type(5) a";
                if (driver.FindElement(By.CssSelector(cssSelectorToFindCounrty)).GetAttribute("textContent") != "0")
                {
                    driver.FindElement(By.CssSelector(cssSelectorToClickCounrty)).Click();
                    wait.Until(ExpectedConditions.TitleIs("Edit Country | My Store"));
                    IList<IWebElement> zones = driver.FindElements(By.CssSelector("table#table-zones td:nth-of-type(3)"));
                    sortingCheck(zones);
                    driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
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