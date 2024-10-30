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
        private readonly IBlobStorageService blobStorageService;
        private readonly IMapper mapper;

        public TrainingExerciseMediasController(ITrainingExerciseMediaRepository trainingExerciseMediaRepository, IBlobStorageService blobStorageService, IMapper mapper)
        {
            this.trainingExerciseMediaRepository = trainingExerciseMediaRepository;
            this.blobStorageService = blobStorageService;
            this.mapper = mapper;
        }

        // GET: TrainingExerciseMedia/Edit
        public async Task<IActionResult> EditImages(int exerciseMediaId)
        {
            return PartialView(mapper.Map<TrainingExerciseMediaEditImagesVM>(await trainingExerciseMediaRepository.GetAsync(exerciseMediaId)));
        }

        // POST: TrainingExerciseMedia/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadImage(int index, int id)
        {
            var imageFile = Request.Form.Files[$"imageUpload"];

            if (imageFile != null && imageFile.Length > 0)
            {
                var trainingExerciseMedia = await trainingExerciseMediaRepository.GetAsync(id);
                trainingExerciseMedia.ImageUrls[index] = await blobStorageService.UploadExerciseImageAsync(imageFile);
                await trainingExerciseMediaRepository.UpdateAsync(trainingExerciseMedia);
            }


            return RedirectToAction(nameof(Index), "TrainingExercises", new { exerciseMediaId = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteImage(int index, int id)
        {
            var trainingExerciseMedia = await trainingExerciseMediaRepository.GetAsync(id);
            await blobStorageService.RemoveExerciseImageAsync(trainingExerciseMedia.ImageUrls[index]);
            trainingExerciseMedia.ImageUrls[index] = null;
            await trainingExerciseMediaRepository.UpdateAsync(trainingExerciseMedia);

            return RedirectToAction(nameof(Index), "TrainingExercises", new { exerciseMediaId = id });
        }
    }
}
