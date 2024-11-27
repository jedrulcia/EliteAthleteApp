using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.User;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using EliteAthleteApp.Repositories;
using Microsoft.EntityFrameworkCore;
using EliteAthleteApp.Services;
using System.Text.Json;
using System.Text;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Models.UserChat;
using Microsoft.AspNetCore.Identity.UI.Services;
using EliteAthleteApp.Models.Home;

namespace EliteAthleteApp.Controllers
{
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
		public async Task<IActionResult> UserIndex(string? userId)
		{
			string coachId = (await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)).Id;
			var userListVM = mapper.Map<List<UserVM>>((await userRepository.GetAllAsync()).Where(u => u.CoachId == coachId));
			return View(new UserIndexVM { AthleteCount = userListVM.Count, CoachId = coachId });
		}
		public async Task<IActionResult> UserPanel(string? userId)
		{
			var userPanelVM = new UserPanelVM();
			if (userId == null)
			{
				userPanelVM.UserVM = mapper.Map<UserVM>(await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User));
				userPanelVM.UserChartsVM = await userChartService.GetUserCharts(userPanelVM.UserVM.Id);
				return View(userPanelVM);
			}
			userPanelVM.UserVM = mapper.Map<UserVM>(await userManager.FindByIdAsync(userId));
			userPanelVM.UserChartsVM = await userChartService.GetUserCharts(userPanelVM.UserVM.Id);
			return View(userPanelVM);
		}

		// GET: Users/List
		public async Task<IActionResult> UserList()
		{
			string coachId = (await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)).Id;
			var userListVM = mapper.Map<List<UserVM>>((await userRepository.GetAllAsync()).Where(u => u.CoachId == coachId));
			return PartialView(userListVM);
		}

		public async Task<IActionResult> AddAthlete(int athleteCount)
		{
			return PartialView(new UserAddAthleteVM { AthleteCount = athleteCount });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddAthlete(UserAddAthleteVM userAddAthleteVM)
		{
			var coach = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			var subscription = await context.Set<UserSubscription>().FindAsync(coach.UserSubscriptionId);

			if (userAddAthleteVM.AthleteCount >= subscription.AthleteLimit)
			{
				TempData["ErrorMessage"] = $"You have reached the limit of athletes in your subscription.";
				return RedirectToAction(nameof(UserList), "Users");
			}

			var user = (await userRepository.GetAllAsync())
				.Where(u => u.InviteCode == userAddAthleteVM.InviteCode)
				.FirstOrDefault();

			user.NewCoachId = coach.Id;
			await userRepository.UpdateAsync(user);

			return RedirectToAction(nameof(UserList), "Users");
		}

		public async Task<IActionResult> AcceptInvite()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			user.CoachId = user.NewCoachId;
			user.NewCoachId = null;
			await userRepository.UpdateAsync(user);

			return RedirectToAction(nameof(UserPanel), new { userId = user.Id });
		}

		public async Task<IActionResult> DeclineInvite()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			user.NewCoachId = null;
			await userRepository.UpdateAsync(user);

			return RedirectToAction(nameof(UserPanel), new { userId = user.Id });
		}

		public async Task<IActionResult> DeleteCoach()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			user.CoachId = null;
			await userRepository.UpdateAsync(user);

			return RedirectToAction(nameof(UserPanel), new { userId = user.Id });
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
			return RedirectToAction(nameof(UserPanel), new { userId = user.Id });
		}

		// GET: Users/List/Index/Info
		public async Task<IActionResult> UserInfo(string? userId)
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
			return RedirectToAction(nameof(UserPanel), new { userId = userId });
		}

		// POST: TrainingExerciseMedia/EditMedia/DeleteImage
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteImage(string userId)
		{
			await userRepository.DeleteUserImageAsync(userId);
			return RedirectToAction(nameof(UserPanel), new { userId = userId });
		}


		// GET: Admin/Index
		public async Task<IActionResult> AdminIndex()
		{
			var admin = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			return View(new AdminIndexVM { AdminId = admin.Id });
		}

		// GET: Admin/Index/User
		public async Task<IActionResult> AdminUserList()
		{
			var admin = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			var users = await userRepository.GetAllAsync();
			var userVMs = mapper.Map<List<UserVM>>(users);
			return PartialView(new AdminUserVM { UserVMs = userVMs, AdminId = admin.Id });
		}

		// GET: Admin/Index/SendEmail
		public async Task<IActionResult> SendEmail(string? userId)
		{
			var admin = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			return PartialView(new AdminSendEmailVM { UserId = userId, AdminId = admin.Id });
		}

		// POST: Admin/Index/SendEmail
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> SendEmail(AdminSendEmailVM adminSendEmailVM)
		{

			if (ModelState.IsValid)
			{
				string subject = adminSendEmailVM.Subject;
				string message = adminSendEmailVM.Message;

				if (adminSendEmailVM.UserId == null)
				{
					var users = await userRepository.GetAllAsync();
					foreach (var user in users)
					{
						await emailSender.SendEmailAsync(user.Email, subject, message);
					}
				}
				else
				{
					var user = await userManager.FindByIdAsync(adminSendEmailVM.UserId);
					await emailSender.SendEmailAsync(user.Email, subject, message);
				}
				return RedirectToAction(nameof(Index));
			}
			TempData["ErrorMessage"] = $"Error while sending emails. Please try again.";
			return RedirectToAction(nameof(Index));
		}

		// GET: Admin/Index/UserDelete
		public async Task<IActionResult> UserDelete(string userId)
		{
			var userVM = mapper.Map<UserVM>(await userManager.FindByIdAsync(userId));
			var admin = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			return PartialView(new AdminUserDeleteVM { AdminId = admin.Id, UserVM = userVM });
		}

		// POST: Admin/Index/UserDelete
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UserDelete(UserVM userVM)
		{
			var user = await userManager.FindByIdAsync(userVM.Id);
			await userManager.DeleteAsync(user);
			return RedirectToAction(nameof(Index));
		}

		// GET: Admin/Index/UserLockout
		public async Task<IActionResult> UserLockout(string userId)
		{
			var userVM = mapper.Map<UserVM>(await userManager.FindByIdAsync(userId));
			var admin = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			return PartialView(new AdminUserLockoutVM { AdminId = admin.Id, UserVM = userVM });
		}

		// POST: Admin/Index/UserLockout
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UserLockout(AdminUserLockoutVM adminUserLockoutVM)
		{
			var user = await userManager.FindByIdAsync(adminUserLockoutVM.UserVM.Id);
			user.LockoutEnd = adminUserLockoutVM.LockoutDate;
			await userRepository.UpdateAsync(user);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Chat(string? userId)
		{
			var viewerId = (await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)).Id;
			var user1 = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			var user2 = await userManager.FindByIdAsync(userId);

			var coachVM = new UserVM();
			var userVM = new UserVM();

			if (User.IsInRole("Coach"))
			{
				coachVM = mapper.Map<UserVM>(user1);
				userVM = mapper.Map<UserVM>(user2);
			}
			else
			{
				coachVM = mapper.Map<UserVM>(user2);
				userVM = mapper.Map<UserVM>(user1);
			}

			// Sprawdź, czy chat między użytkownikami już istnieje
			var chat = await context.Set<UserChat>().Where(uc => uc.UserId == userVM.Id && uc.CoachId == coachVM.Id).FirstOrDefaultAsync();

			List<UserChatMessageVM> chatMessages;
			if (chat == null)
			{
				// Tworzymy nowy plik JSON, jeśli chat nie istnieje
				chatMessages = new List<UserChatMessageVM>();
				string jsonContent = JsonSerializer.Serialize(chatMessages, new JsonSerializerOptions { WriteIndented = true });
				var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonContent));

				var chatFile = new FormFile(stream, 0, stream.Length, "chatFile", "chatFile.json");
				var chatName = userVM.Id;
				string jsonUrl = await backblazeStorageService.UploadChatAsync(chatFile, chatName);

				chat = new UserChat { CoachId = coachVM.Id, UserId = userVM.Id, ChatUrl = jsonUrl };
				await context.AddAsync(chat);
				await context.SaveChangesAsync();
			}
			else
			{
				chatMessages = await backblazeStorageService.GetChatAsync(chat.ChatUrl);
			}

			// Tworzymy model widoku
			var chatVM = new UserChatVM
			{
				Id = chat.Id,
				CoachVM = coachVM,
				UserVM = userVM,
				UserChatMessageVMs = chatMessages,
				ViewerId = viewerId
			};

			return View(chatVM);
		}
	}
}
