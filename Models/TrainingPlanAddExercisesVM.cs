using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
{
	public class TrainingPlanAddExercisesVM
	{
		public int? Id { get; set; }

		public SelectList? AvailableExercises { get; set; }
		public List<int?>? ExerciseIds { get; set; }
		[Display(Name = "Exercises")]
		public List<ExerciseVM?>? Exercises { get; set; }


		[Display(Name = "Exercise")]
		public int? NewExerciseId { get; set; }
		[Display(Name = "Weight")]
		public int? NewExerciseWeight { get; set; }
		[Display(Name = "Sets")]
		public int? NewExerciseSets { get; set; }
		[Display(Name = "Repeats")]
		public int? NewExerciseRepeats { get; set; }
		[Display(Name = "Number of the exercise")]
		public string? NewExerciseIndex { get; set; }

		public bool RedirectToAdmin { get; set; }
	}
}
