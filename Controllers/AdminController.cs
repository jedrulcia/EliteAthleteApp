using AutoMapper;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.Admin;
using EliteAthleteApp.Models.TrainingExercise;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EliteAthleteApp.Services;
using EliteAthleteApp.Models.User;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace EliteAthleteApp.Controllers
{
    public class AdminController : Controller
	{
		private readonly ApplicationDbContext context;
		private readonly UserManager<User> userManager;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly ITrainingExerciseRepository trainingExerciseRepository;
		private readonly IMapper mapper;
		private readonly IUserRepository userRepository;
		private readonly IEmailSender emailSender;

		public AdminController(ApplicationDbContext context, 
			UserManager<User> userManager, 
			IHttpContextAccessor httpContextAccessor, 
			ITrainingExerciseRepository trainingExerciseRepository,
			IMapper mapper,
			IUserRepository userRepository,
			IEmailSender emailSender) 
		{
			this.context = context;
			this.userManager = userManager;
			this.httpContextAccessor = httpContextAccessor;
			this.trainingExerciseRepository = trainingExerciseRepository;
			this.mapper = mapper;
			this.userRepository = userRepository;
			this.emailSender = emailSender;
		}
		// GET: Admin/Index
		public async Task<IActionResult> Index()
		{
			var admin = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			return View(new AdminIndexVM { AdminId = admin.Id });	
		}

		// GET: Admin/Index/User
		public async Task<IActionResult> UserList()
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
	}
}
