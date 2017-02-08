using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
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

            //Menu "Appearence"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=appearance&doc=template']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-logotype")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-template")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

            //Menu "Catalog"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=catalog&doc=catalog']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-product_groups")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-option_groups")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-manufacturers")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-suppliers")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-delivery_statuses")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-sold_out_statuses")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-quantity_units")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-csv")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-catalog")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

            //Menu "Countries"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=countries&doc=countries']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

            //Menu "Currencies"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=currencies&doc=currencies']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

            //Menu "Customers"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=customers&doc=customers']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-csv")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-newsletter")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-customers")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

            //Menu "Geo Zones"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=geo_zones&doc=geo_zones']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

            //Menu "Languages"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=languages&doc=languages']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-storage_encoding")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-languages")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

            //Menu "Modules"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=modules&doc=jobs']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-customer")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-shipping")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-payment")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-order_total")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-order_success")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-order_action")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-jobs")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

            //Menu "Orders"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=orders&doc=orders']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-order_statuses")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-orders")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

            //Menu "Pages"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=pages&doc=pages']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

            //Menu "Reports"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=reports&doc=monthly_sales']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-most_sold_products")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-most_shopping_customers")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-monthly_sales")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

            //Menu "Settings"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=settings&doc=store_info']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-defaults")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-general")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-listings")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-images")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-checkout")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-advanced")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-security")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-store_info")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

            //Menu "Slides"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=slides&doc=slides']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

            //Menu "Tax"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=tax&doc=tax_classes']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-tax_rates")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-tax_classes")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

            //Menu "Translations"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=translations&doc=search']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-scan")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-csv")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-search")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

            //Menu "Users"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=users&doc=users']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);

            //Menu "vQmods"
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#app->[href*='?app=vqmods&doc=vqmods']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
            driver.FindElement(By.CssSelector("ul#box-apps-menu li#doc-vqmods")).Click();
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div#body td#content h1")).Displayed);
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}