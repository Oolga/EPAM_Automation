using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviasales_tests.Pages
{

    public class ResultPage
    {
        private const string BASE_URL = "https://search.aviasales.ru/VNO2804AMS30041";

        private IWebDriver driver;

        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void FilterWithoutTransfers() {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.FindElements(By.XPath("//div[@class='checkboxes-list__item']"))[0].Click();
            driver.FindElements(By.XPath("//div[@class='checkboxes-list__item']"))[1].Click();
        }

        public void FilterBagage() {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.FindElement(By.XPath("//div[@class='filters__item filter --baggage']")).Click();
            driver.FindElements(By.XPath("//div[@class='filters__item filter --baggage is-opened']/div[@class='filter__content']/div[@class='filter__controls checkboxes-list']/div[@class='checkboxes-list__item']"))[0].Click();
            driver.FindElements(By.XPath("//div[@class='checkboxes-list__list --overflow-hidden']/div[@class='checkboxes-list__item']"))[0].Click();
        }

        public void FilterAirline()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div[2]/div[1]/div[2]/div[6]")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div[2]/div[1]/div[2]/div[6]/div/div[3]/div[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div[2]/div[1]/div[2]/div[6]/div/div[3]/div[2]/div[24]")).Click();
        }
    }
}
