using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Diet;

namespace TrainingPlanApp.Web.Contracts
{
	public interface IDietRepository : IGenericRepository<Diet>
	{
		// CREATES A NEW DATABASE ENTITY IN THE DIET TABLE.
		Task CreateDiet(DietCreateVM dietCreateVM);

		// EDITS THE NAME, DESCRIPTION, AND START DATE OF THE DIET.
		Task EditDiet(DietCreateVM dietCreateVM);

		// CHANGES THE STATUS OF THE DIET (ACTIVE/NOT ACTIVE).
		Task ChangeDietStatus(int dietId, bool status);

		// GETS DIETMANAGEMEALSVIEWMODEL FOR THE SPECIFIED DIET ID.
		Task<DietManageMealsVM> GetDietManageMealsVM(int? id);

		// ADDS A MEAL TO THE SPECIFIED DIET.
		Task<DietManageMealsVM> AddMealToDiet(DietManageMealsVM dietManageMealsVM, int index);

		// REMOVES A MEAL FROM THE SPECIFIED DIET.
		Task RemoveMealFromDiet(int id, int index);

		// ADDS QUANTITY TO A MEAL WITHIN THE DIET.
		Task<DietManageMealsVM> AddQuantityToMeal(DietManageMealsVM dietManageMealsVM, int index);
	}
}
