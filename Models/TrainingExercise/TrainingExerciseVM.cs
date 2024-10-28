using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingExercise
{
	public class TrainingExerciseVM
	{
		// IDs
		public int Id { get; set; }
		public string? CoachId {  get; set; }

		// STRINGS etc.
		[Display(Name = "Name")]
		[Required]
		public string Name { get; set; }

		[Display(Name = "Video")]
		[Required]
		public string? VideoLink { get; set; }

		[Display(Name = "Description")]
		public string? Description { get; set; }

		// OTHER
		[Display(Name = "Exercise Category")]
		public TrainingExerciseCategoryVM? ExerciseCategory { get; set; }
		public TrainingExerciseMuscleGroupVM? ExerciseMuscleGroup { get; set; }
		public bool? SetAsPublic { get; set; }
	}
}
