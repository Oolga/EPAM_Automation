using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnit_WebDriver
{
    public class GithubTest
    {
        private string USERNAME = "testautomationuser";
        private string PASSWORD = "Time4Death!";
        private string URL = "https://github.com/";

        [Fact]
        public void LogIn()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(URL);

                var loginButton = driver.FindElementByXPath("//a[text() = 'Sign in']");
                loginButton.Click();

                var userNameField = driver.FindElementById("login_field");
                var userPasswordField = driver.FindElementById("password");

                userNameField.SendKeys(USERNAME);
                userPasswordField.SendKeys(PASSWORD);
            }
        }
    }
}
