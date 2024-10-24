using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EliteAthleteApp.Controllers;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Models.TrainingPlan
{
    public class TrainingPlanIndexVM
    {
        public string UserId { get; set; }
        public string? CoachId { get; set; }
        public int? TrainingModuleId { get; set; }
		public int Progress { get; set; }
        public List<TrainingPlanVM?>? TrainingPlanVMs { get; set; }
	}
}
