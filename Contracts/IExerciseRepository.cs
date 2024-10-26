using EliteAthleteApp.Data;
using EliteAthleteApp.Models.Exercise;

namespace EliteAthleteApp.Contracts
{
	public interface IExerciseRepository : IGenericRepository<Exercise>
	{
		// GETS EXERCISE INDEX VIEW MODEL (COACH ID)
		Task<ExerciseIndexVM> GetExerciseIndexVMAsync();

		// GETS EXERCISE CREATE VIEW MODEL
		Task<ExerciseCreateVM> GetExerciseCreateVMAsync();

		// GETS EXERCISE DELETE VIEW MODEL
		Task<ExerciseDeleteVM> GetExerciseDeleteVMAsync(int id);

		// GETS EXERCISE DETAILS VIEW MODEL
		Task<ExerciseVM> GetExerciseDetailsVMAsync(int id);

		// GETS EXERCISE EDIT VIEW MODEL
		Task<ExerciseCreateVM> GetExerciseEditVMAsync(int id);

		// GETS LIST OF PUBLIC OR PRIVATE EXERCISES
		Task<List<ExerciseVM>> GetExerciseVMAsync(string? coachId);

		// CREATES A NEW DATABASE ENTITY IN THE EXERCISE TABLE
		Task CreateExerciseAsync(ExerciseCreateVM exerciseCreateVM);

		// EDITS EXISTING DATABAASE ENTITY IN THE EXERCISE TABLE
		Task EditExerciseAsync(ExerciseCreateVM exerciseCreateVM);
	}
}
