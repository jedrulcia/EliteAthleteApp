using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Exercise;

namespace TrainingPlanApp.Web.Models.TrainingPlan
{
    public class TrainingPlanManageExercisesVM
    {
        // IDs
        public int? Id { get; set; }
		public int? TrainingModuleId { get; set; }
		public string? UserId { get; set; }
		public string? CoachId { get; set; }

		public List<TrainingPlanExerciseDetailVM?>? TrainingPlanExerciseDetailVMs { get; set; }
		public List<TrainingPlanPhaseVM?>? TrainingPlanPhaseVMs { get; set; }
	}
}
