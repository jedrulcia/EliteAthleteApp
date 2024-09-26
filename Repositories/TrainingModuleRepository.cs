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

        // GETS TRAINING MODULE INDEX VM OF SPECIFIC USER
        public async Task<List<TrainingModuleIndexVM>> GetUserTrainingModuleIndexVM(string userId)
        {
            var trainingModules = await context.TrainingModules
                .Where(x => x.UserId == userId)
                .ToListAsync();
            var trainingModuleIndexVM = mapper.Map<List<TrainingModuleIndexVM>>(trainingModules);
            return trainingModuleIndexVM;
        }

        // CREATES TRAINING MODULE
        public async Task CreateTrainingModule(TrainingModuleCreateVM trainingModuleCreateVM)
        {
            var trainingModule = mapper.Map<TrainingModule>(trainingModuleCreateVM);
            trainingModule.TrainingPlanIds = new List<int>();

			List<DateTime> days = GetDaysBetween(trainingModuleCreateVM.StartDate, trainingModuleCreateVM.EndDate);
			await context.AddAsync(trainingModule);
            await context.SaveChangesAsync();

			foreach (var day in days)
            {
                TrainingPlanCreateVM trainingPlanCreateVM = new TrainingPlanCreateVM
                {
                    UserId = trainingModuleCreateVM.UserId,
                    Date = day,
                    Name = ($"{day.DayOfWeek.ToString()} {day.ToString("dd MMMM", CultureInfo.InvariantCulture)}"),
                    TrainingModuleId = trainingModule.Id
                };
                int id = await trainingPlanRepository.CreateTrainingPlan(trainingPlanCreateVM);
                trainingModule.TrainingPlanIds.Add(id);
            }
            await UpdateAsync(trainingModule);

        }

		// EDITS TRAINING MODULE - ALLOWS ONLY EXTENDING THE MODULE
		public async Task EditTrainingModule(TrainingModuleCreateVM trainingModuleCreateVM)
        {
            var trainingModule = await GetAsync(trainingModuleCreateVM.Id);
            List<DateTime> daysBefore = GetDaysBetween(trainingModule.StartDate, trainingModule.EndDate);
            List<DateTime> daysAfter = GetDaysBetween(trainingModuleCreateVM.StartDate, trainingModuleCreateVM.EndDate);

            trainingModule.Name = trainingModuleCreateVM.Name;
            trainingModule.StartDate = trainingModuleCreateVM.StartDate;
            trainingModule.EndDate = trainingModuleCreateVM.EndDate;
/*            foreach (var day in days)
            {

                TrainingPlanCreateVM trainingPlanCreateVM = new TrainingPlanCreateVM
                {
                    UserId = trainingModuleCreateVM.UserId,
                    Date = day,
                    Name = ($"{day.DayOfWeek.ToString()} {day.ToString("dd MMMM", CultureInfo.InvariantCulture)}"),
                    Description = null
                };
                int id = await trainingPlanRepository.CreateTrainingPlan(trainingPlanCreateVM);
                trainingModule.TrainingPlanIds.Add(id);
            }*/


            await UpdateAsync(trainingModule);
        }

        // DELETES TRAINING MODULE AND ALL TRAINING PLANS ATTACHED TO IT
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

        // GETS A LIST OF DAYS BETWEEN STARTING AND ENDING DATE
        public static List<DateTime> GetDaysBetween(DateTime? startDate, DateTime? endDate)
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

    }
}
