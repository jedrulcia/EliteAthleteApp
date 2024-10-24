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

        // STRINGS etc.
        public string? Name { get; set; }
        public DateTime? Date { get; set; }
		public string? Raport {  get; set; }

		// OTHER
		public bool? IsCompleted { get; set; }
		public bool IsEmpty { get; set; }
	}
}
