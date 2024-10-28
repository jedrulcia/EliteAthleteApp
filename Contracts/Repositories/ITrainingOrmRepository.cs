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

		// GETS TRAINING ORM EDIT VIEW MODEL
		Task<TrainingOrmCreateVM> GetTrainingOrmEditVM(int trainingOrmId);

		// GETS TRAINING ORM DELETE VIEW MODEL
		Task<TrainingOrmDeleteVM> GetTrainingOrmDeleteVM(int trainingOrmId);

		// CREATES NEW ORM ENTITY
		Task CreateOrmAsync(TrainingOrmCreateVM trainingOrmCreateVM);

		// EDITS EXSITING ORM ENTITY
		Task EditOrmAsync(TrainingOrmCreateVM trainingOrmCreateVM);

		// DELETES ORM ENTITY
		Task DeleteOrmAsync(TrainingOrmDeleteVM trainingOrmDeleteVM);
	}
}
