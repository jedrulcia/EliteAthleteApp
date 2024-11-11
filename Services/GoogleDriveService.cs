using EliteAthleteApp.Contracts.Services;
using EliteAthleteApp.Models.User;
using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Util.Store;
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
	private readonly string googleFolderChatJson;

	public GoogleDriveService(
	string googleFolderUserImage,
	string googleFolderExerciseImage,
	string googleFolderExerciseVideo,
	string googleFolderMedicalTestImage,
	string googleFolderBodyAnalysisImage,
	string googleFolderChatJson)
	{
		// Użyj serializowanego JSON do utworzenia poświadczeń
		var credential = GoogleCredential.FromFile("C:\\Users\\Jedrulcia\\Desktop\\Jedrzej\\Programowanko\\github\\EliteAthleteApp\\googlecredentials.json")
										 .CreateScoped(DriveService.Scope.DriveFile);

		this.driveService = new DriveService(new Google.Apis.Services.BaseClientService.Initializer()
		{
			HttpClientInitializer = credential,
			ApplicationName = "GoogleDriveService"
		});

		// Inicjalizacja folderów
		this.googleFolderExerciseImage = googleFolderExerciseImage;
		this.googleFolderExerciseVideo = googleFolderExerciseVideo;
		this.googleFolderUserImage = googleFolderUserImage;
		this.googleFolderMedicalTestImage = googleFolderMedicalTestImage;
		this.googleFolderBodyAnalysisImage = googleFolderBodyAnalysisImage;
		this.googleFolderChatJson = googleFolderChatJson;
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

	// UPLOADS JSON TO USER CHAT BLOB STORAGE
	public async Task<string> UploadUserChatFileAsync(IFormFile file)
	{
		return await UploadFileAsync(file, googleFolderChatJson);
	}

	// REMOVES FILE FROM GOOGLE DRIVE BASED ON LINK
	public async Task RemoveFileAsync(string fileLink)
	{
		try
		{
			// Wyciąganie ID pliku z linku
			Uri uri = new Uri(fileLink);
			string fileId = uri.Segments.Last(); // Oczekujemy, że link będzie zawierał ID w końcowej części

			// Usuwanie pliku
			var request = driveService.Files.Delete(fileId);
			await request.ExecuteAsync();
		}
		catch (Exception ex)
		{
			throw new Exception($"Error removing file: {ex.Message}");
		}
	}

	// CHAT HANDLING
	public async Task<List<UserChatMessageVM>> GetChatMessagesAsync(string fileId)
	{
		var fileRequest = driveService.Files.Get(fileId);
		var stream = new MemoryStream();
		await fileRequest.DownloadAsync(stream);
		stream.Position = 0;

		return await JsonSerializer.DeserializeAsync<List<UserChatMessageVM>>(stream) ?? new List<UserChatMessageVM>();
	}

	// Aktualizowanie zawartości pliku na Google Drive
	public async Task<string> UploadUpdatedChatFileAsync(MemoryStream updatedStream, string fileId)
	{
		var fileMetadata = new File()
		{
			Name = "chatFile.json",
			Parents = new List<string> { "googleFolderChatJson" } // Replace with your actual folder ID
		};

		var request = driveService.Files.Update(fileMetadata, fileId, updatedStream, "application/json");
		request.Fields = "id";
		var uploadResult = await request.UploadAsync();

		if (uploadResult.Status != Google.Apis.Upload.UploadStatus.Completed)
		{
			throw new Exception("File upload failed.");
		}

		return request.ResponseBody.Id; // Return updated file ID
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

		if (fileResponse.Status != Google.Apis.Upload.UploadStatus.Completed)
		{
			throw new Exception("File upload failed.");
		}

		// Zwróć link do pliku
		return request.ResponseBody.WebViewLink;
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

public class GoogleCredentials
{
	public string Type { get; set; }
	public string ProjectId { get; set; }
	public string PrivateKeyId { get; set; }
	public string PrivateKey { get; set; }
	public string ClientEmail { get; set; }
	public string ClientId { get; set; }
	public string AuthUri { get; set; }
	public string TokenUri { get; set; }
	public string AuthProviderX509CertUrl { get; set; }
	public string ClientX509CertUrl { get; set; }
	public string UniverseDomain { get; set; }
}
