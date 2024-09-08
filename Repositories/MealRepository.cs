using AutoMapper;
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
                    double? ingredientMultiplier = mealsVM[i].IngredientQuantities[j] / 100.00;
                    mealsVM[i].Kcal += Convert.ToInt32(ingredient.Kcal * ingredientMultiplier);
                    mealsVM[i].Proteins += Convert.ToInt32(ingredient.Proteins * ingredientMultiplier);
                    mealsVM[i].Fats += Convert.ToInt32(ingredient.Fats * ingredientMultiplier);
                    mealsVM[i].Carbohydrates += Convert.ToInt32(ingredient.Carbohydrates * ingredientMultiplier);
                }
            }
            return mealsVM;
        }
    }
}
