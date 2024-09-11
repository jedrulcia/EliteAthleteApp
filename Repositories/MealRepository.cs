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

		public async Task CreateNewMeal(MealCreateVM mealCreateVM)
		{
			var meal = mapper.Map<Meal>(mealCreateVM);
			await AddAsync(meal);
		}

		public async Task EditMeal(MealCreateVM mealCreateVM)
		{
			var meal = await GetAsync(mealCreateVM.Id);
			meal.Name = mealCreateVM.Name;
			meal.Recipe = mealCreateVM.Recipe;
			await UpdateAsync(meal);
		}

		public async Task<List<MealVM>> GetMealIndexVM()
        {
            var mealsVM = mapper.Map<List<MealVM>>(await GetAllAsync());
            for (int i = 0; i < mealsVM.Count; i++)
			{
				mealsVM[i].Proteins = 0;
				mealsVM[i].Carbohydrates = 0;
				mealsVM[i].Fats = 0;
				for (int j = 0; j < mealsVM[i].IngredientIds.Count; j++)
				{
					IngredientVM ingredientVM = mapper.Map<IngredientVM>(await ingredientRepository.GetAsync(mealsVM[i].IngredientIds[j]));
					decimal ingredientMultiplier = mealsVM[i].IngredientQuantities[j] / (decimal)100.00;
					mealsVM[i].Proteins += Math.Round(ingredientVM.Proteins * ingredientMultiplier, 1);
					mealsVM[i].Fats += Math.Round(ingredientVM.Fats * ingredientMultiplier, 1);
					mealsVM[i].Carbohydrates += Math.Round(ingredientVM.Carbohydrates * ingredientMultiplier, 1);
				}
				mealsVM[i].Kcal = Convert.ToInt16(mealsVM[i].Proteins * 4 + mealsVM[i].Carbohydrates * 4 + mealsVM[i].Fats * 9);
			}
			return mealsVM;
        }

        public async Task<MealDetailsVM> GetMealDetailsVM(Meal meal)
        {
			var mealDetailsVM = mapper.Map<MealDetailsVM>(meal);
			mealDetailsVM = await GetTheMacrosOfSingleMeal(mealDetailsVM);
			mealDetailsVM.Ingredients = await ingredientRepository.GetListOfIngredients(mealDetailsVM.IngredientIds);
			return mealDetailsVM;
        }

        public async Task<MealManageIngredientsVM> GetMealManageIngredientsVM(int? id, bool redirectToAdmin)
		{
			var mealManageIngredientsVM = mapper.Map<MealManageIngredientsVM>(await GetAsync(id));
			mealManageIngredientsVM.AvailableIngredients = new SelectList(context.Ingredients.OrderBy(e => e.Name), "Id", "Name");
			mealManageIngredientsVM.Ingredients = await ingredientRepository.GetListOfIngredients(mealManageIngredientsVM.IngredientIds);
			mealManageIngredientsVM.RedirectToAdmin = redirectToAdmin;
			mealManageIngredientsVM = await GetTheMacrosOfSingleMeal(mealManageIngredientsVM);
			mealManageIngredientsVM = await CountTheMacrosOfSingleIngredients(mealManageIngredientsVM);
			return mealManageIngredientsVM;
		}

		public async Task<MealManageIngredientsVM> AddIngredientToMealSequence(MealManageIngredientsVM mealManageIngredientsVM)
		{
			var newIngredient = await ingredientRepository.GetAsync(mealManageIngredientsVM.NewIngredientId);
			if (newIngredient == null)
			{
				mealManageIngredientsVM.AvailableIngredients = new SelectList(context.Ingredients, "Id", "Name");
				return mealManageIngredientsVM;
			}

			var meal = await GetAsync(mealManageIngredientsVM.Id);
			if (meal.IngredientIds == null)
			{
				meal = AddListsToMeal(meal);
			}

			meal = AddIngredientToMeal(meal, mealManageIngredientsVM);
			await UpdateAsync(meal);

			return await GetMealManageIngredientsVM(mealManageIngredientsVM.Id, mealManageIngredientsVM.RedirectToAdmin);
		}

		public async Task RemoveIngredientFromMeal(int mealId, int index)
		{
			var meal = await GetAsync(mealId);
			meal.IngredientIds.RemoveAt(index);
			meal.IngredientQuantities.RemoveAt(index);
			await UpdateAsync(meal);
		}

		private async Task<T> GetTheMacrosOfSingleMeal<T>(T mealVM) where T : IMealMacrosRepository
		{
			mealVM.Proteins = 0;
			mealVM.Carbohydrates = 0;
            mealVM.Fats = 0;
            for (int i = 0; i < mealVM.IngredientIds.Count; i++)
			{
				IngredientVM ingredientVM = mapper.Map<IngredientVM>(await ingredientRepository.GetAsync(mealVM.IngredientIds[i]));
				decimal ingredientMultiplier = mealVM.IngredientQuantities[i] / (decimal)100.00;
				Console.WriteLine($"Multiplier: {ingredientMultiplier}");
				mealVM.Proteins += Math.Round(ingredientVM.Proteins * ingredientMultiplier, 1);
				mealVM.Carbohydrates += Math.Round(ingredientVM.Carbohydrates * ingredientMultiplier, 1);
				mealVM.Fats += Math.Round(ingredientVM.Fats * ingredientMultiplier, 1);
			}
			mealVM.Kcal = Convert.ToInt16(mealVM.Proteins * 4 + mealVM.Carbohydrates * 4 + mealVM.Fats * 9);
			return mealVM;
		}

		private async Task<MealManageIngredientsVM> CountTheMacrosOfSingleIngredients(MealManageIngredientsVM mealManageIngredientsVM)
		{
			mealManageIngredientsVM = AddListsToMealManageIngredientsVM(mealManageIngredientsVM);
			for (int i = 0; i < mealManageIngredientsVM.IngredientIds.Count; i++)
			{
				IngredientVM ingredientVM = mapper.Map<IngredientVM>(await ingredientRepository.GetAsync(mealManageIngredientsVM.IngredientIds[i]));
				decimal ingredientMultiplier = mealManageIngredientsVM.IngredientQuantities[i] / (decimal)100.00;
				mealManageIngredientsVM.IngredientProteins.Add(Math.Round(ingredientVM.Proteins * ingredientMultiplier, 1));
				mealManageIngredientsVM.IngredientCarbohydrates.Add(Math.Round(ingredientVM.Carbohydrates * ingredientMultiplier, 1));
				mealManageIngredientsVM.IngredientFats.Add(Math.Round(ingredientVM.Fats * ingredientMultiplier, 1));
				mealManageIngredientsVM.IngredientKcal.Add(Convert.ToInt16
					(mealManageIngredientsVM.IngredientProteins[i] * 4 + mealManageIngredientsVM.IngredientCarbohydrates[i] * 4 + mealManageIngredientsVM.IngredientFats[i] * 9));
			}
			return mealManageIngredientsVM;
		}

		private Meal AddListsToMeal(Meal meal)
		{
			meal.IngredientIds = new List<int?>();
			meal.IngredientQuantities = new List<int?>();
			return meal;
		}

		private MealManageIngredientsVM AddListsToMealManageIngredientsVM(MealManageIngredientsVM mealManageIngredientsVM)
		{
			mealManageIngredientsVM.IngredientProteins = new List<decimal>();
			mealManageIngredientsVM.IngredientCarbohydrates = new List<decimal>();
			mealManageIngredientsVM.IngredientFats = new List<decimal>();
			mealManageIngredientsVM.IngredientKcal = new List<int?>();

			return mealManageIngredientsVM;
		}

		private Meal AddIngredientToMeal(Meal meal, MealManageIngredientsVM mealManageIngredientsVM)
		{
			meal.IngredientIds.Add(mealManageIngredientsVM.NewIngredientId);
			meal.IngredientQuantities.Add(mealManageIngredientsVM.NewIngredientQuantity);
			return meal;
		}
    }
}
