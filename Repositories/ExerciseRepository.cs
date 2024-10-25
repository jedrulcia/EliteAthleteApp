using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models;
using EliteAthleteApp.Models.Exercise;
using System.ComponentModel;

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

		// GETS EXERCISE INDEX VIEW MODEL LIST.
		public async Task<ExerciseIndexVM> GetExerciseIndexVMAsync()
		{
			return new ExerciseIndexVM { CoachId = (await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)).Id };
		}

		// GETS LIST OF EXERCISE VM
		public async Task<List<ExerciseVM>> GetExerciseVMAsync(string? coachId)
		{
			var exercises = new List<Exercise>();
			exercises = (await GetAllAsync()).Where(e => e.CoachId == coachId).ToList();
			var exerciseVMs = mapper.Map<List<ExerciseVM>>(exercises);

			for (int i = 0; i < exerciseVMs.Count; i++)
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

			return exerciseVMs;
		}

		// GETS EXERCISE CREATE VM
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

		// GETS EXERCISE DELETE VM
		public async Task<ExerciseDeleteVM> GetExerciseDeleteVMAsync(int id)
		{
			return mapper.Map<ExerciseDeleteVM>(await GetAsync(id));
		}

		// GETS EXERCISE DETAILS VM
		public async Task<ExerciseVM> GetExerciseDetailsVMAsync(int id)
		{
			var exercise = await GetAsync(id);
			var exerciseVM = mapper.Map<ExerciseVM>(exercise);

			var category = await context.Set<ExerciseCategory>().FindAsync(exercise.ExerciseCategoryId);
			exerciseVM.ExerciseCategory = mapper.Map<ExerciseCategoryVM>(category);

			var muscleGroup = await context.Set<ExerciseMuscleGroup>().FindAsync(exercise.ExerciseMuscleGroupId);
			exerciseVM.ExerciseMuscleGroup = mapper.Map<ExerciseMuscleGroupVM>(muscleGroup);

			return exerciseVM;
		}

		// GETS EXERCISE EDIT VM
		public async Task<ExerciseCreateVM> GetExerciseEditVMAsync(int id)
		{
			var exerciseCreateVM = mapper.Map<ExerciseCreateVM>(await GetAsync(id));
			exerciseCreateVM.CoachId = (await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User)).Id;
			exerciseCreateVM.AvailableCategories = new SelectList(context.ExerciseCategories.OrderBy(e => e.Name), "Id", "Name");
			exerciseCreateVM.AvailableMuscleGroups = new SelectList(context.ExerciseMuscleGroups.OrderBy(e => e.Name), "Id", "Name");

			return exerciseCreateVM;
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
	}
}
