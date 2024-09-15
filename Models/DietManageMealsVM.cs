using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
{
    public class DietManageMealsVM
    {
        public int? Id { get; set; }
        [Display(Name = "Athlete")]
        public string? UserId { get; set; }
        [Display(Name = "Training Plan")]
        [Required]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Status")]
        public bool? IsActive { get; set; }
        public List<int?>? MealIds { get; set; }

        public SelectList? AvailableMeals { get; set; }
        public List<MealIndexVM?>? Meals { get; set; }
        public bool? RedirectToAdmin { get; set; }
        [Display(Name = "Meal Quantity")]
        public List<int>? MealQuantities { get; set; }
        public List<decimal>? MealProteins { get; set; }
        public List<decimal>? MealFats { get; set; }
        public List<decimal>? MealCarbohydrates { get; set; }
        public List<int?>? MealKcal { get; set; }

        [Display(Name = "Amount of kcal")]
        public int? Kcal { get; set; }
        [Display(Name = "Amount of proteins")]
        public decimal Proteins { get; set; }
        [Display(Name = "Amount of fats")]
        public decimal Fats { get; set; }
        [Display(Name = "Amount of carbs")]
        public decimal Carbohydrates { get; set; }

    }
}
