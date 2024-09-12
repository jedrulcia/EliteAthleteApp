using Microsoft.AspNetCore.Mvc;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Contracts
{
    public interface IExerciseRepository : IGenericRepository<Exercise>
    {
        // Creates new database entity in exercise table
        Task CreateExercise(ExerciseVM exercise);

        // Edits Name, VideoLink, Description of exercise
        Task EditExercise(ExerciseVM exerciseVM);

        // Gets list of IDs of specific exercises
        Task<List<ExerciseVM>> GetListOfExercises(List<int?> exercisesIds);

	}
}
