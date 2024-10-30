using EliteAthleteApp.Data;
using EliteAthleteApp.Models.TrainingExercise;

namespace EliteAthleteApp.Contracts.Repositories
{
	public interface ITrainingExerciseMediaRepository : IGenericRepository<TrainingExerciseMedia>
	{
		Task DeleteExerciseMediaAsync(int? trainingExerciseMediaId);
	}
}
