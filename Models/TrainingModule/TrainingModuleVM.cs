using System.ComponentModel.DataAnnotations;
using EliteAthleteApp.Models.TrainingPlan;

namespace EliteAthleteApp.Models.TrainingModule
{
	public class TrainingModuleVM
	{
		// IDs
		public int Id { get; set; }
		public string UserId { get; set; }
		public string CoachId { get; set; }
		public List<int> TrainingPlanIds { get; set; }

		// STRINGS etc.
		[Display(Name = "Training Module")]
		public string Name { get; set; }

		[Display(Name = "Starting Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		[DataType(DataType.Date)]
		public DateTime StartDate { get; set; }

		[Display(Name = "Ending Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		[DataType(DataType.Date)]
		public DateTime EndDate { get; set; }

		// LISTS
		public List<TrainingPlanIndexVM?>? TrainingPlans { get; set; }

		// OTHER
		public bool? IsActive { get; set; }
	}
}
