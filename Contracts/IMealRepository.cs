using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Meal;

namespace TrainingPlanApp.Web.Contracts
{
	public interface IMealRepository : IGenericRepository<Meal>
	{
		// CREATES A NEW DATABASE ENTITY IN THE MEAL TABLE.
		Task CreateMeal(MealCreateVM mealCreateVM);

		// EDITS THE NAME AND RECIPE OF THE SPECIFIED MEAL.
		Task EditMeal(MealCreateVM mealCreateVM);

		// GETS THE MEAL INDEX VIEW MODEL, MAINLY COUNTING CALORIES AND MACROS OF MEALS.
		Task<MealIndexVM> GetMealIndexVM();

		// GETS THE MEAL DETAILS VIEW MODEL FOR THE SPECIFIED MEAL.
		Task<MealDetailsVM> GetMealDetailsVM(Meal meal);

		// GETS MEAL MANAGE INGREDIENTS VIEW MODEL FOR THE SPECIFIED MEAL ID.
		Task<MealManageIngredientsVM> GetMealManageIngredientsVM(int? id);

		// ADDS AN INGREDIENT TO THE SPECIFIED MEAL.
		Task<MealManageIngredientsVM> AddIngredientToMeal(MealManageIngredientsVM mealManageIngredientsVM);

		// REMOVES AN INGREDIENT FROM THE SPECIFIED MEAL BASED ON MEAL ID AND INDEX.
		Task RemoveIngredientFromMeal(int mealId, int index);

		// GETS A LIST OF SPECIFIC MEALS BASED ON PROVIDED MEAL IDs.
		Task<List<MealIndexVM?>?> GetListOfMeals(List<int?>? mealIds);
	}
}
