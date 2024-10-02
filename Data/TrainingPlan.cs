using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Controllers;

namespace TrainingPlanApp.Web.Data
{
	public class TrainingPlan
    {
        // IDs
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CoachId { get; set; }
        public int? TrainingModuleId {  get; set; }

        // STRINGS etc.
        public string? Name { get; set; }
        public DateTime? Date { get; set; }

		// LISTS
		public List<string?>? Indices { get; set; }
		public List<int?>? ExerciseIds { get; set; }
		// indices are used to get the order of exercises
		public List<float?>? Weights { get; set; }
		public List<int?>? Sets { get; set; }
		// repeats can be (example): 10reps/30sec/5km           unit types can be (example): reps/time/distance
		public List<string?>? Repeats { get; set; }
		public List<string?>? UnitTypes { get; set; }
		public List<string?>? RestTimes { get; set; }
        public List<string?>? Notes { get; set; }

		// OTHER
		public bool? IsCompleted { get; set; }
		public bool IsEmpty { get; set; }
	}
}
