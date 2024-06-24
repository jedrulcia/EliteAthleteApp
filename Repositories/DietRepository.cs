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
            var diet = mapper.Map<Diet>(dietCreateVM);
            diet.IsActive = true;
            await UpdateAsync(diet);
        }
    }
}
