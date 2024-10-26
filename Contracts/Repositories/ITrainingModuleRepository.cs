using EliteAthleteApp.Data;
using EliteAthleteApp.Models.TrainingModule;

namespace EliteAthleteApp.Contracts
{
	public interface ITrainingModuleRepository : IGenericRepository<TrainingModule>
	{
		// GETS TRAINING MODULE INDEX VIEW MODEL
		Task<TrainingModuleIndexVM> GetTrainingModuleIndexVMAsync(string? userId);

		// GETS LIST OF TRAINING MODULES VIEW MODELS
		Task<List<TrainingModuleVM>> GetTrainingModuleVMsAsync(string userId);

		// CREATES A NEW TRAINING MODULE.
		Task CreateTrainingModuleAsync(TrainingModuleCreateVM trainingModuleCreateVM);

		// EDITS AN EXISTING TRAINING MODULE, ALLOWING ONLY EXTENSION OF DAYS AND NAME CHANGE.
		Task EditTrainingModuleAsync(TrainingModuleCreateVM trainingModuleCreateVM);

		// DELETES THE TRAINING MODULE AND ALL ASSOCIATED TRAINING PLANS.
		Task DeleteTrainingModuleAsync(int id);

		TrainingModuleCreateVM GetTrainingModuleCreateVM(string userId, string coachId);
		Task<TrainingModuleCreateVM> GetTrainingModuleEditVMAsync(int trainingModuleId);
		Task<TrainingModuleDeleteVM> GetTrainingModuleDeleteVM(int trainingModuleId);
	}
}
