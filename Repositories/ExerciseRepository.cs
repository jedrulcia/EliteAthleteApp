using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Exercise;

namespace TrainingPlanApp.Web.Repositories
{
    public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public ExerciseRepository(ApplicationDbContext context, IMapper mapper) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
		}

		// GETS EXERCISE INDEX VIEW MODEL LIST.
		public async Task<List<ExerciseIndexVM>> GetExerciseIndexVM()
		{
			var exercises = await GetAllAsync();
			var exercisesIndexVM = mapper.Map<List<ExerciseIndexVM>>(exercises);

			for (int i = 0; i < exercises.Count; i++)
			{
				int? id = exercises[i].ExerciseCategoryId;
				if (id != null)
				{
					var category = await context.Set<ExerciseCategory>().FindAsync(id);
					exercisesIndexVM[i].ExerciseCategory = mapper.Map<ExerciseCategoryVM>(category);
				}
			}
			return exercisesIndexVM;
		}

		// GETS EXERCISE DETAILS VIEW MODEL FOR THE SPECIFIED EXERCISE ID.
		public async Task<ExerciseDetailsVM> GetExerciseDetailsVM(int id)
		{
			var exercise = await GetAsync(id);
			var exerciseDetailsVM = mapper.Map<ExerciseDetailsVM>(exercise);

			if (exercise.ExerciseCategoryId != null)
			{
				var category = await context.Set<ExerciseCategory>().FindAsync(exercise.ExerciseCategoryId);
				exerciseDetailsVM.ExerciseCategory = mapper.Map<ExerciseCategoryVM>(category);
			}
			return exerciseDetailsVM;
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
		public async Task<List<ExerciseIndexVM>> GetListOfExercises(List<int?> exercisesIds)
		{
			List<ExerciseIndexVM> exercises = new List<ExerciseIndexVM>();
			foreach (int id in exercisesIds)
			{
				var exerciseVM = mapper.Map<ExerciseIndexVM>(await GetAsync(id));
				exercises.Add(exerciseVM);
			}
			return exercises;
		}

		// GETS A LIST OF EXERCISE UNIT TYPES BASED ON PROVIDED UNIT TYPE IDs.
		public async Task<List<ExerciseUnitTypeVM>> GetListOfExerciseUnitTypes(List<int?> exerciseUnitTypesIds)
		{
			List<ExerciseUnitTypeVM> exerciseUnitTypesVM = new List<ExerciseUnitTypeVM>();
			foreach (int? id in exerciseUnitTypesIds)
			{
				if (id != null)
				{
					var exerciseUnitTypeVM = mapper.Map<ExerciseUnitTypeVM>(await context.Set<ExerciseUnitType>().FindAsync(id));
					exerciseUnitTypesVM.Add(exerciseUnitTypeVM);
				}
				else
				{
					exerciseUnitTypesVM.Add(null);
				}
			}
			return exerciseUnitTypesVM;
		}
	}
}
