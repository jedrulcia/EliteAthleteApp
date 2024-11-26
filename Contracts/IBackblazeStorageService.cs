namespace EliteAthleteApp.Contracts
{
	public interface IBackblazeStorageService
	{
		Task<string> UploadNewChatAsync(IFormFile chat, string chatName); //- creates new chat in the bucket and returns connection key, gets a file in json format
		 // Task UploadUpdatedChat(IFormFile file) - updates an exsisting chat, gets a file in json format
		Task<IFormFile> GetChatAsync(string fileId); //- gets a chat using provided key that is stored in database
	}
}
