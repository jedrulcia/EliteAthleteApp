using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Contracts
{
	public interface IMealRepository : IGenericRepository<Meal>
	{
		Task CreateNewMeal(MealCreateVM mealCreateVM);
		Task EditMeal(MealVM mealVM);
	}
}
