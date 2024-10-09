using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Ingredient;
using TrainingPlanApp.Web.Models.Meal;

namespace TrainingPlanApp.Web.Repositories
{
    public class MealRepository : GenericRepository<Meal>, IMealRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;
		private readonly IIngredientRepository ingredientRepository;
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public MealRepository(
			ApplicationDbContext context, 
			IMapper mapper, 
			IIngredientRepository ingredientRepository, 
			UserManager<User> userManager, 
			IHttpContextAccessor httpContextAccessor) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
			this.ingredientRepository = ingredientRepository;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        // Creates new database entity in Meal table
        public async Task CreateMeal(MealCreateVM mealCreateVM)
		{
			var dietician = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			var meal = mapper.Map<Meal>(mealCreateVM);
            meal.IngredientIds = new List<int?>();
            meal.IngredientQuantities = new List<int?>();
			meal.DieticianId = dietician.Id;
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
        public async Task<MealIndexVM> GetMealIndexVM()
        {
            var mealVMs = mapper.Map<List<MealVM>>(await GetAllAsync());
            for (int i = 0; i < mealVMs.Count; i++)
			{
				mealVMs[i].Proteins = 0;
				mealVMs[i].Carbohydrates = 0;
				mealVMs[i].Fats = 0;
				mealVMs[i].Fibres = 0;
				for (int j = 0; j < mealVMs[i].IngredientIds.Count; j++)
                {
                    IngredientVM? ingredientVM = await ingredientRepository.GetMacrosOfIngredient(mealVMs[i].IngredientIds[j], mealVMs[i].IngredientQuantities[j]);
					mealVMs[i].Proteins += ingredientVM.Proteins;
					mealVMs[i].Carbohydrates += ingredientVM.Carbohydrates;
					mealVMs[i].Fats += ingredientVM.Fats;
					mealVMs[i].Fibres += ingredientVM.Fibres;
				}
				mealVMs[i].Kcal = Convert.ToInt16(mealVMs[i].Proteins * 4 + mealVMs[i].Carbohydrates * 4 + mealVMs[i].Fats * 9);
			}

			var dietician = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);

			var mealIndexVM = new MealIndexVM
			{
				MealVMs = mealVMs,
				MealCreateVM = new MealCreateVM(),
				DieticianId = dietician.Id
			};

			return mealIndexVM;
        }

        // Gets MealManageIngredientsVM
        public async Task<MealManageIngredientsVM> GetMealManageIngredientsVM(int? id)
		{
			var mealManageIngredientsVM = mapper.Map<MealManageIngredientsVM>(await GetAsync(id));
			mealManageIngredientsVM.AvailableIngredients = new SelectList(context.Ingredients.OrderBy(e => e.Name), "Id", "Name");
			mealManageIngredientsVM.Ingredients = await ingredientRepository.GetListOfIngredients(mealManageIngredientsVM.IngredientIds);
			mealManageIngredientsVM = await CountMacrosForMealManageIngredientVM(mealManageIngredientsVM);/*
			mealManageIngredientsVM = await GetMacrosOfMeal(mealManageIngredientsVM);*/
			return mealManageIngredientsVM;
		}

        // Adds Ingredient to Meal
        public async Task AddIngredientToMeal(MealManageIngredientsVM mealManageIngredientsVM)
		{
			var meal = await GetAsync(mealManageIngredientsVM.Id);

			meal.IngredientIds.Add(mealManageIngredientsVM.NewIngredientId);
			meal.IngredientQuantities.Add(mealManageIngredientsVM.NewIngredientQuantity);
			await UpdateAsync(meal);
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

        // PRIVATE METHODS BELOW

        // Counts the macros of list of ingredients
		private async Task<MealManageIngredientsVM> CountMacrosForMealManageIngredientVM(MealManageIngredientsVM mealManageIngredientsVM)
		{
			mealManageIngredientsVM = AddListsToMealManageIngredientsVM(mealManageIngredientsVM);
			for (int i = 0; i < mealManageIngredientsVM.IngredientIds.Count; i++)
			{
				IngredientVM? ingredientVM = await ingredientRepository.GetMacrosOfIngredient(mealManageIngredientsVM.IngredientIds[i], mealManageIngredientsVM.IngredientQuantities[i]);
				mealManageIngredientsVM.IngredientProteins.Add(ingredientVM.Proteins);
				mealManageIngredientsVM.IngredientCarbohydrates.Add(ingredientVM.Carbohydrates);
				mealManageIngredientsVM.IngredientFats.Add(ingredientVM.Fats);
				mealManageIngredientsVM.IngredientKcal.Add(ingredientVM.Kcal);
				mealManageIngredientsVM.IngredientFibres.Add(ingredientVM.Fibres);
			}
			mealManageIngredientsVM.Proteins = mealManageIngredientsVM.IngredientProteins.Sum();
			mealManageIngredientsVM.Carbohydrates = mealManageIngredientsVM.IngredientCarbohydrates.Sum();
			mealManageIngredientsVM.Fats = mealManageIngredientsVM.IngredientFats.Sum();
			mealManageIngredientsVM.Kcal = mealManageIngredientsVM.IngredientKcal.Sum();
			mealManageIngredientsVM.Fibres = mealManageIngredientsVM.IngredientFibres.Sum();
			return mealManageIngredientsVM;
		}

		// Adds empty lists to the MealManageIngredientsVM

		private MealManageIngredientsVM AddListsToMealManageIngredientsVM(MealManageIngredientsVM mealManageIngredientsVM)
		{
			mealManageIngredientsVM.IngredientProteins = new List<decimal>();
			mealManageIngredientsVM.IngredientCarbohydrates = new List<decimal>();
			mealManageIngredientsVM.IngredientFats = new List<decimal>();
			mealManageIngredientsVM.IngredientFibres = new List<decimal>();
			mealManageIngredientsVM.IngredientKcal = new List<int?>();

			return mealManageIngredientsVM;
		}
    }
}
