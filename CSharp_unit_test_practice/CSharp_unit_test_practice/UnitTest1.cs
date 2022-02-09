using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharp_unit_test_practice
{
    [TestClass]
    public class TestcasePractice
    {
        ChromeDriver? driver;

        [TestInitialize]
        public void create_driver_object()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            // FirefoxDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://juice-shop.herokuapp.com/";
        }

        [TestMethod]
        public void LoginLogout()
        {            
            driver.FindElement(By.CssSelector(".close-dialog")).Click();
            driver.FindElement(By.CssSelector(".cc-btn")).Click();

            IList<IWebElement> cards = driver.FindElements(By.CssSelector("div > mat-card"));

            foreach (IWebElement product_card in cards)
            {
                product_card.Click();
                Thread.Sleep(5);
                product_card.FindElement(By.XPath("//button[@aria-label=\"Close Dialog\"]")).Click();
            }
            driver.Quit();
        }
    }
}