using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviasales_tests.Drivers
{
    public class DriverInstance
    {
        private static IWebDriver driver;

        private DriverInstance() { }

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(30);
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;

            foreach (var process in Process.GetProcessesByName("geckodriver"))
            {
                process.Kill();
            }
        }
    }
}
