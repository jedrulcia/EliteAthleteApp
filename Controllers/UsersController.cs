using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EliteAthleteApp.Constants;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.User;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using EliteAthleteApp.Repositories;
using EliteAthleteApp.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using EliteAthleteApp.Services;
using System.Text.Json;
using System.Text;
using EliteAthleteApp.Contracts.Services;

namespace EliteAthleteApp.Controllers
{
    public class UsersController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IUserRepository userRepository;
		private readonly ApplicationDbContext context;
		private readonly IGoogleDriveService googleDriveService;

		public UsersController(UserManager<User> userManager,
			IMapper mapper,
			IHttpContextAccessor httpContextAccessor,
			IUserRepository userRepository,
			ApplicationDbContext context,
			IGoogleDriveService googleDriveService)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			this.userRepository = userRepository;
			this.context = context;
			this.googleDriveService = googleDriveService;
		}

		// GET: Users/List
		public async Task<IActionResult> List()
		{
			string coachId = (await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)).Id;
			var userListVM = mapper.Map<List<UserVM>>((await userRepository.GetAllAsync()).Where(u => u.CoachId == coachId));
			return View(userListVM);
		}

		// GET: Users/List/Index
		public async Task<IActionResult> Index(string? userId)
		{
			if (userId == null)
			{
				return View(mapper.Map<UserVM>(await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)));
			}
			return View(mapper.Map<UserVM>(await userManager.FindByIdAsync(userId)));
		}


		// GET: Users/List/Index/Info
		public async Task<IActionResult> Info(string? userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			var userVM = mapper.Map<UserVM>(user);
			var userInfoVM = new UserInfoVM { UserVM = userVM };
			if (user.CoachId != null)
			{
				var coachVM = mapper.Map<UserVM>(await userManager.FindByIdAsync(user.CoachId));
				userInfoVM.CoachVM = coachVM;
			}
			if (user.NewCoachId != null)
			{
				var newCoachVM = mapper.Map<UserVM>(await userManager.FindByIdAsync(user.NewCoachId));
				userInfoVM.NewCoachVM = newCoachVM;
			}
			return PartialView(userInfoVM);
		}

		// POST: TrainingExerciseMedia/EditMedia/UploadImage
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UploadImage(string userId)
		{
			var imageFile = Request.Form.Files[$"imageUpload"];
			await userRepository.UploadUserImageAsync(userId, imageFile);
			return RedirectToAction(nameof(Index), "Users", new { userId = userId });
		}

		// POST: TrainingExerciseMedia/EditMedia/DeleteImage
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteImage(string userId)
		{
			await userRepository.DeleteUserImageAsync(userId);
			return RedirectToAction(nameof(Index), "Users", new { userId = userId });
		}

		public async Task<IActionResult> AddAthlete(string? inviteCode, int athleteCount)
		{
			var coach = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			var subscription = await context.Set<UserSubscription>().FindAsync(coach.UserSubscriptionId);

			if (athleteCount >= subscription.AthleteLimit)
			{
				TempData["ErrorMessage"] = $"You have reached the limit of athletes in your subscription.";
				return RedirectToAction(nameof(List), "Users");
			}

			var user = (await userRepository.GetAllAsync())
				.Where(u => u.InviteCode == inviteCode)
				.FirstOrDefault();

			user.NewCoachId = coach.Id;
			await userRepository.UpdateAsync(user);

			return RedirectToAction(nameof(List), "Users");
		}

		public async Task<IActionResult> AcceptInvite()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			user.CoachId = user.NewCoachId;
			user.NewCoachId = null;
			await userRepository.UpdateAsync(user);

			return RedirectToAction(nameof(Index), "Users", new { userId = user.Id });
		}

		public async Task<IActionResult> DeclineInvite()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			user.NewCoachId = null;
			await userRepository.UpdateAsync(user);

			return RedirectToAction(nameof(Index), "Users", new { userId = user.Id });
		}

		public async Task<IActionResult> DeleteCoach()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			user.CoachId = null;
			await userRepository.UpdateAsync(user);

			return RedirectToAction(nameof(Index), "Users", new { userId = user.Id });
		}

		public async Task<IActionResult> ResetInviteCode()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			string inviteCode;
			do
			{
				inviteCode = Guid.NewGuid().ToString("N").Substring(0, 8);
			} while (await userManager.Users.AnyAsync(u => u.InviteCode == inviteCode));

			user.InviteCode = inviteCode;
			await userRepository.UpdateAsync(user);
			return RedirectToAction(nameof(Index), "Users", new { userId = user.Id });
		}
    }
}
