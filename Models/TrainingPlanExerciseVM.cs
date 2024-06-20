using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
{
    public class TrainingPlanExerciseVM
    {
        public int Id { get; set; }
        public int? TrainingPlanId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Exercise")]
        [Required]
        public string? MainExerciseName { get; set; }
        [Display(Name = "Repeats")]
        [Required]
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
        public int OverallNumberOfSets { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}
