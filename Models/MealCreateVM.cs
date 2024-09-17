using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models
{
    public class MealCreateVM
    {
        // IDs
        public int? Id { get; set; }

        // STRINGS etc.
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Display(Name = "Recipe")]
        public string? Recipe { get; set; }

    }
}
