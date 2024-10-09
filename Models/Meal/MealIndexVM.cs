using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.Meal
{
    public class MealIndexVM
    {
        // IDs
        public string DieticianId {  get; set; }
        public MealCreateVM MealCreateVM { get; set; }
        public List<MealVM> MealVMs { get; set; }
    }
}
