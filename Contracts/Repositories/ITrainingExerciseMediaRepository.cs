using EliteAthleteApp.Data;
using EliteAthleteApp.Models.TrainingExercise;

namespace EliteAthleteApp.Contracts.Repositories
{
	public interface ITrainingExerciseMediaRepository : IGenericRepository<TrainingExerciseMedia>
	{
		Task<TrainingExerciseMediaCreateVM> GetTrainingExerciseMediaEditVMAsync(int trainingExerciseMediaId);
		Task EditTrainingExerciseMediaAsync(TrainingExerciseMediaCreateVM trainingExerciseMediaCreateVM);
		Task DeleteExerciseMediaAsync(int? trainingExerciseMediaId);
	}
}
