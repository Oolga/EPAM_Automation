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

		private string incButtonPath = "//a[@class='of_numeric_input__inc']";

        [FindsBy(How = How.XPath, Using = "//button[@class='of_main_form__submit']")]
        private IWebElement buttonFind;
		[FindsBy(How = How.XPath, Using = "//button[@class='pika-next']")]
		private IWebElement nextMonthButton;
		[FindsBy(How = How.XPath, Using = "//input[@id='origin']")]
        private IWebElement originInput;
        [FindsBy(How = How.XPath, Using = "//input[@id='destination']")]
        private IWebElement destinationInput;
        [FindsBy(How = How.XPath, Using = "//div[@class='of_dropdown__over']")]
        private IWebElement ofDropdownValueButton;
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

        public void FindFlightRoundtripAdultsOnly(string origin, string destination, DateTime departDate, DateTime returnDate, int countOfAdults) {
            originInput.SendKeys(origin);
            destinationInput.SendKeys(destination);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SetDepartDate(DateTime.Now, departDate);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SetReturnDate(departDate, returnDate);


            SetCountOfAdults(countOfAdults);


            buttonFind.Click();
        }

        public void FindFlightRoundtripAdultsOnlyBusinessClass(string origin, string destination, DateTime departDate, DateTime returnDate, int countOfAdults)
        {
            originInput.SendKeys(origin);
            destinationInput.SendKeys(destination);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SetDepartDate(DateTime.Now, departDate);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SetReturnDate(departDate, returnDate);


            SetCountOfAdults(countOfAdults);
            ofDropdownValueButton.Click();
            tripClassSwitcherButton.Click();

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


        public void FindFlightWithOneChildrenUnder12(string origin, string destination, DateTime departDate, DateTime returnDate, int countOfAdults, int countOfChildren)
        {
            originInput.SendKeys(origin);
            destinationInput.SendKeys(destination);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SetDepartDate(DateTime.Now, departDate);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SetReturnDate(departDate, returnDate);

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
            SetReturnDate(departDate, returnDate);

            SetCountOfAdults(countOfAdults);
            SetCountOfCheldrenUnder2(countOfChildren);

            buttonFind.Click();
        }

        private void SetDepartDate(DateTime before, DateTime date)
        {
            int count = 12 - before.Month + date.Month;
            SetDate(count, date);
        }

        private void SetReturnDate(DateTime before, DateTime date)
        {
            int count = date.Month- before.Month;
            SetDate(count, date);
        }

        private void SetDate(int count, DateTime date)
        {


            for (int i = 0; i < count; i++) {
				nextMonthButton.Click();
            }

            driver.FindElement(By.XPath("//button[@data-pika-day='" + date.Day + "']")).Click();
        }

        private void SetCountOfAdults(int count) {

            for (int i = 1; i < count; i++)
            {
                ofDropdownValueButton.Click();
                driver.FindElements(By.XPath(incButtonPath))[0].Click();
            }
        }

        private void SetCountOfCheldrenUnder12(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ofDropdownValueButton.Click();
                driver.FindElements(By.XPath(incButtonPath))[1].Click();
            }
        }

        private void SetCountOfCheldrenUnder2(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ofDropdownValueButton.Click();
                driver.FindElements(By.XPath(incButtonPath))[2].Click();
            }
        }

    }
}
