using OpenQA.Selenium;

namespace Class_library_practice_selenium
{
    public class TestCase_from_Class_Library
    {
        public bool Test_Navigation(IWebDriver driver)
        {
            driver.FindElement(By.Id("")).Click();
            Thread.Sleep(2000);
            if(driver.Url == "")
            {
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}