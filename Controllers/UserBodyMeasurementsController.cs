using AutoMapper;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.TrainingOrm;
using EliteAthleteApp.Models.UserBodyMeasurements;
using EliteAthleteApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EliteAthleteApp.Controllers
{
    public class UserBodyMeasurementsController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IUserBodyMeasurementsRepository userBodyMeasurementsRepository;

		public UserBodyMeasurementsController(UserManager<User> userManager,
			IMapper mapper,
			IHttpContextAccessor httpContextAccessor,
			IUserBodyMeasurementsRepository userBodyMeasurementsRepository)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			this.userBodyMeasurementsRepository = userBodyMeasurementsRepository;
		}

		// GET: UserBodyMeasurements/List
		public async Task<IActionResult> List(string? userId)
		{
			return PartialView(await userBodyMeasurementsRepository.GetUserBodyMeasurementsVMsAsync(userId));
		}

		// GET: UserBodyMeasurements/Create
		public async Task<IActionResult> Create(string userId)
		{
			return PartialView(await userBodyMeasurementsRepository.GetUserBodyMeasurementCreateVM(userId));
		}

		// POST: UserBodyMeasurements/Create
		[HttpPost, ActionName("Create")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(UserBodyMeasurementsCreateVM userBodyMeasurementsCreateVM)
		{
			if (ModelState.IsValid)
			{
				await userBodyMeasurementsRepository.CreateUserBodyMeasurementAsync(userBodyMeasurementsCreateVM);
				return RedirectToAction(nameof(Index), "Users", new { userId = userBodyMeasurementsCreateVM.UserId });
			}
			TempData["ErrorMessage"] = ModelState.Values
				.SelectMany(v => v.Errors)
				.Select(e => e.ErrorMessage)
				.FirstOrDefault() ?? "Error while creating User Body Measruements. Please try again.";
			return RedirectToAction(nameof(Index), "Users", new { userId = userBodyMeasurementsCreateVM.UserId });
		}

		// GET: UserBodyMeasurements/Edit
		public async Task<IActionResult> Edit(int bodyMeasurementId)
		{
			return PartialView(await userBodyMeasurementsRepository.GeUserBodyMeasurementEditVM(bodyMeasurementId));
		}

		// POST: UserBodyMeasurements/Edit
		[HttpPost, ActionName("Edit")]
		public async Task<IActionResult> Edit(UserBodyMeasurementsCreateVM userBodyMeasurementsCreateVM)
		{
			if (ModelState.IsValid)
			{
				await userBodyMeasurementsRepository.EditUserBodyMeasurementAsync(userBodyMeasurementsCreateVM);
				return RedirectToAction(nameof(Index), "Users", new { userId = userBodyMeasurementsCreateVM.UserId });
			}
			TempData["ErrorMessage"] = ModelState.Values
				.SelectMany(v => v.Errors)
				.Select(e => e.ErrorMessage)
				.FirstOrDefault() ?? "Error while editing User Body Measruements. Please try again.";
			return RedirectToAction(nameof(Index), "Users", new { userId = userBodyMeasurementsCreateVM.UserId });
		}

		// GET: UserBodyMeasurements/Delete
		public async Task<IActionResult> Delete(int bodyMeasurementId)
		{
			return PartialView(await userBodyMeasurementsRepository.GetUserBodyMeasurementDeleteVM(bodyMeasurementId));
		}

		// POST: UserBodyMeasurements/Delete
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> Delete(UserBodyMeasurementsDeleteVM userBodyMeasurementsDeleteVM)
		{
			await userBodyMeasurementsRepository.DeleteUserBodyMeasurementAsync(userBodyMeasurementsDeleteVM);
			return RedirectToAction(nameof(Index), "Users", new { userId = userBodyMeasurementsDeleteVM.UserId });
		}
	}
}
