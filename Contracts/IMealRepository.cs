using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Contracts
{
	public interface IMealRepository : IGenericRepository<Meal>
	{
		// Creates new database entity in Meal table
		Task CreateMeal(MealCreateVM mealCreateVM);

		// Edits Name, Recipe of meal
		Task EditMeal(MealCreateVM mealCreateVM);

		// Gets the Meal IndexVM - mainly counts the calories and macros of the meals
		Task<List<MealIndexVM>> GetMealIndexVM();

		// Gets the MealDetailsVM
		Task<MealDetailsVM> GetMealDetailsVM(Meal meal);

		// Gets MealManageIngredientsVM
        Task<MealManageIngredientsVM> GetMealManageIngredientsVM(int? id, bool redirectToAdmin);

		// Adds Ingredient to Meal
		Task<MealManageIngredientsVM> AddIngredientToMeal(MealManageIngredientsVM mealManageIngredientsVM);

		// Removes Ingredient from Meal
		Task RemoveIngredientFromMeal(int mealId, int index);

        // Gets the list of specific meals
        Task<List<MealIndexVM?>?> GetListOfMeals(List<int?>? mealIds);
    }
}
