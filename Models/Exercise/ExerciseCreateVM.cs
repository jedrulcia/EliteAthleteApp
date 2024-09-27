using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.Exercise
{
	public class ExerciseCreateVM
	{
		// IDs
		public int Id { get; set; }
		public int? ExerciseCategoryId {  get; set; }

		// STRINGS etc.
		[Display(Name = "Exercise")]
		[Required]
		public string Name { get; set; }

		[Display(Name = "Video")]
		[Required]
		public string? VideoLink { get; set; }

		[Display(Name = "Description")]
		public string? Description { get; set; }

		// OTHER
		[Display(Name = "Category")]
		public ExerciseCategoryVM? ExerciseCategory { get; set; }

		[Display(Name = "Categories")]
		public SelectList? AvailableCategories { get; set; }
	}
}
