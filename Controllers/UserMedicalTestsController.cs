using AutoMapper;
using EliteAthleteApp.Contracts.Repositories;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.UserMedicalTest;
using EliteAthleteApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EliteAthleteApp.Controllers
{
    public class UserMedicalTestsController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IUserMedicalTestRepository userMedicalTestRepository;

		public UserMedicalTestsController(UserManager<User> userManager,
			IMapper mapper,
			IHttpContextAccessor httpContextAccessor,
			IUserMedicalTestRepository userMedicalTestRepository)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			this.userMedicalTestRepository = userMedicalTestRepository;
		}

		public async Task<IActionResult> List(string? userId)
		{
			var medicalTestVMs = mapper.Map<UserMedicalTestVM>((await userMedicalTestRepository.GetAllAsync())
				.ToList()
				.Where(x => x.UserId == userId));

			return PartialView(medicalTestVMs);
		}

		// GET: UserMedicalTestsController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: UserMedicalTestsController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: UserMedicalTestsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: UserMedicalTestsController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: UserMedicalTestsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: UserMedicalTestsController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: UserMedicalTestsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
