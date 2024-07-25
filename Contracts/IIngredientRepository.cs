using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Contracts
{
    public interface IIngredientRepository : IGenericRepository<Ingredient>
    {
        Task CreateNewIngredient(IngredientVM ingredientVM);
        Task EditIngredient(IngredientVM ingredientVM);
    }
}
