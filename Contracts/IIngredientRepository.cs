using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Contracts
{
    public interface IIngredientRepository : IGenericRepository<Ingredient>
    {
        Task AddIngredient(MealCreateVM mealCreateVM);
    }
}
