using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingPlan
{
	public class TrainingPlanVM
	{
		// IDs
		public int? Id { get; set; }
		public int? TrainingModuleId { get; set; }
		public string? UserId { get; set; }
		public string? CoachId {  get; set; }

		// STRINGS
		// .
		[Display(Name = "Training Plan")]
		public string? Name { get; set; }
		public string? Raport { get; set; }

		// DATES

		[Display(Name = "Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		[DataType(DataType.Date)]
		public DateTime? Date { get; set; }

		// BOOLEANS

		[Display(Name = "Status")]
		public bool IsCompleted { get; set; }
		public bool IsEmpty { get; set; }
	}
}
