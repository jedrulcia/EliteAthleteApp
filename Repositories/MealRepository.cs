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

		public async Task<List<MealVM>> GetMacrosOfFewMeals(List<MealVM> mealsVM)
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
		public async Task<MealManageIngredientsVM> GetMealManageIngredientsVM(int? id, bool redirectToAdmin)
		{
			var mealManageIngredientsVM = mapper.Map<MealManageIngredientsVM>(await GetAsync(id));
			mealManageIngredientsVM.AvailableIngredients = new SelectList(context.Ingredients.OrderBy(e => e.Name), "Id", "Name");
			mealManageIngredientsVM.Ingredients = await ingredientRepository.GetListOfIngredients(mealManageIngredientsVM.IngredientIds);
			mealManageIngredientsVM.RedirectToAdmin = redirectToAdmin;
			mealManageIngredientsVM = await CountTheMacrosOfSingleMeal(mealManageIngredientsVM);
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

		private async Task<MealManageIngredientsVM> CountTheMacrosOfSingleMeal(MealManageIngredientsVM mealManageIngredientsVM)
		{
			mealManageIngredientsVM.Proteins = 0;
			mealManageIngredientsVM.Fats = 0;
			mealManageIngredientsVM.Carbohydrates = 0;
			for (int i = 0; i < mealManageIngredientsVM.IngredientIds.Count; i++)
			{
				Ingredient ingredient = await ingredientRepository.GetAsync(mealManageIngredientsVM.IngredientIds[i]);
				double? ingredientMultiplier = mealManageIngredientsVM.IngredientQuantities[i] / 100.00;
				mealManageIngredientsVM.Proteins += Convert.ToInt32(ingredient.Proteins * ingredientMultiplier);
				mealManageIngredientsVM.Fats += Convert.ToInt32(ingredient.Fats * ingredientMultiplier);
				mealManageIngredientsVM.Carbohydrates += Convert.ToInt32(ingredient.Carbohydrates * ingredientMultiplier);
			}
			mealManageIngredientsVM.Kcal = mealManageIngredientsVM.Proteins * 4 + mealManageIngredientsVM.Carbohydrates * 4 + mealManageIngredientsVM.Fats * 9;
			return mealManageIngredientsVM;
		}

		private Meal AddListsToMeal(Meal meal)
		{
			meal.IngredientIds = new List<int?>();
			meal.IngredientQuantities = new List<int?>();
			return meal;
		}

		private Meal AddIngredientToMeal(Meal meal, MealManageIngredientsVM mealManageIngredientsVM)
		{
			meal.IngredientIds.Add(mealManageIngredientsVM.NewIngredientId);
			meal.IngredientQuantities.Add(mealManageIngredientsVM.NewIngredientQuantity);
			return meal;
		}


	}
}
