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
		private readonly ApplicationDbContext context;
		public TrainingModuleRepository(ApplicationDbContext context,
			IMapper mapper,
			ITrainingPlanRepository trainingPlanRepository,
			UserManager<User> userManager,
			IHttpContextAccessor httpContextAccessor) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
			this.trainingPlanRepository = trainingPlanRepository;
			this.userManager = userManager;
			this.httpContextAccessor = httpContextAccessor;
		}

		// GETS LIST OF TRAINING MODULES VIEW MODELS
		public async Task<List<TrainingModuleVM>> GetTrainingModuleVMsAsync(string userId)
		{
			var trainingModules = (await GetAllAsync()).Where(x => x.UserId == userId);
			return mapper.Map<List<TrainingModuleVM>>(trainingModules);
		}

		// GETS TRAINING MODULE CREATE VIEW MODEL
		public TrainingModuleCreateVM GetTrainingModuleCreateVM(string userId, string coachId)
		{
			return new TrainingModuleCreateVM { UserId = userId, CoachId = coachId };
		}

		// GETS TRAINING MODULE EDIT VIEW MODEL
		public async Task<TrainingModuleCreateVM> GetTrainingModuleEditVMAsync(int trainingModuleId)
		{
			var trainingModule = await GetAsync(trainingModuleId);
			return mapper.Map<TrainingModuleCreateVM>(trainingModule);
		}

		// GETS TRAINING MODULE DELETE VIEW MODEL
		public async Task<TrainingModuleDeleteVM> GetTrainingModuleDeleteVM(int trainingModuleId)
		{
			return mapper.Map<TrainingModuleDeleteVM>(await GetAsync(trainingModuleId));
		}

		// CREATES A NEW TRAINING MODULE
		public async Task CreateTrainingModuleAsync(TrainingModuleCreateVM trainingModuleCreateVM)
		{
			var trainingModule = mapper.Map<TrainingModule>(trainingModuleCreateVM);
			trainingModule.TrainingPlanIds = new List<int>();
			List<DateTime> days = GetDaysBetween(trainingModuleCreateVM.StartDate, trainingModuleCreateVM.EndDate);

			await AddAsync(trainingModule);
			await CreateDaysInTrainingModuleAsync(days, trainingModuleCreateVM.UserId, trainingModuleCreateVM.CoachId, trainingModule.Id);
		}

		// EDITS EXSITING TRAINING MODULE
		public async Task EditTrainingModuleAsync(TrainingModuleCreateVM trainingModuleCreateVM)
		{
			var trainingModule = await GetAsync(trainingModuleCreateVM.Id);

			List<DateTime> daysBefore = GetDaysBetween(trainingModule.StartDate, trainingModule.EndDate);
			List<DateTime> daysAfter = GetDaysBetween(trainingModuleCreateVM.StartDate, trainingModuleCreateVM.EndDate);
			List<DateTime> newDays = GetNewDays(daysBefore, daysAfter);
			List<DateTime> oldDays = GetOldDays(daysBefore, daysAfter);


			trainingModule.Name = trainingModuleCreateVM.Name;
			trainingModule.StartDate = trainingModuleCreateVM.StartDate;
			trainingModule.EndDate = trainingModuleCreateVM.EndDate;

			await RemoveDaysFromTrainingModuleAsync(oldDays, trainingModule.Id);
			await CreateDaysInTrainingModuleAsync(newDays, trainingModuleCreateVM.UserId, trainingModuleCreateVM.CoachId, trainingModule.Id);
		}

		// DELETES THE TRAINING MODULE AND ALL ASSOCIATED TRAINING PLANS
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

		// CREATES NEW DAYS IN TRAINING MODULE (NEW TRAINING PLAN ENTITIES)
		private async Task CreateDaysInTrainingModuleAsync(List<DateTime> days, string userId, string coachId, int trainingModuleId)
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

		// REMOVES OLD DAYS FROM TRAINING MODULE (OLD TRAINING PLAN ENTITIES)
		private async Task RemoveDaysFromTrainingModuleAsync(List<DateTime> oldDays, int trainingModuleId)
		{
			var trainingModule = await GetAsync(trainingModuleId);
			var holder = trainingModule.TrainingPlanIds.ToList();

			for (int i = 0; i < holder.Count; i++)
			{
				var trainingPlan = await trainingPlanRepository.GetAsync(holder[i]);
				for (int j = 0; j < oldDays.Count; j++)
				{
					if (trainingPlan.Date == oldDays[j])
					{
						await trainingPlanRepository.DeleteTrainingPlanAndDetailsAsync(holder[i]);
						trainingModule.TrainingPlanIds.Remove(holder[i]);
						break;
					}
				}
			}
		}

		// GETS A LIST OF DAYS BETWEEN STARTING AND ENDING DATE
		private static List<DateTime> GetDaysBetween(DateTime? startDate, DateTime? endDate)
		{
			DateTime start = startDate.Value;
			DateTime end = endDate.Value;

			List<DateTime> days = new List<DateTime>();
			for (DateTime date = start; date <= end; date = date.AddDays(1))
			{
				days.Add(date);
			}
			return days;
		}

		// GETS A LIST OF NEW DAYS IN TRAINING MODULE
		private static List<DateTime> GetNewDays(List<DateTime> daysBefore, List<DateTime> daysAfter)
		{
			List<DateTime> newDays = new List<DateTime>();

			foreach (var dayAfter in daysAfter)
			{
				bool isNew = true;
				foreach (var dayBefore in daysBefore)
				{
					if (dayAfter == dayBefore)
					{
						isNew = false;
						break;
					}
				}
				if (isNew)
				{
					newDays.Add(dayAfter);
				}
			}
			return newDays;
		}

		// GETS A LIST OF DAYS TO DELETE IN TRAINING MODULE
		private static List<DateTime> GetOldDays(List<DateTime> daysBefore, List<DateTime> daysAfter)
		{
			List<DateTime> oldDays = new List<DateTime>();

			foreach (var dayBefore in daysBefore)
			{
				bool toDelete = true;
				foreach (var dayAfter in daysAfter)
				{
					if (dayBefore == dayAfter)
					{
						toDelete = false;
						break;
					}
				}
				if (toDelete)
				{
					oldDays.Add(dayBefore);
				}
			}
			return oldDays;
		}
	}
}
