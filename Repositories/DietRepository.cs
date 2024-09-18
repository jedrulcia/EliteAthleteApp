using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Repositories
{
    public class DietRepository : GenericRepository<Diet>, IDietRepository
    {
        private readonly IMapper mapper;
        private readonly IMealRepository mealRepository;
        private readonly IIngredientRepository ingredientRepository;
        private readonly ApplicationDbContext context;

        public DietRepository(ApplicationDbContext context, IMapper mapper, IMealRepository mealRepository, IIngredientRepository ingredientRepository) : base(context)
        {
            this.mapper = mapper;
            this.mealRepository = mealRepository;
            this.ingredientRepository = ingredientRepository;
            this.context = context;
        }

        // Creates new database entity in diet table
        public async Task CreateDiet(DietCreateVM dietCreateVM)
        {
            var diet = mapper.Map<Diet>(dietCreateVM);
            diet.IsActive = false;
            diet.MealIds = Enumerable.Repeat<int?>(null, 35).ToList();
			diet.MealQuantities = Enumerable.Repeat<int?>(100, 35).ToList();
			Console.WriteLine($"list length: {diet.MealIds.Count}");
            await AddAsync(diet);
        }

        // Edits the Name, Description, StartDate of diet
        public async Task EditDiet(DietCreateVM dietCreateVM)
        {
            var diet = await GetAsync(dietCreateVM.Id);
            diet.Name = dietCreateVM.Name;
            diet.StartDate = dietCreateVM.StartDate;
            diet.Description = dietCreateVM.Description;
            await UpdateAsync(diet);
        }

        // Changes status of diet (Active/Not Active)
        public async Task ChangeDietStatus(int dietId, bool status)
        {
            var diet = await GetAsync(dietId);
            if (status)
            {
                diet.IsActive = true;
            }
            else
            {
                diet.IsActive = false;
            }
            await UpdateAsync(diet);
        }

        // Gets DietManageMealsVM
        public async Task<DietManageMealsVM> GetDietManageMealsVM(int? id, bool? redirectToAdmin)
        {
            var dietManageMealsVM = mapper.Map<DietManageMealsVM>(await GetAsync(id));
            dietManageMealsVM.AvailableMeals = new SelectList(context.Meals.OrderBy(e => e.Name), "Id", "Name");
            dietManageMealsVM.Meals = await mealRepository.GetListOfMeals(dietManageMealsVM.MealIds);
            dietManageMealsVM.RedirectToAdmin = redirectToAdmin;
			dietManageMealsVM = await GetMacrosOfMeals(dietManageMealsVM);
			/*dietManageMealsVM = await GetMacrosOfDiets(dietManageMealsVM);*/
			return dietManageMealsVM;
        }

        // Adds Meal to Diet
        public async Task<DietManageMealsVM> AddMealToDiet(DietManageMealsVM dietManageMealsVM, int index)
        {
            var newMeal = await mealRepository.GetAsync(dietManageMealsVM.NewMealId);
            if (newMeal == null)
            {
                dietManageMealsVM.AvailableMeals = new SelectList(context.Meals, "Id", "Name");
                return dietManageMealsVM;
            }

            var diet = await GetAsync(dietManageMealsVM.Id);
            diet.MealIds[index] = dietManageMealsVM.NewMealId;
            await UpdateAsync(diet);
            return await GetDietManageMealsVM(dietManageMealsVM.Id, dietManageMealsVM.RedirectToAdmin);
		}        

        // Adds Quantity to Meal from Diet
		public async Task<DietManageMealsVM> AddQuantityToMeal(DietManageMealsVM dietManageMealsVM, int index)
		{
			var diet = await GetAsync(dietManageMealsVM.Id);
			diet.MealQuantities[index] = dietManageMealsVM.NewMealQuantity;
			await UpdateAsync(diet);
			return await GetDietManageMealsVM(dietManageMealsVM.Id, dietManageMealsVM.RedirectToAdmin);
		}

		// Removes Meal from Diet
		public async Task RemoveMealFromDiet(int dietId, int index)
		{
			var diet = await GetAsync(dietId);
            diet.MealIds[index] = null;
			await UpdateAsync(diet);
		}

		// METHODS NOT AVAILABLE OUTSIDE OF THE CLASS BELOW

/*		private async Task<DietManageMealsVM> GetMacrosOfDiets(DietManageMealsVM dietManageMealsVM)
        {
            dietManageMealsVM.Proteins = 0;
            dietManageMealsVM.Carbohydrates = 0;
            dietManageMealsVM.Fats = 0;
            for (int i = 0; i < dietManageMealsVM.MealIds.Count; i++)
            {
                MealIndexVM mealIndexVM = mapper.Map<MealIndexVM>(await mealRepository.GetAsync(dietManageMealsVM.MealIds[i]));
                for (int j = 0; j < mealIndexVM.IngredientIds.Count; j++)
                {
                    IngredientVM? ingredientVM = await ingredientRepository.GetMacrosOfIngredient(mealIndexVM.IngredientIds[i], mealIndexVM.IngredientQuantities[i]);
                    dietManageMealsVM.Proteins += ingredientVM.Proteins;
                    dietManageMealsVM.Carbohydrates += ingredientVM.Carbohydrates;
                    dietManageMealsVM.Fats += ingredientVM.Fats;
                }
            }
            dietManageMealsVM.Kcal = Convert.ToInt16(dietManageMealsVM.Proteins * 4 + dietManageMealsVM.Carbohydrates * 4 + dietManageMealsVM.Fats * 9);
            return dietManageMealsVM;
        }*/

        private async Task<DietManageMealsVM> GetMacrosOfMeals(DietManageMealsVM dietManageMealsVM)
        {
            dietManageMealsVM.MealKcal = Enumerable.Repeat<int>(0, 35).ToList();
			dietManageMealsVM.MealProteins = Enumerable.Repeat<decimal>(0, 35).ToList();
			dietManageMealsVM.MealCarbohydrates = Enumerable.Repeat<decimal>(0, 35).ToList();
			dietManageMealsVM.MealFats = Enumerable.Repeat<decimal>(0, 35).ToList();
			for (int i = 0; i < dietManageMealsVM.Meals.Count; i++)
            {
                if (dietManageMealsVM.Meals[i] != null)
				{
                    dietManageMealsVM.MealProteins[i] = 0;
                    dietManageMealsVM.MealCarbohydrates[i] = 0;
                    dietManageMealsVM.MealFats[i] = 0;
                    for (int j = 0; j < dietManageMealsVM.Meals[i].IngredientIds.Count; j++)
                    {
						IngredientVM? ingredientVM = await ingredientRepository.GetMacrosOfIngredient(dietManageMealsVM.Meals[i].IngredientIds[j], dietManageMealsVM.Meals[i].IngredientQuantities[j]);
                        dietManageMealsVM.MealProteins[i] += ingredientVM.Proteins;
						dietManageMealsVM.MealCarbohydrates[i] += ingredientVM.Carbohydrates;
						dietManageMealsVM.MealFats[i] += ingredientVM.Fats;
					}
                    dietManageMealsVM = await MultiplyMealByQuantity(dietManageMealsVM, i);
                    dietManageMealsVM.MealKcal[i] = Convert.ToInt32(dietManageMealsVM.MealProteins[i] * 4 + dietManageMealsVM.MealCarbohydrates[i] * 4 + dietManageMealsVM.MealFats[i] * 9);
				}
            }
			return dietManageMealsVM;
        }

        private async Task<DietManageMealsVM> MultiplyMealByQuantity(DietManageMealsVM dietManageMealsVM, int index)
		{
			decimal mealMultiplier = dietManageMealsVM.MealQuantities[index] / (decimal)100.00;
			dietManageMealsVM.MealProteins[index] = Math.Round(dietManageMealsVM.MealProteins[index] * mealMultiplier, 1);
			dietManageMealsVM.MealCarbohydrates[index] = Math.Round(dietManageMealsVM.MealCarbohydrates[index] * mealMultiplier, 1);
			dietManageMealsVM.MealFats[index] = Math.Round(dietManageMealsVM.MealFats[index] * mealMultiplier, 1);
			return dietManageMealsVM;
        }
	}
}
