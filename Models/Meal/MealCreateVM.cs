using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Models.Meal
{
    public class MealCreateVM
    {
        // IDs
        public int? Id { get; set; }
        public string? DieticianId { get; set; }
		public int? MealCategoryId { get; set; }

		// STRINGS etc.
		[Display(Name = "Name")]
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Recipe")]
        public string? Recipe { get; set; }

        // OTHER 
        public bool SetAsPublic { get; set; }
		public string? ImageUrl { get; set; }

		// FORM
		public SelectList? AvailableCategories { get; set; }
	}
}
