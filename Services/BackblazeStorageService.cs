using EliteAthleteAppShared.Data;
using EliteAthleteAppShared.Contracts;
using Microsoft.Extensions.Azure;
using B2Net;
using Google.Apis.Util.Store;
using EliteAthleteAppShared.Models.UserChat;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace EliteAthleteAppShared.Services
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

		// CREATES/UPDATES THE CHAT IN THE BUTCKET - RETURNS CONNECTION KEY - GETS CHAT IN JSON FILE FORMAT AND CHAT NAME
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

		// GETS A CHAT CONVERTED INTO VIEW MODEL LIST
		public async Task<List<UserChatMessageVM>> GetChatAsync(string fileId)
		{
			var file = await client.Files.DownloadById(fileId);
			string jsonContent = Encoding.UTF8.GetString(file.FileData);
			return JsonSerializer.Deserialize<List<UserChatMessageVM>>(jsonContent);
		}
	}
}
