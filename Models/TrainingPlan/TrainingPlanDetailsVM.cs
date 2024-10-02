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

		// LISTS
		public List<string?>? Indices { get; set; }
		public List<ExerciseVM?>? Exercises { get; set; }
		public List<int?>? ExerciseIds { get; set; }
		// indices are used to get the order of exercises
		public List<float?>? Weights { get; set; }
		public List<int?>? Sets { get; set; }
		// repeats can be (example): 10reps/30sec/5km           unit types can be (example): reps/time/distance
		public List<string?>? Repeats { get; set; }
		public List<string?>? UnitTypes { get; set; }
		public List<string?>? RestTimes { get; set; }
		public List<string?>? Notes { get; set; }
	}
}
