using EliteAthleteApp.Data;
using EliteAthleteApp.Contracts;
using AutoMapper;
using EliteAthleteApp.Models.TrainingOrm;
using EliteAthleteApp.Models.Charts;
using EliteAthleteApp.Models.UserCharts;
using Microsoft.AspNetCore.Identity;

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
		public async Task<TrainingOrmCreateVM> GetTrainingOrmCreateVMAsync(string userId)
		{
			var formattedDate = DateTime.Now.ToString("yyyy-MM-dd");
			var trainingOrm = (await GetAllAsync())
				.Where(tm => tm.UserId == userId && tm.CreationDate.ToString("yyyy-MM-dd") == formattedDate)
				.FirstOrDefault();
			if (trainingOrm != null)
			{
				return new TrainingOrmCreateVM { UserId = userId, CreatedToday = true};
			}
			return new TrainingOrmCreateVM { UserId = userId};
		}

		// GETS TRAINING ORM EDIT VIEW MODEL
		public async Task<TrainingOrmCreateVM> GetTrainingOrmEditVMAsync(int trainingOrmId)
		{
			return mapper.Map<TrainingOrmCreateVM>(await GetAsync(trainingOrmId));
		}

		// GETS TRAINING ORM DELETE VIEW MODEL
		public async Task<TrainingOrmDeleteVM> GetTrainingOrmDeleteVMAsync(int trainingOrmId)
		{
			return mapper.Map<TrainingOrmDeleteVM>(await GetAsync(trainingOrmId));
		}

		// GETS TRAINING ORM CHART VM
		public async Task<TrainingOrmChartVM> GetTrainingOrmChartVMAsync(string userId)
		{
			var trainingOrmVMs = (await GetTrainingOrmVMsAsync(userId)).OrderBy(t => t.DateTime).ToList();
			var trainingOrmChartVM = new TrainingOrmChartVM();

			foreach (var orm in trainingOrmVMs)
			{
				var date = orm.DateTime;
				trainingOrmChartVM.BenchPressDataPointVMs.Add(new DataPointVM { Date = date, Value = orm.BenchPressOrm });
				trainingOrmChartVM.OverheadPressDataPointVMs.Add(new DataPointVM { Date = date, Value = orm.OverheadPressOrm });
				trainingOrmChartVM.DeadliftDataPointVMs.Add(new DataPointVM { Date = date, Value = orm.DeadliftOrm });
				trainingOrmChartVM.SquatDataPointVMs.Add(new DataPointVM { Date = date, Value = orm.SquatOrm });
			}

			return trainingOrmChartVM;
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
