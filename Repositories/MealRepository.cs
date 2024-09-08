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
				for (int j = 0; j < mealsVM[i].IngredientIds.Count; j++)
				{
					Ingredient ingredient = await ingredientRepository.GetAsync(mealsVM[i].IngredientIds[j]);
					Console.WriteLine("--------------------NAME--------------" + ingredient.Name);
					double? ingredientMultiplier = mealsVM[i].IngredientQuantities[j] / 100.00;
					mealsVM[i].Kcal += Convert.ToInt32(ingredient.Kcal * ingredientMultiplier);
					Console.WriteLine(mealsVM[i].Kcal);
					mealsVM[i].Proteins += Convert.ToInt32(ingredient.Proteins * ingredientMultiplier);
					mealsVM[i].Fats += Convert.ToInt32(ingredient.Fats * ingredientMultiplier);
					mealsVM[i].Carbohydrates += Convert.ToInt32(ingredient.Carbohydrates * ingredientMultiplier);
				}
			}
			return mealsVM;
		}
		public async Task<MealVM> GetMacrosOfTheMeal(MealVM mealVM)
		{
			for (int j = 0; j < mealVM.IngredientIds.Count; j++)
			{
				Ingredient ingredient = await ingredientRepository.GetAsync(mealVM.IngredientIds[j]);
				double? ingredientMultiplier = mealVM.IngredientQuantities[j] / 100.00;
				mealVM.Kcal += Convert.ToInt32(ingredient.Kcal * ingredientMultiplier);
				mealVM.Proteins += Convert.ToInt32(ingredient.Proteins * ingredientMultiplier);
				mealVM.Fats += Convert.ToInt32(ingredient.Fats * ingredientMultiplier);
				mealVM.Carbohydrates += Convert.ToInt32(ingredient.Carbohydrates * ingredientMultiplier);
			}

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


/*		public async Task<TrainingPlanManageExercisesVM> AddExerciseToTrainingPlanSequence(TrainingPlanManageExercisesVM trainingPlanAddExercisesVM)
		{

			trainingPlanAddExercisesVM = mapper.Map<TrainingPlanManageExercisesVM>(await GetAsync(trainingPlanAddExercisesVM.Id));
			trainingPlanAddExercisesVM.AvailableExercises = new SelectList(context.Exercises, "Id", "Name");
			trainingPlanAddExercisesVM.Exercises = await exerciseRepository.GetListOfExercises(trainingPlanAddExercisesVM.ExerciseIds);
			return trainingPlanAddExercisesVM;
		}*/
	}
}
