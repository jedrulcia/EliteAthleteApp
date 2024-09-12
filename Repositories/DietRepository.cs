using AutoMapper;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Repositories
{
	public class DietRepository : GenericRepository<Diet>, IDietRepository
	{
		private readonly IMapper mapper;

		public DietRepository(ApplicationDbContext context, IMapper mapper) : base(context)
		{
			this.mapper = mapper;
		}

		public async Task CreateDiet(DietCreateVM dietCreateVM)
		{
			var diet = mapper.Map<Diet>(dietCreateVM);
			diet.IsActive = true; 
            diet.MealIds = Enumerable.Repeat<int?>(null, 35).ToList();
            Console.WriteLine($"list length: {diet.MealIds.Count}");
            await AddAsync(diet);
		}
        public async Task ChangeDietStatus(int dietId, bool status)
        {
            var diet = await GetAsync(dietId);
            if (status)
            {
                diet.IsActive = true;
            }
            else
            {
                diet.IsActive = false;
            }

            await UpdateAsync(diet);
        }

        public async Task UpdateDiet(DietCreateVM dietCreateVM)
        {
            var diet = await GetAsync(dietCreateVM.Id);
            diet.Name = dietCreateVM.Name;
            diet.StartDate = dietCreateVM.StartDate;
            diet.Description = dietCreateVM.Description;
            diet.IsActive = true;
            await UpdateAsync(diet);
        }
    }
}
