using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.TrainingPlan
{
	public class TrainingPlanAddExerciseVM
	{
		public int? Id { get; set; }
		// FORMS
		// indices are used to get the order of exercises
		public string? NewExerciseIndex { get; set; }
		public SelectList? AvailableExercises { get; set; }
		[Display(Name = "Exercise")]
		public int? NewExerciseId { get; set; }
		public int? NewExerciseSets { get; set; }
		// Units can be (example): 10reps/30sec/5km
		public string? NewExerciseUnits { get; set; }
		public string? NewExerciseWeight { get; set; }
		public string? NewExerciseRestTime { get; set; }
		public string? NewExerciseNote { get; set; }
	}
}
