﻿using AutoMapper;
using EliteAthleteApp.Contracts.Repositories;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.UserMedicalTest;
using EliteAthleteApp.Models.UserMedicalTest;
using EliteAthleteApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EliteAthleteApp.Controllers
{
	public class UserMedicalTestsController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IUserMedicalTestRepository userMedicalTestRepository;

		public UserMedicalTestsController(UserManager<User> userManager,
			IMapper mapper,
			IHttpContextAccessor httpContextAccessor,
			IUserMedicalTestRepository userMedicalTestRepository)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			this.userMedicalTestRepository = userMedicalTestRepository;
		}

		// GET: UserMedicalTest/List
		public async Task<IActionResult> List(string? userId)
		{
			return PartialView(await userMedicalTestRepository.GetUserMedicalTestVMsAsync(userId));
		}

		// GET: UserMedicalTest/Create
		public IActionResult Create(string userId)
		{
			return PartialView(userMedicalTestRepository.GetUserMedicalTestCreateVM(userId));
		}

		// POST: UserMedicalTest/Create
		[HttpPost, ActionName("Create")]
		public async Task<IActionResult> Create(UserMedicalTestCreateVM userMedicalTestCreateVM)
		{
			var file = Request.Form.Files[$"fileUpload"];
			await userMedicalTestRepository.CreateUserMedicalTestAsync(userMedicalTestCreateVM, file);
			return RedirectToAction("Panel", "Users", new { userId = userMedicalTestCreateVM.UserId });
		}

		// GET: UserMedicalTest/Edit
		public async Task<IActionResult> Edit(int medicalTestId)
		{
			return PartialView(await userMedicalTestRepository.GeUserMedicalTestEditVM(medicalTestId));
		}

		// POST: UserMedicalTest/Edit
		[HttpPost, ActionName("Edit")]
		public async Task<IActionResult> Edit(UserMedicalTestCreateVM userMedicalTestCreateVM)
		{
			var file = Request.Form.Files[$"fileUpload"];
			await userMedicalTestRepository.EditUserMedicalTestAsync(userMedicalTestCreateVM, file);
			return RedirectToAction("Panel", "Users", new { userId = userMedicalTestCreateVM.UserId });
		}

		// GET: UserMedicalTest/Delete
		public async Task<IActionResult> Delete(int medicalTestId)
		{
			return PartialView(await userMedicalTestRepository.GetUserMedicalTestDeleteVM(medicalTestId));
		}

		// POST: UserMedicalTest/Delete
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> Delete(UserMedicalTestDeleteVM userMedicalTestDeleteVM)
		{
			await userMedicalTestRepository.DeleteUserMedicalTestAsync(userMedicalTestDeleteVM);
			return RedirectToAction("Panel", "Users", new { userId = userMedicalTestDeleteVM.UserId });
		}
	}
}
