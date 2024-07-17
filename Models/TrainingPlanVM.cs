using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models
{
    public class TrainingPlanVM
    {
        public int? Id { get; set; }
        [Display(Name = "Athlete")]
        public string? UserId { get; set; }
        [Display(Name = "Training Plan")]
        [Required]
        public string? Name { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Status")]
        public bool? IsActive { get; set; }
        public bool RedirectToAdmin {  get; set; }
        [Display(Name = "Exercises")]
        public List<ExerciseVM>? Exercises { get; set; }
        [Display(Name = "Exercise")]
        public string? ExerciseName { get; set; }
    }
}
