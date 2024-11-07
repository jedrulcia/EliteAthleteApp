using Azure.Storage.Blobs;
using EliteAthleteApp.Contracts.Services;
using EliteAthleteApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EliteAthleteApp.Models.User;

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
		var chat = await context.Set<UserChat>()
			.Where(uc => (uc.UserId == userId && uc.CoachId == coachId) || (uc.UserId == coachId && uc.CoachId == userId))
			.FirstOrDefaultAsync();

		if (chat == null)
			throw new InvalidOperationException("Chat does not exist or invalid chat");

		var blobClient = new BlobClient(new Uri(chat.ChatUrl));
		var stream = new MemoryStream();
		await blobClient.DownloadToAsync(stream);
		stream.Position = 0;
		var chatMessages = await JsonSerializer.DeserializeAsync<List<UserChatMessageVM>>(stream) ?? new List<UserChatMessageVM>();
		var timestamp = DateTime.UtcNow;

		var newMessage = new UserChatMessageVM
		{
			Timestamp = timestamp,
			UserId = senderId,
			Content = message
		};

		var formattedTimestamp = timestamp.ToString("HH:mm");

		chatMessages.Add(newMessage);

		string jsonContent = JsonSerializer.Serialize(chatMessages, new JsonSerializerOptions { WriteIndented = true });
		var updatedStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonContent));

		var chatFile = new FormFile(updatedStream, 0, updatedStream.Length, "chatFile", "chatFile.json");
		await blobStorageService.RemoveUserChatFileAsync(chat.ChatUrl);
		string jsonUrl = await blobStorageService.UploadUserChatFileAsync(chatFile);

		chat.ChatUrl = jsonUrl;
		await context.SaveChangesAsync();

		await Clients.User(userId).SendAsync("ReceiveMessage", message, senderId, formattedTimestamp);
		await Clients.User(coachId).SendAsync("ReceiveMessage", message, senderId, formattedTimestamp);
	}
}