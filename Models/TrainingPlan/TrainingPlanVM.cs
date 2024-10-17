using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.TrainingPlan
{
	public class TrainingPlanVM
	{
		// IDs
		public int? Id { get; set; }
		public int? TrainingModuleId { get; set; }

		[Display(Name = "Athlete")]
		public string? UserId { get; set; }
		public string? CoachId {  get; set; }

		// STRINGS etc.
		[Display(Name = "Training Plan")]
		[Required]
		public string? Name { get; set; }

		[Required]
		[Display(Name = "Start date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		[DataType(DataType.Date)]
		public DateTime? Date { get; set; }

		public string? Raport { get; set; }

		// OTHER
		[Display(Name = "Status")]
		public bool IsCompleted { get; set; }
		public bool IsEmpty { get; set; }
	}
}
