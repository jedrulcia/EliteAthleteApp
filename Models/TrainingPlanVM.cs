using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models
{
    public class TrainingPlanVM
    {
        public int Id { get; set; }
        [Display(Name = "Training Plan name")]
        [Required]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Exercise first")]
        public int? ExerciseFirstId { get; set; }
        public ExerciseVM? ExerciseFirst { get; set; }
        [Display(Name = "Exercise second")]
        public int? ExerciseSecondId { get; set; }
        public ExerciseVM? ExerciseSecond { get; set; }
        [Display(Name = "Exercise third")]
        public int? ExerciseThirdId { get; set; }
        public ExerciseVM? ExerciseThird { get; set; }
        [Display(Name = "Exercise fourth")]
        public int? ExerciseFourthId { get; set; }
        public ExerciseVM? ExerciseFourth { get; set; }
        [Display(Name = "Athlete")]
        public string? UserId { get; set; }
        public string? Description { get; set; }
    }
}
