using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Status")]
        public bool? IsActive { get; set; }
        [Display(Name = "Exercise 1")]
        public int? ExerciseFirstId { get; set; }
        public SelectList? Exercises { get; set; }
        [Display(Name = "Exercise 2")]
        public int? ExerciseSecondId { get; set; }
        [Display(Name = "Exercise 3")]
        public int? ExerciseThirdId { get; set; }
        [Display(Name = "Exercise 4")]
        public int? ExerciseFourthId { get; set; }
		public bool RedirectToAdmin { get; set; }
	}
}
