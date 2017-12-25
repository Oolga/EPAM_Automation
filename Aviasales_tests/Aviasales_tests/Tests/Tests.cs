using Aviasales_tests.Drivers;
using Aviasales_tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightRoundtripTwoAdults("Вильнюс", "Амстердам", new DateTime(2018, 4, 28), new DateTime(2018, 5, 1), 2);
            Assert.True(steps.HasTicketsList(true));
        }

        [Fact]
        public void FindFlightWithSameOriginAndDestinationPointThrowException()
        {
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightWithSameOriginAndDestinationPointThrowException("Вильнюс", "Вильнюс", new DateTime(2018, 4, 28), new DateTime(2018, 5, 1), 2);
            Assert.True(steps.HasErrorMessage());
        }

        [Fact]
        public void FindFlightOneAdult()
        {
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightOneAdult("Вильнюс", "Амстердам", new DateTime(2018, 4, 28), 1);
            Assert.True(steps.HasTicketsList(true));
        }

        [Fact]
        public void FindFlightRoundtripWithChildrenUnder12()
        {
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightRoundtripWithChildrenUnder12("Вильнюс", "Амстердам", new DateTime(2018, 4, 28), new DateTime(2018, 5, 1), 1, 1);
            Assert.True(steps.HasTicketsList(true));
        }

        [Fact]
        public void FindFlightRoundtripWithChildernUnder2()
        {
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightRoundtripWithChildernUnder2("Вильнюс", "Амстердам", new DateTime(2018, 4, 28), new DateTime(2018, 5, 1), 1, 1);
            Assert.True(steps.HasTicketsList(true));
        }

        [Fact]
        public void FindFlightRoundtripAdultsBusinessClass()
        {
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightRoundtripAdultsBusinessClass("Вильнюс", "Амстердам", new DateTime(2018, 4, 28), new DateTime(2018, 5, 1), 1);
            Assert.True(steps.HasTicketsList(true));
        }

        [Fact]
        public void FindFlightRoundtripAdultsFilter()
        {
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightRoundtripAdultsFilter();
            Assert.True(steps.HasTicketsList(false));
        }

        [Fact]
        public void FindFlightRoundtripAdultsFilterBagage()
        {
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightRoundtripAdultsFilterBagage();
            Assert.True(steps.HasTicketsList(false));
        }

        [Fact]
        public void FindFlightRoundtripAdultsFilterAirline()
        {
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightRoundtripAdultsFilterAirline();
            Assert.True(steps.HasTicketsList(false));
        }

        [Fact]
<<<<<<< HEAD
        public void FindFlightRoundtripAdultsMultiWay()
        {
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightRoundtripAdultsMultiWay(new string[] { "Вильнюс", "Берлин", "Амстердам" }, new string[] { "Берлин", "Амстердам", "Вильнюс" }, new DateTime[] { new DateTime(2018, 4, 28), new DateTime(2018, 4, 29), new DateTime(2018, 5, 1) });
            Assert.True(steps.HasTicketsList(false));
=======
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
>>>>>>> 5d1045e1627ebbe909b59f18a9b453c870adff13
        }
    }
}
