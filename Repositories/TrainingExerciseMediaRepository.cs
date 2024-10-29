using EliteAthleteApp.Contracts.Repositories;
using EliteAthleteApp.Contracts.Services;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Repositories
{
	public class TrainingExerciseMediaRepository : GenericRepository<TrainingExerciseMedia>, ITrainingExerciseMediaRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IBlobStorageService blobStorageService;

		public TrainingExerciseMediaRepository(ApplicationDbContext context, IBlobStorageService blobStorageService) : base(context) 
		{
			this.context = context;
			this.blobStorageService = blobStorageService;
		}

		public async Task DeleteExerciseMediaAsync(int? trainingExerciseMediaId)
		{
			var trainingExerciseMedia = await GetAsync(trainingExerciseMediaId);
			await blobStorageService.RemoveExerciseImageAsync(trainingExerciseMedia.ImageUrlFirst);
			await blobStorageService.RemoveExerciseImageAsync(trainingExerciseMedia.ImageUrlSecond);
			await blobStorageService.RemoveExerciseImageAsync(trainingExerciseMedia.ImageUrlThird);
			await blobStorageService.RemoveExerciseVideoAsync(trainingExerciseMedia.VideoUrl);
			await DeleteAsync(trainingExerciseMediaId.Value);
		}
	}
}
