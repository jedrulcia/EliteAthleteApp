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
		// indices are used to get the order of exercises
		public List<string?>? Indices { get; set; }
		public List<int?>? ExerciseIds { get; set; }
		public List<int?>? Sets { get; set; }
		// Units can be (example): 10reps/30sec/5km
		public List<string?>? Units { get; set; }
		public List<string?>? Weights { get; set; }
		public List<string?>? RestTimes { get; set; }
        public List<string?>? Notes { get; set; }

		// OTHER
		public bool? IsCompleted { get; set; }
		public bool IsEmpty { get; set; }
	}
}
