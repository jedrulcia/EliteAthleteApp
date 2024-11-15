using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EliteAthleteApp.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using EliteAthleteApp.Contracts;
using Microsoft.AspNetCore.Identity;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.Home;
using AutoMapper;
using EliteAthleteApp.Models.User;

namespace EliteAthleteApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IUserChartService userChartService;
		private readonly UserManager<User> userManager;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IMapper mapper;
		private readonly ITrainingPlanRepository trainingPlanRepository;

		public HomeController(IUserChartService userChartService, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, IMapper mapper, ITrainingPlanRepository trainingPlanRepository)
		{
			this.userChartService = userChartService;
			this.userManager = userManager;
			this.httpContextAccessor = httpContextAccessor;
			this.mapper = mapper;
			this.trainingPlanRepository = trainingPlanRepository;
		}

		public async Task<IActionResult> Index()
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
			return View(homeIndexVM);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
