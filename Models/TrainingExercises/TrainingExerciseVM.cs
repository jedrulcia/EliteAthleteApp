using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingExercise
{
	public class TrainingExerciseVM
	{
		// IDs
		public int Id { get; set; }
		public string? CoachId {  get; set; }

		// URLs
		public string? YoutubeLink { get; set; }

		// OBJECTS
		public TrainingExerciseCategoryVM? ExerciseCategory { get; set; }
		public TrainingExerciseMuscleGroupVM? ExerciseMuscleGroup { get; set; }
		public TrainingExerciseMediaVM? ExerciseMediaVM { get; set; }

		// STRINGS

		[Display(Name = "Name")]
		public string Name { get; set; }

		[Display(Name = "Description")]
		public string? Description { get; set; }

		// BOOLEANS
		public bool? SetAsPublic { get; set; }
	}
}
