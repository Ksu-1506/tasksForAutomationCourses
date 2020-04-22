using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Task11ForCourses.WizzAir_pages
{
	public class MainSearchTicketsPage
	{
		private IWebDriver Driver;
		public MainSearchTicketsPage(IWebDriver driver)
		{
			this.Driver = driver;
		}

		public IWebElement DepartureStation => Driver.FindElement(By.Id("search-departure-station"));

		public IWebElement DepartureStationAfterEnter => Driver.FindElement(By.XPath("(//div[@class='rf-input--large rf-input'])[1]"));

		public IWebElement DepartureAirport => Driver.FindElement(By.XPath("((//div[@class='rf-input--large rf-input'])[1]//span[@class])[1]"));

		public IWebElement ArrivalStation => Driver.FindElement(By.Id("search-arrival-station"));

		public IWebElement ArrivalStationAfterEnter => Driver.FindElement(By.XPath("(//div[@class='rf-input--large rf-input'])[2]"));

		public IWebElement ArrivalAirport => Driver.FindElement(By.XPath("((//div[@class='rf-input--large rf-input'])[2]//span[@class])[1]"));

		public IWebElement SearchButton => Driver.FindElement(By.XPath("//button[@data-test='flight-search-submit']"));

		public IWebElement SearchPassengerField => Driver.FindElement(By.Id("search-passenger"));

		public IWebElement ConfirmDateButton => Driver.FindElement(By.XPath("//button[@data-test='calendar-shrinkable-ok-button']"));

		public IWebElement ConfirmOneWayButton => Driver.FindElement(By.XPath("//button[@data-test='calendar-one-way-button']"));

		public IWebElement DepartureDate => Driver.FindElement(By.Id("search-departure-date"));

		public IWebElement FlightSearchButton => Driver.FindElement(By.XPath("//button[@data-test='flight-search-submit']"));
	}
}
