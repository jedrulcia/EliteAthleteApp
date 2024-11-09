using EliteAthleteApp.Models.TrainingExercise;
using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingPlan
{
	public class TrainingPlanExerciseDetailVM
	{
		// IDs
		public int Id { get; set; }
		public int? ExerciseId { get; set; }
		public int? TrainingPlanPhaseId { get; set; }

		// OBJECTS
		public TrainingPlanPhaseVM? TrainingPlanPhaseVM { get; set; }
		public TrainingExerciseVM? ExerciseVM { get; set; }

		// STRINGS

		[Display(Name = "Exercise Order")]
		public string? Index { get; set; }

		[Display(Name = "Number of Sets")]
		public string? Sets { get; set; }

		[Display(Name = "Units (f. ex. 12reps/60sec/100m")]
		public string? Units { get; set; }

		[Display(Name = "Weight (f. ex. 100kg/150lbs)")]
		public string? Weight { get; set; }

		[Display(Name = "Rest Time (f. ex. 30sec/2min)")]
		public string? RestTime { get; set; }

		[Display(Name = "Notes")]
		public string? Note { get; set; }
	}
}
