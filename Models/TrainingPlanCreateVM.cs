using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models
{
    public class TrainingPlanCreateVM
    {

        public int? Id { get; set; }
        [Display(Name = "Athlete")]
        public string? UserId { get; set; }
        [Display(Name = "Training Plan name")]
        [Required]
        public string? Name { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Status")]
        public bool? IsActive { get; set; }
		public bool RedirectToAdmin { get; set; }
        [Display(Name = "Exercises")]
        public List<int>? ExerciseIds { get; set; }
        [Display(Name = "Exercise")]
        public int? Exercise { get; set; }
        public SelectList? AvailableExercises { get; set; }
		[Display(Name = "Weight")]
		public int? Weight { get; set; }
		[Display(Name = "Sets")]
		public int? Sets { get; set; }
		[Display(Name = "Repeats")]
		public int? Repeats { get; set; }
        [Display(Name = "Number of the exercise")]
        public string? Index { get; set; }
    }
}
