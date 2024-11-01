using AutoMapper;
using EliteAthleteApp.Contracts.Repositories;
using EliteAthleteApp.Contracts.Services;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.TrainingExercise;

namespace EliteAthleteApp.Repositories
{
	public class TrainingExerciseMediaRepository : GenericRepository<TrainingExerciseMedia>, ITrainingExerciseMediaRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IBlobStorageService blobStorageService;
		private readonly IMapper mapper;

		public TrainingExerciseMediaRepository(ApplicationDbContext context, IBlobStorageService blobStorageService, IMapper mapper) : base(context) 
		{
			this.context = context;
			this.blobStorageService = blobStorageService;
			this.mapper = mapper;
		}

		// GETS TRAINING EXERCISE MEDIA CREATE VIEW MODEL
		public async Task<TrainingExerciseMediaCreateVM> GetTrainingExerciseMediaCreateVMAsync(int exerciseMediaId)
		{
			return mapper.Map<TrainingExerciseMediaCreateVM>(await GetAsync(exerciseMediaId));
		}

		// UPLOADS IMAGE TO AZURE BLOB STORAGE AND SAVES URL IN EXERCISE MEDIA ENTITY
		public async Task UploadImageAsync(int id, int index, IFormFile imageFile)
		{
			if (imageFile != null && imageFile.Length > 0)
			{
				var trainingExerciseMedia = await GetAsync(id);
				trainingExerciseMedia.ImageUrls[index] = await blobStorageService.UploadExerciseImageAsync(imageFile);
				await UpdateAsync(trainingExerciseMedia);
			}
		}

		// UPLOADS VIDEO TO AZURE BLOB STORAGE AND SAVES URL IN EXERCISE MEDIA ENTITY
		public async Task UploadVideoAsync(int id, IFormFile videoFile)
		{
			if (videoFile != null && videoFile.Length > 0)
			{
				var trainingExerciseMedia = await GetAsync(id);
				trainingExerciseMedia.VideoUrl = await blobStorageService.UploadExerciseVideoAsync(videoFile);
				await UpdateAsync(trainingExerciseMedia);
			}
		}

		// REMOVES IMAGE FROM AZURE BLOB STORAGE AND URL FROM EXERCISE MEDIA ENTITY
		public async Task DeleteImageAsync(int id, int index)
		{
			var trainingExerciseMedia = await GetAsync(id);
			await blobStorageService.RemoveExerciseImageAsync(trainingExerciseMedia.ImageUrls[index]);
			trainingExerciseMedia.ImageUrls[index] = null;
			await UpdateAsync(trainingExerciseMedia);
		}

		// REMOVES VIDEO FROM AZURE BLOB STORAGE AND URL FROM EXERCISE MEDIA ENTITY
		public async Task DeleteVideoAsync(int id)
		{
			var trainingExerciseMedia = await GetAsync(id);
			await blobStorageService.RemoveExerciseImageAsync(trainingExerciseMedia.VideoUrl);
			trainingExerciseMedia.VideoUrl = null;
			await UpdateAsync(trainingExerciseMedia);
		}

		// REMOVES URL OF DELETED EXERCISE AND EXERCISE MEDIA ENTITY
		public async Task DeleteExerciseMediaAsync(int? trainingExerciseMediaId)
		{
			var trainingExerciseMedia = await GetAsync(trainingExerciseMediaId);
			foreach (var imageUrl in trainingExerciseMedia.ImageUrls)
			{
				await blobStorageService.RemoveExerciseImageAsync(imageUrl);
			}
			await blobStorageService.RemoveExerciseVideoAsync(trainingExerciseMedia.VideoUrl);
			await DeleteAsync(trainingExerciseMediaId.Value);
		}
	}
}
