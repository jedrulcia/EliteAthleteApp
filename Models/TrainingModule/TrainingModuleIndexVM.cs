using System.ComponentModel.DataAnnotations;
using EliteAthleteApp.Models.Exercise;
using EliteAthleteApp.Models.TrainingPlan;

namespace EliteAthleteApp.Models.TrainingModule
{
    public class TrainingModuleIndexVM
	{
		public string UserId { get; set; }
		public string? CoachId { get; set; }
		public List<TrainingModuleVM?>? TrainingModuleVMs { get; set; }
		public TrainingModuleCreateVM? TrainingModuleCreateVM { get; set; }
		public List<TrainingModuleORMVM?>? TrainingModuleORMVMs { get; set; }
		public TrainingModuleORMVM? TrainingModuleAddORMVM { get;set; }
	}
}
