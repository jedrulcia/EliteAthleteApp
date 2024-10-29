using EliteAthleteApp.Data;
using EliteAthleteApp.Models.TrainingExercise;

namespace EliteAthleteApp.Contracts
{
	public interface ITrainingExerciseRepository : IGenericRepository<TrainingExercise>
	{
		// GETS EXERCISE INDEX VIEW MODEL (COACH ID)
		Task<TrainingExerciseIndexVM> GetExerciseIndexVMAsync();

		// GETS LIST OF PUBLIC OR PRIVATE EXERCISES
		Task<List<TrainingExerciseVM>> GetExerciseVMsAsync(string? coachId);

		// GETS EXERCISE CREATE VIEW MODEL
		Task<TrainingExerciseCreateVM> GetExerciseCreateVMAsync();

		// GETS EXERCISE DELETE VIEW MODEL
		Task<TrainingExerciseDeleteVM> GetExerciseDeleteVMAsync(int id);

		// GETS EXERCISE DETAILS VIEW MODEL
		Task<TrainingExerciseVM?> GetExerciseDetailsVMAsync(int id);

		// GETS EXERCISE EDIT VIEW MODEL
		Task<TrainingExerciseCreateVM> GetExerciseEditVMAsync(int id);

		// CREATES A NEW DATABASE ENTITY IN THE EXERCISE TABLE
		Task CreateExerciseAsync(TrainingExerciseCreateVM exerciseCreateVM);

		// EDITS EXISTING DATABAASE ENTITY IN THE EXERCISE TABLE
		Task EditExerciseAsync(TrainingExerciseCreateVM exerciseCreateVM);
	}
}
