using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Task11ForCourses.WizzAir_pages
{
	public class PassangerDetailsPage
	{
		//protected readonly IWebDriver Driver;
		public PassangerDetailsPage(IWebDriver driver)
		{
			//this.Driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Id, Using = "passenger-first-name-0")]
		private IWebElement FirstName { get; set; }

		[FindsBy(How = How.Id, Using = "passenger-last-name-0")]
		private IWebElement LastName { get; set; }

		[FindsBy(How = How.XPath, Using = "(//span[@class='rf-switch__label__inner'])[1]")]
		private IWebElement GenderFemale { get; set; }

		[FindsBy(How = How.XPath, Using = "(//span[@class='rf-switch__label__inner'])[2]")]
		private IWebElement GenderMale { get; set; }

		[FindsBy(How = How.Id, Using = "passengers-continue-btn")]
		public IWebElement ConfirmPassengerSelectedButton;

		[FindsBy(How = How.XPath, Using = "(//div[contains(@class, 'passenger-names')])[1]")]
		public IWebElement PassengersName;

		[FindsBy(How = How.XPath, Using = "//span[@class='tab__title title title--2']")]
		public IWebElement FlightRoute;

		[FindsBy(How = How.XPath, Using = "//button[@data-test='baggage-recommendation-accept-button']")]
		public IWebElement ConfirmBaggageButton;

		[FindsBy(How = How.Name, Using = "login-form")]
		public IWebElement SignInDialog;

		public PassangerDetailsPage EnteringFirstName(string firstName)
		{
			FirstName.Click();
			FirstName.SendKeys(firstName);
			return this;
		}

		public PassangerDetailsPage EnteringLastName(string lastName)
		{
			LastName.Click();
			LastName.SendKeys(lastName);
			return this;
		}

		public PassangerDetailsPage SelectGender(string gender)
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
