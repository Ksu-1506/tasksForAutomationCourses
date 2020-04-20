using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task11ForCourses
{
	[TestFixture]
	public class GismeteoTests
	{
		private static string igWorkDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); 

		private static IWebDriver driver;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddArguments("--ignore-certificate-errors");
			options.AddArguments("--ignore-ssl-errors");
			driver = new ChromeDriver(igWorkDir, options);
			driver.Navigate().GoToUrl("https://www.gismeteo.ua/");
			driver.Manage().Window.Maximize();
		}

		[Test]
		public void FindAllDivs()
		{
			IReadOnlyList<IWebElement> divElement = driver.FindElements(By.XPath("//div"));
			IReadOnlyList<IWebElement> divElementCSS = driver.FindElements(By.CssSelector("div"));
			var count = divElement.Count;
			var count2 = divElementCSS.Count;
			Assert.AreEqual(count, count2, $"Count found elements by XPath {count} and by CSS {count2} are equals");
		}

		[Test]
		public void FindAllH1Divs()
		{
			IReadOnlyList<IWebElement> divH1Element = driver.FindElements(By.XPath("//div//h1"));
			IReadOnlyList<IWebElement> divH1ElementCss = driver.FindElements(By.CssSelector("div h1"));
			var count = divH1Element.Count;
			var count2 = divH1ElementCss.Count;
			Assert.AreEqual(count, count2, $"Count found elements by XPath {count} and by CSS {count2} are equals");
		}

		[Test]
		public void FindAllH2Divs()
		{
			IReadOnlyList<IWebElement> divH2Element = driver.FindElements(By.XPath("//div//h2"));
			IReadOnlyList<IWebElement> divH2ElementCss = driver.FindElements(By.CssSelector("div h2"));
			var count = divH2Element.Count;
			var count2 = divH2ElementCss.Count;
			Assert.AreEqual(count, count2, $"Count found elements by XPath {count} and by CSS {count2} are equals");
		}

		[Test]
		public void FindNews()
		{
			IReadOnlyList<IWebElement> news = driver.FindElements(By.XPath("//div[@class ='readmore_list']"));
			IReadOnlyList<IWebElement> newsCss = driver.FindElements(By.CssSelector(".readmore_item"));
			Assert.AreEqual(news, newsCss, $"Elements are equals");
		}

		[Test]
		public void FindLastSpan()
		{
			IReadOnlyList<IWebElement> lastSpanCss =
							driver.FindElements(By.CssSelector(".readmore_item:nth-last-of-type(1)"));
			Assert.IsNotNull(lastSpanCss, $"Element is displayed");
		}

		[Test]
		public void FindNewsText()
		{
			IReadOnlyList<IWebElement> newsText =
				driver.FindElements(By.XPath("//div[contains(@class,'readmore_title')]"));

			IReadOnlyList<IWebElement> newsTextCss =
				driver.FindElements(By.CssSelector(".readmore_title"));

			var count1 = newsText.Count();
			var count2 = newsText.Count();
			Assert.AreEqual(count1, count2, $"Count of elements are equals");

			foreach (IWebElement element in newsText)
			{
				string text = element.Text;
			}
			foreach (IWebElement elementCss in newsTextCss)
			{
				string textCss = elementCss.Text;
			}
		}

		[Test]
		public void FindKiev()
		{
			IWebElement textKiev = driver.FindElement(By.XPath("//*[text()='Киев']"));
			Assert.IsNotNull(textKiev, "Element is displayed");
		}

		[Test]
		public void FindCityAfterKiev()
		{
			IWebElement cityAfterKiev =
				driver.FindElement(
					By.XPath("//*[text()='Киев']/ancestor-or-self::div/following-sibling::div[1]//span"));
			Assert.IsNotNull(cityAfterKiev, "Element is displayed");
		}

		[Test]
		public void FindLinks()
		{
			IReadOnlyList<IWebElement> links = driver.FindElements(By.XPath("//header//a[@href]"));
			Assert.IsNotNull(links, "Elements are displayed");
		}

		[Test]
		public void FindThreeDays()
		{
			IReadOnlyList<IWebElement> threeDays = driver.FindElements(By.XPath("//a[contains(@href, '3-days')]"));
			IReadOnlyList<IWebElement> threeDaysCSS = driver.FindElements(By.CssSelector(@"a[href*=""3-days""]"));
			Assert.AreEqual(threeDays, threeDaysCSS, $"Elements are equals");
		}

		[Test]
		public void FindCurrentDay()
		{
			IWebElement currentDay = driver.FindElement(By.XPath("//div[@class='weather_now']"));
			IWebElement currentDayCSS = driver.FindElement(By.CssSelector(".weather_now"));
			Assert.AreEqual(currentDay, currentDayCSS, $"Elements are equals");
		}

		[Test]
		public void FindCloudy()
		{
			if (driver.FindElement(By.CssSelector(".description")).Text == "Малооблачно")
			{
				string cloudyTemperature = driver.FindElement(By.CssSelector(".js_meas_container[data-value]")).Text;
				Assert.IsNotNull(cloudyTemperature, "Element is displayed");
			}
		}

		[Test]
		public void FindCurrentCloudy()
		{
			IWebElement currentCloudy = driver.FindElement(By.XPath("//div[contains(@class, 'description')]"));
			string info = currentCloudy.Text;
			if (info == "Малооблачно")
			{
				IWebElement currentTemperature = driver.FindElement(By.XPath("//div[@class='weather_frame_now']//div[contains(@class, 'temperature')]//span[contains(@class, 'unit_temperature_c')]"));
				string temperature = currentTemperature.Text;
				Assert.IsNotNull(temperature, "Temperature is displayed");
			}
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			driver.Quit();
		}
	}

}

