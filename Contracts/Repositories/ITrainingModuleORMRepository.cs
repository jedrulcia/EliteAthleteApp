using EliteAthleteApp.Data;
using EliteAthleteApp.Models.TrainingModule;

namespace EliteAthleteApp.Contracts
{
	public interface ITrainingModuleORMRepository : IGenericRepository<TrainingModuleORM>
	{
		// GETS LIST OF TRAINING MODULE ORMs
		Task<List<TrainingModuleORMVM>> GetTrainingModuleORMVMsAsync(string userId);

		// GETS TRAINING MODULE ORM CREATE VM
		TrainingModuleORMCreateVM GetTrainingModuleORMCreateVM(string userId);

		// CREATES NEW ORM ENTITY
		Task CreateORMAsync(TrainingModuleORMCreateVM trainingModuleORMCreateVM);
	}
}
