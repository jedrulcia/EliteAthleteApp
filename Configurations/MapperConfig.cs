using AutoMapper;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;
using TrainingPlanApp.Web.Models.Diet;
using TrainingPlanApp.Web.Models.Exercise;
using TrainingPlanApp.Web.Models.Ingredient;
using TrainingPlanApp.Web.Models.Meal;
using TrainingPlanApp.Web.Models.TrainingModule;
using TrainingPlanApp.Web.Models.TrainingPlan;

namespace TrainingPlanApp.Web.Configurations
{
    public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			// User module mapping
			CreateMap<User, UserVM>().ReverseMap();

			// Exercise module mapping
			CreateMap<Exercise, ExerciseIndexVM>().ReverseMap();
			CreateMap<Exercise, ExerciseDetailsVM>().ReverseMap();
			CreateMap<Exercise, ExerciseCreateVM>().ReverseMap();

			CreateMap<ExerciseCategory, ExerciseCategoryVM>().ReverseMap();
			CreateMap<ExerciseUnitType, ExerciseUnitTypeVM>().ReverseMap();

			// Training Module module mapping
			CreateMap<TrainingModule, TrainingModuleIndexVM>().ReverseMap();
			CreateMap<TrainingModule, TrainingModuleCreateVM>().ReverseMap();

			// Training Plan module mapping
            CreateMap<TrainingPlan, TrainingPlanIndexVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanCreateVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanManageExercisesVM>().ReverseMap();
			CreateMap<TrainingPlan, TrainingPlanDetailsVM>().ReverseMap();

			// Ingredient module mapping
            CreateMap<Ingredient, IngredientVM>().ReverseMap();

			// Meal module mapping
            CreateMap<Meal, MealIndexVM>().ReverseMap();
			CreateMap<Meal, MealCreateVM>().ReverseMap();
			CreateMap<Meal, MealManageIngredientsVM>().ReverseMap();
			CreateMap<Meal, MealDetailsVM>().ReverseMap();

            // Diet module mapping
            CreateMap<Diet, DietIndexVM>().ReverseMap();
			CreateMap<Diet, DietCreateVM>().ReverseMap();
			CreateMap<Diet, DietManageMealsVM>().ReverseMap();
		}
	}
}
