﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using EliteAthleteApp.Models.Meal;

namespace EliteAthleteApp.Models.Diet
{
    public class DietManageMealsVM
    {
        // IDs
        public int? Id { get; set; }
        public string? UserId { get; set; }
		public List<int?>? MealIds { get; set; }

		// STRINGS etc.
		[Display(Name = "Training Plan")]
        [Required]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        // OTHER
        [Display(Name = "Status")]
        public bool? IsActive { get; set; }

        // FORM
        public SelectList? AvailableMeals { get; set; }
        public int? NewMealId { get; set; }
        public int? NewMealQuantity { get; set; }

        // MACROS
        public int? Kcal { get; set; }
        public decimal Proteins { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fats { get; set; }

        public List<int>? MealKcal { get; set; }
        public List<decimal>? MealProteins { get; set; }
        public List<decimal>? MealCarbohydrates { get; set; }
        public List<decimal>? MealFats { get; set; }

        public List<int>? DayKcal { get; set; }
        public List<decimal>? DayProteins { get; set; }
        public List<decimal>? DayCarbohydrates { get; set; }
        public List<decimal>? DayFats { get; set; }

		// OTHER LISTS
		[Display(Name = "Meal")]
		public List<MealIndexVM?>? Meals { get; set; }
        [Display(Name = "Meal Quantity")]
        public List<int> MealQuantities { get; set; }
    }
}
