using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Task11ForCourses.WizzAir_pages
{
	public class TicketDetailsPage
	{
		private IWebDriver Driver;
		public TicketDetailsPage(IWebDriver driver)
		{
			this.Driver = driver;
		}

		//both airports
		public IWebElement FlightPath => Driver.FindElement(By.XPath("//address[@data-test='flight-select-flight-title-address']"));

		//date of flight
		public IWebElement FlightDate => Driver.FindElement(By.XPath("//time[@data-test='flight-select-flight-info-details-time']"));

		public IWebElement AllPricesButton => Driver.FindElement(By.XPath("(//div[@data-test='fare-type-button'])[1]"));

		//public IWebElement AllPricesButton => Driver.FindElement(By.XPath("(//div[@data-test='fare-type-button-title'])[1]"));

		//variable of prices
		public IReadOnlyList<IWebElement> PricesCategory => Driver.FindElements(By.XPath("//div[@data-test='flight-select-fare']"));
		//public IReadOnlyList<IWebElement> PricesCategory => Driver.FindElements(By.XPath("//div[@data-test='flight-select-fare-header']"));

		//3 prices
		public IReadOnlyList<IWebElement> AllPrices => Driver.FindElements(By.XPath("//div[@data-test='fare-type-button' and contains(@class, 'active')]//span"));

		//select min price
		public IWebElement SelectBaseTarif => Driver.FindElement(By.XPath("(//div[@data-test='fare-type-button'])[5]"));

		public IWebElement FlightSelectButton => Driver.FindElement(By.Id("flight-select-continue-button"));
	}
}
