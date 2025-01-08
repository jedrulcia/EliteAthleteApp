using EliteAthleteAppShared.Contracts;
using EliteAthleteAppShared.Models.UserChat;
using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using File = Google.Apis.Drive.v3.Data.File;
using JsonSerializer = System.Text.Json.JsonSerializer;

public class GoogleDriveService : IGoogleDriveService
{
	private readonly DriveService driveService;
	private readonly string googleFolderExerciseImage;
	private readonly string googleFolderExerciseVideo;
	private readonly string googleFolderUserImage;
	private readonly string googleFolderMedicalTestImage;
	private readonly string googleFolderBodyAnalysisImage;

	public GoogleDriveService(
	string googleFolderUserImage,
	string googleFolderExerciseImage,
	string googleFolderExerciseVideo,
	string googleFolderMedicalTestImage,
	string googleFolderBodyAnalysisImage)
	{

        // Użyj serializowanego JSON do utworzenia poświadczeń
        var credential = GoogleCredential.FromFile("C:\\Users\\Jedrulcia\\Desktop\\Jedrzej\\Programowanko\\github\\EliteAthleteApp\\googlecredentials.json")
                                         .CreateScoped(DriveService.Scope.DriveFile);

        this.driveService = new DriveService(new Google.Apis.Services.BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "GoogleDriveService"
        });
        this.googleFolderExerciseImage = googleFolderExerciseImage;
		this.googleFolderExerciseVideo = googleFolderExerciseVideo;
		this.googleFolderUserImage = googleFolderUserImage;
		this.googleFolderMedicalTestImage = googleFolderMedicalTestImage;
		this.googleFolderBodyAnalysisImage = googleFolderBodyAnalysisImage;
	}

	// UPLOADS IMAGE TO EXERCISE BLOB STORAGE
	public async Task<string> UploadExerciseImageAsync(IFormFile file)
	{
		return await UploadFileAsync(file, googleFolderExerciseImage);
	}

	// UPLOADS VIDEO TO EXERCISE BLOB STORAGE
	public async Task<string> UploadExerciseVideoAsync(IFormFile file)
	{
		return await UploadFileAsync(file, googleFolderExerciseVideo);
	}

	// UPLOADS IMAGE TO USER BLOB STORAGE
	public async Task<string> UploadUserImageAsync(IFormFile file)
	{
		return await UploadFileAsync(file, googleFolderUserImage);
	}

	// UPLOADS IMAGE TO USER BLOB STORAGE
	public async Task<string> UploadMedicalTestFileAsync(IFormFile file)
	{
		return await UploadFileAsync(file, googleFolderMedicalTestImage);
	}

	// UPLOADS IMAGE TO USER BLOB STORAGE
	public async Task<string> UploadBodyAnalysisFileAsync(IFormFile file)
	{
		return await UploadFileAsync(file, googleFolderBodyAnalysisImage);
	}

	// REMOVES FILE FROM GOOGLE DRIVE BASED ON LINK
	public async Task RemoveFileAsync(string fileId)
	{
		try
		{
			// Usuwanie pliku
			var request = driveService.Files.Delete(fileId);
			await request.ExecuteAsync();
		}
		catch (Exception ex)
		{
			throw new Exception($"Error removing file: {ex.Message}");
		}
	}

	// PRIVATE METHODS BELOW

	// UPLOADS FILE TO GOOGLE DRIVE
	private async Task<string> UploadFileAsync(IFormFile file, string folderId)
	{
		string fileExtension = Path.GetExtension(file.FileName);
		string originalFileName = DateTime.Now.ToString("yyyy-MM-dd");
		string fileName = $"{originalFileName}{fileExtension}";
		int counter = 0;

		// Tworzenie metadanych pliku
		var fileMetadata = new Google.Apis.Drive.v3.Data.File()
		{
			Name = fileName,
			Parents = new List<string> { folderId }
		};

		// Sprawdzenie, czy plik o tej samej nazwie już istnieje w folderze
		while (await FileExistsAsync(fileName, folderId))
		{
			counter++;
			fileName = $"{originalFileName}_{counter}{fileExtension}";
			fileMetadata.Name = fileName; // Zaktualizuj nazwę w metadanych
		}

		// Upload pliku na Google Drive
		var fileStream = file.OpenReadStream();
		var request = driveService.Files.Create(fileMetadata, fileStream, file.ContentType);
		request.Fields = "id, webViewLink"; // Zwróć zarówno ID jak i link do pliku
		var fileResponse = await request.UploadAsync();


		var permission = new Permission
		{
			Type = "anyone",
			Role = "reader"
		};

		// Dodanie uprawnienia do pliku
		await driveService.Permissions.Create(permission, request.ResponseBody.Id).ExecuteAsync();

		if (fileResponse.Status != Google.Apis.Upload.UploadStatus.Completed)
		{
			throw new Exception("File upload failed.");
		}

		// Zwróć link do pliku
		return request.ResponseBody.Id;
	}

	// CHECKS IF FILE EXISTS IN GOOGLE DRIVE
	private async Task<bool> FileExistsAsync(string fileName, string folderId)
	{
		try
		{
			// Wyszukiwanie plików w danym folderze na podstawie nazwy
			var request = driveService.Files.List();
			request.Q = $"name = '{fileName}' and '{folderId}' in parents"; // Zapytanie, które szuka pliku w folderze o tej samej nazwie
			request.Fields = "files(id)"; // Chcemy tylko ID pliku

			var result = await request.ExecuteAsync();

			// Jeśli znajdziesz jakikolwiek plik o tej samej nazwie, zwróć true
			return result.Files != null && result.Files.Count > 0;
		}
		catch (Exception)
		{
			// Obsługuje wszelkie wyjątki (np. problemy z połączeniem lub błędy Google API)
			return false;
		}
	}
}
