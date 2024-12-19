using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EliteAthleteAppShared.Data;
using EliteAthleteAppShared.Models.User;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using EliteAthleteAppShared.Repositories;
using Microsoft.EntityFrameworkCore;
using EliteAthleteAppShared.Services;
using System.Text.Json;
using System.Text;
using EliteAthleteAppShared.Contracts;
using EliteAthleteAppShared.Models.UserChat;
using Microsoft.AspNetCore.Identity.UI.Services;
using EliteAthleteAppShared.Models.Home;
using EliteAthleteAppShared.Configurations.Constants;

namespace EliteAthleteApp.Controllers
{
	[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
	public class UsersController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IUserRepository userRepository;
		private readonly ApplicationDbContext context;
		private readonly IUserChartService userChartService;
		private readonly IEmailSender emailSender;
		private readonly IBackblazeStorageService backblazeStorageService;

		public UsersController(UserManager<User> userManager,
			IMapper mapper,
			IHttpContextAccessor httpContextAccessor,
			IUserRepository userRepository,
			ApplicationDbContext context,
			IUserChartService userChartService,
			IEmailSender emailSender,
			IBackblazeStorageService backblazeStorageService)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			this.userRepository = userRepository;
			this.context = context;
			this.userChartService = userChartService;
			this.emailSender = emailSender;
			this.backblazeStorageService = backblazeStorageService;
		}

		// GET: Users/List/Index
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> UserIndex(string? userId)
		{
			return View(await userRepository.GetUserIndexVMAsync(userId));
		}

		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> UserPanel(string? userId)
		{
			return View(await userRepository.GetUserPanelVMAsync(userId));
		}

		// GET: Users/List
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> UserList()
		{
			return PartialView(await userRepository.GetUserListVMAsync());
		}

		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> AddAthlete(int athleteCount)
		{
			return PartialView(await userRepository.GetUserAddAthleteVMAsync(athleteCount));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> AddAthlete(UserAddAthleteVM userAddAthleteVM)
		{
			if (ModelState.IsValid)
			{
				await userRepository.AddAthleteAsync(userAddAthleteVM);
				return RedirectToAction(nameof(UserIndex), "Users");
			}
			TempData["ErrorMessage"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).FirstOrDefault() ?? "Error while adding athlete. Please try again.";
			return RedirectToAction(nameof(UserIndex), "Users");

		}

		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> AcceptInvite()
		{
			return RedirectToAction(nameof(UserPanel), new { userId = await userRepository.AcceptInviteAsync() });
		}

		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> DeclineInvite()
		{
			return RedirectToAction(nameof(UserPanel), new { userId = await userRepository.DeclineInviteAsync() });
		}

		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> DeleteCoach()
		{
			return RedirectToAction(nameof(UserPanel), new { userId = await userRepository.DeleteCoachAsync() });
		}

		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> ResetInviteCode()
		{
			return RedirectToAction(nameof(UserPanel), new { userId = await userRepository.ResetInviteCodeAsync() });
		}

		// GET: Users/List/Index/Info
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> UserInfo(string? userId)
		{
			return PartialView(await userRepository.GetUserInfoVMAsync(userId));
		}

		// POST: TrainingExerciseMedia/EditMedia/UploadImage
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> UploadImage(string userId)
		{
			var imageFile = Request.Form.Files[$"imageUpload"];
			await userRepository.UploadUserImageAsync(userId, imageFile);
			return RedirectToAction(nameof(UserPanel), new { userId = userId });
		}

		// POST: TrainingExerciseMedia/EditMedia/DeleteImage
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> DeleteImage(string userId)
		{
			await userRepository.DeleteUserImageAsync(userId);
			return RedirectToAction(nameof(UserPanel), new { userId = userId });
		}

		// GET: Admin/Index
		[Authorize(Roles = $"{Roles.Administrator}")]
		public async Task<IActionResult> AdminIndex()
		{
			return View(await userRepository.GetAdminIndexVMAsync());
		}

		// GET: Admin/Index/User
		[Authorize(Roles = $"{Roles.Administrator}")]
		public async Task<IActionResult> AdminUserList()
		{
			return PartialView(await userRepository.GetAdminUserListVMAsync());
		}

		// GET: Admin/Index/SendEmail
		[Authorize(Roles = $"{Roles.Administrator}")]
		public async Task<IActionResult> SendEmail(string? userId)
		{
			return PartialView(await userRepository.GetAdminSendEmailVMAsync(userId));
		}

		// POST: Admin/Index/SendEmail
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Administrator}")]
		public async Task<IActionResult> SendEmail(AdminSendEmailVM adminSendEmailVM)
		{

			if (ModelState.IsValid)
			{
				await userRepository.SendEmailAsync(adminSendEmailVM);
				return RedirectToAction(nameof(Index));
			}
			TempData["ErrorMessage"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).FirstOrDefault() ?? "Error while sending email. Please try again.";
			return RedirectToAction(nameof(Index));
		}

		// GET: Admin/Index/UserDelete
		[Authorize(Roles = $"{Roles.Administrator}")]
		public async Task<IActionResult> UserDelete(string userId)
		{
			return PartialView(await userRepository.GetAdminUserDeleteVMAsync(userId));
		}

		// POST: Admin/Index/UserDelete
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Administrator}")]
		public async Task<IActionResult> UserDelete(UserVM userVM)
		{
			await userRepository.UserDeleteAsync(userVM);
			return RedirectToAction(nameof(Index));
		}

		// GET: Admin/Index/UserLockout
		[Authorize(Roles = $"{Roles.Administrator}")]
		public async Task<IActionResult> UserLockout(string userId)
		{
			return PartialView(await userRepository.GetAdminUserLockoutVMAsync(userId));
		}

		// POST: Admin/Index/UserLockout
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Administrator}")]
		public async Task<IActionResult> UserLockout(AdminUserLockoutVM adminUserLockoutVM)
		{
			userRepository.UserLockoutAsync(adminUserLockoutVM);
			return RedirectToAction(nameof(Index));
		}

		[Authorize(Roles = $"{Roles.Administrator},{Roles.Coach},{Roles.User}")]
		public async Task<IActionResult> UserChat(string? userId)
		{
			return View(await userRepository.GetUserChatVMAsync(userId));
		}
	}
}
