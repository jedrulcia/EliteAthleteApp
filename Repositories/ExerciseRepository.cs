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

		public async Task<List<int>?> GetOrderOfExercises(List<string?>? index)
		{
			if (index == null)
			{
				return null;
			}

			var indexedItems = index
				.Select((value, idx) => new { Value = value, OriginalIndex = idx })
				.ToList();

			var sortedItems = indexedItems
				.OrderBy(item => item.Value, new StringComparer())
				.ToList();

			var order = sortedItems
				.Select(item => item.OriginalIndex)
				.ToList();

			var sortedIndex = sortedItems
				.Select(item => item.Value)
				.ToList();

			return order;
		}

		private class StringComparer : IComparer<string?>
		{
			public int Compare(string? x, string? y)
			{
				if (x == null && y == null) return 0;
				if (x == null) return -1;
				if (y == null) return 1;

				(int numberX, string letterX) = SplitNumericAndAlpha(x);
				(int numberY, string letterY) = SplitNumericAndAlpha(y);

				int numberComparison = numberX.CompareTo(numberY);
				if (numberComparison != 0)
				{
					return numberComparison;
				}

				return string.Compare(letterX, letterY, StringComparison.Ordinal);
			}

			private (int, string) SplitNumericAndAlpha(string value)
			{
				int index = 0;
				while (index < value.Length && char.IsDigit(value[index]))
				{
					index++;
				}

				int numberPart = int.Parse(value.Substring(0, index));
				string alphaPart = value.Substring(index);

				return (numberPart, alphaPart);
			}
		}
	}
}
