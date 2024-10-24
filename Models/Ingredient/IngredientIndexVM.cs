using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Models.Ingredient
{
    public class IngredientIndexVM
    {
        public string DieticianId { get; set; }
        public List<IngredientVM> IngredientVMs { get; set; }
        public IngredientCreateVM? IngredientCreateVM { get; set; }
    }
}
