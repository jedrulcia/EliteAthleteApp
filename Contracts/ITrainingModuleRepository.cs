using EliteAthleteApp.Data;
using EliteAthleteApp.Models.TrainingModule;

namespace EliteAthleteApp.Contracts
{
	public interface ITrainingModuleRepository : IGenericRepository<TrainingModule>
	{
		// GETS TRAINING MODULE INDEX VIEW MODEL FOR A SPECIFIC USER.
		Task<TrainingModuleIndexVM> GetTrainingModuleIndexVMAsync(string userId);

		// CREATES A NEW TRAINING MODULE.
		Task CreateTrainingModuleAsync(TrainingModuleCreateVM trainingModuleCreateVM);

		// EDITS AN EXISTING TRAINING MODULE, ALLOWING ONLY EXTENSION OF DAYS AND NAME CHANGE.
		Task EditTrainingModuleAsync(TrainingModuleCreateVM trainingModuleCreateVM);

		// DELETES THE TRAINING MODULE AND ALL ASSOCIATED TRAINING PLANS.
		Task DeleteTrainingModuleAsync(int id);

		// CREATES NEW ORM
		Task CreateORMAsync(TrainingModuleORMCreateVM trainingModuleORMCreateVM);

		Task<List<TrainingModuleVM>> GetTrainingModuleVMsAsync(string userId);
		Task<List<TrainingModuleORMVM>> GetTrainingModuleORMVMsAsync(string userId);
		TrainingModuleCreateVM GetTrainingModuleCreateVM(string userId, string coachId);
		Task<TrainingModuleCreateVM> GetTrainingModuleEditVMAsync(int trainingModuleId);
		TrainingModuleDeleteVM GetTrainingModuleDeleteVM(int trainingModuleId, string name, string userId);
		TrainingModuleORMCreateVM GetTrainingModuleORMCreateVM(string userId);
	}
}
