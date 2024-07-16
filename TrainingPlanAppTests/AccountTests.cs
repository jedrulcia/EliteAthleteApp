using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlanAppTests
{
	public class AccountTests
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
		[TearDown]
		public void Teardown()
		{
			driver.Quit();
			driver.Dispose();
		}


		//ACCOUNTS
		[Test, Order(1)]
		public void Login()
		{
			driver.FindElement(By.CssSelector("a[href='/Identity/Account/Login']")).Click();
			driver.FindElement(By.Id("Input_Email")).SendKeys("admin@localhost.com");
			driver.FindElement(By.Id("Input_Password")).SendKeys("Admin!2");
			driver.FindElement(By.Id("login-submit")).Click();
		}

		[Test, Order(2)]
		public void Logout()
		{
			Login();
			driver.FindElement(By.XPath(".//button[@type='submit']")).Click();
		}

		[Test, Order(3)]
		public void Register()
		{
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
		}
	}
}
