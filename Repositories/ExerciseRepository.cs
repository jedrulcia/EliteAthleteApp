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

		// Gets Exercise Index VM
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

		// Gets Exercise Details VM
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

		// Gets Exercise Create VM
		public async Task<ExerciseCreateVM> GetExerciseCreateVM()
		{
			var exerciseCreateVM = new ExerciseCreateVM
			{
				AvailableCategories = new SelectList(context.ExerciseCategories.OrderBy(e => e.Name), "Id", "Name")
			};
			return exerciseCreateVM;
		}

		// Creates new database entity in exercise table
		public async Task CreateExercise(ExerciseCreateVM exerciseCreateVM)
		{
			var exercise = mapper.Map<Exercise>(exerciseCreateVM);
			await AddAsync(exercise);
		}

        // Gets Exercise Create VM for editing
        public async Task<ExerciseCreateVM> GetExerciseCreateVMForEditing(int id)
        {
			var exerciseCreateVM = mapper.Map<ExerciseCreateVM>(await GetAsync(id));
			exerciseCreateVM.AvailableCategories = new SelectList(context.ExerciseCategories.OrderBy(e => e.Name), "Id", "Name");
			return exerciseCreateVM;
        }

        // Edits Name, VideoLink, Description of exercise
        public async Task EditExercise(ExerciseCreateVM exerciseCreateVM)
		{
			var exercise = mapper.Map<Exercise>(exerciseCreateVM);
			await UpdateAsync(exercise);
		}

		// Gets list of IDs of specific exercises
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

    }
}
