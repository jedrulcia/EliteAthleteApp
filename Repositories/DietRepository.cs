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
        public async Task<DietManageMealsVM> GetDietManageMealsVM(int? id, bool redirectToAdmin)
        {
            var dietManageMealsVM = mapper.Map<DietManageMealsVM>(await GetAsync(id));
            dietManageMealsVM.AvailableMeals = new SelectList(context.Meals.OrderBy(e => e.Name), "Id", "Name");
            dietManageMealsVM.Meals = await mealRepository.GetListOfMeals(dietManageMealsVM.MealIds);
            dietManageMealsVM.RedirectToAdmin = redirectToAdmin;
/*            dietManageMealsVM = await GetMacrosOfDiet(dietManageMealsVM);*/
            /*dietManageMealsVM = await CountMacrosOfMeals(dietManageMealsVM);*/
            return dietManageMealsVM;
        }

/*        // Adds Meal to Diet
        public async Task<DietManageMealsVM> AddMealToDiet(DietManageMealsVM dietManageMealsVM)
        {
            var newIngredient = await ingredientRepository.GetAsync(dietManageMealsVM.NewIngredientId);
            if (newIngredient == null)
            {
                dietManageMealsVM.AvailableIngredients = new SelectList(context.Ingredients, "Id", "Name");
                return dietManageMealsVM;
            }

            var meal = await GetAsync(dietManageMealsVM.Id);

            meal = AddIngredientToMeal(meal, dietManageMealsVM);
            await UpdateAsync(meal);
            return await GetDietManageMealsVM(dietManageMealsVM.Id, dietManageMealsVM.RedirectToAdmin);
        }*/

        // METHODS NOT AVAILABLE OUTSIDE OF THE CLASS BELOW

        private async Task<DietManageMealsVM> GetMacrosOfDiet(DietManageMealsVM dietManageMealsVM)
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
        }
/*        // TO DO: CountMacrosOfMeals
        private async Task<MealManageIngredientsVM> CountMacrosOfIngredients(MealManageIngredientsVM mealManageIngredientsVM)
        {
            mealManageIngredientsVM = AddListsToMealManageIngredientsVM(mealManageIngredientsVM);
            for (int i = 0; i < mealManageIngredientsVM.IngredientIds.Count; i++)
            {
                IngredientVM? ingredientVM = await ingredientRepository.GetMacrosOfIngredient(mealManageIngredientsVM.IngredientIds[i], mealManageIngredientsVM.IngredientQuantities[i]);
                mealManageIngredientsVM.IngredientProteins.Add(ingredientVM.Proteins);
                mealManageIngredientsVM.IngredientCarbohydrates.Add(ingredientVM.Carbohydrates);
                mealManageIngredientsVM.IngredientFats.Add(ingredientVM.Fats);
                mealManageIngredientsVM.IngredientKcal.Add(ingredientVM.Kcal);
            }
            return mealManageIngredientsVM;
        }*/
    }
}
