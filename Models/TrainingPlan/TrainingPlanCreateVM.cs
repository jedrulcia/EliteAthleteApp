using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Models.TrainingPlan
{
    public class TrainingPlanCreateVM
    {
        // IDs
        public int? Id { get; set; }
        public int? TrainingModuleId {  get; set; }
        public string? UserId { get; set; }
		public string? CoachId { get; set; }

		// STRINGS

		[Required]
		[Display(Name = "Training Plan Name")]
        public string? Name { get; set; }


        // DATES

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? Date { get; set; }
    }
}
