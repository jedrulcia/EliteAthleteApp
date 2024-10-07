using AutoMapper;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.TrainingModule;
using TrainingPlanApp.Web.Models.TrainingPlan;

namespace TrainingPlanApp.Web.Repositories
{
	public class TrainingModuleRepository : GenericRepository<TrainingModule>, ITrainingModuleRepository
	{
		private readonly IMapper mapper;
		private readonly ITrainingPlanRepository trainingPlanRepository;
		private readonly ApplicationDbContext context;
		public TrainingModuleRepository(ApplicationDbContext context, IMapper mapper, ITrainingPlanRepository trainingPlanRepository) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
			this.trainingPlanRepository = trainingPlanRepository;
		}

		// GETS TRAINING MODULE INDEX VIEW MODEL FOR A SPECIFIC USER.
		public async Task<TrainingModuleIndexVM> GetUserTrainingModuleIndexVM(string userId)
		{
			var trainingModules = await context.TrainingModules
				.Where(x => x.UserId == userId)
				.ToListAsync();
			var trainingModuleVMs = mapper.Map<List<TrainingModuleVM>>(trainingModules);

			var trainingModuleIndexVM = new TrainingModuleIndexVM
			{
				UserId = userId,
				CoachId = trainingModuleVMs[0].CoachId,
				TrainingModuleVMs = trainingModuleVMs,
				TrainingModuleCreateVM = new TrainingModuleCreateVM { UserId = userId }
            };

			return trainingModuleIndexVM;
		}

		// CREATES A NEW TRAINING MODULE.
		public async Task CreateTrainingModule(TrainingModuleCreateVM trainingModuleCreateVM)
		{
			var trainingModule = mapper.Map<TrainingModule>(trainingModuleCreateVM);
			trainingModule.TrainingPlanIds = new List<int>();
			List<DateTime> days = GetDaysBetween(trainingModuleCreateVM.StartDate, trainingModuleCreateVM.EndDate);

			await context.AddAsync(trainingModule);
			await context.SaveChangesAsync();
			await CreateNewDayInTrainingModule(days, trainingModuleCreateVM.UserId, trainingModuleCreateVM.CoachId, trainingModule.Id);
		}

		// EDITS AN EXISTING TRAINING MODULE, ALLOWING ONLY EXTENSION OF DAYS AND NAME CHANGE.
		public async Task EditTrainingModule(TrainingModuleCreateVM trainingModuleCreateVM)
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

			await CreateNewDayInTrainingModule(newDays, trainingModuleCreateVM.UserId, trainingModuleCreateVM.CoachId, trainingModule.Id);
		}

		// DELETES THE TRAINING MODULE AND ALL ASSOCIATED TRAINING PLANS.
		public async Task DeleteTrainingModule(int id)
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
		private async Task CreateNewDayInTrainingModule(List<DateTime> days, string userId, string coachId, int trainingModuleId)
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
				int trainingPlanId = await trainingPlanRepository.CreateTrainingPlan(trainingPlanCreateVM);
				trainingModule.TrainingPlanIds.Add(trainingPlanId);
			}
			await UpdateAsync(trainingModule);
		}

		// ARCHIVE

		// CHECKS IF NEW DATES ARE NOT NULL
		public async Task<TrainingModuleCreateVM> CheckTheDates(TrainingModuleCreateVM trainingModuleCreateVM)
		{
			var trainingModule = await GetAsync(trainingModuleCreateVM.Id);

			if (trainingModuleCreateVM.StartDate == null)
			{
				trainingModuleCreateVM.StartDate = trainingModule.StartDate;
			}
			if (trainingModuleCreateVM.EndDate == null)
			{
				trainingModuleCreateVM.EndDate = trainingModule.EndDate;
			}
			return trainingModuleCreateVM;
		}

	}
}
