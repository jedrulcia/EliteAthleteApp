using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingExercise
{
	public class TrainingExerciseMuscleGroupVM
	{
		// IDs
		public int Id { get; set; }

		// STRINGS

		[Required]
		[Display(Name = "Muscle Group")]
		public string Name { get; set; }
	}
}
