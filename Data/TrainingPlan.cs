using System.ComponentModel.DataAnnotations.Schema;
using EliteAthleteApp.Controllers;

namespace EliteAthleteApp.Data
{
	public class TrainingPlan
    {
        // IDs
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CoachId { get; set; }
        public int? TrainingModuleId {  get; set; }
		public List<int?>? TrainingPlanExerciseDetailIds { get; set; }

        // STRINGS
        public string? Name { get; set; }
		public string? Raport {  get; set; }

		// DATES
		public DateTime? Date { get; set; }

		// BOOLEANS
		public bool? IsCompleted { get; set; }
		public bool IsEmpty { get; set; }
	}
}
