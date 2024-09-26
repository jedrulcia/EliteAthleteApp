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

		// STRINGS etc.
		[Display(Name = "Training Plan")]
        public string? Name { get; set; }

		// LISTS
		public List<ExerciseIndexVM?>? Exercises { get; set; }
		public List<ExerciseUnitTypeVM?>? ExerciseUnitTypes { get; set; }
		public List<string?>? Index { get; set; }
		public List<int?>? ExerciseIds { get; set; }
		public List<int?>? Weight { get; set; }
		public List<int?>? Sets { get; set; }
		public List<int?>? UnitAmounts { get; set; }
		public List<string?>? Units { get; set; }
		public List<int?>? ExerciseUnitTypeIds { get; set; }
		public List<int?>? BreakTimes { get; set; }
		public List<string?>? Notes { get; set; }
	}
}
