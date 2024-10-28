using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingExercise
{
	public class TrainingExerciseMuscleGroupVM
	{
		// IDs
		public int Id { get; set; }

		// STRINGS etc.
		[Display(Name = "Muscle Group")]
		[Required]
		public string Name { get; set; }
	}
}
