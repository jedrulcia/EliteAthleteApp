using EliteAthleteApp.Data;
using EliteAthleteApp.Contracts;
using Microsoft.Extensions.Azure;
using B2Net;
using Google.Apis.Util.Store;
using EliteAthleteApp.Models.UserChat;
using System.Text.Json;
using System.Text;

namespace EliteAthleteApp.Services
{
	public class BackblazeStorageService : IBackblazeStorageService
	{
		private readonly B2Client client;
		private readonly string backblazeApplicationKey;
		private readonly string keyId;
		private readonly string bucketId;

		public BackblazeStorageService(string backblazeApplicationKey, string keyId, string bucketId)
		{
			this.backblazeApplicationKey = backblazeApplicationKey;
			this.keyId = keyId;
			this.bucketId = bucketId;
			this.client = new B2Client(keyId, backblazeApplicationKey);
		}

		public async Task<string> UploadChatAsync(IFormFile chat, string chatName)
		{
			byte[] fileData;
			using (var memoryStream = new MemoryStream())
			{
				await chat.CopyToAsync(memoryStream);
				fileData = memoryStream.ToArray();
			}

			var file = await client.Files.Upload(fileData, chatName, bucketId);
			return file.FileId;
		}

		public async Task<List<UserChatMessageVM>> GetChatAsync(string fileId)
		{
			var file = await client.Files.DownloadById(fileId);
			string jsonContent = Encoding.UTF8.GetString(file.FileData);
			var userChatMessageVMs = JsonSerializer.Deserialize<List<UserChatMessageVM>>(jsonContent);
			return userChatMessageVMs;
		}
	}
}
