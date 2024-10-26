namespace EliteAthleteApp.Contracts.Services
{
    public interface IBlobStorageService
    {
        // UPLOAD IMAGE TO THE AZURE BLOB STORAGE
        Task<string> UploadImageAsync(IFormFile file);

        // REMOVES IMAGE FROM THE AZURE BLOB STORAGE
        Task RemoveImageAsync(string imageUrl);

        // CHECKS IF BLOB EXSISTS IN THE STORAGE
        Task<bool> BlobExistsAsync(string blobName);
    }
}
