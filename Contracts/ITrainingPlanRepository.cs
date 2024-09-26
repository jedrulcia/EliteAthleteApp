using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.TrainingPlan;

namespace TrainingPlanApp.Web.Contracts
{
    public interface ITrainingPlanRepository : IGenericRepository<TrainingPlan>
	{
		// Gets list of specific User Training Plans
		Task<List<TrainingPlanIndexVM>> GetTrainingPlanIndexVM(List<int> trainingPlanIds);

		// Gets TrainingPlanDetailsVM
		Task<TrainingPlanDetailsVM> GetTrainingPlanDetailsVM(TrainingPlan trainingPlan);

		// Gets TrainingPlanManageExercisesVM
		Task<TrainingPlanManageExercisesVM> GetTrainingPlanManageExercisesVM(int? id);

		// Creates new database entity in TrainingPlan table
		Task<int> CreateTrainingPlan(TrainingPlanCreateVM model);

		// Adds Exercise to Training Plan
		Task<TrainingPlanManageExercisesVM> AddExerciseToTrainingPlan(TrainingPlanManageExercisesVM trainingPlanCreateVM);

		// Removes Exercise from Training Plan
		Task RemoveExerciseFromTrainingPlan(int id, int index);

		// Changes the status of Training Plan (Active/Not Active)
		Task ChangeTrainingPlanCompletionStatus(int trainingPlanId, bool status);
	}
}
