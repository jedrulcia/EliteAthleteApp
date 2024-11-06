using Azure.Storage.Blobs;
using EliteAthleteApp.Contracts.Services;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.UserChat;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;

public class UserChatHub : Hub
{
	private readonly IBlobStorageService blobStorageService;
	private readonly ApplicationDbContext context;
	private readonly UserManager<User> userManager;

	public UserChatHub(IBlobStorageService blobStorageService, ApplicationDbContext context, UserManager<User> userManager)
	{
		this.blobStorageService = blobStorageService;
		this.context = context;
		this.userManager = userManager;
	}

	public async Task SendMessage(string message, string userId, string coachId, string senderId)
	{
		// Pobierz chat na podstawie userId i coachId
		var chat = await context.Set<UserChat>()
			.Where(uc => (uc.UserId == userId && uc.CoachId == coachId) || (uc.UserId == coachId && uc.CoachId == userId))
			.FirstOrDefaultAsync();

		if (chat == null)
			throw new InvalidOperationException("Chat does not exist or invalid chat");

		// Pobierz istniejące wiadomości z Azure Blob Storage
		var blobClient = new BlobClient(new Uri(chat.ChatUrl));
		var stream = new MemoryStream();
		await blobClient.DownloadToAsync(stream);
		stream.Position = 0;
		var chatMessages = await JsonSerializer.DeserializeAsync<List<UserChatMessageVM>>(stream) ?? new List<UserChatMessageVM>();
		var timestamp = DateTime.UtcNow;

		// Tworzenie nowej wiadomości
		var newMessage = new UserChatMessageVM
		{
			Timestamp = timestamp,
			UserId = senderId,
			Content = message
		};

		// Dodaj nową wiadomość do listy
		chatMessages.Add(newMessage);

		// Zserializuj zaktualizowane wiadomości do JSON
		string jsonContent = JsonSerializer.Serialize(chatMessages, new JsonSerializerOptions { WriteIndented = true });
		var updatedStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonContent));

		// Prześlij zaktualizowany plik do Azure Blob Storage
		var chatFile = new FormFile(updatedStream, 0, updatedStream.Length, "chatFile", "chatFile.json");
		string jsonUrl = await blobStorageService.UploadUserChatFileAsync(chatFile);

		// Zaktualizuj adres URL w bazie danych
		chat.ChatUrl = jsonUrl;
		await context.SaveChangesAsync();

		// Powiadomienie wszystkich klientów o nowej wiadomości
		await Clients.User(userId).SendAsync("ReceiveMessage", message, userId, timestamp);
		await Clients.User(coachId).SendAsync("ReceiveMessage", message, userId, timestamp);
	}
}