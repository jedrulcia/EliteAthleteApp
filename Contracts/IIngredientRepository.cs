using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Contracts
{
    public interface IIngredientRepository : IGenericRepository<Ingredient>
    {
        MealCreateVM CreateIngredientAddingModel(Meal meal);
        Task<MealCreateVM> AddIngredientSequence(MealCreateVM mealCreateVM);
    }
}
