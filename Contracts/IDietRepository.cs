using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Contracts
{
	public interface IDietRepository : IGenericRepository<Diet>
	{
		// Creates new database entity in diet table
		Task CreateDiet(DietCreateVM dietCreateVM);

        // Edits the Name, Description, StartDate of diet
        Task EditDiet(DietCreateVM dietCreateVM);

        // Changes status of diet (Active/Not Active)
        Task ChangeDietStatus(int dietId, bool status);

        // Gets DietManageMealsVM
        Task<DietManageMealsVM> GetDietManageMealsVM(int? id, bool? redirectToAdmin);

        // Adds Meal to Diet
        Task<DietManageMealsVM> AddMealToDiet(DietManageMealsVM dietManageMealsVM, int index);

        // Removes Meal From Diet
        Task RemoveMealFromDiet(int id, int index);

        // Adds Quantity to Meal from Diet
        Task<DietManageMealsVM> AddQuantityToMeal(DietManageMealsVM dietManageMealsVM, int index);
	}
}
