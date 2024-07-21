using Microsoft.AspNetCore.Mvc;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Contracts
{
    public interface IExerciseRepository : IGenericRepository<Exercise>
    {
        Task CreateNewExercise(ExerciseVM exercise);
        Task EditExercise(ExerciseVM exerciseVM);
        Task<List<ExerciseVM>> GetListOfExercises(List<int?> exercisesIds);
		Task<List<int>?> GetOrderOfExercises(List<string?>? index);

	}
}
