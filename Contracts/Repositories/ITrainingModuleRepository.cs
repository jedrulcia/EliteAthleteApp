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

		// GETS TRAINING MODULE CREATE VIEW MODEL
		TrainingModuleCreateVM GetTrainingModuleCreateVM(string userId, string coachId);

		// GETS TRAINING MODULE EDIT VIEW MODEL
		Task<TrainingModuleCreateVM> GetTrainingModuleEditVMAsync(int trainingModuleId);
		
		// GETS TRAINING MODULE DELETE VIEW MODEL
		Task<TrainingModuleDeleteVM> GetTrainingModuleDeleteVM(int trainingModuleId);

		// CREATES A NEW TRAINING MODULE
		Task CreateTrainingModuleAsync(TrainingModuleCreateVM trainingModuleCreateVM);

		// EDITS EXSITING TRAINING MODULE
		Task EditTrainingModuleAsync(TrainingModuleCreateVM trainingModuleCreateVM);

		// DELETES THE TRAINING MODULE AND ALL ASSOCIATED TRAINING PLANS
		Task DeleteTrainingModuleAsync(int id);

	}
}
