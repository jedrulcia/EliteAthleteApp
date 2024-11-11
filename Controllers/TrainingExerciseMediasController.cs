using AutoMapper;
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
        private readonly IMapper mapper;

        public TrainingExerciseMediasController(ITrainingExerciseMediaRepository trainingExerciseMediaRepository, IMapper mapper)
        {
            this.trainingExerciseMediaRepository = trainingExerciseMediaRepository;
            this.mapper = mapper;
        }

        // GET: TrainingExerciseMedia/Edit
        public async Task<IActionResult> EditMedia(int exerciseMediaId)
        {
            return PartialView(await trainingExerciseMediaRepository.GetTrainingExerciseMediaCreateVMAsync(exerciseMediaId));
        }

        // POST: TrainingExerciseMedia/EditMedia/UploadImage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadImage(int index, int id)
        {
            var imageFile = Request.Form.Files[$"imageUpload"];
            await trainingExerciseMediaRepository.UploadImageAsync(id, index, imageFile);
            return RedirectToAction(nameof(Index), "TrainingExercises", new { exerciseMediaId = id });
		}

		// POST: TrainingExerciseMedia/EditMedia/UploadVideo
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UploadVideo(int id)
		{
			var videoFile = Request.Form.Files[$"videoUpload"];
			await trainingExerciseMediaRepository.UploadVideoAsync(id, videoFile);
			return RedirectToAction(nameof(Index), "TrainingExercises", new { exerciseMediaId = id });
		}

		// POST: TrainingExerciseMedia/EditMedia/DeleteImage
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteImage(int index, int id)
        {
            await trainingExerciseMediaRepository.DeleteImageAsync(id, index);
            return RedirectToAction(nameof(Index), "TrainingExercises", new { exerciseMediaId = id });
        }

		// POST: TrainingExerciseMedia/EditMedia/DeleteVideo
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteVideo(int id)
		{
            await trainingExerciseMediaRepository.DeleteVideoAsync(id);
			return RedirectToAction(nameof(Index), "TrainingExercises", new { exerciseMediaId = id });
		}
	}
}
