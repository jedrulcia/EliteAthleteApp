using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPlanApp.Web.Data
{
	public class Meal
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
		public string? Recipe {  get; set; }
        public List<int?>? IngredientIds { get; set; }
        public List<int?>? IngredientQuantities { get; set; }
	}
}
