using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Contracts
{
	public interface IMealRepository : IGenericRepository<Meal>
	{
		Task CreateNewMeal(MealCreateVM mealCreateVM);
		Task EditMeal(MealCreateVM mealCreateVM);
		Task<List<MealVM>> GetMealIndexVM();
		Task<MealDetailsVM> GetMealDetailsVM(Meal meal);
        Task<MealManageIngredientsVM> GetMealManageIngredientsVM(int? id, bool redirectToAdmin);
		Task<MealManageIngredientsVM> AddIngredientToMealSequence(MealManageIngredientsVM mealManageIngredientsVM);
		Task RemoveIngredientFromMeal(int mealId, int index);
	}
}
