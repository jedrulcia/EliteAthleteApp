using Microsoft.AspNetCore.Mvc;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Contracts
{
    public interface IExerciseRepository : IGenericRepository<Exercise>
    {
        // Gets Exercise Index VM
        Task<List<ExerciseIndexVM>> GetExerciseIndexVM();

        // Creates new database entity in exercise table
        Task CreateExercise(ExerciseIndexVM exercise);

        // Edits Name, VideoLink, Description of exercise
        Task EditExercise(ExerciseIndexVM exerciseVM);

        // Gets list of IDs of specific exercises
        Task<List<ExerciseIndexVM>> GetListOfExercises(List<int?> exercisesIds);

	}
}
