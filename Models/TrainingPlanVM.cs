using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models
{
    public class TrainingPlanVM
    {
        [Display(Name = "Training Plan")]
        [Required]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Exercise 1")]
        public Exercise? ExerciseFirst {  get; set; }
        public int ExerciseFirstId { get; set; }
        [Display(Name = "Exercise 2")]
        public Exercise? ExerciseSecond { get; set; }
        public int ExerciseSecondId { get; set; }
        [Display(Name = "Exercise 3")]
        public Exercise? ExerciseThird { get; set; }
        public int ExerciseThirdId { get; set; }
        [Display(Name = "Exercise 4")]
        public Exercise? ExerciseFourth { get; set; }
        public int ExerciseFourthId { get; set; }
        [Display(Name = "Athlete")]
        public string? UserId { get; set; }
		public int? Id { get; set; }
		public string? Description { get; set; }

		[Display(Name = "Status")]
		public bool? IsActive { get; set; }
    }
}
