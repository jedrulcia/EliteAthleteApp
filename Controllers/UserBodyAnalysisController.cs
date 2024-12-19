using AutoMapper;
using EliteAthleteAppShared.Configurations.Constants;
using EliteAthleteAppShared.Contracts;
using EliteAthleteAppShared.Data;
using EliteAthleteAppShared.Models.UserBodyAnalysis;
using EliteAthleteAppShared.Models.UserBodyAnalysis;
using EliteAthleteAppShared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EliteAthleteApp.Controllers
{
	[Authorize]
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

		// GET: UserBodyAnalysis/List
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> List(string? userId)
		{
			return PartialView(await userBodyAnalysisRepository.GetUserBodyAnalysisVMsAsync(userId));
		}

		// GET: UserBodyAnalysis/Create
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Create(string userId)
		{
			return PartialView(await userBodyAnalysisRepository.GetUserBodyAnalysisCreateVM(userId));
		}

		// POST: UserBodyAnalysis/Create
		[HttpPost, ActionName("Create")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Create(UserBodyAnalysisCreateVM userBodyAnalysisCreateVM)
		{
			if (ModelState.IsValid)
			{
				var file = Request.Form.Files[$"fileUpload"];
				await userBodyAnalysisRepository.CreateUserBodyAnalysisAsync(userBodyAnalysisCreateVM, file);
				return RedirectToAction(nameof(Index), "Users", new { userId = userBodyAnalysisCreateVM.UserId });
			}
			TempData["ErrorMessage"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).FirstOrDefault() ?? "Error while creating User Body Analysis. Please try again.";
			return RedirectToAction(nameof(Index), "Users", new { userId = userBodyAnalysisCreateVM.UserId });
		}

		// GET: UserBodyAnalysis/Edit
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Edit(int bodyAnalysisId)
		{
			return PartialView(await userBodyAnalysisRepository.GeUserBodyAnalysisEditVM(bodyAnalysisId));
		}

		// POST: UserBodyAnalysis/Edit
		[HttpPost, ActionName("Edit")]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Edit(UserBodyAnalysisCreateVM userBodyAnalysisCreateVM)
		{
			if (ModelState.IsValid)
			{
				var file = Request.Form.Files[$"fileUpload"];
				await userBodyAnalysisRepository.EditUserBodyAnalysisAsync(userBodyAnalysisCreateVM, file);
				return RedirectToAction(nameof(Index), "Users", new { userId = userBodyAnalysisCreateVM.UserId });
			}
			TempData["ErrorMessage"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).FirstOrDefault() ?? "Error while editing User Body Analysis. Please try again.";
			return RedirectToAction(nameof(Index), "Users", new { userId = userBodyAnalysisCreateVM.UserId });
		}

		// GET: UserBodyAnalysis/Delete
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Delete(int bodyAnalysisId)
		{
			return PartialView(await userBodyAnalysisRepository.GetUserBodyAnalysisDeleteVM(bodyAnalysisId));
		}

		// POST: UserBodyAnalysis/Delete
		[HttpPost, ActionName("Delete")]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Delete(UserBodyAnalysisDeleteVM userBodyAnalysisDeleteVM)
		{
			await userBodyAnalysisRepository.DeleteUserBodyAnalysisAsync(userBodyAnalysisDeleteVM);
			return RedirectToAction(nameof(Index), "Users", new { userId = userBodyAnalysisDeleteVM.UserId });
		}

		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Media(string fileUrl)
		{
			return PartialView(new UserBodyAnalysisMediaVM { FileUrl = fileUrl });
		}
	}
}
