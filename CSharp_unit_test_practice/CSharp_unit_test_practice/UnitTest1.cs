using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;
using Class_library_practice_selenium;
using System.Collections;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

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
            driver.FindElement(By.CssSelector(".close-dialog")).Click();
            driver.FindElement(By.CssSelector(".cc-btn")).Click();
        }

        [TestMethod]
        public void LoginLogout()
        {            
            IList<IWebElement> cards = new List<IWebElement>();
            cards = driver.FindElements(By.CssSelector("div > mat-card"));

            foreach (IWebElement product_card in cards)
            {
                try
                {
                    product_card.Click();
                    Thread.Sleep(500);
                    product_card.FindElement(By.XPath("//button[@aria-label=\"Close Dialog\"]")).Click();
                }
                catch
                {
                    Thread.Sleep(1);
                }
                
            }
        }

        [TestMethod]
        public void NavigationTest()
        {
            driver.FindElement(By.Id("navbarAccount")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("navbarLoginButton")).Click();
            Thread.Sleep(2000);
            TestCase_from_Class_Library test_navigation = new TestCase_from_Class_Library();
            bool nav_success = test_navigation.Test_Navigation(driver.Url);
            Console.WriteLine("Returned :" + nav_success);
        }

        [TestMethod]
        public void Test_Select_Element()
        {
            // Launch the URL
            driver.Url = "https://demoqa.com/select-menu";

            SelectElement oSelection = new SelectElement(driver.FindElement(By.Id("oldSelectMenu")));

            //  Select option 'Green' (Use selectByIndex)
            oSelection.SelectByText("Green");

            // Using sleep command so that changes can be notice
            Thread.Sleep(2000);

            // Select option 'White' now (Use selectByVisibleText)
            oSelection.SelectByIndex(6);
            Thread.Sleep(2000);

            // Print all the options for the selected drop down and select one option of your choice
            // Get the size of the Select element
            IList<IWebElement> oSize = oSelection.Options;

            int iListSize = oSize.Count;
            // Setting up the loop to print all the options
            for (int i = 0; i < iListSize; i++)
            {
                // Storing the value of the option	
                String sValue = oSelection.Options.ElementAt(i).Text;
                // Printing the stored value
                Console.WriteLine("Value of the Select item is : " + sValue);

                // Putting a check on each option that if any of the option is equal to 'Black" then select it 
                if (sValue.Equals("Black"))
                {
                    oSelection.SelectByIndex(i);
                    break;
                }
            }
        }

        [TestCleanup]
        public void clean_up()
        {
            driver.Quit();
        }
    }
}