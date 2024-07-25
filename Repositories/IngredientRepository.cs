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
	}
}
