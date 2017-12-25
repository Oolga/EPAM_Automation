using Aviasales_tests.Drivers;
using Aviasales_tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviasales_tests.Steps
{
    public class Steps
    {
        IWebDriver driver;
        MainPage page;
        ResultPage resultPage;

        public void InitBrowser()
        {
            driver = DriverInstance.GetInstance();
            page = new MainPage(driver);
            resultPage = new ResultPage(driver);
        }

        public void FindFlightRoundtripTwoAdults(string origin, string destination, DateTime departDate, DateTime returnDate, int countOfAdults)
        {
            page.OpenPage();
            page.FindFlightRoundtripAdultsOnly( origin,  destination,  departDate,  returnDate, countOfAdults);
        }

        public bool HasTicketsList(bool isMainPage)
        {
            foreach (var windowHandle in driver.WindowHandles)
            {
                if(isMainPage)
                {
                    if (windowHandle != driver.CurrentWindowHandle)
                    {
                        driver.SwitchTo().Window(windowHandle);
                        IWebElement dynamicElement = (new WebDriverWait(driver, TimeSpan.Parse("60"))).Until(ExpectedConditions.ElementExists(page.GetTicketsListContainer()));
                        return page.GetTicketsListElement(dynamicElement).Count() > 0;
                    }
                }
                if (!isMainPage)
                {
                    IWebElement dynamicElement = (new WebDriverWait(driver, TimeSpan.Parse("60"))).Until(ExpectedConditions.ElementExists(page.GetTicketsListContainer()));
                    return page.GetTicketsListElement(dynamicElement).Count() > 0;
                }

            }
            return false;
        }

        public bool HasErrorMessage()
        {
            return page.HasErrorMessage();
        }

        public void FindFlightWithSameOriginAndDestinationPointThrowException(string origin, string destination, DateTime departDate, DateTime returnDate, int countOfAdults)
        {
            page.OpenPage();
            page.FindFlightRoundtripAdultsOnly(origin, destination, departDate, returnDate, countOfAdults);
        }

        public void FindFlightOneAdult(string origin, string destination, DateTime departDate, int countOfAdults)
        {
            page.OpenPage();
            page.FindFlightAdultsOnly(origin, destination, departDate, countOfAdults);
        }

        public void FindFlightRoundtripWithChildrenUnder12(string origin, string destination, DateTime departDate, DateTime returnDate, int countOfAdults, int countOfChildren)
        {
            page.OpenPage();
            page.FindFlightWithOneChildrenUnder12(origin, destination, departDate, returnDate, countOfAdults, countOfChildren);
        }

        public void FindFlightRoundtripWithChildernUnder2(string origin, string destination, DateTime departDate, DateTime returnDate, int countOfAdults, int countOfChildren)
        {
            page.OpenPage();
            page.FindFlightWithOneChildrenUnder2(origin, destination, departDate, returnDate, countOfAdults, countOfChildren);
        }

        public void FindFlightRoundtripAdultsBusinessClass(string origin, string destination, DateTime departDate, DateTime returnDate, int countOfAdults)
        {
            page.OpenPage();
            page.FindFlightRoundtripAdultsOnlyBusinessClass(origin, destination, departDate, returnDate, countOfAdults);
        }

        public void FindFlightRoundtripAdultsFilter()
        {
            resultPage.OpenPage();
            resultPage.FilterWithoutTransfers();
        }

        public void FindFlightRoundtripAdultsFilterBagage()
        {
            resultPage.OpenPage();
            resultPage.FilterBagage();
        }

        public void FindFlightRoundtripAdultsFilterAirline()
        {
            resultPage.OpenPage();
            resultPage.FilterAirline();
        }

        public void FindFlightRoundtripAdultsMultiWay(string[] origin, string[] destination, DateTime[] departDate)
        {
            page.OpenPage();
            page.FindFlightMultiWay(origin, destination, departDate);
        }

        public void CloseBrowser()
        {
            DriverInstance.CloseBrowser();
        }
    }
}
