using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models.TrainingPlan
{
    public class TrainingPlanCreateVM
    {
        // IDs
        public int? Id { get; set; }
        public int? TrainingModuleId {  get; set; }

        [Display(Name = "Athlete")]
        public string? UserId { get; set; }
		public string? CoachId { get; set; }

		// STRINGS etc.
		[Display(Name = "Training Plan name")]
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
    }
}
