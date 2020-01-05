using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class CustomerService
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.katalon.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheCustomerServiceTest()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=contact");
            driver.FindElement(By.Id("id_contact")).Click();
            new SelectElement(driver.FindElement(By.Id("id_contact"))).SelectByText("Webmaster");
            driver.FindElement(By.Id("id_contact")).Click();
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("alexander.oliverpes@gmail.com");
            driver.FindElement(By.Id("id_order")).Click();
            driver.FindElement(By.Id("id_order")).Clear();
            driver.FindElement(By.Id("id_order")).SendKeys("oliver");
            driver.FindElement(By.Id("message")).Click();
            driver.FindElement(By.Id("message")).Click();
            driver.FindElement(By.Id("message")).Clear();
            driver.FindElement(By.Id("message")).SendKeys("hola");
            driver.FindElement(By.XPath("//button[@id='submitMessage']/span/i")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
