using EliteAthleteApp.Data;
using EliteAthleteApp.Models.Charts;
using EliteAthleteApp.Models.TrainingOrm;

namespace EliteAthleteApp.Contracts
{
    public interface ITrainingOrmRepository : IGenericRepository<TrainingOrm>
	{
		// GETS LIST OF TRAINING ORMs
		Task<List<TrainingOrmVM>> GetTrainingOrmVMsAsync(string userId);

		// GETS TRAINING ORM CREATE VM
		Task<TrainingOrmCreateVM> GetTrainingOrmCreateVMAsync(string userId);

		// GETS TRAINING ORM EDIT VIEW MODEL
		Task<TrainingOrmCreateVM> GetTrainingOrmEditVMAsync(int trainingOrmId);

		// GETS TRAINING ORM DELETE VIEW MODEL
		Task<TrainingOrmDeleteVM> GetTrainingOrmDeleteVMAsync(int trainingOrmId);

		// GETS TRAINING ORM CHART
		Task<TrainingOrmChartVM> GetTrainingOrmChartVMAsync(string userId);

		// CREATES NEW ORM ENTITY
		Task CreateOrmAsync(TrainingOrmCreateVM trainingOrmCreateVM);

		// EDITS EXSITING ORM ENTITY
		Task EditOrmAsync(TrainingOrmCreateVM trainingOrmCreateVM);

		// DELETES ORM ENTITY
		Task DeleteOrmAsync(TrainingOrmDeleteVM trainingOrmDeleteVM);
	}
}
