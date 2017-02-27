using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace CSharp_example
{
    /// <summary>
    /// Exercise12: "Add Product" scenario for Selenium3 course
    /// </summary>
    [TestFixture]
    public class Exercise12AddProduct
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
        public void Exercise12AddProductTest()
        {
            //Login
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("img[title='My Store']")));

            //Navigate to "Add Product" page
            driver.Url = "http://localhost/litecart/admin/?app=catalog&doc=catalog";
            int buttonCounts = driver.FindElements(By.CssSelector("a.button")).Count;
            for (int i = 1; i <= buttonCounts; i++)
            {
                var cssSelectorToFindButton = "a.button:nth-of-type(" + i + ")";
                var button = driver.FindElement(By.CssSelector(cssSelectorToFindButton));
                if (button.GetAttribute("textContent")== " Add New Product")
                {
                    button.Click();
                }
            }
            wait.Until(ExpectedConditions.TitleContains("Add New Product | My Store"));

            //Add new Product
            //Fill General tab
            var name = GenerateTestDataHelper.GenerateName();
            var code = GenerateTestDataHelper.GenerateCode();
            IWebElement general = driver.FindElement(By.CssSelector("div.content"));
            general.FindElement(By.CssSelector("input[name=status][value='1']")).Click();
            general.FindElement(By.Name("name[en]")).SendKeys(name);
            general.FindElement(By.Name("code")).SendKeys(code);
            general.FindElement(By.CssSelector("div.input-wrapper input[value='1']")).Click();
            SelectElement selectorDefaultCategory = new SelectElement(general.FindElement(By.Name("default_category_id")));
            selectorDefaultCategory.SelectByText("Rubber Ducks");
            general.FindElement(By.CssSelector("div.input-wrapper input[value='1-3']")).Click();
            general.FindElement(By.Name("quantity")).Clear();
            general.FindElement(By.Name("quantity")).SendKeys("15");
            general.FindElement(By.Name("new_images[]")).SendKeys("duck.jpg");
            general.FindElement(By.Name("date_valid_from")).SendKeys(Keys.Home + "2017-02-15");
            general.FindElement(By.Name("date_valid_to")).SendKeys(Keys.Home + "2018-02-15");
            driver.FindElement(By.CssSelector("div.tabs li a[href='#tab-information']")).Click();
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("div#tab-information")));

            //Fill Information tab
            IWebElement information = driver.FindElement(By.CssSelector("div.content"));
            SelectElement selectorManufacturer = new SelectElement(information.FindElement(By.Name("manufacturer_id")));
            selectorManufacturer.SelectByText("ACME Corp.");
            information.FindElement(By.Name("keywords")).SendKeys("new duck");
            information.FindElement(By.Name("short_description[en]")).SendKeys("test short description");
            information.FindElement(By.CssSelector("div.trumbowyg-editor")).SendKeys("test description");
            information.FindElement(By.Name("head_title[en]")).SendKeys("test head title");
            information.FindElement(By.Name("meta_description[en]")).SendKeys("test meta description");
            driver.FindElement(By.CssSelector("div.tabs li a[href='#tab-prices']")).Click();
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("div#tab-prices")));

            //Fill Price tab
            IWebElement price = driver.FindElement(By.CssSelector("div.content"));
            price.FindElement(By.Name("purchase_price")).Clear();
            price.FindElement(By.Name("purchase_price")).SendKeys("25");
            SelectElement selectorPurchasePrice = new SelectElement(price.FindElement(By.Name("purchase_price_currency_code")));
            selectorPurchasePrice.SelectByValue("USD");
            price.FindElement(By.Name("prices[USD]")).Clear();
            price.FindElement(By.Name("prices[USD]")).SendKeys("35");
            price.FindElement(By.Name("gross_prices[USD]")).Clear();
            price.FindElement(By.Name("gross_prices[USD]")).SendKeys("5");
            driver.FindElement(By.Name("save")).Click();
            wait.Until(ExpectedConditions.TitleContains("Catalog | My Store"));

            //Check added product
            IList<IWebElement> products = driver.FindElements(By.CssSelector("tr.row td:nth-of-type(3) a"));
            var isExist = false;
            foreach (IWebElement product in products)
            {
                if(product.GetAttribute("textContent") == name)
                {
                    isExist = true;
                }
            }
            Assert.AreEqual(true, isExist);
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }

    public class GenerateTestDataHelper
    {
        private static Random random = new Random();

        public static string GenerateName()
        {
            return string.Format("New Duck {0}", random.Next(1, 99999));
        }

        public static string GenerateCode()
        {
            return string.Format("rd{0}", random.Next(1, 99999));
        }
    }
}
