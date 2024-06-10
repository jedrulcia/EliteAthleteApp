using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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
		private readonly IExerciseRepository exerciseRepository;

		public TrainingPlanRepository(ApplicationDbContext context, IMapper mapper, IExerciseRepository exerciseRepository) : base(context)
        {
			this.context = context;
			this.mapper = mapper;
			this.exerciseRepository = exerciseRepository;
		}

		public async Task<List<TrainingPlanVM>> GetUserTrainingPlans(string userId)
		{
			var trainingPlans = await context.TrainingPlans
				.Where(x => x.UserId == userId)
				.ToListAsync();
			var trainingPlansVM = mapper.Map<List<TrainingPlanVM>>(trainingPlans);
			return trainingPlansVM;
		}

		public async Task ChangeTrainingPlanStatus(int trainingPlanId, bool status)
		{
			var trainingPlan = await GetAsync(trainingPlanId);
			if(status)
			{
				trainingPlan.IsActive = true;
			}
			else
			{
				trainingPlan.IsActive = false;
			}

			await UpdateAsync(trainingPlan);
		}

		public async Task<TrainingPlan> GetTrainingPlanDetails(int? id)
		{
			var trainingPlan = await GetAsync(id);
			trainingPlan.ExerciseFirst = await exerciseRepository.GetAsync(trainingPlan.ExerciseFirstId);
			trainingPlan.ExerciseSecond = await exerciseRepository.GetAsync(trainingPlan.ExerciseSecondId);
			trainingPlan.ExerciseThird = await exerciseRepository.GetAsync(trainingPlan.ExerciseThirdId);
			trainingPlan.ExerciseFourth = await exerciseRepository.GetAsync(trainingPlan.ExerciseFourthId);
			return trainingPlan;
		}

		public async Task CreateTrainingPlan(TrainingPlanCreateVM model)
		{
			var trainingPlan = mapper.Map<TrainingPlan>(model);
			trainingPlan.IsActive = true;
			await AddAsync(trainingPlan);
		}

		public async Task UpdateTrainingPlan(TrainingPlanCreateVM model)
		{
			var trainingPlan = mapper.Map<TrainingPlan>(model);
			trainingPlan.IsActive = true;
			await UpdateAsync(trainingPlan);
		}
	}
}
