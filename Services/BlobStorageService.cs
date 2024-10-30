using Azure.Storage.Blobs;
using EliteAthleteApp.Contracts.Services;

namespace EliteAthleteApp.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient blobServiceClient;
        private readonly string blobContainerExerciseImage;
		private readonly string blobContainerExerciseVideo;

		public BlobStorageService(string blobConnectionString, string blobContainerExerciseImage, string blobContainerExerciseVideo)
        {
            this.blobServiceClient = new BlobServiceClient(blobConnectionString);
            this.blobContainerExerciseImage = blobContainerExerciseImage;
			this.blobContainerExerciseVideo = blobContainerExerciseVideo;
		}

		// EXERCISE IMAGES

		// UPLOADS IMAGE TO EXERCISE BLOB STORAGE
		public async Task<string> UploadExerciseImageAsync(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            string originalFileName = DateTime.Now.ToString("yyyy-MM-dd");
            string blobName = $"{originalFileName}_{fileExtension}";
            int counter = 0;

            var containerClient = blobServiceClient.GetBlobContainerClient(blobContainerExerciseImage);

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

		// REMOVES IMAGE FROM EXERCISE BLOB STORAGE
		public async Task RemoveExerciseImageAsync(string? imageUrl)
        {
			if (imageUrl != null)
			{
				int index = imageUrl.LastIndexOf('/');
				string blobName = imageUrl.Substring(index + 1);

				var containerClient = blobServiceClient.GetBlobContainerClient(blobContainerExerciseImage);
				var blobClient = containerClient.GetBlobClient(blobName);
				await blobClient.DeleteIfExistsAsync();
			}
        }

		// CHECKS IF EXERCISE IMAGE EXISTS IN BLOB STORAGE
		private async Task<bool> BlobExerciseImageExistsAsync(string blobName)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(blobContainerExerciseImage);
            try
            {
                return await containerClient.GetBlobClient(blobName).ExistsAsync();
            }
            catch
            {
                return false;
            }
		}

		// EXERCISE VIDEOS

		// UPLOADS VIDEO TO EXERCISE BLOB STORAGE
		public async Task<string> UploadExerciseVideoAsync(IFormFile file)
		{
			string fileExtension = Path.GetExtension(file.FileName);
			string originalFileName = DateTime.Now.ToString("yyyy-MM-dd");
			string blobName = $"{originalFileName}_{fileExtension}";
			int counter = 0;

			var containerClient = blobServiceClient.GetBlobContainerClient(blobContainerExerciseVideo);

			while (await BlobExerciseVideoExistsAsync(blobName))
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

		// REMOVES VIDEO FROM EXERCISE BLOB STORAGE
		public async Task RemoveExerciseVideoAsync(string? videoUrl)
		{
            if (videoUrl != null)
			{
				int index = videoUrl.LastIndexOf('/');
				string blobName = videoUrl.Substring(index + 1);

				var containerClient = blobServiceClient.GetBlobContainerClient(blobContainerExerciseVideo);
				var blobClient = containerClient.GetBlobClient(blobName);
				await blobClient.DeleteIfExistsAsync();
			}
		}

		// CHECKS IF EXERCISE VIDEO EXISTS IN BLOB STORAGE
		private async Task<bool> BlobExerciseVideoExistsAsync(string blobName)
		{
			var containerClient = blobServiceClient.GetBlobContainerClient(blobContainerExerciseVideo);
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
