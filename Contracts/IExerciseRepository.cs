using Microsoft.AspNetCore.Mvc;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Exercise;

namespace TrainingPlanApp.Web.Contracts
{
	public interface IExerciseRepository : IGenericRepository<Exercise>
	{
		// GETS EXERCISE INDEX VIEW MODEL LIST.
		Task<ExerciseIndexVM> GetExerciseIndexVM();

		// GETS EXERCISE DETAILS VIEW MODEL FOR THE SPECIFIED EXERCISE ID.
		Task<ExerciseDetailsVM> GetExerciseDetailsVM(int id);

		// GETS EXERCISE CREATE VIEW MODEL FOR NEW EXERCISE CREATION.
		Task<ExerciseCreateVM> GetExerciseCreateVM();

		// GETS EXERCISE CREATE VIEW MODEL FOR EDITING AN EXISTING EXERCISE.
		Task<ExerciseCreateVM> GetExerciseEditVM(int id);

		// CREATES A NEW DATABASE ENTITY IN THE EXERCISE TABLE.
		Task CreateExercise(ExerciseCreateVM exerciseCreateVM);

		// EDITS THE NAME, VIDEO LINK, AND DESCRIPTION OF THE SPECIFIED EXERCISE.
		Task EditExercise(ExerciseCreateVM exerciseCreateVM);

		// GETS A LIST OF SPECIFIC EXERCISES BASED ON PROVIDED EXERCISE IDs.
		Task<List<ExerciseIndexVM>> GetListOfExercises(List<int?> exercisesIds);

		// GETS A LIST OF EXERCISE UNIT TYPES BASED ON PROVIDED UNIT TYPE IDs.
		Task<List<ExerciseUnitTypeVM>> GetListOfExerciseUnitTypes(List<int?> exerciseUnitTypesIds);

		// GETS A LIST OF FIELDS IMPROPERLY FILLED WHILE CREATING OR EDITING THE EXERCISE
		string GetErrorMessageFields(ExerciseCreateVM exerciseCreateVM);
	}
}
