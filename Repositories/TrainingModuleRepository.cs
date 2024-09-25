using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.TrainingModule;

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
            await AddAsync(trainingModule);
        }

        // EDITS TRAINING MODULE
        public async Task EditTrainingModule(TrainingModuleCreateVM trainingModuleCreateVM)
        {
            var trainingModule = await GetAsync(trainingModuleCreateVM.Id);
            trainingModule.Name = trainingModuleCreateVM.Name;
            trainingModule.StartDate = trainingModuleCreateVM.StartDate;
            trainingModule.EndDate = trainingModuleCreateVM.EndDate;
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
    }
}
