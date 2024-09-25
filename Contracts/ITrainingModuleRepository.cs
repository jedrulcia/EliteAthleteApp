using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.TrainingModule;

namespace TrainingPlanApp.Web.Contracts
{
    public interface ITrainingModuleRepository : IGenericRepository<TrainingModule>
    {
        // GETS TRAINING MODULE INDEX VM OF SPECIFIC USER
        Task<List<TrainingModuleIndexVM>> GetUserTrainingModuleIndexVM(string userId);

        // CREATES TRAINING MODULE
        Task CreateTrainingModule(TrainingModuleCreateVM trainingModuleCreateVM);

        // EDITS TRAINING MODULE
        Task EditTrainingModule(TrainingModuleCreateVM trainingModuleCreateVM);

        // DELETES TRAINING MODULE AND ALL TRAINING PLANS ATTACHED TO IT
        Task DeleteTrainingModule(int id);
    }
}
