namespace TrainingPlanApp.Web.Contracts
{
    public interface IMacroRepository
    {
        decimal Proteins { get; set; }
        decimal Carbohydrates { get; set; }
        decimal Fats { get; set; }
        int? Kcal { get; set; }
        List<int?>? IngredientIds { get; set; }
        List<int>? IngredientQuantities { get; set; }
    }
}
