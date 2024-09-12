using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models
{
    public class DietIndexVM
    {
        public int? Id { get; set; }
        [Display(Name = "Athlete")]
        public string? UserId { get; set; }
        [Display(Name = "Training Plan")]
        [Required]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Status")]
        public bool? IsActive { get; set; }
    }
}
