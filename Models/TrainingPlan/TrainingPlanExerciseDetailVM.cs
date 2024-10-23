using TrainingPlanApp.Web.Models.Exercise;

namespace TrainingPlanApp.Web.Models.TrainingPlan
{
	public class TrainingPlanExerciseDetailVM
	{
		public int Id { get; set; }
		public ExerciseVM? ExerciseVM { get; set; }
		public int? ExerciseId { get; set; }
		public TrainingPlanPhaseVM? TrainingPlanPhaseVM { get; set; }
		public int? TrainingPlanPhaseId { get; set; }
		public string? Index { get; set; }
		public int? Sets { get; set; }
		public string? Units { get; set; }
		public string? Weight { get; set; }
		public string? RestTime { get; set; }
		public string? Note { get; set; }
	}
}
