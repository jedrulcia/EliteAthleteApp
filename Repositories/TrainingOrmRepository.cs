using EliteAthleteApp.Data;
using EliteAthleteApp.Contracts;
using AutoMapper;
using EliteAthleteApp.Models.TrainingOrm;

namespace EliteAthleteApp.Repositories
{
    public class TrainingOrmRepository : GenericRepository<TrainingOrm>, ITrainingOrmRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public TrainingOrmRepository(ApplicationDbContext context, IMapper mapper) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
		}

		// GETS LIST OF TRAINING ORMs
		public async Task<List<TrainingOrmVM>> GetTrainingOrmVMsAsync(string userId)
		{
			var trainingOrms = (await GetAllAsync()).Where(tm => tm.UserId == userId);
			return mapper.Map<List<TrainingOrmVM>>(trainingOrms);
		}

		// GETS TRAINING ORM CREATE VM
		public TrainingOrmCreateVM GetTrainingOrmCreateVM(string userId)
		{
			DateTime dateNow = DateTime.Now;
			DateTime modifiedDate = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 0, 0, 0);

			return new TrainingOrmCreateVM { DateTime = modifiedDate, UserId = userId };
		}

		// CREATES NEW ORM ENTITY
		public async Task CreateOrmAsync(TrainingOrmCreateVM trainingOrmCreateVM)
		{
			var trainingORM = mapper.Map<TrainingOrm>(trainingOrmCreateVM);
			await AddAsync(trainingORM);
		}
	}
}
