using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
{
    public class DietMealVM
    {
        public int Id { get; set; }
        public int? DietId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Breakfast")]
        public string? Breakfast { get; set; }
        [Display(Name = "Second Breakfast")]
        public string? SecondBreakfast { get; set; }
        [Display(Name = "Lunch")]
        public string? Lunch { get; set; }
        [Display(Name = "Snack")]
        public string? Snack { get; set; }
        [Display(Name = "Dinner")]
        public string? Dinner { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}
