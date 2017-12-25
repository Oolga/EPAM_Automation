using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviasales_tests.Pages
{
    public class MainPage
    {
        private const string BASE_URL = "https://www.aviasales.ru";

        [FindsBy(How = How.XPath, Using = "//button[@class='of_main_form__submit']")]
        private IWebElement buttonFind;
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]/div/div[1]/div[2]/div/form/div[1]/div[3]/div[1]/div")]
        private IWebElement dropDownElement;

        [FindsBy(How = How.XPath, Using = "//input[@id='origin']")]
        private IWebElement originInput;
        [FindsBy(How = How.XPath, Using = "//input[@id='destination']")]
        private IWebElement destinationInput;
        [FindsBy(How = How.XPath, Using = "//input[@name='depart_date']")]
        private IWebElement departDateInput;
        [FindsBy(How = How.XPath, Using = "//input[@name='return_date']")]
        private IWebElement returnDateInput;
        [FindsBy(How = How.XPath, Using = "//div[@class='of_dropdown__over']")]
        private IWebElement ofDropdownValueButton;
        [FindsBy(How = How.XPath, Using = "//div[@class='of_additional__row'][0]/span[@class='of_numeric_input__value']")]
        private IWebElement setCountOfAdultsInput;
        [FindsBy(How = How.XPath, Using = "//div[@class='of_input_checkbox of_input_checkbox--dark of_additional__trip_class']")]
        private IWebElement tripClassSwitcherButton;

        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void ClickOnButtonFind()
        {
            buttonFind.Click();
        }

        public void FindFlightRoundtripAdultsOnly(string origin, string destination, DateTime departDate, DateTime returnDate, int countOfAdults)
        {
            originInput.SendKeys(origin);
            destinationInput.SendKeys(destination);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SetDepartDate(DateTime.Now, departDate);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SetDepartDate(departDate, returnDate);

            SetCountOfAdults(countOfAdults);

            buttonFind.Click();
        }

        public By GetTicketsListContainer()
        {
            return By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div[2]/div[2]/div/div[2]");
        }

        public IEnumerable<IWebElement> GetTicketsListElement(IWebElement dynamicElement)
        {
            return dynamicElement.FindElements(By.XPath("//div[@class='ticket product-list__ticket --openable']"));
        }

        public void FindFlightRoundtripAdultsOnlyBusinessClass(string origin, string destination, DateTime departDate, DateTime returnDate, int countOfAdults)
        {
            originInput.SendKeys(origin);
            destinationInput.SendKeys(destination);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SetDepartDate(DateTime.Now, departDate);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SetDepartDate(departDate, returnDate);


            SetCountOfAdults(countOfAdults);
            ofDropdownValueButton.Click();
            tripClassSwitcherButton.Click();

            ofDropdownValueButton.Click();

            buttonFind.Click();
        }

        public void FindFlightAdultsOnly(string origin, string destination, DateTime departDate, int countOfAdults)
        {
            originInput.SendKeys(origin);
            destinationInput.SendKeys(destination);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SetDepartDate(DateTime.Now, departDate);

            SetCountOfAdults(countOfAdults);

            buttonFind.Click();
        }

        public void FindFlightMultiWay(string[] origin, string[] destination, DateTime[] departDate)
        {
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/form/div[2]/a")).Click();
            for (int i = 0; i < origin.Count(); i++)
            {
                driver.FindElement(By.XPath("//input[@id='segments[" + i + "][origin]']")).SendKeys(origin[i]);
                driver.FindElement(By.XPath("//input[@id='segments[" + i + "][destination]']")).SendKeys(destination[i]);
                driver.FindElement(By.XPath("//input[@id='segments[" + i + "][depart_date]']")).Click();
                var before = i == 0 ? DateTime.Now : departDate[i - 1];
                SetDepartDate(before, departDate[i]);
                if (i != origin.Count() - 1)
                    driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/form/div[2]/a")).Click();
            }

            buttonFind.Click();
        }

        public void FindFlightWithOneChildrenUnder12(string origin, string destination, DateTime departDate, DateTime returnDate, int countOfAdults, int countOfChildren)
        {
            originInput.SendKeys(origin);
            destinationInput.SendKeys(destination);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SetDepartDate(DateTime.Now, departDate);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SetDepartDate(departDate, returnDate);

            SetCountOfAdults(countOfAdults);
            SetCountOfCheldrenUnder12(countOfChildren);

            buttonFind.Click();
        }

        public void FindFlightWithOneChildrenUnder2(string origin, string destination, DateTime departDate, DateTime returnDate, int countOfAdults, int countOfChildren)
        {
            originInput.SendKeys(origin);
            destinationInput.SendKeys(destination);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SetDepartDate(DateTime.Now, departDate);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SetDepartDate(departDate, returnDate);

            SetCountOfAdults(countOfAdults);
            SetCountOfCheldrenUnder2(countOfChildren);
            ofDropdownValueButton.Click();

            buttonFind.Click();
        }


        public bool HasErrorMessage()
        {
            return null != driver.FindElement(By.XPath("//div[@class='of_form_part--destination is_invalid of_form_part of_autocomplete']"));
        }

        private void SetDepartDate(DateTime before, DateTime date)
        {
            int count = before.Year < date.Year ? Math.Abs(12 - (before.Month + date.Month)) : date.Month - before.Month;
            SetDate(count, date);
        }

        private void SetDate(int count, DateTime date)
        {
            for (int i = 0; i < count; i++)
            {
                driver.FindElement(By.XPath("//button[@class='pika-next']")).Click();
            }

            driver.FindElement(By.XPath("//button[@data-pika-day='" + date.Day + "']")).Click();
        }

        private void SetCountOfAdults(int count)
        {

            for (int i = 1; i < count; i++)
            {
                ofDropdownValueButton.Click();
                driver.FindElements(By.XPath("//a[@class='of_numeric_input__inc']"))[0].Click();
            }
        }

        private void SetCountOfCheldrenUnder12(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ofDropdownValueButton.Click();
                driver.FindElements(By.XPath("//a[@class='of_numeric_input__inc']"))[1].Click();
            }
        }

        private void SetCountOfCheldrenUnder2(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ofDropdownValueButton.Click();
                driver.FindElements(By.XPath("//a[@class='of_numeric_input__inc']"))[2].Click();
            }
        }

    }
}
