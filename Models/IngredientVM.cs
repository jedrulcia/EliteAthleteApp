using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models
{
    public class IngredientVM
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? ServingSize { get; set; }
    }
}
