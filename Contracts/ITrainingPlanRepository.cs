using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Contracts
{
    public interface ITrainingPlanRepository : IGenericRepository<TrainingPlan>
    {
        Task CreateTrainingPlan(TrainingPlanCreateVM model);
		Task<TrainingPlanManageExercisesVM> GetTrainingPlanManageExercisesVM(int? id, bool redirectToAdmin);
		Task<TrainingPlanManageExercisesVM> AddExerciseToTrainingPlanSequence(TrainingPlanManageExercisesVM trainingPlanCreateVM);
		Task RemoveExerciseFromTrainingPlan(int id, int index);
		Task UpdateBasicTrainingPlanDetails(TrainingPlanCreateVM model);
		Task ChangeTrainingPlanStatus(int trainingPlanId, bool status);
		Task<List<TrainingPlanVM>> GetUserTrainingPlans(string userId);
		Task<List<TrainingPlanAdminVM>> GetAllTrainingPlansToVM();
		Task<TrainingPlanCreateVM> GetTrainingPlanCreateVMForEditingView(int? id, bool redirectToAdmin);
		Task<TrainingPlanDetailsVM> GetTrainingPlanDetailsVM(TrainingPlan trainingPlan, bool redirectToAdmin);
	}
}
