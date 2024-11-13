using EliteAthleteApp.Data;
using EliteAthleteApp.Models.UserChat;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EliteAthleteApp.Models.User;
using Google.Apis.Drive.v3;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using EliteAthleteApp.Contracts;

public class UserChatHub : Hub
{
	private readonly IGoogleDriveService googleDriveService;
	private readonly ApplicationDbContext context;
	private readonly UserManager<User> userManager;

	public UserChatHub(IGoogleDriveService googleDriveService, ApplicationDbContext context, UserManager<User> userManager)
	{
		this.googleDriveService = googleDriveService;
		this.context = context;
		this.userManager = userManager;
	}

/*    public async Task SendMessage(string message, string userId, string coachId, string senderId)
    {
        var chat = await context.Set<UserChat>()
            .Where(uc => (uc.UserId == userId && uc.CoachId == coachId) || (uc.UserId == coachId && uc.CoachId == userId))
            .FirstOrDefaultAsync();

        if (chat == null)
            throw new InvalidOperationException("Chat does not exist or invalid chat");

        // Pobieranie zawartości pliku z Google Drive
        var fileId = new Uri(chat.ChatUrl).Segments.Last();
        var chatMessages = await googleDriveService.GetChatMessagesAsync(fileId);

        // Tworzenie nowej wiadomości
        var newMessage = new UserChatMessageVM
        {
            Timestamp = DateTime.UtcNow,
            UserId = senderId,
            Content = message
        };
        chatMessages.Add(newMessage);

        // Serializacja i aktualizacja pliku
        string jsonContent = JsonSerializer.Serialize(chatMessages, new JsonSerializerOptions { WriteIndented = true });
        var updatedStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonContent));
        await googleDriveService.UploadUpdatedChatFileAsync(updatedStream, fileId);

        // Wysyłanie wiadomości do użytkowników
        var formattedTimestamp = newMessage.Timestamp.ToString("HH:mm");
        await Clients.User(userId).SendAsync("ReceiveMessage", message, senderId, formattedTimestamp);
        await Clients.User(coachId).SendAsync("ReceiveMessage", message, senderId, formattedTimestamp);
    }*/
}