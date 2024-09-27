using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.Exercise
{
    public class ExerciseCategoryVM
    {
        // IDs
        public int Id { get; set; }

        // STRINGS etc.
        [Display(Name="Exercise")]
        [Required]
        public string Name { get; set; }
    }
}
