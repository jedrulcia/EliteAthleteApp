using AutoMapper;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Repositories
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public IngredientRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
        }

		public async Task CreateNewIngredient(IngredientVM ingredientVM)
		{
			var ingredient = mapper.Map<Ingredient>(ingredientVM);
			await context.AddAsync(ingredient);
		}

		/*        public async Task<MealCreateVM> AddIngredientSequence(MealCreateVM mealCreateVM)
				{

					var ingredient = mapper.Map<Ingredient>(mealCreateVM);
					await AddAsync(ingredient);
					var ingredientVM = mapper.Map<List<IngredientVM>>(context.Ingredients.Where(e => e.MealId == mealCreateVM.Id));
					mealCreateVM.Ingredients = new List<IngredientVM>(ingredientVM);
					mealCreateVM.IngredientName = null;
					mealCreateVM.IngredientServingSize = null;
					return mealCreateVM;
				}

				public MealCreateVM CreateIngredientAddingModel(Meal meal)
				{
					var mealCreateVM = mapper.Map<MealCreateVM>(meal);
					var ingredientVM = mapper.Map<List<IngredientVM>>(context.Ingredients.Where(e => e.MealId == mealCreateVM.Id));
					mealCreateVM.Ingredients = new List<IngredientVM>(ingredientVM);
					return mealCreateVM;
				}*/
	}
}
