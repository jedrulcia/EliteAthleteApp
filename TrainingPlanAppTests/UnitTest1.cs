using Newtonsoft.Json.Converters;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V124.Page;

namespace TrainingPlanAppTests
{
	public class Tests
	{
		Random random = new Random();
		private IWebDriver driver;

		[SetUp]
		public void Setup()
		{
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl("https://localhost:7256/");
		}
		[TearDown] public void Teardown()
		{
			driver.Quit();
		}

		[Test, Order(1)]
		public void Run() 
		{
			IWebDriver driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl("https://localhost:7256/");
			driver.Quit();
		}

		//ACCOUNTS
		[Test, Order(2)]
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

		[Test, Order(3)]
		public void Logout()
		{
			IWebDriver driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl("https://localhost:7256/");
			driver.FindElement(By.CssSelector("a[href='/Identity/Account/Login']")).Click();
			driver.FindElement(By.Id("Input_Email")).SendKeys("admin@localhost.com");
			driver.FindElement(By.Id("Input_Password")).SendKeys("Admin!2");
			driver.FindElement(By.Id("login-submit")).Click();
			driver.FindElement(By.XPath(".//button[@type='submit']")).Click();
			driver.Quit();
		}

		[Test, Order(4)]
		public void Register()
		{
			IWebDriver driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl("https://localhost:7256/");
			driver.FindElement(By.CssSelector("a[href='/Identity/Account/Register']")).Click();
			driver.FindElement(By.Id("Input_FirstName")).SendKeys("Test");
			driver.FindElement(By.Id("Input_LastName")).SendKeys("Account");
			driver.FindElement(By.Id("Input_DateOfBith")).SendKeys("01012000");
			string email = $"testaccount{random.Next(0, 999999)}@localhost.com";
			driver.FindElement(By.Id("Input_Email")).SendKeys(email);
			driver.FindElement(By.Id("Input_Password")).SendKeys("Password!2");
			driver.FindElement(By.Id("Input_ConfirmPassword")).SendKeys("Password!2");
			driver.FindElement(By.Id("registerSubmit")).Click();
			driver.FindElement(By.Id("confirm-link")).Click();
			driver.Quit();
		}

		//EXERCISES
		[Test, Order(5)]
		public void CreateExercise()
		{
			IWebDriver driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl("https://localhost:7256/");
			driver.FindElement(By.CssSelector("a[href='/Identity/Account/Login']")).Click();
			driver.FindElement(By.Id("Input_Email")).SendKeys("admin@localhost.com");
			driver.FindElement(By.Id("Input_Password")).SendKeys("Admin!2");
			driver.FindElement(By.Id("login-submit")).Click();
			driver.FindElement(By.CssSelector("a[href='/Exercises']")).Click();
		}

		[Test, Order(6)]
		public void ViewExerciseDetails()
		{
			IWebDriver driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl("https://localhost:7256/");
			driver.FindElement(By.CssSelector("a[href='/Identity/Account/Login']")).Click();
			driver.FindElement(By.Id("Input_Email")).SendKeys("admin@localhost.com");
			driver.FindElement(By.Id("Input_Password")).SendKeys("Admin!2");
			driver.FindElement(By.Id("login-submit")).Click();
			driver.FindElement(By.CssSelector("a[href='/Exercises']")).Click();
		}

		[Test, Order(7)]
		public void EditExericse()
		{
			IWebDriver driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl("https://localhost:7256/");
			driver.FindElement(By.CssSelector("a[href='/Identity/Account/Login']")).Click();
			driver.FindElement(By.Id("Input_Email")).SendKeys("admin@localhost.com");
			driver.FindElement(By.Id("Input_Password")).SendKeys("Admin!2");
			driver.FindElement(By.Id("login-submit")).Click();
			driver.FindElement(By.CssSelector("a[href='/Exercises']")).Click();

		}

		[Test, Order(8)]
		public void RemoveExercise()
		{
			IWebDriver driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl("https://localhost:7256/");
			driver.FindElement(By.CssSelector("a[href='/Identity/Account/Login']")).Click();
			driver.FindElement(By.Id("Input_Email")).SendKeys("admin@localhost.com");
			driver.FindElement(By.Id("Input_Password")).SendKeys("Admin!2");
			driver.FindElement(By.Id("login-submit")).Click();
			driver.FindElement(By.CssSelector("a[href='/Exercises']")).Click();

		}

	}
}