using System.ComponentModel.DataAnnotations.Schema;

namespace EliteAthleteApp.Data
{
	public class Meal
    {
        // IDs
        public int? Id { get; set; }
		public List<int?>? IngredientIds { get; set; }
		public string? DieticianId { get; set; }
		public int? MealCategoryId { get; set; }

		// STRINGS etc.
		public string? Name { get; set; }
		public string? Recipe {  get; set; }

		// NUMBERS
        public List<int?>? IngredientQuantities { get; set; }

		// OTHER
		public bool SetAsPublic {  get; set; }
		public string? ImageUrl { get; set; }
	}
}
