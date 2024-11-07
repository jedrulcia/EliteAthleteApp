using AutoMapper;
using EliteAthleteApp.Contracts.Repositories;
using EliteAthleteApp.Contracts.Services;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.TrainingOrm;
using EliteAthleteApp.Models.UserBodyAnalysis;
using Microsoft.AspNetCore.Identity;

namespace EliteAthleteApp.Repositories
{
	public class UserBodyAnalysisRepository : GenericRepository<UserBodyAnalysis>, IUserBodyAnalysisRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;
		private readonly IBlobStorageService blobStorageService;

		public UserBodyAnalysisRepository(ApplicationDbContext context, IMapper mapper, IBlobStorageService blobStorageService) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
			this.blobStorageService = blobStorageService;
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

		// CREATES NEW USER BODY ANALYSIS ENTITY
		public async Task CreateUserBodyAnalysisAsync(UserBodyAnalysisCreateVM userBodyAnalysisCreateVM, IFormFile? file)
		{
			if (file != null)
			{
				var fileUrl = await blobStorageService.UploadBodyAnalysisFileAsync(file);
				userBodyAnalysisCreateVM.FileUrl = fileUrl;
			}
			await AddAsync(mapper.Map<UserBodyAnalysis>(userBodyAnalysisCreateVM));
		}

		// EDITS EXSITING USER BODY ANALYSIS ENTITY
		public async Task EditUserBodyAnalysisAsync(UserBodyAnalysisCreateVM userBodyAnalysisCreateVM, IFormFile? file)
		{
			if (file != null)
			{
				var fileUrl = await blobStorageService.UploadBodyAnalysisFileAsync(file);
				userBodyAnalysisCreateVM.FileUrl = fileUrl;
			}
			await UpdateAsync(mapper.Map<UserBodyAnalysis>(userBodyAnalysisCreateVM));
		}

		// DELETES USER BODY ANALYSIS ENTITY
		public async Task DeleteUserBodyAnalysisAsync(UserBodyAnalysisDeleteVM userBodyAnalysisDeleteVM)
		{
			if (userBodyAnalysisDeleteVM.FileUrl != null)
			{
				await blobStorageService.RemoveBodyAnalysisFileAsync(userBodyAnalysisDeleteVM.FileUrl);
			}
			await DeleteAsync(userBodyAnalysisDeleteVM.Id);
		}
	}
}
