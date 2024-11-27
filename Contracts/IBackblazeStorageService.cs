using EliteAthleteApp.Models.UserChat;

namespace EliteAthleteApp.Contracts
{
	public interface IBackblazeStorageService
	{
		Task<string> UploadChatAsync(IFormFile chat, string chatName); //- creates new chat in the bucket and returns connection key, gets a file in json format
		Task<List<UserChatMessageVM>> GetChatAsync(string chatId); //- gets a chat using provided key that is stored in database
	}
}
