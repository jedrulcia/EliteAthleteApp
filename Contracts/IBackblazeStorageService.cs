using EliteAthleteApp.Models.UserChat;

namespace EliteAthleteApp.Contracts
{
	public interface IBackblazeStorageService
	{
		// CREATES/UPDATES THE CHAT IN THE BUTCKET - RETURNS CONNECTION KEY - GETS CHAT IN JSON FILE FORMAT AND CHAT NAME
		Task<string> UploadChatAsync(IFormFile chat, string chatName);

		// GETS A CHAT CONVERTED INTO VIEW MODEL LIST
		Task<List<UserChatMessageVM>> GetChatAsync(string chatId);
	}
}
