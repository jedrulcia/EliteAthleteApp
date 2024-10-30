using EliteAthleteApp.Contracts;
using EliteAthleteApp.Contracts.Repositories;
using EliteAthleteApp.Contracts.Services;
using EliteAthleteApp.Models.TrainingExercise;
using EliteAthleteApp.Models.TrainingOrm;
using Microsoft.AspNetCore.Mvc;

namespace EliteAthleteApp.Controllers
{
	public class TrainingExerciseMediasController : Controller
	{
		private readonly ITrainingExerciseMediaRepository trainingExerciseMediaRepository;
		private readonly IBlobStorageService blobStorageService;

		public TrainingExerciseMediasController(ITrainingExerciseMediaRepository trainingExerciseMediaRepository, IBlobStorageService blobStorageService)
		{
			this.trainingExerciseMediaRepository = trainingExerciseMediaRepository;
			this.blobStorageService = blobStorageService;
		}
		// GET: TrainingExerciseMedia/Edit
		public async Task<IActionResult> Edit(int exerciseMediaId)
		{
			var model = await trainingExerciseMediaRepository.GetTrainingExerciseMediaEditVMAsync(exerciseMediaId);
			return PartialView(model);
		}

		// POST: TrainingExerciseMedia/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(TrainingExerciseMediaCreateVM trainingExerciseMediaCreateVM)
		{
			var imageFileFirst = Request.Form.Files["imageUploadFirst"];
			var imageFileSecond = Request.Form.Files["imageUploadSecond"];
			var imageFileThird = Request.Form.Files["imageUploadThird"];
			var imageFileVideo = Request.Form.Files["videoUpload"];

			if (imageFileFirst != null && imageFileFirst.Length > 0)
			{
				trainingExerciseMediaCreateVM.ImageUrlFirst = await blobStorageService.UploadExerciseImageAsync(imageFileFirst);
			}
			if (imageFileSecond != null && imageFileSecond.Length > 0)
			{
				trainingExerciseMediaCreateVM.ImageUrlSecond = await blobStorageService.UploadExerciseImageAsync(imageFileSecond);
			}
			if (imageFileThird != null && imageFileThird.Length > 0)
			{
				trainingExerciseMediaCreateVM.ImageUrlThird = await blobStorageService.UploadExerciseImageAsync(imageFileThird);
            }
            if (imageFileVideo != null && imageFileVideo.Length > 0)
            {
                trainingExerciseMediaCreateVM.VideoUrl = await blobStorageService.UploadExerciseVideoAsync(imageFileVideo);
            }

            await trainingExerciseMediaRepository.EditTrainingExerciseMediaAsync(trainingExerciseMediaCreateVM);

			return RedirectToAction(nameof(Index), "TrainingExercises");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task DeleteVideo(string? VideoUrl, int Id)
		{
			var exerciseMedia = await trainingExerciseMediaRepository.GetAsync(Id);
			exerciseMedia.VideoUrl = null;
			await trainingExerciseMediaRepository.UpdateAsync(exerciseMedia);
			blobStorageService.RemoveExerciseVideoAsync(VideoUrl);
		}
	}
}
