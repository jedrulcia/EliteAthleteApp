using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

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

			foreach (var exerciseIndexVM in exercisesIndexVM)
			{
				int? id = exerciseIndexVM.ExerciseCategoryId;
				if (id != null)
				{
					var category = await context.Set<ExerciseCategory>().FindAsync(id);
					exerciseIndexVM.ExerciseCategory = mapper.Map<ExerciseCategoryVM>(category);
				}
			}

			return exercisesIndexVM;
		}

		// Creates new database entity in exercise table
		public async Task CreateExercise(ExerciseIndexVM exerciseVM)
		{
			var exercise = mapper.Map<Exercise>(exerciseVM);
			await AddAsync(exercise);
		}

		// Edits Name, VideoLink, Description of exercise
		public async Task EditExercise(ExerciseIndexVM exerciseVM)
		{
			var exercise = mapper.Map<Exercise>(exerciseVM);
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
