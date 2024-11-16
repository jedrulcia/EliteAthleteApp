using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingPlan
{
	public class TrainingPlanAddExerciseVM : IValidatableObject
	{
		// IDs
		public int TrainingPlanId { get; set; }
		public int? Id { get; set; }

		[Required]
		[Display(Name = "Exercise")]
		public int? ExerciseId { get; set; }
		public int? TrainingPlanPhaseId { get; set; }

		// STRINGS

		[Required]
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

		// FORMS
        public SelectList? AvailableTrainingPlanPhases { get; set; }
        public SelectList? AvailableExercises { get; set; }

		// VALIDATION
		public bool ReachedExerciseLimit { get; set; } = false;

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (ReachedExerciseLimit == true)
			{
				yield return new ValidationResult(
					"You have reached the limit of 30 exercises in the training plan.",
					new[] { nameof(ReachedExerciseLimit) }
				);
			}
		}

	}
}
