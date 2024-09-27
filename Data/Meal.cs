using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPlanApp.Web.Data
{
	public class Meal
    {
        // IDs
        public int? Id { get; set; }
		public List<int?>? IngredientIds { get; set; }

		// STRINGS etc.
		public string? Name { get; set; }
		public string? Recipe {  get; set; }

		// NUMBERS
        public List<int?>? IngredientQuantities { get; set; }
	}
}
