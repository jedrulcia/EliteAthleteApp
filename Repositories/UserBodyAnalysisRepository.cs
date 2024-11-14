using AutoMapper;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models;
using EliteAthleteApp.Models.Charts;
using EliteAthleteApp.Models.TrainingOrm;
using EliteAthleteApp.Models.UserBodyAnalysis;
using Microsoft.AspNetCore.Identity;

namespace EliteAthleteApp.Repositories
{
    public class UserBodyAnalysisRepository : GenericRepository<UserBodyAnalysis>, IUserBodyAnalysisRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;
		private readonly IGoogleDriveService googleDriveService;

		public UserBodyAnalysisRepository(ApplicationDbContext context, IMapper mapper, IGoogleDriveService googleDriveService) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
			this.googleDriveService = googleDriveService;
		}

		// GETS LIST OF USER BODY ANALYSIS
		public async Task<List<UserBodyAnalysisVM>> GetUserBodyAnalysisVMsAsync(string userId)
		{
			return mapper.Map<List<UserBodyAnalysisVM>>((await GetAllAsync()).Where(tm => tm.UserId == userId));
		}

		// GETS USER BODY ANALYSIS CREATE VM
		public async Task<UserBodyAnalysisCreateVM> GetUserBodyAnalysisCreateVM(string userId)
		{
			var formattedDate = DateTime.Now.ToString("yyyy-MM-dd");
			var userBa = (await GetAllAsync())
				.Where(uba => uba.UserId == userId && uba.CreationDate.ToString("yyyy-MM-dd") == formattedDate)
				.FirstOrDefault();
			if (userBa != null)
			{
				return new UserBodyAnalysisCreateVM { UserId = userId, CreatedToday = true };
			}

			return new UserBodyAnalysisCreateVM { UserId = userId, CreatedToday = false };
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

		// GETS UBA CHART VM
		public async Task<UserBodyAnalysisChartVM> GetUserBodyAnalysisChartVMAsync(string userId)
		{
			var userBodyAnalysisVMs = (await GetUserBodyAnalysisVMsAsync(userId)).OrderBy(t => t.DateTime).ToList();
			var userBodyAnalysisChartVM = new UserBodyAnalysisChartVM();

			foreach (var uba in userBodyAnalysisVMs)
			{
				var date = uba.DateTime;
				userBodyAnalysisChartVM.WeightDataPointVMs.Add(new DataPointVM { Date = date, Value = uba.Weight });
				userBodyAnalysisChartVM.FatPercentageDataPointVMs.Add(new DataPointVM { Date = date, Value = uba.FatPercentage });
				userBodyAnalysisChartVM.MusclePercentageDataPointVMs.Add(new DataPointVM { Date = date, Value = uba.MusclePercentage });
				userBodyAnalysisChartVM.WaterPercentageDataPointVMs.Add(new DataPointVM { Date = date, Value = uba.WaterPercentage });
			}

			return userBodyAnalysisChartVM;
		}

		// CREATES NEW USER BODY ANALYSIS ENTITY
		public async Task CreateUserBodyAnalysisAsync(UserBodyAnalysisCreateVM userBodyAnalysisCreateVM, IFormFile? file)
		{
			if (file != null)
			{
				var fileUrl = await googleDriveService.UploadBodyAnalysisFileAsync(file);
				userBodyAnalysisCreateVM.FileUrl = fileUrl;
			}
			await AddAsync(mapper.Map<UserBodyAnalysis>(userBodyAnalysisCreateVM));
		}

		// EDITS EXSITING USER BODY ANALYSIS ENTITY
		public async Task EditUserBodyAnalysisAsync(UserBodyAnalysisCreateVM userBodyAnalysisCreateVM, IFormFile? file)
		{
			if (file != null)
			{
				var fileUrl = await googleDriveService.UploadBodyAnalysisFileAsync(file);
				userBodyAnalysisCreateVM.FileUrl = fileUrl;
			}
			await UpdateAsync(mapper.Map<UserBodyAnalysis>(userBodyAnalysisCreateVM));
		}

		// DELETES USER BODY ANALYSIS ENTITY
		public async Task DeleteUserBodyAnalysisAsync(UserBodyAnalysisDeleteVM userBodyAnalysisDeleteVM)
		{
			if (userBodyAnalysisDeleteVM.FileUrl != null)
			{
				await googleDriveService.RemoveFileAsync(userBodyAnalysisDeleteVM.FileUrl);
			}
			await DeleteAsync(userBodyAnalysisDeleteVM.Id);
		}
	}
}
