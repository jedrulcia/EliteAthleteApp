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

        // Creates new database entity in exercise table
        public async Task CreateExercise(ExerciseVM exerciseVM)
        {
            var exercise = mapper.Map<Exercise>(exerciseVM);
            await AddAsync(exercise);
        }

        // Edits Name, VideoLink, Description of exercise
        public async Task EditExercise(ExerciseVM exerciseVM)
        {
            var exercise = mapper.Map<Exercise>(exerciseVM);
            await UpdateAsync(exercise);
        }

        // Gets list of IDs of specific exercises
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

	}
}
