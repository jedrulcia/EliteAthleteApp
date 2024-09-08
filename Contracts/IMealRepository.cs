using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Contracts
{
	public interface IMealRepository : IGenericRepository<Meal>
	{
		Task CreateNewMeal(MealCreateVM mealCreateVM);
		Task EditMeal(MealVM mealVM);
		Task<List<MealVM>> GetMacrosOfTheMeals(List<MealVM> mealVM);
		Task<MealVM> GetMacrosOfTheMeal(MealVM mealVM);
		Task<MealManageIngredientsVM> GetMealManageIngredientsVM(int? id, bool redirectToAdmin);
		Task<MealManageIngredientsVM> AddIngredientToMealSequence(MealManageIngredientsVM mealManageIngredientsVM);

	}
}
