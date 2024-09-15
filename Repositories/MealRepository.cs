using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Repositories
{
	public class MealRepository : GenericRepository<Meal>, IMealRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;
		private readonly IIngredientRepository ingredientRepository;

		public MealRepository(ApplicationDbContext context, IMapper mapper, IIngredientRepository ingredientRepository) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
			this.ingredientRepository = ingredientRepository;
		}

        // Creates new database entity in Meal table
        public async Task CreateMeal(MealCreateVM mealCreateVM)
		{
			var meal = mapper.Map<Meal>(mealCreateVM);
            meal.IngredientIds = new List<int?>();
            meal.IngredientQuantities = new List<int?>();
            await AddAsync(meal);
		}

        // Edits Name, Recipe of meal
        public async Task EditMeal(MealCreateVM mealCreateVM)
		{
			var meal = await GetAsync(mealCreateVM.Id);
			meal.Name = mealCreateVM.Name;
			meal.Recipe = mealCreateVM.Recipe;
			await UpdateAsync(meal);
		}

        // Gets the Meal IndexVM - mainly counts the calories and macros of the meals
        public async Task<List<MealIndexVM>> GetMealIndexVM()
        {
            var mealsVM = mapper.Map<List<MealIndexVM>>(await GetAllAsync());
            for (int i = 0; i < mealsVM.Count; i++)
			{
				mealsVM[i].Proteins = 0;
				mealsVM[i].Carbohydrates = 0;
				mealsVM[i].Fats = 0;
				for (int j = 0; j < mealsVM[i].IngredientIds.Count; j++)
                {
                    IngredientVM? ingredientVM = await ingredientRepository.GetMacrosOfIngredient(mealsVM[i].IngredientIds[i], mealsVM[i].IngredientQuantities[i]);
					mealsVM[i].Proteins += ingredientVM.Proteins;
					mealsVM[i].Carbohydrates += ingredientVM.Carbohydrates;
					mealsVM[i].Fats += ingredientVM.Fats;
                }
				mealsVM[i].Kcal = Convert.ToInt16(mealsVM[i].Proteins * 4 + mealsVM[i].Carbohydrates * 4 + mealsVM[i].Fats * 9);
			}
			return mealsVM;
        }

        // Gets the MealDetailsVM
        public async Task<MealDetailsVM> GetMealDetailsVM(Meal meal)
        {
			var mealDetailsVM = mapper.Map<MealDetailsVM>(meal);
			mealDetailsVM = await GetMacrosOfMeal(mealDetailsVM);
			mealDetailsVM.Ingredients = await ingredientRepository.GetListOfIngredients(mealDetailsVM.IngredientIds);
			return mealDetailsVM;
        }

        // Gets MealManageIngredientsVM
        public async Task<MealManageIngredientsVM> GetMealManageIngredientsVM(int? id, bool redirectToAdmin)
		{
			var mealManageIngredientsVM = mapper.Map<MealManageIngredientsVM>(await GetAsync(id));
			mealManageIngredientsVM.AvailableIngredients = new SelectList(context.Ingredients.OrderBy(e => e.Name), "Id", "Name");
			mealManageIngredientsVM.Ingredients = await ingredientRepository.GetListOfIngredients(mealManageIngredientsVM.IngredientIds);
			mealManageIngredientsVM.RedirectToAdmin = redirectToAdmin;
			mealManageIngredientsVM = await GetMacrosOfMeal(mealManageIngredientsVM);
			mealManageIngredientsVM = await CountMacrosOfIngredients(mealManageIngredientsVM);
			return mealManageIngredientsVM;
		}

        // Adds Ingredient to Meal
        public async Task<MealManageIngredientsVM> AddIngredientToMeal(MealManageIngredientsVM mealManageIngredientsVM)
		{
			var newIngredient = await ingredientRepository.GetAsync(mealManageIngredientsVM.NewIngredientId);
			if (newIngredient == null)
			{
				mealManageIngredientsVM.AvailableIngredients = new SelectList(context.Ingredients, "Id", "Name");
				return mealManageIngredientsVM;
			}

			var meal = await GetAsync(mealManageIngredientsVM.Id);

			meal = AddIngredientToMeal(meal, mealManageIngredientsVM);
			await UpdateAsync(meal);
			return await GetMealManageIngredientsVM(mealManageIngredientsVM.Id, mealManageIngredientsVM.RedirectToAdmin);
		}

        // Removes Ingredient from Meal
        public async Task RemoveIngredientFromMeal(int mealId, int index)
		{
			var meal = await GetAsync(mealId);
			meal.IngredientIds.RemoveAt(index);
			meal.IngredientQuantities.RemoveAt(index);
			await UpdateAsync(meal);
        }

        // Gets the list of specific meals
        public async Task<List<MealIndexVM?>?> GetListOfMeals(List<int?>? mealIds)
        {
            List<MealIndexVM?> meals = new List<MealIndexVM>();
            foreach (int? id in mealIds)
            {
				if (id != null)
				{
					var mealIndexVM = mapper.Map<MealIndexVM>(await GetAsync(id));
					meals.Add(mealIndexVM);
				}
				else
				{
					meals.Add(null);
				}
            }
            return meals;
        }

        // Counts the macros of single meal
        public async Task<T> GetMacrosOfMeal<T>(T mealVM) where T : IMacroRepository
        {
            mealVM.Proteins = 0;
            mealVM.Carbohydrates = 0;
            mealVM.Fats = 0;
            for (int i = 0; i < mealVM.IngredientIds.Count; i++)
            {
                IngredientVM? ingredientVM = await ingredientRepository.GetMacrosOfIngredient(mealVM.IngredientIds[i], mealVM.IngredientQuantities[i]);
                mealVM.Proteins += ingredientVM.Proteins;
                mealVM.Carbohydrates += ingredientVM.Carbohydrates;
                mealVM.Fats += ingredientVM.Fats;
            }
            mealVM.Kcal = Convert.ToInt16(mealVM.Proteins * 4 + mealVM.Carbohydrates * 4 + mealVM.Fats * 9);
            return mealVM;
        }

        // METHODS NOT AVAILABLE OUTSIDE OF THE CLASS BELOW

        // Counts the macros of list of ingredients
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
		}

		// Adds empty lists to the MealManageIngredientsVM
		private MealManageIngredientsVM AddListsToMealManageIngredientsVM(MealManageIngredientsVM mealManageIngredientsVM)
		{
			mealManageIngredientsVM.IngredientProteins = new List<decimal>();
			mealManageIngredientsVM.IngredientCarbohydrates = new List<decimal>();
			mealManageIngredientsVM.IngredientFats = new List<decimal>();
			mealManageIngredientsVM.IngredientKcal = new List<int?>();

			return mealManageIngredientsVM;
		}

		// Adds Ingredient to Meal
		private Meal AddIngredientToMeal(Meal meal, MealManageIngredientsVM mealManageIngredientsVM)
		{
			meal.IngredientIds.Add(mealManageIngredientsVM.NewIngredientId);
			meal.IngredientQuantities.Add(mealManageIngredientsVM.NewIngredientQuantity);
			return meal;
		}
    }
}
