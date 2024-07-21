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
		public async Task CreateTrainingPlan(TrainingPlanCreateVM model)
		{
			var trainingPlan = mapper.Map<TrainingPlan>(model);
			trainingPlan.IsActive = true;
			trainingPlan.ExerciseIds = null;
			await AddAsync(trainingPlan);
		}

		public async Task<TrainingPlanCreateVM> GetTrainingPlanVMForExerciseManagementView(int? id, bool redirectToAdmin)
		{
			var trainingPlanCreateVM = mapper.Map<TrainingPlanCreateVM>(await GetAsync(id));
			trainingPlanCreateVM.AvailableExercises = new SelectList(context.Exercises.OrderBy(e => e.Name), "Id", "Name");
			trainingPlanCreateVM.Exercises = await exerciseRepository.GetListOfExercises(trainingPlanCreateVM.ExerciseIds);
			trainingPlanCreateVM.RedirectToAdmin = redirectToAdmin;
			return trainingPlanCreateVM;
		}

		public async Task<TrainingPlanCreateVM> AddExerciseToTrainingPlanSequence(TrainingPlanCreateVM trainingPlanCreateVM)
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

		private TrainingPlan AddListsToTrainingPlan(TrainingPlan trainingPlan)
		{
			trainingPlan.ExerciseIds = new List<int?>();
			trainingPlan.Weight = new List<int?>();
			trainingPlan.Sets = new List<int?>();
			trainingPlan.Repeats = new List<int?>();
			trainingPlan.Index = new List<string?>();
			return trainingPlan;
		}

		private TrainingPlan AddSingleAtributesToTrainingPlan(TrainingPlan trainingPlan, TrainingPlanCreateVM trainingPlanCreateVM)
		{
			trainingPlan.ExerciseIds.Add(trainingPlanCreateVM.Exercise);
			trainingPlan.Weight.Add(trainingPlanCreateVM.Weight);
			trainingPlan.Sets.Add(trainingPlanCreateVM.Sets);
			trainingPlan.Repeats.Add(trainingPlanCreateVM.Repeats);
			trainingPlan.Index.Add(trainingPlanCreateVM.Index);
			return trainingPlan;
		}

		public async Task RemoveExerciseFromTrainingPlan(int id, int index)
		{
			var trainingPlan = await GetAsync(id);
			trainingPlan.ExerciseIds.RemoveAt(index);
			trainingPlan.Weight.RemoveAt(index);
			trainingPlan.Sets.RemoveAt(index);
			trainingPlan.Repeats.RemoveAt(index);
			trainingPlan.Index.RemoveAt(index);
			await UpdateAsync(trainingPlan);
		}

		public async Task<TrainingPlanCreateVM> GetTrainingPlanVMForEditingView(int? id, bool redirectToAdmin)
		{
			var trainingPlan = await context.TrainingPlans.FindAsync(id);
			var trainingPlanCreateVM = mapper.Map<TrainingPlanCreateVM>(trainingPlan);
			trainingPlanCreateVM.RedirectToAdmin = redirectToAdmin;
			trainingPlanCreateVM.AvailableExercises = new SelectList(context.Exercises, "Id", "Name");
			return trainingPlanCreateVM;
		}

		public async Task UpdateBasicTrainingPlanDetails(TrainingPlanCreateVM model)
		{
			var trainingPlan = await GetAsync(model.Id);
			trainingPlan.Name = model.Name;
			trainingPlan.Description = model.Description;
			trainingPlan.StartDate = model.StartDate;
			trainingPlan.IsActive = true;
			await UpdateAsync(trainingPlan);
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

        public async Task<List<TrainingPlanAdminVM>> GetAllTrainingPlansToVM()
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

		public async Task<TrainingPlanVM> GetDetailsOfTrainingPlan(TrainingPlan trainingPlan, bool redirectToAdmin)
		{
			var trainingPlanVM = mapper.Map<TrainingPlanVM>(trainingPlan);
			trainingPlanVM.Exercises = await exerciseRepository.GetListOfExercises(trainingPlanVM.ExerciseIds);
			trainingPlanVM.Order = await exerciseRepository.GetOrderOfExercises(trainingPlanVM.Index);
			trainingPlanVM.RedirectToAdmin = redirectToAdmin;
			return trainingPlanVM;
		}

	}
}
