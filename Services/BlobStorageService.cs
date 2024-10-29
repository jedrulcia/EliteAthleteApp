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

        // UPLOAD EXERCISE IMAGE TO THE AZURE BLOB STORAGE
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

        // REMOVES IMAGE FROM THE AZURE BLOB STORAGE
        public async Task RemoveExerciseImageAsync(string imageUrl)
        {
            int index = imageUrl.LastIndexOf('/');
            string blobName = imageUrl.Substring(index + 1);

            var containerClient = blobServiceClient.GetBlobContainerClient(blobContainerExerciseImage);
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.DeleteIfExistsAsync();
        }

        // CHECKS IF BLOB EXSISTS IN THE STORAGE
        public async Task<bool> BlobExerciseImageExistsAsync(string blobName)
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
    }
}
