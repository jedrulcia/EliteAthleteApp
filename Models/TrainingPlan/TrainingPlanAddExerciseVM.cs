using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingPlan
{
	public class TrainingPlanAddExerciseVM : IValidatableObject
	{
		public int? TrainingPlanId { get; set; }
		public int? Id { get; set; }
		[Display(Name = "Exercise")]
		[Required]
		public int? ExerciseId { get; set; }
		public int? TrainingPlanPhaseId { get; set; }
		[Required]
		public string? Index { get; set; }
		public int? Sets { get; set; }
		public string? Units { get; set; }
		public string? Weight { get; set; }
		public string? RestTime { get; set; }
		public string? Note { get; set; }

        public SelectList? AvailableTrainingPlanPhases { get; set; }
        public SelectList? AvailableExercises { get; set; }

		public bool ReachedExerciseLimit { get; set; } = false;

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (ReachedExerciseLimit)
			{
				yield return new ValidationResult(
					"You have reached the limit of 30 exercises in the training plan.",
					new[] { nameof(ReachedExerciseLimit) }
				);
			}
		}

	}
}
