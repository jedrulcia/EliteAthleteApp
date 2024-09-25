using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Exercise;
using TrainingPlanApp.Web.Models.TrainingPlan;

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

        // Creates new database entity in TrainingPlan table
        public async Task<int> CreateTrainingPlan(TrainingPlanCreateVM trainingPlanCreateVM)
		{
			var trainingPlan = mapper.Map<TrainingPlan>(trainingPlanCreateVM);
			trainingPlan.IsCompleted = true;
            trainingPlan.ExerciseIds = new List<int?>();
            trainingPlan.Weight = new List<int?>();
            trainingPlan.Sets = new List<int?>();
            trainingPlan.UnitAmount = new List<int?>();
            trainingPlan.Index = new List<string?>();
            trainingPlan.ExerciseUnitIds = new List<int?>();
            trainingPlan.UnitAmount = new List<int?>();
            trainingPlan.Units = new List<string?>();
            trainingPlan.BreakTime = new List<int?>();
            trainingPlan.Notes = new List<string?>();
            await context.AddAsync(trainingPlan);
            await context.SaveChangesAsync();
            return trainingPlan.Id;
        }

        // Edits Name, Description, StartDate of Training Plan
        public async Task EditTrainingPlan(TrainingPlanCreateVM trainingPlanCreateVM)
        {
            var trainingPlan = await GetAsync(trainingPlanCreateVM.Id);
            trainingPlan.Name = trainingPlanCreateVM.Name;
            trainingPlan.Description = trainingPlanCreateVM.Description;
            trainingPlan.Date = trainingPlanCreateVM.Date;
            trainingPlan.IsCompleted = true;
            await UpdateAsync(trainingPlan);
        }

        // Gets TrainingPlanManageExercisesVM
        public async Task<TrainingPlanManageExercisesVM> GetTrainingPlanManageExercisesVM(int? id)
		{
			var trainingPlanAddExercisesVM = mapper.Map<TrainingPlanManageExercisesVM>(await GetAsync(id));
			trainingPlanAddExercisesVM.AvailableExercises = new SelectList(context.Exercises.OrderBy(e => e.Name), "Id", "Name");
			trainingPlanAddExercisesVM.Exercises = await exerciseRepository.GetListOfExercises(trainingPlanAddExercisesVM.ExerciseIds);
			return trainingPlanAddExercisesVM;
		}

        // Adds Exercise to Training Plan
        public async Task<TrainingPlanManageExercisesVM> AddExerciseToTrainingPlan(TrainingPlanManageExercisesVM trainingPlanAddExercisesVM)
		{
			var exercise = await exerciseRepository.GetAsync(trainingPlanAddExercisesVM.NewExerciseId);
			if (exercise == null)
			{
				trainingPlanAddExercisesVM.AvailableExercises = new SelectList(context.Exercises, "Id", "Name");
				return trainingPlanAddExercisesVM;
			}

			var trainingPlan = await GetAsync(trainingPlanAddExercisesVM.Id);
			trainingPlan = AddExerciseAtributesToTrainingPlan(trainingPlan, trainingPlanAddExercisesVM);
			await UpdateAsync(trainingPlan);

			trainingPlanAddExercisesVM = mapper.Map<TrainingPlanManageExercisesVM>(await GetAsync(trainingPlanAddExercisesVM.Id));
			trainingPlanAddExercisesVM.AvailableExercises = new SelectList(context.Exercises, "Id", "Name");
			trainingPlanAddExercisesVM.Exercises = await exerciseRepository.GetListOfExercises(trainingPlanAddExercisesVM.ExerciseIds);
			return trainingPlanAddExercisesVM;
		}

        // Removes Exercise from Training Plan
        public async Task RemoveExerciseFromTrainingPlan(int id, int index)
		{
			var trainingPlan = await GetAsync(id);
			trainingPlan.ExerciseIds.RemoveAt(index);
			trainingPlan.Weight.RemoveAt(index);
			trainingPlan.Sets.RemoveAt(index);
			trainingPlan.UnitAmount.RemoveAt(index);
			trainingPlan.Index.RemoveAt(index);
			await UpdateAsync(trainingPlan);
		}

        // Changes the status of Training Plan (Active/Not Active)
        public async Task ChangeTrainingPlanStatus(int trainingPlanId, bool status)
		{
			var trainingPlan = await GetAsync(trainingPlanId);
			if (status)
			{
				trainingPlan.IsCompleted = true;
			}
			else
			{
				trainingPlan.IsCompleted = false;
			}
			await UpdateAsync(trainingPlan);
		}

        // Gets list of specific User Training Plans
        public async Task<List<TrainingPlanIndexVM>> GetModuleTrainingPlans(List<int?>? trainingPlanIds)
        {
            List<TrainingPlanIndexVM> trainingPlanIndexVM = new List<TrainingPlanIndexVM>();
            foreach (int id in trainingPlanIds)
            {
                var trainingPlanVM = mapper.Map<TrainingPlanIndexVM>(await GetAsync(id));
                trainingPlanIndexVM.Add(trainingPlanVM);
            }
            return trainingPlanIndexVM;
        }

        // Gets TrainingPlanDetailsVM
        public async Task<TrainingPlanDetailsVM> GetTrainingPlanDetailsVM(TrainingPlan trainingPlan)
		{
			var trainingPlanDetailsVM = mapper.Map<TrainingPlanDetailsVM>(trainingPlan);
			trainingPlanDetailsVM.Exercises = await exerciseRepository.GetListOfExercises(trainingPlanDetailsVM.ExerciseIds);
			return trainingPlanDetailsVM;
		}

        // METHODS NOT AVAILABLE OUTSIDE OF THE CLASS BELOW

        // 
        private TrainingPlan AddExerciseAtributesToTrainingPlan(TrainingPlan trainingPlan, TrainingPlanManageExercisesVM trainingPlanAddExercisesVM)
        {
            trainingPlan.ExerciseIds.Add(trainingPlanAddExercisesVM.NewExerciseId);
            trainingPlan.Weight.Add(trainingPlanAddExercisesVM.NewExerciseWeight);
            trainingPlan.Sets.Add(trainingPlanAddExercisesVM.NewExerciseSets);
            trainingPlan.UnitAmount.Add(trainingPlanAddExercisesVM.NewExerciseRepeats);
            trainingPlan.Index.Add(trainingPlanAddExercisesVM.NewExerciseIndex);
            return trainingPlan;
        }
    }
}
