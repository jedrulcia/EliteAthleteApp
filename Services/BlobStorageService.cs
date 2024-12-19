using Azure.Storage.Blobs;
using EliteAthleteAppShared.Contracts;
using Microsoft.AspNetCore.Http;

namespace EliteAthleteAppShared.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient blobServiceClient;
        private readonly string blobContainer;

		public BlobStorageService(string blobConnectionString, 
			string blobContainer)
        {
            this.blobServiceClient = new BlobServiceClient(blobConnectionString);
            this.blobContainer = blobContainer;
		}

		// UPLOADS IMAGE TO EXERCISE BLOB STORAGE
		public async Task<string> UploadImageAsync(IFormFile file)
		{
			return await UploadFileAsync(file, blobContainer);
		}

		// REMOVES IMAGE FROM EXERCISE BLOB STORAGE
		public async Task RemoveImageAsync(string? imageUrl)
		{
			await RemoveFileAsync(imageUrl, blobContainer);
		}

		// PRIVATE METHODS BELOW

		// UPLOADS FILE TO BLOB STORAGE
		private async Task<string> UploadFileAsync(IFormFile file, string containerName)
		{
			string fileExtension = Path.GetExtension(file.FileName);
			string originalFileName = DateTime.Now.ToString("yyyy-MM-dd");
			string blobName = $"{originalFileName}_{fileExtension}";
			int counter = 0;

			var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

			while (await BlobFileExistsAsync(blobName, containerName))
			{
				blobName = $"{originalFileName}_{counter}{fileExtension}";
				counter++;
			}

			var blobClient = containerClient.GetBlobClient(blobName);
			await using (var data = file.OpenReadStream())
			{
				await blobClient.UploadAsync(data);
			}

			return blobClient.Uri.AbsoluteUri;
		}

		// REMOVES FILE FROM BLOB STORAGE
		private async Task RemoveFileAsync(string? imageUrl, string containerName)
		{
			if (imageUrl != null)
			{
				int index = imageUrl.LastIndexOf('/');
				string blobName = imageUrl.Substring(index + 1);

				var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
				var blobClient = containerClient.GetBlobClient(blobName);
				await blobClient.DeleteIfExistsAsync();
			}
		}

		// CHECKS IF FILE EXSISTS IN BLOB STORAGE
		private async Task<bool> BlobFileExistsAsync(string blobName, string containerName)
		{
			var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
			try
			{
				return await containerClient.GetBlobClient(blobName).ExistsAsync();
			}
			catch
			{
				return false;
			}
		}
	}
}
