using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Repositories
{
    public class TrainingPlanRepository : GenericRepository<TrainingPlan>, ITrainingPlanRepository
    {
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

        public TrainingPlanRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
			this.context = context;
			this.mapper = mapper;
        }

		public async Task<List<TrainingPlanVM>> GetUserTrainingPlans(string userId)
		{
			var trainingPlans = await context.TrainingPlans
				.Where(x => x.UserId == userId)
				.ToListAsync();
			var trainingPlansVM = mapper.Map<List<TrainingPlanVM>>(trainingPlans);
			return trainingPlansVM;
		}
	}
}
