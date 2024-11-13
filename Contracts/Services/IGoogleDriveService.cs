using EliteAthleteApp.Models.UserChat;

namespace EliteAthleteApp.Contracts.Services
{
    public interface IGoogleDriveService
	{
		// UPLOADS IMAGE TO GOOGLE DRIVE
		Task<string> UploadExerciseImageAsync(IFormFile file);

		// UPLOADS VIDEO TO GOOGLE DRIVE
		Task<string> UploadExerciseVideoAsync(IFormFile file);

		// UPLOADS IMAGE TO GOOGLE DRIVE
		Task<string> UploadUserImageAsync(IFormFile file);

		// UPLOADS IMAGE TO GOOGLE DRIVE
		Task<string> UploadMedicalTestFileAsync(IFormFile file);

		// UPLOADS IMAGE TO GOOGLE DRIVE
		Task<string> UploadBodyAnalysisFileAsync(IFormFile file);

		// REMOVES FILE FROM GOOGLE DRIVE
		Task RemoveFileAsync(string fileLink);
	}
}
