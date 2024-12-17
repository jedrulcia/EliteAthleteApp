using EliteAthleteApp.Data;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Models.Home;
using EliteAthleteApp.Models.User;
using EliteAthleteApp.Services;
using Microsoft.AspNetCore.Http;

namespace EliteAthleteApp.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;
		private readonly UserManager<User> userManager;
		private readonly IGoogleDriveService googleDriveService;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IUserChartService userChartService;
		private readonly ITrainingPlanRepository trainingPlanRepository;

		public UserRepository(ApplicationDbContext context, 
			IMapper mapper, 
			UserManager<User> userManager, 
			IGoogleDriveService googleDriveService,
			IHttpContextAccessor httpContextAccessor,
			IUserChartService userChartService,
			ITrainingPlanRepository trainingPlanRepository) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
			this.userManager = userManager;
			this.googleDriveService = googleDriveService;
			this.httpContextAccessor = httpContextAccessor;
			this.userChartService = userChartService;
			this.trainingPlanRepository = trainingPlanRepository;
		}

		// UPLOADS IMAGE TO AZURE BLOB STORAGE AND SAVES URL IN USER MEDIA ENTITY
		public async Task UploadUserImageAsync(string userId, IFormFile imageFile)
		{
			if (imageFile != null && imageFile.Length > 0)
			{
				var user = await userManager.FindByIdAsync(userId);
				user.ImageUrl = await googleDriveService.UploadUserImageAsync(imageFile);
				await UpdateAsync(user);
			}
		}

		// REMOVES IMAGE FROM AZURE BLOB STORAGE AND URL FROM EXERCISE MEDIA ENTITY
		public async Task DeleteUserImageAsync(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			await googleDriveService.RemoveFileAsync(user.ImageUrl);
			user.ImageUrl = null;
			await UpdateAsync(user);
		}

		public async Task<HomeIndexVM> GetHomeIndexVMAsync()
		{
			var homeIndexVM = new HomeIndexVM();
			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			if (user != null)
			{
				homeIndexVM.UserVM = mapper.Map<UserVM>(user);
				homeIndexVM.UserChartsVM = await userChartService.GetUserCharts(user.Id);
				homeIndexVM.IsLoggedIn = true;
				homeIndexVM.TrainingPlanDetailsVM = await trainingPlanRepository.GetDailyTrainingPlanVMAsync(user.Id);
			}
			return homeIndexVM;
		}
	}
}
