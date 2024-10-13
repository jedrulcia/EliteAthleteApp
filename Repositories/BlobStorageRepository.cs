using Azure.Storage.Blobs;
using TrainingPlanApp.Web.Contracts;

namespace TrainingPlanApp.Web.Repositories
{
	public class BlobStorageRepository : IBlobStorageRepository
	{
		private readonly BlobServiceClient blobServiceClient;
		private readonly string containerName;

		public BlobStorageRepository(string blobConnectionString, string containerName)
		{
			this.blobServiceClient = new BlobServiceClient(blobConnectionString);
			this.containerName = containerName;
		}

		// UPLOAD IMAGE TO THE AZURE BLOB STORAGE
		public async Task<string> UploadImageAsync(IFormFile file)
		{
			string fileExtension = Path.GetExtension(file.FileName);
			string originalFileName = DateTime.Now.ToString("yyyy-MM-dd");
			string blobName = $"{originalFileName}_{fileExtension}";
			int counter = 0;

			var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

			while (await BlobExistsAsync(blobName))
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

		// REMOVES IMAGE FROM THE AZURE BLOB STORAGE
		public async Task RemoveImageAsync(string imageUrl)
		{
			int index = imageUrl.LastIndexOf('/');
			string blobName = imageUrl.Substring(index + 1);

			var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
			var blobClient = containerClient.GetBlobClient(blobName);
			await blobClient.DeleteIfExistsAsync();
		}

		// CHECKS IF BLOB EXSISTS IN THE STORAGE
		public async Task<bool> BlobExistsAsync(string blobName)
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
