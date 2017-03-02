using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_example
{
    /// <summary>
    /// Exercise14: "New Window" scenario for Selenium3 course
    /// </summary>
    [TestFixture]
    public class Exercise14NewWindow
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
        public void Exercise14NewWindowTest()
        {
            //Login
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("img[title='My Store']")));

            //Navigate to Add Country page
            driver.FindElement(By.CssSelector("a.button")).Click();

            IList <IWebElement> links = driver.FindElements(By.CssSelector("i.fa-external-link"));
            string originalWindow = driver.CurrentWindowHandle;
            string newWindow = string.Empty;
            IList <string> oldWindows = driver.WindowHandles;
            int numberOfWindows = oldWindows.Count;

            foreach (IWebElement link in links)
            {
                link.Click();
                wait.Until(driver => driver.WindowHandles.Count() == (numberOfWindows + 1));
                IList<string> currentWindows = driver.WindowHandles;
                IList<string> differentWindows = currentWindows.Except(oldWindows).ToList();
                if (differentWindows.Count > 0)
                {
                    newWindow = differentWindows[0];
                }
                driver.SwitchTo().Window(newWindow);
                driver.Close();
                driver.SwitchTo().Window(originalWindow);
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
