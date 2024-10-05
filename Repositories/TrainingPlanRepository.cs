using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using OpenQA.Selenium.DevTools.V125.Page;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Exercise;
using TrainingPlanApp.Web.Models.TrainingPlan;

namespace TrainingPlanApp.Web.Repositories
{
	public class TrainingPlanRepository : GenericRepository<TrainingPlan>, ITrainingPlanRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;
		private readonly IExerciseRepository exerciseRepository;
		private readonly UserManager<User> userManager;
		private readonly IHttpContextAccessor httpContextAccessor;

		public TrainingPlanRepository(ApplicationDbContext context,
			IMapper mapper,
			IExerciseRepository exerciseRepository,
			UserManager<User> userManager,
			IHttpContextAccessor httpContextAccessor) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
			this.exerciseRepository = exerciseRepository;
			this.userManager = userManager;
			this.httpContextAccessor = httpContextAccessor;
		}

		// GETS A LIST OF SPECIFIC USER TRAINING PLANS BASED ON PROVIDED TRAINING PLAN IDs.
		public async Task<TrainingPlanIndexVM> GetTrainingPlanIndexVM(List<int> trainingPlanIds)
		{
			List<TrainingPlanVM> trainingPlanVMs = new List<TrainingPlanVM>();

			foreach (int id in trainingPlanIds)
			{
				var trainingPlan = await GetAsync(id);
				trainingPlanVMs.Add(mapper.Map<TrainingPlanVM>(trainingPlan));
			}

			var trainingPlanIndexVM = new TrainingPlanIndexVM
			{
				UserId = trainingPlanVMs[0].UserId,
				CoachId = trainingPlanVMs[0].CoachId,
				TrainingModuleId = trainingPlanVMs[0].TrainingModuleId,
				TrainingPlanVMs = trainingPlanVMs
			};
			return trainingPlanIndexVM;
		}

		// GETS THE TRAINING PLAN DETAILS VIEW MODEL FOR THE SPECIFIED TRAINING PLAN.
		public async Task<TrainingPlanDetailsVM> GetTrainingPlanDetailsVM(TrainingPlan trainingPlan)
		{
			var trainingPlanDetailsVM = mapper.Map<TrainingPlanDetailsVM>(trainingPlan);
			trainingPlanDetailsVM.ExerciseVMs = await exerciseRepository.GetListOfExercises(trainingPlanDetailsVM.ExerciseIds);
			trainingPlanDetailsVM = sortListsForSingleTrainingPlanDetails(trainingPlanDetailsVM);
			return trainingPlanDetailsVM;
		}

		// GETS THE TRAINING PLAN MANAGE EXERCISES VIEW MODEL FOR THE SPECIFIED TRAINING PLAN ID.
		public async Task<TrainingPlanManageExercisesVM> GetTrainingPlanManageExercisesVM(int? id)
		{
			var trainingPlanManageExercisesVM = mapper.Map<TrainingPlanManageExercisesVM>(await GetAsync(id));
			trainingPlanManageExercisesVM.TrainingPlanAddExerciseVM = new TrainingPlanAddExerciseVM { AvailableExercises = new SelectList(context.Exercises.OrderBy(e => e.Name), "Id", "Name") };
			trainingPlanManageExercisesVM.Exercises = await exerciseRepository.GetListOfExercises(trainingPlanManageExercisesVM.ExerciseIds);
			return trainingPlanManageExercisesVM;
		}

		// CREATES A NEW DATABASE ENTITY IN THE TRAINING PLAN TABLE AND RETURNS THE NEW ID.
		public async Task<int> CreateTrainingPlan(TrainingPlanCreateVM trainingPlanCreateVM)
		{
			var trainingPlan = mapper.Map<TrainingPlan>(trainingPlanCreateVM);

			trainingPlan.ExerciseIds = new List<int?>();
			trainingPlan.Indices = new List<string?>();
			trainingPlan.Sets = new List<int?>();
			trainingPlan.Units = new List<string?>();
			trainingPlan.Weights = new List<string?>();
			trainingPlan.RestTimes = new List<string?>();
			trainingPlan.Notes = new List<string?>();
			trainingPlan.IsCompleted = false;
			trainingPlan.IsEmpty = true;
			await context.AddAsync(trainingPlan);
			await context.SaveChangesAsync();
			return trainingPlan.Id;
		}

		// ADDS AN EXERCISE TO THE SPECIFIED TRAINING PLAN.
		public async Task<TrainingPlanManageExercisesVM> AddExerciseToTrainingPlan(TrainingPlanAddExerciseVM trainingPlanAddExerciseVM)
		{
			var exercise = await exerciseRepository.GetAsync(trainingPlanAddExerciseVM.NewExerciseId);
			if (exercise == null)
			{
				return await GetTrainingPlanManageExercisesVM(trainingPlanAddExerciseVM.TrainingPlanId);
			}

			var trainingPlan = await GetAsync(trainingPlanAddExerciseVM.TrainingPlanId);
			trainingPlan.Indices.Add(trainingPlanAddExerciseVM.NewExerciseIndex);
			trainingPlan.ExerciseIds.Add(trainingPlanAddExerciseVM.NewExerciseId);
			trainingPlan.Sets.Add(trainingPlanAddExerciseVM.NewExerciseSets);
			trainingPlan.Units.Add(trainingPlanAddExerciseVM.NewExerciseUnits);
			trainingPlan.Weights.Add(trainingPlanAddExerciseVM.NewExerciseWeight);
			trainingPlan.RestTimes.Add(trainingPlanAddExerciseVM.NewExerciseRestTime);
			trainingPlan.Notes.Add(trainingPlanAddExerciseVM.NewExerciseNote);
			trainingPlan.IsEmpty = false;
			await UpdateAsync(trainingPlan);

			return await GetTrainingPlanManageExercisesVM(trainingPlanAddExerciseVM.TrainingPlanId);
		}

		// EDITS AN EXERCISE IN THE SPECIFIED TRAINING PLAN.
		public async Task<TrainingPlanManageExercisesVM> EditExerciseInTrainingPlan(TrainingPlanAddExerciseVM trainingPlanAddExerciseVM, int? index)
		{
			var exercise = await exerciseRepository.GetAsync(trainingPlanAddExerciseVM.NewExerciseId);
			if (exercise == null)
			{
				return await GetTrainingPlanManageExercisesVM(trainingPlanAddExerciseVM.TrainingPlanId);
			}

			var trainingPlan = await GetAsync(trainingPlanAddExerciseVM.TrainingPlanId);
			trainingPlan.Indices[index.Value] = trainingPlanAddExerciseVM.NewExerciseIndex;
			trainingPlan.ExerciseIds[index.Value] = trainingPlanAddExerciseVM.NewExerciseId;
			trainingPlan.Sets[index.Value] = trainingPlanAddExerciseVM.NewExerciseSets;
			trainingPlan.Units[index.Value] = trainingPlanAddExerciseVM.NewExerciseUnits;
			trainingPlan.Weights[index.Value] = trainingPlanAddExerciseVM.NewExerciseWeight;
			trainingPlan.RestTimes[index.Value] = trainingPlanAddExerciseVM.NewExerciseRestTime;
			trainingPlan.Notes[index.Value] = trainingPlanAddExerciseVM.NewExerciseNote;
			await UpdateAsync(trainingPlan);

			return await GetTrainingPlanManageExercisesVM(trainingPlanAddExerciseVM.TrainingPlanId);
		}

		// REMOVES AN EXERCISE FROM THE SPECIFIED TRAINING PLAN BASED ON TRAINING PLAN ID AND EXERCISE INDEX.
		public async Task RemoveExerciseFromTrainingPlan(int id, int index)
		{
			var trainingPlan = await GetAsync(id);
			trainingPlan.ExerciseIds.RemoveAt(index);
			trainingPlan.Indices.RemoveAt(index);
			trainingPlan.Sets.RemoveAt(index);
			trainingPlan.Units.RemoveAt(index);
			trainingPlan.Weights.RemoveAt(index);
			trainingPlan.RestTimes.RemoveAt(index);
			trainingPlan.Notes.RemoveAt(index);
			if (trainingPlan.ExerciseIds.Count == 0)
			{
				trainingPlan.IsEmpty = true;
			}
			await UpdateAsync(trainingPlan);
		}

		// CHANGES THE STATUS OF THE TRAINING PLAN (ACTIVE/NOT ACTIVE).
		public async Task ChangeTrainingPlanCompletionStatus(int trainingPlanId, bool status)
		{
			var trainingPlan = await GetAsync(trainingPlanId);
			if (status)
			{
				trainingPlan.IsCompleted = true;
			}
			else
			{
				trainingPlan.IsCompleted = false;
			}
			await UpdateAsync(trainingPlan);
		}

		// COPIES A TRAINING PLAN TO ANOTHER TRAINING PLAN WITHIN THE SAME MODULE.
		public async Task CopyTrainingPlanToAnother(int copyFromId, int copyToId)
		{
			var copyFromTrainingPlan = await GetAsync(copyFromId);
			var copyToTrainingPlan = await GetAsync(copyToId);

			copyToTrainingPlan.IsEmpty = copyFromTrainingPlan.IsEmpty;
			copyToTrainingPlan.ExerciseIds = copyFromTrainingPlan.ExerciseIds;
			copyToTrainingPlan.Indices = copyFromTrainingPlan.Indices;
			copyToTrainingPlan.Sets = copyFromTrainingPlan.Sets;
			copyToTrainingPlan.Units = copyFromTrainingPlan.Units;
			copyToTrainingPlan.Weights = copyFromTrainingPlan.Weights;
			copyToTrainingPlan.RestTimes = copyFromTrainingPlan.RestTimes;
			copyToTrainingPlan.Notes = copyFromTrainingPlan.Notes;
			await UpdateAsync(copyToTrainingPlan);
		}

		// METHODS NOT AVAILABLE OUTSIDE OF THE CLASS BELOW

		static int ExtractNumber(string str)
		{
			var numberString = new string(str.TakeWhile(char.IsDigit).ToArray());
			return int.TryParse(numberString, out var number) ? number : 0;
		}

		static string ExtractLetters(string str)
		{
			var letterString = new string(str.SkipWhile(char.IsDigit).ToArray());
			return letterString;
		}
		static TrainingPlanDetailsVM sortListsForSingleTrainingPlanDetails(TrainingPlanDetailsVM trainingPlanDetailsVM)
		{
			var sortedIndices = trainingPlanDetailsVM.Indices
				.Select((value, index) => new { Index = index, Value = value })
				.Select(x => new { x.Index, NumberPart = ExtractNumber(x.Value), LetterPart = ExtractLetters(x.Value) })
				.OrderBy(x => x.NumberPart)
				.ThenBy(x => x.LetterPart)
				.ToList();

			// Tworzenie nowych list w posortowanej kolejności
			var sortedIndicesList = sortedIndices.Select(x => trainingPlanDetailsVM.Indices[x.Index]).ToList();
			var sortedExercises = sortedIndices.Select(x => trainingPlanDetailsVM.ExerciseVMs[x.Index]).ToList();
			var sortedExerciseIds = sortedIndices.Select(x => trainingPlanDetailsVM.ExerciseIds[x.Index]).ToList();
			var sortedSets = sortedIndices.Select(x => trainingPlanDetailsVM.Sets[x.Index]).ToList();
			var sortedUnits = sortedIndices.Select(x => trainingPlanDetailsVM.Units[x.Index]).ToList();
			var sortedWeights = sortedIndices.Select(x => trainingPlanDetailsVM.Weights[x.Index]).ToList();
			var sortedRestTimes = sortedIndices.Select(x => trainingPlanDetailsVM.RestTimes[x.Index]).ToList();
			var sortedNotes = sortedIndices.Select(x => trainingPlanDetailsVM.Notes[x.Index]).ToList();

			// Aktualizacja oryginalnych list
			trainingPlanDetailsVM.Indices = sortedIndicesList;
			trainingPlanDetailsVM.ExerciseVMs = sortedExercises;
			trainingPlanDetailsVM.ExerciseIds = sortedExerciseIds;
			trainingPlanDetailsVM.Sets = sortedSets;
			trainingPlanDetailsVM.Units = sortedUnits;
			trainingPlanDetailsVM.Weights = sortedWeights;
			trainingPlanDetailsVM.RestTimes = sortedRestTimes;
			trainingPlanDetailsVM.Notes = sortedNotes;

			return trainingPlanDetailsVM;
		}


		static List<TrainingPlanDetailsVM> sortListsForMultipleTrainingPlanDetails(List<TrainingPlanDetailsVM> trainingPlanDetailsVMs)
		{
			foreach (var trainingPlanDetailsVM in trainingPlanDetailsVMs)
			{
				var sortedIndices = trainingPlanDetailsVM.Indices
					.Select((value, index) => new { Index = index, Value = value })
					.Select(x => new { x.Index, NumberPart = ExtractNumber(x.Value), LetterPart = ExtractLetters(x.Value) })
					.OrderBy(x => x.NumberPart)
					.ThenBy(x => x.LetterPart)
					.ToList();

				// Tworzenie nowych list w posortowanej kolejności
				var sortedIndicesList = sortedIndices.Select(x => trainingPlanDetailsVM.Indices[x.Index]).ToList();
				var sortedExercises = sortedIndices.Select(x => trainingPlanDetailsVM.ExerciseVMs[x.Index]).ToList();
				var sortedExerciseIds = sortedIndices.Select(x => trainingPlanDetailsVM.ExerciseIds[x.Index]).ToList();
				var sortedSets = sortedIndices.Select(x => trainingPlanDetailsVM.Sets[x.Index]).ToList();
				var sortedUnits = sortedIndices.Select(x => trainingPlanDetailsVM.Units[x.Index]).ToList();
				var sortedWeights = sortedIndices.Select(x => trainingPlanDetailsVM.Weights[x.Index]).ToList();
				var sortedRestTimes = sortedIndices.Select(x => trainingPlanDetailsVM.RestTimes[x.Index]).ToList();
				var sortedNotes = sortedIndices.Select(x => trainingPlanDetailsVM.Notes[x.Index]).ToList();

				// Aktualizacja oryginalnych list
				trainingPlanDetailsVM.Indices = sortedIndicesList;
				trainingPlanDetailsVM.ExerciseVMs = sortedExercises;
				trainingPlanDetailsVM.ExerciseIds = sortedExerciseIds;
				trainingPlanDetailsVM.Sets = sortedSets;
				trainingPlanDetailsVM.Units = sortedUnits;
				trainingPlanDetailsVM.Weights = sortedWeights;
				trainingPlanDetailsVM.RestTimes = sortedRestTimes;
				trainingPlanDetailsVM.Notes = sortedNotes;

			}
			return trainingPlanDetailsVMs;
		}

	}
}
