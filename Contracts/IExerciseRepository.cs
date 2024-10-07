﻿using Microsoft.AspNetCore.Mvc;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Exercise;

namespace TrainingPlanApp.Web.Contracts
{
	public interface IExerciseRepository : IGenericRepository<Exercise>
	{
		// GETS EXERCISE INDEX VIEW MODEL LIST.
		Task<ExerciseIndexVM> GetExerciseIndexVM();

		// CREATES A NEW DATABASE ENTITY IN THE EXERCISE TABLE.
		Task CreateExercise(ExerciseCreateVM exerciseCreateVM);

		// EDITS THE NAME, VIDEO LINK, AND DESCRIPTION OF THE SPECIFIED EXERCISE.
		Task EditExercise(ExerciseCreateVM exerciseCreateVM);

		// GETS A LIST OF SPECIFIC EXERCISES BASED ON PROVIDED EXERCISE IDs.
		Task<List<ExerciseVM>> GetListOfExercises(List<int?> exercisesIds);

		// ARCHIVE

		// GETS A LIST OF FIELDS IMPROPERLY FILLED WHILE CREATING OR EDITING THE EXERCISE
		string GetErrorMessageFields(ExerciseCreateVM exerciseCreateVM);

		// GETS EXERCISE CREATE VIEW MODEL FOR NEW EXERCISE CREATION.
		Task<ExerciseCreateVM> GetExerciseCreateVM();

		// GETS EXERCISE CREATE VIEW MODEL FOR EDITING AN EXISTING EXERCISE.
		Task<ExerciseCreateVM> GetExerciseEditVM(int id);
	}
}
