using TrainingPlanApp.Web.Contracts;

namespace TrainingPlanApp.Web.Repositories
{
    public class MacroRepository : IMacroRepository
    {
        public decimal Proteins { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fats { get; set; }
        public int? Kcal { get; set; }
        public List<int?>? IngredientIds { get; set; }
        public List<int>? IngredientQuantities { get; set; }
    }
}
