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

		public async Task EditMeal(MealVM mealVM)
		{
			var meal = mapper.Map<Meal>(mealVM);
			await UpdateAsync(meal);
		}

		public async Task<List<MealVM>> GetMacrosOfTheMeals(List<MealVM> mealsVM)
		{
			for (int i = 0; i < mealsVM.Count; i++)
			{
				mealsVM[i].Proteins = 0;
				mealsVM[i].Carbohydrates = 0;
				mealsVM[i].Fats = 0;
				for (int j = 0; j < mealsVM[i].IngredientIds.Count; j++)
				{
					Ingredient ingredient = await ingredientRepository.GetAsync(mealsVM[i].IngredientIds[j]);
					double? ingredientMultiplier = mealsVM[i].IngredientQuantities[j] / 100.00;
					mealsVM[i].Proteins += (ingredient.Proteins * ingredientMultiplier);
					mealsVM[i].Fats += (ingredient.Fats * ingredientMultiplier);
					mealsVM[i].Carbohydrates += (ingredient.Carbohydrates * ingredientMultiplier);
				}
				mealsVM[i].Kcal = mealsVM[i].Proteins * 4 + mealsVM[i].Carbohydrates * 4 + mealsVM[i].Fats * 9;
			}
			return mealsVM;
		}
		public async Task<MealVM> GetMacrosOfTheMeal(MealVM mealVM)
		{
			mealVM.Proteins = 0;
			mealVM.Carbohydrates = 0;
			mealVM.Fats = 0;
			for (int j = 0; j < mealVM.IngredientIds.Count; j++)
			{
				Ingredient ingredient = await ingredientRepository.GetAsync(mealVM.IngredientIds[j]);
				double? ingredientMultiplier = mealVM.IngredientQuantities[j] / 100.00;
				mealVM.Proteins += Convert.ToInt32(ingredient.Proteins * ingredientMultiplier);
				mealVM.Fats += Convert.ToInt32(ingredient.Fats * ingredientMultiplier);
				mealVM.Carbohydrates += Convert.ToInt32(ingredient.Carbohydrates * ingredientMultiplier);
			}
			mealVM.Kcal = mealVM.Proteins * 4 + mealVM.Carbohydrates * 4 + mealVM.Fats * 9;

			return mealVM;
		}

		public async Task<MealManageIngredientsVM> GetMealManageIngredientsVM(int? id, bool redirectToAdmin)
		{
			var mealManageIngredientsVM = mapper.Map<MealManageIngredientsVM>(await GetAsync(id));
			mealManageIngredientsVM.AvailableIngredients = new SelectList(context.Ingredients.OrderBy(e => e.Name), "Id", "Name");
			mealManageIngredientsVM.Ingredients = await ingredientRepository.GetListOfIngredients(mealManageIngredientsVM.IngredientIds);
			mealManageIngredientsVM.RedirectToAdmin = redirectToAdmin;
			return mealManageIngredientsVM;
		}

		public async Task<MealManageIngredientsVM> AddIngredientToMealSequence(MealManageIngredientsVM mealManageIngredientsVM)
		{
			var ingredient = await ingredientRepository.GetAsync(mealManageIngredientsVM.NewIngredientId);
			if (ingredient == null)
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

			mealManageIngredientsVM = mapper.Map<MealManageIngredientsVM>(await GetAsync(mealManageIngredientsVM.Id));
			mealManageIngredientsVM.AvailableIngredients = new SelectList(context.Ingredients, "Id", "Name");
			mealManageIngredientsVM.Ingredients = await ingredientRepository.GetListOfIngredients(mealManageIngredientsVM.IngredientIds);
			return mealManageIngredientsVM;
		}

		public Meal AddListsToMeal(Meal meal)
		{
			meal.IngredientIds = new List<int?>();
			meal.IngredientQuantities = new List<int?>();
			return meal;
		}

		public Meal AddIngredientToMeal(Meal meal, MealManageIngredientsVM mealManageIngredientsVM)
		{
			meal.IngredientIds.Add(mealManageIngredientsVM.NewIngredientId);
			meal.IngredientQuantities.Add(mealManageIngredientsVM.NewIngredientQuantity);
			return meal;
		}

		public async Task RemoveIngredientFromMeal(int mealId, int index)
		{
			var meal = await GetAsync(mealId);
			meal.IngredientIds.RemoveAt(index);
			meal.IngredientQuantities.RemoveAt(index);
			await UpdateAsync(meal);
		}

	}
}
