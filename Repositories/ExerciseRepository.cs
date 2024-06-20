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

        public async Task CreateNewExercise(ExerciseVM exerciseVM)
        {
            var exercise = mapper.Map<Exercise>(exerciseVM);
            await AddAsync(exercise);
        }

        public async Task EditExercise(ExerciseVM exerciseVM)
        {
            var exercise = mapper.Map<Exercise>(exerciseVM);
            await UpdateAsync(exercise);
        }
    }
}
