using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
{
	public class TrainingPlanExerciseDetailsVM
	{
		[Display(Name = "Athlete")]
		public string? UserId { get; set; }

		[Display(Name = "Exercise")]
		public ExerciseVM? Exercise { get; set; }
	}
}
