using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.Exercise;
using EliteAthleteApp.Contracts.Repositories;

namespace EliteAthleteApp.Repositories
{
	public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;
		private readonly UserManager<User> userManager;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IExerciseCategoryRepository exerciseCategoryRepository;
		private readonly IExerciseMuscleGroupRepository exerciseMuscleGroupRepository;

		public ExerciseRepository(ApplicationDbContext context, 
			IMapper mapper, 
			UserManager<User> userManager, 
			IHttpContextAccessor httpContextAccessor, 
			IExerciseCategoryRepository exerciseCategoryRepository,
			IExerciseMuscleGroupRepository exerciseMuscleGroupRepository) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
			this.userManager = userManager;
			this.httpContextAccessor = httpContextAccessor;
			this.exerciseCategoryRepository = exerciseCategoryRepository;
			this.exerciseMuscleGroupRepository = exerciseMuscleGroupRepository;
		}

		// GETS EXERCISE INDEX VIEW MODEL (COACH ID)
		public async Task<ExerciseIndexVM> GetExerciseIndexVMAsync()
		{
			return new ExerciseIndexVM { CoachId = (await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)).Id };
		}

		// GETS LIST OF PUBLIC OR PRIVATE EXERCISES
		public async Task<List<ExerciseVM>> GetExerciseVMsAsync(string? coachId)
		{
			var exercises = (await GetAllAsync()).Where(e => e.CoachId == coachId).ToList();
			var exerciseVMs = mapper.Map<List<ExerciseVM>>(exercises);

			for (int i = 0; i < exerciseVMs.Count; i++)
			{
				exerciseVMs[i] = await GetExerciseForeignEntitiesAsync(exerciseVMs[i], exercises[i]);
			}

			return exerciseVMs;
		}

		// GETS EXERCISE CREATE VIEW MODEL
		public async Task<ExerciseCreateVM> GetExerciseCreateVMAsync()
		{
			return await GetExerciseCreateSelectListsAsync(null);
		}

		// GETS EXERCISE EDIT VIEW MODEL
		public async Task<ExerciseCreateVM> GetExerciseEditVMAsync(int id)
		{
			return await GetExerciseCreateSelectListsAsync(mapper.Map<ExerciseCreateVM>(await GetAsync(id)));
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

		// CREATES A NEW DATABASE ENTITY IN THE EXERCISE TABLE
		public async Task CreateExerciseAsync(ExerciseCreateVM exerciseCreateVM)
		{
			await AddAsync(mapper.Map<Exercise>(exerciseCreateVM));
		}

		// EDITS EXISTING DATABAASE ENTITY IN THE EXERCISE TABLE
		public async Task EditExerciseAsync(ExerciseCreateVM exerciseCreateVM)
		{
			await UpdateAsync(mapper.Map<Exercise>(exerciseCreateVM));
		}

		// PRIVATE METHODS BELOW

		// GETS THE CATEGORY AND MUSCLE GROUP ENTITIES VOR EXERCISE VIEW MODEL
		private async Task<ExerciseVM> GetExerciseForeignEntitiesAsync(ExerciseVM exerciseVM, Exercise exercise)
		{
			exerciseVM.ExerciseCategory = mapper.Map<ExerciseCategoryVM>(await exerciseCategoryRepository.GetAsync(exercise.ExerciseCategoryId));
			exerciseVM.ExerciseMuscleGroup = mapper.Map<ExerciseMuscleGroupVM>(await exerciseMuscleGroupRepository.GetAsync(exercise.ExerciseMuscleGroupId));

			return exerciseVM;
		}

		// GETS EXERCISE SELECT LIST FOR CREATE AND EDIT VIEW MODELS
		private async Task<ExerciseCreateVM> GetExerciseCreateSelectListsAsync(ExerciseCreateVM? exerciseCreateVM)
		{
			if (exerciseCreateVM == null)
			{
				exerciseCreateVM = new ExerciseCreateVM();
			}

			exerciseCreateVM.CoachId = (await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)).Id;
			exerciseCreateVM.AvailableCategories = new SelectList(mapper.Map<List<ExerciseCategoryVM>>(await exerciseCategoryRepository
				.GetAllAsync())
				.OrderBy(e => e.Name), "Id", "Name");
			exerciseCreateVM.AvailableMuscleGroups = new SelectList(mapper.Map<List<ExerciseMuscleGroupVM>>(await exerciseMuscleGroupRepository
				.GetAllAsync())
				.OrderBy(e => e.Name), "Id", "Name");

			return exerciseCreateVM;
		}
	}
}
