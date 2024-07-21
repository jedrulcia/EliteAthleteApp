using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Contracts
{
    public interface ITrainingPlanRepository : IGenericRepository<TrainingPlan>
    {
        Task<List<TrainingPlanVM>> GetUserTrainingPlans(string userId);
        Task ChangeTrainingPlanStatus(int trainingPlanId, bool status);
        Task<TrainingPlan> GetTrainingPlanDetails(int? id);

        Task CreateTrainingPlan(TrainingPlanCreateVM model);
        Task UpdateTrainingPlan(TrainingPlanCreateVM model);
        Task<List<TrainingPlanAdminVM>> GetAllTrainingPlans();
        Task<TrainingPlanCreateVM> AddExerciseSequence(TrainingPlanCreateVM trainingPlanCreateVM);
        TrainingPlan AddSingleAtributesToTrainingPlan(TrainingPlan trainingPlan, TrainingPlanCreateVM trainingPlanCreateVM);
        TrainingPlan AddListsToTrainingPlan(TrainingPlan trainingPlan);
        Task RemoveExerciseFromTrainingPlan(int id, int index);
	}
}
