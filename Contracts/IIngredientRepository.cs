using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Ingredient;

namespace TrainingPlanApp.Web.Contracts
{
	public interface IIngredientRepository : IGenericRepository<Ingredient>
	{
		// CREATES A NEW DATABASE ENTITY IN THE INGREDIENT TABLE.
		Task CreateIngredient(IngredientVM ingredientVM);

		// EDITS THE NAME AND MACROS OF THE SPECIFIED INGREDIENT.
		Task EditIngredient(IngredientVM ingredientVM);

		// GETS THE LIST OF ALL INGREDIENTS WITH COUNTED CALORIES.
		Task<List<IngredientVM>> GetIngredientVM();

		// GETS A LIST OF SPECIFIC INGREDIENTS BASED ON PROVIDED INGREDIENT IDs.
		Task<List<IngredientVM?>?> GetListOfIngredients(List<int?>? ingredientIds);

		// COUNTS THE MACROS (NUTRIENTS) OF THE SPECIFIED INGREDIENT BASED ON QUANTITY.
		Task<IngredientVM?> GetMacrosOfIngredient(int? id, int ingredientQuantity);
	}
}
