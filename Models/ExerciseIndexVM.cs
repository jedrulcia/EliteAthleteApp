using System.ComponentModel.DataAnnotations;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models
{
    public class ExerciseIndexVM
    {
        // IDs
        public int Id { get; set; }
		public int? ExerciseCategoryId { get; set; }

		// STRINGS etc.
		[Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Video")]
        [Required]
        public string? VideoLink { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        // OTHER
        [Display(Name = "Category")]
        public ExerciseCategoryVM? ExerciseCategory { get; set; }
    }
}
