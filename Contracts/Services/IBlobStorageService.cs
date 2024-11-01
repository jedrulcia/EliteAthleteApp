namespace EliteAthleteApp.Contracts.Services
{
    public interface IBlobStorageService
    {
        // UPLOADS IMAGE TO EXERCISE BLOB STORAGE
        Task<string> UploadExerciseImageAsync(IFormFile file);

        // REMOVES IMAGE FROM EXERCISE BLOB STORAGE
        Task RemoveExerciseImageAsync(string? imageUrl);

		// UPLOADS VIDEO TO EXERCISE BLOB STORAGE
		Task<string> UploadExerciseVideoAsync(IFormFile file);

		// REMOVES VIDEO FROM EXERCISE BLOB STORAGE
		Task RemoveExerciseVideoAsync(string? videoUrl);

        Task<string> UploadUserImageAsync(IFormFile file);
        Task RemoveUserImageAsync(string? imageUrl);

		Task<string> UploadMedicalTestImageAsync(IFormFile file);
		Task RemoveMedicalTestImageAsync(string? imageUrl);

		Task<string> UploadBodyAnalysisImageAsync(IFormFile file);
		Task RemoveBodyAnalysisImageAsync(string? imageUrl);
	}
}
