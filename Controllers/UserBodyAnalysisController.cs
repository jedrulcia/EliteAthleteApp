using AutoMapper;
using EliteAthleteApp.Contracts.Repositories;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.UserBodyAnalysis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EliteAthleteApp.Controllers
{
    public class UserBodyAnalysisController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IUserBodyAnalysisRepository userBodyAnalysisRepository;

		public UserBodyAnalysisController(UserManager<User> userManager,
			IMapper mapper,
			IHttpContextAccessor httpContextAccessor,
			IUserBodyAnalysisRepository userBodyAnalysisRepository)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			this.userBodyAnalysisRepository = userBodyAnalysisRepository;
		}

		public async Task<IActionResult> List(string? userId)
		{
			var bodyAnalysisVMs = mapper.Map<UserBodyAnalysisVM>((await userBodyAnalysisRepository.GetAllAsync())
				.ToList()
				.Where(x => x.UserId == userId));

			return PartialView(bodyAnalysisVMs);
		}

		// GET: UserBodyAnalysisController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: UserBodyAnalysisController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: UserBodyAnalysisController/Create
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

		// GET: UserBodyAnalysisController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: UserBodyAnalysisController/Edit/5
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

		// GET: UserBodyAnalysisController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: UserBodyAnalysisController/Delete/5
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
