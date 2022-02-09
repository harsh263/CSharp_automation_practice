using OpenQA.Selenium;

namespace Class_library_practice_selenium
{
    public class TestCase_from_Class_Library
    {
        public bool Test_Navigation(string url)
        {
            if(url == "http://juice-shop.herokuapp.com/#/login")
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