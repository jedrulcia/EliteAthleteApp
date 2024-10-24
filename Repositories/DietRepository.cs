using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.Diet;

namespace EliteAthleteApp.Repositories
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
        public async Task<DietManageMealsVM> GetDietManageMealsVM(int? id)
        {
            var dietManageMealsVM = mapper.Map<DietManageMealsVM>(await GetAsync(id));
            dietManageMealsVM.AvailableMeals = new SelectList(context.Meals.OrderBy(e => e.Name), "Id", "Name");
            dietManageMealsVM.Meals = await mealRepository.GetListOfMeals(dietManageMealsVM.MealIds);
            dietManageMealsVM = await GetMacrosOfMeals(dietManageMealsVM);
            dietManageMealsVM = await GetMacrosOfDays(dietManageMealsVM);
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
            diet.MealQuantities[index] = 100;
            await UpdateAsync(diet);
            return await GetDietManageMealsVM(dietManageMealsVM.Id);
        }

        // Adds Quantity to Meal from Diet
        public async Task<DietManageMealsVM> AddQuantityToMeal(DietManageMealsVM dietManageMealsVM, int index)
        {
            var diet = await GetAsync(dietManageMealsVM.Id);
            diet.MealQuantities[index] = dietManageMealsVM.NewMealQuantity;
            await UpdateAsync(diet);
            return await GetDietManageMealsVM(dietManageMealsVM.Id);
        }

        // Removes Meal from Diet
        public async Task RemoveMealFromDiet(int dietId, int index)
        {
            var diet = await GetAsync(dietId);
            diet.MealIds[index] = null;
            diet.MealQuantities[index] = 100;
            await UpdateAsync(diet);
        }

        // METHODS NOT AVAILABLE OUTSIDE OF THE CLASS BELOW

        // Counts total macros of days in diet
        private async Task<DietManageMealsVM> GetMacrosOfDays(DietManageMealsVM dietManageMealsVM)
        {
            dietManageMealsVM.DayKcal = Enumerable.Repeat<int>(0, 7).ToList();
            dietManageMealsVM.DayProteins = Enumerable.Repeat<decimal>(0, 7).ToList();
            dietManageMealsVM.DayCarbohydrates = Enumerable.Repeat<decimal>(0, 7).ToList();
            dietManageMealsVM.DayFats = Enumerable.Repeat<decimal>(0, 7).ToList();
            int dayIndex = 0;
            for (int i = 0; i < dietManageMealsVM.MealIds.Count; i += 5)
            {
                for (int j = i; j < i + 5; j++)
                {
                    dietManageMealsVM.DayKcal[dayIndex] += dietManageMealsVM.MealKcal[j];
                    dietManageMealsVM.DayProteins[dayIndex] += dietManageMealsVM.MealProteins[j];
                    dietManageMealsVM.DayCarbohydrates[dayIndex] += dietManageMealsVM.MealCarbohydrates[j];
                    dietManageMealsVM.DayFats[dayIndex] += dietManageMealsVM.MealFats[j];
                }
                dayIndex++;
            }
            return dietManageMealsVM;
        }

        // Counts macros of meals
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
/*                    for (int j = 0; j < dietManageMealsVM.Meals[i].IngredientIds.Count; j++)
                    {
                        var ingredientVM = await ingredientRepository.GetMacrosOfIngredient(dietManageMealsVM.Meals[i].IngredientIds[j], dietManageMealsVM.Meals[i].IngredientQuantities[j]);
                        dietManageMealsVM.MealProteins[i] += ingredientVM.Proteins;
                        dietManageMealsVM.MealCarbohydrates[i] += ingredientVM.Carbohydrates;
                        dietManageMealsVM.MealFats[i] += ingredientVM.Fats;
                    }*/
                    dietManageMealsVM = await MultiplyMealByQuantity(dietManageMealsVM, i);
                    dietManageMealsVM.MealKcal[i] = Convert.ToInt32(dietManageMealsVM.MealProteins[i] * 4 + dietManageMealsVM.MealCarbohydrates[i] * 4 + dietManageMealsVM.MealFats[i] * 9);
                }
            }
            return dietManageMealsVM;
        }

        // Multiplies the meal by the chosen percent
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
