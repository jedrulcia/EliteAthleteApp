using EliteAthleteApp.Data;

namespace EliteAthleteApp.Contracts.Repositories
{
	public interface ITrainingExerciseMediaRepository : IGenericRepository<TrainingExerciseMedia>
	{
		Task DeleteExerciseMediaAsync(int? trainingExerciseMediaId);
	}
}
