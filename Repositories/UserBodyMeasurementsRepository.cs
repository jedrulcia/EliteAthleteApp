using AutoMapper;
using EliteAthleteApp.Contracts.Repositories;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.UserBodyMeasurements;

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
		public UserBodyMeasurementsCreateVM GetUserBodyMeasurementCreateVM(string userId)
		{
			DateTime dateNow = DateTime.Now;
			DateTime modifiedDate = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 0, 0, 0);

			return new UserBodyMeasurementsCreateVM { DateTime = modifiedDate, UserId = userId };
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
