using EliteAthleteApp.Data;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Models.Home;
using EliteAthleteApp.Models.User;
using EliteAthleteApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using EliteAthleteApp.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using EliteAthleteApp.Models.UserChat;
using System.Text.Json;
using System.Text;

namespace EliteAthleteApp.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;
		private readonly UserManager<User> userManager;
		private readonly IGoogleDriveService googleDriveService;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IUserChartService userChartService;
		private readonly ITrainingPlanRepository trainingPlanRepository;
		private readonly IEmailSender emailSender;
		private readonly IBackblazeStorageService backblazeStorageService;

		public UserRepository(ApplicationDbContext context, 
			IMapper mapper, 
			UserManager<User> userManager, 
			IGoogleDriveService googleDriveService,
			IHttpContextAccessor httpContextAccessor,
			IUserChartService userChartService,
			ITrainingPlanRepository trainingPlanRepository,
			IEmailSender emailSender,
			IBackblazeStorageService backblazeStorageService) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
			this.userManager = userManager;
			this.googleDriveService = googleDriveService;
			this.httpContextAccessor = httpContextAccessor;
			this.userChartService = userChartService;
			this.trainingPlanRepository = trainingPlanRepository;
			this.emailSender = emailSender;
			this.backblazeStorageService = backblazeStorageService;
		}

		// UPLOADS IMAGE TO AZURE BLOB STORAGE AND SAVES URL IN USER MEDIA ENTITY
		public async Task UploadUserImageAsync(string userId, IFormFile imageFile)
		{
			if (imageFile != null && imageFile.Length > 0)
			{
				var user = await userManager.FindByIdAsync(userId);
				user.ImageUrl = await googleDriveService.UploadUserImageAsync(imageFile);
				await UpdateAsync(user);
			}
		}

		// REMOVES IMAGE FROM AZURE BLOB STORAGE AND URL FROM EXERCISE MEDIA ENTITY
		public async Task DeleteUserImageAsync(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			await googleDriveService.RemoveFileAsync(user.ImageUrl);
			user.ImageUrl = null;
			await UpdateAsync(user);
		}

		public async Task<HomeIndexVM> GetHomeIndexVMAsync()
		{
			var homeIndexVM = new HomeIndexVM();
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			if (user != null)
			{
				homeIndexVM.UserVM = mapper.Map<UserVM>(user);
				homeIndexVM.UserChartsVM = await userChartService.GetUserCharts(user.Id);
				homeIndexVM.IsLoggedIn = true;
				homeIndexVM.TrainingPlanDetailsVM = await trainingPlanRepository.GetDailyTrainingPlanVMAsync(user.Id);
			}
			return homeIndexVM;
		}

		public async Task<UserIndexVM> GetUserIndexVMAsync(string? userId)
		{
			string coachId = (await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)).Id;
			var userListVM = mapper.Map<List<UserVM>>((await GetAllAsync()).Where(u => u.CoachId == coachId));
			return new UserIndexVM { AthleteCount = userListVM.Count, CoachId = coachId };
		}

		public async Task<UserPanelVM> GetUserPanelVMAsync(string? userId)
		{
			var userPanelVM = new UserPanelVM();
			if (userId == null)
			{
				userPanelVM.UserVM = mapper.Map<UserVM>(await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User));
				userPanelVM.UserChartsVM = await userChartService.GetUserCharts(userPanelVM.UserVM.Id);
				return userPanelVM;
			}
			userPanelVM.UserVM = mapper.Map<UserVM>(await userManager.FindByIdAsync(userId));
			userPanelVM.UserChartsVM = await userChartService.GetUserCharts(userPanelVM.UserVM.Id);
			return userPanelVM;
		}

		public async Task<List<UserVM>> GetUserListVMAsync()
		{
			string coachId = (await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)).Id;
			var userListVM = mapper.Map<List<UserVM>>((await GetAllAsync()).Where(u => u.CoachId == coachId));
			return userListVM;
		}

		public async Task<UserAddAthleteVM> GetUserAddAthleteVMAsync(int athleteCount)
		{
			var coach = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			var subscription = await context.Set<UserSubscription>().FindAsync(coach.UserSubscriptionId);
			return new UserAddAthleteVM { AthleteCount = athleteCount, AthleteLimit = subscription.AthleteLimit, CoachId = coach.Id };
		}

		public async Task AddAthleteAsync(UserAddAthleteVM userAddAthleteVM)
		{
			var user = (await GetAllAsync())
				.Where(u => u.InviteCode == userAddAthleteVM.InviteCode)
				.FirstOrDefault();

			user.NewCoachId = userAddAthleteVM.CoachId;
			await UpdateAsync(user);
		}

		public async Task<string> AcceptInviteAsync()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			user.CoachId = user.NewCoachId;
			user.NewCoachId = null;
			await UpdateAsync(user);
			return user.Id;
		}

		public async Task<string> DeclineInviteAsync()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			user.NewCoachId = null;
			await UpdateAsync(user);
			return user.Id;
		}

		public async Task<string> DeleteCoachAsync()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			user.CoachId = null;
			await UpdateAsync(user);
			return user.Id ;
		}

		public async Task<string> ResetInviteCodeAsync()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			string inviteCode;
			do
			{
				inviteCode = Guid.NewGuid().ToString("N").Substring(0, 8);
			} while (await userManager.Users.AnyAsync(u => u.InviteCode == inviteCode));

			user.InviteCode = inviteCode;
			await UpdateAsync(user);
			return user.Id;
		}

		public async Task<UserInfoVM> GetUserInfoVMAsync(string? userId)
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
			return userInfoVM;
		}

		public async Task<AdminIndexVM> GetAdminIndexVMAsync()
		{
			var admin = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			return new AdminIndexVM { AdminId = admin.Id };
		}

		public async Task<AdminUserVM> GetAdminUserListVMAsync()
		{
			var admin = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			var users = await GetAllAsync();
			var userVMs = mapper.Map<List<UserVM>>(users);
			return new AdminUserVM { UserVMs = userVMs, AdminId = admin.Id };
		}

		public async Task<AdminSendEmailVM> GetAdminSendEmailVMAsync(string? userId)
		{
			var admin = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			return new AdminSendEmailVM { UserId = userId, AdminId = admin.Id };
		}

		public async Task SendEmailAsync(AdminSendEmailVM adminSendEmailVM)
		{
			string subject = adminSendEmailVM.Subject;
			string message = adminSendEmailVM.Message;

			if (adminSendEmailVM.UserId == null)
			{
				var users = await GetAllAsync();
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
		}

		public async Task<AdminUserDeleteVM> GetAdminUserDeleteVMAsync(string userId)
		{
			var userVM = mapper.Map<UserVM>(await userManager.FindByIdAsync(userId));
			var admin = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			return new AdminUserDeleteVM { AdminId = admin.Id, UserVM = userVM );
		}

		public async Task UserDeleteAsync(UserVM userVM)
		{
			var user = await userManager.FindByIdAsync(userVM.Id);
			await userManager.DeleteAsync(user);
		}

		public async Task<AdminUserLockoutVM> GetAdminUserLockoutVMAsync(string userId)
		{
			var userVM = mapper.Map<UserVM>(await userManager.FindByIdAsync(userId));
			var admin = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			return new AdminUserLockoutVM { AdminId = admin.Id, UserVM = userVM };
		}

		public async Task UserLockoutAsync(AdminUserLockoutVM adminUserLockoutVM)
		{
			var user = await userManager.FindByIdAsync(adminUserLockoutVM.UserVM.Id);
			user.LockoutEnd = adminUserLockoutVM.LockoutDate;
			await UpdateAsync(user);
		}

		public async Task<UserChatVM> GetUserChatVMAsync(string? userId)
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

			return chatVM;
		}
	}
}
