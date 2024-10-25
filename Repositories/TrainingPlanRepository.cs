using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using OpenQA.Selenium.DevTools.V125.Page;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.Exercise;
using EliteAthleteApp.Models.TrainingPlan;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.IdentityModel.Tokens;
using EliteAthleteApp.Models;

namespace EliteAthleteApp.Repositories
{
	public class TrainingPlanRepository : GenericRepository<TrainingPlan>, ITrainingPlanRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;
		private readonly IExerciseRepository exerciseRepository;
		private readonly UserManager<User> userManager;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly ITrainingPlanExerciseDetailRepository trainingPlanExerciseDetailRepository;

		public TrainingPlanRepository(ApplicationDbContext context,
			IMapper mapper,
			IExerciseRepository exerciseRepository,
			UserManager<User> userManager,
			IHttpContextAccessor httpContextAccessor,
			ITrainingPlanExerciseDetailRepository trainingPlanExerciseDetailRepository) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
			this.exerciseRepository = exerciseRepository;
			this.userManager = userManager;
			this.httpContextAccessor = httpContextAccessor;
			this.trainingPlanExerciseDetailRepository = trainingPlanExerciseDetailRepository;
		}

		// GETS A LIST OF SPECIFIC USER TRAINING PLANS BASED ON PROVIDED TRAINING PLAN IDs.
		public async Task<TrainingPlanIndexVM> GetTrainingPlanIndexVMAsync(List<int> trainingPlanIds)
		{
			List<TrainingPlanVM> trainingPlanVMs = new List<TrainingPlanVM>();

			int completed = 0;
			int notCompleted = 0;

			foreach (int id in trainingPlanIds)
			{
				var trainingPlan = await GetAsync(id);
				var trainingPlanVM = (mapper.Map<TrainingPlanVM>(trainingPlan));
				trainingPlanVMs.Add(trainingPlanVM);
				if (!trainingPlanVM.IsEmpty)
				{
					if (trainingPlanVM.IsCompleted)
					{
						completed++;
					}
					else
					{
						notCompleted++;
					}
				}
			}

			int total = completed + notCompleted;
			int progress = 0;
			if (total != 0)
			{
				float holder = ((float)completed / (float)total) * 100;
				progress = (int)holder;
			}

			var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
			var coach = await userManager.FindByIdAsync(user.CoachId);

			var trainingPlanIndexVM = new TrainingPlanIndexVM
			{
				UserId = user.Id,
				CoachId = coach.Id,
				TrainingModuleId = trainingPlanVMs[0].TrainingModuleId,
				TrainingPlanVMs = trainingPlanVMs,
				Progress = progress
			};
			return trainingPlanIndexVM;
		}

		// GETS THE TRAINING PLAN DETAILS VIEW MODEL FOR THE SPECIFIED TRAINING PLAN.
		public async Task<TrainingPlanDetailsVM> GetTrainingPlanDetailsVMAsync(TrainingPlan trainingPlan)
		{
			var trainingPlanDetailsVM = mapper.Map<TrainingPlanDetailsVM>(trainingPlan);
			trainingPlanDetailsVM.TrainingPlanExerciseDetailVMs = new List<TrainingPlanExerciseDetailVM>();
			trainingPlanDetailsVM.TrainingPlanPhaseVMs = new List<TrainingPlanPhaseVM?>();

			foreach (var id in trainingPlan.TrainingPlanExerciseDetailIds)
			{
				var trainingPlanExerciseDetailVM = mapper.Map<TrainingPlanExerciseDetailVM>(await trainingPlanExerciseDetailRepository.GetAsync(id));
				trainingPlanDetailsVM.TrainingPlanExerciseDetailVMs.Add(trainingPlanExerciseDetailVM);
				var trainingPlanPhaseVM = mapper.Map<TrainingPlanPhaseVM>(await context.Set<TrainingPlanPhase>().FindAsync(trainingPlanExerciseDetailVM.TrainingPlanPhaseId));
				trainingPlanDetailsVM.TrainingPlanPhaseVMs.Add(trainingPlanPhaseVM);
				trainingPlanExerciseDetailVM.ExerciseVM = mapper.Map<ExerciseVM>(await exerciseRepository.GetAsync(trainingPlanExerciseDetailVM.ExerciseId));
			}

			trainingPlanDetailsVM.TrainingPlanExerciseDetailVMs = SortTrainingPlanExerciseDetailVMs(trainingPlanDetailsVM.TrainingPlanExerciseDetailVMs);
			return trainingPlanDetailsVM;
		}

		// GETS THE TRAINING PLAN MANAGE EXERCISES VIEW MODEL FOR THE SPECIFIED TRAINING PLAN ID.
		public async Task<TrainingPlanManageExercisesVM> GetTrainingPlanManageExercisesVMAsync(int? id)
		{
			var trainingPlan = await GetAsync(id);
			var trainingPlanManageExercisesVM = mapper.Map<TrainingPlanManageExercisesVM>(trainingPlan);
			trainingPlanManageExercisesVM.TrainingPlanExerciseDetailVMs = new List<TrainingPlanExerciseDetailVM?>();

			foreach (var exerciseDetailId in trainingPlan.TrainingPlanExerciseDetailIds)
			{
				var trainingPlanExerciseDetailVM = mapper.Map<TrainingPlanExerciseDetailVM>(await trainingPlanExerciseDetailRepository.GetAsync(exerciseDetailId));
				trainingPlanManageExercisesVM.TrainingPlanExerciseDetailVMs.Add(trainingPlanExerciseDetailVM);
			}

			trainingPlanManageExercisesVM.TrainingPlanPhaseVMs = new List<TrainingPlanPhaseVM?>();
			foreach (var trainingPlanExerciseDetailVM in trainingPlanManageExercisesVM.TrainingPlanExerciseDetailVMs)
			{
				var trainingPlanPhaseVM = mapper.Map<TrainingPlanPhaseVM>(await context.Set<TrainingPlanPhase>().FindAsync(trainingPlanExerciseDetailVM.TrainingPlanPhaseId));
				trainingPlanManageExercisesVM.TrainingPlanPhaseVMs.Add(trainingPlanPhaseVM);
				trainingPlanExerciseDetailVM.ExerciseVM = mapper.Map<ExerciseVM>(await exerciseRepository.GetAsync(trainingPlanExerciseDetailVM.ExerciseId));
			}
			return trainingPlanManageExercisesVM;
		}
		public async Task<TrainingPlanChangeStatusVM> GetTrainingPlanChangeStatusVMAsync(int id)
		{
			var trainingPlanVM = mapper.Map<TrainingPlanVM>(await GetAsync(id));
			var trainingPlanChangeStatusVM = new TrainingPlanChangeStatusVM
			{
				Id = trainingPlanVM.Id,
				TrainingModuleId = trainingPlanVM.TrainingModuleId,
				Raport = trainingPlanVM.Raport
			};

			return trainingPlanChangeStatusVM;
		}

		public async Task<TrainingPlanCopyVM> GetTrainingPlanCopyVMAsync(int? copyFromId, List<int> trainingPlanIds)
		{
			List<TrainingPlanVM> trainingPlanVMs = new List<TrainingPlanVM>();

			foreach (int id in trainingPlanIds)
			{
				var trainingPlan = await GetAsync(id);
				trainingPlanVMs.Add(mapper.Map<TrainingPlanVM>(trainingPlan));
			}

			var trainingPlanCopyVM = new TrainingPlanCopyVM
			{
				TrainingModuleId = trainingPlanVMs[0].TrainingModuleId,
				CopyFromId = copyFromId,
				TrainingPlanVMs = trainingPlanVMs
			};
			return trainingPlanCopyVM;
		}

		public async Task<TrainingPlanAddExerciseVM> GetTrainingPlanAddExerciseVMAsync(int trainingPlanId, string coachId)
		{

			return await GetTrainingPlanAddExerciseSelectListsAsync(trainingPlanId, coachId);
		}

		public async Task<TrainingPlanAddExerciseVM> GetTrainingPlanEditExerciseVMAsync(int trainingPlanId, string coachId, int trainingPlanExerciseDetailId)
		{
			var trainingPlanAddExerciseVM = mapper.Map<TrainingPlanAddExerciseVM>(await trainingPlanExerciseDetailRepository.GetAsync(trainingPlanExerciseDetailId));
			var trainingPlanAddExerciseSelectLists = await GetTrainingPlanAddExerciseSelectListsAsync(trainingPlanId, coachId);

			trainingPlanAddExerciseVM.AvailableExercises = trainingPlanAddExerciseSelectLists.AvailableExercises;
			trainingPlanAddExerciseVM.AvailableTrainingPlanPhases = trainingPlanAddExerciseSelectLists.AvailableTrainingPlanPhases;
			trainingPlanAddExerciseVM.TrainingPlanId = trainingPlanId;

			return trainingPlanAddExerciseVM;
		}

		public async Task<TrainingPlanAddExerciseVM> GetTrainingPlanAddExerciseSelectListsAsync(int trainingPlanId, string coachId)
		{
			var trainingPlanAddExerciseVM = new TrainingPlanAddExerciseVM
			{
				AvailableExercises = new SelectList(
					context.Exercises
							.Where(e => e.CoachId == null || e.CoachId == coachId)
							.OrderBy(e => e.Name), "Id", "Name"),
				AvailableTrainingPlanPhases = new SelectList(context.TrainingPlanPhases.OrderBy(e => e.Id), "Id", "Name"),
				TrainingPlanId = trainingPlanId
			};
			return trainingPlanAddExerciseVM;
		}
		public async Task<TrainingPlanRemoveExerciseVM> GetTrainingPlanRemoveExerciseVM(int trainingPlanId, int trainingPlanExerciseDetailId, string name)
		{
			var trainingPlanRemoveExerciseVM = new TrainingPlanRemoveExerciseVM
			{
				Name = name,
				Id = trainingPlanExerciseDetailId,
				TrainingPlanId = trainingPlanId
			};
			return trainingPlanRemoveExerciseVM;
		}

		// CREATES A NEW DATABASE ENTITY IN THE TRAINING PLAN TABLE AND RETURNS THE NEW ID.
		public async Task<int> CreateTrainingPlanAsync(TrainingPlanCreateVM trainingPlanCreateVM)
		{
			var trainingPlan = mapper.Map<TrainingPlan>(trainingPlanCreateVM);

			trainingPlan.TrainingPlanExerciseDetailIds = new List<int?>();
			trainingPlan.IsCompleted = false;
			trainingPlan.IsEmpty = true;
			await context.AddAsync(trainingPlan);
			await context.SaveChangesAsync();
			return trainingPlan.Id;
		}

		// ADDS AN EXERCISE TO THE SPECIFIED TRAINING PLAN.
		public async Task<TrainingPlanManageExercisesVM> AddExerciseToTrainingPlanAsync(TrainingPlanAddExerciseVM trainingPlanAddExerciseVM)
		{
			var exercise = await exerciseRepository.GetAsync(trainingPlanAddExerciseVM.ExerciseId);
			if (exercise == null)
			{
				return await GetTrainingPlanManageExercisesVMAsync(trainingPlanAddExerciseVM.TrainingPlanId);
			}

			var trainingPlanExerciseDetail = mapper.Map<TrainingPlanExerciseDetail>(trainingPlanAddExerciseVM);
			await context.AddAsync(trainingPlanExerciseDetail);
			await context.SaveChangesAsync();

			var trainingPlan = await GetAsync(trainingPlanAddExerciseVM.TrainingPlanId);
			trainingPlan.IsEmpty = false;
			trainingPlan.TrainingPlanExerciseDetailIds.Add(trainingPlanExerciseDetail.Id);
			await UpdateAsync(trainingPlan);

			return await GetTrainingPlanManageExercisesVMAsync(trainingPlanAddExerciseVM.TrainingPlanId);
		}

		// EDITS AN EXERCISE IN THE SPECIFIED TRAINING PLAN.
		public async Task<TrainingPlanManageExercisesVM> EditExerciseInTrainingPlanAsync(TrainingPlanAddExerciseVM trainingPlanAddExerciseVM)
		{
			var exercise = await exerciseRepository.GetAsync(trainingPlanAddExerciseVM.ExerciseId);
			if (exercise == null)
			{
				return await GetTrainingPlanManageExercisesVMAsync(trainingPlanAddExerciseVM.TrainingPlanId);
			}
			int? id = trainingPlanAddExerciseVM.Id;
			var trainingPlanExerciseDetail = mapper.Map<TrainingPlanExerciseDetail>(trainingPlanAddExerciseVM);
			await trainingPlanExerciseDetailRepository.UpdateAsync(trainingPlanExerciseDetail);

			return await GetTrainingPlanManageExercisesVMAsync(trainingPlanAddExerciseVM.TrainingPlanId);
		}

		// REMOVES AN EXERCISE FROM THE SPECIFIED TRAINING PLAN BASED ON TRAINING PLAN ID AND EXERCISE INDEX.
		public async Task RemoveExerciseFromTrainingPlanAsync(TrainingPlanRemoveExerciseVM trainingPlanRemoveExerciseVM)
		{
			var trainingPlan = await GetAsync(trainingPlanRemoveExerciseVM.TrainingPlanId);
			var trainingPlanExerciseDetail = await trainingPlanExerciseDetailRepository.GetAsync(trainingPlanRemoveExerciseVM.Id);

			await trainingPlanExerciseDetailRepository.DeleteAsync(trainingPlanRemoveExerciseVM.Id);
			trainingPlan.TrainingPlanExerciseDetailIds.Remove(trainingPlanRemoveExerciseVM.Id);
			
			if (trainingPlan.TrainingPlanExerciseDetailIds.Count == 0)
			{
				trainingPlan.IsEmpty = true;
			}
			await UpdateAsync(trainingPlan);
		}

		// CHANGES THE STATUS OF THE TRAINING PLAN (ACTIVE/NOT ACTIVE).
		public async Task CompleteTrainingPlanAsync(int trainingPlanId, string raport)
		{
			var trainingPlan = await GetAsync(trainingPlanId);
			trainingPlan.IsCompleted = true;
			trainingPlan.Raport = raport;
			await UpdateAsync(trainingPlan);
		}

		// COPIES A TRAINING PLAN TO ANOTHER TRAINING PLAN WITHIN THE SAME MODULE.
		public async Task CopyTrainingPlanAsync(int copyFromId, int copyToId)
		{
			var copyFromTrainingPlan = await GetAsync(copyFromId);
			var copyToTrainingPlan = await GetAsync(copyToId);

			copyToTrainingPlan.IsEmpty = copyFromTrainingPlan.IsEmpty;
			var trainingPlanExerciseDetailIds = copyFromTrainingPlan.TrainingPlanExerciseDetailIds;

			foreach (var id in trainingPlanExerciseDetailIds)
			{
				var copyToExerciseDetail = await trainingPlanExerciseDetailRepository.GetAsync(id);
				copyToExerciseDetail.Id = null;
				await trainingPlanExerciseDetailRepository.AddAsync(copyToExerciseDetail);
				copyToTrainingPlan.TrainingPlanExerciseDetailIds.Add(copyToExerciseDetail.Id);
			}
			await UpdateAsync(copyToTrainingPlan);
		}

		// GENERATES TRAINING MODULE IN PDF
		public async Task<byte[]> GetTrainingModulePDFAsync(List<int> trainingPlanIds)
		{
			List<TrainingPlanDetailsVM> trainingPlanVMs = new List<TrainingPlanDetailsVM>();

			foreach (int id in trainingPlanIds)
			{
				var trainingPlan = await GetAsync(id);
				trainingPlanVMs.Add(await GetTrainingPlanDetailsVMAsync(trainingPlan));
			}

			PdfDocument document = new PdfDocument();
			document.Info.Title = "Training Plan";
			XFont font = new XFont("Verdana", 20, XFontStyleEx.Bold);

			List<PdfPage> pageList = new List<PdfPage>();
			pageList.Add(document.AddPage());
			XGraphics gfx = XGraphics.FromPdfPage(pageList[0]);

			int tableX = 50;
			int tableY = 50;
			int rowHeight = 15;
			int columnWidth = 110;
			int tableYOffset = 0;

			foreach (var trainingPlanVM in trainingPlanVMs)
			{
				if (!trainingPlanVM.TrainingPlanExerciseDetailVMs.IsNullOrEmpty())
				{
					if (tableY + trainingPlanVM.TrainingPlanExerciseDetailVMs.Count * 15 > 842)
					{
						font = new XFont("Verdana", 8, XFontStyleEx.Bold);
						gfx.DrawString($"str.{pageList.Count}", font, XBrushes.Black, new XRect(570, 830, 5, 5), XStringFormats.Center);
						pageList.Add(document.AddPage());
						tableY = 50;
						gfx = XGraphics.FromPdfPage(pageList[pageList.Count - 1]);
					}

					font = new XFont("Verdana", 20, XFontStyleEx.Bold);
					gfx.DrawString($"{trainingPlanVM.Name}", font, XBrushes.Black, new XRect(tableX, tableY - 20, columnWidth, rowHeight), XStringFormats.CenterLeft);

					for (int i = 0; i < trainingPlanVM.TrainingPlanExerciseDetailVMs.Count; i++)
					{
						font = new XFont("Verdana", 12, XFontStyleEx.Regular);
						gfx.DrawRectangle(XPens.Black, tableX + columnWidth * 0, tableY + rowHeight * i, columnWidth + 50, rowHeight);
						gfx.DrawRectangle(XPens.Black, tableX + columnWidth * 1 + 50, tableY + rowHeight * i, columnWidth, rowHeight);
						gfx.DrawRectangle(XPens.Black, tableX + columnWidth * 2 + 50, tableY + rowHeight * i, columnWidth, rowHeight);
						gfx.DrawRectangle(XPens.Black, tableX + columnWidth * 3 + 50, tableY + rowHeight * i, columnWidth, rowHeight);

						gfx.DrawString($"{trainingPlanVM.TrainingPlanExerciseDetailVMs[i].Index}: {trainingPlanVM.TrainingPlanExerciseDetailVMs[i].ExerciseVM.Name}", font, XBrushes.Black, new XRect(tableX + columnWidth * 0, tableY + rowHeight * i, columnWidth + 50, rowHeight), XStringFormats.CenterLeft);
						gfx.DrawString($"{trainingPlanVM.TrainingPlanExerciseDetailVMs[i].Sets}x{trainingPlanVM.TrainingPlanExerciseDetailVMs[i].Units}", font, XBrushes.Black, new XRect(tableX + columnWidth * 1 + 50, tableY + rowHeight * i, columnWidth, rowHeight), XStringFormats.Center);
						gfx.DrawString($"Weight: {trainingPlanVM.TrainingPlanExerciseDetailVMs[i].Weight}", font, XBrushes.Black, new XRect(tableX + columnWidth * 2 + 50, tableY + rowHeight * i, columnWidth, rowHeight), XStringFormats.Center);
						gfx.DrawString($"Rest: {trainingPlanVM.TrainingPlanExerciseDetailVMs[i].RestTime}", font, XBrushes.Black, new XRect(tableX + columnWidth * 3 + 50, tableY + rowHeight * i, columnWidth, rowHeight), XStringFormats.Center);
						tableYOffset += 15;
					}
					tableY += tableYOffset + 30;
					tableYOffset = 0;
				}
			}
			font = new XFont("Verdana", 8, XFontStyleEx.Bold);
			gfx.DrawString($"str.{pageList.Count}", font, XBrushes.Black, new XRect(570, 830, 5, 5), XStringFormats.Center);

			using (MemoryStream stream = new MemoryStream())
			{
				document.Save(stream);

				return stream.ToArray();
			}
		}

		// METHODS NOT AVAILABLE OUTSIDE OF THE CLASS BELOW

		// SORTS ALL LISTS BY INDICES LIST
		private List<TrainingPlanExerciseDetailVM> SortTrainingPlanExerciseDetailVMs(List<TrainingPlanExerciseDetailVM> trainingPlanExerciseDetailVMs)
		{
			var sortedList = trainingPlanExerciseDetailVMs
				.Select(x => new
				{
					TrainingPlanExerciseDetail = x,
					NumberPart = ExtractNumber(x.Index),
					LetterPart = ExtractLetters(x.Index)
				})
				.OrderBy(x => x.NumberPart)
				.ThenBy(x => x.LetterPart)
				.Select(x => x.TrainingPlanExerciseDetail)
				.ToList();

			return sortedList;
		}

		// EXTRACTS NUMBER FROM INDICES
		private int ExtractNumber(string str)
		{
			var numberString = new string(str.TakeWhile(char.IsDigit).ToArray());
			return int.TryParse(numberString, out var number) ? number : 0;
		}

		// EXTRACTS LETTER FROM INDICES
		private string ExtractLetters(string str)
		{
			var letterString = new string(str.SkipWhile(char.IsDigit).ToArray());
			return letterString;
		}
	}
}
