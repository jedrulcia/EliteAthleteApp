using Microsoft.AspNetCore.Mvc;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Exercise;

namespace TrainingPlanApp.Web.Contracts
{
	public interface IExerciseRepository : IGenericRepository<Exercise>
	{
		// GETS EXERCISE INDEX VIEW MODEL LIST.
		Task<ExerciseIndexVM> GetExerciseIndexVMAsync();

		// CREATES A NEW DATABASE ENTITY IN THE EXERCISE TABLE.
		Task CreateExerciseAsync(ExerciseCreateVM exerciseCreateVM);

		// EDITS THE NAME, VIDEO LINK, AND DESCRIPTION OF THE SPECIFIED EXERCISE.
		Task EditExerciseAsync(ExerciseCreateVM exerciseCreateVM);

		// GETS A LIST OF SPECIFIC EXERCISES BASED ON PROVIDED EXERCISE IDs.
		Task<List<ExerciseVM>> GetListOfExercisesAsync(List<int?> exercisesIds);
	}
}
