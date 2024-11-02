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

namespace EliteAthleteApp.Controllers
{
	public class UsersController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IUserRepository userRepository;

		public UsersController(UserManager<User> userManager,
			IMapper mapper,
			IHttpContextAccessor httpContextAccessor,
			IUserRepository userRepository)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			this.userRepository = userRepository;
		}

		// GET: Users/Index
		public async Task<IActionResult> Index()
		{
			string coachId = (await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)).Id;
			var userListVM = mapper.Map<List<UserVM>>((await userRepository.GetAllAsync()).Where(u => u.CoachId == coachId));
			return View(userListVM);
		}

		// GET: Users/Index/Panel
		public async Task<IActionResult> Panel(string? userId)
		{
			if (userId == null)
			{
				return View(mapper.Map<UserVM>(await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)));
			}
			return View(mapper.Map<UserVM>(await userManager.FindByIdAsync(userId)));
		}


		// GET: Users/Index/Panel/Info
		public async Task<IActionResult> Info(string? userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			var userVM = mapper.Map<UserInfoVM>(user);
			if (user.CoachId != null)
			{
				var coachVM = mapper.Map<UserVM>(await userManager.FindByIdAsync(user.CoachId));
				userVM.CoachFullName = coachVM.FirstName + " " + coachVM.LastName;
			}
			return PartialView(userVM);
		}

		// POST: TrainingExerciseMedia/EditMedia/UploadImage
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UploadImage(string userId)
		{
			var imageFile = Request.Form.Files[$"imageUpload"];
			await userRepository.UploadUserImageAsync(userId, imageFile);
			return RedirectToAction(nameof(Panel), "Users", new { userId = userId });
		}

		// POST: TrainingExerciseMedia/EditMedia/DeleteImage
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteImage(string userId)
		{
			await userRepository.DeleteUserImageAsync(userId);
			return RedirectToAction(nameof(Panel), "Users", new { userId = userId });
		}

		public async Task<IActionResult> AddAthlete(string? inviteCode)
		{
			var coach = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			var user = (await userRepository.GetAllAsync())
				.Where(u => u.InviteCode == inviteCode)
				.FirstOrDefault();

			user.CoachId = coach.Id;
			await userRepository.UpdateAsync(user);

			return RedirectToAction(nameof(Index), "Users");
		}
	}
}
