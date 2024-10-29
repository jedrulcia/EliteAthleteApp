namespace EliteAthleteApp.Contracts.Services
{
    public interface IBlobStorageService
    {
        // UPLOAD IMAGE TO THE AZURE BLOB STORAGE
        Task<string> UploadExerciseImageAsync(IFormFile file);

        // REMOVES IMAGE FROM THE AZURE BLOB STORAGE
        Task RemoveExerciseImageAsync(string imageUrl);

        // CHECKS IF BLOB EXSISTS IN THE STORAGE
        Task<bool> BlobExerciseImageExistsAsync(string blobName);
    }
}
