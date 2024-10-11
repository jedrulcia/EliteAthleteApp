namespace TrainingPlanApp.Web.Contracts
{
	public interface IBlobStorageRepository
	{
		Task<string> UploadImageAsync(IFormFile file);
		Task RemoveImageAsync(string imageUrl);
		Task<bool> BlobExistsAsync(string blobName);
	}
}
