using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Contracts
{
    public interface IIngredientRepository : IGenericRepository<Ingredient>
    {
        // Creates new database entity in ingredient table
        Task CreateIngredient(IngredientVM ingredientVM);

        // Edits Name, Proteins, Carbohydrates, Fats of ingredient
        Task EditIngredient(IngredientVM ingredientVM);

        // Gets the list of all ingredients with counted calories
        Task<List<IngredientVM>> GetIngredientVM();

        // Gets the list of specific ingredients
        Task<List<IngredientVM?>?> GetListOfIngredients(List<int?>? ingredientIds);

        // Counts the macros of specific ingredient
        Task<IngredientVM?> GetMacrosOfIngredient(int? id, int ingredientQuantity);
	}
}
