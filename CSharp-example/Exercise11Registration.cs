using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CSharp_example
{
    /// <summary>
    /// Exercise11: "Registration" scenario for Selenium3 course
    /// </summary>
    [TestFixture]
    public class Exercise11Registration
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
        public void Exercise11RegistrationTest()
        {
            //Open Registration page
            driver.Url = "http://localhost/litecart/en/";
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("img[title='My Store']")));
            driver.FindElement(By.CssSelector("form[name = login_form] a")).Click();
            wait.Until(ExpectedConditions.TitleContains("Create Account | My Store"));

            //Get "unique" email address
            string emailAddress = TestDataHelper.GenerateEmailAddress();

            //Register new user
            IWebElement registrationForm = driver.FindElement(By.Name("customer_form"));
            registrationForm.FindElement(By.Name("firstname")).SendKeys("First");
            registrationForm.FindElement(By.Name("lastname")).SendKeys("Last");
            registrationForm.FindElement(By.Name("address1")).SendKeys("111 Test");
            registrationForm.FindElement(By.Name("postcode")).SendKeys("12345");
            registrationForm.FindElement(By.Name("city")).SendKeys("Test City");
            SelectElement selectorCountry = new SelectElement(registrationForm.FindElement(By.Name("country_code")));
            selectorCountry.SelectByValue("US");
            SelectElement selectorState = new SelectElement(registrationForm.FindElement(By.CssSelector("select[name=zone_code]")));
            selectorState.SelectByValue("CA");
            registrationForm.FindElement(By.Name("email")).SendKeys(emailAddress);
            registrationForm.FindElement(By.Name("phone")).SendKeys(Keys.Home + "+1234567890");
            registrationForm.FindElement(By.Name("password")).SendKeys("asd123!!");
            registrationForm.FindElement(By.Name("confirmed_password")).SendKeys("asd123!!");
            registrationForm.FindElement(By.Name("create_account")).Click();
            wait.Until(ExpectedConditions.TitleContains("Online Store | My Store"));

            //Logout
            driver.FindElement(By.CssSelector("div#box-account li:last-child a")).Click();
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Name("login_form")));

            //Login
            IWebElement loginForm = driver.FindElement(By.Name("login_form"));
            loginForm.FindElement(By.Name("email")).SendKeys(emailAddress);
            loginForm.FindElement(By.Name("password")).SendKeys("asd123!!");
            loginForm.FindElement(By.Name("login")).Click();

            //Logout
            driver.FindElement(By.CssSelector("div#box-account li:last-child")).Click();
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }

    public class TestDataHelper
    {
        private static Random random = new Random();

        public static string GenerateEmailAddress()
        {
            return string.Format("test.user{0}@test.test", random.Next(1, 99999));
        }
    }
}
