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
    /// Exercise9.2: "Sorting" for zones scenario for Selenium3 course
    /// </summary>
    [TestFixture]
    public class Exercise9Sorting2
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
            List<String> itemActual = new List<String>();

            //Get text for all listed items
            for (int i = 0; i < item.Count; i++)
            {
                SelectElement selectedValue = new SelectElement(item[i]);
                itemActual.Add(selectedValue.SelectedOption.Text);
            }

            //Sort all listed items
            List<String> itemSorted = new List<String>();
            itemSorted.AddRange(itemActual);
            itemSorted.OrderBy(a => a);

            //Check initial sorting
            Assert.IsTrue(itemSorted.SequenceEqual(itemActual));
        }

        [Test]
        public void Exercise9Sorting2Test()
        {
            //Login
            driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("img[title='My Store']")));

            //Get all listed countries
            IList<IWebElement> countries = driver.FindElements(By.CssSelector("table.dataTable tr.row td:nth-of-type(3)"));

            //Check sorting for all zones
            for (int i = 2; i <= (countries.Count + 1); i++)
            {
                var cssSelectorToClickCounrty = "tr.row:nth-of-type(" + i + ") td:nth-of-type(3) a";
                driver.FindElement(By.CssSelector(cssSelectorToClickCounrty)).Click();
                wait.Until(ExpectedConditions.TitleIs("Edit Geo Zone | My Store"));
                IList<IWebElement> zones = driver.FindElements(By.CssSelector("table#table-zones td:nth-of-type(3) select"));
                sortingCheck(zones);
                driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
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
