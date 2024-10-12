using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.TrainingPlan
{
	public class TrainingPlanAddExerciseVM
	{
		public int? Id { get; set; }
		// FORMS
		// indices are used to get the order of exercises
		public string? ExerciseIndex { get; set; }
		public SelectList? AvailableTrainingPlanPhases { get; set; }
		public int? TrainingPlanPhaseId { get; set; }
		public SelectList? AvailableExercises { get; set; }
		[Display(Name = "Exercise")]
		public int? ExerciseId { get; set; }
		public int? ExerciseSets { get; set; }
		// Units can be (example): 10reps/30sec/5km
		public string? ExerciseUnits { get; set; }
		public string? ExerciseWeight { get; set; }
		public string? ExerciseRestTime { get; set; }
		public string? ExerciseNote { get; set; }
	}
}
