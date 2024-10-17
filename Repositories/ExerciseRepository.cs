using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;
using TrainingPlanApp.Web.Models.Exercise;

namespace TrainingPlanApp.Web.Repositories
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

		// GETS EXERCISE INDEX VIEW MODEL LIST.
		public async Task<ExerciseIndexVM> GetExerciseIndexVMAsync()
		{
			var exercises = await GetAllAsync();
			var exerciseVMs = mapper.Map<List<ExerciseVM>>(exercises);

			for (int i = 0; i < exercises.Count; i++)
			{
				int? categoryId = exercises[i].ExerciseCategoryId;
				if (categoryId != null)
				{
					var category = await context.Set<ExerciseCategory>().FindAsync(categoryId);
					exerciseVMs[i].ExerciseCategory = mapper.Map<ExerciseCategoryVM>(category);
				}
				int? muscleGroupId = exercises[i].ExerciseMuscleGroupId;
				if (muscleGroupId != null)
				{
					var muscleGroup = await context.Set<ExerciseMuscleGroup>().FindAsync(muscleGroupId);
					exerciseVMs[i].ExerciseMuscleGroup = mapper.Map<ExerciseMuscleGroupVM>(muscleGroup);
				}
			}

			var exerciseIndexVM = new ExerciseIndexVM
			{
				CoachId = (await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)).Id,
				ExerciseVMs = exerciseVMs
			};
			return exerciseIndexVM;
		}

		public async Task<ExerciseCreateVM> GetExerciseCreateVMAsync()
		{
			var exerciseCreateVM = new ExerciseCreateVM
			{
				CoachId = (await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)).Id,
				AvailableCategories = new SelectList(context.ExerciseCategories.OrderBy(e => e.Name), "Id", "Name"),
				AvailableMuscleGroups = new SelectList(context.ExerciseMuscleGroups.OrderBy(e => e.Name), "Id", "Name")
			};
			return exerciseCreateVM;
		}

		public async Task<ExerciseDeleteVM> GetExerciseDeleteVMAsync(int id)
		{
			return mapper.Map<ExerciseDeleteVM>(await GetAsync(id));
		}

		// CREATES A NEW DATABASE ENTITY IN THE EXERCISE TABLE.
		public async Task CreateExerciseAsync(ExerciseCreateVM exerciseCreateVM)
		{
			var exercise = mapper.Map<Exercise>(exerciseCreateVM);
			await AddAsync(exercise);
		}

		// EDITS THE NAME, VIDEO LINK, AND DESCRIPTION OF THE SPECIFIED EXERCISE.
		public async Task EditExerciseAsync(ExerciseCreateVM exerciseCreateVM)
		{
			var exercise = mapper.Map<Exercise>(exerciseCreateVM);
			await UpdateAsync(exercise);
		}

		// GETS A LIST OF SPECIFIC EXERCISES BASED ON PROVIDED EXERCISE IDs.
		public async Task<List<ExerciseVM>> GetListOfExercisesAsync(List<int?> exercisesIds)
		{
			List<ExerciseVM> exercises = new List<ExerciseVM>();
			foreach (int id in exercisesIds)
			{
				var exerciseVM = mapper.Map<ExerciseVM>(await GetAsync(id));
				exercises.Add(exerciseVM);
			}
			return exercises;
		}
	}
}
