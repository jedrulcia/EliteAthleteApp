using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
{
    public class ExerciseVM
    {
        public int Id { get; set; }
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
