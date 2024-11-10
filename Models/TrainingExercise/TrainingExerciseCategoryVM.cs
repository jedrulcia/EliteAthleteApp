using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingExercise
{
    public class TrainingExerciseCategoryVM
    {
        // IDs
        public int Id { get; set; }

        // STRINGS

        [Display(Name="Category")]
        public string Name { get; set; }
    }
}
