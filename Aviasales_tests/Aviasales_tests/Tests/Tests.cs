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
        private const string depPoint = "Вильнюс";
        private const string returnPoint = "Амстердам";
        private static DateTime depDate = new DateTime(DateTime.Now.Year, 4, 28);
        private static DateTime returnDate = depDate.AddDays(4);

        [Fact]
        public void FindFlightRoundtripTwoAdults()
        {
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightRoundtripTwoAdults(depPoint, returnPoint, depDate, returnDate, 2);
            Assert.True(steps.HasTicketsList(true));
        }

        [Fact]
        public void FindFlightWithSameOriginAndDestinationPointThrowException()
        {
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightWithSameOriginAndDestinationPointThrowException(depPoint, depPoint, depDate, returnDate, 2);
            Assert.True(steps.HasErrorMessage());
        }

        [Fact]
        public void FindFlightOneAdult()
        {
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightOneAdult(depPoint, returnPoint, depDate, 1);
            Assert.True(steps.HasTicketsList(true));
        }

        [Fact]
        public void FindFlightRoundtripWithChildrenUnder12()
        {
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightRoundtripWithChildrenUnder12(depPoint, returnPoint, depDate, returnDate, 1, 1);
            Assert.True(steps.HasTicketsList(true));
        }

        [Fact]
        public void FindFlightRoundtripWithChildernUnder2()
        {
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightRoundtripWithChildernUnder2(depPoint, returnPoint, depDate, returnDate, 1, 1);
            Assert.True(steps.HasTicketsList(true));
        }

        [Fact]
        public void FindFlightRoundtripAdultsBusinessClass()
        {
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightRoundtripAdultsBusinessClass(depPoint, returnPoint, depDate, returnDate, 1);
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
        public void FindFlightRoundtripAdultsMultiWay()
        {
            Aviasales_tests.Steps.Steps steps = new Steps.Steps();
            steps.InitBrowser();
            steps.FindFlightRoundtripAdultsMultiWay(new string[] { "Вильнюс", "Берлин", "Амстердам" }, new string[] { "Берлин", "Амстердам", "Вильнюс" }, new DateTime[] { new DateTime(2018, 4, 28), new DateTime(2018, 4, 29), new DateTime(2018, 5, 1) });
            Assert.True(steps.HasTicketsList(false));
        }
    }
}
