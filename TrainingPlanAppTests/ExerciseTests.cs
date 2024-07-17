using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlanAppTests
{
	public class ExerciseTests
	{
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

		public void Login()
		{
			driver.FindElement(By.CssSelector("a[href='/Identity/Account/Login']")).Click();
			driver.FindElement(By.Id("Input_Email")).SendKeys("admin@localhost.com");
			driver.FindElement(By.Id("Input_Password")).SendKeys("Admin!2");
			driver.FindElement(By.Id("login-submit")).Click();
		}

		//EXERCISES
		[Test, Order(1)]
		public void CreateExercise()
		{
			Login();
			driver.FindElement(By.CssSelector("a[href='/Exercises']")).Click();
			driver.FindElement(By.CssSelector("a[href='/Exercises/Create']")).Click();
			driver.FindElement(By.Id("Name")).SendKeys("TestExercise1");
			driver.FindElement(By.Id("VideoLink")).SendKeys("https://www.youtube.com/watch?v=CjHIKDQ4RQo");
			driver.FindElement(By.Id("Description")).SendKeys("Description");
			driver.FindElement(By.CssSelector("input[type='submit'][value='Create'].btn.btn-primary")).Click();
		}

		[Test, Order(2)]
		public void ViewExerciseDetails()
		{
			Login();
			driver.FindElement(By.CssSelector("a[href='/Exercises']")).Click();
			var row = driver.FindElement(By.XPath("//tr[td[contains(text(), 'TestExercise1')]]"));
			row.FindElement(By.XPath(".//a[contains(text(), 'Details')]")).Click();
		}

		[Test, Order(3)]
		public void EditExercise()
		{
			Login();
			driver.FindElement(By.CssSelector("a[href='/Exercises']")).Click();
			var row = driver.FindElement(By.XPath("//tr[td[contains(text(), 'TestExercise1')]]"));
			row.FindElement(By.XPath(".//a[contains(text(), 'Edit')]")).Click();
			driver.FindElement(By.Id("Name")).Clear();
			driver.FindElement(By.Id("Name")).SendKeys("TestExercise1");
			driver.FindElement(By.Id("VideoLink")).Clear();
			driver.FindElement(By.Id("VideoLink")).SendKeys("https://www.youtube.com/watch?v=jNQXAC9IVRw");
			driver.FindElement(By.Id("Description")).Clear();
			driver.FindElement(By.Id("Description")).SendKeys("Description");
			driver.FindElement(By.XPath("//input[@value='Save changes']")).Click();
		}

		[Test, Order(4)]
		public void RemoveExercise()
		{
			Login();
			driver.FindElement(By.CssSelector("a[href='/Exercises']")).Click();
			var row = driver.FindElement(By.XPath("//tr[td[contains(text(), 'TestExercise1')]]"));
			row.FindElement(By.XPath(".//button[contains(@class, 'deleteBtn')]")).Click();
			driver.FindElement(By.CssSelector("button.swal-button.swal-button--confirm.swal-button--danger"));
		}
	}
}
