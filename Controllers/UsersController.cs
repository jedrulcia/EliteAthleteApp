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
using Azure.Storage.Blobs;
using EliteAthleteApp.Models.UserChat;
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
		private readonly IBlobStorageService blobStorageService;
		private readonly ApplicationDbContext context;

		public UsersController(UserManager<User> userManager,
			IMapper mapper,
			IHttpContextAccessor httpContextAccessor,
			IUserRepository userRepository,
			IBlobStorageService blobStorageService,
			ApplicationDbContext context)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			this.userRepository = userRepository;
			this.blobStorageService = blobStorageService;
			this.context = context;
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
				userVM.CoachVM = coachVM;
			}
			if (user.NewCoachId != null)
			{
				var newCoachVM = mapper.Map<UserVM>(await userManager.FindByIdAsync(user.NewCoachId));
				userVM.NewCoachVM = newCoachVM;
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

			user.NewCoachId = coach.Id;
			await userRepository.UpdateAsync(user);

			return RedirectToAction(nameof(Index), "Users");
		}

		public async Task<IActionResult> AcceptInvite()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			user.CoachId = user.NewCoachId;
			user.NewCoachId = null;
			await userRepository.UpdateAsync(user);

			return RedirectToAction(nameof(Panel), "Users", new { userId = user.Id });
		}

		public async Task<IActionResult> DeclineInvite()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			user.NewCoachId = null;
			await userRepository.UpdateAsync(user);

			return RedirectToAction(nameof(Panel), "Users", new { userId = user.Id });
		}

		public async Task<IActionResult> DeleteCoach()
		{
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			user.CoachId = null;
			await userRepository.UpdateAsync(user);

			return RedirectToAction(nameof(Panel), "Users", new { userId = user.Id });
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
			return RedirectToAction(nameof(Panel), "Users", new { userId = user.Id });
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

			var chat = await context.Set<UserChat>().Where(uc => uc.UserId == userVM.Id && uc.CoachId == coachVM.Id).FirstOrDefaultAsync();
			var stream = new MemoryStream();

			if (chat == null)
			{
				var emptyChat = new List<UserChatMessageVM>();
				string jsonContent = JsonSerializer.Serialize(emptyChat, new JsonSerializerOptions { WriteIndented = true });
				stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonContent));
				var chatFile = new FormFile(stream, 0, stream.Length, "chatFile", "chatFile.json");
				string jsonUrl = await blobStorageService.UploadUserChatFileAsync(chatFile);

				chat = new UserChat { CoachId = coachVM.Id, UserId = userVM.Id, ChatUrl = jsonUrl };
				await context.AddAsync(chat);
				await context.SaveChangesAsync();
			}

			var blobClient = new BlobClient(new Uri(chat.ChatUrl));

			stream = new MemoryStream();
			await blobClient.DownloadToAsync(stream);
			stream.Position = 0;
			var chatMessages = await JsonSerializer.DeserializeAsync<List<UserChatMessageVM>>(stream);



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
