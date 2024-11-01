using AutoMapper;
using EliteAthleteApp.Contracts.Repositories;
using EliteAthleteApp.Contracts.Services;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.UserBodyAnalysis;
using Microsoft.AspNetCore.Identity;

namespace EliteAthleteApp.Repositories
{
	public class UserBodyAnalysisRepository : GenericRepository<UserBodyAnalysis>, IUserBodyAnalysisRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public UserBodyAnalysisRepository(ApplicationDbContext context, IMapper mapper) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
		}

		// GETS LIST OF USER BODY ANALYSIS
		public async Task<List<UserBodyAnalysisVM>> GetUserBodyAnalysisVMsAsync(string userId)
		{
			return mapper.Map<List<UserBodyAnalysisVM>>((await GetAllAsync()).Where(tm => tm.UserId == userId));
		}

		// GETS USER BODY ANALYSIS CREATE VM
		public UserBodyAnalysisCreateVM GetUserBodyAnalysisCreateVM(string userId)
		{
			DateTime dateNow = DateTime.Now;
			DateTime modifiedDate = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 0, 0, 0);

			return new UserBodyAnalysisCreateVM { DateTime = modifiedDate, UserId = userId };
		}

		// GETS USER BODY ANALYSIS EDIT VIEW MODEL
		public async Task<UserBodyAnalysisCreateVM> GeUserBodyAnalysisEditVM(int bodyAnalysisId)
		{
			return mapper.Map<UserBodyAnalysisCreateVM>(await GetAsync(bodyAnalysisId));
		}

		// GETS USER BODY ANALYSIS DELETE VIEW MODEL
		public async Task<UserBodyAnalysisDeleteVM> GetUserBodyAnalysisDeleteVM(int bodyAnalysisId)
		{
			return mapper.Map<UserBodyAnalysisDeleteVM>(await GetAsync(bodyAnalysisId));
		}

		// CREATES NEW USER BODY ANALYSIS ENTITY
		public async Task CreateUserBodyAnalysisAsync(UserBodyAnalysisCreateVM userBodyAnalysisCreateVM)
		{
			await AddAsync(mapper.Map<UserBodyAnalysis>(userBodyAnalysisCreateVM));
		}

		// EDITS EXSITING USER BODY ANALYSIS ENTITY
		public async Task EditUserBodyAnalysisAsync(UserBodyAnalysisCreateVM userBodyAnalysisCreateVM)
		{
			await UpdateAsync(mapper.Map<UserBodyAnalysis>(userBodyAnalysisCreateVM));
		}

		// DELETES USER BODY ANALYSIS ENTITY
		public async Task DeleteUserBodyAnalysisAsync(UserBodyAnalysisDeleteVM userBodyAnalysisDeleteVM)
		{
			await DeleteAsync(userBodyAnalysisDeleteVM.Id);
		}
	}
}
