using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using OpenQA.Selenium.DevTools.V125.Page;
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

		// GETS A LIST OF SPECIFIC USER TRAINING PLANS BASED ON PROVIDED TRAINING PLAN IDs.
		public async Task<TrainingPlanIndexVM> GetTrainingPlanIndexVM(List<int> trainingPlanIds)
        {
            List<TrainingPlanVM> trainingPlanVMs = new List<TrainingPlanVM>();


            foreach (int id in trainingPlanIds)
            {
                var trainingPlanVM = mapper.Map<TrainingPlanVM>(await GetAsync(id));
                trainingPlanVMs.Add(trainingPlanVM);
            }

			var trainingPlanIndexVM = new TrainingPlanIndexVM
			{
				UserId = trainingPlanVMs[0].UserId,
				CoachId = trainingPlanVMs[0].CoachId,
				TrainingModuleId = trainingPlanVMs[0].TrainingModuleId,
				TrainingPlanVMs = trainingPlanVMs
			};
            return trainingPlanIndexVM;
		}

		// GETS THE TRAINING PLAN DETAILS VIEW MODEL FOR THE SPECIFIED TRAINING PLAN.
		public async Task<TrainingPlanDetailsVM> GetTrainingPlanDetailsVM(TrainingPlan trainingPlan)
		{
			var trainingPlanDetailsVM = mapper.Map<TrainingPlanDetailsVM>(trainingPlan);
			trainingPlanDetailsVM.Exercises = await exerciseRepository.GetListOfExercises(trainingPlanDetailsVM.ExerciseIds);
			return trainingPlanDetailsVM;
		}

		// GETS THE TRAINING PLAN MANAGE EXERCISES VIEW MODEL FOR THE SPECIFIED TRAINING PLAN ID.
		public async Task<TrainingPlanManageExercisesVM> GetTrainingPlanManageExercisesVM(int? id)
		{
			var trainingPlanManageExercisesVM = mapper.Map<TrainingPlanManageExercisesVM>(await GetAsync(id));
			trainingPlanManageExercisesVM.AvailableExercises = new SelectList(context.Exercises.OrderBy(e => e.Name), "Id", "Name");
			trainingPlanManageExercisesVM.Exercises = await exerciseRepository.GetListOfExercises(trainingPlanManageExercisesVM.ExerciseIds);
			return trainingPlanManageExercisesVM;
		}

		// CREATES A NEW DATABASE ENTITY IN THE TRAINING PLAN TABLE AND RETURNS THE NEW ID.
		public async Task<int> CreateTrainingPlan(TrainingPlanCreateVM trainingPlanCreateVM)
		{
			var trainingPlan = mapper.Map<TrainingPlan>(trainingPlanCreateVM);

			trainingPlan.ExerciseIds = new List<int?>();
			trainingPlan.Indices = new List<string?>();
            trainingPlan.Sets = new List<int?>();
			trainingPlan.Units = new List<string?>();
			trainingPlan.Weights = new List<string?>();
			trainingPlan.RestTimes = new List<string?>();
			trainingPlan.Notes = new List<string?>();
			trainingPlan.IsCompleted = false;
			trainingPlan.IsEmpty = true;
			await context.AddAsync(trainingPlan);
            await context.SaveChangesAsync();
            return trainingPlan.Id;
        }

		// ADDS AN EXERCISE TO THE SPECIFIED TRAINING PLAN.
		public async Task<TrainingPlanManageExercisesVM> AddExerciseToTrainingPlan(TrainingPlanManageExercisesVM trainingPlanManageExercisesVM)
		{
			var exercise = await exerciseRepository.GetAsync(trainingPlanManageExercisesVM.NewExerciseId);
			if (exercise == null)
			{
				trainingPlanManageExercisesVM.AvailableExercises = new SelectList(context.Exercises.OrderBy(e => e.Name), "Id", "Name");
				return trainingPlanManageExercisesVM;
			}

			var trainingPlan = await GetAsync(trainingPlanManageExercisesVM.Id);
			trainingPlan.Indices.Add(trainingPlanManageExercisesVM.NewExerciseIndex);
			trainingPlan.ExerciseIds.Add(trainingPlanManageExercisesVM.NewExerciseId);
			trainingPlan.Sets.Add(trainingPlanManageExercisesVM.NewExerciseSets);
			trainingPlan.Units.Add(trainingPlanManageExercisesVM.NewExerciseUnits);
			trainingPlan.Weights.Add(trainingPlanManageExercisesVM.NewExerciseWeight);
			trainingPlan.RestTimes.Add(trainingPlanManageExercisesVM.NewExerciseRestTime);
			trainingPlan.Notes.Add(trainingPlanManageExercisesVM.NewExerciseNote);
			trainingPlan.IsEmpty = false;
			await UpdateAsync(trainingPlan);

			trainingPlanManageExercisesVM = mapper.Map<TrainingPlanManageExercisesVM>(await GetAsync(trainingPlanManageExercisesVM.Id));
			trainingPlanManageExercisesVM.AvailableExercises = new SelectList(context.Exercises.OrderBy(e => e.Name), "Id", "Name");
			trainingPlanManageExercisesVM.Exercises = await exerciseRepository.GetListOfExercises(trainingPlanManageExercisesVM.ExerciseIds);
			return trainingPlanManageExercisesVM;
		}

		// REMOVES AN EXERCISE FROM THE SPECIFIED TRAINING PLAN BASED ON TRAINING PLAN ID AND EXERCISE INDEX.
		public async Task RemoveExerciseFromTrainingPlan(int id, int index)
		{
			var trainingPlan = await GetAsync(id);
			trainingPlan.ExerciseIds.RemoveAt(index);
			trainingPlan.Indices.RemoveAt(index);
			trainingPlan.Sets.RemoveAt(index);
			trainingPlan.Units.RemoveAt(index);
			trainingPlan.Weights.RemoveAt(index);
			trainingPlan.RestTimes.RemoveAt(index);
			trainingPlan.Notes.RemoveAt(index);
			if (trainingPlan.ExerciseIds.Count == 0)
            {
                trainingPlan.IsEmpty = true;
            }
			await UpdateAsync(trainingPlan);
		}

		// CHANGES THE STATUS OF THE TRAINING PLAN (ACTIVE/NOT ACTIVE).
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

		// COPIES A TRAINING PLAN TO ANOTHER TRAINING PLAN WITHIN THE SAME MODULE.
		public async Task CopyTrainingPlanToAnother(int copyFromId, int copyToId)
		{
			var copyFromTrainingPlan = await GetAsync(copyFromId);
			var copyToTrainingPlan = await GetAsync(copyToId);

			copyToTrainingPlan.IsEmpty = copyFromTrainingPlan.IsEmpty;
			copyToTrainingPlan.ExerciseIds = copyFromTrainingPlan.ExerciseIds;
			copyToTrainingPlan.Indices = copyFromTrainingPlan.Indices;
			copyToTrainingPlan.Sets = copyFromTrainingPlan.Sets;
			copyToTrainingPlan.Units = copyFromTrainingPlan.Units;
			copyToTrainingPlan.Weights = copyFromTrainingPlan.Weights;
			copyToTrainingPlan.RestTimes = copyFromTrainingPlan.RestTimes;
			copyToTrainingPlan.Notes = copyFromTrainingPlan.Notes;
			await UpdateAsync(copyToTrainingPlan);
		}

		// METHODS NOT AVAILABLE OUTSIDE OF THE CLASS BELOW

	}
}
