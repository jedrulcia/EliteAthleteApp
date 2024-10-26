using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.Exercise;

namespace EliteAthleteApp.Repositories
{
	public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;
		private readonly UserManager<User> userManager;
		private readonly IHttpContextAccessor httpContextAccessor;

		public ExerciseRepository(ApplicationDbContext context, IMapper mapper, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
			this.userManager = userManager;
			this.httpContextAccessor = httpContextAccessor;
		}

		// GETS EXERCISE INDEX VIEW MODEL (COACH ID)
		public async Task<ExerciseIndexVM> GetExerciseIndexVMAsync()
		{
			return new ExerciseIndexVM { CoachId = (await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)).Id };
		}

		// GETS EXERCISE CREATE VIEW MODEL
		public async Task<ExerciseCreateVM> GetExerciseCreateVMAsync()
		{
			var exerciseCreateVM = await GetExerciseCreateSelectListsAsync(null);
			return exerciseCreateVM;
		}

		// GETS EXERCISE EDIT VIEW MODEL
		public async Task<ExerciseCreateVM> GetExerciseEditVMAsync(int id)
		{
			var exerciseCreateVM = await GetExerciseCreateSelectListsAsync(id);
			return exerciseCreateVM;
		}

		// GETS EXERCISE DETAILS VIEW MODEL
		public async Task<ExerciseVM> GetExerciseDetailsVMAsync(int id)
		{
			var exercise = await GetAsync(id);
			var exerciseVM = mapper.Map<ExerciseVM>(exercise);
			exerciseVM = await GetExerciseForeignEntitiesAsync(exerciseVM, exercise);

			return exerciseVM;
		}

		// GETS EXERCISE DELETE VIEW MODEL
		public async Task<ExerciseDeleteVM> GetExerciseDeleteVMAsync(int id)
		{
			return mapper.Map<ExerciseDeleteVM>(await GetAsync(id));
		}

		// GETS LIST OF PUBLIC OR PRIVATE EXERCISES
		public async Task<List<ExerciseVM>> GetExerciseVMAsync(string? coachId)
		{
			var exercises = (await GetAllAsync()).Where(e => e.CoachId == coachId).ToList();
			var exerciseVMs = mapper.Map<List<ExerciseVM>>(exercises);

			for (int i = 0; i < exerciseVMs.Count; i++)
			{
				exerciseVMs[i] = await GetExerciseForeignEntitiesAsync(exerciseVMs[i], exercises[i]);
			}

			return exerciseVMs;
		}

		// CREATES A NEW DATABASE ENTITY IN THE EXERCISE TABLE
		public async Task CreateExerciseAsync(ExerciseCreateVM exerciseCreateVM)
		{
			var exercise = mapper.Map<Exercise>(exerciseCreateVM);
			await AddAsync(exercise);
		}

		// EDITS EXISTING DATABAASE ENTITY IN THE EXERCISE TABLE
		public async Task EditExerciseAsync(ExerciseCreateVM exerciseCreateVM)
		{
			var exercise = mapper.Map<Exercise>(exerciseCreateVM);
			await UpdateAsync(exercise);
		}

		// PRIVATE METHODS BELOW

		// GETS THE CATEGORY AND MUSCLE GROUP ENTITIES VOR EXERCISE VIEW MODEL
		private async Task<ExerciseVM> GetExerciseForeignEntitiesAsync(ExerciseVM exerciseVM, Exercise exercise)
		{
			var category = await context.Set<ExerciseCategory>().FindAsync(exercise.ExerciseCategoryId);
			exerciseVM.ExerciseCategory = mapper.Map<ExerciseCategoryVM>(category);

			var muscleGroup = await context.Set<ExerciseMuscleGroup>().FindAsync(exercise.ExerciseMuscleGroupId);
			exerciseVM.ExerciseMuscleGroup = mapper.Map<ExerciseMuscleGroupVM>(muscleGroup);

			return exerciseVM;
		}

		// GETS EXERCISE SELECT LIST FOR CREATE AND EDIT VIEW MODELS
		private async Task<ExerciseCreateVM> GetExerciseCreateSelectListsAsync(int? id)
		{
			var exerciseCreateVM = new ExerciseCreateVM();
			if (id != null)
			{
				exerciseCreateVM = mapper.Map<ExerciseCreateVM>(await GetAsync(id));
			}

			exerciseCreateVM.CoachId = (await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)).Id;
			exerciseCreateVM.AvailableCategories = new SelectList(context.ExerciseCategories.OrderBy(e => e.Name), "Id", "Name");
			exerciseCreateVM.AvailableMuscleGroups = new SelectList(context.ExerciseMuscleGroups.OrderBy(e => e.Name), "Id", "Name");

			return exerciseCreateVM;
		}
	}
}
