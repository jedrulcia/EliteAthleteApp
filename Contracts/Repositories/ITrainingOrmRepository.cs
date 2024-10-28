using EliteAthleteApp.Data;
using EliteAthleteApp.Models.TrainingOrm;

namespace EliteAthleteApp.Contracts
{
    public interface ITrainingOrmRepository : IGenericRepository<TrainingOrm>
	{
		// GETS LIST OF TRAINING ORMs
		Task<List<TrainingOrmVM>> GetTrainingOrmVMsAsync(string userId);

		// GETS TRAINING ORM CREATE VM
		TrainingOrmCreateVM GetTrainingOrmCreateVM(string userId);

		// CREATES NEW ORM ENTITY
		Task CreateOrmAsync(TrainingOrmCreateVM trainingOrmCreateVM);
	}
}
