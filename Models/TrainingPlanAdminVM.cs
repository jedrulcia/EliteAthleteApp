using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models
{
	public class TrainingPlanAdminVM
    {
        // IDs
        public int? Id { get; set; }

        [Display(Name = "Athlete")]
        public string? UserId { get; set; }

        // STRINGS etc.
        [Display(Name = "Training Plan")]
		[Required]
		public string? Name { get; set; }

        [Display(Name = "First name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last name")]
        public string? LastName { get; set; }

        [Required]
		[Display(Name = "Start date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		[DataType(DataType.Date)]
		public DateTime? StartDate { get; set; }

        // OTHER
        [Display(Name = "Status")]
        public bool? IsActive { get; set; }
    }
}
