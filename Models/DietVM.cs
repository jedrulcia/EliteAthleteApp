using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models
{
    public class DietVM
    {
        public int? Id { get; set; }
        [Display(Name="Athlete")]
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        [Display(Name="Breakfast")]
        public Meal? Breakfast { get; set; }
        public int? BreakfastId { get; set; }
        [Display(Name = "Second Breakfast")]
        public Meal? SecondBreakfast { get; set; }
        public int? SecondBreakfastId { get; set; }
        [Display(Name = "Lunch")]
        public Meal? Lunch { get; set; }
        public int? LunchId { get; set; }
        [Display(Name = "Snack")]
        public Meal? Snack { get; set; }
        public int? SnackId { get; set; }
        [Display(Name = "Dinner")]
        public Meal? Dinner { get; set; }
        public int? DinnerId { get; set; }
		public bool RedirectToAdmin { get; set; }
	}
}
