using System.ComponentModel.DataAnnotations;
using TrainingPlanApp.Web.Models.Exercise;
using TrainingPlanApp.Web.Models.TrainingPlan;

namespace TrainingPlanApp.Web.Models.TrainingModule
{
    public class TrainingModuleIndexVM
	{
		public string UserId { get; set; }
		public string? CoachId { get; set; }
		public List<TrainingModuleVM> TrainingModuleVMs { get; set; }
		public TrainingModuleCreateVM? TrainingModuleCreateVM { get; set; }
	}
}
