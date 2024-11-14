using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.Charts;
using Microsoft.AspNetCore.Identity;

namespace EliteAthleteApp.Services
{
	public class UserChartService : IUserChartService
	{
		private readonly ITrainingOrmRepository trainingOrmRepository;
		private readonly IUserBodyAnalysisRepository bodyAnalysisRepository;
		private readonly IUserBodyMeasurementsRepository bodyMeasurementsRepository;
		private readonly UserManager<User> userManager;
		private readonly IHttpContextAccessor httpContextAccessor;

		public UserChartService(ITrainingOrmRepository trainingOrmRepository, 
			IUserBodyAnalysisRepository bodyAnalysisRepository, 
			IUserBodyMeasurementsRepository bodyMeasurementsRepository, 
			UserManager<User> userManager,
			IHttpContextAccessor httpContextAccessor) 
		{
			this.trainingOrmRepository = trainingOrmRepository;
			this.bodyAnalysisRepository = bodyAnalysisRepository;
			this.bodyMeasurementsRepository = bodyMeasurementsRepository;
			this.userManager = userManager;
			this.httpContextAccessor = httpContextAccessor;
		}

		public async Task<UserChartsVM> GetUserCharts(string? userId)
		{
			if (userId == null)
			{
				userId = (await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)).Id;
			}
			var userChartsVM = new UserChartsVM();
			userChartsVM.TrainingOrmChartVM = await trainingOrmRepository.GetTrainingOrmChartVMAsync(userId);
			userChartsVM.UserBodyMeasurementsChartVM = await bodyMeasurementsRepository.GetUserBodyMeasurementsChartVMAsync(userId);
			userChartsVM.UserBodyAnalysisChartVM = await bodyAnalysisRepository.GetUserBodyAnalysisChartVMAsync(userId);

			return userChartsVM;
		}
	}
}
