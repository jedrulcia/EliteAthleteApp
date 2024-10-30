﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingExercise
{
	public class TrainingExerciseCreateVM
	{
		// IDs
		public int? Id { get; set; }
		public string? CoachId { get; set; }
		[Display(Name = "Category")]
		public int? ExerciseCategoryId { get; set; }
		[Display(Name = "Muscle Group")]
		public int? ExerciseMuscleGroupId { get; set; }
		public int? ExerciseMediaId { get; set; }

		// STRINGS etc.
		[Display(Name = "Exercise")]
		[Required]
		public string Name { get; set; }

		[Display(Name = "Description")]
		public string? Description { get; set; }

		// FORM
		[Display(Name = "Categories")]
		public SelectList? AvailableCategories { get; set; }
		[Display(Name = "Muscle Groups")]
		public SelectList? AvailableMuscleGroups { get; set; }

		// OTHER 
		public bool SetAsPublic { get; set; }
	}
}