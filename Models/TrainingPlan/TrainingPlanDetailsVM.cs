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
		// indices are used to get the order of exercises
		public List<string?>? Indices { get; set; }
		public List<ExerciseVM?>? ExerciseVMs { get; set; }
		public List<int?>? ExerciseIds { get; set; }
		public List<int?>? Sets { get; set; }
		// Units can be (example): 10reps/30sec/5km
		public List<string?>? Units { get; set; }
		public List<string?>? Weights { get; set; }
		public List<string?>? RestTimes { get; set; }
		public List<string?>? Notes { get; set; }
	}
}
