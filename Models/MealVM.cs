using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
{
	public class MealVM
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Display(Name = "Amount of kcal")]
        public int? Kcal { get; set; }
        [Display(Name = "Amount of proteins")]
        public int? Protein { get; set; }
        [Display(Name = "Amount of fats")]
        public int? Fat { get; set; }
        [Display(Name = "Amount of carbs")]
        public int? Carbs { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
	}
}
