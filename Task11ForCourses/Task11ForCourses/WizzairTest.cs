using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Task11ForCourses.WizzAir_pages;

namespace Task11ForCourses
{
	[TestFixture]
	public class WizzAirTest
	{
		private static string igWorkDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
		private static IWebDriver driver;
		private const string _departureStation = "Киев";
		private const string _arivalStation = "Копенгаген";
		private const string _passangerFirstName = "Anastasiia";
		private const string _passangerLastName = "Fedorova";
		private const string _passangerGender = "Female";

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddArguments("--ignore-certificate-errors");
			options.AddArguments("--ignore-ssl-errors");
			driver = new ChromeDriver(igWorkDir, options);
			driver.Navigate().GoToUrl("https://wizzair.com/ru-ru#/");
			new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementExists(By.Id("search-departure-station")));
			driver.Manage().Window.Maximize();
		}

		[Test]
		public void CreateTicketFromKievToCopenhagen()
		{
			MainSearchTicketsPage mainPageWizzAir = new MainSearchTicketsPage(driver);
			mainPageWizzAir.DepartureStation.Click();
			mainPageWizzAir.DepartureStation.SendKeys(_departureStation);
			new WebDriverWait(driver, TimeSpan.FromSeconds(10))
				.Until(ExpectedConditions.ElementExists(By.XPath("//strong[@class='locations-container__location__name']")));
			mainPageWizzAir.DepartureStation.SendKeys(Keys.Enter);
			string _depature = mainPageWizzAir.DepartureStationAfterEnter.Text.Substring(0, 13);
			string _depatureAirport = mainPageWizzAir.DepartureAirport.Text;

			mainPageWizzAir.ArrivalStation.Click();
			mainPageWizzAir.ArrivalStation.SendKeys(_arivalStation);
			mainPageWizzAir.ArrivalStation.SendKeys(Keys.Enter);
			new WebDriverWait(driver, TimeSpan.FromSeconds(5))
				.Until(ExpectedConditions.ElementExists(By.XPath("(//div[@class='rf-input--large rf-input'])[2]")));
			string _arrival = mainPageWizzAir.ArrivalStationAfterEnter.Text.Substring(0, 10);
			string _arrivalAirport = mainPageWizzAir.ArrivalAirport.Text;
			string airportsWithKeys = _depature + " (" +_depatureAirport + ") " + _arrival + " (" + _arrivalAirport + ")";
			string airports = _depature + " " + _arrival ;
			//new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(mainPageWizzAir.ConfirmDateButton));
			Thread.Sleep(16000);
			mainPageWizzAir.ConfirmOneWayButton.Click();
			string _flightDate = mainPageWizzAir.DepartureDate.Text;
			Assert.AreEqual("1 взрослый", mainPageWizzAir.SearchPassengerField.Text, "Search Passenger Field contains '1 взрослый'");
			mainPageWizzAir.SearchButton.Click();

			//ticket details
			driver.SwitchTo().Window(driver.WindowHandles.Last());
			TicketDetailsPage ticketDetailsPage = new TicketDetailsPage(driver);
			//new WebDriverWait(driver, TimeSpan.FromSeconds(50)).Until(ExpectedConditions.ElementToBeClickable(ticketDetailsPage.AllPricesButton));
			Thread.Sleep(50000);
			Assert.True(ticketDetailsPage.FlightPath.Displayed, "FlightPath is displayed");
			StringAssert.Contains(_flightDate,ticketDetailsPage.FlightDate.Text, "Flight date is equals to expected");
			StringAssert.Contains(_depatureAirport, ticketDetailsPage.FlightPath.Text, "Depature airport international key is equals to expected");
			Assert.AreEqual(airportsWithKeys, ticketDetailsPage.FlightPath.Text, "Arrival airport international key is equals to expected");
			ticketDetailsPage.AllPricesButton.Click();
			Assert.AreEqual(3, ticketDetailsPage.PricesCategory.Count, "Count of different prices is equals to 3");
			foreach (IWebElement price in ticketDetailsPage.AllPrices)
			{
				string flightPrice = price.Text;
				Assert.NotNull(flightPrice, "Price is present");
			}
			
			Assert.True(ticketDetailsPage.SelectBaseTarif.Displayed, "SelectBaseTarif button is displayed");
			var element = driver.FindElement(By.XPath("(//div[@data-test='fare-type-button'])[5]"));
			Actions actions = new Actions(driver);
			actions.MoveToElement(element);
			actions.Perform();
			ticketDetailsPage.SelectBaseTarif.Click();
			new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(ticketDetailsPage.FlightSelectButton));
			ticketDetailsPage.FlightSelectButton.Click();

			
			//passenger details
			PassengerDetailsPage passengerDetailsPage = new PassengerDetailsPage(driver);
			//new WebDriverWait(driver, TimeSpan.FromSeconds(70)).Until(ExpectedConditions.ElementToBeClickable(By.Id("passenger-first-name-0")));
			passengerDetailsPage.EnteringFirstName(_passangerFirstName);
			passengerDetailsPage.EnteringLastName(_passangerLastName);
			passengerDetailsPage.SelectGender(_passangerGender);
			string fullPassengersName = _passangerFirstName + ' ' + _passangerLastName;
			Assert.AreEqual(fullPassengersName,passengerDetailsPage.PassengersName.Text, "Passengers Name is equals to expected");
			StringAssert.AreEqualIgnoringCase(airports, passengerDetailsPage.FlightRoute.Text, "Flight route is equals to expected");
			passengerDetailsPage.ConfirmBaggageButton.Click();
			new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(passengerDetailsPage.CarryOnBaggageButton));
			passengerDetailsPage.CarryOnBaggageButton.Click();
			new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(passengerDetailsPage.ConfirmPassengerSelectedButton));
			passengerDetailsPage.ConfirmPassengerSelectedButton.Click();
			Assert.True(passengerDetailsPage.SignInDialog.Displayed, "Sign In Dialog is appeared on page");
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			driver.Quit();
		}
	}

}

