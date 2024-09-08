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
			await AddAsync(ingredient);
		}

		public async Task EditIngredient(IngredientVM ingredientVM)
		{
			var ingredient = mapper.Map<Ingredient>(ingredientVM);
			await UpdateAsync(ingredient);
		}

		public async Task<List<IngredientVM>> GetIngredientVM()
		{
			var ingredientVM = mapper.Map<List<IngredientVM>>(await GetAllAsync());
			for (var i = 0; i < ingredientVM.Count; i++) 
			{
				ingredientVM[i].Kcal = ingredientVM[i].Proteins * 4 + ingredientVM[i].Carbohydrates * 4 + ingredientVM[i].Fats * 9;
			}
			return ingredientVM;
		}

		public async Task<List<IngredientVM?>?> GetListOfIngredients(List<int?>? ingredientIds)
		{
            List<IngredientVM> ingredients = new List<IngredientVM>();
			foreach (int id in ingredientIds)
            {
                var ingredientVM = mapper.Map<IngredientVM>(await GetAsync(id));
                ingredients.Add(ingredientVM);
            }
            return ingredients;
		}


	}
}
