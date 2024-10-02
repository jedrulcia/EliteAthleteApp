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
		public async Task<ExerciseIndexVM> GetExerciseIndexVM()
		{
			var coach = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			var exercises = await GetAllAsync();

			var exerciseVMs = mapper.Map<List<ExerciseVM>>(exercises);

			for (int i = 0; i < exercises.Count; i++)
			{
				int? id = exercises[i].ExerciseCategoryId;
				if (id != null)
				{
					var category = await context.Set<ExerciseCategory>().FindAsync(id);
					exerciseVMs[i].ExerciseCategory = mapper.Map<ExerciseCategoryVM>(category);
				}
			}

			var exerciseIndexVM = new ExerciseIndexVM
			{
				ExerciseVMs = exerciseVMs,
				CoachId = coach.Id,
				ExerciseCreateVM = new ExerciseCreateVM
				{
					CoachId = coach.Id,
					AvailableCategories = new SelectList(context.ExerciseCategories.OrderBy(e => e.Name), "Id", "Name")
				}
			};
			return exerciseIndexVM;
		}

		// CREATES A NEW DATABASE ENTITY IN THE EXERCISE TABLE.
		public async Task CreateExercise(ExerciseCreateVM exerciseCreateVM)
		{
			var exercise = mapper.Map<Exercise>(exerciseCreateVM);
			await AddAsync(exercise);
		}

		// EDITS THE NAME, VIDEO LINK, AND DESCRIPTION OF THE SPECIFIED EXERCISE.
		public async Task EditExercise(ExerciseCreateVM exerciseCreateVM)
		{
			var exercise = mapper.Map<Exercise>(exerciseCreateVM);
			await UpdateAsync(exercise);
		}

		// GETS A LIST OF SPECIFIC EXERCISES BASED ON PROVIDED EXERCISE IDs.
		public async Task<List<ExerciseVM>> GetListOfExercises(List<int?> exercisesIds)
		{
			List<ExerciseVM> exercises = new List<ExerciseVM>();
			foreach (int id in exercisesIds)
			{
				var exerciseVM = mapper.Map<ExerciseVM>(await GetAsync(id));
				exercises.Add(exerciseVM);
			}
			return exercises;
		}

		// ARCHIVE

		public string GetErrorMessageFields(ExerciseCreateVM exerciseCreateVM)
		{
			string result = "";
			if (exerciseCreateVM.Name == null) result += "Name ";
			if (exerciseCreateVM.VideoLink == null) result += "Video ";
			return result;
		}

		// GETS EXERCISE CREATE VIEW MODEL FOR NEW EXERCISE CREATION.
		public async Task<ExerciseCreateVM> GetExerciseCreateVM()
		{
			var exerciseCreateVM = new ExerciseCreateVM
			{
				AvailableCategories = new SelectList(context.ExerciseCategories.OrderBy(e => e.Name), "Id", "Name")
			};
			return exerciseCreateVM;
		}

		// GETS EXERCISE CREATE VIEW MODEL FOR EDITING AN EXISTING EXERCISE.
		public async Task<ExerciseCreateVM> GetExerciseEditVM(int id)
		{
			var exerciseCreateVM = mapper.Map<ExerciseCreateVM>(await GetAsync(id));
			exerciseCreateVM.AvailableCategories = new SelectList(context.ExerciseCategories.OrderBy(e => e.Name), "Id", "Name");
			return exerciseCreateVM;
		}
	}
}
