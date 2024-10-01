using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.TrainingModule
{
    public class TrainingModuleCreateVM
    {
        // IDs
        public int? Id { get; set; }
        public string UserId { get; set; }
		public string CoachId {  get; set; }

        // STRINGS etc.
        [Display(Name="Training Module")]
        [Required]
        public string Name { get; set; }

		[Display(Name = "Starting Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		[DataType(DataType.Date)]
		[Required]
		public DateTime StartDate { get; set; }

		[Display(Name = "Ending Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		[DataType(DataType.Date)]
		[Required]
		public DateTime EndDate { get; set; }
	}
}
