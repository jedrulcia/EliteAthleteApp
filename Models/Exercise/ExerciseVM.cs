using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.Exercise
{
	public class ExerciseVM
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
		public ExerciseCategoryVM? ExerciseCategory { get; set; }
		public ExerciseMuscleGroupVM? ExerciseMuscleGroup { get; set; }
		public bool? SetAsPublic { get; set; }
	}
}
