using Microsoft.AspNetCore.Mvc;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Exercise;

namespace TrainingPlanApp.Web.Contracts
{
    public interface IExerciseRepository : IGenericRepository<Exercise>
    {
        // Gets Exercise Index VM
        Task<List<ExerciseIndexVM>> GetExerciseIndexVM();

        // Gets Exercise Details VM
        Task<ExerciseDetailsVM> GetExerciseDetailsVM(int id);

        // Gets Exercise Create VM
        Task<ExerciseCreateVM> GetExerciseCreateVM();

		// Creates new database entity in exercise table
		Task CreateExercise(ExerciseCreateVM exerciseCreateVM);

        // Gets Exercise Create VM for editing
        Task<ExerciseCreateVM> GetExerciseCreateVMForEditing(int id);

        // Edits Name, VideoLink, Description of exercise
        Task EditExercise(ExerciseCreateVM exerciseCreateVM);

        // Gets list of IDs of specific exercises
        Task<List<ExerciseIndexVM>> GetListOfExercises(List<int?> exercisesIds);

	}
}
