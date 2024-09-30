﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.Exercise
{
	public class ExerciseCreateVM
	{
		// IDs
		public int? Id { get; set; }
		public int? ExerciseCategoryId {  get; set; }
		public string? CoachId { get; set; }

		// STRINGS etc.
		[Display(Name = "Exercise")]
		[Required]
		public string Name { get; set; }

		[Display(Name = "Video")]
		[Required]
		public string? VideoLink { get; set; }

		[Display(Name = "Description")]
		public string? Description { get; set; }

		// FORM
		[Display(Name = "Categories")]
		public SelectList? AvailableCategories { get; set; }
	}
}
