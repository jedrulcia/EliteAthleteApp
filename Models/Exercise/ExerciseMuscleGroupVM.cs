using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.Exercise
{
	public class ExerciseMuscleGroupVM
	{
		// IDs
		public int Id { get; set; }

		// STRINGS etc.
		[Display(Name = "Muscle Group")]
		[Required]
		public string Name { get; set; }
	}
}
