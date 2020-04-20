using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
			Thread.Sleep(1000);
			driver.Manage().Window.Maximize();
		}

		[Test]
		public void CreateTicketFromKievToCopenhagen()
		{
			MainSearchTicketsPage mainPageWizzAir = new MainSearchTicketsPage(driver);
			TicketDetailsPage ticketDetailsPage = new TicketDetailsPage(driver);
			PassangerDetailsPage _passangerDetailsPage = new PassangerDetailsPage(driver);
			//Assert.IsNotNull(mainPageWizzAir.DepartureStation, "Elemen present");
			mainPageWizzAir.SearchDepatureStation(_departureStation);
			string _depatureAirport = mainPageWizzAir.DepartureAirport.Text;
			//mainPageWizzAir.DepartureStation.SendKeys("Киев"+ Keys.Enter);
			mainPageWizzAir.SearchArrivalStation(_arivalStation);
			string _arrivalAirport = mainPageWizzAir.ArrivalAirport.Text;
			string airports = _depatureAirport + _arrivalAirport;
			//mainPageWizzAir.ArrivalStation.SendKeys("Копенгаген"+ Keys.Enter);
			mainPageWizzAir.ConfirmOneWayButton.Click();
			string _flightDate = mainPageWizzAir.DepartureDate.Text;
			Assert.AreEqual("1 взрослый", mainPageWizzAir.SearchPassengerField.Text, "Search Passenger Field contains '1 взрослый'");
			mainPageWizzAir.SearchButton.Click();

			//ticket details
			StringAssert.Contains(_flightDate,ticketDetailsPage.FlightDate.Text, "Flight date is equals to expected");
			StringAssert.Contains(airports, ticketDetailsPage.FlightPath.Text, "Flight Path is equals to expected");
			ticketDetailsPage.AllPricesButton.Click();
			Assert.AreEqual(3, ticketDetailsPage.PricesCategory.Count, "Count of different prices is equals to 3");
			foreach (IWebElement price in ticketDetailsPage.AllPrices)
			{
				string flightPrice = price.Text;
				Assert.NotNull(flightPrice, "Price is present");
			}
			ticketDetailsPage.SelectBaseTarif.Click();
			ticketDetailsPage.FlightSelectButton.Click();

			//passenger details
			_passangerDetailsPage.EnteringFirstName(_passangerFirstName);
			_passangerDetailsPage.EnteringLastName(_passangerLastName);
			_passangerDetailsPage.SelectGender(_passangerGender);
			string fullPassangersName = _passangerFirstName + ' ' + _passangerLastName;
			Assert.AreEqual(fullPassangersName,_passangerDetailsPage.PassengersName.Text, "Passangers Name is equals to expected");
			StringAssert.Contains(airports,_passangerDetailsPage.FlightRoute.Text, "Flight route is equals to expected");
			_passangerDetailsPage.ConfirmBaggageButton.Click();
			_passangerDetailsPage.ConfirmPassengerSelectedButton.Click();
			Assert.True(_passangerDetailsPage.SignInDialog.Displayed, "Sign In Dialog is appeared on page");
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			driver.Quit();
		}
	}

}

