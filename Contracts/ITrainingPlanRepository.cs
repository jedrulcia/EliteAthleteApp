using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.TrainingPlan;

namespace TrainingPlanApp.Web.Contracts
{
	public interface ITrainingPlanRepository : IGenericRepository<TrainingPlan>
	{
		// GETS A LIST OF SPECIFIC USER TRAINING PLANS BASED ON PROVIDED TRAINING PLAN IDs.
		Task<TrainingPlanIndexVM> GetTrainingPlanIndexVM(List<int> trainingPlanIds);

		// GETS THE TRAINING PLAN DETAILS VIEW MODEL FOR THE SPECIFIED TRAINING PLAN.
		Task<TrainingPlanDetailsVM> GetTrainingPlanDetailsVM(TrainingPlan trainingPlan);

		// GETS THE TRAINING PLAN MANAGE EXERCISES VIEW MODEL FOR THE SPECIFIED TRAINING PLAN ID.
		Task<TrainingPlanManageExercisesVM> GetTrainingPlanManageExercisesVM(int? id);

		// CREATES A NEW DATABASE ENTITY IN THE TRAINING PLAN TABLE AND RETURNS THE NEW ID.
		Task<int> CreateTrainingPlan(TrainingPlanCreateVM model);

		// ADDS AN EXERCISE TO THE SPECIFIED TRAINING PLAN.
		Task<TrainingPlanManageExercisesVM> AddExerciseToTrainingPlan(TrainingPlanAddExerciseVM trainingPlanCreateVM);

		// EDIT AN EXERCISE IN SPECIFIED TRAINING PLAN.
		Task<TrainingPlanManageExercisesVM> EditExerciseInTrainingPlan(TrainingPlanAddExerciseVM trainingPlanCreateVM, int? index);

		// REMOVES AN EXERCISE FROM THE SPECIFIED TRAINING PLAN BASED ON TRAINING PLAN ID AND EXERCISE INDEX.
		Task RemoveExerciseFromTrainingPlan(int id, int index);

		// CHANGES THE STATUS OF THE TRAINING PLAN (ACTIVE/NOT ACTIVE).
		Task ChangeTrainingPlanCompletionStatus(int trainingPlanId, bool status);

		// COPIES A TRAINING PLAN TO ANOTHER TRAINING PLAN WITHIN THE SAME MODULE.
		Task CopyTrainingPlanToAnother(int copyFromId, int copyToId);
	}
}
