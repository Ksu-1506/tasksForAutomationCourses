using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Task11ForCourses.WizzAir_pages
{
	public class TicketDetailsPage
	{
		//protected readonly IWebDriver Driver;
		public TicketDetailsPage(IWebDriver driver)
		{
			//this.Driver = driver;
			PageFactory.InitElements(driver, this);
		}

		//both airports
		[FindsBy(How = How.XPath, Using = "//address[@data-test='flight-select-flight-title-address']")]
		public IWebElement FlightPath;

		//date of flight
		[FindsBy(How = How.XPath, Using = "//time[@data-test='flight-select-flight-info-details-time']")]
		public IWebElement FlightDate;

		[FindsBy(How = How.XPath, Using = "(//div[@data-test='fare-type-button-title'])[1]")]
		public IWebElement AllPricesButton;

		//variable of prices
		[FindsBy(How = How.XPath, Using = "//div[@data-test='flight-select-fare']")]
		//[FindsBy(How = How.XPath, Using = "//div[@data-test='flight-select-fare-header']")]
		public IReadOnlyList<IWebElement> PricesCategory;

		//3 prices
		[FindsBy(How = How.XPath, Using = "//div[@data-test='fare-type-button' and contains(@class, 'active')]//span")]
		public IReadOnlyList<IWebElement> AllPrices;

		//select min price
		[FindsBy(How = How.XPath, Using = "(//div[@class='fare-button__background'])[3]")]
		public IWebElement SelectBaseTarif;

		[FindsBy(How = How.Id, Using = "flight-select-continue-button")]
		public IWebElement FlightSelectButton;
	}
}
