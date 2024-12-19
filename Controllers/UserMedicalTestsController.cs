using AutoMapper;
using EliteAthleteAppShared.Configurations.Constants;
using EliteAthleteAppShared.Contracts;
using EliteAthleteAppShared.Data;
using EliteAthleteAppShared.Models.UserMedicalTest;
using EliteAthleteAppShared.Models.UserMedicalTest;
using EliteAthleteAppShared.Repositories;
using Microsoft.AspNetCore.Authorization;
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

		// GET: UserMedicalTest/List
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> List(string? userId)
		{
			return PartialView(await userMedicalTestRepository.GetUserMedicalTestVMsAsync(userId));
		}

		// GET: UserMedicalTest/Create
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Create(string userId)
		{
			return PartialView(await userMedicalTestRepository.GetUserMedicalTestCreateVM(userId));
		}

		// POST: UserMedicalTest/Create
		[HttpPost, ActionName("Create")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Create(UserMedicalTestCreateVM userMedicalTestCreateVM)
		{
			if (ModelState.IsValid)
			{
				var file = Request.Form.Files[$"fileUpload"];
				await userMedicalTestRepository.CreateUserMedicalTestAsync(userMedicalTestCreateVM, file);
				return RedirectToAction(nameof(Index), "Users", new { userId = userMedicalTestCreateVM.UserId });
			}
			TempData["ErrorMessage"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).FirstOrDefault() ?? "Error while creating User Mdeical Test. Please try again.";
			return RedirectToAction(nameof(Index), "Users", new { userId = userMedicalTestCreateVM.UserId });
		}

		// GET: UserMedicalTest/Edit
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Edit(int medicalTestId)
		{
			return PartialView(await userMedicalTestRepository.GeUserMedicalTestEditVM(medicalTestId));
		}

		// POST: UserMedicalTest/Edit
		[HttpPost, ActionName("Edit")]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Edit(UserMedicalTestCreateVM userMedicalTestCreateVM)
		{
			if (ModelState.IsValid)
			{
				var file = Request.Form.Files[$"fileUpload"];
				await userMedicalTestRepository.EditUserMedicalTestAsync(userMedicalTestCreateVM, file);
				return RedirectToAction(nameof(Index), "Users", new { userId = userMedicalTestCreateVM.UserId });
			}
			TempData["ErrorMessage"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).FirstOrDefault() ?? "Error while editing User Mdeical Test. Please try again.";
			return RedirectToAction(nameof(Index), "Users", new { userId = userMedicalTestCreateVM.UserId });
		}

		// GET: UserMedicalTest/Delete
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Delete(int medicalTestId)
		{
			return PartialView(await userMedicalTestRepository.GetUserMedicalTestDeleteVM(medicalTestId));
		}

		// POST: UserMedicalTest/Delete
		[HttpPost, ActionName("Delete")]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Delete(UserMedicalTestDeleteVM userMedicalTestDeleteVM)
		{
			await userMedicalTestRepository.DeleteUserMedicalTestAsync(userMedicalTestDeleteVM);
			return RedirectToAction(nameof(Index), "Users", new { userId = userMedicalTestDeleteVM.UserId });
		}

		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Media(string fileUrl)
		{
			return PartialView(new UserMedicalTestMediaVM { FileUrl = fileUrl });
		}
	}
}
