using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Task11ForCourses.WizzAir_pages
{
	public class PassengerDetailsPage
	{
		private IWebDriver Driver;
		public PassengerDetailsPage(IWebDriver driver)
		{
			this.Driver = driver;
		}

		private IWebElement FirstName => Driver.FindElement(By.Id("passenger-first-name-0"));

		private IWebElement LastName => Driver.FindElement(By.Id("passenger-last-name-0"));

		private IWebElement GenderFemale => Driver.FindElement(By.XPath("(//span[@class='rf-switch__label__inner'])[1]"));

		private IWebElement GenderMale => Driver.FindElement(By.XPath("(//span[@class='rf-switch__label__inner'])[2]"));

		public IWebElement ConfirmPassengerSelectedButton => Driver.FindElement(By.Id("passengers-continue-btn"));

		public IWebElement PassengersName => Driver.FindElement(By.XPath("(//div[contains(@class, 'passenger-names')])[1]"));

		public IWebElement FlightRoute => Driver.FindElement(By.XPath("//span[@class='tab__title title title--2']"));

		public IWebElement CarryOnBaggageButton => Driver.FindElement(By.XPath("//label[@for='passenger-0-outbound-baggageType-switch-option-hand-luggage']"));

		public IWebElement ConfirmBaggageButton => Driver.FindElement(By.XPath("//*[@id='passenger-baggages-outbound-0']/div[2]/section/div[3]/span/label[1]"));
		//public IWebElement ConfirmBaggageButton => Driver.FindElement(By.XPath("//button[@data-test='baggage-recommendation-accept-button']"));
		//public IWebElement ConfirmBaggageButton => Driver.FindElement(By.XPath("//div[@class='swiper-items']/div[1]"));

		public IWebElement SignInDialog => Driver.FindElement(By.Name("login-form"));

		public PassengerDetailsPage EnteringFirstName(string firstName)
		{
			FirstName.Click();
			FirstName.SendKeys(firstName);
			return this;
		}

		public PassengerDetailsPage EnteringLastName(string lastName)
		{
			LastName.Click();
			LastName.SendKeys(lastName);
			return this;
		}

		public PassengerDetailsPage SelectGender(string gender)
		{
			if (gender == "Male")
			{
				GenderMale.Click();
			}
			if (gender == "Female")
			{
				GenderFemale.Click();
			}

			return this;
		}
	}
}
