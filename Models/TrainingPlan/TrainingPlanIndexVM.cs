using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Controllers;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models.TrainingPlan
{
    public class TrainingPlanIndexVM
    {
        // IDs
        public int? Id { get; set; }

        [Display(Name = "Athlete")]
        public string? UserId { get; set; }

        // STRINGS etc.
        [Display(Name = "Training Plan")]
        [Required]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        // OTHER
        [Display(Name = "Status")]
        public bool? IsCompleted { get; set; }

        public bool IsEmpty { get; set; }

        public UserVM? User { get; set; }
    }
}
