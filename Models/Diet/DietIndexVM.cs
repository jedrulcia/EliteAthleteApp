using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Models.Diet
{
    public class DietIndexVM
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
        public DateTime? StartDate { get; set; }

        // OTHER
        [Display(Name = "Status")]
        public bool? IsActive { get; set; }
    }
}
