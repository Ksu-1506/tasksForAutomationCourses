using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task11ForCourses
{
	[TestFixture]
	public class Test
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
		}

		[Test]
		public void FindLastSpan()
		{
			IReadOnlyList<IWebElement> lastSpan =
				driver.FindElements(By.XPath("//div[contains(@class,'readmore_title')]//span"));
		}

		[Test]
		public void FindNewsText()
		{
			IReadOnlyList<IWebElement> newsText =
				driver.FindElements(By.XPath("//div[contains(@class,'readmore_title')]"));

			IReadOnlyList<IWebElement> newsTextCss =
				driver.FindElements(By.CssSelector(".readmore_title")); 

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
		}

		[Test]
		public void FindCityAfterKiev()
		{
			IWebElement cityAfterKiev =
				driver.FindElement(
					By.XPath("//*[text()='Киев']/ancestor-or-self::div/following-sibling::div[1]//span"));
		}

		[Test]
		public void FindLinks()
		{
			IReadOnlyList<IWebElement> links = driver.FindElements(By.XPath("//header//a[@href]"));
		}

		[Test]
		public void FindThreeDays()
		{
			IReadOnlyList<IWebElement> threeDays = driver.FindElements(By.XPath("//a[contains(@href, '3-days')]"));
		}

		[Test]
		public void FindCurrentDay()
		{
			IWebElement currentDay = driver.FindElement(By.XPath("//div[@class='weather_now']"));
		}

		[Test]
		public void FindCloudy()
		{
			IWebElement cloudy = driver.FindElement(By.XPath(
				"//span[contains(@data-text, 'Малооблачно')]/ancestor-or-self::div/following-sibling::div//div[3]/span[1 and contains(@class, 'temperature_c')]"));
		}

		[Test]
		public void FindCurrentloudy()
		{
			IWebElement currentCloudy = driver.FindElement(By.XPath("//div[contains(@class, 'description')]"));
			string info = currentCloudy.Text;
			if (info == "Малооблачно")
			{
				IWebElement currentTemperature = driver.FindElement(By.XPath("//div[@class='weather_frame_now']//div[contains(@class, 'temperature')]//span[contains(@class, 'unit_temperature_c')]"));
				string temperature = currentTemperature.Text;
			}
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			driver.Quit();
		}
	}

}

