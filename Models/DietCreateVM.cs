using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
{
	public class DietCreateVM
	{
		public int? Id { get; set; }
		[Display(Name = "Athlete")]
		public string? UserId { get; set; }
		[Display(Name = "Diet name")]
		[Required]
		public string? Name { get; set; }
		[Display(Name = "Start date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		[DataType(DataType.Date)]
		public DateTime? StartDate { get; set; }
		[Display(Name = "Description")]
		public string? Description { get; set; }
		[Display(Name = "Status")]
		public bool? IsActive { get; set; }
		[Display(Name = "Breakfast")]
		public int? BreakfastId { get; set; }
		[Display(Name = "Second breakfast")]
		public int? SecondBreakfastId { get; set; }
		[Display(Name = "Lunch")]
		public int? LunchId { get; set; }
		[Display(Name = "Snack")]
		public int? SnackId { get; set; }
		[Display(Name = "Dinner")]
		public int? DinnerId { get; set; }
		public bool RedirectToAdmin { get; set; }
		public SelectList? Meals { get; set; }
	}
}
