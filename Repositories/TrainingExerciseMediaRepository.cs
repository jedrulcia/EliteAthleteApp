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

		public async Task<TrainingExerciseMediaCreateVM> GetTrainingExerciseMediaEditVMAsync(int trainingExerciseMediaId)
		{
			// GET IMAGES AND VIDEO FROM BLOB SERVICE
			return mapper.Map<TrainingExerciseMediaCreateVM>(await GetAsync(trainingExerciseMediaId));
		}

		public async Task DeleteExerciseMediaAsync(int? trainingExerciseMediaId)
		{
			var trainingExerciseMedia = await GetAsync(trainingExerciseMediaId);
			// MAKE METHOD THAT REMOVES ALL OF THESE INSIDE OF BLOB SERVICE
			await blobStorageService.RemoveExerciseImageAsync(trainingExerciseMedia.ImageUrlFirst);
			await blobStorageService.RemoveExerciseImageAsync(trainingExerciseMedia.ImageUrlSecond);
			await blobStorageService.RemoveExerciseImageAsync(trainingExerciseMedia.ImageUrlThird);
			await blobStorageService.RemoveExerciseVideoAsync(trainingExerciseMedia.VideoUrl);
			await DeleteAsync(trainingExerciseMediaId.Value);
		}
	}
}
