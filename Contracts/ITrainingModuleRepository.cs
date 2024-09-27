using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.TrainingModule;

namespace TrainingPlanApp.Web.Contracts
{
	public interface ITrainingModuleRepository : IGenericRepository<TrainingModule>
	{
		// GETS TRAINING MODULE INDEX VIEW MODEL FOR A SPECIFIC USER.
		Task<List<TrainingModuleIndexVM>> GetUserTrainingModuleIndexVM(string userId);

		// CREATES A NEW TRAINING MODULE.
		Task CreateTrainingModule(TrainingModuleCreateVM trainingModuleCreateVM);

		// EDITS AN EXISTING TRAINING MODULE, ALLOWING ONLY EXTENSION OF DAYS AND NAME CHANGE.
		Task EditTrainingModule(TrainingModuleCreateVM trainingModuleCreateVM);

		// DELETES THE TRAINING MODULE AND ALL ASSOCIATED TRAINING PLANS.
		Task DeleteTrainingModule(int id);
	}
}
