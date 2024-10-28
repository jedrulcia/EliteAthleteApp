using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingExercise
{
    public class TrainingExerciseCategoryVM
    {
        public int Id { get; set; }
        // STRINGS etc.
        [Display(Name="Exercise Category")]
        public string Name { get; set; }
    }
}
