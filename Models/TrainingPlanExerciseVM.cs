using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
{
    public class TrainingPlanExerciseVM
    {
        public int Id { get; set; }
        public int? TrainingPlanId { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Video")]
        [Required]
        public string? VideoLink { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}
