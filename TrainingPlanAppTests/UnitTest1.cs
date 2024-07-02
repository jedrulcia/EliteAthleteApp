using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TrainingPlanAppTests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Run() 
		{
			IWebDriver driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl("https://localhost:7256/");
			driver.Quit();
		}

		[Test]
		public void Login()
		{
			IWebDriver driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl("https://localhost:7256/");
			driver.FindElement(By.CssSelector("a[href='/Identity/Account/Login']")).Click();
			driver.FindElement(By.Id("Input_Email")).SendKeys("admin@localhost.com");
			driver.FindElement(By.Id("Input_Password")).SendKeys("Admin!2");
			driver.FindElement(By.Id("login-submit")).Click();
			driver.Quit();
		}
	}
}