using EliteAthleteApp.Data;
using EliteAthleteApp.Models.Ingredient;

namespace EliteAthleteApp.Contracts
{
	public interface IIngredientRepository : IGenericRepository<Ingredient>
	{
		// GETS THE LIST OF ALL INGREDIENTS WITH COUNTED CALORIES.
		Task<IngredientIndexVM> GetIngredientIndexVM();

		// GETS A LIST OF SPECIFIC INGREDIENTS BASED ON PROVIDED INGREDIENT IDs.
		Task<List<IngredientVM?>?> GetListOfIngredients(List<int?>? ingredientIds);

		// COUNTS THE MACROS (NUTRIENTS) OF THE SPECIFIED INGREDIENT BASED ON QUANTITY.
		Task<IngredientVM?> GetMacrosOfIngredient(int? id, int ingredientQuantity);

		// CREATES A NEW DATABASE ENTITY IN THE INGREDIENT TABLE.
		Task CreateIngredient(IngredientCreateVM ingredientVM);

		// EDITS THE NAME AND MACROS OF THE SPECIFIED INGREDIENT.
		Task EditIngredient(IngredientCreateVM ingredientVM);
	}
}
