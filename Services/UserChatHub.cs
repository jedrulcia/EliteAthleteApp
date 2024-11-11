using EliteAthleteApp.Contracts.Services;
using EliteAthleteApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EliteAthleteApp.Models.User;
using Google.Apis.Drive.v3;

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

	public async Task SendMessage(string message, string userId, string coachId, string senderId)
	{
		var chat = await context.Set<UserChat>()
			.Where(uc => (uc.UserId == userId && uc.CoachId == coachId) || (uc.UserId == coachId && uc.CoachId == userId))
			.FirstOrDefaultAsync();

		if (chat == null)
			throw new InvalidOperationException("Chat does not exist or invalid chat");

		// Pobranie ID pliku z Google Drive
		string fileLink = chat.ChatUrl;
		var fileId = new Uri(fileLink).Segments.Last();

		// Pobranie zawartości pliku z Google Drive
		var chatMessages = await googleDriveService.GetChatMessagesAsync(fileId);
		var timestamp = DateTime.UtcNow;

		// Tworzenie nowej wiadomości
		var newMessage = new UserChatMessageVM
		{
			Timestamp = timestamp,
			UserId = senderId,
			Content = message
		};

		// Dodanie nowej wiadomości do listy
		chatMessages.Add(newMessage);

		// Formatowanie czasu
		var formattedTimestamp = timestamp.ToString("HH:mm");

		// Serializacja zaktualizowanej listy wiadomości
		string jsonContent = JsonSerializer.Serialize(chatMessages, new JsonSerializerOptions { WriteIndented = true });
		var updatedStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonContent));

		// Upload zaktualizowanego pliku do Google Drive
		string updatedFileLink = await googleDriveService.UploadUpdatedChatFileAsync(updatedStream, fileId);

		// Aktualizacja URL chatu w bazie danych
		chat.ChatUrl = updatedFileLink;
		await context.SaveChangesAsync();

		// Wysyłanie wiadomości do użytkownika i trenera
		await Clients.User(userId).SendAsync("ReceiveMessage", message, senderId, formattedTimestamp);
		await Clients.User(coachId).SendAsync("ReceiveMessage", message, senderId, formattedTimestamp);
	}
}