using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
{
    public class TrainingPlanExerciseVM
    {
        public string Name { get; set; }
        public int Id { get; set; }
        [Display(Name = "Exercise")]
        [Required]
        public string? MainExerciseName { get; set; }
        [Display(Name = "Repeats")]
        [Required]
        [Range(1, 200, ErrorMessage = "Please enter a valid number")]
        public int MainExerciseNumberOfRepeats { get; set; }
        [Display(Name = "Video")]
        [Required]
        public string? MainExerciseVideoLink { get; set; }
        [Display(Name = "Additional exercise")]
        [Required]
        public string? AdditionalExerciseName { get; set; }
        [Display(Name = "Repeats")]
        [Required]
        public int? AdditionalExerciseNumberOfRepeats { get; set; }
        [Display(Name = "Video")]
        [Required]
        public string? AdditionalExerciseVideoLink { get; set; }
        [Display(Name = "Number of sets")]
        [Required]
        [Range(1, 25, ErrorMessage = "Please enter a valid number")]
        public int OverallNumberOfSets { get; set; }
        public string? Description { get; set; }
        public int? TrainingPlanId { get; set; }
    }
}
