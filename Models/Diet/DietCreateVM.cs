using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.Diet
{
    public class DietCreateVM
    {
        // IDs
        public int? Id { get; set; }
        public string? UserId { get; set; }

        // STRINGS etc.
        [Display(Name = "Diet Name")]
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
    }
}
