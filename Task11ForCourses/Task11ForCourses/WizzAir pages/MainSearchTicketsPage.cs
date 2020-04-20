using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Task11ForCourses.WizzAir_pages
{
	public class MainSearchTicketsPage
	{
		//protected readonly IWebDriver Driver;
		public MainSearchTicketsPage(IWebDriver driver)
		{
			//this.Driver = driver; 
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.XPath, Using = "(//div[@class='rf-input--large rf-input'])[1]")]
		private IWebElement DepartureStation { get; set; }
		//search-departure-station
		//(//div[@class='rf-input--large rf-input'])[1]
		[FindsBy(How = How.XPath, Using = "((//div[@class='rf-input--large rf-input'])[1]//span[@class])[1]")]
		public IWebElement DepartureAirport;

		[FindsBy(How = How.XPath, Using = "(//div[@class='rf-input--large rf-input'])[2]")]
		private IWebElement ArrivalStation { get; set; }

		[FindsBy(How = How.XPath, Using = "((//div[@class='rf-input--large rf-input'])[2]//span[@class])[1]")]
		public IWebElement ArrivalAirport;
		//search-arrival-station
		//(//div[@class='rf-input--large rf-input'])[2]
		[FindsBy(How = How.XPath, Using = "//button[@data-test='flight-search-submit']")]
		public IWebElement SearchButton; 
					
		[FindsBy(How = How.Id, Using = "search-passenger")]
		public IWebElement SearchPassengerField; 
					
		[FindsBy(How = How.XPath, Using = "//button[@data-test='calendar-shrinkable-ok-button']")]
		public IWebElement ConfirmDateButton; 
					
		[FindsBy(How = How.XPath, Using = "//button[@data-test='calendar-one-way-button']")]
		public IWebElement ConfirmOneWayButton; 
					
		[FindsBy(How = How.Id, Using = "search-departure-date")]
		public IWebElement DepartureDate; 
					
		[FindsBy(How = How.XPath, Using = "//button[@data-test='flight-search-submit']")]
		public IWebElement FlightSearchButton;

		public MainSearchTicketsPage SearchDepatureStation(string departureStation)
		{
			DepartureStation.Click();
			ArrivalStation.SendKeys(departureStation + Keys.Enter);
			return this;
		}

		public MainSearchTicketsPage SearchArrivalStation(string departureStation)
		{
			ArrivalStation.Click();
			ArrivalStation.SendKeys(departureStation + Keys.Enter);
			return this;
		}
		//public const string 
	}
}
