using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.Exercise
{
    public class ExerciseCategoryVM
    {
        public int Id { get; set; }
        // STRINGS etc.
        [Display(Name="Exercise Category")]
        public string Name { get; set; }
    }
}
