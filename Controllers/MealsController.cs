using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using TrainingPlanApp.Web.Constants;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Meal;
using TrainingPlanApp.Web.Repositories;

namespace TrainingPlanApp.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
	public class MealsController : Controller
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;
		private readonly IMealRepository mealRepository;
		private readonly IIngredientRepository ingredientRepository;
		private readonly IConfiguration config;

		public MealsController(ApplicationDbContext context, IMapper mapper, IMealRepository mealRepository, IIngredientRepository ingredientRepository, IConfiguration config)
		{
			this.context = context;
			this.mapper = mapper;
			this.mealRepository = mealRepository;
			this.ingredientRepository = ingredientRepository;
			this.config = config;
		}

		// GET: Meals
		public async Task<IActionResult> Index()
		{
			var mealsVM = await mealRepository.GetMealIndexVM();
			return View(mealsVM);
		}

		// POST: Meals/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(MealCreateVM mealCreateVM)
		{
			if (ModelState.IsValid)
			{
				var imageFile = Request.Form.Files["imageUpload"];
				if (imageFile != null && imageFile.Length > 0)
				{
					var uploadResult = await UploadImage(); // Call your UploadImage method
					if (uploadResult is OkObjectResult result)
					{
						var fileUrl = ((dynamic)result.Value).FileUrl;
						mealCreateVM.ImageUrl = fileUrl; // Set the image URL
					}
				}
				int? id = await mealRepository.CreateMeal(mealCreateVM);
				return RedirectToAction(nameof(ManageIngredients), new { id = id });
			}
			TempData["ErrorMessage"] = $"Error while creating the meal. Please try again.";
			return RedirectToAction(nameof(Index));
		}

		// POST: Meals/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, MealCreateVM mealCreateVM)
		{
			if (ModelState.IsValid)
			{
				try
				{
					await mealRepository.EditMeal(mealCreateVM);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!await mealRepository.Exists(id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(ManageIngredients), new { id = mealCreateVM.Id });
			}
			TempData["ErrorMessage"] = $"Error while editing the meal. Please try again.";
			return RedirectToAction(nameof(ManageIngredients), new { id = mealCreateVM.Id });
		}

		// POST: Meals/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await mealRepository.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}

		// GET: Meals/ManageIngredients
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> ManageIngredients(int? id)
		{
			var mealManageIngredientsVM = await mealRepository.GetMealManageIngredientsVM(id);
			return View(mealManageIngredientsVM);
		}

		// POST: Meals/ManageIngredients/AddIngredient
		[HttpPost, ActionName("AddIngredient")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> AddIngredient(MealManageIngredientsVM mealManageIngredientsVM)
		{
			await mealRepository.AddIngredientToMeal(mealManageIngredientsVM);
			return RedirectToAction(nameof(ManageIngredients), new { id = mealManageIngredientsVM.Id });
		}

		// POST: Meals/ManageIngredients/RemoveIngredient
		[HttpPost, ActionName("RemoveIngredient")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> RemoveIngredient(int mealId, int index)
		{
			await mealRepository.RemoveIngredientFromMeal(mealId, index);
			return RedirectToAction(nameof(ManageIngredients), new { id = mealId });
		}



		[HttpPost, ActionName("UploadImage")]
		public async Task<IActionResult> UploadImage()
		{
			var files = Request.Form.Files;
			if (files.Count == 0)
			{
				return BadRequest("No files uploaded.");
			}

			string fileUrl = "";
			string systemFileName = files[0].FileName;
			string blobstorageconnection = config.GetValue<string>("BlobConnectionString");
			CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
			CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
			CloudBlobContainer container = blobClient.GetContainerReference(config.GetValue<string>("BlobContainerName"));
			CloudBlockBlob blockblob = container.GetBlockBlobReference(systemFileName);

			try
			{
				await using (var data = files[0].OpenReadStream())
				{
					await blockblob.UploadFromStreamAsync(data);
				}

				fileUrl = blockblob.SnapshotQualifiedUri.AbsoluteUri;
			}
			catch (Exception ex)
			{
				// Log the exception if needed
				return BadRequest("Upload failed: " + ex.Message);
			}

			// Return the file URL or any other response you need
			return Ok(new { FileUrl = fileUrl });
		}
	}
}
