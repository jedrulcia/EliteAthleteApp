using AutoMapper;
using EliteAthleteApp.Contracts.Repositories;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.UserMedicalTest;

namespace EliteAthleteApp.Repositories
{
	public class UserMedicalTestRepository : GenericRepository<UserMedicalTest>, IUserMedicalTestRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public UserMedicalTestRepository(ApplicationDbContext context, IMapper mapper) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
		}

		// GETS LIST OF USER BODY MEASUREMENTS
		public async Task<List<UserMedicalTestVM>> GetUserMedicalTestVMsAsync(string userId)
		{
			return mapper.Map<List<UserMedicalTestVM>>((await GetAllAsync()).Where(tm => tm.UserId == userId));
		}

		// GETS USER BODY MEASUREMENTS CREATE VM
		public UserMedicalTestCreateVM GetUserMedicalTestCreateVM(string userId)
		{
			DateTime dateNow = DateTime.Now;
			DateTime modifiedDate = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 0, 0, 0);

			return new UserMedicalTestCreateVM { DateTime = modifiedDate, UserId = userId };
		}

		// GETS USER BODY MEASUREMENTS EDIT VIEW MODEL
		public async Task<UserMedicalTestCreateVM> GeUserMedicalTestEditVM(int medicalTestId)
		{
			return mapper.Map<UserMedicalTestCreateVM>(await GetAsync(medicalTestId));
		}

		// GETS USER BODY MEASUREMENTS DELETE VIEW MODEL
		public async Task<UserMedicalTestDeleteVM> GetUserMedicalTestDeleteVM(int medicalTestId)
		{
			return mapper.Map<UserMedicalTestDeleteVM>(await GetAsync(medicalTestId));
		}

		// CREATES NEW USER BODY MEASUREMENTS ENTITY
		public async Task CreateUserMedicalTestAsync(UserMedicalTestCreateVM userMedicalTestCreateVM)
		{
			await AddAsync(mapper.Map<UserMedicalTest>(userMedicalTestCreateVM));
		}

		// EDITS EXSITING USER BODY MEASUREMENTS ENTITY
		public async Task EditUserMedicalTestAsync(UserMedicalTestCreateVM userMedicalTestCreateVM)
		{
			await UpdateAsync(mapper.Map<UserMedicalTest>(userMedicalTestCreateVM));
		}

		// DELETES USER BODY MEASUREMENTS ENTITY
		public async Task DeleteUserMedicalTestAsync(UserMedicalTestDeleteVM userMedicalTestDeleteVM)
		{
			await DeleteAsync(userMedicalTestDeleteVM.Id);
		}
	}
}
