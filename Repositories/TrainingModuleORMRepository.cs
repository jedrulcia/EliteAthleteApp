using EliteAthleteApp.Data;
using EliteAthleteApp.Contracts;
using AutoMapper;
using EliteAthleteApp.Models.TrainingModule;

namespace EliteAthleteApp.Repositories
{
	public class TrainingModuleORMRepository : GenericRepository<TrainingModuleORM>, ITrainingModuleORMRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public TrainingModuleORMRepository(ApplicationDbContext context, IMapper mapper) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<List<TrainingModuleORMVM>> GetTrainingModuleORMVMsAsync(string userId)
		{
			var trainingModuleORMs = (await GetAllAsync()).Where(tm => tm.UserId == userId);
			return mapper.Map<List<TrainingModuleORMVM>>(trainingModuleORMs);
		}

		public TrainingModuleORMCreateVM GetTrainingModuleORMCreateVM(string userId)
		{
			DateTime dateNow = DateTime.Now;
			DateTime modifiedDate = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 0, 0, 0);

			return new TrainingModuleORMCreateVM { DateTime = modifiedDate, UserId = userId };
		}

		// CREATES NEW ORM
		public async Task CreateORMAsync(TrainingModuleORMCreateVM trainingModuleORMCreateVM)
		{
			var trainingModuleORM = mapper.Map<TrainingModuleORM>(trainingModuleORMCreateVM);
			await AddAsync(trainingModuleORM);
		}
	}
}
