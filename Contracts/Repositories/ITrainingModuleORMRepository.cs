using EliteAthleteApp.Data;
using EliteAthleteApp.Models.TrainingModule;

namespace EliteAthleteApp.Contracts
{
	public interface ITrainingModuleORMRepository : IGenericRepository<TrainingModuleORM>
	{
		// GETS LIST ONE REPETITION MAX ENTITIES
		Task<List<TrainingModuleORMVM>> GetTrainingModuleORMVMsAsync(string userId);


		TrainingModuleORMCreateVM GetTrainingModuleORMCreateVM(string userId);

		// CREATES NEW ORM
		Task CreateORMAsync(TrainingModuleORMCreateVM trainingModuleORMCreateVM);
	}
}
