using System.ComponentModel.DataAnnotations;
using EliteAthleteApp.Models.TrainingExercise;
using EliteAthleteApp.Models.TrainingPlan;

namespace EliteAthleteApp.Models.TrainingModule
{
    public class TrainingModuleIndexVM
	{
		public string UserId { get; set; }
		public string? CoachId { get; set; }
	}
}
