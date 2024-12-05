using System.ComponentModel.DataAnnotations;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.TrainingExercise;

namespace EliteAthleteApp.Models.TrainingPlan
{
    public class TrainingPlanDetailsVM
    {
        // IDs
        public int? Id { get; set; }
		public int? TrainingModuleId { get; set; }
        public string? UserId { get; set; }
		public string? CoachId { get; set; }

		// OBJECTS
		public List<TrainingPlanExerciseDetailVM?>? TrainingPlanExerciseDetailVMs { get; set; }

		// STRINGS
		[Display(Name = "Training Plan")]
        public string? Name { get; set; }

		public DateTime? Date { get; set; }

	}
}
