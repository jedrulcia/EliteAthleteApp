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
			return mapper.Map<List<TrainingOrmVM>>((await GetAllAsync()).Where(tm => tm.UserId == userId));
		}

		// GETS TRAINING ORM CREATE VIEW MODEL
		public TrainingOrmCreateVM GetTrainingOrmCreateVM(string userId)
		{
			DateTime dateNow = DateTime.Now;
			DateTime modifiedDate = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 0, 0, 0);

			return new TrainingOrmCreateVM { DateTime = modifiedDate, UserId = userId };
		}

		// GETS TRAINING ORM EDIT VIEW MODEL
		public async Task<TrainingOrmCreateVM> GetTrainingOrmEditVM(int trainingOrmId)
		{
			return mapper.Map<TrainingOrmCreateVM>(await GetAsync(trainingOrmId));
		}

		// GETS TRAINING ORM DELETE VIEW MODEL
		public async Task<TrainingOrmDeleteVM> GetTrainingOrmDeleteVM(int trainingOrmId)
		{
			return mapper.Map<TrainingOrmDeleteVM>(await GetAsync(trainingOrmId));
		}

		// CREATES NEW ORM ENTITY
		public async Task CreateOrmAsync(TrainingOrmCreateVM trainingOrmCreateVM)
		{
			await AddAsync(mapper.Map<TrainingOrm>(trainingOrmCreateVM));
		}

		public async Task EditOrmAsync(TrainingOrmCreateVM trainingOrmCreateVM)
		{
			await UpdateAsync(mapper.Map<TrainingOrm>(trainingOrmCreateVM));
		}

		public async Task DeleteOrmAsync(TrainingOrmDeleteVM trainingOrmDeleteVM)
		{
			await DeleteAsync(trainingOrmDeleteVM.Id);
		}
	}
}
