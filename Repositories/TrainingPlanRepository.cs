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
			await AddAsync(trainingPlan);
		}

		public async Task<TrainingPlanManageExercisesVM> GetTrainingPlanManageExercisesVM(int? id, bool redirectToAdmin)
		{
			var trainingPlanAddExercisesVM = mapper.Map<TrainingPlanManageExercisesVM>(await GetAsync(id));
			trainingPlanAddExercisesVM.AvailableExercises = new SelectList(context.Exercises.OrderBy(e => e.Name), "Id", "Name");
			trainingPlanAddExercisesVM.Exercises = await exerciseRepository.GetListOfExercises(trainingPlanAddExercisesVM.ExerciseIds);
			trainingPlanAddExercisesVM.RedirectToAdmin = redirectToAdmin;
			return trainingPlanAddExercisesVM;
		}

		public async Task<TrainingPlanManageExercisesVM> AddExerciseToTrainingPlanSequence(TrainingPlanManageExercisesVM trainingPlanAddExercisesVM)
		{
			var exercise = await exerciseRepository.GetAsync(trainingPlanAddExercisesVM.NewExerciseId);
			if (exercise == null)
			{
				trainingPlanAddExercisesVM.AvailableExercises = new SelectList(context.Exercises, "Id", "Name");
				return trainingPlanAddExercisesVM;
			}

			var trainingPlan = await GetAsync(trainingPlanAddExercisesVM.Id);
			if (trainingPlan.ExerciseIds == null)
			{
				trainingPlan = AddListsToTrainingPlan(trainingPlan);
			}
			trainingPlan = AddSingleAtributesToTrainingPlan(trainingPlan, trainingPlanAddExercisesVM);
			await UpdateAsync(trainingPlan);

			trainingPlanAddExercisesVM = mapper.Map<TrainingPlanManageExercisesVM>(await GetAsync(trainingPlanAddExercisesVM.Id));
			trainingPlanAddExercisesVM.AvailableExercises = new SelectList(context.Exercises, "Id", "Name");
			trainingPlanAddExercisesVM.Exercises = await exerciseRepository.GetListOfExercises(trainingPlanAddExercisesVM.ExerciseIds);
			return trainingPlanAddExercisesVM;
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

		private TrainingPlan AddSingleAtributesToTrainingPlan(TrainingPlan trainingPlan, TrainingPlanManageExercisesVM trainingPlanAddExercisesVM)
		{
			trainingPlan.ExerciseIds.Add(trainingPlanAddExercisesVM.NewExerciseId);
			trainingPlan.Weight.Add(trainingPlanAddExercisesVM.NewExerciseWeight);
			trainingPlan.Sets.Add(trainingPlanAddExercisesVM.NewExerciseSets);
			trainingPlan.Repeats.Add(trainingPlanAddExercisesVM.NewExerciseRepeats);
			trainingPlan.Index.Add(trainingPlanAddExercisesVM.NewExerciseIndex);
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

		public async Task<TrainingPlanCreateVM> GetTrainingPlanCreateVMForEditingView(int? id, bool redirectToAdmin)
		{
			var trainingPlan = await context.TrainingPlans.FindAsync(id);
			var trainingPlanCreateVM = mapper.Map<TrainingPlanCreateVM>(trainingPlan);
			trainingPlanCreateVM.RedirectToAdmin = redirectToAdmin;
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

		public async Task<List<TrainingPlanIndexVM>> GetUserTrainingPlans(string? userId)
        {
            if (userId == null)
            {
                var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
                userId = user.Id;
            }
            var trainingPlans = await context.TrainingPlans
                .Where(x => x.UserId == userId)
                .ToListAsync();
            return mapper.Map<List<TrainingPlanIndexVM>>(trainingPlans);
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

		public async Task<List<TrainingPlanActiveVM>> GetUserActiveTrainingPlans(string userId)
		{
			if (userId == null)
			{
				var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
				userId = user.Id;
			}
			var trainingPlans = await context.TrainingPlans
				.Where(x => x.UserId == userId)
				.Where(x => x.IsActive == true)
				.ToListAsync();
			var trainingPlanActiveVM = mapper.Map<List<TrainingPlanActiveVM>>(trainingPlans);

			for (int i = 0; i < trainingPlanActiveVM.Count; i++)
			{
				trainingPlanActiveVM[i].Exercises = await exerciseRepository.GetListOfExercises(trainingPlanActiveVM[i].ExerciseIds);
			}
			return trainingPlanActiveVM;
		}

		public async Task<TrainingPlanDetailsVM> GetTrainingPlanDetailsVM(TrainingPlan trainingPlan, bool redirectToAdmin)
		{
			var trainingPlanDetailsVM = mapper.Map<TrainingPlanDetailsVM>(trainingPlan);
			trainingPlanDetailsVM.Exercises = await exerciseRepository.GetListOfExercises(trainingPlanDetailsVM.ExerciseIds);
			trainingPlanDetailsVM.RedirectToAdmin = redirectToAdmin;
			return trainingPlanDetailsVM;
		}

		public async Task<TrainingPlanExerciseDetailsVM> GetTrainingPlanExerciseDetailsVM(int? id, string userId)
		{
			var exercise = await exerciseRepository.GetAsync(id);
			var trainingPlanExerciseDetailsVM = new TrainingPlanExerciseDetailsVM
			{
				Exercise = mapper.Map<ExerciseVM>(exercise),
				UserId = userId
			};
			return trainingPlanExerciseDetailsVM;
		}
	}
}
