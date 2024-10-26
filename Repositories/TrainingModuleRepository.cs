using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.TrainingModule;
using EliteAthleteApp.Models.TrainingPlan;

namespace EliteAthleteApp.Repositories
{
	public class TrainingModuleRepository : GenericRepository<TrainingModule>, ITrainingModuleRepository
	{
		private readonly IMapper mapper;
		private readonly ITrainingPlanRepository trainingPlanRepository;
		private readonly UserManager<User> userManager;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly ITrainingModuleORMRepository trainingModuleORMRepository;
		private readonly ApplicationDbContext context;
		public TrainingModuleRepository(ApplicationDbContext context, 
			IMapper mapper, 
			ITrainingPlanRepository trainingPlanRepository, 
			UserManager<User> userManager, 
			IHttpContextAccessor httpContextAccessor,
			ITrainingModuleORMRepository trainingModuleORMRepository) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
			this.trainingPlanRepository = trainingPlanRepository;
			this.userManager = userManager;
			this.httpContextAccessor = httpContextAccessor;
			this.trainingModuleORMRepository = trainingModuleORMRepository;
		}

		// GETS TRAINING MODULE INDEX VIEW MODEL FOR A SPECIFIC USER.
		public async Task<TrainingModuleIndexVM> GetTrainingModuleIndexVMAsync(string? userId)
		{
			var user = new User();
			if (userId == null)
			{
				user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
				userId = user.Id;
			}
			else
			{
				user = await userManager.FindByIdAsync(userId);
			}
			var coach = await userManager.FindByIdAsync(user.CoachId);

			return new TrainingModuleIndexVM{ UserId = userId, CoachId = coach.Id }; 
		}

		public async Task<List<TrainingModuleVM>> GetTrainingModuleVMsAsync(string userId)
		{
			var trainingModules = (await GetAllAsync()).Where(x => x.UserId == userId);
			return mapper.Map<List<TrainingModuleVM>>(trainingModules);
		}

		public TrainingModuleCreateVM GetTrainingModuleCreateVM(string userId, string coachId)
		{
			return new TrainingModuleCreateVM { UserId = userId, CoachId = coachId };
		}

		public async Task<TrainingModuleCreateVM> GetTrainingModuleEditVMAsync(int trainingModuleId)
		{
			var trainingModule = await GetAsync(trainingModuleId);
			return mapper.Map<TrainingModuleCreateVM>(trainingModule);
		}

		public async Task<TrainingModuleDeleteVM> GetTrainingModuleDeleteVM(int trainingModuleId)
		{
			return mapper.Map<TrainingModuleDeleteVM>(await GetAsync(trainingModuleId));
		}

		// CREATES A NEW TRAINING MODULE
		public async Task CreateTrainingModuleAsync(TrainingModuleCreateVM trainingModuleCreateVM)
		{
			var trainingModule = mapper.Map<TrainingModule>(trainingModuleCreateVM);
			List<DateTime> days = GetDaysBetween(trainingModuleCreateVM.StartDate, trainingModuleCreateVM.EndDate);

			await AddAsync(trainingModule);
			await CreateDayInTrainingModuleAsync(days, trainingModuleCreateVM.UserId, trainingModuleCreateVM.CoachId, trainingModule.Id);
		}

		// EDITS AN EXISTING TRAINING MODULE, ALLOWING ONLY EXTENSION OF DAYS AND NAME CHANGE.
		public async Task EditTrainingModuleAsync(TrainingModuleCreateVM trainingModuleCreateVM)
		{
			var trainingModule = await GetAsync(trainingModuleCreateVM.Id);

			if (trainingModuleCreateVM.StartDate > trainingModule.StartDate || trainingModuleCreateVM.EndDate < trainingModule.EndDate)
			{
				throw new ArgumentException("New StartDate must be earlier than previous, and EndDate later than previous.");
			}

			List<DateTime> daysBefore = GetDaysBetween(trainingModule.StartDate, trainingModule.EndDate);
			List<DateTime> daysAfter = GetDaysBetween(trainingModuleCreateVM.StartDate, trainingModuleCreateVM.EndDate);
			List<DateTime> newDays = GetNewDays(daysBefore, daysAfter);

			trainingModule.Name = trainingModuleCreateVM.Name;
			trainingModule.StartDate = trainingModuleCreateVM.StartDate;
			trainingModule.EndDate = trainingModuleCreateVM.EndDate;

			await CreateDayInTrainingModuleAsync(newDays, trainingModuleCreateVM.UserId, trainingModuleCreateVM.CoachId, trainingModule.Id);
		}

		// DELETES THE TRAINING MODULE AND ALL ASSOCIATED TRAINING PLANS.
		public async Task DeleteTrainingModuleAsync(int id)
		{
			var trainingModule = await GetAsync(id);
			foreach (var trainingPlanId in trainingModule.TrainingPlanIds)
			{
				await trainingPlanRepository.DeleteAsync(trainingPlanId);
			}
			await DeleteAsync(id);
		}

		// METHODS NOT AVAILABLE OUTSIDE OF THE CLASS BELOW

		// GETS A LIST OF DAYS BETWEEN STARTING AND ENDING DATE.
		private static List<DateTime> GetDaysBetween(DateTime? startDate, DateTime? endDate)
		{
			DateTime start = startDate.Value;
			DateTime end = endDate.Value;

			if (start > end)
			{
				throw new ArgumentException("StartDate must be earlier than or equal to EndDate.");
			}

			List<DateTime> days = new List<DateTime>();
			for (DateTime date = start; date <= end; date = date.AddDays(1))
			{
				days.Add(date);
			}
			return days;
		}

		// GETS A LIST OF DAYS THAT ARE CONTAINED IN DAYSBEFORE AND NOT CONTAINED IN DAYSAFTER
		private static List<DateTime> GetNewDays(List<DateTime> daysBefore, List<DateTime> daysAfter)
		{
			List<DateTime> newDays = new List<DateTime>();

			for (int i = 0; i < daysAfter.Count; i++)
			{
				bool isNew = true;
				for (int j = 0; j < daysBefore.Count; j++)
				{
					if (daysAfter[i] == daysBefore[j])
					{
						isNew = false;
					}
				}
				if (isNew)
				{
					newDays.Add(daysAfter[i]);
				}
			}
			return newDays;
		}

		// CREATES NEW DAY IN TRAINING MODULE (TRAINING PLAN ENTITY)
		private async Task CreateDayInTrainingModuleAsync(List<DateTime> days, string userId, string coachId, int trainingModuleId)
		{
			var trainingModule = await GetAsync(trainingModuleId);

			foreach (var day in days)
			{
				TrainingPlanCreateVM trainingPlanCreateVM = new TrainingPlanCreateVM
				{
					UserId = userId,
					Date = day,
					Name = ($"{day.DayOfWeek.ToString()} {day.ToString("dd MMMM", CultureInfo.InvariantCulture)}"),
					TrainingModuleId = trainingModuleId,
					CoachId = coachId
				};
				int trainingPlanId = await trainingPlanRepository.CreateTrainingPlanAsync(trainingPlanCreateVM);
				trainingModule.TrainingPlanIds.Add(trainingPlanId);
			}
			await UpdateAsync(trainingModule);
		}
	}
}
