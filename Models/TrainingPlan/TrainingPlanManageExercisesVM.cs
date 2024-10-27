using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.Exercise;

namespace EliteAthleteApp.Models.TrainingPlan
{
    public class TrainingPlanManageExercisesVM
    {
        // IDs
        public int? Id { get; set; }
		public int? TrainingModuleId { get; set; }
		public string? UserId { get; set; }
		public string? CoachId { get; set; }

		public List<TrainingPlanExerciseDetailVM?>? TrainingPlanExerciseDetailVMs { get; set; }
	}
}
