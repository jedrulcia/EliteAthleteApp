using AutoMapper;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models;
using EliteAthleteApp.Models.Charts;
using EliteAthleteApp.Models.UserBodyMeasurements;
using EliteAthleteApp.Models.UserMedicalTest;

namespace EliteAthleteApp.Repositories
{
    public class UserBodyMeasurementsRepository : GenericRepository<UserBodyMeasurements>, IUserBodyMeasurementsRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public UserBodyMeasurementsRepository(ApplicationDbContext context, IMapper mapper) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
		}

		// GETS LIST OF USER BODY MEASUREMENTS
		public async Task<List<UserBodyMeasurementsVM>> GetUserBodyMeasurementsVMsAsync(string userId)
		{
			return mapper.Map<List<UserBodyMeasurementsVM>>((await GetAllAsync()).Where(tm => tm.UserId == userId));
		}

		// GETS USER BODY MEASUREMENTS CREATE VM
		public async Task<UserBodyMeasurementsCreateVM> GetUserBodyMeasurementCreateVM(string userId)
		{
			var formattedDate = DateTime.Now.ToString("yyyy-MM-dd");
			var userBm = (await GetAllAsync())
				.Where(ubm => ubm.UserId == userId && ubm.CreationDate.ToString("yyyy-MM-dd") == formattedDate)
				.FirstOrDefault();
			if (userBm != null)
			{
				return new UserBodyMeasurementsCreateVM { UserId = userId, CreatedToday = true };
			}

			return new UserBodyMeasurementsCreateVM { UserId = userId, CreatedToday = false };
		}

		// GETS USER BODY MEASUREMENTS EDIT VIEW MODEL
		public async Task<UserBodyMeasurementsCreateVM> GeUserBodyMeasurementEditVM(int bodyMeasurementId)
		{
			return mapper.Map<UserBodyMeasurementsCreateVM>(await GetAsync(bodyMeasurementId));
		}

		// GETS USER BODY MEASUREMENTS DELETE VIEW MODEL
		public async Task<UserBodyMeasurementsDeleteVM> GetUserBodyMeasurementDeleteVM(int bodyMeasurementId)
		{
			return mapper.Map<UserBodyMeasurementsDeleteVM>(await GetAsync(bodyMeasurementId));
		}
		
		// GETS UBM CHART VM
		public async Task<UserBodyMeasurementChartVM> GetUserBodyMeasurementsChartVMAsync(string userId)
		{
			var userBodyMeasurementVMs = (await GetUserBodyMeasurementsVMsAsync(userId)).OrderBy(t => t.DateTime).ToList();
			var userBodyMeasurementChartVM = new UserBodyMeasurementChartVM();

			foreach (var ubm in userBodyMeasurementVMs)
			{
				var date = ubm.DateTime;
				userBodyMeasurementChartVM.ChestDataPointVMs.Add(new DataPointVM { Date = date, Value = ubm.Chest });
				userBodyMeasurementChartVM.WaistDataPointVMs.Add(new DataPointVM { Date = date, Value = ubm.Waist });
				userBodyMeasurementChartVM.HipsDataPointVMs.Add(new DataPointVM { Date = date, Value = ubm.Hips });
				userBodyMeasurementChartVM.ArmsDataPointVMs.Add(new DataPointVM { Date = date, Value = ubm.Arms });
				userBodyMeasurementChartVM.ThighsDataPointVMs.Add(new DataPointVM { Date = date, Value = ubm.Thighs });
			}

			return userBodyMeasurementChartVM;
		}

		// CREATES NEW USER BODY MEASUREMENTS ENTITY
		public async Task CreateUserBodyMeasurementAsync(UserBodyMeasurementsCreateVM userBodyMeasurementCreateVM)
		{
			await AddAsync(mapper.Map<UserBodyMeasurements>(userBodyMeasurementCreateVM));
		}

		// EDITS EXSITING USER BODY MEASUREMENTS ENTITY
		public async Task EditUserBodyMeasurementAsync(UserBodyMeasurementsCreateVM userBodyMeasurementCreateVM)
		{
			await UpdateAsync(mapper.Map<UserBodyMeasurements>(userBodyMeasurementCreateVM));
		}

		// DELETES USER BODY MEASUREMENTS ENTITY
		public async Task DeleteUserBodyMeasurementAsync(UserBodyMeasurementsDeleteVM userBodyMeasurementDeleteVM)
		{
			await DeleteAsync(userBodyMeasurementDeleteVM.Id);
		}
	}
}
