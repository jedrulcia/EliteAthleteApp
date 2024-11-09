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

		// STRINGS
		[Display(Name = "Training Module")]
		public string Name { get; set; }

		// DATES

		[DataType(DataType.Date)]
		[Display(Name = "Starting Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime StartDate { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Ending Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime EndDate { get; set; }
	}
}
