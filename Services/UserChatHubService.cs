using EliteAthleteAppShared.Data;
using EliteAthleteAppShared.Models.UserChat;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EliteAthleteAppShared.Contracts;
using Microsoft.AspNetCore.Http;

public class UserChatHubService : Hub
{
	private readonly IBackblazeStorageService backblazeService;
	private readonly ApplicationDbContext context;
	private readonly UserManager<User> userManager;

	public UserChatHubService(IBackblazeStorageService backblazeService, ApplicationDbContext context, UserManager<User> userManager)
	{
		this.backblazeService = backblazeService;
		this.context = context;
		this.userManager = userManager;
	}

    public async Task SendMessage(string message, string userId, string coachId, string senderId)
    {
        var userChat = await context.Set<UserChat>()
            .Where(uc => (uc.UserId == userId && uc.CoachId == coachId) || (uc.UserId == coachId && uc.CoachId == userId))
            .FirstOrDefaultAsync();

        if (userChat == null)
            throw new InvalidOperationException("Chat does not exist or invalid chat");

        // Pobieranie zawartości pliku z Google Drive
        var chatMessages = await backblazeService.GetChatAsync(userChat.ChatUrl);

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
		var chatFile = new FormFile(updatedStream, 0, updatedStream.Length, "chatFile", "chatFile.json");
		var chatName = userId;
		var newChatId = await backblazeService.UploadChatAsync(chatFile, chatName);

        userChat.ChatUrl = newChatId;
        context.Update(userChat);
        context.SaveChanges();

        // Wysyłanie wiadomości do użytkowników
        var formattedTimestamp = newMessage.Timestamp.ToString("HH:mm");
        await Clients.User(userId).SendAsync("ReceiveMessage", message, senderId, formattedTimestamp);
        await Clients.User(coachId).SendAsync("ReceiveMessage", message, senderId, formattedTimestamp);
    }
}