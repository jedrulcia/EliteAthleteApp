using System.ComponentModel.DataAnnotations;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Exercise;

namespace TrainingPlanApp.Web.Models.TrainingPlan
{
    public class TrainingPlanDetailsVM
    {
        // IDs
        public int? Id { get; set; }
		public int? TrainingModuleId { get; set; }

		[Display(Name = "Athlete")]
        public string? UserId { get; set; }
		public string? CoachId { get; set; }

		// STRINGS etc.
		[Display(Name = "Training Plan")]
        public string? Name { get; set; }

		public List<TrainingPlanExerciseDetailVM?>? TrainingPlanExerciseDetailVMs { get; set; }
		public List<TrainingPlanPhaseVM?>? TrainingPlanPhaseVMs { get; set; }
	}
}
