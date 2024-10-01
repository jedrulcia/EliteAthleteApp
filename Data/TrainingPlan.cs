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
        public List<int?>? ExerciseIds { get; set; }
        public List<int?>? Weight {  get; set; }
        public List<int?>? Sets { get; set; }
        public List<string?>? Index {  get; set; }
        public List<int?>? ExerciseUnitTypeIds { get; set; }
        public List<int?>? UnitAmounts { get; set; }
        public List<string?>? Units { get; set; }
        public List<int?>? BreakTimes { get; set; }
        public List<string?>? Notes { get; set; }

        // OTHER
		public bool? IsCompleted { get; set; }
		public bool IsEmpty { get; set; }
	}
}
