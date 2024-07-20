using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public TrainingPlanRepository(ApplicationDbContext context, IMapper mapper, IExerciseRepository exerciseRepository, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.exerciseRepository = exerciseRepository;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<TrainingPlanVM>> GetUserTrainingPlans(string? userId)
        {
            if (userId == null)
            {
                var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
                userId = user.Id;
            }
            var trainingPlans = await context.TrainingPlans
                .Where(x => x.UserId == userId)
                .ToListAsync();
            return mapper.Map<List<TrainingPlanVM>>(trainingPlans);
        }

        public async Task ChangeTrainingPlanStatus(int trainingPlanId, bool status)
        {
            var trainingPlan = await GetAsync(trainingPlanId);
            if (status)
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
            return trainingPlan;
        }

        public async Task CreateTrainingPlan(TrainingPlanCreateVM model)
        {
            var trainingPlan = mapper.Map<TrainingPlan>(model);
            trainingPlan.IsActive = true;
            trainingPlan.ExerciseIds = null;
            await AddAsync(trainingPlan);
        }

        public async Task UpdateTrainingPlan(TrainingPlanCreateVM model)
        {
            var trainingPlan = await GetAsync(model.Id);
            trainingPlan.Name = model.Name;
            trainingPlan.Description = model.Description;
            trainingPlan.StartDate = model.StartDate;
            trainingPlan.IsActive = true;
            await UpdateAsync(trainingPlan);
        }

        public async Task<List<TrainingPlanAdminVM>> GetAllTrainingPlans()
        {
            var trainingPlans = await context.TrainingPlans.ToListAsync();
            var trainingPlansVM = mapper.Map<List<TrainingPlanAdminVM>>(trainingPlans);
            foreach (var trainingPlan in trainingPlansVM)
            {
                var user = await userManager.FindByIdAsync(trainingPlan.UserId);
                trainingPlan.FirstName = user.FirstName;
                trainingPlan.LastName = user.LastName;
            }
            return trainingPlansVM;
        }

        public async Task<TrainingPlanCreateVM> AddExerciseSequence(TrainingPlanCreateVM trainingPlanCreateVM)
        {
            var exercise = await exerciseRepository.GetAsync(trainingPlanCreateVM.Exercise);
            if (exercise == null)
			{
				trainingPlanCreateVM.AvailableExercises = new SelectList(context.Exercises, "Id", "Name");
				return trainingPlanCreateVM;
			}

            var trainingPlan = await GetAsync(trainingPlanCreateVM.Id);
            if (trainingPlan.ExerciseIds == null)
            {
                trainingPlan = AddListsToTrainingPlan(trainingPlan);
            }
            trainingPlan = AddSingleAtributesToTrainingPlan(trainingPlan, trainingPlanCreateVM);
            await UpdateAsync(trainingPlan);

            trainingPlanCreateVM = mapper.Map<TrainingPlanCreateVM>(await GetAsync(trainingPlanCreateVM.Id));
            trainingPlanCreateVM.AvailableExercises = new SelectList(context.Exercises, "Id", "Name");
			trainingPlanCreateVM.Exercises = await exerciseRepository.GetListOfExercises(trainingPlanCreateVM.ExerciseIds);
			return trainingPlanCreateVM;
        }

        public TrainingPlan AddListsToTrainingPlan(TrainingPlan trainingPlan)
        {
			trainingPlan.ExerciseIds = new List<int?>();
			trainingPlan.Weight = new List<int?>();
			trainingPlan.Sets = new List<int?>();
			trainingPlan.Repeats = new List<int?>();
			trainingPlan.Index = new List<string?>();
			return trainingPlan;
        }
        public TrainingPlan AddSingleAtributesToTrainingPlan(TrainingPlan trainingPlan, TrainingPlanCreateVM trainingPlanCreateVM)
		{
			trainingPlan.ExerciseIds.Add(trainingPlanCreateVM.Exercise);
			trainingPlan.Weight.Add(trainingPlanCreateVM.Weight);
			trainingPlan.Sets.Add(trainingPlanCreateVM.Sets);
			trainingPlan.Repeats.Add(trainingPlanCreateVM.Repeats);
			trainingPlan.Index.Add(trainingPlanCreateVM.Index);
			return trainingPlan;
        }
    }
}
