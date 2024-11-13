using AutoMapper;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EliteAthleteApp.Contracts;

namespace EliteAthleteApp.Controllers
{
    public class UserChatsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;
        private readonly IGoogleDriveService googleDriveService;

        public UserChatsController(ApplicationDbContext context, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, IMapper mapper, IGoogleDriveService googleDriveService)
        {
            this.context = context;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
            this.googleDriveService = googleDriveService;
        }
/*        public async Task<IActionResult> Chat(string? userId)
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
                string jsonUrl = await googleDriveService.UploadUserChatFileAsync(chatFile);

                chat = new UserChat { CoachId = coachVM.Id, UserId = userVM.Id, ChatUrl = jsonUrl };
                await context.AddAsync(chat);
                await context.SaveChangesAsync();
            }
            else
            {
                // Jeśli plik istnieje, pobierz wiadomości
                var fileId = new Uri(chat.ChatUrl).Segments.Last();
                chatMessages = await googleDriveService.GetChatMessagesAsync(fileId);
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
        }*/
    }
}
