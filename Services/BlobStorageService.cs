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
		private readonly string blobContainerMedicalTestImage;
		private readonly string blobContainerBodyAnalysisImage;
		private readonly string blobContainerChatJson;

		public BlobStorageService(string blobConnectionString, 
			string blobContainerExerciseImage, 
			string blobContainerExerciseVideo, 
			string blobContainerUserImage, 
			string blobContainerMedicalTestImage, 
			string blobContainerBodyAnalysisImage,
			string blobContainerChatJson)
        {
            this.blobServiceClient = new BlobServiceClient(blobConnectionString);
            this.blobContainerExerciseImage = blobContainerExerciseImage;
			this.blobContainerExerciseVideo = blobContainerExerciseVideo;
			this.blobContainerUserImage = blobContainerUserImage;
			this.blobContainerMedicalTestImage = blobContainerMedicalTestImage;
			this.blobContainerBodyAnalysisImage = blobContainerBodyAnalysisImage;
			this.blobContainerChatJson = blobContainerChatJson;
		}

		// EXERCISE IMAGES

		// UPLOADS IMAGE TO EXERCISE BLOB STORAGE
		public async Task<string> UploadExerciseImageAsync(IFormFile file)
        {
            return await UploadFileAsync(file, blobContainerExerciseImage);
		}

		// REMOVES IMAGE FROM EXERCISE BLOB STORAGE
		public async Task RemoveExerciseImageAsync(string? imageUrl)
		{
			await RemoveFileAsync(imageUrl, blobContainerExerciseImage);
		}

		// UPLOADS VIDEO TO EXERCISE BLOB STORAGE
		public async Task<string> UploadExerciseVideoAsync(IFormFile file)
		{
			return await UploadFileAsync(file, blobContainerExerciseVideo);
		}

		// REMOVES VIDEO FROM EXERCISE BLOB STORAGE
		public async Task RemoveExerciseVideoAsync(string? videoUrl)
		{
			await RemoveFileAsync(videoUrl, blobContainerExerciseVideo);
		}

		// UPLOADS IMAGE TO USER BLOB STORAGE
		public async Task<string> UploadUserImageAsync(IFormFile file)
		{
			return await UploadFileAsync(file, blobContainerUserImage);
		}

		// REMOVES IMAGE FROM USER BLOB STORAGE
		public async Task RemoveUserImageAsync(string? imageUrl)
		{
			await RemoveFileAsync(imageUrl, blobContainerUserImage);
		}

		// UPLOADS IMAGE TO USER BLOB STORAGE
		public async Task<string> UploadMedicalTestFileAsync(IFormFile file)
		{
			return await UploadFileAsync(file, blobContainerMedicalTestImage);
		}

		// REMOVES IMAGE FROM USER BLOB STORAGE
		public async Task RemoveMedicalTestFileAsync(string? imageUrl)
		{
			await RemoveFileAsync(imageUrl, blobContainerMedicalTestImage);
		}

		// UPLOADS IMAGE TO USER BLOB STORAGE
		public async Task<string> UploadBodyAnalysisFileAsync(IFormFile file)
		{
			return await UploadFileAsync(file, blobContainerBodyAnalysisImage);
		}

		// REMOVES IMAGE FROM USER BLOB STORAGE
		public async Task RemoveBodyAnalysisFileAsync(string? imageUrl)
		{
			await RemoveFileAsync(imageUrl, blobContainerBodyAnalysisImage);
		}

		// UPLOADS JSON TO USER CHAT BLOB STORAGE
		public async Task<string> UploadUserChatFileAsync(IFormFile file)
		{
			return await UploadFileAsync(file, blobContainerChatJson);
		}

		public async Task RemoveUserChatFileAsync(string? fileUrl)
		{
			await RemoveFileAsync(fileUrl, blobContainerChatJson);
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
