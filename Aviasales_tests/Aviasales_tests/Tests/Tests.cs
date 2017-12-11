using Aviasales_tests.Drivers;
using Aviasales_tests.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aviasales_tests.Tests
{
    public class Tests
    {
        [Fact]
        public void FindFlightRoundtripTwoAdults() {
            var driver = DriverInstance.GetInstance();
            MainPage page = new MainPage(driver);
            page.OpenPage();
            page.FindFlightRoundtripAdultsOnly("Вильнюс", "Амстердам", new DateTime(2018,4,28), new DateTime(2018, 5, 1), 2);
        }

        [Fact]
        public void FindFlightWithSameOriginAndDestinationPointThrowException()
        {
            var driver = DriverInstance.GetInstance();
            MainPage page = new MainPage(driver);
            page.OpenPage();
            page.FindFlightRoundtripAdultsOnly("Вильнюс", "Вильнюс", new DateTime(2018, 4, 28), new DateTime(2018, 5, 1), 2);
        }

        [Fact]
        public void FindFlightOneAdult()
        {
            var driver = DriverInstance.GetInstance();
            MainPage page = new MainPage(driver);
            page.OpenPage();
            page.FindFlightAdultsOnly("Вильнюс", "Амстердам", new DateTime(2018, 4, 28), 1);
        }

        [Fact]
        public void FindFlightRoundtripWithChildrenUnder12()
        {
            var driver = DriverInstance.GetInstance();
            MainPage page = new MainPage(driver);
            page.OpenPage();
            page.FindFlightWithOneChildrenUnder12("Вильнюс", "Амстердам", new DateTime(2018, 4, 28), new DateTime(2018, 5, 1), 1, 1);
        }

        [Fact]
        public void FindFlightRoundtripWithChildernUnder2()
        {
            var driver = DriverInstance.GetInstance();
            MainPage page = new MainPage(driver);
            page.OpenPage();
            page.FindFlightWithOneChildrenUnder2("Вильнюс", "Амстердам", new DateTime(2018, 4, 28), new DateTime(2018, 5, 1), 1, 1);
        }

        [Fact]
        public void FindFlightRoundtripAdultsBusinessClass()
        {
            var driver = DriverInstance.GetInstance();
            MainPage page = new MainPage(driver);
            page.OpenPage();
            page.FindFlightRoundtripAdultsOnlyBusinessClass("Вильнюс", "Амстердам", new DateTime(2018, 4, 28), new DateTime(2018, 5, 1), 1);

        }

        [Fact]
        public void FindFlightRoundtripAdultsFilter()
        {
            var driver = DriverInstance.GetInstance();
            ResultPage page = new ResultPage(driver);
            page.OpenPage();
            page.FilterWithoutTransfers();
        }

        [Fact]
        public void FindFlightRoundtripAdultsFilterBagage()
        {
            var driver = DriverInstance.GetInstance();
            ResultPage page = new ResultPage(driver);
            page.OpenPage();
            page.FilterBagage();
        }
    }
}
