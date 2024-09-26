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

        public TrainingPlanRepository(ApplicationDbContext context, 
            IMapper mapper, 
            IExerciseRepository exerciseRepository, 
            UserManager<User> userManager, 
            IHttpContextAccessor httpContextAccessor) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.exerciseRepository = exerciseRepository;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        // Gets list of specific Module Training Plans
        public async Task<List<TrainingPlanIndexVM>> GetTrainingPlanIndexVM(List<int> trainingPlanIds)
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
			trainingPlanDetailsVM.ExerciseUnitTypes = await exerciseRepository.GetListOfExerciseUnitTypes(trainingPlanDetailsVM.ExerciseUnitTypeIds);
			return trainingPlanDetailsVM;
		}

		// Gets TrainingPlanManageExercisesVM
		public async Task<TrainingPlanManageExercisesVM> GetTrainingPlanManageExercisesVM(int? id)
		{
			var trainingPlanManageExercisesVM = mapper.Map<TrainingPlanManageExercisesVM>(await GetAsync(id));
			trainingPlanManageExercisesVM.AvailableExercises = new SelectList(context.Exercises.OrderBy(e => e.Name), "Id", "Name");
			trainingPlanManageExercisesVM.AvailableExerciseUnitTypes = new SelectList(context.ExerciseUnitTypes.OrderBy(e => e.Name), "Id", "Name");
			trainingPlanManageExercisesVM.Exercises = await exerciseRepository.GetListOfExercises(trainingPlanManageExercisesVM.ExerciseIds);
			return trainingPlanManageExercisesVM;
		}

		// Creates new database entity in TrainingPlan table
		public async Task<int> CreateTrainingPlan(TrainingPlanCreateVM trainingPlanCreateVM)
		{
			var trainingPlan = mapper.Map<TrainingPlan>(trainingPlanCreateVM);

			trainingPlan.Index = new List<string?>();
			trainingPlan.ExerciseIds = new List<int?>();
			trainingPlan.Weight = new List<int?>();
            trainingPlan.Sets = new List<int?>();
            trainingPlan.UnitAmounts = new List<int?>();
			trainingPlan.Units = new List<string?>();
			trainingPlan.ExerciseUnitTypeIds = new List<int?>();
            trainingPlan.BreakTimes = new List<int?>();
            trainingPlan.Notes = new List<string?>();
			trainingPlan.IsCompleted = false;
			trainingPlan.IsEmpty = true;
			await context.AddAsync(trainingPlan);
            await context.SaveChangesAsync();
            return trainingPlan.Id;
        }

        // Adds Exercise to Training Plan
        public async Task<TrainingPlanManageExercisesVM> AddExerciseToTrainingPlan(TrainingPlanManageExercisesVM trainingPlanManageExercisesVM)
		{
			var exercise = await exerciseRepository.GetAsync(trainingPlanManageExercisesVM.NewExerciseId);
			if (exercise == null)
			{
				trainingPlanManageExercisesVM.AvailableExercises = new SelectList(context.Exercises.OrderBy(e => e.Name), "Id", "Name");
				trainingPlanManageExercisesVM.AvailableExerciseUnitTypes = new SelectList(context.ExerciseUnitTypes.OrderBy(e => e.Name), "Id", "Name");
				return trainingPlanManageExercisesVM;
			}

			var trainingPlan = await GetAsync(trainingPlanManageExercisesVM.Id);
			trainingPlan.Index.Add(trainingPlanManageExercisesVM.NewExerciseIndex);
			trainingPlan.ExerciseIds.Add(trainingPlanManageExercisesVM.NewExerciseId);
			trainingPlan.Weight.Add(trainingPlanManageExercisesVM.NewExerciseWeight);
			trainingPlan.Sets.Add(trainingPlanManageExercisesVM.NewExerciseSets);
			trainingPlan.UnitAmounts.Add(trainingPlanManageExercisesVM.NewExerciseUnitAmount);
			trainingPlan.Units.Add(trainingPlanManageExercisesVM.NewExerciseUnit);
			trainingPlan.ExerciseUnitTypeIds.Add(trainingPlanManageExercisesVM.NewExerciseUnitTypeId);
			trainingPlan.BreakTimes.Add(trainingPlanManageExercisesVM.NewExerciseBreakTime);
			trainingPlan.Notes.Add(trainingPlanManageExercisesVM.NewExerciseNote);
			trainingPlan.IsEmpty = false;
			await UpdateAsync(trainingPlan);

			trainingPlanManageExercisesVM = mapper.Map<TrainingPlanManageExercisesVM>(await GetAsync(trainingPlanManageExercisesVM.Id));
			trainingPlanManageExercisesVM.AvailableExercises = new SelectList(context.Exercises, "Id", "Name");
			trainingPlanManageExercisesVM.Exercises = await exerciseRepository.GetListOfExercises(trainingPlanManageExercisesVM.ExerciseIds);
			return trainingPlanManageExercisesVM;
		}

        // Removes Exercise from Training Plan
        public async Task RemoveExerciseFromTrainingPlan(int id, int index)
		{
			var trainingPlan = await GetAsync(id);
			trainingPlan.Index.RemoveAt(index);
			trainingPlan.ExerciseIds.RemoveAt(index);
			trainingPlan.Weight.RemoveAt(index);
			trainingPlan.Sets.RemoveAt(index);
			trainingPlan.UnitAmounts.RemoveAt(index);
			trainingPlan.Units.RemoveAt(index);
			trainingPlan.ExerciseUnitTypeIds.RemoveAt(index);
			trainingPlan.BreakTimes.RemoveAt(index);
			trainingPlan.Notes.RemoveAt(index);
			if (trainingPlan.ExerciseIds.Count == 0)
            {
                trainingPlan.IsEmpty = true;
            }
			await UpdateAsync(trainingPlan);
		}

        // Changes the status of Training Plan (Active/Not Active)
        public async Task ChangeTrainingPlanCompletionStatus(int trainingPlanId, bool status)
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

        // METHODS NOT AVAILABLE OUTSIDE OF THE CLASS BELOW

    }
}
