using Azure.Storage.Blobs;
using EliteAthleteApp.Contracts.Services;

namespace EliteAthleteApp.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient blobServiceClient;
        private readonly string blobContainerExerciseImage;
		private readonly string blobContainerExerciseVideo;
		private readonly string blobContainerUserImage;

		public BlobStorageService(string blobConnectionString, string blobContainerExerciseImage, string blobContainerExerciseVideo, string blobContainerUserImage)
        {
            this.blobServiceClient = new BlobServiceClient(blobConnectionString);
            this.blobContainerExerciseImage = blobContainerExerciseImage;
			this.blobContainerExerciseVideo = blobContainerExerciseVideo;
			this.blobContainerUserImage = blobContainerUserImage;
		}

		// EXERCISE IMAGES

		// UPLOADS IMAGE TO EXERCISE BLOB STORAGE
		public async Task<string> UploadExerciseImageAsync(IFormFile file)
        {
            return await UploadFileAsync(file, blobContainerExerciseImage);
		}

		// UPLOADS VIDEO TO EXERCISE BLOB STORAGE
		public async Task<string> UploadExerciseVideoAsync(IFormFile file)
		{
			return await UploadFileAsync(file, blobContainerExerciseVideo);
		}

		// UPLOADS IMAGE TO USER BLOB STORAGE
		public async Task<string> UploadUserImageAsync(IFormFile file)
		{
			return await UploadFileAsync(file, blobContainerUserImage);
		}

		// REMOVES IMAGE FROM EXERCISE BLOB STORAGE
		public async Task RemoveExerciseImageAsync(string? imageUrl)
        {
			await RemoveFileAsync(imageUrl, blobContainerExerciseImage);
		}

		// REMOVES VIDEO FROM EXERCISE BLOB STORAGE
		public async Task RemoveExerciseVideoAsync(string? videoUrl)
		{
			await RemoveFileAsync(videoUrl, blobContainerExerciseVideo);
		}

		// REMOVES IMAGE FROM USER BLOB STORAGE
		public async Task RemoveUserImageAsync(string? imageUrl)
		{
			await RemoveFileAsync(imageUrl, blobContainerUserImage);
		}

		// CHECKS IF EXERCISE IMAGE EXISTS IN BLOB STORAGE
		private async Task<bool> BlobExerciseImageExistsAsync(string blobName)
        {
			return await BlobFileExistsAsync(blobName, blobContainerExerciseImage);
		}

		// CHECKS IF EXERCISE VIDEO EXISTS IN BLOB STORAGE
		private async Task<bool> BlobExerciseVideoExistsAsync(string blobName)
		{
			return await BlobFileExistsAsync(blobName, blobContainerExerciseVideo);
		}

		// CHECKS IF EXERCISE VIDEO EXISTS IN BLOB STORAGE
		private async Task<bool> BlobUserImageExistsAsync(string blobName)
		{
			return await BlobFileExistsAsync(blobName, blobContainerUserImage);
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

			while (await BlobExerciseImageExistsAsync(blobName))
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
