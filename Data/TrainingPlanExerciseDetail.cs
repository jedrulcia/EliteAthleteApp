using System.ComponentModel.DataAnnotations;
using TrainingPlanApp.Web.Models.Exercise;
using TrainingPlanApp.Web.Models.TrainingPlan;

namespace TrainingPlanApp.Web.Data
{
	public class TrainingPlanExerciseDetail
	{
		public int? Id { get; set; }
		public int? ExerciseId { get; set; }
		public int? TrainingPlanPhaseId { get; set; }
		public string? Index { get; set; }
		public int? Sets { get; set; }
		public string? Units { get; set; }
		public string? Weight { get; set; }
		public string? RestTime { get; set; }
		public string? Note { get; set; }
	}
}
