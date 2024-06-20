using AutoMapper;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Repositories
{
	public class MealRepository : GenericRepository<Meal>, IMealRepository
	{
        private readonly IMapper mapper;

        public MealRepository(ApplicationDbContext context, IMapper mapper) : base(context)
		{
            this.mapper = mapper;
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
    }
}
