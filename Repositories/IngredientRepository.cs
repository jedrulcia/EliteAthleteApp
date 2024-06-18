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

        public async Task AddIngredient(MealCreateVM mealCreateVM)
        {
            var ingredient = mapper.Map<Ingredient>(mealCreateVM);
            await context.AddAsync(ingredient);
            await context.SaveChangesAsync();
        }
    }
}
