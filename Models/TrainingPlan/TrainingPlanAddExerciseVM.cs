using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingPlan
{
	public class TrainingPlanAddExerciseVM
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
    }
}
