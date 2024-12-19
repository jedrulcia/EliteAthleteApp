using AutoMapper;
using EliteAthleteAppShared.Configurations.Constants;
using EliteAthleteAppShared.Contracts;
using EliteAthleteAppShared.Data;
using EliteAthleteAppShared.Models.TrainingOrm;
using EliteAthleteAppShared.Models.UserBodyMeasurements;
using EliteAthleteAppShared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EliteAthleteApp.Controllers
{
	[Authorize]
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
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> List(string? userId)
		{
			return PartialView(await userBodyMeasurementsRepository.GetUserBodyMeasurementsVMsAsync(userId));
		}

		// GET: UserBodyMeasurements/Create
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Create(string userId)
		{
			return PartialView(await userBodyMeasurementsRepository.GetUserBodyMeasurementCreateVM(userId));
		}

		// POST: UserBodyMeasurements/Create
		[HttpPost, ActionName("Create")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Create(UserBodyMeasurementsCreateVM userBodyMeasurementsCreateVM)
		{
			if (ModelState.IsValid)
			{
				await userBodyMeasurementsRepository.CreateUserBodyMeasurementAsync(userBodyMeasurementsCreateVM);
				return RedirectToAction(nameof(Index), "Users", new { userId = userBodyMeasurementsCreateVM.UserId });
			}
			TempData["ErrorMessage"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).FirstOrDefault() ?? "Error while creating User Body Measruements. Please try again.";
			return RedirectToAction(nameof(Index), "Users", new { userId = userBodyMeasurementsCreateVM.UserId });
		}

		// GET: UserBodyMeasurements/Edit
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Edit(int bodyMeasurementId)
		{
			return PartialView(await userBodyMeasurementsRepository.GeUserBodyMeasurementEditVM(bodyMeasurementId));
		}

		// POST: UserBodyMeasurements/Edit
		[HttpPost, ActionName("Edit")]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Edit(UserBodyMeasurementsCreateVM userBodyMeasurementsCreateVM)
		{
			if (ModelState.IsValid)
			{
				await userBodyMeasurementsRepository.EditUserBodyMeasurementAsync(userBodyMeasurementsCreateVM);
				return RedirectToAction(nameof(Index), "Users", new { userId = userBodyMeasurementsCreateVM.UserId });
			}
			TempData["ErrorMessage"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).FirstOrDefault() ?? "Error while editing User Body Measruements. Please try again.";
			return RedirectToAction(nameof(Index), "Users", new { userId = userBodyMeasurementsCreateVM.UserId });
		}

		// GET: UserBodyMeasurements/Delete
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Delete(int bodyMeasurementId)
		{
			return PartialView(await userBodyMeasurementsRepository.GetUserBodyMeasurementDeleteVM(bodyMeasurementId));
		}

		// POST: UserBodyMeasurements/Delete
		[HttpPost, ActionName("Delete")]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Delete(UserBodyMeasurementsDeleteVM userBodyMeasurementsDeleteVM)
		{
			await userBodyMeasurementsRepository.DeleteUserBodyMeasurementAsync(userBodyMeasurementsDeleteVM);
			return RedirectToAction(nameof(Index), "Users", new { userId = userBodyMeasurementsDeleteVM.UserId });
		}
	}
}
